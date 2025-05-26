using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Models;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Data;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Services;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NexaWorksContext _context;
        private readonly IQuerySelectionService _queryService;

        public HomeController(ILogger<HomeController> logger, NexaWorksContext context, IQuerySelectionService queryService)
        {
            _logger = logger;
            _context = context;
            _queryService = queryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Nouvelle action pour obtenir les options des listes déroulantes
        [HttpGet]
        public async Task<IActionResult> GetDropdownOptions(string dataSource, string? parentValue = null)
        {
            try
            {
                var options = await _queryService.GetDropdownOptions(dataSource, parentValue);
                return Json(new { success = true, data = options });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting dropdown options for {DataSource}", dataSource);
                return Json(new { success = false, error = ex.Message });
            }
        }

        // Nouvelle action pour obtenir les requêtes disponibles en JSON
        [HttpGet]
        public IActionResult GetAvailableQueries()
        {
            var queries = _queryService.GetAvailableQueries()
                .Select(q => new {
                    q.Id,
                    q.Name,
                    q.Description,
                    q.Category,
                    Parameters = q.Parameters.Select(p => new {
                        p.Name,
                        p.Type,
                        p.Label,
                        p.Placeholder,
                        p.Required,
                        p.DefaultValue,
                        p.DataSource,
                        p.DependsOn,
                        p.Options
                    })
                })
                .GroupBy(q => q.Category)
                .ToDictionary(g => g.Key, g => g.ToList());

            return Json(queries);
        }

        // Action pour exécuter une requête sélectionnée
        [HttpPost]
        public async Task<IActionResult> ExecuteSelectedQuery([FromBody] QueryExecutionRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.QueryId))
                    return BadRequest(new { error = "ID de requête requis" });

                // Convertir les paramètres selon leur type
                var convertedParams = new List<object>();
                var queryDef = _queryService.GetAvailableQueries().FirstOrDefault(q => q.Id == request.QueryId);
                
                if (queryDef == null)
                    return BadRequest(new { error = $"Requête '{request.QueryId}' non trouvée" });

                // Valider et convertir les paramètres
                for (int i = 0; i < queryDef.Parameters.Count; i++)
                {
                    var paramDef = queryDef.Parameters[i];
                    var value = i < request.Parameters.Count ? request.Parameters[i] : paramDef.DefaultValue;
                    
                    if (paramDef.Required && string.IsNullOrEmpty(value))
                        return BadRequest(new { error = $"Le paramètre '{paramDef.Label}' est requis" });

                    // Conversion selon le type
                    object convertedValue = paramDef.Type switch
                    {
                        "date" => DateTime.Parse(value!),
                        "number" => Convert.ToDouble(value!),
                        "string" => value!,
                        _ => value!
                    };
                    
                    convertedParams.Add(convertedValue);
                }

                // Exécuter la requête
                var results = await _queryService.ExecuteQuery(request.QueryId, convertedParams.ToArray());
                
                _logger.LogInformation("Executed query {QueryId} with {ParamCount} parameters", request.QueryId, convertedParams.Count);
                
                return Json(new { 
                    success = true, 
                    data = results,
                    queryInfo = new {
                        queryDef.Name,
                        queryDef.Description,
                        parametersUsed = convertedParams.Count
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing query {QueryId}", request.QueryId);
                return Json(new { success = false, error = ex.Message });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class QueryExecutionRequest
    {
        public string QueryId { get; set; } = null!;
        public List<string> Parameters { get; set; } = new();
    }
}

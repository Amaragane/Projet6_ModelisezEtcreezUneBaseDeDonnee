using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Data;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Models;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Controllers
{
    public class QueryController : Controller
    {
        private readonly NexaWorksContext _context;

        public QueryController(NexaWorksContext context)
        {
            _context = context;
        }

        // Page principale pour sélectionner et exécuter les requêtes
        public async Task<IActionResult> Index()
        {
            // Charger les données pour les listes déroulantes
            ViewBag.Products = await _context.Products.OrderBy(p => p.ProductName).ToListAsync();
            ViewBag.Versions = await _context.Versions.OrderBy(v => v.VersionName).ToListAsync();
            ViewBag.Os = await _context.Os.OrderBy(o => o.OsName).ToListAsync();
            ViewBag.Statuts = await _context.Statuts.ToListAsync();

            return View();
        }

        // API pour obtenir les versions compatibles avec un produit
        [HttpGet]
        public async Task<JsonResult> GetVersionsByProduct(int productId)
        {
            var versions = await _context.ProductVersionOsSupport
                .Where(pvos => pvos.ProductId == productId)
                .Select(pvos => pvos.Version)
                .Distinct()
                .OrderBy(v => v.VersionName)
                .ToListAsync();

            return Json(versions);
        }

        // Exécution des requêtes - EXACTEMENT les 20 requêtes du PDF
        [HttpPost]
        public async Task<IActionResult> ExecuteQuery(string queryType, int? productId, int? versionId, int? osId, 
            DateTime? dateDebut, DateTime? dateFin, string? motsCles)
        {
            try
            {
                var result = queryType switch
                {
                    "1" => await GetProblemsInProgress(),
                    "2" => await GetProblemsInProgressByProduct(productId),
                    "3" => await GetProblemsInProgressByProductAndVersion(productId, versionId),
                    "4" => await GetProblemsByPeriodAndProduct(dateDebut, dateFin, productId),
                    "5" => await GetProblemsByPeriodProductAndVersion(dateDebut, dateFin, productId, versionId),
                    "6" => await GetProblemsInProgressByKeywords(motsCles),
                    "7" => await GetProblemsInProgressByProductAndKeywords(productId, motsCles),
                    "8" => await GetProblemsInProgressByProductVersionAndKeywords(productId, versionId, motsCles),
                    "9" => await GetProblemsByPeriodProductAndKeywords(dateDebut, dateFin, productId, motsCles),
                    "10" => await GetProblemsByPeriodProductVersionAndKeywords(dateDebut, dateFin, productId, versionId, motsCles),
                    "11" => await GetProblemsResolved(),
                    "12" => await GetProblemsResolvedByProduct(productId),
                    "13" => await GetProblemsResolvedByProductAndVersion(productId, versionId),
                    "14" => await GetProblemsResolvedByPeriodAndProduct(dateDebut, dateFin, productId),
                    "15" => await GetProblemsResolvedByPeriodProductAndVersion(dateDebut, dateFin, productId, versionId),
                    "16" => await GetProblemsResolvedByKeywords(motsCles),
                    "17" => await GetProblemsResolvedByProductAndKeywords(productId, motsCles),
                    "18" => await GetProblemsResolvedByProductVersionAndKeywords(productId, versionId, motsCles),
                    "19" => await GetProblemsResolvedByPeriodProductAndKeywords(dateDebut, dateFin, productId, motsCles),
                    "20" => await GetProblemsResolvedByPeriodProductVersionAndKeywords(dateDebut, dateFin, productId, versionId, motsCles),
                    _ => throw new ArgumentException("Type de requête non reconnu")
                };

                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        // ===================================================
        // REQUÊTES EN COURS (1-10)
        // ===================================================

        // 1. Obtenir tous les problèmes en cours (tous les produits)
        private async Task<object> GetProblemsInProgress()
        {
            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "En cours")
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.Description
                })
                .ToListAsync();
        }

        // 2. Obtenir tous les problèmes en cours pour un produit (toutes les versions)
        private async Task<object> GetProblemsInProgressByProduct(int? productId)
        {
            if (!productId.HasValue) return new List<object>();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "En cours" && t.ProductId == productId)
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.Description
                })
                .ToListAsync();
        }

        // 3. Obtenir tous les problèmes en cours pour un produit (une seule version)
        private async Task<object> GetProblemsInProgressByProductAndVersion(int? productId, int? versionId)
        {
            if (!productId.HasValue || !versionId.HasValue) return new List<object>();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "En cours" && t.ProductId == productId && t.VersionId == versionId)
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.Description
                })
                .ToListAsync();
        }

        // 4. Obtenir tous les problèmes rencontrés au cours d'une période donnée pour un produit (toutes les versions)
        private async Task<object> GetProblemsByPeriodAndProduct(DateTime? dateDebut, DateTime? dateFin, int? productId)
        {
            if (!dateDebut.HasValue || !dateFin.HasValue || !productId.HasValue) return new List<object>();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.DateCreation >= dateDebut && t.DateCreation <= dateFin && t.ProductId == productId)
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    Statut = t.Statut.State,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description
                })
                .ToListAsync();
        }

        // 5. Obtenir tous les problèmes rencontrés au cours d'une période donnée pour un produit (une seule version)
        private async Task<object> GetProblemsByPeriodProductAndVersion(DateTime? dateDebut, DateTime? dateFin, int? productId, int? versionId)
        {
            if (!dateDebut.HasValue || !dateFin.HasValue || !productId.HasValue || !versionId.HasValue) return new List<object>();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.DateCreation >= dateDebut && t.DateCreation <= dateFin && t.ProductId == productId && t.VersionId == versionId)
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    Statut = t.Statut.State,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description
                })
                .ToListAsync();
        }

        // 6. Obtenir tous les problèmes en cours contenant une liste de mots-clés (tous les produits)
        private async Task<object> GetProblemsInProgressByKeywords(string? motsCles)
        {
            if (string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "En cours" &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.Description
                })
                .ToListAsync();
        }

        // 7. Obtenir tous les problèmes en cours pour un produit contenant une liste de mots-clés (toutes les versions)
        private async Task<object> GetProblemsInProgressByProductAndKeywords(int? productId, string? motsCles)
        {
            if (!productId.HasValue || string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "En cours" && t.ProductId == productId &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.Description
                })
                .ToListAsync();
        }

        // 8. Obtenir tous les problèmes en cours pour un produit contenant une liste de mots-clés (une seule version)
        private async Task<object> GetProblemsInProgressByProductVersionAndKeywords(int? productId, int? versionId, string? motsCles)
        {
            if (!productId.HasValue || !versionId.HasValue || string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "En cours" && t.ProductId == productId && t.VersionId == versionId &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.Description
                })
                .ToListAsync();
        }

        // 9. Obtenir tous les problèmes rencontrés au cours d'une période donnée pour un produit contenant une liste de mots-clés (toutes les versions)
        private async Task<object> GetProblemsByPeriodProductAndKeywords(DateTime? dateDebut, DateTime? dateFin, int? productId, string? motsCles)
        {
            if (!dateDebut.HasValue || !dateFin.HasValue || !productId.HasValue || string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.DateCreation >= dateDebut && t.DateCreation <= dateFin && t.ProductId == productId &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    Statut = t.Statut.State,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description
                })
                .ToListAsync();
        }

        // 10. Obtenir tous les problèmes rencontrés au cours d'une période donnée pour un produit contenant une liste de mots-clés (une seule version)
        private async Task<object> GetProblemsByPeriodProductVersionAndKeywords(DateTime? dateDebut, DateTime? dateFin, int? productId, int? versionId, string? motsCles)
        {
            if (!dateDebut.HasValue || !dateFin.HasValue || !productId.HasValue || !versionId.HasValue || string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.DateCreation >= dateDebut && t.DateCreation <= dateFin && t.ProductId == productId && t.VersionId == versionId &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    Statut = t.Statut.State,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description
                })
                .ToListAsync();
        }

        // ===================================================
        // REQUÊTES RÉSOLUES (11-20)
        // ===================================================

        // 11. Obtenir tous les problèmes résolus (tous les produits)
        private async Task<object> GetProblemsResolved()
        {
            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu")
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }

        // 12. Obtenir tous les problèmes résolus pour un produit (toutes les versions)
        private async Task<object> GetProblemsResolvedByProduct(int? productId)
        {
            if (!productId.HasValue) return new List<object>();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu" && t.ProductId == productId)
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }

        // 13. Obtenir tous les problèmes résolus pour un produit (une seule version)
        private async Task<object> GetProblemsResolvedByProductAndVersion(int? productId, int? versionId)
        {
            if (!productId.HasValue || !versionId.HasValue) return new List<object>();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu" && t.ProductId == productId && t.VersionId == versionId)
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }

        // 14. Obtenir tous les problèmes résolus au cours d'une période donnée pour un produit (toutes les versions)
        private async Task<object> GetProblemsResolvedByPeriodAndProduct(DateTime? dateDebut, DateTime? dateFin, int? productId)
        {
            if (!dateDebut.HasValue || !dateFin.HasValue || !productId.HasValue) return new List<object>();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu" && t.DateResolution >= dateDebut && t.DateResolution <= dateFin && t.ProductId == productId)
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }

        // 15. Obtenir tous les problèmes résolus au cours d'une période donnée pour un produit (une seule version)
        private async Task<object> GetProblemsResolvedByPeriodProductAndVersion(DateTime? dateDebut, DateTime? dateFin, int? productId, int? versionId)
        {
            if (!dateDebut.HasValue || !dateFin.HasValue || !productId.HasValue || !versionId.HasValue) return new List<object>();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu" && t.DateResolution >= dateDebut && t.DateResolution <= dateFin && t.ProductId == productId && t.VersionId == versionId)
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }

        // 16. Obtenir tous les problèmes résolus contenant une liste de mots-clés (tous les produits)
        private async Task<object> GetProblemsResolvedByKeywords(string? motsCles)
        {
            if (string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu" &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }

        // 17. Obtenir tous les problèmes résolus pour un produit contenant une liste de mots-clés (toutes les versions)
        private async Task<object> GetProblemsResolvedByProductAndKeywords(int? productId, string? motsCles)
        {
            if (!productId.HasValue || string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu" && t.ProductId == productId &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }

        // 18. Obtenir tous les problèmes résolus pour un produit contenant une liste de mots-clés (une seule version)
        private async Task<object> GetProblemsResolvedByProductVersionAndKeywords(int? productId, int? versionId, string? motsCles)
        {
            if (!productId.HasValue || !versionId.HasValue || string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu" && t.ProductId == productId && t.VersionId == versionId &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }

        // 19. Obtenir tous les problèmes résolus au cours d'une période donnée pour un produit contenant une liste de mots-clés (toutes les versions)
        private async Task<object> GetProblemsResolvedByPeriodProductAndKeywords(DateTime? dateDebut, DateTime? dateFin, int? productId, string? motsCles)
        {
            if (!dateDebut.HasValue || !dateFin.HasValue || !productId.HasValue || string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu" && t.DateResolution >= dateDebut && t.DateResolution <= dateFin && t.ProductId == productId &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }

        // 20. Obtenir tous les problèmes résolus au cours d'une période donnée pour un produit contenant une liste de mots-clés (une seule version)
        private async Task<object> GetProblemsResolvedByPeriodProductVersionAndKeywords(DateTime? dateDebut, DateTime? dateFin, int? productId, int? versionId, string? motsCles)
        {
            if (!dateDebut.HasValue || !dateFin.HasValue || !productId.HasValue || !versionId.HasValue || string.IsNullOrEmpty(motsCles)) return new List<object>();

            var keywords = motsCles.Split(',').Select(k => k.Trim()).ToList();

            return await _context.Tickets
                .Include(t => t.Product)
                .Include(t => t.Version)
                .Include(t => t.Os)
                .Include(t => t.Statut)
                .Where(t => t.Statut.State == "Résolu" && t.DateResolution >= dateDebut && t.DateResolution <= dateFin && t.ProductId == productId && t.VersionId == versionId &&
                           keywords.Any(mot => t.Description.Contains(mot) || (t.Resolution != null && t.Resolution.Contains(mot))))
                .Select(t => new
                {
                    t.TicketId,
                    Produit = t.Product.ProductName,
                    Version = t.Version.VersionName,
                    OS = t.Os.OsName,
                    t.DateCreation,
                    t.DateResolution,
                    t.Description,
                    t.Resolution
                })
                .ToListAsync();
        }
    }
}

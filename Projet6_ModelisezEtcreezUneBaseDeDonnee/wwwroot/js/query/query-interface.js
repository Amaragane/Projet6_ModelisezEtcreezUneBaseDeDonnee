/**
 * ===================================================
 * NEXAWORK QUERY INTERFACE - JAVASCRIPT
 * ===================================================
 */

// Variables globales
let currentResults = null;
let currentQueryType = null;

// Configuration
const CONFIG = {
    ENDPOINTS: {
        GET_VERSIONS: '/Query/GetVersionsByProduct',
        EXECUTE_QUERY: '/Query/ExecuteQuery'
    }
};

// ===================================================
// GESTION DE LA SÉLECTION DYNAMIQUE
// ===================================================

async function updateVersions(productId, versionSelectId) {
    const versionSelect = document.getElementById(versionSelectId);
    
    if (!versionSelect) {
        console.error(`Element avec ID ${versionSelectId} non trouvé`);
        return;
    }
    
    if (!productId) {
        versionSelect.innerHTML = '<option value="">-- Sélectionnez d\'abord un produit --</option>';
        return;
    }
    
    versionSelect.innerHTML = '<option value="">⏳ Chargement des versions...</option>';
    versionSelect.disabled = true;
    
    try {
        const response = await fetch(`${CONFIG.ENDPOINTS.GET_VERSIONS}?productId=${productId}`);
        
        if (!response.ok) {
            throw new Error(`Erreur HTTP: ${response.status}`);
        }
        
        const versions = await response.json();
        
        versionSelect.innerHTML = '<option value="">-- Sélectionnez une version --</option>';
        
        if (versions && versions.length > 0) {
            versions.forEach(version => {
                const option = document.createElement('option');
                option.value = version.versionId;
                option.textContent = version.versionName;
                versionSelect.appendChild(option);
            });
        } else {
            versionSelect.innerHTML = '<option value="">Aucune version disponible</option>';
        }
        
    } catch (error) {
        console.error('Erreur lors du chargement des versions:', error);
        versionSelect.innerHTML = '<option value="">❌ Erreur de chargement</option>';
        showError('Erreur lors du chargement des versions: ' + error.message);
    } finally {
        versionSelect.disabled = false;
    }
}

// ===================================================
// EXÉCUTION DES REQUÊTES
// ===================================================

async function executeQuery(queryType, params = {}) {
    const resultsDiv = document.getElementById('results');
    const resultsContent = document.getElementById('results-content');
    
    if (!resultsDiv || !resultsContent) {
        console.error('Elements de résultats non trouvés');
        return;
    }
    
    // Validation des paramètres
    const validationResult = validateQueryParams(queryType, params);
    if (!validationResult.isValid) {
        showError(validationResult.message);
        return;
    }
    
    // Afficher le loader
    showLoading(resultsDiv, resultsContent);
    
    try {
        // Préparer les données du formulaire
        const formData = createFormData(queryType, params);
        
        // Exécuter la requête
        const response = await fetch(CONFIG.ENDPOINTS.EXECUTE_QUERY, {
            method: 'POST',
            body: formData
        });
        
        if (!response.ok) {
            throw new Error(`Erreur HTTP: ${response.status} - ${response.statusText}`);
        }
        
        const result = await response.json();
        
        if (result.success) {
            displayResults(result.data, queryType);
        } else {
            showError(result.error || 'Erreur inconnue lors de l\'exécution de la requête');
        }
        
    } catch (error) {
        console.error('Erreur lors de l\'exécution de la requête:', error);
        showError('Erreur lors de l\'exécution de la requête: ' + error.message);
    }
}

function validateQueryParams(queryType, params) {
    const validationRules = {
        '2': ['productId'],
        '3': ['productId', 'versionId'],
        '4': ['dateDebut', 'dateFin', 'productId'],
        '5': ['dateDebut', 'dateFin', 'productId', 'versionId'],
        '6': ['motsCles'],
        '7': ['productId', 'motsCles'],
        '8': ['productId', 'versionId', 'motsCles'],
        '9': ['dateDebut', 'dateFin', 'productId', 'motsCles'],
        '10': ['dateDebut', 'dateFin', 'productId', 'versionId', 'motsCles'],
        '12': ['productId'],
        '13': ['productId', 'versionId'],
        '14': ['dateDebut', 'dateFin', 'productId'],
        '15': ['dateDebut', 'dateFin', 'productId', 'versionId'],
        '16': ['motsCles'],
        '17': ['productId', 'motsCles'],
        '18': ['productId', 'versionId', 'motsCles'],
        '19': ['dateDebut', 'dateFin', 'productId', 'motsCles'],
        '20': ['dateDebut', 'dateFin', 'productId', 'versionId', 'motsCles']
    };
    
    const requiredParams = validationRules[queryType] || [];
    
    for (const param of requiredParams) {
        if (!params[param] || params[param].toString().trim() === '') {
            const paramNames = {
                'productId': 'un produit',
                'versionId': 'une version',
                'dateDebut': 'une date de début',
                'dateFin': 'une date de fin',
                'motsCles': 'des mots-clés'
            };
            
            return {
                isValid: false,
                message: `Veuillez sélectionner ${paramNames[param] || param}`
            };
        }
    }
    
    // Validation des dates
    if (params.dateDebut && params.dateFin) {
        const debut = new Date(params.dateDebut);
        const fin = new Date(params.dateFin);
        
        if (debut > fin) {
            return {
                isValid: false,
                message: 'La date de début doit être antérieure à la date de fin'
            };
        }
    }
    
    return { isValid: true };
}

function createFormData(queryType, params) {
    const formData = new FormData();
    formData.append('queryType', queryType);
    
    Object.keys(params).forEach(key => {
        const value = params[key];
        if (value !== null && value !== undefined && value.toString().trim() !== '') {
            formData.append(key, value.toString().trim());
        }
    });
    
    return formData;
}

// ===================================================
// AFFICHAGE DES RÉSULTATS
// ===================================================

function showLoading(resultsDiv, resultsContent) {
    resultsDiv.classList.remove('hidden');
    resultsContent.innerHTML = '<div class="loading">Exécution de la requête en cours...</div>';
}

function displayResults(data, queryType) {
    // Stocker les résultats pour référence
    currentResults = data;
    currentQueryType = queryType;
    
    const resultsContent = document.getElementById('results-content');
    
    if (!data || data.length === 0) {
        resultsContent.innerHTML = '<div class="success">Requête exécutée avec succès, mais aucun résultat trouvé.</div>';
        return;
    }
    
    // Affichage spécial pour les statistiques
    if (queryType === 'stats_product' || queryType === 'stats_os') {
        displayStats(data, queryType);
        return;
    }
    
    // Affichage spécial pour la matrice de compatibilité
    if (queryType === 'compatibility') {
        displayCompatibilityMatrix(data);
        return;
    }
    
    // Affichage standard en tableau
    displayTable(data);
}

function displayTable(data) {
    const resultsContent = document.getElementById('results-content');
    
    let html = `<div class="success">${data.length} résultat(s) trouvé(s)</div>`;
    html += '<table class="results-table">';
    
    // En-têtes du tableau
    if (data.length > 0) {
        html += '<thead><tr>';
        Object.keys(data[0]).forEach(key => {
            html += `<th>${formatColumnName(key)}</th>`;
        });
        html += '</tr></thead>';
    }
    
    // Données du tableau
    html += '<tbody>';
    data.forEach(row => {
        html += '<tr>';
        Object.values(row).forEach(value => {
            html += `<td>${formatValue(value)}</td>`;
        });
        html += '</tr>';
    });
    html += '</tbody></table>';
    
    resultsContent.innerHTML = html;
}

function displayStats(data, queryType) {
    const resultsContent = document.getElementById('results-content');
    
    let html = '<div class="success">Statistiques générées avec succès</div>';
    html += '<div class="stats-container">';
    
    data.forEach(item => {
        html += '<div class="stats-card">';
        
        if (queryType === 'stats_product') {
            html += `<h4>📦 ${item.produit}</h4>`;
        } else {
            html += `<h4>💻 ${item.os}</h4>`;
        }
        
        html += `<div class="stats-number">${item.nombreTickets}</div>`;
        html += '<div class="stats-label">Total tickets</div>';
        html += '<div class="stats-details">';
        html += `<span class="en-cours">En cours: ${item.ticketsEnCours}</span>`;
        html += `<span class="resolus">Résolus: ${item.ticketsResolus}</span>`;
        html += '</div>';
        html += '</div>';
    });
    
    html += '</div>';
    resultsContent.innerHTML = html;
}

function displayCompatibilityMatrix(data) {
    const resultsContent = document.getElementById('results-content');
    
    let html = '<div class="success">Matrice de compatibilité générée avec succès</div>';
    html += '<table class="results-table">';
    html += '<thead><tr><th>Produit</th><th>Version</th><th>Système d\'exploitation</th></tr></thead>';
    html += '<tbody>';
    
    data.forEach(item => {
        html += '<tr>';
        html += `<td>📦 ${item.produit}</td>`;
        html += `<td>🔢 ${item.version}</td>`;
        html += `<td>💻 ${item.os}</td>`;
        html += '</tr>';
    });
    
    html += '</tbody></table>';
    resultsContent.innerHTML = html;
}

function showError(message) {
    const resultsDiv = document.getElementById('results');
    const resultsContent = document.getElementById('results-content');
    
    if (resultsDiv && resultsContent) {
        resultsDiv.classList.remove('hidden');
        resultsContent.innerHTML = `<div class="error">${message}</div>`;
    } else {
        alert('Erreur: ' + message);
    }
}

// ===================================================
// FORMATAGE DES DONNÉES
// ===================================================

function formatColumnName(columnName) {
    const translations = {
        'ticketId': 'ID Ticket',
        'produit': 'Produit',
        'version': 'Version',
        'os': 'Système d\'exploitation',
        'statut': 'Statut',
        'dateCreation': 'Date création',
        'dateResolution': 'Date résolution',
        'description': 'Description',
        'resolution': 'Résolution'
    };
    
    return translations[columnName] || columnName;
}

function formatValue(value) {
    if (value === null || value === undefined) {
        return '<span class="value-null">Non défini</span>';
    }
    
    // Formater les dates
    if (typeof value === 'string' && value.match(/^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}/)) {
        const date = new Date(value);
        return `<span class="value-date">${date.toLocaleDateString('fr-FR')}</span>`;
    }
    
    // Tronquer les descriptions longues
    if (typeof value === 'string' && value.length > 100) {
        const truncated = value.substring(0, 100);
        return `<span class="value-truncated" title="${escapeHtml(value)}">${escapeHtml(truncated)}...</span>`;
    }
    
    return escapeHtml(value.toString());
}

function escapeHtml(text) {
    const div = document.createElement('div');
    div.textContent = text;
    return div.innerHTML;
}

// ===================================================
// UTILITAIRES
// ===================================================

function initializeDates() {
    const today = new Date();
    const lastMonth = new Date(today.getFullYear(), today.getMonth() - 1, today.getDate());
    
    document.querySelectorAll('input[type="date"]').forEach(input => {
        if (input.id.includes('Debut')) {
            input.value = lastMonth.toISOString().split('T')[0];
        } else if (input.id.includes('Fin')) {
            input.value = today.toISOString().split('T')[0];
        }
    });
}

// ===================================================
// INITIALISATION
// ===================================================

function initializeInterface() {
    try {
        initializeDates();
        
        console.log('%c🔍 NexaWork Query Interface Initialisée', 'color: #667eea; font-size: 16px; font-weight: bold;');
        console.log('Interface prête à l\'utilisation!');
        
    } catch (error) {
        console.error('Erreur lors de l\'initialisation:', error);
        showError('Erreur lors de l\'initialisation de l\'interface');
    }
}

// Initialisation au chargement de la page
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initializeInterface);
} else {
    initializeInterface();
}

// Exposer les fonctions principales au scope global
window.updateVersions = updateVersions;
window.executeQuery = executeQuery;

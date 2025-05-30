# 🔍 Interface de Requêtes NexaWork

## Vue d'ensemble

Cette interface ultra légère permet d'exécuter facilement toutes les requêtes LINQ sur la base de données des tickets de support NexaWork. Elle offre une interface intuitive avec des formulaires dynamiques qui s'adaptent selon le type de requête sélectionné.

## ✨ Fonctionnalités

### 🎯 **Sélection Intelligente**
- **Produits :** Liste déroulante avec tous les produits disponibles
- **Versions :** Se met à jour automatiquement selon le produit sélectionné
- **Compatibilité :** Seules les versions compatibles avec le produit sont affichées
- **Validation :** Empêche l'exécution de requêtes avec des paramètres manquants

### 📊 **Types de Requêtes Disponibles**

#### **1. Problèmes en Cours (📋)**
- Requête 1 : Tous les problèmes en cours (tous produits)
- Requête 2 : Problèmes en cours par produit
- Requête 3 : Problèmes en cours par produit et version

#### **2. Problèmes par Période (📅)**
- Requête 4 : Problèmes sur une période pour un produit
- Requête 5 : Problèmes sur une période pour un produit et version
- **Dates pré-remplies** avec le mois dernier par défaut

#### **3. Recherche par Mots-clés (🔎)**
- Requête 6 : Recherche dans tous les produits
- Requête 7 : Recherche dans un produit spécifique
- Requête 8 : Recherche dans un produit et version spécifiques
- **Support multi-mots-clés** séparés par des virgules

#### **4. Problèmes Résolus (✅)**
- Requête 11 : Tous les problèmes résolus
- Requête 12 : Problèmes résolus par produit
- Requête 13 : Problèmes résolus par produit et version

#### **5. Statistiques et Analyses (📊)**
- Statistiques par produit
- Statistiques par OS
- Matrice de compatibilité produit/version/OS

## 🚀 Guide d'utilisation

### **Démarrage Rapide**
1. Lancez l'application : `dotnet run`
2. Ouvrez votre navigateur sur `https://localhost:5001`
3. L'interface de requêtes s'ouvre automatiquement

### **Exécution d'une Requête Simple**
1. **Choisissez une section** (ex: "Problèmes en cours")
2. **Sélectionnez une requête** (ex: Requête 1)
3. **Cliquez sur "Exécuter"**
4. **Consultez les résultats** dans le tableau en bas de page

### **Requêtes avec Paramètres**
1. **Sélectionnez un produit** dans la liste déroulante
2. **La liste des versions se met à jour automatiquement**
3. **Choisissez une version** (si nécessaire)
4. **Remplissez les autres champs** (dates, mots-clés)
5. **Cliquez sur "Exécuter"**

### **Recherche par Mots-clés**
- Entrez plusieurs mots-clés séparés par des virgules
- Exemple : `mémoire, crash, GPS`
- La recherche s'effectue dans les descriptions ET les résolutions

### **Sélection de Période**
- Les dates sont pré-remplies avec le mois dernier
- Modifiez selon vos besoins
- Format : AAAA-MM-JJ

## 🎨 Interface Utilisateur

### **Design Moderne**
- **Gradient coloré** en arrière-plan
- **Cartes flottantes** avec effets de survol
- **Boutons animés** avec feedback visuel
- **Tableau responsive** pour les résultats

### **Expérience Utilisateur**
- **Feedback instantané** avec messages de succès/erreur
- **Loading indicators** pendant l'exécution
- **Validation en temps réel** des formulaires
- **Descriptions claires** pour chaque requête

### **Affichage des Résultats**
- **Tableaux stylisés** avec en-têtes colorés
- **Formatage automatique** des dates
- **Troncature intelligente** des descriptions longues
- **Cartes spéciales** pour les statistiques

## 🔧 Fonctionnalités Techniques

### **AJAX Asynchrone**
- Exécution des requêtes sans rechargement de page
- Gestion d'erreurs robuste
- Feedback utilisateur en temps réel

### **API Dynamique**
- Endpoint `/Query/GetVersionsByProduct` pour la compatibilité
- Endpoint `/Query/ExecuteQuery` pour l'exécution
- Responses JSON avec gestion d'erreurs

### **Validation Côté Client**
```javascript
// Vérification automatique des paramètres requis
if (!productId || !versionId) {
    showError('Veuillez sélectionner un produit et une version');
    return;
}
```

## 📝 Exemples d'Utilisation

### **Exemple 1 : Problèmes en cours pour "Planificateur d'Entraînement"**
1. Section : "📋 Problèmes en cours"
2. Requête 2 : "Obtenir tous les problèmes en cours pour un produit"
3. Produit : "Planificateur d'Entraînement"
4. Clic : "Exécuter"

### **Exemple 2 : Recherche de problèmes de mémoire**
1. Section : "🔎 Recherche par mots-clés"
2. Requête 6 : "Problèmes en cours contenant une liste de mots-clés"
3. Mots-clés : "mémoire, RAM, fuite"
4. Clic : "Exécuter"

### **Exemple 3 : Statistiques par produit**
1. Section : "📊 Statistiques et analyses"
2. Bouton : "📈 Statistiques par produit"
3. Résultat : Cartes avec nombre de tickets par produit

## 🛠️ Structure du Code

### **Contrôleur Principal**
```csharp
[HttpPost]
public async Task<IActionResult> ExecuteQuery(string queryType, int? productId, ...)
{
    var result = queryType switch
    {
        "1" => await GetProblemsInProgress(),
        "2" => await GetProblemsInProgressByProduct(productId),
        // ... autres requêtes
    };
    return Json(new { success = true, data = result });
}
```

### **JavaScript Client**
```javascript
async function executeQuery(queryType, params = {}) {
    // Validation des paramètres
    // Appel AJAX
    // Affichage des résultats
}
```

## 🎯 Avantages de cette Interface

### **Pour les Développeurs**
- ✅ **Copier-coller facile** : Toutes les requêtes LINQ sont prêtes
- ✅ **Test rapide** : Interface de test intégrée
- ✅ **Debug simple** : Messages d'erreur clairs
- ✅ **Extension facile** : Architecture modulaire

### **Pour les Utilisateurs**
- ✅ **Interface intuitive** : Pas besoin de connaître SQL/LINQ
- ✅ **Résultats immédiats** : Affichage en temps réel
- ✅ **Validation automatique** : Empêche les erreurs
- ✅ **Design moderne** : Expérience utilisateur agréable

## 🚀 Prochaines Étapes

1. **Créez votre migration** : `dotnet ef migrations add InitialCreate`
2. **Appliquez la migration** : `dotnet ef database update`
3. **Lancez l'application** : `dotnet run`
4. **Testez les requêtes** : Naviguez vers l'interface
5. **Copiez les requêtes** : Utilisez le fichier `RequetesLINQ_NexaWork.txt`

## 📋 Checklist Finale

- [ ] Migration créée et appliquée
- [ ] Base de données initialisée avec les données de test
- [ ] Application lancée sans erreurs
- [ ] Interface accessible sur https://localhost:5001
- [ ] Toutes les listes déroulantes se chargent correctement
- [ ] Les requêtes s'exécutent et retournent des résultats
- [ ] Les statistiques s'affichent correctement

**🎉 Votre interface de requêtes NexaWork est prête à l'emploi !**

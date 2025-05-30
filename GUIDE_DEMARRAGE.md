# 🚀 Guide de Démarrage Rapide - Interface NexaWork

## Étapes pour Démarrer

### 1. ✅ Corriger le DbContext (Déjà fait)
Les erreurs dans les relations ont été corrigées dans `NexaWorkContext.cs`

### 2. 🗄️ Créer et Appliquer les Migrations

```bash
# Dans le terminal, naviguez vers le dossier du projet
cd "C:\Users\Micka\source\repos\Projet6_ModelisezEtcreezUneBaseDeDonnee\Projet6_ModelisezEtcreezUneBaseDeDonnee"

# Supprimez les anciennes migrations si elles existent
Remove-Item -Recurse -Force .\Migrations\* -ErrorAction SilentlyContinue

# Créez une nouvelle migration
dotnet ef migrations add InitialCreate

# Appliquez la migration à la base de données
dotnet ef database update
```

### 3. 🚀 Lancer l'Application

```bash
# Démarrer l'application
dotnet run
```

### 4. 🌐 Tester l'Interface

1. **Ouvrez votre navigateur** sur : `https://localhost:5001` ou `http://localhost:5000`
2. **L'interface de requêtes s'ouvre automatiquement**
3. **Testez une requête simple** :
   - Cliquez sur "Exécuter la requête" pour la Requête 1
   - Vous devriez voir les tickets en cours

### 5. 🧪 Tests Recommandés

#### Test 1 : Requête Simple
- **Requête 1** : "Tous les problèmes en cours"
- **Résultat attendu** : Liste des tickets avec statut "En cours"

#### Test 2 : Sélection de Produit
- **Requête 2** : Sélectionnez "Planificateur d'Entraînement"
- **Résultat attendu** : Tickets du produit sélectionné

#### Test 3 : Produit + Version
- **Requête 3** : 
  1. Sélectionnez "Planificateur d'Entraînement"
  2. Attendez que les versions se chargent
  3. Sélectionnez "2.0"
- **Résultat attendu** : Tickets spécifiques à cette version

#### Test 4 : Recherche par Mots-clés
- **Requête 6** : Entrez "mémoire, GPS"
- **Résultat attendu** : Tickets contenant ces mots-clés

#### Test 5 : Statistiques
- **Cliquez sur "📈 Statistiques par produit"**
- **Résultat attendu** : Cartes avec le nombre de tickets par produit

## ⚠️ Résolution de Problèmes

### Problème : "Connection string not found"
**Solution :** Vérifiez que `appsettings.json` contient :
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=NexaWork;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Problème : "Cannot create database"
**Solution :** Assurez-vous que SQL Server LocalDB est installé :
```bash
# Vérifier SQL Server
sqllocaldb info
```

### Problème : "Les listes déroulantes sont vides"
**Solution :** Les données de seed ne se sont pas chargées. Vérifiez :
1. La migration s'est bien appliquée
2. Les données sont dans la base : ouvrez SQL Server Management Studio

### Problème : "Erreur lors de l'exécution des requêtes"
**Solution :** Vérifiez la console du navigateur (F12) pour voir les erreurs JavaScript

## 📊 Données de Test Disponibles

L'application contient **25 tickets de test** répartis sur :
- **4 produits** : Trader en Herbe, Maître des Investissements, Planificateur d'Entraînement, Planificateur d'Anxiété Sociale
- **6 versions** : 1.0, 1.1, 1.2, 1.3, 2.0, 2.1
- **6 OS** : Linux, Windows, MacOS, Android, iOS, Windows Mobile
- **2 statuts** : En cours, Résolu

## 🎯 Fonctionnalités Testées

### ✅ Interface Responsive
- Design adaptatif
- Effets de survol
- Animations fluides

### ✅ Sélection Dynamique
- Les versions se mettent à jour selon le produit
- Validation des champs requis
- Messages d'erreur explicites

### ✅ Exécution des Requêtes
- 20 requêtes principales implémentées
- 3 requêtes de statistiques
- Affichage des résultats en tableau

### ✅ Gestion des Erreurs
- Messages d'erreur utilisateur-friendly
- Validation côté client et serveur
- Feedback visuel pour le loading

## 🔗 Fichiers Importants

- **Interface** : `/Views/Query/Index.cshtml`
- **Contrôleur** : `/Controllers/QueryController.cs`
- **DbContext** : `/Data/NexaWorkContext.cs`
- **Modèles** : `/Models/*.cs`
- **Requêtes LINQ** : `/RequetesLINQ_NexaWork.txt`

## 🎉 C'est Prêt !

Une fois ces étapes terminées, vous avez une interface complète pour :
- ✅ Tester toutes vos requêtes LINQ
- ✅ Voir les résultats en temps réel
- ✅ Copier-coller les requêtes dans vos projets
- ✅ Analyser les données avec des statistiques

**Bon développement avec NexaWork ! 🚀**

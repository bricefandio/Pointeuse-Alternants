# Pointeuse-pour-alternants-2

# 🎓 Pointeuse pour Alternants

## 🧠 Description du projet
**Pointeuse pour Alternants** est une solution complète de gestion des présences destinée aux établissements accueillant des alternants (formation en entreprise et à l’école).  
Le projet permet d’automatiser le suivi des étudiants grâce à un **système de pointage par QR Code**, relié à une **API centrale** et accessible depuis plusieurs applications (desktop, web, mobile).

Ce projet démontre la mise en place d’un **écosystème connecté** utilisant plusieurs technologies modernes de l’écosystème .NET.

---

## 🧩 Architecture globale

| Composant | Type d’application | Rôle |
|------------|--------------------|------|
| 🧠 **Pointeuse.API** | ASP.NET Core Web API | Serveur central REST – gère les données et la logique |
| 💾 **Pointeuse.Data** | .NET Class Library | Contient les modèles et le contexte Entity Framework Core |
| 🖥️ **Pointeuse.DesktopGestion** | WinForms (.NET 8) | Gestion des étudiants, groupes et promotions (CRUD + export Excel) |
| 💻 **Pointeuse.WebApp** | ASP.NET Core MVC | Interface web de suivi des présences et retards |
| 📱 **Pointeuse.Maui** | .NET MAUI | Application mobile pour étudiants (génération QR code) |
| 🖲️ **Pointeuse.Borne** | WinForms (.NET 8) | Application borne avec lecteur QR (pointage automatique) |
| 🗄️ **SQL Server** | Base de données | Centralise toutes les informations partagées |

---

## 🌐 Schéma d’architecture

            +-----------------------+
            |   Pointeuse.WebApp    |
            |  (Visualisation web)  |
            +-----------▲-----------+
                        │
                        ▼

+-----------------+ +----------------------+ +-----------------+
| Pointeuse.Maui | --> | | <-- | Pointeuse.Desktop|
| (Génération QR) | | Pointeuse.API | | (Gestion CRUD) |
+-----------------+ | ASP.NET Core REST | +-----------------+
| + Entity Framework |
+----------▲-----------+
│
▼
+--------------+
| SQL Server |
+--------------+



---

## 🧱 Technologies utilisées

| Domaine | Technologie |
|----------|--------------|
| Langage principal | C# (.NET 8) |
| Frameworks | ASP.NET Core, WinForms, .NET MAUI |
| Base de données | SQL Server |
| ORM | Entity Framework Core |
| QR Code | [QRCoder](https://github.com/codebude/QRCoder) |
| Lecture QR | [ZXing.Net](https://github.com/micjahn/ZXing.Net) |
| Export Excel | [EPPlus](https://github.com/EPPlusSoftware/EPPlus) |
| IDE | Visual Studio 2022 |
| Gestion de version | Git + GitHub |

---

## 🗃️ Base de données

### Tables principales

| Table | Champs | Description |
|--------|---------|-------------|
| **Etudiants** | Id, Nom, Prenom, GroupeId, PromotionId, QrCodeHash | Informations de base |
| **Groupes** | Id, Type (“FE”, “FA”) | Type de formation |
| **Promotions** | Id, Annee | Année scolaire |
| **Pointages** | Id, EtudiantId, DateHeureScan, Statut | Historique de présence |
| **Users** | Id, Username, Password | Authentification des utilisateurs internes |

---

## 💼 Fonctionnalités principales

### 🔗 API (ASP.NET Core)
- Fournit des endpoints REST (`/api/etudiants`, `/api/pointages`, etc.)
- Gère la logique de statut “Présent / Retard”
- Connectée via Entity Framework Core

### 🖥️ Application Desktop (Gestion)
- CRUD complet sur les étudiants, groupes, promotions
- Export Excel automatique (EPPlus)
- Liaison directe à l’API
- Authentification via table `Users`

### 📱 Application Mobile (MAUI)
- Génère un QR code unique pour chaque étudiant
- Enregistre le QR code dans la base via l’API
- Interface simple et intuitive

### 🖲️ Application Borne (Pointage)
- Lecture QR via webcam (ZXing.Net)
- Envoie le pointage à l’API
- Calcule automatiquement le statut de présence

### 💻 Application Web
- Affiche la liste des étudiants et des présences du jour
- Tableau de bord récapitulatif (présents / retards)
- Accès via login (table `Users`)

---

## 🔒 Authentification
Les applications (Desktop, Web, MAUI) sont sécurisées via la table **Users** de la base de données :
- Chaque utilisateur dispose d’un identifiant et mot de passe
- L’authentification est gérée côté API (`/api/auth/login`)
- Aucun compte ne peut être créé via l’interface

---

## 🚀 Installation et exécution

### 📦 Prérequis
- Visual Studio 2022 (avec .NET 8)
- SQL Server (local ou distant)
- Git

### ⚙️ Étapes d’installation

1. Cloner le dépôt :
   ```bash
   git clone https://github.com/<votre-utilisateur>/Pointeuse.git
   cd Pointeuse
2. Configurer la base SQL dans appsettings.json :
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=PointeuseAlternantsDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
3. Lancer les migrations EF Core (si activées) :
   dotnet ef database update
4.Démarrer l’API (Pointeuse.API)
→ vérifier sur https://localhost:7124/swagger
5. Démarrer les autres projets selon les besoins :
  Pointeuse.DesktopGestion → gestion admin
  Pointeuse.WebApp → suivi web
  Pointeuse.Maui → mobile
  Pointeuse.Borne → borne de pointage


Captures d’écran:

Interface de connexion

Formulaire de gestion des étudiants

QR Code généré sur mobile

Interface web de suivi des présences



Roadmap (évolutions prévues)

 Gestion des départs (pointage de sortie)

 Export PDF des présences

 Ajout d’un tableau de bord statistiques

 Notifications par email

 Version cloud (hébergement Azure)


 🧑‍💻 Auteur

👤 [Fandio Brice]
Développeur .NET Full Stack
📧 bricegeorgyfandio@yahoo.fr

🔗 https://www.linkedin.com/in/brice-georgy-fandio-80ab27171/
 • https://github.com/bricefandio/

📜 Licence

Projet réalisé dans le cadre d’un projet de fin d’études.
Usage éducatif et démonstratif uniquement.

💡 Ce projet illustre la conception complète d’un écosystème applicatif professionnel sous .NET 8 : Web API, Desktop, Mobile, et Web intégrés autour d’une base de données commune SQL Server.

⭐ Si ce projet vous plaît, pensez à laisser une étoile sur le dépôt GitHub !

C’est la meilleure manière d’encourager le travail open-source.

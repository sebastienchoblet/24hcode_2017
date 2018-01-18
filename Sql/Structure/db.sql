SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
/*
	drop table Utilisateur
	
	drop table BugTracker
	drop table BugTracker_Utilisateur
	drop table BugTracker_Tache
	drop table BugTracker_Tache_Event

	drop table Applicatif
	drop table Composant
	drop table Fct
	drop table Utilisateur_Fct
	drop table Livraison
	drop table Evolution
	drop table Evolution_Utilisateur
	drop table Tache
	drop table Tache_Event
	drop table Tache_Annexe
	*/
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Utilisateur' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Utilisateur]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		[Nom]						varchar(20)			not null,
		[Photo]						varchar(200)		null,
		[Prenom]					varchar(20)			null,
		[Portable]					varchar(20)			null,
		[Email]						varchar(20)			null,
		[Login]						varchar(20)			null,
		[Pass]						varchar(255)		null,
		[Profils]					smallint			null, -- Admin, Developpeur, recetteur, CP
		[Archive]					bit					not null default(0)
	 CONSTRAINT [pk_Utilisateur] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	--ALTER TABLE [dbo].[Bailleur]  WITH CHECK ADD  CONSTRAINT [FK_Bailleur_Contact] FOREIGN KEY([Contact])
	--REFERENCES [dbo].[Contact] ([uid])

	--ALTER TABLE [dbo].[Bailleur] CHECK CONSTRAINT [FK_Bailleur_Contact]
END
-- drop 
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'BugTracker' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[BugTracker]
	(
		[Id]					[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]				[uniqueidentifier] NULL,
		[DateCreation]			[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]			[uniqueidentifier] NULL,
		[DateDerniereModif]		[DateTime] NOT NULL default(GetDate()),
		[Logo]					varchar(200) NULL,
		[Adresse]				varchar(200) NULL,
		[Pass]					varchar(20) NULL,
		[Type]					smallint not null default(0)
		CONSTRAINT [pk_BugTracker] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	--ALTER TABLE [dbo].[Bailleur]  WITH CHECK ADD  CONSTRAINT [FK_Bailleur_Contact] FOREIGN KEY([Contact])
	--REFERENCES [dbo].[Contact] ([uid])

	--ALTER TABLE [dbo].[Bailleur] CHECK CONSTRAINT [FK_Bailleur_Contact]
END
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'BugTracker_Utilisateur' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[BugTracker_Utilisateur]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		[Login]						varchar(20)	null,
		[Pass]						varchar(20) null,
		[IdBugTracker]				varchar(100) not null,
		--> Links
		[Tracker]					[uniqueidentifier] NOT NULL,
		[Utilisateur]				uniqueidentifier not null
		
	 CONSTRAINT [pk_BugTracker_Utilisateur] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'BugTracker_Tache' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[BugTracker_Tache]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		[IdBugTracker]				varchar(100) not null,
		--> Links
		[Tracker]					[uniqueidentifier] NOT NULL,
		[Tache]						uniqueidentifier not null
		 CONSTRAINT [pk_BugTracker_Tache] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'BugTracker_Tache_Event' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[BugTracker_Tache_Event]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		[IdBugTracker]				varchar(100) not null,
		--> Links
		[Tache]						uniqueidentifier not null
		 CONSTRAINT [pk_BugTracker_Tache_Event] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Applicatif' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Applicatif]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		[Nom]						varchar(20)	NOT NULL,
		[Logo]						varchar(200) NULL
		 CONSTRAINT [pk_Applicatif] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Composant' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Composant]
	(
		[Id]							[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]						[uniqueidentifier] NULL,
		[DateCreation]					[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]					[uniqueidentifier] NULL,
		[DateDerniereModif]				[DateTime] NOT NULL default(GetDate()),
		[Nom]							varchar(20) NOT NULL,
		[Description]					varchar(max) NULL,
		--> Links
		[Applicatif]					uniqueidentifier NOT NULL
		 CONSTRAINT [pk_Composant] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Fct' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Fct]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		[Nom]						varchar(20)	NOT NULL,			-- La premiere est editable
		[Description]				varchar(max) NULL,
		[DecableLe]					datetime NULL,
		--> Links
		[Composant]					uniqueidentifier NOT NULL,
		[FctParente]				uniqueidentifier NULL				-- lié à la fonction dans l'autre version
		 CONSTRAINT [pk_Fct] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Utilisateur_Fct' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Utilisateur_Fct]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		--> Links
		[Connaissances]				smallint not null default(0),		-- (Aucune, Fonctionnelle, Archi, Code )
		[Niveau]					int	null
		 CONSTRAINT [pk_Utilisateur_Fct] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
		IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Livraison' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Livraison]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		[Titre]						varchar(200) NOT NULL,
		[MiseEnRecette]				DateTime NULL,
		[DatePrevisionnelle]		DateTime NULL,
		[Version]					varchar(20) NOT NULL,
		--> Links
		[Applicatif]				uniqueidentifier NOT NULL
		 CONSTRAINT [pk_Livraison] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
		IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Evolution' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Evolution]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		[Etat]						smallint not null default(0),  -- (0 projet, 1 dev, 1 etat 3 valide)
		--> Links
		Livraison					uniqueidentifier NOT NULL,
		Fct							uniqueidentifier NOT NULL
		 CONSTRAINT [pk_Evolution] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
		IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Evolution_Utilisateur' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Evolution_Utilisateur]									-- Table pour assigner de la charge
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		Roles						smallint not null default(0),	-- Profils
		ChargeDev					float not null default (0), -- Indique
		ChargeRecette				float not null default (0), -- Indique
		--> Links
		Evolution					uniqueidentifier NOT NULL,
		Utilisateur					uniqueidentifier NOT NULL
		 CONSTRAINT [pk_Evolution_Utilisateur] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Tache' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Tache]
	(
		[Id]						[uniqueidentifier] NOT NULL default(newid()),
		[CreePar]					[uniqueidentifier] NULL,
		[DateCreation]				[DateTime] NOT NULL default(GetDate()),
		[ModifiePar]				[uniqueidentifier] NULL,
		[DateDerniereModif]			[DateTime] NOT NULL default(GetDate()),
		[Titre]						varchar(200) NOT NULL,
		[Description]				varchar(max) NULL,
		[Type]						smallint NOT NULL,		-- 1 bug / 2 evolution
		[Criticite]					smallint NOT NULL,		-- 0 d
		[ChargeDev]					float NOT NULL Default(0),		-- Indique le temps de réalisétion
		[ChargeRecette]				float NOT NULL default(0),		-- Indique le temps de réalisétion
		--> Links
		[Fct]							uniqueidentifier NOT NULL
		 CONSTRAINT [pk_Tache] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
		IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Tache_Event' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Tache_Event]
	(
		[Id] [uniqueidentifier] NOT NULL default(newid()),
		[CreePar] [uniqueidentifier] NULL,
		[DateCreation] [DateTime] NOT NULL default(GetDate()),
		[ModifiePar] [uniqueidentifier] NULL,
		[DateDerniereModif] [DateTime] NOT NULL default(GetDate()),
		[Etat]						smallint not null default(0),	-- (Wait dependncies, Pour le dev, a mettre en recette, validé par la recette)
		[TypeAction]				smallint null,
		[Message]					varchar(max) Null,
		[Role]						smallint not null default(0), -- Profil de l'utilisateur
		[Consomme]					float NOT NULL default(0),
		--> Links
		[Tache]						uniqueidentifier NULL,
		[Utilisateur]				uniqueidentifier NULL,
		 CONSTRAINT [pk_Tache_Event] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
		IF NOT EXISTS (SELECT 1 FROM sys.sysobjects  WHERE name  = 'Tache_Annexe' AND Xtype='U')
BEGIN
	CREATE TABLE [dbo].[Tache_Annexe]
	(
		[Id] [uniqueidentifier] NOT NULL default(newid()),
		[CreePar] [uniqueidentifier] NULL,
		[DateCreation] [DateTime] NOT NULL default(GetDate()),
		[ModifiePar] [uniqueidentifier] NULL,
		[DateDerniereModif] [DateTime] NOT NULL default(GetDate()),
		[Nom]							varchar(20) NOT NULL,
		[Path]						varchar(1024) NOT NULL,
		[Tache]						uniqueidentifier not null
		 CONSTRAINT [pk_Tache_Annexe] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END




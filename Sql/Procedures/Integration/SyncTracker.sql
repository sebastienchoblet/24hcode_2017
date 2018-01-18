IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncTracker]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncTracker]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Création de la procédure d'ajout d'un tracker dans la table BugTracker
CREATE PROCEDURE [dbo].[SyncTracker]
		@adresse nvarchar(200),
		@typeTracker smallint --1 (bugzilla), 2 (flyspray), 3 (redmine)
AS

-- 1) vérification de l'existance du tracker
if(not Exists (select 1 from BugTracker where Adresse = @adresse))
BEGIN
	INSERT INTO BugTracker
	(
		Adresse,
		[Type]
	)
	VALUES
	(
		@adresse,
		@typeTracker	
	)
END
DECLARE @idtracker uniqueidentifier = (SELECT TOP 1 Id FROM BugTracker WHERE Adresse = @adresse)

SELECT @idtracker AS return_value

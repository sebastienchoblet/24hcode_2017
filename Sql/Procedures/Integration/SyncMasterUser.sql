IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncMasterUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncMasterUser]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Création de la procédure d'ajout d'un tracker dans la table BugTracker
CREATE PROCEDURE [dbo].[SyncMasterUser]
	@trackerId uniqueidentifier,
	@iduser uniqueidentifier,
	@login varchar(100)
AS

-- 1) vérification de l'existance de l'utilisateur
IF(not Exists (
	SELECT 1
	FROM BugTracker_Utilisateur 
	WHERE Tracker = @trackerId
		AND Utilisateur = @iduser))
BEGIN
	INSERT INTO BugTracker_Utilisateur
	(
		[Login],
		Tracker,
		Utilisateur,
		IdBugTracker
	)
	VALUES
	(
		@login,
		@trackerId,
		@iduser,
		0
	)
END

DECLARE @idTrackerUser uniqueidentifier = (
	SELECT TOP 1 Id 
	FROM BugTracker_Utilisateur 
	WHERE Tracker = @trackerId
		AND Utilisateur = @iduser)

SELECT @idTrackerUser AS return_value

GO


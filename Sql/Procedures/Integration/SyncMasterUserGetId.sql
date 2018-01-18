IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncMasterUserGetId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncMasterUserGetId]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Création de la procédure d'ajout d'un tracker dans la table BugTracker
CREATE PROCEDURE [dbo].[SyncMasterUserGetId]
	@trackerId uniqueidentifier,
	@iduser uniqueidentifier
AS

DECLARE @idTrackerUser uniqueidentifier = (
	SELECT TOP 1 Id 
	FROM BugTracker_Utilisateur 
	WHERE Tracker = @trackerId
		AND Utilisateur = @iduser)

SELECT @idTrackerUser AS return_value

GO


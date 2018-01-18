IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncUserGetId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncUserGetId]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Création de la procédure d'ajout d'un tracker dans la table BugTracker
CREATE PROCEDURE [dbo].[SyncUserGetId]
		@email nvarchar(200)
AS

DECLARE @iduser uniqueidentifier = (SELECT TOP 1 Id FROM Utilisateur WHERE Email = @email)

SELECT @iduser AS return_value

GO
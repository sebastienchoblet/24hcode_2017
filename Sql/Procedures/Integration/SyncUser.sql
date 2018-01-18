IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncUSer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncUser]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Création de la procédure d'ajout d'un tracker dans la table BugTracker
CREATE PROCEDURE [dbo].[SyncUser]
		@email nvarchar(200),
		@login varchar(100),
		@nom varchar(100)
AS

-- 1) vérification de l'existance de l'utilisateur
IF(not Exists (
	SELECT 1
	FROM Utilisateur 
	WHERE Email = @email))
BEGIN
	INSERT INTO Utilisateur
	(
		Email,
		[Login],
		Nom
	)
	VALUES
	(
		@email,
		@login,
		@nom
	)
END
DECLARE @iduser uniqueidentifier = (SELECT TOP 1 Id FROM Utilisateur WHERE Email = @email)

SELECT @iduser AS return_value


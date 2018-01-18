IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncUtilisateur]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncUtilisateur]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SyncUtilisateur]
	@email varchar(200),
	@nom varchar(20),
	@prenom varchar(20),

	@idtracker uniqueidentifier,		-- tracker d'origine
	@idbugtracker varchar(100)			-- Identifiant de l'utilisateur pour le tracker
AS

-- 1) dans notre modèle on créé l'utilisateur ou on le récupre
-- Si il existe pas dans la table des utilisateurs création

if(not Exists (select 1 from utilisateur where email = @email))
BEGIN
	insert into utilisateur 
	(
		email,
		Nom,
		Prenom
	)
	values
	(
		@email,
		@nom,
		@prenom
	)
END
ELSE
BEGIN
	update u
	set Nom = coalesce(@nom, nom)
	, Prenom = coalesce(@prenom, prenom)
	from utilisateur u
	where @email = email
END

declare @iduser uniqueidentifier = (select top 1 id from utilisateur where @email = email)
-- Si la ligne de mapping Utilisateur <> tracker n'existe pas on l'insert



-- 2) On créé la ligne de mapping entre le tracker et l'utilisateur
if(not Exists (select 1 from BugTracker_Utilisateur where Utilisateur = @iduser))
BEGIN
	insert into BugTracker_Utilisateur 
	(
		Tracker,
		IdBugTracker,
		Utilisateur
	)
	values
	(
		@idtracker,
		@idbugtracker,
		@iduser
	)
END
-- Pas d'update à priori
--ELSE
--BEGIN
--	update u
--	set Tracker = @tracker
--	, Prenom = coalesce(@prenom, prenom)
--	from BugTracker_Utilisateur u
--	where @email = email
--END

select @iduser
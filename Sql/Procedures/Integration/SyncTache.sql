IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncTache]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncTache]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SyncTache]
		@trackerid uniqueidentifier, -- identifiant du tracker
		@trackertacheid varchar(100), -- id de la tâche pour le tracker
		@type smallint, -- 1 bug / 2 evols
		@titre varchar(200),
		@description varchar(max) = null,
		@Criticite smallint,
		@composantname varchar(200) = null,
		@applicatifname varchar(200) = null,
		@etat smallint
AS

declare @t table ( id uniqueidentifier )

-- Synchro de l'applicatif
insert into @t EXEC SyncApplicatif @nom = @applicatifname
declare @applicatif uniqueidentifier = (select top 1 id from @t)
delete @t

-- Synchro du composant
insert into @t EXEC SyncComposant @applicatif = @applicatif, @nom = @composantname
declare @composant  uniqueidentifier = (select top 1 id from @t)
delete @t

declare @id uniqueidentifier = (select Tache from bugtracker_tache where @trackertacheid = IdBugTracker)
if(@id is null)
BEGIN
	set @id = newid()
	insert into tache 
	(
		Id,
		Titre,
		Criticite,
		Etat,
		Composant,
		Type,
		Description
	)
	values
	(
		@id,
		@Titre,
		@Criticite,
		@Etat,
		@Composant,
		@Type,
		@Description
	)
	insert into bugtracker_tache
	(
		Tache,
		IdBugTracker,
		Tracker
	)
	values
	(
		@id,
		@trackertacheid,
		@trackerid
	)
END
ELSE
BEGIN
	update tache 
	set Criticite = @criticite
	, Titre = @Titre
	, Etat = @Etat
	where id = @id

END
	select @id

IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncComposant]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncComposant]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SyncComposant]
	@applicatif uniqueidentifier,
	@nom varchar(100)
AS

declare @id uniqueidentifier = (select id from composant where applicatif = @applicatif and @nom = nom)
if(@id is null)
BEGIN
	insert into composant 
	(
		Applicatif,
		Nom
	)
	values
	(
		@applicatif
		,@nom
	)
	select @@IDENTITY
END
ELSE
BEGIN
select @id
END

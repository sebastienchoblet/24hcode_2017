IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncApplicatif]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncApplicatif]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SyncApplicatif]
	@nom varchar(100)
AS

declare @id uniqueidentifier = (select id from applicatif where @nom = nom)
if(@id is null)
BEGIN
	insert into applicatif 
	(
		Nom
	)
	values
	(
		@nom
	)
	select @@IDENTITY
END
ELSE
BEGIN
	select @id
END

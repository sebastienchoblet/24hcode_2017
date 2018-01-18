IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncComposantGetId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncComposantGetId]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SyncComposantGetId]
	@applicatif uniqueidentifier,
	@nom varchar(100)
AS

declare @id uniqueidentifier = (select id from composant where applicatif = @applicatif and @nom = nom)

SELECT @id AS return_value

GO


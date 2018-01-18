IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SyncApplicatifGetId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SyncApplicatifGetId]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SyncApplicatifGetId]
	@nom varchar(100)
AS

declare @id uniqueidentifier = (select id from applicatif where @nom = nom)

SELECT @id AS return_value

GO

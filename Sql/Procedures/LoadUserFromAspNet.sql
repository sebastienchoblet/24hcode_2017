IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadUserFromAspNet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LoadUserFromAspNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadUserFromAspNet]
		@IdAspNet [uniqueidentifier]
AS

select u.* from utilisateur u
inner join AspNetUsers asp
	on asp.email = u.email
	and asp.id = @idaspnet


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[V_Asset_Info]') AND OBJECTPROPERTY(id,N'IsView') = 1)
	DROP VIEW [V_Asset_Info]
GO
/*
	×Ê²úÊÓÍ¼
*/
CREATE VIEW V_Asset_Info
AS 
SELECT * FROM Asset_Information WHERE ISNULL(F_ParentId,'') = ''
UNION ALL
SELECT * FROM Asset_ComboInformation
 



GO



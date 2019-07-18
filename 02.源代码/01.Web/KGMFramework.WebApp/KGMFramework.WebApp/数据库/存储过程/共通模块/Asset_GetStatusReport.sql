
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Asset_GetStatusReport]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [Asset_GetStatusReport]
GO
/*
	��ȡ�ʲ�״̬��
*/
CREATE PROC [Asset_GetStatusReport]
@CorpId NVARCHAR(50)	--��˾Id
AS 
SELECT COUNT(*) Qty,F_STATUS FROM Asset_Information WHERE F_CompanyId = @CorpId group by F_STATUS


 
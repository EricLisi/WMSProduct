
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Asset_GetPreVerfy]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [Asset_GetPreVerfy]
GO
/*
	获取待审核单据
*/
CREATE PROC Asset_GetPreVerfy
@CorpId NVARCHAR(50)	--公司Id
AS
DECLARE @PREDJ INT = 0	--登记
DECLARE @PREZY INT = 0	--转移
DECLARE @PRECL INT = 0	--处理

SELECT @PREDJ = COUNT(*) FROM Asset_RegisterHead WHERE F_Status = 0 AND F_Orgnization = @CorpId
 
SELECT @PRECL = COUNT(*) FROM Asset_TransforHead WHERE F_Status = 0 AND F_Orgnization = @CorpId AND F_OrderType IN ('资产维修','资产处理')

DECLARE @PREZY1 INT = 0
DECLARE @PREZY2 INT = 0
DECLARE @PREZY3 INT = 0
SELECT @PREZY1 = COUNT(*) FROM Asset_TransforHead WHERE F_Status = 0 AND F_Orgnization = @CorpId AND F_OrderType NOT IN ('资产维修','资产处理')
SELECT @PREZY2 = COUNT(*) FROM Asset_AllocationHead WHERE F_Status = 0 AND F_OCompany = @CorpId
SELECT @PREZY3 = COUNT(*) FROM Asset_AllocationHead WHERE F_Status = 1 AND F_ICompany = @CorpId

SET @PREZY = @PREZY1 + @PREZY2 + @PREZY3

SELECT @PREDJ PREDJ,@PREZY PREZY,@PRECL PRECL

 
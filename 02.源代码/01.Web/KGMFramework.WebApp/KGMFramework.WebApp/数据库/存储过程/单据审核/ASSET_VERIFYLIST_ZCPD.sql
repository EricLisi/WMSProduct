
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ASSET_VERIFYLIST_ZCPD]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [ASSET_VERIFYLIST_ZCPD]
GO
/*
	资产盘点审核单据
*/
CREATE PROC ASSET_VERIFYLIST_ZCPD
@ORDERID NVARCHAR(50),	--单据Id
@ORDERNO NVARCHAR(50),	--单据号 
@USER NVARCHAR(50),		--审核人
@COMPCODE NVARCHAR(50)	--公司编码
AS  
--数据校验
IF EXISTS(SELECT * FROM Asset_StockTaskHead WHERE F_Id = @ORDERID AND F_VeriDate IS NOT NULL)
BEGIN
	SELECT 0,N'当前单据已经审核!'
	RETURN 
END 

--更改表头状态
UPDATE Asset_StockTaskHead SET F_Verify = @USER,F_VeriDate = GETDATE(),F_Status = 1 WHERE F_Id = @ORDERID
  
DECLARE @COPRNAME NVARCHAR(120)
SELECT @COPRNAME = F_FullName FROM Sys_Organize WHERE F_Id = @COMPCODE
 
--写入履历表
INSERT INTO Asset_Records(F_Id,F_SourceCode,F_Source,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
			,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
			,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_DepartmentName,F_Principal,F_BuyDate
			,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
			,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
			,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId
			,F_NCompanyId,F_NCompanyName,F_NDepartmentId,F_NDepartmentName,F_EnabledMark)
SELECT NEWID(),@ORDERNO,'资产盘点',A.F_EnCode,A.F_FullName,A.F_ParentId,A.F_AssetType,A.F_AssetTypeName,A.F_STATUS,A.F_GroupCode
			,A.F_Qty,A.F_Amount,A.F_Ddate,'','','' F_BidNumber,A.F_Invoice,A.F_Model,A.F_NetWeight,A.F_GrossWeight,A.F_Length
			,A.F_Width,A.F_Height,A.F_Supplier,A.F_Unit,A.F_Brand,A.F_FactorySn,A.F_Owner,A.F_CompanyId,@COPRNAME,A.F_DepartmentId,O.F_FullName,A.F_Principal,A.F_BuyDate
			,A.F_TimeService,A.F_Depreciation,A.F_LifeYears,A.F_Description,A.F_Cdefine1,A.F_Cdefine2,A.F_Cdefine3,A.F_Cdefine4,A.F_Cdefine5
			,A.F_Cdefine6,A.F_Cdefine7,A.F_Cdefine8,A.F_Cdefine9,A.F_Cdefine10,A.F_Cdefine11,A.F_Cdefine12,A.F_Cdefine13,A.F_Cdefine14
			,A.F_Cdefine15,A.F_Cdefine16,A.F_Cdefine17,A.F_Cdefine18,A.F_Cdefine19,A.F_Cdefine20,GETDATE(),@USER
			,A.F_CompanyId,A.F_CompanyName,A.F_DepartmentId,A.F_DepartmenName,A.F_EnabledMark
FROM [Asset_StockTaskBody] AS A
LEFT JOIN Sys_Organize AS O ON A.F_DepartmentId = O.F_Id 
WHERE A.F_Hid = @ORDERID


--更新资产状态
--UPDATE Asset_Information SET Asset_Information.F_EnabledMark = A.F_EnabledMark
--FROM [Asset_StockTaskBody] AS A
--WHERE A.F_Hid = @ORDERID AND A.F_EnCode = Asset_Information.F_EnCode
 
  
SELECT 1,N''
GO


 
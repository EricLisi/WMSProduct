
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ASSET_VERIFYLIST_ZCDB]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [ASSET_VERIFYLIST_ZCDB]
GO
/*
	资产调拨审核单据
*/
CREATE PROC [ASSET_VERIFYLIST_ZCDB]
@ORDERID NVARCHAR(50),	--单据Id
@ORDERNO NVARCHAR(50),	--单据号
@ORDERTYPE NVARCHAR(50),--单据类型
@USER NVARCHAR(50),		--审核人
@COMPCODE NVARCHAR(50)	--公司编码
AS  
--数据校验

  
--更改表头状态
DECLARE @STAUTS INT
IF @ORDERTYPE = '资产调出'
BEGIN
	IF EXISTS(SELECT * FROM Asset_AllocationHead WHERE F_Id = @ORDERID AND F_Status > 0)
	BEGIN
		SELECT 0,N'当前单据已经审核!'
		RETURN 
	END 

	SET @STAUTS = 1
END
ELSE IF @ORDERTYPE = '资产调入'
BEGIN
	IF EXISTS(SELECT * FROM Asset_AllocationHead WHERE F_Id = @ORDERID AND F_Status > 1)
	BEGIN
		SELECT 0,N'当前单据已经审核!'
		RETURN 
	END 
	 
	SET @STAUTS = 2 
END

UPDATE Asset_AllocationHead SET F_Verify = @USER,F_VeriDate = GETDATE(),F_Status = @STAUTS WHERE F_Id = @ORDERID
 

DECLARE @COPRNAME NVARCHAR(120)
SELECT @COPRNAME = F_FullName FROM Sys_Organize WHERE F_Id = @COMPCODE

DECLARE @ASTATUS NVARCHAR(50)
--更改资产表状态
IF @ORDERTYPE = '资产调出'
	SET @ASTATUS = '在途'
ELSE
	SET @ASTATUS = '闲置'
 

--更改资产表状态
IF @ORDERTYPE = '资产调出'
BEGIN
	--写入履历表
	INSERT INTO Asset_Records(F_Id,F_SourceCode,F_Source,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
				,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
				,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_DepartmentName,F_Principal,F_BuyDate
				,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
				,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
				,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId
				,F_NCompanyId,F_NCompanyName,F_NDepartmentId,F_NDepartmentName,F_NPrincipal,F_NOwner
				,F_OutCompany,F_OutCompanyName, F_InCompany,F_InCompanyName)
	SELECT NEWID(),@ORDERNO,@ORDERTYPE,B.F_EnCode,B.F_FullName,B.F_ParentId,B.F_AssetType,B.F_AssetTypeName,@ASTATUS,B.F_GroupCode
				,B.F_Qty,B.F_Amount,B.F_Ddate,B.F_OrderNo,B.F_Id,B.F_BidNumber,B.F_Invoice,B.F_Model,B.F_NetWeight,B.F_GrossWeight,B.F_Length
				,B.F_Width,B.F_Height,B.F_Supplier,B.F_Unit,B.F_Brand,B.F_FactorySn,B.F_Owner,B.F_CompanyId,@COPRNAME,A.F_DepartmentId,O.F_FullName,A.F_Principal,A.F_BuyDate
				,B.F_TimeService,B.F_Depreciation,B.F_LifeYears,B.F_Description,B.F_Cdefine1,B.F_Cdefine2,B.F_Cdefine3,B.F_Cdefine4,B.F_Cdefine5
				,B.F_Cdefine6,B.F_Cdefine7,B.F_Cdefine8,B.F_Cdefine9,B.F_Cdefine10,B.F_Cdefine11,B.F_Cdefine12,B.F_Cdefine13,B.F_Cdefine14
				,B.F_Cdefine15,B.F_Cdefine16,B.F_Cdefine17,B.F_Cdefine18,B.F_Cdefine19,B.F_Cdefine20,GETDATE(),@USER
				,B.F_CompanyId,B.F_CompanyName,B.F_DepartmentId,B.F_DepartmenName,B.F_Principal,B.F_Owner
				,H.F_OCompany,H.F_OCompanyName,H.F_ICompany,H.F_ICompanyName
	FROM [Asset_Allocationbody] AS A
	INNER JOIN Asset_Information AS B ON A.F_EnCode = B.F_EnCode
	LEFT JOIN Sys_Organize AS O ON A.F_DepartmentId = O.F_Id
	INNER JOIN [Asset_AllocationHead] AS H ON A.F_HId = H.F_Id
	WHERE A.F_Hid = @ORDERID

	 

	UPDATE Asset_Information SET  Asset_Information.F_LastModifyUserId = @USER,Asset_Information.F_LastModifyTime = GETDATE(),
		Asset_Information.F_Status = '在途'
	FROM [Asset_Allocationbody] AS A
	WHERE A.F_Hid = @ORDERID AND A.F_EnCode = Asset_Information.F_EnCode
END
ELSE IF @ORDERTYPE = '资产调入'
BEGIN

	--写入履历表
	INSERT INTO Asset_Records(F_Id,F_SourceCode,F_Source,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
				,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
				,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_DepartmentName,F_Principal,F_BuyDate
				,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
				,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
				,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId
				,F_NCompanyId,F_NCompanyName,F_NDepartmentId,F_NDepartmentName,F_NPrincipal,F_NOwner
				,F_OutCompany,F_OutCompanyName, F_InCompany,F_InCompanyName,F_EnabledMark)
	SELECT NEWID(),@ORDERNO,@ORDERTYPE,B.F_EnCode,B.F_FullName,B.F_ParentId,B.F_AssetType,B.F_AssetTypeName,@ASTATUS,B.F_GroupCode
				,B.F_Qty,B.F_Amount,B.F_Ddate,B.F_OrderNo,B.F_Id,B.F_BidNumber,B.F_Invoice,B.F_Model,B.F_NetWeight,B.F_GrossWeight,B.F_Length
				,B.F_Width,B.F_Height,B.F_Supplier,B.F_Unit,B.F_Brand,B.F_FactorySn,B.F_Owner,B.F_CompanyId,@COPRNAME,A.F_DepartmentId,O.F_FullName,A.F_Principal,A.F_BuyDate
				,B.F_TimeService,B.F_Depreciation,B.F_LifeYears,B.F_Description,B.F_Cdefine1,B.F_Cdefine2,B.F_Cdefine3,B.F_Cdefine4,B.F_Cdefine5
				,B.F_Cdefine6,B.F_Cdefine7,B.F_Cdefine8,B.F_Cdefine9,B.F_Cdefine10,B.F_Cdefine11,B.F_Cdefine12,B.F_Cdefine13,B.F_Cdefine14
				,B.F_Cdefine15,B.F_Cdefine16,B.F_Cdefine17,B.F_Cdefine18,B.F_Cdefine19,B.F_Cdefine20,GETDATE(),@USER
				,B.F_CompanyId,B.F_CompanyName,B.F_DepartmentId,B.F_DepartmenName,B.F_Principal,B.F_Owner
				,H.F_OCompany,H.F_OCompanyName,H.F_ICompany,H.F_ICompanyName,A.F_EnabledMark
	FROM [Asset_Allocationbody] AS A
	INNER JOIN Asset_Information AS B ON A.F_EnCode = B.F_EnCode
	LEFT JOIN Sys_Organize AS O ON A.F_DepartmentId = O.F_Id
	INNER JOIN [Asset_AllocationHead] AS H ON A.F_HId = H.F_Id
	WHERE A.F_Hid = @ORDERID --AND A.F_EnabledMark = 1


	UPDATE Asset_Information SET  Asset_Information.F_LastModifyUserId = @USER,Asset_Information.F_LastModifyTime = GETDATE(),
		Asset_Information.F_Status = '闲置',Asset_Information.F_CompanyId = B.F_ICompany,F_CompanyName = B.F_ICompanyName
	FROM [Asset_Allocationbody] AS A
	INNER JOIN [Asset_Allocationhead] AS B ON A.F_HId = B.F_Id
	WHERE A.F_Hid = @ORDERID AND A.F_EnabledMark = 1 AND A.F_EnCode = Asset_Information.F_EnCode

	UPDATE Asset_Information SET  Asset_Information.F_LastModifyUserId = @USER,Asset_Information.F_LastModifyTime = GETDATE(),
	Asset_Information.F_Status = '闲置' 
	FROM [Asset_Allocationbody] AS A 
	WHERE A.F_Hid = @ORDERID AND A.F_EnabledMark = 0 AND A.F_EnCode = Asset_Information.F_EnCode
END  


SELECT 1,N''
GO
 
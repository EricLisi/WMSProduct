IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ASSET_VERIFYLIST_ZCZY]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [ASSET_VERIFYLIST_ZCZY]
GO
 
/*
	资产登记审核单据
*/
CREATE PROC [ASSET_VERIFYLIST_ZCZY]
@ORDERID NVARCHAR(50),	--单据Id
@ORDERNO NVARCHAR(50),	--单据号
@ORDERTYPE NVARCHAR(50),--单据类型
@USER NVARCHAR(50),		--审核人
@COMPCODE NVARCHAR(50)	--公司编码
AS  
--数据校验
IF EXISTS(SELECT * FROM Asset_TransforHead WHERE F_Id = @ORDERID AND F_VeriDate IS NOT NULL)
BEGIN
	SELECT 0,N'当前单据已经审核!'
	RETURN 
END 

--更改表头状态
UPDATE Asset_TransforHead SET F_Verify = @USER,F_VeriDate = GETDATE(),F_Status = 2 WHERE F_Id = @ORDERID
 

DECLARE @COPRNAME NVARCHAR(120)
SELECT @COPRNAME = F_FullName FROM Sys_Organize WHERE F_Id = @COMPCODE

DECLARE @STATUS NVARCHAR(50)
--更改资产表状态
IF @ORDERTYPE = '资产领用'
BEGIN
	SET @STATUS = '在用' 
END
ELSE IF @ORDERTYPE = '资产借用'
BEGIN
	SET @STATUS = '借用' 
END  
ELSE IF @ORDERTYPE = '资产归还'
BEGIN
	SET @STATUS = '闲置' 
END
ELSE IF @ORDERTYPE = '资产维修'
BEGIN
	SET @STATUS = '维修' 
END
ELSE IF @ORDERTYPE = '资产处理'
BEGIN
	SET @STATUS = '处理' 
END

--更改资产表状态
IF @ORDERTYPE = '资产变更'
BEGIN
	--写入履历表
	INSERT INTO Asset_Records(F_Id,F_SourceCode,F_Source,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
				,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
				,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_DepartmentName,F_Principal,F_BuyDate
				,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
				,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
				,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId
				,F_RepairUnit,F_MendMoney,F_RepairdDate,F_PlanReturnDate,F_NCompanyId,F_NCompanyName,F_NDepartmentId,F_NDepartmentName
				,F_NPrincipal,F_NOwner,F_ScapType,F_ScapCost)
	SELECT NEWID(),@ORDERNO,'资产变更(旧)',B.F_EnCode,B.F_FullName,B.F_ParentId,B.F_AssetType,B.F_AssetTypeName,@STATUS,B.F_GroupCode
				,B.F_Qty,B.F_Amount,B.F_Ddate,B.F_OrderNo,B.F_Id,B.F_BidNumber,B.F_Invoice,B.F_Model,B.F_NetWeight,B.F_GrossWeight,B.F_Length
				,B.F_Width,B.F_Height,B.F_Supplier,B.F_Unit,B.F_Brand,B.F_FactorySn,B.F_Owner,B.F_CompanyId,@COPRNAME,A.F_DepartmentId,O.F_FullName,A.F_Principal,A.F_BuyDate
				,B.F_TimeService,B.F_Depreciation,B.F_LifeYears,B.F_Description,B.F_Cdefine1,B.F_Cdefine2,B.F_Cdefine3,B.F_Cdefine4,B.F_Cdefine5
				,B.F_Cdefine6,B.F_Cdefine7,B.F_Cdefine8,B.F_Cdefine9,B.F_Cdefine10,B.F_Cdefine11,B.F_Cdefine12,B.F_Cdefine13,B.F_Cdefine14
				,B.F_Cdefine15,B.F_Cdefine16,B.F_Cdefine17,B.F_Cdefine18,B.F_Cdefine19,B.F_Cdefine20,GETDATE(),@USER
				,H.F_RepairUnit,A.F_MendMoney,H.F_RepairdDate,H.F_ReturnDate,A.F_CompanyId,A.F_CompanyName,A.F_DepartmentId,A.F_DepartmenName
				,A.F_Principal,A.F_Owner,A.F_DisposalMethod,A.F_Salvage
	FROM [Asset_Transforbody] AS A
	INNER JOIN Asset_Information AS B ON A.F_EnCode = B.F_EnCode
	LEFT JOIN Sys_Organize AS O ON A.F_DepartmentId = O.F_Id
	INNER JOIN [Asset_TransforHead] AS H ON A.F_HId = H.F_Id
	WHERE A.F_Hid = @ORDERID
 END
 ELSE
 BEGIN
	--写入履历表
	INSERT INTO Asset_Records(F_Id,F_SourceCode,F_Source,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
				,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
				,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_DepartmentName,F_Principal,F_BuyDate
				,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
				,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
				,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId
				,F_RepairUnit,F_MendMoney,F_RepairdDate,F_PlanReturnDate,F_NCompanyId,F_NCompanyName,F_NDepartmentId,F_NDepartmentName
				,F_NPrincipal,F_NOwner,F_ScapType,F_ScapCost)
	SELECT NEWID(),@ORDERNO,@ORDERTYPE,B.F_EnCode,B.F_FullName,B.F_ParentId,B.F_AssetType,B.F_AssetTypeName,@STATUS,B.F_GroupCode
				,B.F_Qty,B.F_Amount,B.F_Ddate,B.F_OrderNo,B.F_Id,B.F_BidNumber,B.F_Invoice,B.F_Model,B.F_NetWeight,B.F_GrossWeight,B.F_Length
				,B.F_Width,B.F_Height,B.F_Supplier,B.F_Unit,B.F_Brand,B.F_FactorySn,B.F_Owner,B.F_CompanyId,@COPRNAME,A.F_DepartmentId,O.F_FullName,A.F_Principal,A.F_BuyDate
				,B.F_TimeService,B.F_Depreciation,B.F_LifeYears,B.F_Description,B.F_Cdefine1,B.F_Cdefine2,B.F_Cdefine3,B.F_Cdefine4,B.F_Cdefine5
				,B.F_Cdefine6,B.F_Cdefine7,B.F_Cdefine8,B.F_Cdefine9,B.F_Cdefine10,B.F_Cdefine11,B.F_Cdefine12,B.F_Cdefine13,B.F_Cdefine14
				,B.F_Cdefine15,B.F_Cdefine16,B.F_Cdefine17,B.F_Cdefine18,B.F_Cdefine19,B.F_Cdefine20,GETDATE(),@USER
				,H.F_RepairUnit,A.F_MendMoney,H.F_RepairdDate,H.F_ReturnDate,A.F_CompanyId,A.F_CompanyName,A.F_DepartmentId,A.F_DepartmenName
				,A.F_Principal,A.F_Owner,A.F_DisposalMethod,A.F_Salvage
	FROM [Asset_Transforbody] AS A
	INNER JOIN Asset_Information AS B ON A.F_EnCode = B.F_EnCode
	LEFT JOIN Sys_Organize AS O ON A.F_DepartmentId = O.F_Id
	INNER JOIN [Asset_TransforHead] AS H ON A.F_HId = H.F_Id
	WHERE A.F_Hid = @ORDERID
 END


--更改资产表状态
IF @ORDERTYPE = '资产领用'
BEGIN
	UPDATE Asset_Information SET  Asset_Information.F_LastModifyUserId = @USER,Asset_Information.F_LastModifyTime = GETDATE(),
		Asset_Information.F_DepartmentId = A.F_DepartmentId,Asset_Information.F_DepartmenName = O.F_FullName,
		Asset_Information.F_Principal = A.F_Principal,Asset_Information.F_Owner = A.F_Owner,Asset_Information.F_Status = '在用',
		Asset_Information.F_CDEFINE20 = U.F_Id
	FROM [Asset_Transforbody] AS A
	INNER JOIN Sys_Organize AS O ON A.F_DepartmentId = O.F_Id
	LEFT JOIN Sys_User AS U ON A.F_DepartmentId = U.F_DepartmentId AND A.F_Principal = U.F_RealName
	WHERE A.F_Hid = @ORDERID AND A.F_EnCode = Asset_Information.F_EnCode
END
ELSE IF @ORDERTYPE = '资产借用'
BEGIN
	UPDATE Asset_Information SET  Asset_Information.F_LastModifyUserId = @USER,Asset_Information.F_LastModifyTime = GETDATE(),
		Asset_Information.F_DepartmentId = A.F_DepartmentId,Asset_Information.F_DepartmenName = O.F_FullName,
		Asset_Information.F_Principal = A.F_Principal,Asset_Information.F_Owner = A.F_Owner,Asset_Information.F_Status = '借用'
	FROM [Asset_Transforbody] AS A
	INNER JOIN Sys_Organize AS O ON A.F_DepartmentId = O.F_Id
	WHERE A.F_Hid = @ORDERID AND A.F_EnCode = Asset_Information.F_EnCode
END  
ELSE IF @ORDERTYPE = '资产归还'
BEGIN
	UPDATE Asset_Information SET  Asset_Information.F_LastModifyUserId = @USER,Asset_Information.F_LastModifyTime = GETDATE(),
		Asset_Information.F_DepartmentId = '' ,Asset_Information.F_DepartmenName = '',
		Asset_Information.F_Principal = '' ,Asset_Information.F_Owner = '',Asset_Information.F_Status = '闲置'
	FROM [Asset_Transforbody] AS A 
	WHERE A.F_Hid = @ORDERID AND A.F_EnCode = Asset_Information.F_EnCode
END
ELSE IF @ORDERTYPE = '资产维修'
BEGIN
	UPDATE Asset_Information SET  Asset_Information.F_LastModifyUserId = @USER,Asset_Information.F_LastModifyTime = GETDATE(),
		 Asset_Information.F_Status = '维修'
	FROM [Asset_Transforbody] AS A 
	WHERE A.F_Hid = @ORDERID AND A.F_EnCode = Asset_Information.F_EnCode
END
ELSE IF @ORDERTYPE = '资产处理'
BEGIN
	UPDATE Asset_Information SET  Asset_Information.F_LastModifyUserId = @USER,Asset_Information.F_LastModifyTime = GETDATE(),
		 Asset_Information.F_Status = '处理',Asset_Information.F_EnabledMark = 0
	FROM [Asset_Transforbody] AS A 
	WHERE A.F_Hid = @ORDERID AND A.F_EnCode = Asset_Information.F_EnCode
END
ELSE IF @ORDERTYPE = '资产变更'
BEGIN
	UPDATE Asset_Information SET  Asset_Information.F_LastModifyUserId = @USER,Asset_Information.F_LastModifyTime = GETDATE()
		  ,Asset_Information.F_FullName = A.F_FullName
		  ,Asset_Information.F_ParentId = A.F_ParentId
		  ,Asset_Information.F_AssetType = A.F_AssetType
		  ,Asset_Information.F_AssetTypeName = A.F_AssetTypeName
		  ,Asset_Information.F_Status = A.F_Status
		  ,Asset_Information.F_GroupCode = A.F_GroupCode
		  ,Asset_Information.F_Qty = A.F_Qty
		  ,Asset_Information.F_Amount = A.F_Amount
		  ,Asset_Information.F_Ddate = A.F_Ddate  
		  ,Asset_Information.F_Invoice = A.F_Invoice
		  ,Asset_Information.F_Model = A.F_Model
		  ,Asset_Information.F_NetWeight = A.F_NetWeight
		  ,Asset_Information.F_GrossWeight = A.F_GrossWeight
		  ,Asset_Information.F_Length = A.F_Length
		  ,Asset_Information.F_Width = A.F_Width
		  ,Asset_Information.F_Height = A.F_Height
		  ,Asset_Information.F_Supplier = A.F_Supplier
		  ,Asset_Information.F_Unit = A.F_Unit
		  ,Asset_Information.F_Brand = A.F_Brand
		  ,Asset_Information.F_FactorySn = A.F_FactorySn
		  ,Asset_Information.F_Owner = A.F_Owner
		  ,Asset_Information.F_CompanyId = A.F_CompanyId
		  ,Asset_Information.F_CompanyName = A.F_CompanyName
		  ,Asset_Information.F_DepartmentId = A.F_DepartmentId
		  ,Asset_Information.F_DepartmenName = A.F_DepartmenName
		  ,Asset_Information.F_Principal = A.F_Principal
		  ,Asset_Information.F_BuyDate = A.F_BuyDate
		  ,Asset_Information.F_TimeService = A.F_TimeService
		  ,Asset_Information.F_Depreciation = A.F_Depreciation
		  ,Asset_Information.F_LifeYears = A.F_LifeYears
		  ,Asset_Information.F_Salvage = A.F_Salvage
		  ,Asset_Information.F_DisposalMethod = A.F_DisposalMethod
		  ,Asset_Information.F_Description = A.F_Description
		  ,Asset_Information.F_Cdefine1 = A.F_Cdefine1
		  ,Asset_Information.F_Cdefine2 = A.F_Cdefine2
		  ,Asset_Information.F_Cdefine3 = A.F_Cdefine3
		  ,Asset_Information.F_Cdefine4 = A.F_Cdefine4
		  ,Asset_Information.F_Cdefine5 = A.F_Cdefine5
		  ,Asset_Information.F_Cdefine6 = A.F_Cdefine6
		  ,Asset_Information.F_Cdefine7 = A.F_Cdefine7
		  ,Asset_Information.F_Cdefine8 = A.F_Cdefine8
		  ,Asset_Information.F_Cdefine9 = A.F_Cdefine9
		  ,Asset_Information.F_Cdefine10 = A.F_Cdefine10
		  ,Asset_Information.F_Cdefine11 = A.F_Cdefine11
		  ,Asset_Information.F_Cdefine12 = A.F_Cdefine12
		  ,Asset_Information.F_Cdefine13 = A.F_Cdefine13
		  ,Asset_Information.F_Cdefine14 = A.F_Cdefine14
		  ,Asset_Information.F_Cdefine15 = A.F_Cdefine15
		  ,Asset_Information.F_Cdefine16 = A.F_Cdefine16
		  ,Asset_Information.F_Cdefine17 = A.F_Cdefine17
		  ,Asset_Information.F_Cdefine18 = A.F_Cdefine18
		  ,Asset_Information.F_Cdefine19 = A.F_Cdefine19
		  ,Asset_Information.F_Cdefine20 = A.F_Cdefine20
	FROM [Asset_Transforbody] AS A 
	WHERE A.F_Hid = @ORDERID AND A.F_EnCode = Asset_Information.F_EnCode



	--写入履历表
	INSERT INTO Asset_Records(F_Id,F_SourceCode,F_Source,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
				,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
				,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_DepartmentName,F_Principal,F_BuyDate
				,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
				,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
				,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId
				,F_RepairUnit,F_MendMoney,F_RepairdDate,F_PlanReturnDate,F_NCompanyId,F_NCompanyName,F_NDepartmentId,F_NDepartmentName
				,F_NPrincipal,F_NOwner,F_ScapType,F_ScapCost)
	SELECT NEWID(),@ORDERNO,'资产变更(新)',B.F_EnCode,B.F_FullName,B.F_ParentId,B.F_AssetType,B.F_AssetTypeName,@STATUS,B.F_GroupCode
				,B.F_Qty,B.F_Amount,B.F_Ddate,B.F_OrderNo,B.F_Id,B.F_BidNumber,B.F_Invoice,B.F_Model,B.F_NetWeight,B.F_GrossWeight,B.F_Length
				,B.F_Width,B.F_Height,B.F_Supplier,B.F_Unit,B.F_Brand,B.F_FactorySn,B.F_Owner,B.F_CompanyId,@COPRNAME,A.F_DepartmentId,O.F_FullName,A.F_Principal,A.F_BuyDate
				,B.F_TimeService,B.F_Depreciation,B.F_LifeYears,B.F_Description,B.F_Cdefine1,B.F_Cdefine2,B.F_Cdefine3,B.F_Cdefine4,B.F_Cdefine5
				,B.F_Cdefine6,B.F_Cdefine7,B.F_Cdefine8,B.F_Cdefine9,B.F_Cdefine10,B.F_Cdefine11,B.F_Cdefine12,B.F_Cdefine13,B.F_Cdefine14
				,B.F_Cdefine15,B.F_Cdefine16,B.F_Cdefine17,B.F_Cdefine18,B.F_Cdefine19,B.F_Cdefine20,GETDATE(),@USER
				,H.F_RepairUnit,A.F_MendMoney,H.F_RepairdDate,H.F_ReturnDate,A.F_CompanyId,A.F_CompanyName,A.F_DepartmentId,A.F_DepartmenName
				,A.F_Principal,A.F_Owner,A.F_DisposalMethod,A.F_Salvage
	FROM [Asset_Transforbody] AS A
	INNER JOIN Asset_Information AS B ON A.F_EnCode = B.F_EnCode
	LEFT JOIN Sys_Organize AS O ON A.F_DepartmentId = O.F_Id
	INNER JOIN [Asset_TransforHead] AS H ON A.F_HId = H.F_Id
	WHERE A.F_Hid = @ORDERID
END
SELECT 1,N''


GO 
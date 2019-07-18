IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[USER_CHAGNEDEPARTMENT]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [USER_CHAGNEDEPARTMENT]
GO
 
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'PARM_USER_CHAGNEDEPARTMENT' AND ss.name = N'dbo')
	DROP TYPE [dbo].[PARM_USER_CHAGNEDEPARTMENT]
GO

CREATE TYPE [PARM_USER_CHAGNEDEPARTMENT] AS TABLE(
	USERID NVARCHAR(50)
)

GO

/*
	更改用户部门
*/
CREATE PROC [USER_CHAGNEDEPARTMENT]
@USER NVARCHAR(50),		--操作用户
@DEPTID NVARCHAR(50),	--部门ID
@PARM_USER_CHAGNEDEPARTMENT PARM_USER_CHAGNEDEPARTMENT READONLY	--用户Id
AS
SET XACT_ABORT ON
BEGIN TRAN

DECLARE @CORPID NVARCHAR(50)	--公司ID
DECLARE @CORPNAME NVARCHAR(120)	--公司名称
DECLARE @DEPARTMENTID NVARCHAR(50)	--部门ID
DECLARE @DEPARTMENTNAME NVARCHAR(120)	--部门名称
SET @DEPARTMENTID = ''
SET @DEPARTMENTNAME = ''
IF EXISTS (SELECT F_Id FROM Sys_Organize WHERE F_Id = @DEPTID AND F_CategoryId = 'Department')
BEGIN
	--如果是部门ID,则根据部门找到上游公司ID
	SELECT * INTO #TEMP_ORG FROM Sys_Organize WHERE 1 = 2
	DECLARE @FILTER NVARCHAR(500)
	SET @FILTER = ' AND F_Id = '''+@DEPTID+''''
	INSERT INTO #TEMP_ORG
	EXEC [SYS_GETTREEINFO] 'Sys_Organize','F_Id','F_ParentId',@FILTER,'F_SortCode','1'
	--更新部门
	SELECT @DEPARTMENTID = F_Id,@DEPARTMENTNAME = F_FullName FROM #TEMP_ORG WHERE F_Id = @DEPTID
	--更新公司
	SELECT @CORPID = F_Id,@CORPNAME = F_FullName FROM #TEMP_ORG WHERE F_Id IN (
		SELECT F_ParentId FROM #TEMP_ORG WHERE F_Id = @DEPTID
	)
END
ELSE
BEGIN
	--公司
	SET @CORPID  = @DEPTID
	SELECT @CORPNAME = F_FullName FROM Sys_Organize WHERE F_Id = @DEPTID
END 

DECLARE @ORDERNO NVARCHAR(50)
DECLARE @PREFIX NVARCHAR(50)
SET @PREFIX = 'BMBG' + CONVERT(NVARCHAR(10),GETDATE(),112) 
DECLARE @SNNO NVARCHAR(50)
EXEC [SYS_CREATESN_OUTPUT] @PREFIX,@SNNO OUTPUT
SET @ORDERNO = @PREFIX + RIGHT(N'0000000000000'+CONVERT(NVARCHAR,@SNNO),5)
  
--写入履历表
INSERT INTO Asset_Records(F_Id,F_SourceCode,F_Source,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
			,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
			,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_DepartmentName,F_Principal,F_BuyDate
			,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
			,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
			,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId
			,F_RepairUnit,F_MendMoney,F_RepairdDate,F_PlanReturnDate,F_NCompanyId,F_NCompanyName,F_NDepartmentId,F_NDepartmentName
			,F_NPrincipal,F_NOwner,F_ScapType,F_ScapCost)
SELECT NEWID(),@ORDERNO,'资产变更(旧)',F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
			,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_Id,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
			,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_FullName,F_Principal,F_BuyDate
			,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
			,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
			,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,GETDATE(),@USER
			,NULL,NULL,NULL,NULL,F_CompanyId,F_CompanyName,F_DepartmentId,F_DepartmenName
			,F_Principal,F_Owner,F_DisposalMethod,CASE ISNULL(F_Salvage,'') WHEN '' THEN NULL ELSE F_Salvage END
FROM  Asset_Information
WHERE F_Cdefine20 IN (
	SELECT USERID FROM @PARM_USER_CHAGNEDEPARTMENT
) 

INSERT INTO Asset_Records(F_Id,F_SourceCode,F_Source,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
			,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
			,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_DepartmentName,F_Principal,F_BuyDate
			,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
			,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
			,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId
			,F_RepairUnit,F_MendMoney,F_RepairdDate,F_PlanReturnDate,F_NCompanyId,F_NCompanyName,F_NDepartmentId,F_NDepartmentName
			,F_NPrincipal,F_NOwner,F_ScapType,F_ScapCost)
SELECT NEWID(),@ORDERNO,'资产变更(新)',F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
			,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_Id,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
			,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_FullName,F_Principal,F_BuyDate
			,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
			,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
			,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,GETDATE(),@USER
			,NULL,NULL,NULL,NULL,@CORPID,@CORPNAME,@DEPARTMENTID,@DEPARTMENTNAME,NULL,NULL,NULL,NULL
FROM  Asset_Information
WHERE F_Cdefine20 IN (
	SELECT USERID FROM @PARM_USER_CHAGNEDEPARTMENT
) 

--更新用户部门
UPDATE Sys_User SET F_OrganizeId = @CORPID,F_DepartmentId = @DEPARTMENTID WHERE F_Account IN (
	SELECT USERID FROM @PARM_USER_CHAGNEDEPARTMENT
)

--更新资产部门
UPDATE Asset_Information SET F_CompanyId = @CORPID,F_CompanyName = @CORPNAME, F_DepartmentId = @DEPARTMENTID,F_DepartmenName = @DEPARTMENTNAME
WHERE F_Cdefine20 IN (
	SELECT USERID FROM @PARM_USER_CHAGNEDEPARTMENT
)  

COMMIT TRAN

GO
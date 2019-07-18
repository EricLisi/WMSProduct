
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ASSET_VERIFYLIST_ZCDJ]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [ASSET_VERIFYLIST_ZCDJ]
GO
/*
	�ʲ��Ǽ���˵���
*/
CREATE PROC ASSET_VERIFYLIST_ZCDJ
@ORDERID NVARCHAR(50),	--����Id
@ORDERNO NVARCHAR(50),	--���ݺ�
@USER NVARCHAR(50),		--�����
@COMPCODE NVARCHAR(50)	--��˾����
AS  
--����У��
IF EXISTS(SELECT * FROM Asset_RegisterHead WHERE F_Id = @ORDERID AND F_VeriDate IS NOT NULL)
BEGIN
	SELECT 0,N'��ǰ�����Ѿ����!'
	RETURN 
END 

DECLARE @COMPCODE NVARCHAR(50)
DECLARE @COMPNAME NVARCHAR(120) 
SELECT @COMPCODE = F_EnCode,@COMPNAME = F_FullName FROM Sys_Organize WHERE F_Id = @COMPID
--�жϵ�ǰ���ݺ��Ƿ��Ѿ����ɹ��ʲ���Ƭ
IF NOT EXISTS(SELECT TOP 1 F_Id FROM Asset_Information WHERE F_EnCode = @ORDERNO)
BEGIN
	--���ɿ�Ƭ
	
	--��ֱ���,��������
	SELECT * INTO #TEMP_REGBODY FROM Asset_RegisterBody WHERE F_HId = @ORDERID
	DECLARE @DID NVARCHAR(50)	--�ӱ�ID
	DECLARE @QTY INT			--�ʲ�����
	DECLARE @FactorySN NVARCHAR(4000)	--ԭ������
	DECLARE @AssetType NVARCHAR(50)	--����Id
	DECLARE @COUNT INT			--��ǰ����

	SET @COUNT = 1
	WHILE EXISTS(SELECT F_ID FROM #TEMP_REGBODY)
	BEGIN
		SELECT TOP 1 @DID = F_ID,@AssetType = F_AssetType,@QTY = F_Qty,@FactorySN = F_FactorySn 
			FROM #TEMP_REGBODY ORDER BY F_SortCode 
		--ѭ��������������
		WHILE(@QTY > 0)
		BEGIN
			--��������
			DECLARE @BARCODE NVARCHAR(50)
			DECLARE @ASSETCODE NVARCHAR(50)
			SELECT @ASSETCODE = F_EnCode FROM Asset_Type WHERE F_Id = @AssetType
		
			DECLARE @PREFIX NVARCHAR(50)
			SET @PREFIX = @COMPCODE + '-' + ISNULL(@ASSETCODE,'') + '-'
			EXEC [ASSET_CREATEBARCODE] @PREFIX,@BARCODE OUTPUT 

			DECLARE @FSN NVARCHAR(50)	--ԭ�����к� 
			SET @FSN = [dbo].[GETSPLITCHAR](@FactorySN,',',@COUNT)


			--д���ʲ���
			INSERT INTO Asset_Information(F_Id,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
				,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
				,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_Principal,F_BuyDate
				,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
				,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
				,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId,F_EnabledMark)
			SELECT NEWID(),@BARCODE,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,'����',F_GroupCode
				,1,F_Amount,ISNULL(F_Ddate,F_BuyDate),F_OrderNo,F_Id,'' F_BidNumber,'' F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
				,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,@FSN,F_Owner,@COMPID,@COMPNAME,F_DepartmentId,F_Principal,F_BuyDate
				,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
				,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
				,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,GETDATE(),@USER,0
			FROM #TEMP_REGBODY 
			WHERE F_Id = @DID

			SET @QTY = @QTY - 1
			SET @COUNT = @COUNT + 1
		END 

		DELETE FROM #TEMP_REGBODY WHERE F_Id = @DID
	END
END 

--UPDATE Asset_RegisterHead SET F_Status = 1 WHERE F_Id = @ORDERID
--���ı���״̬
UPDATE Asset_RegisterBody SET Asset_RegisterBody.F_EnCode = A.F_EnCode
FROM (
	SELECT MIN(F_EnCode)+'~'+MAX(F_EnCode) F_EnCode,F_OrderDetailedId 
	FROM Asset_Information 
	WHERE F_OrderNo = @ORDERNO 
	GROUP BY F_OrderDetailedId
) AS A 
WHERE Asset_RegisterBody.F_Id = A.F_OrderDetailedId

--���ı�ͷ״̬
UPDATE Asset_RegisterHead SET F_Verify = @USER,F_VeriDate = GETDATE(),F_Status = 2 WHERE F_Id = @ORDERID
 
--�����ʲ���״̬
UPDATE Asset_Information SET F_EnabledMark = 1, F_LastModifyUserId = @USER,F_LastModifyTime = GETDATE()  WHERE F_OrderNo = @ORDERNO

DECLARE @COPRNAME NVARCHAR(120)
SELECT @COPRNAME = F_FullName FROM Sys_Organize WHERE F_Id = @COMPCODE

--д��������
INSERT INTO Asset_Records(F_Id,F_SourceCode,F_Source,F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,F_Status,F_GroupCode
			,F_Qty,F_Amount,F_Ddate,F_OrderNo,F_OrderDetailedId,F_BidNumber,F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
			,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,F_CompanyName,F_DepartmentId,F_Principal,F_BuyDate
			,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
			,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
			,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,F_CreatorTime,F_CreatorUserId)
SELECT NEWID(),@ORDERNO,'�ʲ��Ǽ�',F_EnCode,F_FullName,F_ParentId,F_AssetType,F_AssetTypeName,'����',F_GroupCode
			,1,F_Amount,ISNULL(F_Ddate,F_BuyDate),F_OrderNo,F_Id,'' F_BidNumber,'' F_Invoice,F_Model,F_NetWeight,F_GrossWeight,F_Length
			,F_Width,F_Height,F_Supplier,F_Unit,F_Brand,F_FactorySn,F_Owner,F_CompanyId,@COPRNAME,F_DepartmentId,F_Principal,F_BuyDate
			,F_TimeService,F_Depreciation,F_LifeYears,F_Description,F_Cdefine1,F_Cdefine2,F_Cdefine3,F_Cdefine4,F_Cdefine5
			,F_Cdefine6,F_Cdefine7,F_Cdefine8,F_Cdefine9,F_Cdefine10,F_Cdefine11,F_Cdefine12,F_Cdefine13,F_Cdefine14
			,F_Cdefine15,F_Cdefine16,F_Cdefine17,F_Cdefine18,F_Cdefine19,F_Cdefine20,GETDATE(),@USER
FROM Asset_Information 
WHERE F_OrderNo = @ORDERNO

SELECT 1,N''

GO
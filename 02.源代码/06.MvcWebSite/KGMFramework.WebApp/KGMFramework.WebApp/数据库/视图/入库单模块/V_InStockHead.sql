IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.V_InStockHead') AND OBJECTPROPERTY(id,N'IsView') = 1)
	DROP VIEW V_InStockHead
GO
/*
	入库单表头视图
*/
CREATE VIEW V_InStockHead WITH SCHEMABINDING
AS
SELECT A.F_Id,A.F_EnCode,A.F_OrganizationId,A.F_WarehouseId,A.F_SupplierId,A.F_SrTypeId,A.F_OwnershipId
      ,A.F_Maker,A.F_Date,A.F_Verifier,A.F_Veridate,A.F_Status,A.F_SourceId,A.F_SourceType
      ,A.F_SourceNo,A.F_Define1,A.F_Define2,A.F_Define3,A.F_Define4,A.F_Define5,A.F_Define6
      ,A.F_Define7,A.F_Define8,A.F_Define9,A.F_Define10,A.F_Description,A.F_SortCode,A.F_DeleteMark
      ,A.F_EnabledMark,A.F_CreatorTime,A.F_CreatorUserId,A.F_LastModifyTime,A.F_LastModifyUserId
      ,A.F_DeleteTime,A.F_DeleteUserId,B.F_EnCode F_SupplierCode,B.F_FullName F_SupplierName
	  ,B.F_ClassId F_SupplierClassId,B.F_Contacts F_SupplierContacts,B.F_TelePhone F_SupplierTelePhone
	  ,B.F_MobilePhone F_SupplierMobilePhone,B.F_Email F_SupplierEmail,B.F_WeChat F_SupplierWeChat
	  ,B.F_Fax F_SupplierFax,B.F_Address F_SupplierAddress,B.F_Define1 F_SupplierDefine1,B.F_Define2 F_SupplierDefine2
      ,B.F_Define3 F_SupplierDefine3,B.F_Define4 F_SupplierDefine4,B.F_Define5 F_SupplierDefine5,B.F_Define6 F_SupplierDefine6
	  ,B.F_Define7 F_SupplierDefine7,B.F_Define8 F_SupplierDefine8,B.F_Define9 F_SupplierDefine9,B.F_Define10 F_SupplierDefine10
	  ,B.F_Description F_SupplierDescription,W.F_EnCode F_WarehouseCode,W.F_FullName F_WarehouseName,W.F_Contacts F_WarehouseContacts
      ,W.F_TelePhone F_WarehouseTelePhone,W.F_MobilePhone F_WarehouseMobilePhone,W.F_Email F_WarehouseEmail
      ,W.F_WeChat F_WarehouseWeChat,W.F_Fax F_WarehouseFax,W.F_Address F_WarehouseAddress,W.F_Define1 F_WarehouseDefine1
      ,W.F_Define2 F_WarehouseDefine2,W.F_Define3 F_WarehouseDefine3,W.F_Define4 F_WarehouseDefine4,W.F_Define5 F_WarehouseDefine5
      ,W.F_Define6 F_WarehouseDefine6,W.F_Define7 F_WarehouseDefine7,W.F_Define8 F_WarehouseDefine8,W.F_Define9 F_WarehouseDefine9
      ,W.F_Define10 F_WarehouseDefine10,W.F_Description F_WarehouseDescription,S.F_EnCode F_SrTypeCode,S.F_FullName F_SrTypeName
FROM dbo.InStock_Head A
LEFT JOIN dbo.Mst_Supplier B ON A.F_SupplierId = B.F_Id
LEFT JOIN dbo.Mst_Warehouse W ON A.F_WarehouseId = W.F_Id
LEFT JOIN dbo.Mst_SrType S ON A.F_SrTypeId = S.F_Id

GO



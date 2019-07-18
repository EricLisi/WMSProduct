USE [KGM_WMS_DB]
GO

/****** Object:  View [dbo].[V_InStock]    Script Date: 2018/11/15 16:20:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[V_InStock]
AS
SELECT TOP(1000000)  
 dbo.PI_Body.F_Id, dbo.PI_Body.F_EnCode, dbo.PI_Body.F_FullName, dbo.PI_Body.F_GoodsId, 
                dbo.PI_Body.F_GoodsName, dbo.PI_Body.F_SpecifModel, dbo.PI_Body.F_Pic, dbo.PI_Body.F_RetailPrice, 
                dbo.PI_Body.F_ShelfLife, dbo.PI_Body.F_OrderNo, dbo.PI_Body.F_ProDate, dbo.PI_Body.F_ExpiratDate, 
                dbo.PI_Body.F_SellingPrice, dbo.PI_Body.F_PurchasePrice, dbo.PI_Body.F_WarehouseId, 
                dbo.PI_Body.F_WarehouseName, dbo.PI_Body.F_CargoPositionId, dbo.PI_Body.F_CargoPositionName, 
                dbo.PI_Body.F_Supplier, dbo.PI_Body.F_BasicRate, dbo.PI_Body.F_HId, dbo.PI_Body.F_InStockNum, 
                dbo.PI_Body.F_AlreadyOperatedNum, dbo.PI_Body.F_SpecifiedDate, dbo.PI_Body.F_Unit, dbo.PI_Body.F_TradePrice, 
                dbo.PI_Body.F_AllAmount, dbo.PI_Body.F_SerialNum, dbo.PI_Head.F_EnCode AS F_InCode, dbo.PI_Head.F_Vendor, 
                dbo.PI_Head.F_VendorName, dbo.PI_Body.F_SortCode
FROM      dbo.PI_Body INNER JOIN
                dbo.PI_Head ON dbo.PI_Body.F_HId = dbo.PI_Head.F_Id and dbo.PI_Head.F_Status=1
				ORDER BY PI_Head.F_EnCode



GO



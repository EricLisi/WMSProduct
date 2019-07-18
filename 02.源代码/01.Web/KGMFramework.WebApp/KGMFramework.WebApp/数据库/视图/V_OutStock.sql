USE [KGM_WMS_DB]
GO

/****** Object:  View [dbo].[V_OutStock]    Script Date: 2018/11/15 16:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER  VIEW [dbo].[V_OutStock]
AS
SELECT TOP(300000)
b.F_Id,a.F_EnCode as F_HeadBatch,a.F_CustomerId,a.F_SortCode,a.F_CustomerName,a.F_Contacts,
a.F_TelePhone,a.F_Operator,a.F_Date,a.F_Address,a.F_Description,
b.F_EnCode,b.F_HId,b.F_Num,b.F_GoodsId,b.F_GoodsName,
b.F_ShelfLife,b.F_Unit,b.F_OutStockNum,b.F_WarehouseId,b.F_WarehouseName,
b.F_CargoPositionId,b.F_CargoPositionName,b.F_Batch,b.F_SellingPrice,b.F_SpecifModel
 FROM SO_Head a,SO_Body b WHERE a.F_Id=b.F_HId and a.F_Status=1
 ORDER BY a.F_EnCode



GO



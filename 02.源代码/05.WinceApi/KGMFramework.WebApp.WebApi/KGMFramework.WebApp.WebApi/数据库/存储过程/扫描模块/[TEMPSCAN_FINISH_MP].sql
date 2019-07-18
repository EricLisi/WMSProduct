USE [KGM_WMS_DB]
GO

/****** Object:  StoredProcedure [dbo].[TEMPSCAN_FINISH_MP]    Script Date: 2019/3/28 10:47:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM  SYS.PROCEDURES WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[[[TEMPSCAN_FINISH_MP]]]'))
   drop proc [dbo].[TEMPSCAN_FINISH_MP]
go

CREATE PROC [dbo].[TEMPSCAN_FINISH_MP]
@ORDERNO NVARCHAR(50),		--单据号
@ORDERTYPE NVARCHAR(50),	--单据类型
@CMPOSCODE NVARCHAR(50),		--移入库位
@CMCWHCODE NVARCHAR(50),		--移入仓库
@RESULT INT OUTPUT,			--返回状态
@MSG NVARCHAR(4000) OUTPUT	--返回信息
AS  
/*@
	数据校验
*/
IF ISNULL(@CMPOSCODE,'') = ''
BEGIN
	SET @RESULT = 0
	SET @MSG = N'货位码不允许为空!'  
	RETURN
END

--DECLARE @CWHCODE NVARCHAR(50)
--SELECT TOP 1 @CWHCODE = F_WarehouseId 
--FROM KGM_TEMPSCAN
--WHERE F_mainID = @ORDERNO AND F_orderType = @ORDERTYPE 

IF NOT EXISTS(SELECT F_ID FROM Mst_Warehouse WHERE F_Id = @CMCWHCODE)
BEGIN
	SET @RESULT = 0
	SET @MSG = N'未能获取移入仓库信息,请确认仓库码是否正确!'   
	RETURN
END

IF NOT EXISTS(SELECT F_ID FROM Mst_CargoPosition WHERE F_WarehouseId = @CMCWHCODE AND F_Id = @CMPOSCODE)
BEGIN
	SET @RESULT = 0
	SET @MSG = N'未能获取移入货位信息,请确认货位码是否正确!'   
	RETURN
END

--写入历史记录
DECLARE @HNO NVARCHAR(50)
EXEC [KGM_CREATEORDERNO] 'MPH_',@HNO OUTPUT
INSERT INTO MP_HISTORY(F_ID,[F_DID],[F_orderType],[F_barcode],[F_mainID],[F_WarehouseId],
	[F_PositionId],[F_boxNo],[F_ProductId],[F_qty],[F_operUser],[F_operDate],[F_CMPOSID],[F_CMCHWID],[F_CustomerCode],[F_Property])
SELECT NEWID(),@HNO,@ORDERTYPE,A.[F_barcode],A.[F_mainID],A.[F_WarehouseId],
	A.[F_PositionId],A.[F_boxNo],A.[F_ProductId],A.[F_qty],A.[F_operUser],A.[F_operDate],@CMPOSCODE,@CMCWHCODE,
	[F_CustomerCode],[F_Property]
FROM KGM_TEMPSCAN AS A 
WHERE A.[F_mainID] = @ORDERNO AND A.[F_orderType] = @ORDERTYPE 
 

--扣原庫存

UPDATE Sys_Stock SET Sys_Stock.F_Number = Sys_Stock.F_Number - A.QTY
FROM (
	SELECT F_SN,F_PositionId,F_WarehouseId,SUM(F_qty) QTY,F_boxNo,F_ProductId,F_Property,F_cbatch
 	FROM KGM_TEMPSCAN
	WHERE  F_ORDERTYPE = @ORDERTYPE 
	GROUP BY f_SN,F_PositionId,F_WarehouseId,F_ProductId,F_PROPERTY,F_BOXNO,F_cbatch
) AS A
WHERE Sys_Stock.F_WarehouseId = A.F_WarehouseId AND Sys_Stock.F_CargoPositionId = A.F_PositionId  AND Sys_Stock.F_GoodsId=a.F_ProductId 
	AND Sys_Stock.F_Batch = A.F_cbatch --AND Sys_Stock.f_box = A.BOXNO
	--AND A.F_CustomerCode = Sys_Stock.CCUSCODE AND A.Property = SM_STOCK.Property



--更新库存
UPDATE Sys_Stock SET Sys_Stock.F_Number = Sys_Stock.F_Number + A.QTY
FROM (
	SELECT f_SN,F_PositionId,F_WarehouseId,SUM(F_qty) QTY,F_boxNo,F_ProductId,F_Property,F_cbatch
 	FROM KGM_TEMPSCAN
	WHERE   F_ORDERTYPE = @ORDERTYPE 
	GROUP BY f_SN,F_PositionId,F_WarehouseId,F_ProductId,F_PROPERTY,F_BOXNO,F_cbatch
) AS A
WHERE Sys_Stock.F_WarehouseId = @CMCWHCODE AND Sys_Stock.F_CargoPositionId = @CMPOSCODE  AND Sys_Stock.F_GoodsId=a.F_ProductId 
	AND Sys_Stock.F_Batch = A.F_cbatch --AND Sys_Stock.f_box = A.BOXNO
	--AND A.F_CustomerCode = Sys_Stock.CCUSCODE AND A.Property = SM_STOCK.Property

--写入不存在的库存
INSERT INTO Sys_Stock(F_ID,F_WarehouseId,F_CargoPositionId,F_Batch,F_GoodsId,F_Number,F_CreatorTime)
SELECT NEWID(),@CMCWHCODE,@CMPOSCODE,A.F_cbatch,A.F_ProductId,A.QTY,CONVERT(NVARCHAR(10),GETDATE(),120)
FROM (
	SELECT F_SN,F_PositionId,F_WarehouseId,SUM(F_QTY) QTY,F_BOXNO,F_ProductId,F_CustomerCode,F_PROPERTY,F_cbatch
	FROM KGM_TEMPSCAN
	WHERE  F_ORDERTYPE = @ORDERTYPE 
	GROUP BY F_SN,F_PositionId,F_WarehouseId,F_ProductId,F_CustomerCode,F_PROPERTY,F_BOXNO,F_cbatch
) AS A
LEFT JOIN Sys_Stock ON Sys_Stock.F_WarehouseId = @CMCWHCODE AND Sys_Stock.F_CargoPositionId = @CMPOSCODE AND Sys_Stock.F_GoodsId=a.F_ProductId 
	AND Sys_Stock.F_Batch = A.F_cbatch --AND SM_STOCK.BOXNO = A.BOXNO 
	--AND A.CCUSCODE = SM_STOCK.CCUSCODE AND A.Property = SM_STOCK.Property
WHERE Sys_Stock.F_ID IS NULL

	--IF EXISTS(SELECT A.F_Id FROM Sys_Stock A
	--left join KGM_TEMPSCAN AS B ON  A.F_GoodsId=B.F_ProductId  AND A.F_Batch=B.F_cbatch AND A.F_WarehouseId=B.F_WarehouseId AND A.F_CargoPositionId=B.F_CMPOSCODE
	--WHERE B.F_mainID = @ORDERNO AND B.F_orderType = @ORDERTYPE )
	--BEGIN 
	--	DECLARE @FFFD NVARCHAR(50)
	--	DECLARE @QTY1 int
	--	SELECT @FFFD=A.F_Id,@QTY1=B.F_qty FROM Sys_Stock A 
	--	left join KGM_TEMPSCAN AS B ON  A.F_GoodsId=B.F_ProductId AND A.F_Batch=B.F_cbatch AND A.F_WarehouseId=B.F_WarehouseId AND A.F_CargoPositionId=B.F_CMPOSCODE 
	--	WHERE B.F_mainID = @ORDERNO AND B.F_orderType = @ORDERTYPE 
	--	update Sys_Stock SET F_Number=F_Number+@QTY1 where F_Id= @FFFD
	--END
	--ELSE
	--BEGIN
	--	INSERT INTO Sys_Stock(F_ID,[F_EnCode],[F_Batch],[F_WarehouseId],[F_WarehouseName],[F_GoodsId],[F_GoodsName],[F_Number],
	--	[F_CargoPositionId],[F_CargoPositionName],[F_SpecifModel],[F_Unit],[F_SellingPrice])
	--	SELECT NEWID(),'',A.F_cbatch,A.[F_WarehouseId],B.F_FullName,A.[F_ProductId],D.F_FullName,A.F_qty,
	--	A.F_CMPOSCODE,C.F_FullName,D.[F_SpecifModel],D.F_Unit,D.[F_SellingPrice]
	--	FROM KGM_TEMPSCAN AS A 
	--	left join MSt_Warehouse B on A.[F_WarehouseId]=B.F_Id
	--	left join MSt_CargoPosition C on A.[F_PositionId]=C.F_Id
	--	left join MSt_Goods D on A.[F_ProductId]=D.F_Id
	--	WHERE A.F_mainID = @ORDERNO AND A.F_orderType = @ORDERTYPE 

	--END

----删除0库存
DELETE FROM Sys_Stock WHERE F_Number <= 0

----删除临时扫描表信息
DELETE FROM KGM_TEMPSCAN WHERE   F_orderType=@ORDERTYPE

SET @RESULT = 1
SET @MSG = N''   
GO



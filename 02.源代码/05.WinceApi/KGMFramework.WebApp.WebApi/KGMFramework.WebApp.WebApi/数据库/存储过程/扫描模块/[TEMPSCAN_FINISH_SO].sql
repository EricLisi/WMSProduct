USE [KGM_WMS_DB]
GO

/****** Object:  StoredProcedure [dbo].[TEMPSCAN_FINISH_SO]    Script Date: 2019/3/28 10:49:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


IF EXISTS (SELECT * FROM  SYS.PROCEDURES WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[TEMPSCAN_FINISH_SO]'))
   DROP PROC [dbo].[TEMPSCAN_FINISH_SO]
GO
CREATE PROC [dbo].[TEMPSCAN_FINISH_SO]
@ORDERNO NVARCHAR(50),		--单据号
@ORDERTYPE NVARCHAR(50),	--单据类型
@RESULT INT OUTPUT,			--返回状态
@MSG NVARCHAR(4000) OUTPUT	--返回信息
AS 
--单据状态校验 
EXEC [SO_VALIDATE_STATUS] @ORDERNO,@MSG OUTPUT 

IF ISNULL(@MSG,'') <> ''
BEGIN
	SET @RESULT = 0
	RETURN
END 


--差异表
CREATE TABLE #TEMP_CYDATA
(
	GOODCODE NVARCHAR(50),
	QTY INT,
	DONEQTY INT,
	CYQTY INT
)

--获取差异信息
INSERT INTO #TEMP_CYDATA(GOODCODE,QTY,DONEQTY,CYQTY)
EXEC [TEMPSCAN_GETDIFFLIST] @ORDERNO,@ORDERTYPE 

IF EXISTS(SELECT GOODCODE FROM #TEMP_CYDATA WHERE CYQTY <> 0)
BEGIN 
	--锁定主表
	--UPDATE PU_MAIN SET ISLOCK = 1 WHERE ORDERNO = @ORDERNO 
	----锁定扫描表 status = 1
	--UPDATE KGM_TEMPSCAN SET [STATUS] = 1 WHERE MAINID = @ORDERNO AND ORDERTYPE = @ORDERTYPE

	SET @RESULT = 0
	SET @MSG = N'当前扫描记录存在差异,不允许完成!' 
END
ELSE
BEGIN 
	--临时扫描表写入出库临时记录内
	INSERT INTO SO_TEMPSCAN
	SELECT * FROM KGM_TEMPSCAN
	WHERE F_mainID = @ORDERNO AND F_orderType = @ORDERTYPE
 
	--写入历史记录
	DECLARE @HNO NVARCHAR(50)
	DECLARE @QTY int
	EXEC [KGM_CREATEORDERNO] 'SOH_',@HNO OUTPUT
	INSERT INTO SO_HISTORY(F_ID,[F_DID],[F_ORDERNO],[F_orderType],[F_barcode],[F_mainID],[F_autoID],[F_WarehouseId],
		[F_CMPOSCODE],[F_boxNo],[F_ProductCode],[F_qty],[F_CustomerCode],[F_operDate])
	SELECT NEWID(),@HNO,@ORDERNO,@ORDERTYPE,A.[F_barcode],A.F_mainID,A.F_autoID,A.[F_WarehouseId],
		A.[F_CMPOSCODE],A.[F_boxNo],A.F_ProductCode,A.[F_qty],A.[F_CustomerCode],A.F_operDate
	FROM KGM_TEMPSCAN AS A 
	WHERE A.F_mainID = @ORDERNO AND A.F_orderType = @ORDERTYPE 

	--写入出入库履历
	INSERT INTO Sys_StockHistory(F_EnCode,F_BllCategory,F_Id,F_WarehouseId,F_WarehouseName,F_Vendor,F_VendorName,F_Date,F_Contacts,F_TelePhone,F_Verify,F_VeriDate,F_Address,F_Maker,F_Batch,F_CargoPositionId,F_CargoPositionName,F_GoodsId,F_GoodsName,F_OperationNum,F_SpecifModel,F_Unit)
	SELECT k.F_mainID,'出库',NEWID(),W.F_Id,W.F_FullName,S.F_Id,S.F_FullName,GETDATE(),S.F_Contacts,S.F_TelePhone,H.F_AuditingUser,H.F_VeriDate,S.F_Address,H.F_CreatorUserId,'',c.F_Id,C.F_FullName,G.F_ID,G.F_FullName,K.F_qty,G.F_SpecifModel,G.F_Unit  FROM KGM_TEMPSCAN K
	LEFT JOIN SO_Head H ON  K.F_mainID=H.F_EnCode
	LEFT JOIN Mst_Warehouse W ON K.F_WarehouseId=W.F_Id
	LEFT JOIN Mst_CargoPosition C ON C.F_Id=K.F_PositionId
	LEFT JOIN Mst_Customer S ON S.F_Id= H.F_CustomerId
	LEFT JOIN Mst_Goods G ON K.F_ProductId=G.F_Id
	WHERE K.F_mainID = @ORDERNO AND K.F_orderType = @ORDERTYPE 

	--将TempScan状态刷新为2 表示出库完成
	UPDATE KGM_TEMPSCAN SET F_status = 2 WHERE F_mainID = @ORDERNO AND F_orderType = @ORDERTYPE
	Select @QTY=[F_qty] from KGM_TEMPSCAN WHERE F_mainID = @ORDERNO AND F_orderType = @ORDERTYPE
	--更新出库数量
	UPDATE SO_Body SET SO_Body.F_OutStockNum = A.QTY
	FROM (
		SELECT [F_autoID],SUM([F_qty]) QTY FROM KGM_TEMPSCAN 
		WHERE F_mainID = @ORDERNO AND F_orderType = @ORDERTYPE 
		GROUP BY [F_autoID]
	) AS A
	WHERE   F_HId = A.F_autoID
	 
	UPDATE SO_Head SET F_Status = 4 WHERE F_EnCode = @ORDERNO 

 

 UPDATE Sys_Stock SET Sys_Stock.F_Number = Sys_Stock.F_Number - A.QTY
FROM (
	SELECT F_SN,F_PositionId,F_WarehouseId,SUM(F_QTY) QTY,F_boxNo,F_ProductId,F_CustomerCode,F_PROPERTY,F_cbatch
	FROM KGM_TEMPSCAN
	WHERE F_MAINID = @ORDERNO AND F_ORDERTYPE = 'SO' 
	GROUP BY F_SN,F_PositionId,F_WarehouseId,F_boxNo,F_ProductId,F_CustomerCode,F_PROPERTY,F_cbatch
) AS A
WHERE Sys_Stock.F_WarehouseId = A.F_WarehouseId AND Sys_Stock.F_CargoPositionId = A.F_PositionId 
	AND Sys_Stock.F_Batch = A.F_cbatch 
 

DELETE FROM Sys_Stock WHERE F_Number = 0

DELETE FROM KGM_TEMPSCAN WHERE F_mainID=@ORDERNO AND F_orderType=@ORDERTYPE

--DELETE FROM SM_PACKINGSTOCK WHERE ORDERNO = @ORDERNO


	--IF EXISTS(SELECT A.F_Id FROM Sys_Stock A
	--left join KGM_TEMPSCAN AS B ON  A.F_GoodsId=B.F_ProductId  AND A.F_Batch=B.F_cbatch AND A.F_WarehouseId=B.F_WarehouseId AND A.F_CargoPositionId=B.F_PositionId
	--WHERE B.F_mainID = @ORDERNO AND B.F_orderType = @ORDERTYPE )
	--BEGIN 
	--	DECLARE @FFFD NVARCHAR(50)
	--	SELECT @FFFD=A.F_Id FROM Sys_Stock A 
	--	left join KGM_TEMPSCAN AS B ON  A.F_GoodsId=B.F_ProductId AND A.F_Batch=B.F_cbatch AND A.F_WarehouseId=B.F_WarehouseId AND A.F_CargoPositionId=B.F_PositionId 
	--	WHERE B.F_mainID = @ORDERNO AND B.F_orderType = @ORDERTYPE 
	--	update Sys_Stock SET F_Number=F_Number-@QTY where F_Id= @FFFD
	--END
	--		--删除0库存
   --DELETE FROM Sys_Stock WHERE F_Number <= 0



	SET @RESULT = 1
	SET @MSG = ''  
END
 
GO



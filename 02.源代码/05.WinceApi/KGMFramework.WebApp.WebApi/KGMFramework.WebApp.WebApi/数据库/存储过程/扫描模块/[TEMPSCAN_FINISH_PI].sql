USE [KGM_WMS_DB]
GO

/****** Object:  StoredProcedure [dbo].[TEMPSCAN_FINISH_PI]    Script Date: 2019/3/28 10:48:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM  SYS.PROCEDURES WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[[[[TEMPSCAN_FINISH_PI]]]]'))
   drop proc [dbo].[TEMPSCAN_FINISH_PI]
go

CREATE PROC [dbo].[TEMPSCAN_FINISH_PI]
@ORDERNO NVARCHAR(50),		--���ݺ�
@ORDERTYPE NVARCHAR(50),	--��������
@RESULT INT OUTPUT,			--����״̬
@MSG NVARCHAR(4000) OUTPUT	--������Ϣ
AS 
--����״̬У�� 
EXEC [PI_VALIDATE_STATUS] @ORDERNO,@MSG OUTPUT 

IF ISNULL(@MSG,'') <> ''
BEGIN
	SET @RESULT = 0
	RETURN
END 


--�����
CREATE TABLE #TEMP_CYDATA
(
	GOODCODE NVARCHAR(50),
	QTY INT,
	DONEQTY INT,
	CYQTY INT
)
--��ȡ������Ϣ
INSERT INTO #TEMP_CYDATA(GOODCODE,QTY,DONEQTY,CYQTY)
EXEC [TEMPSCAN_GETDIFFLIST] @ORDERNO,@ORDERTYPE 

IF EXISTS(SELECT GOODCODE FROM #TEMP_CYDATA WHERE CYQTY <> 0)
BEGIN 

	--��������
	--UPDATE PU_MAIN SET ISLOCK = 1 WHERE ORDERNO = @ORDERNO 
	----����ɨ��� status = 1
	--UPDATE KGM_TEMPSCAN SET [STATUS] = 1 WHERE MAINID = @ORDERNO AND ORDERTYPE = @ORDERTYPE

	SET @RESULT = 0
	SET @MSG = N'��ǰɨ���¼���ڲ���,���������!' 
END
ELSE
BEGIN 


	--��ʱɨ���д�뵽����ʱ��¼��
	INSERT INTO PI_TEMPSCAN
	SELECT * FROM KGM_TEMPSCAN WHERE F_mainID = @ORDERNO AND F_orderType = @ORDERTYPE
	

	--д����ʷ��¼
	DECLARE @HNO NVARCHAR(50)
	DECLARE @QTY int
	EXEC [KGM_CREATEORDERNO] 'PIH_',@HNO OUTPUT
	INSERT INTO PI_HISTORY(F_ID,[F_DID],[F_ORDERNO],[F_orderType],[F_barcode],[F_mainID],[F_autoID],[F_WarehouseId],
		[F_CMPOSCODE],[F_boxNo],[F_ProductCode],[F_qty],[F_CustomerCode],[F_OrderDate])
	SELECT NEWID(),@HNO,@ORDERNO,@ORDERTYPE,A.[F_barcode],A.F_mainID,A.F_autoID,A.[F_WarehouseId],
		A.[F_CMPOSCODE],A.[F_boxNo],A.F_ProductCode,A.[F_qty],A.[F_CustomerCode],A.F_operDate
	FROM KGM_TEMPSCAN AS A 
	WHERE A.F_mainID = @ORDERNO AND A.F_orderType = @ORDERTYPE 
	--д����������
	INSERT INTO Sys_StockHistory(F_EnCode,F_BllCategory,F_Id,F_WarehouseId,F_WarehouseName,F_Vendor,F_VendorName,F_Date,F_Contacts,F_TelePhone,F_Verify,F_VeriDate,F_Address,F_Maker,F_Batch,F_CargoPositionId,F_CargoPositionName,F_GoodsId,F_GoodsName,F_OperationNum,F_SpecifModel,F_Unit)
	SELECT k.F_mainID,'���',NEWID(),W.F_Id,W.F_FullName,S.F_Id,S.F_FullName,GETDATE(),S.F_Contacts,S.F_TelePhone,H.F_Verify,H.F_VeriDate,S.F_Address,H.F_Maker,'',c.F_Id,C.F_FullName,G.F_ID,G.F_FullName,K.F_qty,G.F_SpecifModel,G.F_Unit  FROM KGM_TEMPSCAN K
	LEFT JOIN PI_Head H ON  K.F_mainID=H.F_EnCode
	LEFT JOIN Mst_Warehouse W ON K.F_WarehouseId=W.F_Id
	LEFT JOIN Mst_CargoPosition C ON C.F_Id=K.F_PositionId
	LEFT JOIN Mst_Suppliers S ON S.F_Id= H.F_Vendor
	LEFT JOIN Mst_Goods G ON K.F_ProductId=G.F_Id
	WHERE K.F_mainID = @ORDERNO AND K.F_orderType = @ORDERTYPE 

	--��TempScan״̬ˢ��Ϊ2 ��ʾ������ ���ϼ�
	UPDATE KGM_TEMPSCAN SET F_status = 2 WHERE F_mainID = @ORDERNO AND F_orderType = @ORDERTYPE
	Select @QTY=[F_qty] from KGM_TEMPSCAN WHERE F_mainID = @ORDERNO AND F_orderType = @ORDERTYPE
	--�����ӱ�������
	UPDATE PI_Body SET PI_Body.F_InStockNum = A.QTY
	FROM (
		SELECT [F_autoID],SUM([F_qty]) QTY FROM KGM_TEMPSCAN 
		WHERE F_mainID = @ORDERNO AND F_orderType = @ORDERTYPE 
		GROUP BY [F_autoID]
	) AS A
	WHERE PI_Body.F_OrderNo = @ORDERNO AND PI_Body.F_Id = A.F_autoID
	 
	UPDATE PI_Head SET F_Status = 4 WHERE F_EnCode = @ORDERNO 


--���¿��
UPDATE Sys_Stock SET Sys_Stock.F_Number = Sys_Stock.F_Number + A.QTY
FROM (
	SELECT f_SN,F_PositionId,F_WarehouseId,SUM(F_qty) QTY,F_boxNo,F_ProductCode,F_CustomerCode,F_Property,F_cbatch
 	FROM KGM_TEMPSCAN
	WHERE F_MAINID = @ORDERNO AND F_ORDERTYPE = @ORDERTYPE 
	GROUP BY f_SN,F_PositionId,F_WarehouseId,F_ProductCode,F_CustomerCode,F_PROPERTY,F_BOXNO,F_cbatch
) AS A
WHERE Sys_Stock.F_WarehouseId = A.F_WarehouseId AND Sys_Stock.F_CargoPositionId = A.F_PositionId 
	AND Sys_Stock.F_Batch = A.F_cbatch --AND Sys_Stock.f_box = A.BOXNO
	--AND A.F_CustomerCode = Sys_Stock.CCUSCODE AND A.Property = SM_STOCK.Property

--д�벻���ڵĿ��
INSERT INTO Sys_Stock(F_ID,F_WarehouseId,F_CargoPositionId,F_Batch,F_GoodsId,F_Number,F_CreatorTime)
SELECT NEWID(),A.F_WarehouseId,A.F_PositionId,A.F_cbatch,A.F_ProductId,A.QTY,CONVERT(NVARCHAR(10),GETDATE(),120)
FROM (
	SELECT F_SN,F_PositionId,F_WarehouseId,SUM(F_QTY) QTY,F_BOXNO,F_ProductId,F_CustomerCode,F_PROPERTY,F_cbatch
	FROM KGM_TEMPSCAN
	WHERE F_MAINID = @ORDERNO AND F_ORDERTYPE = @ORDERTYPE 
	GROUP BY F_SN,F_PositionId,F_WarehouseId,F_ProductId,F_CustomerCode,F_PROPERTY,F_BOXNO,F_cbatch
) AS A
LEFT JOIN Sys_Stock ON Sys_Stock.F_WarehouseId = A.F_WarehouseId AND Sys_Stock.F_CargoPositionId = A.F_PositionId 
	AND Sys_Stock.F_Batch = A.F_cbatch --AND SM_STOCK.BOXNO = A.BOXNO 
	--AND A.CCUSCODE = SM_STOCK.CCUSCODE AND A.Property = SM_STOCK.Property
WHERE Sys_Stock.F_ID IS NULL

--��������״̬
UPDATE PI_Head SET [F_STATUS] = 5 WHERE F_EnCode = @ORDERNO 
--ɾ����ʱɨ�����Ϣ
DELETE FROM KGM_TEMPSCAN WHERE F_MAINID = @ORDERNO
--ɾ��������¼����Ϣ
DELETE FROM PI_TEMPSCAN WHERE F_MAINID = @ORDERNO

SET @RESULT = 1
SET @MSG = '' 
END


GO



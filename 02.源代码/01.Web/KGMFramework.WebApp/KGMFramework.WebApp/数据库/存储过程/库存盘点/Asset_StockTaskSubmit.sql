IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Asset_StockTaskSubmit]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [Asset_StockTaskSubmit]
GO
 
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'PARM_Asset_StockTaskSubmit' AND ss.name = N'dbo')
	DROP TYPE [dbo].[PARM_Asset_StockTaskSubmit]
GO

CREATE TYPE [PARM_Asset_StockTaskSubmit] AS TABLE(
	ID NVARCHAR(50) 
)

GO

/*
	App�ύ�̵���
*/
CREATE PROC [Asset_StockTaskSubmit] 
@ORDERNO NVARCHAR(50),--���ݺ�
@BALLSCAN BIT,			--�Ƿ�ȫ��ɨ��
@SCANTYPE INT,			--0 ����δɨ������ 1 ����ɨ������
@PARM_Asset_StockTaskSubmit [PARM_Asset_StockTaskSubmit] READONLY	--�û�Id
AS
SET XACT_ABORT ON
BEGIN TRAN
IF @BALLSCAN = 1
BEGIN
	UPDATE Asset_StockTaskBody SET F_EnabledMark = 1 WHERE F_OrderNo = @ORDERNO
END
ELSE
BEGIN 
	IF @SCANTYPE = 1
	BEGIN
		UPDATE Asset_StockTaskBody SET F_EnabledMark = 0 WHERE F_OrderNo = @ORDERNO
		UPDATE Asset_StockTaskBody SET F_EnabledMark = 1 WHERE F_Id IN (
			SELECT ID FROM @PARM_Asset_StockTaskSubmit
		) AND F_OrderNo = @ORDERNO
	END
	ELSE
	BEGIN
		UPDATE Asset_StockTaskBody SET F_EnabledMark = 1 WHERE F_OrderNo = @ORDERNO
		UPDATE Asset_StockTaskBody SET F_EnabledMark = 0 WHERE F_Id IN (
			SELECT ID FROM @PARM_Asset_StockTaskSubmit
		) AND F_OrderNo = @ORDERNO
	END
END
COMMIT TRAN

GO
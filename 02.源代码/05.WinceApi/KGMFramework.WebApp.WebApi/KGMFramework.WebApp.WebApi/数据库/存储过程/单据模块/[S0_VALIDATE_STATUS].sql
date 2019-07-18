USE [KGM_WMS_DB]
GO

/****** Object:  StoredProcedure [dbo].[S0_VALIDATE_STATUS]    Script Date: 2019/3/28 10:53:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
	���ⵥ��״̬У��
*/
IF EXISTS(SELECT  * FROM SYS.PROCEDURES WHERE  OBJECT_ID = OBJECT_ID(N'[dbo].[S0_VALIDATE_STATUS]'))
   DROP PROC [dbo].[S0_VALIDATE_STATUS]
GO
CREATE PROC [dbo].[S0_VALIDATE_STATUS]
@ORDERNO NVARCHAR(50),	--���ݺ�
@MSG NVARCHAR(4000) OUTPUT	--������Ϣ
AS 
SET @MSG = ''

DECLARE @CSTATUS INT
DECLARE @ISLOCK INT
DECLARE @EXISTS INT
SET @EXISTS = 0
SELECT @CSTATUS = F_Status  --@ISLOCK = ISLOCK,@EXISTS = COUNT(*) 
FROM PI_Head 
WHERE F_EnCode = @ORDERNO
--GROUP BY [STATUS],ISLOCK
--IF @EXISTS = 0
--BEGIN
--	SET @MSG = N'δ�ܻ�ȡ��������Ϣ,���ݿ����Ѿ�ɾ��!'
--	RETURN
--END
--IF @ISLOCK = 1
--BEGIN
--	SET @MSG = N'�����Ѿ�����,�������������!'
--	RETURN
--END
--IF @CSTATUS < 2
--BEGIN
--	SET @MSG = N'�����Ѿ�����,�������������!'
--	RETURN
--END
--ELSE 
IF @CSTATUS = 4
BEGIN
	SET @MSG = N'�����Ѿ����,�������������!'
	RETURN
END 
--ELSE IF @CSTATUS > 4
--BEGIN
--	SET @MSG = N'�����Ѿ��ϼ����,�������������!'
--	RETURN
--END 


GO



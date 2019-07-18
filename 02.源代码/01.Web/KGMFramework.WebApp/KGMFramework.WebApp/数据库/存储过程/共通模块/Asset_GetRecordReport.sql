
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Asset_GetRecordReport]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [Asset_GetRecordReport]
GO
/*
	��ȡ�ʲ�״̬��
*/
CREATE PROC [Asset_GetRecordReport]
@CorpId NVARCHAR(50)	--��˾Id
AS 
SET XACT_ABORT ON 
BEGIN TRAN
--��ȡ����ȵ�����
DECLARE @BEGINDATE DATETIME
DECLARE @ENDATE DATETIME

SELECT @BEGINDATE = CAST(CONVERT(NVARCHAR(4),GETDATE(),120) + '-01-01' AS DATETIME)
SELECT @ENDATE = CAST(CONVERT(NVARCHAR(4),DATEADD(YEAR,1, GETDATE()),120) + '-01-01' AS DATETIME)

SELECT CASE WHEN F_Source = '�ʲ�����' OR F_Source = '�ʲ�����' OR F_Source = '�ʲ��黹' OR F_Source = '�ʲ�����' OR F_Source = '�ʲ�����'
	THEN '�ʲ�ת��' WHEN F_Source = '�ʲ�ά��' THEN '�ʲ�����' ELSE F_Source END F_Source ,COUNT(*) Qty,SUBSTRING(CONVERT(NVARCHAR(7),F_CreatorTime,120),6,2) Mon
INTO #TEMP_RECORD
FROM Asset_Records 
WHERE F_CreatorTime >= @BEGINDATE AND  F_CreatorTime <@ENDATE
GROUP BY  SUBSTRING(CONVERT(NVARCHAR(7),F_CreatorTime,120),6,2),CASE WHEN F_Source = '�ʲ�����' OR F_Source = '�ʲ�����' OR F_Source = '�ʲ��黹' OR F_Source = '�ʲ�����' OR F_Source = '�ʲ�����'
	THEN '�ʲ�ת��' WHEN F_Source = '�ʲ�ά��' THEN '�ʲ�����' ELSE F_Source END 

 

COMMIT TRAN

 


 


 
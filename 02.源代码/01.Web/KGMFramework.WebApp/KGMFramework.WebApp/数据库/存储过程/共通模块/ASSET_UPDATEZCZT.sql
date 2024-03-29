IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ASSET_GETINFO]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [ASSET_GETINFO]
GO
/*
	获取资产信息
*/
CREATE PROC ASSET_GETINFO
@COMPID NVARCHAR(50),			--公司Id
@DEPTID NVARCHAR(50),			--部门Id
@STATUS NVARCHAR(500),			--资产状态
@CONDITION NVARCHAR(4000),		--过滤条件
@PAGEINDEX INT,					--当前页
@PAGESIZE INT					--每页数量
AS
SET XACT_ABORT ON
BEGIN TRAN

SELECT * INTO #TEMP_SASSETINFO FROM V_Asset_Info WHERE 1 = 2

DECLARE @SQL NVARCHAR(4000)
SET @SQL = ' INSERT INTO #TEMP_SASSETINFO SELECT * FROM V_Asset_Info WHERE (F_EnabledMark = 1 OR F_Status = ''处理'') '
IF ISNULL(@COMPID,'') <> ''
BEGIN
	SET @SQL = @SQL + ' AND F_CompanyId = @F_CompanyId '
END
IF ISNULL(@DEPTID,'') <> ''
BEGIN
	SET @SQL = @SQL + ' AND ( F_DepartmentId = @F_DepartmentId OR ISNULL(F_DepartmentId,'''') = '''' )'
END
IF ISNULL(@STATUS,'') <> ''
BEGIN
	SET @SQL = @SQL + ' AND F_Status IN ('''+ REPLACE( @STATUS,',',''',''') +''')'
END

SET @SQL = @SQL + @CONDITION 

EXEC SP_EXECUTESQL @SQL,N'@F_CompanyId NVARCHAR(50),@F_DepartmentId NVARCHAR(50)',@COMPID,@DEPTID

DECLARE @RDS INT
SET @RDS = 0
SELECT @RDS = COUNT(*) FROM #TEMP_SASSETINFO


IF @PAGEINDEX <> -1
BEGIN
	SELECT * FROM  (
		SELECT ROW_NUMBER() OVER(ORDER BY F_EnCode)  as R,*,@RDS RDS  FROM #TEMP_SASSETINFO
	) t  WHERE R> (@PAGEINDEX - 1) * @PAGESIZE AND R <= @PAGEINDEX * @PAGESIZE
END
ELSE
BEGIN
	SELECT ROW_NUMBER() OVER(ORDER BY F_EnCode)  as R,*,@RDS RDS  FROM #TEMP_SASSETINFO
END

COMMIT TRAN
GO
  
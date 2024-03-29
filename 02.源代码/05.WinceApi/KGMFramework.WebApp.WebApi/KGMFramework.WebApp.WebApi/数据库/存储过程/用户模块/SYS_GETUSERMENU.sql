IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[SYS_GETUSERMENU]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROC [SYS_GETUSERMENU]
GO
/*
	获取用户可操作菜单
*/
CREATE PROC [SYS_GETUSERMENU]
@USERID NVARCHAR(50),	--用户ID
@ISAPP BIT = 0
AS
IF @USERID = 'kgmAdmin' 
BEGIN
	IF @ISAPP = 1
	BEGIN
		SELECT * FROM Sys_Module WHERE F_IsApp = @ISAPP AND F_ParentId <> '0' ORDER BY F_SortCode
	END
	ELSE
	BEGIN
		SELECT * FROM Sys_Module WHERE F_IsApp = @ISAPP ORDER BY F_SortCode
	END
END
ELSE
BEGIN
	DECLARE @ROLEID NVARCHAR(50)	--角色ID
	DECLARE @ISADMIN INT			--是否系统管理员

	SELECT @ROLEID = F_RoleId,@ISADMIN = F_IsAdministrator
	FROM Sys_User
	WHERE F_Id = @USERID

	IF @ISADMIN = 1
	BEGIN
		IF @ISAPP = 1
		BEGIN
			SELECT * FROM Sys_Module WHERE F_IsApp = @ISAPP AND F_ParentId <> '0' ORDER BY F_SortCode
		END
		ELSE
		BEGIN
			SELECT * FROM Sys_Module WHERE F_IsApp = @ISAPP ORDER BY F_SortCode
		END
	END 
	ELSE
	BEGIN
		IF @ISAPP = 1
		BEGIN 
			SELECT B.*
			FROM Sys_RoleAuthorize AS A
			INNER JOIN Sys_Module AS B ON A.F_ItemId = B.F_Id
			WHERE A.F_ObjectId = @ROLEID AND F_ItemType = '1' AND F_IsApp = @ISAPP AND F_ParentId <> '0'
			ORDER BY B.F_SortCode
		END
		ELSE
		BEGIN
			SELECT B.*
			FROM Sys_RoleAuthorize AS A
			INNER JOIN Sys_Module AS B ON A.F_ItemId = B.F_Id
			WHERE A.F_ObjectId = @ROLEID AND F_ItemType = '1' AND F_IsApp = @ISAPP 
			ORDER BY B.F_SortCode
		END
	END
END
GO
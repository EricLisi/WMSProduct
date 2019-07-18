 
/*
	实现split功能的函数,拆分为NVARCHAR类型  
*/
CREATE FUNCTION [dbo].[FUN_SplitCharsTable](@SourceSql NVARCHAR(4000),@StrSeprate NVARCHAR(10))      
    RETURNS @temp TABLE(a NVARCHAR(500))      
AS       
BEGIN    
	DECLARE @i INT      
	SET @SourceSql=RTRIM(LTRIM(UPPER(@SourceSql)))      
	SET @i=CHARINDEX(@StrSeprate,@SourceSql)      
    WHILE @i>=1      
    BEGIN      
        INSERT @temp VALUES(RTRIM(LTRIM(LEFT(@SourceSql,@i-1))))      
        SET @SourceSql=SUBSTRING(@SourceSql,@i+1,LEN(@SourceSql)-@i)      
        SET @i=CHARINDEX(@StrSeprate,@SourceSql)     
    END      
--  IF @SourceSql <> ''   
--	BEGIN   
		INSERT @temp VALUES(RTRIM(LTRIM(@SourceSql)))      
--	END
	RETURN
END
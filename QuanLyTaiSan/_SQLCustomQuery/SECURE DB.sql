USE [master]
GO
CREATE LOGIN [test] WITH PASSWORD=N'test', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
EXEC master..sp_addsrvrolemember @loginame = N'test', @rolename = N'sysadmin'
GO
CREATE USER [test] FROM LOGIN [test] WITH DEFAULT_SCHEMA = dbo
GO
ALTER LOGIN [quocdunginfo-PC\quocdunginfo] ENABLE
GO
DECLARE @hostName NVARCHAR(255)
SET @hostName = (SELECT HOST_NAME())
DECLARE @currentUser NVARCHAR(255);
SET @currentUser = (SUSER_NAME());
DECLARE @statement NVARCHAR(255)
SET @statement = 'ALTER LOGIN [' + @hostName + '\' + @currentUser + '] DISABLE'
EXEC sp_executesql @statement
GO








DECLARE @loginNameToDrop sysname
SET @loginNameToDrop = 'test';

DECLARE sessionsToKill CURSOR FAST_FORWARD FOR
    SELECT session_id
    FROM sys.dm_exec_sessions
    WHERE login_name = @loginNameToDrop
OPEN sessionsToKill

DECLARE @sessionId INT
DECLARE @statement NVARCHAR(200)

FETCH NEXT FROM sessionsToKill INTO @sessionId

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Killing session ' + CAST(@sessionId AS NVARCHAR(20)) + ' for login ' + @loginNameToDrop

    SET @statement = 'KILL ' + CAST(@sessionId AS NVARCHAR(20))
    EXEC sp_executesql @statement

    FETCH NEXT FROM sessionsToKill INTO @sessionId
END

CLOSE sessionsToKill
DEALLOCATE sessionsToKill

PRINT 'Dropping login ' + @loginNameToDrop
SET @statement = 'DROP LOGIN [' + @loginNameToDrop + ']'
EXEC sp_executesql @statement
/*=====================REMOVE ALL PROCEDURES===================*/
DECLARE @sql VARCHAR(MAX)='';

SELECT @sql=@sql+'drop procedure ['+name +'];' FROM sys.objects 
WHERE type = 'p' AND  is_ms_shipped = 0

exec(@sql);


/***********REMOVE ALL TRIGGERS OF ALL TABLES*/
DECLARE @SQLCmd nvarchar(1000) 
DECLARE @Trig varchar(500)
DECLARE @sch varchar(500)

DECLARE TGCursor CURSOR FOR

SELECT ISNULL(tbl.name, vue.name) AS [schemaName]
     , trg.name AS triggerName
FROM sys.triggers trg
LEFT OUTER JOIN (SELECT tparent.object_id, ts.name 
                 FROM sys.tables tparent 
                 INNER JOIN sys.schemas ts ON TS.schema_id = tparent.SCHEMA_ID) 
                 AS tbl ON tbl.OBJECT_ID = trg.parent_id
LEFT OUTER JOIN (SELECT vparent.object_id, vs.name 
                 FROM sys.views vparent 
                 INNER JOIN sys.schemas vs ON vs.schema_id = vparent.SCHEMA_ID) 
                 AS vue ON vue.OBJECT_ID = trg.parent_id
 
OPEN TGCursor
FETCH NEXT FROM TGCursor INTO @sch,@Trig
WHILE @@FETCH_STATUS = 0
BEGIN

SET @SQLCmd = N'DROP TRIGGER [' + @sch + '].[' + @Trig + ']'
EXEC sp_executesql @SQLCmd
PRINT @SQLCmd

FETCH next FROM TGCursor INTO @sch,@Trig
END

CLOSE TGCursor
DEALLOCATE TGCursor

/***********REMOVE ALL TRACKING TABLE*/
declare @cmd varchar(4000)
declare cmds cursor for 
select 'drop table [' + Table_Name + ']'
from INFORMATION_SCHEMA.TABLES
where Table_Name like '%_tracking'

open cmds
while 1=1
begin
    fetch cmds into @cmd
    if @@fetch_status != 0 break
    exec(@cmd)
end
close cmds;
deallocate cmds

/***********3 special tables**************/
DROP TABLE [dbo].[schema_info]
GO
DROP TABLE [dbo].[scope_config]
GO
DROP TABLE [dbo].[scope_info]
GO

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
DROP TABLE [schema_info]
GO
DROP TABLE [scope_config]
GO
DROP TABLE [scope_info]
GO
----------------- FOR SURE
declare @n char(1)
set @n = char(10)

declare @stmt nvarchar(max)

-- procedures
select @stmt = isnull( @stmt + @n, '' ) +
    'drop procedure [' + schema_name(schema_id) + '].[' + name + ']'
from sys.procedures

-- functions
select @stmt = isnull( @stmt + @n, '' ) +
    'drop function [' + schema_name(schema_id) + '].[' + name + ']'
from sys.objects
where type in ( 'FN', 'IF', 'TF' )

-- views
select @stmt = isnull( @stmt + @n, '' ) +
    'drop view [' + schema_name(schema_id) + '].[' + name + ']'
from sys.views

-- user defined types
select @stmt = isnull( @stmt + @n, '' ) +
    'drop type [' + schema_name(schema_id) + '].[' + name + ']'
from sys.types
where is_user_defined = 1
exec sp_executesql @stmt
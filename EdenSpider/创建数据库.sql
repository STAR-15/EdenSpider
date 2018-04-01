--------创建数据库
use master
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Example')
DROP DATABASE [Example]
GO
CREATE DATABASE [Example]
on
(
name='Example_data',
filename='D:\CodeSource\ExampleDB\Example_data.mdf',
size=10,
filegrowth=20%
)
log on
(
name='Example_log',
filename='D:\CodeSource\ExampleDB\Example_log.ldf',
size=3,
maxsize=20,
filegrowth=10%
)
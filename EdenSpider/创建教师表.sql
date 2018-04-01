------创建教师表
use [Example]
go
if exists (select name from [Example].dbo.sysobjects where name ='Teacher')
drop table Teacher
create table Teacher
(
TId int not null primary key,
TName nvarchar(15) 
)
go
--插入数据到教师表中

insert into Teacher(TId,TName) values(1,'小屋');
insert into Teacher(TId,TName) values(2,'DAVA');
insert into Teacher(TId,TName) values(3,'刘局');
insert into Teacher(TId,TName) values(4,'张厚');
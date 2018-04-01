/****** Script for SelectTopNRows command from SSMS  ******/
--5.创建成绩表

use [Example]

if exists(select * from [Example].dbo.sysobjects  where id=object_id(N'[dbo].[SC]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table SC ----[dbo].[sc]
go 
create table SC
(
 SNo int not null,
 CNo int not null,
 Score float not null 

)
go

--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[table_name]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
--drop table [dbo].[table_name]
--GO

--CREATE TABLE [dbo].[table_name] (....)
--GO

--创建外键

--alter table [dbo].[sc] with check  add constraint [foreign_key1] foreign key([cno]) references [dbo].[course] ([cno])
--alter table [dbo].[sc] with check  add constraint [foreign_key2] foreign key([sno]) references [dbo].[student] ([sno])

ALTER TABLE [dbo].[sc] WITH CHECK ADD CONSTRAINT [FK_sc_course] FOREIGN KEY([cno])
REFERENCES [dbo].[course] ([cno])
ALTER TABLE [dbo].[sc] WITH CHECK ADD CONSTRAINT [FK_sc_student] FOREIGN KEY([sno])
REFERENCES [dbo].[student] ([sno])
--删除外键

--第一步:找出指定表上的外键约束名字

--exec sp_helpconstraint 'dbo.sc'
--第二步：删除外键约束
--alter table [dbo].[studnet] drop constraint FK_sc_student

--插入数据
INSERT INTO sc(sno,cno,score)VALUES(1,1,80) 
INSERT INTO sc(sno,cno,score)VALUES(1,2,86) 
INSERT INTO sc(sno,cno,score)VALUES(1,3,83) 
INSERT INTO sc(sno,cno,score)VALUES(1,4,89) 

INSERT INTO sc(sno,cno,score)VALUES(2,1,50) 
INSERT INTO sc(sno,cno,score)VALUES(2,2,36) 
--INSERT INTO sc(sno,cno,score)VALUES(2,3,43) 
INSERT INTO sc(sno,cno,score)VALUES(2,4,59)

INSERT INTO sc(sno,cno,score)VALUES(3,1,50) 
INSERT INTO sc(sno,cno,score)VALUES(3,2,96) 
--INSERT INTO sc(sno,cno,score)VALUES(3,3,73) 
INSERT INTO sc(sno,cno,score)VALUES(3,4,69) 
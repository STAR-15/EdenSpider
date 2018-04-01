---- ----创建学生表
 
use [Example]
 go
 if exists(select name from [Example].dbo.sysobjects where name ='Student')
  drop table Student
create table Student
 (
  SNo int not null primary key,
  SName nvarchar(15) not null,
  SAge  datetime not null,
  SSex char(2) not null
 )
 
--go

--插入数据
INSERT INTO student(sno,sname,sage,ssex) VALUES(1,'张三','1980-1-23','男')
INSERT INTO student(sno,sname,sage,ssex) VALUES(2,'李四','1982-12-12','男')
INSERT INTO student(sno,sname,sage,ssex) VALUES(3,'张飒','1981-9-9','男')
INSERT INTO student(sno,sname,sage,ssex) VALUES(4,'莉莉','1983-3-23','女')
INSERT INTO student(sno,sname,sage,ssex) VALUES(5,'王弼','1982-6-21','男')
INSERT INTO student(sno,sname,sage,ssex) VALUES(6,'王丽','1984-10-10','女')
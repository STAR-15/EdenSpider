----.创建课程表
CREATE TABLE [dbo].[Course](
    [CNo] [int] NOT NULL PRIMARY KEY,
    [CName] [nvarchar](20) NOT NULL,
    [TId] [int] NOT NULL
)

--创建外键,已经存在两张表，我想用sql语句建立这两张表的主外键关系
--ALTER TABLE 表名1 add constraint 约束名 foreign key（字段) references 表名2（字段）

alter table course add constraint course_to_student foreign key(tid) references teacher(tid); 
ALTER TABLE [dbo].[course] WITH CHECK ADD 
CONSTRAINT [FK_course_teacher] FOREIGN KEY([tid])
REFERENCES [dbo].[teacher] ([tid])

--插入数据
insert into course(cno,cname,tid) values(1,'企业管理',3)
insert into course(cno,cname,tid) values(2,'马克思',1)
insert into course(cno,cname,tid) values(3,'UML',2)
insert into course(cno,cname,tid) values(4,'数据库',5)
insert into course(cno,cname,tid) values(5,'物理',8)
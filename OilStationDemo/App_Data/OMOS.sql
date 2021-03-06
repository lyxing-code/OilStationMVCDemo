USE OSMS
GO

CREATE TABLE dbo.Approver
	(
	  Id            UNIQUEIDENTIFIER NOT NULL
	, JobCode       VARCHAR (100) NOT NULL
	, AreaLeve      INT NOT NULL
	, Discrible     NVARCHAR (100) NULL
	, [Order]       INT NOT NULL
	, ProcessItemId UNIQUEIDENTIFIER NULL
	, ExecuteMethod NVARCHAR (100) NULL
	, PRIMARY KEY (Id)
	, CONSTRAINT FK__Approver__Proces__30F848ED FOREIGN KEY (ProcessItemId) REFERENCES dbo.ProcessItem (Id)
	)
GO

CREATE TABLE dbo.Entry
	(
	  Id                                 UNIQUEIDENTIFIER NOT NULL
	, StaffName                          NVARCHAR (500) NOT NULL
	, Sex                                BIT NOT NULL
	, BirthDay                           DATE NULL
	, MaritalStatus                      BIT NULL
	, Height                             DECIMAL (5, 2) NULL
	, HighestEducation                   INT NULL
	, Major                              NVARCHAR (500) NULL
	, ForeginLanguageAptitude            NVARCHAR (500) NULL
	, IDNumber                           VARCHAR (20) NULL
	, NativePlace                        NVARCHAR (500) NULL
	, Address                            NVARCHAR (500) NULL
	, Email                              NVARCHAR (500) NULL
	, Tel                                CHAR (20) NULL
	, HaseMedicalHistory                 BIT NULL
	, MedicalHistoryComment              NVARCHAR (500) NULL
	, HobbiesAndSpeciality               NVARCHAR (500) NULL
	, EducationalExperience1StartDate    DATE NULL
	, EducationalExperience1EndDate      DATE NULL
	, EducationalExperience1SchoolName   NVARCHAR (500) NULL
	, EducationalExperience1Major        NVARCHAR (500) NULL
	, EducationalExperience1Certificate  NVARCHAR (500) NULL
	, EducationalExperience2StartDate    DATE NULL
	, EducationalExperience2EndDate      DATE NULL
	, EducationalExperience2SchoolName   NVARCHAR (500) NULL
	, EducationalExperience2Major        NVARCHAR (500) NULL
	, EducationalExperience2Certificate  NVARCHAR (500) NULL
	, EducationalExperience3StartDate    DATE NULL
	, EducationalExperience3EndDate      DATE NULL
	, EducationalExperience3SchoolName   NVARCHAR (500) NULL
	, EducationalExperience3Major        NVARCHAR (500) NULL
	, EducationalExperience3Certificate  NVARCHAR (500) NULL
	, EducationalExperience4StartDate    DATE NULL
	, EducationalExperience4EndDate      DATE NULL
	, EducationalExperience4SchoolName   NVARCHAR (500) NULL
	, EducationalExperience4Major        NVARCHAR (500) NULL
	, EducationalExperience4Certificate  NVARCHAR (500) NULL
	, FamilyStatus1Name                  NVARCHAR (500) NULL
	, FamilyStatus1Appellation           NVARCHAR (500) NULL
	, FamilyStatus1Company               NVARCHAR (500) NULL
	, FamilyStatus1Tel                   VARCHAR (20) NULL
	, FamilyStatus2Name                  NVARCHAR (500) NULL
	, FamilyStatus2Appellation           NVARCHAR (500) NULL
	, FamilyStatus2Company               NVARCHAR (500) NULL
	, FamilyStatus2Tel                   VARCHAR (20) NULL
	, EmergencyContactName               NVARCHAR (500) NULL
	, EmergencyContactTel                VARCHAR (20) NULL
	, EmergencyContactEelationShipWithMe NVARCHAR (500) NULL
	, WorkExperience1CompanyName         NVARCHAR (500) NULL
	, WorkExperience1Job                 NVARCHAR (500) NULL
	, WorkExperience1StartDate           DATE NULL
	, WorkExperience1EndDate             DATE NULL
	, WorkExperience1Pay                 NVARCHAR (50) NULL
	, WorkExperience1LeavingReasons      NVARCHAR (100) NULL
	, WorkExperience2CompanyName         NVARCHAR (500) NULL
	, WorkExperience2Job                 NVARCHAR (500) NULL
	, WorkExperience2StartDate           DATE NULL
	, WorkExperience2EndDate             DATE NULL
	, WorkExperience2Pay                 NVARCHAR (50) NULL
	, WorkExperience2LeavingReasons      NVARCHAR (100) NULL
	, WorkExperience3CompanyName         NVARCHAR (500) NULL
	, WorkExperience3Job                 NVARCHAR (500) NULL
	, WorkExperience3StartDate           DATE NULL
	, WorkExperience3EndDate             DATE NULL
	, WorkExperience3Pay                 NVARCHAR (50) NULL
	, WorkExperience3LeavingReasons      NVARCHAR (100) NULL
	, WorkExperience4CompanyName         NVARCHAR (500) NULL
	, WorkExperience4Job                 NVARCHAR (500) NULL
	, WorkExperience4StartDate           DATE NULL
	, WorkExperience4EndDate             DATE NULL
	, WorkExperience4Pay                 NVARCHAR (50) NULL
	, WorkExperience4LeavingReasons      NVARCHAR (100) NULL
	, JobId                              UNIQUEIDENTIFIER NULL
	, Title                              NVARCHAR (50) NULL
	, Organization_Id                    UNIQUEIDENTIFIER NULL
	, SupervisorComments                 NVARCHAR (500) NULL
	, ProbationarySalary                 NVARCHAR (50) NULL
	, CorrectSalary                      NVARCHAR (50) NULL
	, WorkNumber                         NVARCHAR (50) NULL
	, EntryDate                          DATE NULL
	, BirthCertificatePhoto              NVARCHAR (200) NULL
	, RegistrationPhoto                  NVARCHAR (200) NULL
	, BankCardNumber                     NVARCHAR (200) NULL
	, CreateStaffeId                     UNIQUEIDENTIFIER NULL
	, CreateTime                         DATETIME NULL
	, UpdateTime                         DATETIME NULL
	, No                                 VARCHAR (50) NULL
	, StaffNo                            NVARCHAR (100) NULL
	, IsDel                              BIT DEFAULT ((0)) NOT NULL
	, PRIMARY KEY (Id)
	)
GO

CREATE TABLE dbo.Job
	(
	  Id         UNIQUEIDENTIFIER NOT NULL
	, Name       NVARCHAR (100) NULL
	, Code       NVARCHAR (100) NULL
	, UpdateTime DATETIME NULL
	, CreateTime DATETIME NULL
	, IsDel      BIT NULL
	, PRIMARY KEY (Id)
	)
GO

CREATE TABLE dbo.LeaveOffice
	(
	  Id                  UNIQUEIDENTIFIER NOT NULL
	, No                  NVARCHAR (100) NULL
	, StaffName           NVARCHAR (100) NULL
	, JobId               UNIQUEIDENTIFIER NOT NULL
	, LeaveType           CHAR (1) NULL
	, ApplyDate           DATE NULL
	, Reason              NVARCHAR (500) NULL
	, ExplanationHandover NVARCHAR (500) NULL
	, HandoverSatffId     UNIQUEIDENTIFIER NULL
	, ApplyPersonId       UNIQUEIDENTIFIER NULL
	, CreateTime          DATETIME NULL
	, UpdateTime          DATETIME NULL
	, IsDel               BIT NULL
	, PRIMARY KEY (Id)
	)
GO

CREATE TABLE dbo.OilMaterialOrder
	(
	  Id            UNIQUEIDENTIFIER NOT NULL
	, No            NVARCHAR (100) NOT NULL
	, ApplyPersonId UNIQUEIDENTIFIER NOT NULL
	, ApplyDate     DATE NULL
	, Remark        NVARCHAR (500) NULL
	, IsDel         BIT DEFAULT ((0)) NOT NULL
	, CreateTime    DATETIME NULL
	, UpdateTime    DATETIME NULL
	, PRIMARY KEY (Id)
	)
GO

CREATE TABLE dbo.OilMaterialOrderDetail
	(
	  Id         UNIQUEIDENTIFIER NOT NULL
	, OrderId    UNIQUEIDENTIFIER NOT NULL
	, OilSpec    NVARCHAR (100) NULL
	, Volume     DECIMAL (18, 2) NULL
	, Surplus    DECIMAL (18, 2) NULL
	, DayAvg     DECIMAL (18, 2) NULL
	, NeedAmount DECIMAL (18, 2) NULL
	, CreateTime DATETIME NULL
	, UpdateTime DATETIME NULL
	, IsDel      BIT NULL
	, PRIMARY KEY (Id)
	, CONSTRAINT FK__OilMateri__Order__31EC6D26 FOREIGN KEY (OrderId) REFERENCES dbo.OilMaterialOrder (Id)
	)
GO

CREATE TABLE dbo.OrganizationStructure
	(
	  Id         UNIQUEIDENTIFIER NOT NULL
	, Code       NVARCHAR (100) NOT NULL
	, Name       NVARCHAR (100) NOT NULL
	, Leve       INT NOT NULL
	, ParentId   UNIQUEIDENTIFIER NULL
	, CreateTime DATETIME NULL
	, UpdateTime DATETIME NULL
	, IsDel      BIT DEFAULT ((0)) NOT NULL
	, PRIMARY KEY (Id)
	)
GO

CREATE TABLE dbo.ProcessItem
	(
	  Id        UNIQUEIDENTIFIER NOT NULL
	, Code      VARCHAR (100) NOT NULL
	, Discrible NVARCHAR (100) NULL
	, PRIMARY KEY (Id)
	)
GO

CREATE TABLE dbo.ProcessStepRecord
	(
	  Id                      UNIQUEIDENTIFIER NOT NULL
	, Type                    VARCHAR (50) NOT NULL
	, RecordRemarks           NVARCHAR (500) NULL
	, StepOrder               INT NOT NULL
	, WaitForExecutionStaffId UNIQUEIDENTIFIER NOT NULL
	, CreateTime              DATETIME NOT NULL
	, UpdateTime              DATETIME NOT NULL
	, WhetherToExecute        BIT NOT NULL
	, No                      NVARCHAR (50) NOT NULL
	, RefOrderId              UNIQUEIDENTIFIER NOT NULL
	, Result                  BIT DEFAULT ((0)) NOT NULL
	, ExecuteMethod           NVARCHAR (4000) NULL
	, Discrible               NVARCHAR (400) NULL
	)
GO

CREATE TABLE dbo.Role
	(
	  Id   UNIQUEIDENTIFIER NOT NULL
	, Name NVARCHAR (500) NOT NULL
	, Code NVARCHAR (500) NOT NULL
	, PRIMARY KEY (Id)
	)
GO

CREATE TABLE dbo.RoleResourceModule
	(
	  RoleId           UNIQUEIDENTIFIER NOT NULL
	, ResourceModuleId UNIQUEIDENTIFIER NOT NULL
	)
GO

CREATE TABLE dbo.Staff
	(
	  Id          UNIQUEIDENTIFIER NOT NULL
	, No          NVARCHAR (500) NULL
	, Name        NVARCHAR (500) NULL
	, Sex         BIT NULL
	, BirthDay    DATE NULL
	, NativePlace NVARCHAR (500) NULL
	, Address     NVARCHAR (500) NULL
	, Password    NVARCHAR (1000) NULL
	, Email       NVARCHAR (50) NULL
	, Tel         NVARCHAR (20) NULL
	, Status      CHAR (1) NULL
	, CreateTime  DATETIME NULL
	, UpdateTime  DATETIME NULL
	, JobId       UNIQUEIDENTIFIER NULL
	, OrgID       UNIQUEIDENTIFIER NULL
	, IsHSEGroup  BIT DEFAULT ((0)) NULL
	, PRIMARY KEY (Id)
	)
GO

CREATE TABLE dbo.StaffRole
	(
	  StaffId UNIQUEIDENTIFIER NOT NULL
	, RoleId  UNIQUEIDENTIFIER NOT NULL
	)
GO

CREATE TABLE dbo.SystemResourceModule
	(
	  Id       UNIQUEIDENTIFIER NOT NULL
	, Name     NVARCHAR (500) NULL
	, Code     NVARCHAR (500) NOT NULL
	, Url      NVARCHAR (1000) NULL
	, Type     INT DEFAULT ((0)) NOT NULL
	, ParentId UNIQUEIDENTIFIER NULL
	, OrderNo  INT NULL
	, PRIMARY KEY (Id)
	)
GO

CREATE PROCEDURE [dbo].[P_Pager] (
    @recordTotal INT OUTPUT,            --输出记录总数
    @viewName NVARCHAR(Max),        --表名
    @fieldName VARCHAR(800) = '*',        --查询字段
    @keyName VARCHAR(200) = 'Id',            --索引字段
    @pageSize INT = 10,                    --每页记录数
    @pageNo INT =1,                    --当前页
    @orderString VARCHAR(200),        --排序条件
    @whereString NVARCHAR(Max) = '1=1'        --WHERE条件
)
AS
BEGIN
     DECLARE @beginRow INT
     DECLARE @endRow INT
     DECLARE @tempLimit VARCHAR(200)
     DECLARE @tempCount NVARCHAR(1000)
     DECLARE @tempMain VARCHAR(1000)
     --declare @timediff datetime 
     
     set nocount on
     --select @timediff=getdate() --记录时间

     SET @beginRow = (@pageNo - 1) * @pageSize    + 1
     SET @endRow = @pageNo * @pageSize
     SET @tempLimit = 'rows BETWEEN ' + CAST(@beginRow AS VARCHAR) +' AND '+CAST(@endRow AS VARCHAR)
     
     --输出参数为总记录数
     SET @tempCount = 'SELECT @recordTotal = COUNT(*) FROM (SELECT '+@keyName+' FROM '+@viewName+' WHERE '+@whereString+') AS my_temp'
     EXECUTE sp_executesql @tempCount,N'@recordTotal INT OUTPUT',@recordTotal OUTPUT
       
     --主查询返回结果集
     SET @tempMain = 'SELECT * FROM (SELECT ROW_NUMBER() OVER (order by '+@orderString+') AS rows ,'+@fieldName+' FROM '+@viewName+' WHERE '+@whereString+') AS main_temp WHERE '+@tempLimit
     
     --PRINT @tempMain
     EXECUTE (@tempMain)
     --select datediff(ms,@timediff,getdate()) as 耗时 
     
     set nocount off
END

GO
--菜单导航信息视图
CREATE view v_staffmune
AS
(
SELECT DISTINCT t1.*,t4.Id AS staffid FROM SystemResourceModule t1,RoleResourceModule t2,StaffRole t3, Staff t4
WHERE t1.Id = t2.ResourceModuleId 
AND t2.RoleId = t3.RoleId
AND t4.Id = t3.StaffId
)
--父级菜单
SELECT  * FROM v_staffmune 
WHERE staffid='41C63B02-CB0A-4ECF-AE3E-04C2EE7F4C38' 
AND Type = 0 AND ParentId IS NULL
--子级菜单
SELECT * FROM v_staffmune 
WHERE staffid='41C63B02-CB0A-4ECF-AE3E-04C2EE7F4C38' 
AND ParentId ='0D800549-97A7-41DB-8454-6D4A063A4279'

/*
 select [SystemResourceModule].*, Staff.ID from [dbo].[SystemResourceModule] 
 inner join RoleResourceModule on [SystemResourceModule].Id=RoleResourceModule.ResourceModuleId													
 inner join StaffRole on RoleResourceModule.RoleId=StaffRole.RoleId													
inner join Staff on StaffRole.StaffId=Staff.Id  
where Staff.ID='41C63B02-CB0A-4ECF-AE3E-04C2EE7F4C38' 
AND type = 	0	AND ParentId IS null	 		
*/		


SELECT url FROM v_staffmune  WHERE Url IS NOT null


--DELETE Job WHERE code = '21'

/*
DECLARE @recordTotal INT
EXECUTE dbo.P_Pager @recordTotal OUT, NULL, NULL, NULL, NULL, NULL, NULL, NULL
SELECT "@recordTotal" = @recordTotal
*/
--组织结构视图
IF EXISTS (SELECT * FROM sys.objects where name = 'v_Organization')
DROP VIEW v_OrganizationUPDATE dbo.OrganizationStructure
SET Id = '497336F6-8CF6-4FFA-8380-0D79D56BE9CF'
WHERE Id = '497336F6-8CF6-4FFA-8380-0D79D56BE9CF'
GO


go
CREATE VIEW v_Organization
AS
(
SELECT t1.*,t2.Name AS ParentName,t2.Code ParentCode FROM OrganizationStructure t1 LEFT JOIN OrganizationStructure t2
ON t1.ParentId = t2.Id  where t1.IsDel = 0
)
GO
/*
DELETE dbo.OrganizationStructure
WHERE Id = '00000000-0000-0000-0000-000000000000'
GO
*/

/*
UPDATE dbo.OrganizationStructure
SET IsDel = 0
--WHERE Id = '7CC0B7E5-6356-4E93-895D-4795276B7961'
GO
*/
IF EXISTS (SELECT * FROM sys.objects where name = 'v_staffinfo')
DROP VIEW v_staffinfo
go
CREATE VIEW v_staffinfo
AS
(
SELECT t1.* ,t2.Name AS JobName ,t3.Name AS OrjName FROM Staff t1 
left JOIN job t2 ON t1.JobId = t2.Id
LEFT JOIN OrganizationStructure t3 ON t1.OrgID = t3.Id
)
go

//存储过程调用
/*
DECLARE @recordTotal INT
EXECUTE dbo.P_Pager @recordTotal OUT , 'Staff', '*', 'id', 10, 1, 'no asc', '1=1'
SELECT "@recordTotal" = @recordTotal

DECLARE @recordTotal INT
EXECUTE dbo.P_Pager @recordTotal OUT, 'Job', '*', 'Id', 10, 1, 'id desc', '1=1'
SELECT "@recordTotal" = @recordTotal
*/

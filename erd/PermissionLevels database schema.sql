

CREATE TABLE Groups(
GroupID int identity(1,1) NOT NULL CONSTRAINT PK_Groups1 PRIMARY KEY,
GroupName varchar(350) NULL)
go


CREATE TABLE Companies(
CompanyID int identity(1,1) NOT NULL CONSTRAINT PK_Companies1 PRIMARY KEY,
CompanyName varchar(350) NULL)
go


CREATE TABLE Users(
UserID int identity(1,1) NOT NULL CONSTRAINT PK_Users1 PRIMARY KEY,
CompanyID int NULL,
GroupID int NULL,
FirstName varchar(200) NULL,
LastName varchar(200) NULL)
go


CREATE TABLE PermissionTypes(
PermissionTypeID int identity(1,1) NOT NULL CONSTRAINT PK_PermissionTypes1 PRIMARY KEY,
Description varchar(350) NULL)
go


CREATE TABLE Modules(
ModuleID int identity(1,1) NOT NULL CONSTRAINT PK_Modules1 PRIMARY KEY,
ModuleName varchar(350) NULL)
go


CREATE TABLE Applications(
ApplicationID int identity(1,1) NOT NULL CONSTRAINT PK_Applications1 PRIMARY KEY,
ModuleID int NOT NULL,
ApplicationName varchar(350) NULL)
go


CREATE TABLE ApplicationPermissionTypes(
ApplicationPermissionTypeID int identity(1,1) NOT NULL CONSTRAINT PK_ApplicationPermissionTypes1 PRIMARY KEY,
ApplicationID int NOT NULL,
PermissionTypeID int NOT NULL)
go


CREATE TABLE ApplicationPermissionTypeDetails(
ApplicationPermissionTypeDetailID int identity(1,1) NOT NULL CONSTRAINT PK_ApplicationPermissionTypeDetails1 PRIMARY KEY,
ApplicationPermissionTypeID int NOT NULL,
CompanyIDGroupIDUserID int NULL)
go






ALTER TABLE Users
ADD CONSTRAINT FK_Users_1 
FOREIGN KEY (CompanyID) REFERENCES Companies (CompanyID)
go

ALTER TABLE Users
ADD CONSTRAINT FK_Users_2 
FOREIGN KEY (GroupID) REFERENCES Groups (GroupID)
go




ALTER TABLE Applications
ADD CONSTRAINT FK_Applications_1 
FOREIGN KEY (ModuleID) REFERENCES Modules (ModuleID)
go


ALTER TABLE ApplicationPermissionTypes
ADD CONSTRAINT FK_ApplicationPermissionTypes_1 
FOREIGN KEY (ApplicationID) REFERENCES Applications (ApplicationID)
go

ALTER TABLE ApplicationPermissionTypes
ADD CONSTRAINT FK_ApplicationPermissionTypes_2 
FOREIGN KEY (PermissionTypeID) REFERENCES PermissionTypes (PermissionTypeID)
go


ALTER TABLE ApplicationPermissionTypeDetails
ADD CONSTRAINT FK_ApplicationPermissionTypeDetails_1 
FOREIGN KEY (ApplicationPermissionTypeID) REFERENCES ApplicationPermissionTypes (ApplicationPermissionTypeID)
go


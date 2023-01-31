INSERT INTO Groups(GroupName) VALUES('Front-End Group')	
INSERT INTO Groups(GroupName) VALUES('Back-End Group')	


INSERT INTO Companies(CompanyName) VALUES('CompanyA')	
INSERT INTO Companies(CompanyName) VALUES('CompanyB')	
INSERT INTO Companies(CompanyName) VALUES('CompanyC')


INSERT INTO Users(
	CompanyID,
	GroupID,
	FirstName,
	LastName		
)
VALUES(
	(SELECT TOP 1 CompanyID FROM Companies WHERE CompanyName = 'CompanyA'),
	(SELECT TOP 1 GroupID FROM Groups WHERE GroupName = 'Front-End Group'),
	'Izuku',
	'Midoriya'
)	


INSERT INTO PermissionTypes(Description) VALUES('Global')
INSERT INTO PermissionTypes(Description) VALUES('Company')
INSERT INTO PermissionTypes(Description) VALUES('Group')
INSERT INTO PermissionTypes(Description) VALUES('User')
INSERT INTO PermissionTypes(Description) VALUES('NoAccess')


INSERT INTO Modules(ModuleName) VALUES('Application')	
INSERT INTO Modules(ModuleName) VALUES('Knowledgebase')	


INSERT INTO Applications(ModuleID, ApplicationName)
VALUES(
	(SELECT TOP 1 ModuleID FROM Modules WHERE ModuleName = 'Application'),
	'ApplicationA'
)

INSERT INTO Applications(ModuleID, ApplicationName)
VALUES(
	(SELECT TOP 1 ModuleID FROM Modules WHERE ModuleName = 'Application'),
	'ApplicationB'
)

INSERT INTO Applications(ModuleID, ApplicationName)
VALUES(
	(SELECT TOP 1 ModuleID FROM Modules WHERE ModuleName = 'Application'),
	'ApplicationC'
)

INSERT INTO Applications(ModuleID, ApplicationName)
VALUES(
	(SELECT TOP 1 ModuleID FROM Modules WHERE ModuleName = 'Application'),
	'ApplicationD'
)




--- sample company
INSERT INTO ApplicationPermissionTypes(ApplicationID, PermissionTypeID)
VALUES(
	(SELECT TOP 1 ApplicationID FROM Applications WHERE ApplicationName = 'ApplicationA'),
	(SELECT TOP 1 PermissionTypeID FROM PermissionTypes WHERE Description = 'Company')
)

INSERT INTO ApplicationPermissionTypeDetails(ApplicationPermissionTypeID, CompanyIDGroupIDUserID)
VALUES(
	(SELECT TOP 1 ApplicationPermissionTypeID 
	FROM ApplicationPermissionTypes 
	WHERE 
		ApplicationID = (SELECT TOP 1 ApplicationID FROM Applications WHERE ApplicationName = 'ApplicationA')
		AND PermissionTypeID = (SELECT TOP 1 PermissionTypeID FROM PermissionTypes WHERE Description = 'Company')
	),	
	(SELECT TOP 1 CompanyID FROM Companies WHERE CompanyName = 'CompanyA')
)



--- global
INSERT INTO ApplicationPermissionTypes(ApplicationID, PermissionTypeID)
VALUES(
	(SELECT TOP 1 ApplicationID FROM Applications WHERE ApplicationName = 'ApplicationB'),
	(SELECT TOP 1 PermissionTypeID FROM PermissionTypes WHERE Description = 'Global')
)


--- group
INSERT INTO ApplicationPermissionTypes(ApplicationID, PermissionTypeID)
VALUES(
	(SELECT TOP 1 ApplicationID FROM Applications WHERE ApplicationName = 'ApplicationC'),
	(SELECT TOP 1 PermissionTypeID FROM PermissionTypes WHERE Description = 'Group')
)

INSERT INTO ApplicationPermissionTypeDetails(ApplicationPermissionTypeID, CompanyIDGroupIDUserID)
VALUES(
	(SELECT TOP 1 ApplicationPermissionTypeID 
	FROM ApplicationPermissionTypes 
	WHERE 
		ApplicationID = (SELECT TOP 1 ApplicationID FROM Applications WHERE ApplicationName = 'ApplicationC')
		AND PermissionTypeID = (SELECT TOP 1 PermissionTypeID FROM PermissionTypes WHERE Description = 'Group')
	),	
	(SELECT TOP 1 GroupID FROM Groups WHERE GroupName = 'Back-End Group')
)


--- user
INSERT INTO ApplicationPermissionTypes(ApplicationID, PermissionTypeID)
VALUES(
	(SELECT TOP 1 ApplicationID FROM Applications WHERE ApplicationName = 'ApplicationD'),
	(SELECT TOP 1 PermissionTypeID FROM PermissionTypes WHERE Description = 'User')
)

INSERT INTO ApplicationPermissionTypeDetails(ApplicationPermissionTypeID, CompanyIDGroupIDUserID)
VALUES(
	(SELECT TOP 1 ApplicationPermissionTypeID 
	FROM ApplicationPermissionTypes 
	WHERE 
		ApplicationID = (SELECT TOP 1 ApplicationID FROM Applications WHERE ApplicationName = 'ApplicationD')
		AND PermissionTypeID = (SELECT TOP 1 PermissionTypeID FROM PermissionTypes WHERE Description = 'User')
	),	
	(SELECT TOP 1 UserID FROM Users WHERE FirstName = 'Izuku')
)
----- Groups start here -----
GO
CREATE PROCEDURE Groups_Create	
	@groupID int,
	@groupName varchar(350)
AS
BEGIN
	INSERT INTO Groups(
		GroupName
	)
	VALUES(
		@groupName
	)	

	SET @groupID = SCOPE_IDENTITY()
END
GO



GO
CREATE PROCEDURE Groups_RetrieveAll
AS
BEGIN
	SELECT * FROM Groups
END
GO



GO
CREATE PROCEDURE Groups_RetrieveInfo
	@groupID	INT
AS
BEGIN
	SELECT * FROM Groups WHERE GroupID = @groupID
END
GO




GO
CREATE PROCEDURE Groups_Update
	@groupID int,
	@groupName varchar(350)
AS
BEGIN
	UPDATE Groups SET
		GroupName = @groupName
	WHERE
		GroupID = @groupID
END
GO


GO
CREATE PROCEDURE Groups_Delete
	@groupID	INT
AS
BEGIN
	DELETE
	FROM Groups
	WHERE	
		GroupID = @groupID
END
GO
----- Groups end here -----











----- Companies start here -----
GO
CREATE PROCEDURE Companies_Create	
	@companyID int,
	@companyName varchar(350)	
AS
BEGIN
	INSERT INTO Companies(
		CompanyName
	)
	VALUES(
		@companyName
	)	

	SET @companyID = SCOPE_IDENTITY()
END
GO



GO
CREATE PROCEDURE Companies_RetrieveAll
AS
BEGIN
	SELECT * FROM Companies
END
GO



GO
CREATE PROCEDURE Companies_RetrieveInfo
	@companyID	INT
AS
BEGIN
	SELECT * FROM Companies WHERE CompanyID = @companyID
END
GO




GO
CREATE PROCEDURE Companies_Update
	@companyID int,
	@companyName varchar(350)	
AS
BEGIN
	UPDATE Companies SET
		CompanyName = @companyName
	WHERE
		CompanyID = @companyID
END
GO


GO
CREATE PROCEDURE Companies_Delete
	@companyID	INT
AS
BEGIN
	DELETE
	FROM Companies
	WHERE	
		CompanyID = @companyID
END
GO
----- Companies end here -----












----- Users start here -----

GO
CREATE PROCEDURE Users_Create		
	@userID int,
	@companyID int,
	@groupID int,
	@firstName varchar(200),
	@lastName varchar(200)	
AS
BEGIN
	INSERT INTO Users(
		CompanyID,
		GroupID,
		FirstName,
		LastName		
	)
	VALUES(
		@companyID,
		@groupID,
		@firstName,
		@lastName
	)	

	SET @userID = SCOPE_IDENTITY()
END
GO



GO
CREATE PROCEDURE Users_RetrieveAll
AS
BEGIN
	SELECT 
		u.*,
		c.CompanyName,
		g.GroupName
	FROM Users u
	LEFT JOIN Companies c ON c.CompanyID = u.CompanyID
	LEFT JOIN Groups g ON g.GroupID = u.GroupID
END
GO



GO
CREATE PROCEDURE Users_RetrieveInfo
	@userID	INT
AS
BEGIN
	SELECT * FROM Users WHERE UserID = @userID
END
GO




GO
CREATE PROCEDURE Users_Update
	@userID int,
	@companyID int,
	@groupID int,
	@firstName varchar(200),
	@lastName varchar(200)	
AS
BEGIN
	UPDATE Users SET
		CompanyID = @companyID,
		GroupID = @groupID,
		FirstName = @firstName,
		LastName = @lastName
	WHERE
		UserID = @userID
END
GO


GO
CREATE PROCEDURE Users_Delete
	@userID	INT
AS
BEGIN
	DELETE
	FROM Users
	WHERE
		UserID = @userID
END
GO

----- Users end here -----









----- Permission Types start here -----

GO
CREATE PROCEDURE PermissionTypes_RetrieveAll
AS
BEGIN
	SELECT * FROM PermissionTypes
END
GO

----- Permission Types end here -----




----- Modules start here -----

GO
CREATE PROCEDURE Modules_RetrieveAll
AS
BEGIN
	SELECT * FROM Modules
END
GO

----- Modules end here -----




----- Applications start here -----

GO
CREATE PROCEDURE Applications_RetrieveAll
AS
BEGIN
	SELECT 
		a.*,
		m.ModuleName
	FROM Applications a
	LEFT JOIN Modules m ON m.ModuleID = a.ModuleID
END
GO

----- Applications end here -----







----- ApplicationPermissionTypes start here -----

GO
CREATE PROCEDURE ApplicationPermissionTypes_RetrieveAll
AS
BEGIN
	SELECT 
		apt.*,
		a.ApplicationName,
		pt.Description AS PermissionType
	FROM ApplicationPermissionTypes apt
	LEFT JOIN Applications a ON a.ApplicationID = apt.ApplicationID
	LEFT JOIN PermissionTypes pt ON pt.PermissionTypeID = apt.PermissionTypeID
END
GO

----- ApplicationPermissionTypes end here -----






----- ApplicationPermissionTypeDetails start here -----

GO
CREATE PROCEDURE ApplicationPermissionTypeDetails_RetrieveAll
	@applicationPermissionTypeID	INT
AS
BEGIN
	SELECT 
		aptd.*,				
		a.ApplicationName,
		pt.Description AS PermissionType,
		CASE 
			WHEN pt.Description = 'Company' THEN (SELECT TOP 1 CompanyName FROM Companies WHERE CompanyID = aptd.CompanyIDGroupIDUserID)
			WHEN pt.Description = 'Group' THEN (SELECT TOP 1 GroupName FROM Groups WHERE GroupID = aptd.CompanyIDGroupIDUserID)
			WHEN pt.Description = 'User' THEN (SELECT TOP 1 FirstName + ' ' + LastName FROM Users WHERE UserID = aptd.CompanyIDGroupIDUserID)
			ELSE ''
		END AS CompanyNameOrGroupNameOrUserName
	FROM ApplicationPermissionTypeDetails aptd
	LEFT JOIN ApplicationPermissionTypes apt ON apt.ApplicationPermissionTypeID = aptd.ApplicationPermissionTypeID
	LEFT JOIN Applications a ON a.ApplicationID = apt.ApplicationID
	LEFT JOIN PermissionTypes pt ON pt.PermissionTypeID = apt.PermissionTypeID	
	WHERE 
		aptd.ApplicationPermissionTypeID = @applicationPermissionTypeID
END
GO

----- ApplicationPermissionTypeDetails end here -----
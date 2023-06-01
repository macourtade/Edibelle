USE [C:\PROJECTS\EDIBELLE\DB\EDIBELLE.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Employee_Insert]
		@FirstName = N'Jeff',
		@LastName = N'Simon',
		@Dept_ID = 5,
		@Username = N'jsimon',
		@Password = N'pass',
		@isActive = 1,
		@isAdmin = 0

SELECT	@return_value as 'Return Value'

GO

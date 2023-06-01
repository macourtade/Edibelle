USE [C:\PROJECTS\EDIBELLE\DB\EDIBELLE.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Employee_Insert]
		@FirstName = N'Bill',
		@LastName = N'Tyler',
		@Dept_ID = 16,
		@Username = N'',
		@Password = N'',
		@isActive = 1,
		@isAdmin = 0

SELECT	@return_value as 'Return Value'

GO

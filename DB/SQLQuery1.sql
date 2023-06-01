USE [C:\PROJECTS\EDIBELLE\DB\EDIBELLE.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Department_Insert]
		@Dept_Name = N'New Dept'

SELECT	@return_value as 'Return Value'

GO

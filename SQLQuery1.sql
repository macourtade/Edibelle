USE [C:\PROJECTS\EDIBELLE\DB\EDIBELLE.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Department_UPDATE]
		@Dept_ID = 9,
		@Dept_Name = N'Poultry'

SELECT	@return_value as 'Return Value'

GO

CREATE PROCEDURE [dbo].[Location_Insert]
	@LocID int,
	@LocName nchar(10),
	@LocDesc nvarchar(50)

	AS 

	INSERT INTO Location (Loc_ID, Loc_Name, Loc_Desc)
	VALUES (@LocID,@LocName,@LocDesc);
	Return Location
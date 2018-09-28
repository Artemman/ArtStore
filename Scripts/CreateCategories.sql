USE ArtStore;

CREATE TABLE Categories
( Id INT IDENTITY,
  Name NVARCHAR(50)
  CONSTRAINT PK_Category_Id PRIMARY KEY(Id),
  CONSTRAINT CK_Category_Name CHECK(Name!=''));

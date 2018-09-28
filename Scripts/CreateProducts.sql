USE ArtStore;

CREATE TABLE Products
( Id INT IDENTITY,
  Name NVARCHAR(30) NOT NULL,
  Description NVARCHAR(50) NULL,
  CategoryId INT NOT NULL,
  Price DECIMAL NOT NULL,
  Image VARBINARY(MAX) NULL,
  CONSTRAINT PK_Product_Id PRIMARY KEY(Id),
  CONSTRAINT RK_Products_Categories FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
  CONSTRAINT CK_Products_Name CHECK(Name!=''),
  CONSTRAINT CK_Products_Price CHECK(Price>0));

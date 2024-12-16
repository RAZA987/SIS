--create a database table in SQL Server:

CREATE TABLE Books (
    Bookno INT PRIMARY KEY IDENTITY(1,1),
    Bookname NVARCHAR(100),
    Authorname NVARCHAR(100),
    Price DECIMAL(10, 2)
);

-- Create Database BookStoreDB
USE BookStoreDB;

CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Country VARCHAR(20)
);

CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(50) NOT NULL,
    Price DECIMAL,
    PublishedYear DATE,
    AuthorID INT,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE NOT NULL,
    TotalAmount DECIMAL NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY,
    OrderID INT,
    BookID INT,
    Quantity INT,
    SubTotal DECIMAL NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);


-- Insert data into Authors table
INSERT INTO Authors (AuthorID, Name, Country) VALUES 
(7, 'Somnath Prajapati', 'India'),
(1, 'J.K. Rowling', 'United Kingdom'),
(2, 'George Orwell', 'United Kingdom'),
(3, 'Mark Twain', 'United States'),
(4, 'J.R.R. Tolkien', 'United Kingdom'),
(5, 'Jane Austen', 'United Kingdom'),
(6, 'Agatha Christie', 'United Kingdom');

-- Insert data into Books table
INSERT INTO Books (BookID, Title, Price, PublishedYear, AuthorID) VALUES
(1, 'Harry Potter and the Philosophers Stone', 20.99, '1997-06-26', 1),
(2, '1984', 15.99, '1949-06-08', 2),
(3, 'Animal Farm', 12.99, '1945-08-17', 2),
(4, 'The Adventures of Tom Sawyer', 10.99, '1876-06-17', 3),
(5, 'The Hobbit', 14.99, '1937-09-21', 4),
(6, 'Pride and Prejudice', 16.99, '1813-01-28', 5);

-- Insert data into Customers table
INSERT INTO Customers (CustomerID, Name, Email, PhoneNumber) VALUES 
(1, 'Alice Smith', 'alice.smith@example.com', '1234567890'),
(2, 'Bob Johnson', 'bob.johnson@example.com', '0987654321'),
(3, 'Charlie Brown', 'charlie.brown@example.com', '1122334455'),
(4, 'David Wilson', 'david.wilson@example.com', '2233445566'),
(5, 'Eva Green', 'eva.green@example.com', '3344556677'),
(6, 'Frank Miller', 'frank.miller@example.com', '4455667788');

-- Insert data into Orders table
INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount) VALUES 
(1, 1, '2025-03-01', 36.98),
(2, 2, '2025-03-02', 15.99),
(3, 3, '2025-03-03', 27.98),
(4, 4, '2025-03-04', 20.99),
(5, 5, '2025-03-05', 10.99),
(6, 6, '2025-03-06', 16.99);

-- Insert data into OrderItems table
INSERT INTO OrderItems (OrderItemID, OrderID, BookID, Quantity, SubTotal) VALUES 
(1, 1, 1, 1, 20.99),
(2, 1, 3, 1, 12.99),
(3, 2, 2, 1, 15.99),
(4, 3, 4, 1, 10.99),
(5, 3, 5, 1, 14.99),
(6, 4, 1, 1, 20.99);



update Books set Title='SQL Mastery' where Title='1984'

update Books set Price= Price*1.1 where Title='SQL Mastery'


select Customers.Name
from Customers left join Orders on Customers.CustomerID=Orders.CustomerID;

--delete subquery not exist used to dicreminate the data ndsubquery is used  to select the data
DELETE FROM  customers
WHERE NOT EXISTS (SELECT *
                         FROM   dbo.orders
                         WHERE  dbo.customers.customerid = 
                                dbo.orders.customerid)
select * from Customers;

INSERT INTO Customers (CustomerID, Name, Email, PhoneNumber) VALUES 
(7, 'Alice Dwyne', 'alice.smith@example.com', '1234567890')

--delete customer not placed any orders
delete from customers
where customerID not in (SELECT  customerID FROM dbo.Orders)


select * from orders

select * from Customers


select * from books where Books.Price > 15

print 'Hello world'

select count(books.BookID) from books

select * from books where year(PublishedYear) between 1975 and 2000


select Customers.Name from customers, Orders where Customers.CustomerID = Orders.CustomerID

select * from books where Title like '%_the_%'

SELECT MAX(Books.Price) AS Max_price FROM books;

select * from books where price= (SELECT MAX(price) FROM Books)

select * from Customers where Name like 'A%' or Name like '%J'

select Sum(TotalAmount) as Revenue from Orders

select * from Books
--joins

select a.name , b.title
from Books  b
left join Authors  a
on a.AuthorID = b.AuthorID

select *
from Customers  c
right join Orders  o
on c.CustomerID = o.CustomerID

select *
from Books b
right join OrderItems o
on b.BookID = o.BookID where b.BookID != o.BookID

select Books.Title, OrderItems.Quantity
from Books
join OrderItems
on Books.BookID = OrderItems.BookID


select *
from Customers c
left join Orders o
on o.CustomerID = c.CustomerID



select *
from Authors a
left join Books b
on a.AuthorID = b.AuthorID where b.AuthorID is null


--queries


--Find the customer(s) who placed the first order (earliest OrderDate).
SELECT Customers.Name, Customers.CustomerID 
FROM Customers 
WHERE CustomerID = (
    SELECT CustomerID 
    FROM Orders 
    ORDER BY OrderDate DESC 
    OFFSET 1 ROWS 
    FETCH NEXT 1 ROWS ONLY
);

--Find the customer(s) who placed the most orders. 
select * from Customers 
where CustomerID 
in (select Orders.CustomerID from Orders 
where Orders.OrderID = (select OrderItems.OrderID 
from OrderItems where 
quantity = (select max(quantity) from OrderItems)));





--Find customers who have not placed any orders 
select * from Customers where CustomerID not in  (select CustomerID from Orders)

--Retrieve all books cheaper than the most expensive book written by( any author based on your data) 
select * from Authors where AuthorId in (select authorId from books where price < (select max(price) from Books where AuthorID = (select authorId from Authors where name = 'Somnath Prajapati')) );
select*from Authors;
select * from Books;
--List all customers whose total spending is greater than the average spending of all customers 
select * from Customers where customerId in (select CustomerId from Orders where Orders.TotalAmount > (select avg(Orders.TotalAmount) from Orders))
 

 --Procedure

 CREATE PROCEDURE GetOrdersByCustomerID
  @CustomerID INT
AS
BEGIN
  SELECT * 
  FROM Orders
  WHERE CustomerID = @CustomerID;
END;

exec GetOrdersByCustomerID

CREATE PROCEDURE GetBooksByPriceRange
  @MinPrice DECIMAL(10, 2),
  @MaxPrice DECIMAL(10, 2)
AS
BEGIN
  SELECT * 
  FROM Books
  WHERE Price BETWEEN @MinPrice AND @MaxPrice;
END;

exec GetBooksByPriceRange;

--view 
CREATE VIEW [Available Books] 
AS
SELECT 
  BookID, 
  Title, 
  AuthorID, 
  Price, 
  PublishedYear
FROM 
  Books;



select * from [Available Books];

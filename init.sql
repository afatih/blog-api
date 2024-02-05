CREATE TABLE Blog
(
    BlogId INT AUTO_INCREMENT PRIMARY KEY,
    Title  NVARCHAR(255) NOT NULL
);

INSERT INTO Blog (Title) VALUES ('Sample Blog 1');
INSERT INTO Blog (Title) VALUES ('Sample Blog 2');
create table BlogDB.User
(
    UserId      int auto_increment
        primary key,
    FirstName   varchar(255) charset utf8mb3 not null,
    LastName    varchar(255) charset utf8mb3 not null,
    Email       varchar(255) charset utf8mb3 null,
    PhoneNumber varchar(255) charset utf8mb3 null
);


create table BlogDB.Blog
(
    BlogId      int auto_increment
        primary key,
    Title       varchar(255) charset utf8mb3  not null,
    Description varchar(5000) charset utf8mb3 not null,
    CreateDate  timestamp                     not null,
    UpdateDate  timestamp                     null,
    UserId      int                           not null,
    constraint Blog_User_UserId_fk
        foreign key (UserId) references BlogDB.User (UserId)
);


insert into User (FirstName, LastName, Email, PhoneNumber)
values
    ('Semanur','Çelebi','semanure38@gmail.com','0600000000'),
    ('Fatih','Küçük','ahmet.fatih.kucuk@gmail.com','0600000000');

insert into Blog (Title, Description, CreateDate, UpdateDate, UserId) 
values
    ('Title1','Desc1',NOW(),null,1),
    ('Title2','Desc2',NOW(),null,1),
    ('Title3','Desc3',NOW(),null,2);
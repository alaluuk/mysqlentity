# Entity Framework with MySQL Example

Entity framework is an **ORM** (Object Relational Mapper). ORM makes it possible to handle SQL-data trough objects.

In this examle the interesting files are 
<ol>
<li>Controllers/BookController</li>
<li>Controllers/UserController</li>
<li>Models/Entities/Book</li>
<li>Models/Entities/User</li>
<li>Models/MyDbContext</li>
</ol>

## User and Book Classes

In the database there is two tables User and Book. And the primary keys are 
<ul>
<li>id in User table</li>
<li>id_book in Book table</li>
</ul>
And because in Book table the primary key name is not **id**, we need to add these lines to the Book class 
<pre>
[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
[Column("id_book")]

public int Id { get; set; }
</pre>

## Program.cs

Note these lines in Program.cs
<pre>
builder.Services.AddDbContext<MyDbContext>(options =>
{
        var connectionString = System.Environment.GetEnvironmentVariable("DATABASE_URL");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
</pre>
And also these
<pre>
if (app.Environment.IsDevelopment()){
app.Use(async (contex, next)=>
{
    System.Environment.SetEnvironmentVariable("DATABASE_URL", "server=127.0.0.1;user id=netuser;password=netpass;port=3306;database=netdb;");

    Console.WriteLine(System.Environment.GetEnvironmentVariable("DATABASE_URL"));
    await next();
}
);
}
</pre>

## Database code

The database is created with below codes
<pre>
CREATE DATABASE netdb;
CREATE USER 'netuser'@'localhost' IDENTIFIED BY 'netpass';
GRANT ALL on netdb.* to 'netuser'@'localhost';

USE netdb;

CREATE TABLE user (
  id int primary key NOT NULL AUTO_INCREMENT,
  username varchar(45) DEFAULT NULL,
  password varchar(255) DEFAULT NULL,
  firstname varchar(45) DEFAULT NULL,
  lastname varchar(45) DEFAULT NULL,
  UNIQUE KEY username_UNIQUE (username)
) ENGINE=InnoDB;

INSERT INTO user (username,password,firstname,lastname) VALUES ('user01','pass1','Lisa','Smith');
INSERT INTO user (username,password,firstname,lastname) VALUES ('user02','pass2','Jim','Jones');
INSERT INTO user (username,password,firstname,lastname) VALUES ('user03','pass3','Ann','Daniels');


CREATE TABLE book(
id_book INT primary key auto_increment,
name VARCHAR(255),
author VARCHAR(255),
isbn VARCHAR(20)
);

INSERT INTO book(name,author,isbn) VALUES('PHP Basic','Bob Jones','123-456-789-111-x');
INSERT INTO book(name,author,isbn) VALUES('Statistics','Lisa Smith','222-333-444-555-y');
</pre>
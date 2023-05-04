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
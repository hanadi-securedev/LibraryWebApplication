Create database CityLibrary;
use CityLibrary

CREATE TABLE Branch (
    BranchID INT PRIMARY KEY ,
    Name VARCHAR(100) NOT NULL,
    City VARCHAR(100) NOT NULL,
    Street VARCHAR(200) NOT NULL,
);


CREATE TABLE Publisher (
    PublisherID INT PRIMARY KEY ,
    Name VARCHAR(200) NOT NULL UNIQUE
);


CREATE TABLE Author (
    AuthorID INT PRIMARY KEY ,
    Name VARCHAR(200) NOT NULL,
    Nationality VARCHAR(100),
    NotableWorks TEXT
);


CREATE TABLE Book (
    ISBN VARCHAR(20) PRIMARY KEY,
    Title VARCHAR(300) NOT NULL,
    Author VARCHAR(300),
    PublicationYear INT,
    AvailabilityStatus  TEXT,
    PublisherID INT,
    AuthorID INT,
    BranchID INT,
    FOREIGN KEY (PublisherID) REFERENCES Publisher(PublisherID) ,
    FOREIGN KEY (AuthorID) REFERENCES Author(AuthorID) ,
    FOREIGN KEY (BranchID) REFERENCES Branch(BranchID) ,
  
);
CREATE TABLE Genre (
    
    ISBN VARCHAR (20) ,
    NonFiction TEXT ,
    ScienceFiction TEXT,
    Romance TEXT,
    Mystery TEXT,
    Fiction TEXT ,

   FOREIGN KEY (ISBN) REFERENCES Book(ISBN),

);


CREATE TABLE Memmber (
    MembershipID INT PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    City NVARCHAR(100),
    Street NVARCHAR(200),
    MembershipStatus NVARCHAR(20) DEFAULT 'Student'
        CHECK (MembershipStatus IN ('Student', 'Researcher', 'Reader')),
    INDEX idx_member_status (MembershipStatus)
);



CREATE TABLE Staff (
    StaffID INT PRIMARY KEY ,
    Name VARCHAR(200) NOT NULL,
    Position VARCHAR(100),
    BranchID INT,   
    FOREIGN KEY (BranchID) REFERENCES Branch(BranchID),
    INDEX idx_staff_branch (BranchID)
);


CREATE TABLE Transacion (

    BorrowedBook VARCHAR(20),
    DueDate DATE NOT NULL,
    Fine DECIMAL(10, 2) DEFAULT 0.00,
    Penalties TEXT,
    ISBN VARCHAR(20),
    MembershipID INT,
   
    FOREIGN KEY (ISBN) REFERENCES Book(ISBN),
    FOREIGN KEY (MembershipID) REFERENCES Memmber(MembershipID) ,
 
);


CREATE TABLE Contact (
    ContactID INT PRIMARY KEY ,
    PhoneNumber VARCHAR(20),
    PublisherID INT,
    BranchID INT,
    StaffID INT,
    MembershipID INT,
    FOREIGN KEY (PublisherID) REFERENCES Publisher(PublisherID) ON DELETE CASCADE,
    FOREIGN KEY (BranchID) REFERENCES Branch(BranchID) ON DELETE CASCADE,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID) ON DELETE CASCADE,
    FOREIGN KEY (MembershipID) REFERENCES Memmber(MembershipID) ON DELETE CASCADE
);

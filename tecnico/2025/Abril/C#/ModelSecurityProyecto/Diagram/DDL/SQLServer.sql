CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Description VARCHAR(255) NOT NULL,
    IsDeleted BIT NOT NULL
);

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    IsDeleted BIT NOT NULL,
    ActivationCode VARCHAR(100) NOT NULL,
    PersonId_Id INT NOT NULL,
    FOREIGN KEY (PersonId_Id) REFERENCES People(Id)
);

CREATE TABLE People (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    SecondLastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    DocumentNumber VARCHAR(20) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Address VARCHAR(255) NOT NULL,
    DocumenType VARCHAR(20) NOT NULL,
    BlodType VARCHAR(10) NOT NULL,
    Photo VARCHAR(255) NOT NULL,
    IsDeleted VARCHAR(20) NOT NULL,
    CityId_Id INT NOT NULL,
    AssignmentId_Id INT NOT NULL,
    FOREIGN KEY (CityId_Id) REFERENCES Citys(Id),
    FOREIGN KEY (AssignmentId_Id) REFERENCES Assignments(Id)
);

CREATE TABLE Citys (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    IsDeleted VARCHAR(20) NOT NULL,
    DepartmentId_Id INT NOT NULL,
    FOREIGN KEY (DepartmentId_Id) REFERENCES Departments(Id)
);

CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    IsDeleted VARCHAR(20) NOT NULL
);

CREATE TABLE Assignments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    IsDeleted BIT NOT NULL,
    DivisionId_Id INT NOT NULL,
    FOREIGN KEY (DivisionId_Id) REFERENCES OrganizationDivisions(Id)
);

CREATE TABLE OrganizationDivisions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    IsDeleted BIT NOT NULL
);

CREATE TABLE UserRoles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IsDeleted BIT NOT NULL,
    RoleId_Id INT NOT NULL,
    UserId_Id INT NOT NULL,
    FOREIGN KEY (RoleId_Id) REFERENCES Roles(Id),
    FOREIGN KEY (UserId_Id) REFERENCES Users(Id)
);

CREATE TABLE RoleFormPermissioSet (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IsDeleted BIT NOT NULL,
    RoleId_Id INT NOT NULL,
    PermissionId_Id INT NOT NULL,
    FormId_Id INT NOT NULL,
    FOREIGN KEY (RoleId_Id) REFERENCES Roles(Id),
    FOREIGN KEY (PermissionId_Id) REFERENCES Permits(Id),
    FOREIGN KEY (FormId_Id) REFERENCES Forms(Id)
);

CREATE TABLE Forms (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255) NOT NULL,
    IsDeleted BIT NOT NULL
);

CREATE TABLE Permits (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    IsDeleted BIT NOT NULL
);

CREATE TABLE FormsModules (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IsDeleted BIT NOT NULL,
    Form_Id INT NOT NULL,
    Module_Id INT NOT NULL,
    FOREIGN KEY (Form_Id) REFERENCES Forms(Id),
    FOREIGN KEY (Module_Id) REFERENCES Models(Id)
);

CREATE TABLE Models (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255) NOT NULL,
    IsDeleted VARCHAR(20) NOT NULL
);

CREATE TABLE Cards (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    QR VARCHAR(255) NOT NULL,
    IsDeleted BIT NOT NULL,
    ExpirationDate DATETIME NOT NULL,
    CreationDate DATETIME NOT NULL,
    AttendanceId INT NOT NULL,
    PersonId_Id INT NOT NULL,
    FOREIGN KEY (PersonId_Id) REFERENCES People(Id)
);

CREATE TABLE Organizations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Address VARCHAR(255) NOT NULL,
    IsDeleted BIT NOT NULL
);

CREATE TABLE Branchs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    location VARCHAR(255) NOT NULL,
    OrganizationId INT NOT NULL,
    IsDeleted BIT NOT NULL,
    FOREIGN KEY (OrganizationId) REFERENCES Organizations(Id)
);

CREATE TABLE DivisionsBranchs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IsDeleted BIT NOT NULL,
    DivisionId_Id INT NOT NULL,
    BranchId_Id INT NOT NULL,
    FOREIGN KEY (DivisionId_Id) REFERENCES OrganizationDivisions(Id),
    FOREIGN KEY (BranchId_Id) REFERENCES Branchs(Id)
);

CREATE TABLE Events (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Date DATETIME NOT NULL,
    Name VARCHAR(100) NOT NULL,
    IsDeleted BIT NOT NULL,
    EventTypeId_Id INT NOT NULL,
    FOREIGN KEY (EventTypeId_Id) REFERENCES EventsTypes(Id)
);

CREATE TABLE EventsTypes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    IsDeleted BIT NOT NULL
);

CREATE TABLE AccessPoints (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Type VARCHAR(50) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    IsDeleted BIT NOT NULL,
    EventId_Id INT NOT NULL,
    FOREIGN KEY (EventId_Id) REFERENCES Events(Id)
);

CREATE TABLE Attendances (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Hour DATETIME NOT NULL,
    TypeOfRecord VARCHAR(50) NOT NULL,
    IsDeleted BIT NOT NULL,
    AccessPointId_Id INT NOT NULL,
    FOREIGN KEY (AccessPointId_Id) REFERENCES AccessPoints(Id)
);

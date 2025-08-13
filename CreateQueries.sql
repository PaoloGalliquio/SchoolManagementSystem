-- Create the database
CREATE DATABASE SchoolManagementSystem;
GO

-- Use the newly created database
USE SchoolManagementSystem;
GO

-- Table where countries information will be stored
CREATE TABLE country (
    id INT IDENTITY(1,1) PRIMARY KEY,  -- Auto-incrementing primary key
    name NVARCHAR(100) NOT NULL,       -- Country name (unicode support)
    country_code CHAR(2) NOT NULL      -- 2-letter ISO country code
);

-- Table where school information will be stored
CREATE TABLE school (
    id INT IDENTITY(1,1) PRIMARY KEY,  -- Auto-incrementing primary key
    name NVARCHAR(100) NOT NULL,       -- School name (unicode support)
    id_country INT NOT NULL,            -- Reference to country
	CONSTRAINT FK_school_country FOREIGN KEY (id_country) REFERENCES country(id)
);

-- Table where student information will be stored
CREATE TABLE student (
    identity_card VARCHAR(20) PRIMARY KEY,  -- National ID or passport number
    names NVARCHAR(50) NOT NULL,           -- Student's first/given names
    surnames NVARCHAR(50) NOT NULL,        -- Student's last/family names
    date_of_birth DATETIME NOT NULL,           -- Student's birth date
    id_school INT NOT NULL,                -- School the student attends
    CONSTRAINT FK_student_school FOREIGN KEY (id_school) REFERENCES school(id)
);
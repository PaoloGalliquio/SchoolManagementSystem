USE SchoolManagementSystem;
GO

-- Insert sample countries
INSERT INTO country (name, country_code) VALUES
('United States', 'US'),
('United Kingdom', 'UK'),
('Canada', 'CA'),
('Australia', 'AU'),
('Germany', 'DE');

-- Insert sample schools
INSERT INTO school (name, id_country) VALUES
('Lincoln High School', 1),
('Cambridge Academy', 2),
('Toronto Prep School', 3),
('Sydney Grammar', 4),
('Berlin International School', 5);

-- Insert sample students
INSERT INTO student (identity_card, names, surnames, date_of_birth, id_school) VALUES
('US-1001', 'John', 'Smith', '2005-03-15', 1),
('US-1002', 'Emily', 'Johnson', '2006-07-22', 1),
('UK-2001', 'Oliver', 'Williams', '2004-11-30', 2),
('UK-2002', 'Sophia', 'Brown', '2005-09-18', 2),
('CA-3001', 'Liam', 'Tremblay', '2007-01-25', 3),
('CA-3002', 'Emma', 'Martin', '2006-04-12', 3),
('AU-4001', 'Noah', 'Wilson', '2005-08-05', 4),
('AU-4002', 'Ava', 'Taylor', '2006-12-19', 4),
('DE-5001', 'Luca', 'Schmidt', '2004-06-08', 5),
('DE-5002', 'Mia', 'Fischer', '2005-02-14', 5);
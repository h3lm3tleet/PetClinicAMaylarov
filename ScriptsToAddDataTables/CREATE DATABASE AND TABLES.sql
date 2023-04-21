IF OBJECT_ID(N'PetClinicVitakor', N'U') IS NULL
BEGIN
CREATE DATABASE PetClinicVitakor
USE PetClinicVitakor
END

IF OBJECT_ID(N'PetClinicVitakor.dbo.Owners', N'U') IS NULL
BEGIN
CREATE TABLE Owners (
    OwnerID INT PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL
);
END

IF OBJECT_ID(N'PetClinicVitakor.dbo.Animals', N'U') IS NULL
BEGIN
CREATE TABLE Animals (
    AnimalID INT PRIMARY KEY,
    AnimalName NVARCHAR(50) NOT NULL,
    Species NVARCHAR(50) NOT NULL,
    Breed NVARCHAR(50),
    OwnerID INT FOREIGN KEY REFERENCES Owners(OwnerID)
);
END

IF OBJECT_ID(N'PetClinicVitakor.dbo.Doctors', N'U') IS NULL
BEGIN
CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL
);
END

IF OBJECT_ID(N'PetClinicVitakor.dbo.ClinicServices', N'U') IS NULL
BEGIN
CREATE TABLE ClinicServices (
    ServiceID INT PRIMARY KEY,
    ServiceName NVARCHAR(50) NOT NULL,
    ServiceCost MONEY NOT NULL
);
END

IF OBJECT_ID(N'PetClinicVitakor.dbo.Vaccinations', N'U') IS NULL
BEGIN
CREATE TABLE Vaccinations (
    VaccinationID INT PRIMARY KEY,
    AnimalID INT NOT NULL FOREIGN KEY REFERENCES Animals(AnimalID),
    DoctorID INT NOT NULL FOREIGN KEY REFERENCES Doctors(DoctorID),
    ServiceID INT NOT NULL FOREIGN KEY REFERENCES ClinicServices(ServiceID),
    VaccinationDate DATE NOT NULL
);
END
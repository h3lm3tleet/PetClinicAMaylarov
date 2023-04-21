INSERT INTO [PetClinicVitakor].[dbo].[Owners] (OwnerID, FirstName, LastName, PhoneNumber)
VALUES (1, N'Иван', N'Иванов', N'+7 917 456 1110'),
       (2, N'Петр', N'Петров', N'+7 996 765 4321');

INSERT INTO [PetClinicVitakor].[dbo].[Animals] (AnimalID, AnimalName, Species, Breed, OwnerID)
VALUES (1, N'Барсик', N'Кошка', N'Сиамская', 1),
       (2, N'Шарик', N'Собака', N'Овчарка', 2);

INSERT INTO [PetClinicVitakor].[dbo].[Doctors] (DoctorID, FirstName, LastName)
VALUES (1, N'Анна', N'Андреева'),
       (2, N'Сергей', N'Сергеев');

INSERT INTO [PetClinicVitakor].[dbo].[ClinicServices] (ServiceID, ServiceName, ServiceCost)
VALUES (1, N'Осмотр', 500),
       (2, N'Прививка от бешенства', 1000),
       (3, N'Стрижка когтей', 300);

INSERT INTO [PetClinicVitakor].[dbo].[Vaccinations] (VaccinationID, AnimalID, DoctorID, ServiceID, VaccinationDate)
VALUES (1, 1, 1, 2, '2023-04-01'),
       (2, 2, 2, 2, '2023-04-15');
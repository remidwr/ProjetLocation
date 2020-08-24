EXEC DB_ProjetLocation.dbo.Register
	@LastName = 'Dewinckeleer',
	@FirstName = 'Rémi',
	@Birthdate = '1989-12-18',
	@Email = 'remidwr@gmail.com',
	@Passwd = 'Test1234=';

EXEC DB_ProjetLocation.dbo.Register
	@LastName = 'Nolan',
	@FirstName = 'Christopher',
	@Birthdate = '1970-07-30',
	@Email = 'cnolan@interstellar.com',
	@Passwd = 'Test1234=';

EXEC DB_ProjetLocation.dbo.Register
	@LastName = 'Pacino',
	@FirstName = 'Al',
	@Birthdate = '1940-04-25',
	@Email = 'al@godfather.com',
	@Passwd = 'Test1234=';

EXEC DB_ProjetLocation.dbo.CSP_UpdateUserInfo
	@UserId = 1,
	@LastName = 'Dewinckeleer',
	@FirstName = 'Rémi',
	@Birthdate = '1989-12-18',
	@Street = 'Singel',
	@Number = '80',
	@Box = NULL,
	@PostCode = 1853,
	@City = 'Strombeek-Bever',
	@Phone1 = '+32490123456',
	@Phone2 = '+32490654321',
	@Picture = NULL

EXEC DB_ProjetLocation.dbo.CSP_UpdateUserInfo
	@UserId = 2,
	@LastName = 'Nolan',
	@FirstName = 'Christopher',
	@Birthdate = '1970-07-30',
	@Street = 'Wilshire Blvd.',
	@Number = '10880',
	@Box = 'Suite 2100',
	@PostCode = 90024,
	@City = 'Los Angeles',
	@Phone1 = '+32490123456',
	@Phone2 = '+32490654321',
	@Picture = NULL

EXEC DB_ProjetLocation.dbo.CSP_UpdateUserInfo
	@UserId = 3,
	@LastName = 'Pacino',
	@FirstName = 'Al',
	@Birthdate = '1940-04-25',
	@Street = 'Civic Center Drive',
	@Number = '9336',
	@Box = NULL,
	@PostCode = 90210,
	@City = 'Beverly Hills',
	@Phone1 = '+32490123456',
	@Phone2 = '+32490654321',
	@Picture = NULL

EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Construction';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Jardin & Nature';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Horeca';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Decoration';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Vêtements';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Vacances';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Outillage';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Auto & Moto';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Loisir';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Bébé';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Electroménager';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Evènement';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Immobilier';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Mode';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Multimédia';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Photographie';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Services';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Sport';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection
	@SectionName = 'Divers';

EXEC DB_ProjetLocation.dbo.CSP_InsertCategory
	@CategoryName = 'Auto',
	@SectionId = 8;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory
	@CategoryName = 'Moto',
	@SectionId = 8;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory
	@CategoryName = 'Remorque',
	@SectionId = 8;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory
	@CategoryName = 'Accessoires',
	@SectionId = 8;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory
	@CategoryName = 'Camping Car',
	@SectionId = 8;	
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
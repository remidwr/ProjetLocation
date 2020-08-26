-- REGISTER Users
EXEC DB_ProjetLocation.dbo.CSP_Register 'Dewinckeleer', 'Rémi', '1989-12-18', 'remidwr@gmail.com', 'Test1234=';
EXEC DB_ProjetLocation.dbo.CSP_Register 'Nolan', 'Christopher', '1970-07-30', 'cnolan@interstellar.com', 'Test1234=';
EXEC DB_ProjetLocation.dbo.CSP_Register 'Pacino', 'Al', '1940-04-25', 'al@godfather.com', 'Test1234=';

-- UPDATE Users
EXEC DB_ProjetLocation.dbo.CSP_UpdateUserInfo 1, 'Dewinckeleer', 'Rémi', '1989-12-18', 'Singel', '80', NULL, 1853, 'Strombeek-Bever', '+32490123456', '+32490654321', NULL;
EXEC DB_ProjetLocation.dbo.CSP_UpdateUserInfo 2, 'Nolan', 'Christopher', '1970-07-30', 'Wilshire Blvd.', '10880', 'Suite 2100', 90024, 'Los Angeles', '+32490123456', '+32490654321', NULL;
EXEC DB_ProjetLocation.dbo.CSP_UpdateUserInfo 3, 'Pacino', 'Al', '1940-04-25', 'Civic Center Drive', '9336', NULL, 90210, 'Beverly Hills', '+32490123456', '+32490654321', NULL;

-- INSERT Section
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Auto & Moto';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Bébé';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Construction';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Décoration';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Divers';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Electroménager';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Evènement';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Horeca';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Immobilier';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Jardin & Nature';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Loisir';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Mode';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Multimédia';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Outillage';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Photographie';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Services';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Sport';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Vacances';
EXEC DB_ProjetLocation.dbo.CSP_InsertSection 'Vêtements';

-- INSERT Category (Auto & Moto)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Auto', 1;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Moto', 1;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Remorque', 1;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Accessoires', 1;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Camping Car', 1;

-- INSERT Category (Bébé)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Berceau', 2;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Jouet', 2;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Poussette', 2;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 2;	

-- INSERT Category (Construction)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Marteau-piqueur', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Carotteuse', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Fraiseuse', 3;
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Chariot élévateur', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Lève-plaque', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Ponceuse', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Groupe électrogène', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Rainureuse', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Bétonnière', 3;
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Pelleteuse', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Mini-Pelle', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Echaffaudage', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Echelle', 3;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 3;	

-- INSERT Category (Décoration)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Anniversaire', 4;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Mariage', 4;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Fête en tout genre', 4;	

-- INSERT Category (Evenement)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Anniversaire', 7;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Mariage', 7;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Fête en tout genre', 7;	

-- INSERT Category (Horeca)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Equipement de cuisine', 8;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Vaisselle', 8;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 8;

-- INSERT Category (Immobilier)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Appartement', 9;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Maison', 9;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Garage', 9;	

-- INSERT Category (Jardin & Nature)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Broyeur', 10;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Coupe bordure', 10;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Débroussailleuse', 10;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Pulvérisateur', 10;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Scarificateur', 10;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Rouleau à gazon', 10;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Taille haie', 10;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Tondeuse', 10;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Motobineuse', 10;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 10;	

-- INSERT Category (Loisir)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Château gonflable', 11;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Jacuzzi/Spa', 11;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Pêche aux canards', 11;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Vélo', 11;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Activité', 11;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Déguisement', 11;

-- INSERT Category (Mode)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Bracelet', 12;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Chaussures', 12;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Pantalon', 12;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Sac', 12;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'T-shirt', 12;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Pull', 12;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Veste', 12;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Robe', 12;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Custume', 12;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 12;	

-- INSERT Category (Multimédia)	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Ecran', 13;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Ordinateur', 13;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Téléphone', 13;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Console', 13;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 13;	

-- INSERT Category (Outillage)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Bétonnière', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Visseuse', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Ponceuse', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Pistolet à peinture', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Perceuse', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Disqueuse', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Soudeuse', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Scie', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Décolleuse', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Pince à sertir', 14;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 14;	

-- INSERT Category (Services)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Coup de main', 16;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Activité', 16;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 16;	

-- INSERT Category (Sport)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Hiver', 17;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Eté', 17;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Intérieur', 17;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 17;	

-- INSERT Category (Vacances)
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Appartement', 18;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Caravane/Mobilhome', 18;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Chalet', 18;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Maison', 18;	
EXEC DB_ProjetLocation.dbo.CSP_InsertCategory 'Autre', 18;

-- INSERT Good
EXEC DB_ProjetLocation.dbo.CSP_InsertGood 'Tronçonneuse Thermique Timberwolf 58 cm3',
										  'Tronçonneuse Thermique Timberwolf 58 cm3.',
										  'Utilisé',
										  '20',
										  NULL,
										  NULL,
										  'Civic Center Drive',
										  '9336',
										  NULL,
										  90210,
										  'Beverly Hills',
										  'Http://tronconneuse.png',
										  3,
										  10;

-- INSERT Rental
EXEC DB_ProjetLocation.dbo.CSP_InsertRental 1, 3, '25-08-2020', '27-08-2020', 40, 50;
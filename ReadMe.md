# Band Tracker Database

#### By Rouz Majlessi


 ## Description

This App will let the user Add bands to a particular venue and vice versa

## Setup

CREATE DATABASE band_tracker; GO USE band_tracker; GO CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255)); GO CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255)); GO CREATE TABLE venues_bands (id INT IDENTITY(1,1), venue_id INT, band_id INT); GO

Clone down project from GitHub
run: DNU restore
run: DNX kestrel

export Band-Tracker-SQL.Sql file
Open SSMS
Select File > Open > File and select your .sql file.
If the database does not already exist, add the following lines to the top of the script file
CREATE DATABASE [your_database_name]
GO
Save the file.
Click ! Execute.
Verify that the database has been created and the schema and/or data imported.



#### Known Bugs

None

#### Support and contact details

rmajlessi@gmail.com

Technologies Used

Sql, C#, Nancy, Razor, Html,

License

Copyright (c) 2016 Rouz Majlessi/Epicodus

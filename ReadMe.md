Band Tracker Database

By Rouz Majlessi

Description

This App will let the user Add bands to a particular venue and vice versa

Setup

CREATE DATABASE band_tracker; GO USE band_tracker; GO CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255)); GO CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255)); GO CREATE TABLE venues_bands (id INT IDENTITY(1,1), venue_id INT, band_id INT); GO

Clone down project from GitHub
run: DNU restore
run: DNX kestrel



Known Bugs

None

Support and contact details

rmajlessi@gmail.com

Technologies Used

Sql, C#, Nancy, Razor, Html,

License

Copyright (c) 2016 Rouz Majlessi/Epicodus

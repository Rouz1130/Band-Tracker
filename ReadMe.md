# Band Tracker

#### Site allows tracking which bands have played at what venues

#### _Created 09.28.2016.

#### By _**Rouz Majlessi**_

## Description

This site was made to fulfill the **Week four Epicodus Friday independent project requirement for the C# block**.  Project outline:

Write a program to track bands and the venues where they've played concerts. Make a Venue class and a Band class.

+ Build full CRUD functionality for Venues. Create, Read (show all, show single), Update, Delete.
+ Allow a user to create Bands that have played at a Venue. Don't worry about building out updating or deleting for bands.
+ There is a many-to-many relationship between bands and concert venues, so a venue can host many bands, and a band can play at many venues. Create a join table to store these relationships.
+ When a user is viewing a single concert venue, list out all of the bands that have played at that venue so far and allow them to add a band to that venue. Create a method to get the bands who have played at a venue, and use a join statement in it.
+ When a user is viewing a single Band, list out all of the Venues that have hosted that band and allow them to add a Venue to that Band. Use a join statement in this method too.

###### Requirements
For this code review, use the following names for your databases:

+ Production database: band_tracker
+ Development database: band_tracker_test
+ Resource names will be venues and bands
+ Include .sql files holding the schema for both your band_tracker and band_tracker_test databases (see instructions in the Migrating databases with SSMS lesson) . In your README, include the details of your database names and tables as a back up (see the example below from a To Do application):

```Sql

CREATE DATABASE bandtracker;
GO
USE bandtracker;

-- Table 'bands'
DROP TABLE IF EXISTS bands;

CREATE TABLE bands (
  id INTEGER NOT NULL IDENTITY(1,1),
  name VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (id)
);

-- Table 'venues'
DROP TABLE IF EXISTS venues;

CREATE TABLE venues (
  id INTEGER NOT NULL IDENTITY(1,1),
  name VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (id)
);

-- Table 'bands_venues'
DROP TABLE IF EXISTS bands_venues;

CREATE TABLE bands_venues (
  id INTEGER NOT NULL IDENTITY(1,1),
  band_id INTEGER NULL DEFAULT NULL,
  venue_id INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (id)
);
-- Foreign Keys
-- ---

ALTER TABLE bands_venues ADD FOREIGN KEY (band_id) REFERENCES bands (id);
ALTER TABLE bands_venues ADD FOREIGN KEY (venue_id) REFERENCES venues (id);
GO

CREATE DATABASE bandtracker_tests;
GO
USE bandtracker_tests;

-- Table 'bands'
DROP TABLE IF EXISTS bands;

CREATE TABLE bands (
  id INTEGER NOT NULL IDENTITY(1,1),
  name VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (id)
);

-- Table 'venues'
DROP TABLE IF EXISTS venues;

CREATE TABLE venues (
  id INTEGER NOT NULL IDENTITY(1,1),
  name VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (id)
);

-- Table 'bands_venues'
DROP TABLE IF EXISTS bands_venues;

CREATE TABLE bands_venues (
  id INTEGER NOT NULL IDENTITY(1,1),
  band_id INTEGER NULL DEFAULT NULL,
  venue_id INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (id)
);
-- Foreign Keys
-- ---

ALTER TABLE bands_venues ADD FOREIGN KEY (band_id) REFERENCES bands (id);
ALTER TABLE bands_venues ADD FOREIGN KEY (venue_id) REFERENCES venues (id);


-- Test Data
-- ---

-- INSERT INTO bands (name) VALUES ('');
-- INSERT INTO venues (name) VALUES('');
-- INSERT INTO bands_venues (band_id,venue_id) VALUES ('','');

```
###### Objectives
Here are the objectives that will be used to review your code:

+ Do the database table and column names follow proper naming conventions?
+ Do you have thorough test coverage?
+ Are all tests passing?
+ Did you write the test methods and make them pass before starting on routes for each class?
+ Does your Venue class have all CRUD methods implemented in your app? That includes: Create, Read (all and singular) Update and Delete (all and singular).
+ Are you able to view all the bands that have played at a single venue, as well as all the venues that have hosted a particular band?
+ Is the many-to-many relationship set up correctly in the database?
+ Are the commands on how to set up the database in the README? Did you include the .sql files?
+ Is the project in a polished, portfolio-quality state?
+ Does the project demonstrate all of this week's concepts? If prompted, are you able to discuss your with an instructor using correct terminology?

###### Previous Objectives
And then, make sure to follow all the requirements from last week too.

+ Was Razor syntax used on view pages where appropriate?
+ Is your logic easy to understand?
+ Did you use descriptive variable names?
+ Does your code have proper indentation and spacing?
+ Did you include a README with a description of the program, setup instructions, a copyright, a license, and your name?
+ Is the project tracked in Git, and did you regularly make commits with clear messages that finish the phrase "This commit will…"?

## Known Bugs and observations
- There is no error checking for inputs site.
- Limited views.

## Support and contact details
Email me at rmajlessi@gmail.com

## Technologies Used

+ Mono, Nancy, Razor view engine.
+ C#, HTML, CSS, SQL, jQuery.

### License

COPRYRIGHT ACCORDING TO MIT LICENSE

Copyright (c) 2016 **_Rouz Majlessi_**

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.*

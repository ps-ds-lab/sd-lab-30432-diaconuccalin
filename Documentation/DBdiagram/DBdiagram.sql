CREATE TABLE "admin" (
  "adminID" SERIAL PRIMARY KEY,
  "username" varchar,
  "password" varchar
);

CREATE TABLE "host" (
  "hostID" SERIAL PRIMARY KEY,
  "username" varchar,
  "password" varchar,
  "name" varchar,
  "telephoneNumber" varchar,
  "email" varchar,
  "profilePicturePath" varchar
);

CREATE TABLE "guest" (
  "guestID" SERIAL PRIMARY KEY,
  "username" varchar,
  "password" varchar,
  "name" varchar,
  "telephoneNumber" varchar,
  "email" varchar,
  "profilePicturePath" varchar,
  "description" varchar
);

CREATE TABLE "location" (
  "locationID" SERIAL PRIMARY KEY,
  "hostID" int,
  "physicalAddress" varchar,
  "availableDateStart" datetime,
  "availableDateEnd" datetime,
  "description" varchar
);

CREATE TABLE "image" (
  "id" SERIAL PRIMARY KEY,
  "imagePath" varchar,
  "locationID" int
);

CREATE TABLE "guestRequest" (
  "requestID" SERIAL PRIMARY KEY,
  "requiredDateStart" datetime,
  "requiredDateEnd" datetime,
  "hostID" int
);

ALTER TABLE "location" ADD FOREIGN KEY ("hostID") REFERENCES "host" ("hostID");

ALTER TABLE "image" ADD FOREIGN KEY ("locationID") REFERENCES "location" ("locationID");

ALTER TABLE "guestRequest" ADD FOREIGN KEY ("hostID") REFERENCES "guest" ("guestID");

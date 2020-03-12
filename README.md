# Festival Accomodation Platform
Web application consisting of an Airbnb/Couchsurfing like platform dedicated to a certain festival. The purpose of this platform is to bring together locals wishing to host festival goers and guests looking for a place to stay during the festival.

## Users
There will be three types of users: administrators, hosts and guests. Each user will gain access to the platform through a unique username and a password.
* **Admin**: the administrator should be able to perform any CRUD modification to the information of any user. The information associated with the admin is a username and a password.
* **Host**: the hosts should be able to perform any CRUD modification on any information regarding themselves and also Read operations on the Guests that requested accomodation at one of their locations. The information associated with a host should be: username, password, name, telephone number, email, profile picture and the list of accomodation locations listed by them (with every location containing the following information: physical address, pictures of the location, available dates, description of the accomodation - such as the number of rooms, beds or camping spots and access to bathrooms/showers).
* **Guest**: the guests should be able to perform any CRUD modification on any information regarding themselves and also Read operations on the list of locations and the associated hosts. The information associated with the guests should be: username, password, name, telephone number, email, profile picture, short description of themselves, required dates.

## Other remarks:
- The list of available locations displayed to the Guest should be filtered according to the required dates.
- There should be a form for requesting accomodation that may send an automated email and/or sms that will notify the Host and that will give them Read access to the information of the Guest.

## Possible improvements:
- guests grouping
- blocking list for spam, with "Report" option
- rating system
- in-app messaging system between host and guest

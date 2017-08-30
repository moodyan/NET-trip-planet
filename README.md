# TripPlanet

#### _App created for Epicodus Capstone using C# and ASP.NET. August 31st, 2017_

#### By **Alyssa Moody**

## Description

_A web application that allows users to manage their multi-city trips._

## MVP Program Specifications

| Description  | Input Example | Output Example |
| ------------- | ------------- | ------------- |
| The program allows anyone to view a landing page.  | Home  | "Welcome"  |
| The program allows anyone to create an account.  | New Account  | "Enter your information"  |
| The program allows users to login to edit their account info.  | /Account/Edit  | Form for editing |
| The program allows users to create a new trip (multi-city).  | New trip  | Form for new trip  |
| The program allows users to add more cities to their trip.  | Add city  | Form for date and city  |
| The program allows users to delete cities from their trip.  | Delete city  | "Are you sure?"  |
| The program allows users to add details to each city.  | Add details  | Transportation, Lodging, Activities  |
| The program allows users to edit/delete details from each city .  | Edit  | Form for editing  |
| The program allows admins to add roles to users.  | --  | Admin Portal  |
| STRETCH: The program allows users to view a map view of their trip.  | Map Overview  | Map Overview  |


**STRETCH GOALS**
1. Budgeting feature where users can keep track of their total budget and how much they plan to spend on transportation, food/drink, and activities. This feature would also take the information from user inputted flights and activities and be shown here as part of their budget.
2. Map view (Google maps API) of their trip (overview AND each city) with markers for where they plan to go.
3. Flight selector that inputs flight info to their trip (Flight API)
4. Admin features?
5. Group Trip features (add friend’s email to trip) - this would also add to the budgeting feature to split costs.
6. Upload documents and profile photo feature
7. Allows users to delete their account.
8. Users can choose single-city trip planning

**TODO:**
1. Add markers to map based on trip cities database data.
2. Fix activity/lodging dates to dropdown list dates in city
3. For activity, create dropdown list for types
4. For transportation, different forms based on mode.
5. Shorten names of activities/lodging etc
6. Add starting city based on trip.startCity (add lat/long)
7. Add seed data


## Setup/Installation Requirements

**Requirements**

If you do not have Visual Studio 2017, download [HERE](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15).

If you do not have SSMS, download [HERE](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).

**Cloning From GitHub:** Download or clone project repository onto desktop from GitHub.

Open the project in Visual Studio.

**Migrations**
1. In Solution Explorer, right-click the project and choose 'Open in File Explorer' from the context menu.
2. Enter "cmd" in the address bar and press Enter.
3. Enter the following command in the command window:
  - dotnet ef database update
4. Open scripts.sql in SSMS and execute (this will add sample data).
5. Back in VS, click IIS Express at the top of the window. Project should open in a new window in your default browser.

## Screenshots

## Known Bugs

_No known bugs._

## Support and contact details

_If you run into any issues or have questions, ideas or concerns, please contact Alyssa Moody at alyssanicholemoody@gmail.com_

## Technologies Used

**Languages:** HTML, SCSS, C#, ASP.NET

**IDE:** Visual Studio 2017

**Database Management:** MySQL (SSMS)

**APIs:**
- [Geocoding API](https://github.com/chadly/Geocoding.net)
- [Google Maps API](https://developers.google.com/maps/documentation/javascript/get-api-key)
- MAYBE: Flight API (QPX Express API)


### License

*MIT license Agreement*

Copyright (c) 2017 **_Alyssa Moody_*

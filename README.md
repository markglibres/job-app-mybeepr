## MyBeepr 
This is a take home assignment for my job application in MyBeepr. 

The goal of this project is to calculate the number of weekdays between two dates. Assume weekdays are Monday to Friday. The returned count should not include from date or to date.

The architecture / design used on this project is based on the project template I have created. Please follow this [link](https://github.com/markglibres/dotnetcore-service-template) for a detailed explanation.

## Pre-requisite
* dotnetcore 3.1 <
## How to run
1. Clone the project repository 
	```
	git clone https://github.com/markglibres/job-app-mybeepr
	```
2.  Change directory to the api app
	```
	cd job-app-mybeepr/src/MyBeepr.Presentation.Api
	``` 
3.  Build the project
	```
	dotnet build
	```
4. Run the project
	```
	dotnet run
	``` 
 5. Check swagger UI for available endpoints: [http://localhost:5000/swagger](http://localhost:5000/swagger)
 6. Sample url to get number of working days: [http://localhost:5000/api/businessdays?start=2019-05-23&end=2019-05-26](http://localhost:5000/api/businessdays?start=2019-05-23&end=2019-05-26)
	 
	 This should return working days = 1.

## How to configure holidays
For demo purposes, this project uses the in-memory repository for entities. Follow this [link](https://github.com/markglibres/dotnetcore-service-template/wiki/How-to-install-template) on how to use my project template for SQL database.

There are 3 types of holidays: 

1. Fixed day - Always on the same day even if it is a weekend (like Anzac Day 25 April every year)
	
	Initial data can be configured on this file location: 	[MyBeepr.Presentation.Api/Configs/HolidayTypes/FixedDayHolidayConfiguration.cs](https://github.com/markglibres/job-app-mybeepr/blob/master/src/MyBeepr.Presentation.Api/Configs/HolidayTypes/FixedDayHolidayConfiguration.cs)
	
	 Sample:
	 ```
	 var initialData = new List<FixedDayHoliday>
     {
         new FixedDayHoliday("Anzac Day", 4, 25)
     };
	 ```
2. Sliding day -On the same day as far as it is not a weekend (like New Year 1st of every year unless it
is a weekend, then the holiday would be next Monday)

	Initial data can be configured on this file location: 
[MyBeepr.Presentation.Api/Configs/HolidayTypes/SlidingDayHolidayConfiguration.cs](https://github.com/markglibres/job-app-mybeepr/blob/master/src/MyBeepr.Presentation.Api/Configs/HolidayTypes/SlidingDayHolidayConfiguration.cs)

	Sample:
	```
	var initialData = new List<SlidingDayHoliday>
    {
        new SlidingDayHoliday("Australia Day", 1, 26)
    };
	```

	 
3. Fixed day of the week - Certain occurrence on a certain day in a month (like Queen’s Birthday on the second Monday in June every year)
	
	Initial data can be configured on this file location: 
	[MyBeepr.Presentation.Api/Configs/HolidayTypes/FixedDaysOfTheWeekConfiguration.cs](https://github.com/markglibres/job-app-mybeepr/blob/master/src/MyBeepr.Presentation.Api/Configs/HolidayTypes/FixedDaysOfTheWeekConfiguration.cs)

	Sample:
	```
	var initialData = new List<FixedDayOfWeekHoliday>
    {
        new FixedDayOfWeekHoliday("Queen's Birthday'", 6, DayOfWeek.Monday, 2)
    };
	```
## How to implement your own holiday types
1. Create a class and implement "IHolidayTypeService". See sample service [here](https://github.com/markglibres/job-app-mybeepr/blob/master/src/MyBeepr.Domain/Holidays/HolidayTypes/FixedDayHolidayService.cs)
2. Inject your services and repository. See sample [here](https://github.com/markglibres/job-app-mybeepr/blob/master/src/MyBeepr.Presentation.Api/Configs/HolidayTypes/FixedDayHolidayConfiguration.cs)
3. Don't forget to register your services. See sample [here](https://github.com/markglibres/job-app-mybeepr/blob/master/src/MyBeepr.Presentation.Api/Configs/BusinessDaysConfiguration.cs)

## Tests
For demo purposes, unit tests are only implement for the Domain layer. To run the unit tests, follow the steps below: 

1. Change directory to the test folder
	```
	cd job-app-mybeepr/src/Tests/MyBeepr.Domain.Tests
	```
2. Run the tests
	```
	dotnet test
	``` 

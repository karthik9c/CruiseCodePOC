Before running the API, ensure you have the following installed:

.NET SDK (.Net Core)
Visual Studio (2022 or later)

1. Clone the Repository
	clone the project: 

	git clone https://github.com/karthik9c/CruiseCodePOC.git
	cd your-repo-name	

2. Restore Dependencies
	Navigate to the project folder and restore NuGet packages:
	dotnet restore

3. Build the solution
	dotnet build

4. Run the Application under API
	dotnet run

5. Open Swagger url
	DomainURL/swagger/index.html

6. Run api/DummyJWT for JWT token generation and save it
	Run it to generate JWT token which will be valid for 30 mins and save the token with "bearer" appended

7. Run api/octo/supplier
	Run this get request to get supplier details

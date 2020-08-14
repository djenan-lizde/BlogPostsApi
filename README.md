# BlogPostsApi
BlogPostAPI project :: REST API C# ASP.NET Core

I used SQL Server for the database. After you start the application for the first time, database will be created and seeded with some initial data.
I used Postman for testing API.

How to start?
You need to go into the Posts/appsettings.json (path) file and change the connection string to database in this format:
If you have some kind of authentication then you will use connection string like this (change the parametars)
    "Server=ServerName;Database=DatabaseName;Trusted_Connection=false;MultipleActiveResultSets=true;User=UserName;Password=Password"
    
or if you don't have authentication and you are using windows authentication for sql server then your connection string you should look something like this:
    "Server=ServerName;Database=DatabaseName;Trusted_Connection=true;"

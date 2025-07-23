# OfficeCRM
The project setup is ready for further development but currently lacks complete business logic or modular implementations such as models, database connections, or user authentication.

Project Structure and Purpose

The solution is named OfficeCRM and is set up as a Visual Studio Solution targeting .NET (suggesting it is likely an ASP.NET Core MVC application).

The main structure supports web application features, such as controllers and views, suitable for customer relationship management (CRM) system development.

Configuration and Logging

The project uses an appsettings.json file to configure logging and host settings. The default log level is set to "Information," and warnings are logged for Microsoft.AspNetCore components. The AllowedHosts option is currently set to accept all hosts, making the app accessible from any network environment.

Web Application Setup

The Program.cs file registers MVC controllers and views, configures error-handling middleware for production, enables serving of static files, sets up routing (default route: Home/Index), and activates authorization middleware for secure access to resources

### SensitiveWords
.NET Core application for masking sensitive words in messages.

A .NET 9 microservice that sanitizes client messages by replacing sensitive keywords with asterisks.

## Architecture
.NET 9 Web API
.Net 9 Web App with Razor Pages
Dapper
SQL Server
Clean Architecture
Unit Tests (xUnit + Moq)
Swagger Documentation
### How to Run
## 1. Clone the repository
git clone https://github.com/yourusername/SensitiveWords.Sanitizer.git

## 2. Setup database
Run the scripts inside the /database folder in SQL Server.

## 3. Update connection string
Modify appsettings.json if needed.

## 4. Run Docker
Run Docker Desktop

## 5. Run AppHost
In startup configuration set AppHost as the startup project, this will run everything you need.

Swagger will be available at: https://localhost:7018/swagger

## Running Tests
dotnet test

## Database Structure
- ClientMessages
- SanitizerKeyWords

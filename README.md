# ProfileAPI

A REST API built with C# and ASP.NET Core that returns profile information with dynamic cat facts.

## Features

- GET /me endpoint returning profile data
- Real-time timestamp generation
- External API integration (Cat Facts API)
- Error handling and fallback mechanisms

## Tech Stack

- C# / ASP.NET Core 6.0+
- System.Text.Json for JSON handling
- HttpClient for external API calls

## Prerequisites

- .NET 6.0 SDK or later
- Visual Studio 2022

## Installation

Clone the repository:
```bash
git clone https://github.com/psalmtium/profile-api.git
cd profile-api
```

Restore dependencies:
```bash
dotnet restore
```

## Running Locally

Run the application:
```bash
dotnet run
```

The API will start at `https://localhost:7209` (or check console for actual port).

Test the endpoint:
```
GET https://localhost:7209/me
```

## API Response Format
```json
{
  "status": "success",
  "user": {
    "email": "samuelakinyemi.f@gmail.com",
    "name": "Samuel Akinyemi",
    "stack": "C#/ASP.NET Core"
  },
  "timestamp": "2025-10-16T14:30:45.123Z",
  "fact": "Cats have 32 muscles in each ear."
}

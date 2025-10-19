
# REST API Automated Tests (C#)

This project provides automated tests for the [jsonplaceholder.typicode.com](https://jsonplaceholder.typicode.com) public REST API, using **xUnit** as the test framework and **RestSharp** for HTTP requests. The structure and code follow best practices for maintainability, scalability, and clarity.

## Features

- **CRUD tests** for the `/users` endpoint (Create, Read, Update, Delete)
- Modular architecture: helpers, models, test data generators, and test classes
- Easy configuration via `appsettings.json`
- Clear assertions with [FluentAssertions](https://fluentassertions.com/)
- Ready for CI/CD integration

## Project Structure

```
ApiTests/
│
├── ApiTests.csproj
├── appsettings.json
├── Helpers/
│   └── ApiClient.cs
├── Models/
│   └── UserModel.cs
├── Tests/
│   └── UserApiTests.cs
└── Utils/
    └── TestDataGenerator.cs
```

## Getting Started

### Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/download)
- Internet connection (to access the public API)

### Installation

1. **Clone the repository:**
    ```bash
    git clone <your-repo-url>
    cd ApiTests
    ```

2. **Install dependencies:**
    ```bash
    dotnet add package xunit
    dotnet add package RestSharp
    dotnet add package FluentAssertions
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Newtonsoft.Json
    ```

3. **Check `appsettings.json`:**
    ```json
    {
      "ApiBaseUrl": "https://jsonplaceholder.typicode.com"
    }
    ```

### Running the Tests

```bash
dotnet test
```

All tests are located in the `Tests/UserApiTests.cs` file and cover:

- **GET**: Retrieve a single user and all users
- **POST**: Create a new user (simulated)
- **PUT**: Update an existing user (simulated)
- **DELETE**: Delete a user (simulated)

> **Note:**  
> The jsonplaceholder API simulates POST, PUT, and DELETE operations. The data is not actually changed on the server.

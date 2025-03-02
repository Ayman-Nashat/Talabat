# Talabat

Talabat is a C# application designed to provide a robust and scalable web API using modern technologies such as ASP.NET Core, Entity Framework Core, and Redis.

## Features

- **Web API Services:** Built with ASP.NET Core to ensure scalability and maintainability.
- **Database Integration:** Utilizes SQL Server for efficient data storage.
- **Identity Management:** Implements Identity services for authentication and authorization.
- **Redis Integration:** Enhances performance and scalability with Redis caching.
- **Error Handling:** Middleware for centralized exception handling.
- **CORS Support:** Configured to allow cross-origin requests.

## Setup

### Prerequisites

Ensure you have the following installed:

- .NET 6.0 SDK
- SQL Server
- Redis

### Installation

Clone the repository:

```sh
git clone https://github.com/Ayman-Nashat/Talabat.git
cd Talabat
```

Update the connection strings in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your_sql_server_connection_string",
    "IdentityConnection": "your_identity_db_connection_string",
    "Redis": "your_redis_connection_string"
  }
}
```

Run the application:

```sh
dotnet run --project Talabat.APIs
```

## Usage

### Running the API

Once the application starts, the API will be available at:

```
https://localhost:5001
```

### API Endpoints

- **GET** `/api/values` - Retrieve a list of values.
- **POST** `/api/values` - Add a new value.

## Contributing

We welcome contributions! Follow these steps:

1. Fork the repository.
2. Create a new branch:

   ```sh
   git checkout -b feature-branch
   ```

3. Make your changes and commit them:

   ```sh
   git commit -m "Description of changes"
   ```

4. Push to your branch:

   ```sh
   git push origin feature-branch
   ```

5. Create a pull request.

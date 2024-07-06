# Silverhorse API

A .NET API that retrieves posts, albums, users, and collections.

## Overview

The Silverhorse API is a .NET API designed to retrieve posts, albums, users, and collections from a specified data source (https://jsonplaceholder.typicode.com/).

## Installation

### Prerequisites

-   .NET 8.0 SDK or later ([Download .NET SDK](https://dotnet.microsoft.com/download))
-   Visual Studio (or any preferred code editor such as Visual Studio Code)
-   Git

### Steps

1. **Clone the repository**

    ```bash
    git clone https://github.com/jay4170/silverhorsetechteam.git
    cd silverhorsetechteam
    ```

## Usage

### Open and Run the Project in Visual Studio

1. **Launch Visual Studio.**

2. **Open the cloned project:**

    - Click on `File` > `Open` > `Project/Solution`.
    - Navigate to the directory where you cloned the repository (`silverhorsetechteam`) and select the solution file (`.sln`).

3. **Restore Packages:**

    - Once the project is loaded, right-click on the solution in Solution Explorer and select `Restore NuGet Packages`. This ensures all necessary packages are installed.

4. **Set the Startup Project:**

    - Right-click on the API project in Solution Explorer.
    - Select `Set as Startup Project`.

5. **Build and Run the Project:**

    - Press `F5` or click on the `Start` button in Visual Studio to build and run the API project.

6. **Access the API:**

    - The API will be hosted locally and by default, it should be accessible at `https://localhost:7269`.
    - You can use tools like Postman or cURL to send requests to the API endpoints.

### Example Usage

- Use Postman to send GET or POST requests to `https://localhost:7269/api/albums/1` or other endpoints defined in the API controllers.
- Requires specific bearer token af24353tdsfw

### Testing with Swagger

Swagger is set up for this project, making it easy to test the API endpoints. Once the project is running, you can access the Swagger UI at:

http://localhost:5226/swagger


By following these steps, you should be able to successfully run the Silverhorse API project in Visual Studio and begin interacting with its endpoints. Adjust the port number (`5226`) as needed based on your project configuration.

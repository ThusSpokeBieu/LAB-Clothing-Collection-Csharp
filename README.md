
# LAB Clothing Collection
[ [Português](./.docs/README-PTBR.md) ]

Welcome to LAB Clothing Collection—a study in crafting a dynamic REST API. Our aim is to harmonize developer satisfaction, performance, best coding practices, and business logic. By embracing DDD, SOLID, and innovative patterns, we're creating an API that thrives on balance. We mitigate performance trade-offs using source-generated code, advanced DTO structures, sealed classes, SQL procedures, and caching.

This endeavor yields a potentially scalable, high-performance system, providing flexibility and ease of maintenance. Inspired by real fashion scenarios, LAB Clothing Collection lets users manage fashion collections and models. An evolution of DEVinHouse Audaces v2, explore the original [here](https://github.com/gmessiasc/LABCC-Back-End-Csharp).

Every decision made for this system's design is meticulously documented and justified. We welcome any suggestions for improvement you might have.

## Index
1. [Technologies](#1-technologies)
2. [How To Build And Run](#2-how-to-build-and-run)
3. [Features and Documentation](#3-features-and-documentation)
4. [Software Design](#4-software-design)
5. [TODO](#5-todo)
6. [Reference](#6-references)

## 1. Technologies

- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/) and [.NET Core 8.0](https://dotnet.microsoft.com/pt-br/) -  Expanding to include other language versions in the future (e.g., Java with Quarkus and Go).

- [Fast Endpoints](https://fast-endpoints.com/) -  This framework offers high-performance endpoints akin to Minimal API, with improved code organization and a clean architecture. It seamlessly integrates other libraries.

- [Dapper](https://github.com/DapperLib/Dapper) -  A performance-focused MicroORM that avoids excessive complexity. We opted for Dapper due to its performance and flexibility in using complex custom queries when required.

- [ValueOf](https://github.com/mcintyre321/ValueOf) - Enables the creation of ValueObjects with ease. This allows us to encapsulate value object logic within themselves, promoting a more flexible, ubiquitous language and bounded context. Complex logic can be written into Value Objects for universal reuse.

- [BCrypt](https://github.com/BcryptNet/bcrypt.net) or [Argon2](https://github.com/mheyman/Isopoh.Cryptography.Argon2) - After careful consideration, we lean towards BCrypt due to its balance between security and performance. Argon2 is more secure but slower, potentially impacting API performance.

- [SQL Server 2022](https://www.microsoft.com/pt-br/sql-server/sql-server-2022) - Chosen primarily due to the project's .NET Core environment. We adopt a database-first approach for better performance and flexibility. The included SQL script in the resources automates database seeding and provides stored procedures.

- [Docker](https://www.docker.com/) - Facilitates easy project execution and deployment.

## 2. How to Build and Run

To build the LAB Clothing Collection project, follow these steps:

1. Begin by creating a `.env` file. An example file named `.env.example` contains all the environment variables required. You can either update these variables with your own values or use the example variables as-is. Simply copy the contents of the file into a new `.env` file located in the root directory.<br><br>Env Example:

```.env
# SQLSERVER
DB_HOST=labcc-db
DB_PORT=1433
DB_NAME=labclothingcollectionbd
DB_USER=sa
DB_PASSWORD=1456789!AbcDeFg

# JWT
JWT_SECRET=MysteriousSecretForJwt
```
-  `DB_HOST` is the name of the Docker container for the database. If you aren't using docker, must be something like "localhost,1433".

2. As seen above, you need to set up an instance of SQL Server that contains a database with a name equivalent to the `DB_NAME` variable in the `.env` file. You can achieve this in various ways, but by default, you can follow these steps:<br><br>
   - Launch the Docker instance of the database using the command: 
   ```bash
   docker-compose up labcc-db -d
   ```

   - Wait for the SQL Server to initialize properly and then create the database. You can use any database management tool or even the docker exec command for this purpose. For example:
   ```bash
   docker exec -it labcc-mssql /opt/mssql-tools/bin/sqlcmd -S labcc-db -U SA -P 1456789!AbcDeFg -Q 'CREATE DATABASE labclothingcollectionbd;'
   ```

3. Once the database is up and running, you can start the application using Docker with the command: 
```bash 
docker-compose up labcc-app
```
- This option will run the application on the localhost exposed in the Docker Compose setup, typically on port 8080. You can access the Swagger API documentation through http://localhost:8080/swagger.
<br><br>
- During runtime, the application will read the .env file and execute SQL scripts to configure the database, including the initial migration step (if it's the first time running).
<br><br>
- Alternatively, you can run the application locally by navigating to the LABCC.Application directory and using the commands dotnet watch or dotnet run.
<br><br>
- You can also build the application using the following commands: dotnet restore, dotnet build, and dotnet publish. This will generate the executable DLL that you can use to run the application locally.

### Approach Explanation
- The .env file simplifies configuration for both the API and database. It allows easy adjustment and a fresh start by resetting Docker containers when necessary.
- SQL Scripts run on-demand for manual database migrations. Dapper lacks automated migration options, so this approach ensures precise database updates in sync with the application's changes.

## 3. Features and Documentation

- For organized and comprehensive information, each feature is accompanied by dedicated documentation within the `.docs` folder:
<br><br>
  - **Authentication: [Auth Documentation](.docs/Auth.md)**
  - **User Management: [Users Documentation](.docs/Users.md)**
  - **Clothing Collections:** _(Coming Soon)_
  - **Clothing Models** _(Coming Soon)_
  <br><br>
- This setup provides clear insights into feature creation, implementation, and underlying business logic.

## 4. Software Design

- The project is divided into three modules: Application, Domain and Infra.

### Application

- The Application module manages inputs and serves as the end-user interface. It leverages FastEndpoints for request handling, adopts a straightforward Jwt Bearer Token Authentication and Role Authorization approach for security, and employs in-memory caching to enhance performance. This module also makes use of records in requests and responses, simple mappers, and the FluentValidator from FastEndpoint for streamlined processes.  
- To enhance single responsibility within classes, we partition features into distinct use cases. This strategy promotes a more organized and focused codebase.

### Domain

- The core of the project, the Domain module houses business logic using interfaces for IoC, Enums, Exceptions, utility tools, Aggregate Roots, and ValueObjects. Entities are self-contained, equipped with Params and Dto (including records) to manage data. Aggregate Roots represent groups of value objects, each property empowered to handle itself—like Passwords that can self-hash and verify. This module streamlines validation, conversion, and code, enhancing clarity.

### Infrastructure

- The Infrastructure module manages broader configurations, such as external access and bootstrapping. It ensures a smooth operational setup for the project's execution.

### Test

- _Soon_

## 5. TODO

- Commence with unit tests to ensure code quality.
- Enhance documentation, focusing on both user guides and authentication specifics.
- Implement advanced user features like Update and Delete with customizable permissions.
- Integrate Github actions for continuous integration.
- Introduce an external caching provider using Redis to optimize performance.
- Add comprehensive features for Clothing Collections.
- Develop extensive features for Clothing Models.
- Continuously expand and enhance the project with more to come.

## 6. References

- Some projects that I use as inspiration:
  - [Elfocrash/clean-minimal-api](https://github.com/Elfocrash/clean-minimal-api)
  - [dj-nitehawk/MiniDevTo](https://github.com/dj-nitehawk/MiniDevTo)
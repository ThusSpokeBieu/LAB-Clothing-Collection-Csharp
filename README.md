
# LAB Clothing Collection

Welcome to LAB Clothing Collection—a study in crafting a dynamic REST API. Our aim is to harmonize developer satisfaction, performance, best coding practices, and business logic. By embracing DDD, SOLID, and innovative patterns, we're creating an API that thrives on balance. We mitigate performance trade-offs using source-generated code, advanced DTO structures, sealed classes, SQL procedures, and caching.

This endeavor yields a potentially scalable, high-performance system, providing flexibility and ease of maintenance. Inspired by real fashion scenarios, LAB Clothing Collection lets users manage fashion collections and models. An evolution of DEVinHouse Audaces v2, explore the original [here](https://github.com/gmessiasc/LABCC-Back-End-Csharp).

Every decision made for this system's design is meticulously documented and justified. We welcome any suggestions for improvement you might have.


## Technologies

- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/) and [.NET Core 8.0](https://dotnet.microsoft.com/pt-br/) -  Expanding to include other language versions in the future (e.g., Java with Quarkus and Go with Fiber).

- [Fast Endpoints](https://fast-endpoints.com/) -  This framework offers high-performance endpoints akin to Minimal API, with improved code organization and a clean architecture. It seamlessly integrates other libraries.

- [Dapper](https://github.com/DapperLib/Dapper) -  A performance-focused MicroORM that avoids excessive complexity. We opted for Dapper due to its performance and flexibility in using complex custom queries when required.

- [ValueOf](https://github.com/mcintyre321/ValueOf) - Enables the creation of ValueObjects with ease. This allows us to encapsulate value object logic within themselves, promoting a more flexible, ubiquitous language and bounded context. Complex logic can be written into Value Objects for universal reuse.

- [BCrypt](https://github.com/BcryptNet/bcrypt.net) or [Argon2](https://github.com/mheyman/Isopoh.Cryptography.Argon2) - After careful consideration, we lean towards BCrypt due to its balance between security and performance. Argon2 is more secure but slower, potentially impacting API performance.

- [SQL Server 2022](https://www.microsoft.com/pt-br/sql-server/sql-server-2022) - Chosen primarily due to the project's .NET Core environment. We adopt a database-first approach for better performance and flexibility. The included SQL script in the resources automates database seeding and provides stored procedures.

- [Docker](https://www.docker.com/) - Facilitates easy project execution and deployment.

## 

# ECommerce

This is a proof-of-concept project that conceptualizes an e-commerce website with a .NET Core backend that uses "REST API with basic CQRS and DDD" and a frontend that uses Vue3. It is **not** a fully functional website that is ready to be deployed. It demonstrates the following:

- C#
- CQRS
- FluentValidation
- DDD
- Vue.js
- REST API
- Unit Testing
- SQL Server
- .NET Framework (Core)
- Entity Framework (Core)

## Requirements

- [SQL Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-2019)
- [Visual Studio 2022 (version 17.5 or higher)](https://visualstudio.microsoft.com/downloads/)
- [Node.js (preferably latest)](https://nodejs.org/en)
- [Yarn package manager](https://classic.yarnpkg.com/lang/en/docs/install)
  - [`yarn` command available in the PATH environment variable](https://stackoverflow.com/questions/70385413/git-bash-bash-yarn-command-not-found)

## Before starting

- Execute the `InitializeDatabase.sql` which will create and initializes a demo database
- Restore the NuGet packages of the whole solution
- Install the node packages that are needed for the frontend
    1. Open up a terminal
    2. Change the directory to "~/ECommerce.Vue"
    3. run `yarn` or `yarn install`

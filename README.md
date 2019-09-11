<br />
<p align="center">
  <img src="github/logo.png" alt="Logo" width="80" height="80">

  <h3 align="center">Movie Posters</h3>

  <p align="center">
    A full-stack (React, ASP.NET Core, MS SQL Server) Movie Poster Review App
  </p>
</p>

## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [License](#license)

## About the Project
* ASP.NET Core RESTful service layer with Entity Framework Core ORM
* SPA-style front-end with Webpack, React, Babel
* MS SQL Server 2017 persistent database

### Built With
* [MS SQL Server](https://www.microsoft.com/en-us/sql-server/default.aspx)
* [Microsoft Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-2.2)
* [React](https://reactjs.org)
* [Webpack](https://webpack.js.org)
* [Babel](https://babeljs.io)
* [Docker](https://www.docker.com)
* [Azure Data Studio](https://docs.microsoft.com/en-us/sql/azure-data-studio/what-is?view=sql-server-2017)
* [VS Code](https://code.visualstudio.com)

## Getting Started

### Prerequisites

* [Docker](https://www.docker.com) installed.
* [MS SQL Server image: 2017-latest](https://hub.docker.com/_/microsoft-mssql-server) in Docker repo.
```sh
docker pull mcr.microsoft.com/mssql/server:2017-latest

#Set up DB server. (Docker Quickstart Terminal can tell you the IP address of your virtual machine)
docker run -e 'ACCEPT_EULA=Y' \
-e 'SA_PASSWORD=Passw0rd!' \
-p 1433:1433 \
--name movie-posters-db \
-d microsoft/mssql-server-linux:2017-latest
```
* [Node](https://nodejs.org/en/) installed.
* [.NET Core 2.2.0](https://dotnet.microsoft.com/download) installed.

### Installation

__*Note: DB ConnectionString is hardcoded in this project. For deployment, consider encrypting in a config file or environment variable.__
1. Clone the repo
```sh
https://github.com/chaua0927/movie-posters.git
```
2. Install EF Core 2.2.0
```sh
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 2.2.0
```
3. Install NPM packages.
```sh
npm install
```

<!-- USAGE EXAMPLES -->
## Usage
```
#run db container, syntax is for Docker Toolbox
docker container start <db-name>

#run webserver at localhost:5000 and :5001
dotnet run

```

<!-- ROADMAP -->
## Roadmap

### Features
- [x] View List of Movie Posters
- [ ] Base UI Design + Icon
- [ ] CRUD Movie Posters 
- [ ] CRUD Comments
- [ ] Movie Poster Search
- [ ] Account Management

### Optimizations
- [ ] Implement lazy-loading

### Dev Environment
- [x] Fundamental stack set-up
- [ ] Set up source maps + HMR
- [ ] Set up BDD/TDD: Cucumber + Selenium + Jest
- [ ] Set up SCSS env (minifying, autoprefixer)


## License

Distributed under the MIT License. See `LICENSE` for more information.

All images are intended for non-commercial entertainment and education use only - reviews, fan art, blogs, forums, etc. MoviePosterDB is not endorsed, sponsored or affiliated with any movie studio. All copyrights, trademarks, and logos are owned by their respective owners. This site is for non-profit/educational use only. Using images from this project to make and/or sell reprinted movie posters is strictly forbidden.
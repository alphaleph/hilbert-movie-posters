<br />
<p align="center">
  <img src="github/logo.png" alt="Logo" width="80" height="80">

  <h3 align="center">Hilbert - Movie Posters</h3>

  <p align="center">
    A full-stack (React/Redux-Saga, ASP.NET Core, MS SQL Server) Movie Poster Review App
  </p>
</p>

## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started-seedling)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage-rice_scene)
* [Roadmap](#roadmap-tent)
* [License](#license)


## About the Project
__Hilbert__  is the one-stop community for movie poster enthusiasts. 
* Come by for a casual perusal! :movie_camera: 
* Leave a fanatic review! :sparkles: 
* Contribute your own movie poster! :space_invader::city_sunrise::clapper::100:

_This project is made from scratch for demonstration and educational purposes. Please feel free to leave comments for improvements or fork it for your own repurposing!_

_Overall structure_:

* __Server__: ASP.NET Core RESTful service layer with Entity Framework Core ORM and Swagger API Spec
* __Front-end__: SPA-style front-end with React, Redux-Saga, Webpack, Babel, Typescript, Flexbox, Bootstrap, React Router, and Cloudinary CDN
* __Database__: MS SQL Server 2017 persistent database running on a Docker container

### Built With
| Server | Front-end | Database | Tooling |
| ---  | --- | --- | --- |
[ASP.NET Core MVC][ASP.NET Core MVC URL]|[React][React URL]|[MS SQL Server][SQL Server URL]|[VS Code][VS Code URL]
[MS EF Core][EF Core URL]|[Redux][Redux URL]|[Docker][Docker URL]|[Azure Data Studio][Data Studio URL]
| | [Redux-Saga][Redux-Saga URL] | |[Swagger][Swagger URL]|
| | [Webpack][Webpack URL] | | |
| | [Babel][Babel URL] | | |
| | [TypeScript][TypeScript URL] | | |
| | [SCSS][SCSS URL] | | |
| | [Bootstrap][Bootstrap URL] | | |
| | [Cloudinary][Cloudinary URL] | | |


## Getting Started :seedling:

### Prerequisites

* [Node](https://nodejs.org/en/) installed.
* [.NET Core 2.2.0](https://dotnet.microsoft.com/download) installed.
* [Docker][Docker URL] installed.
* [MS SQL Server image: 2017-latest][SQL Server Image URL] in Docker repo.
```bash
# Retrieve DB image
docker pull mcr.microsoft.com/mssql/server:2017-latest

# Set up DB server (Docker Quickstart Terminal can tell you the IP address of your virtual machine)
docker run -e 'ACCEPT_EULA=Y' \
-e 'SA_PASSWORD=Passw0rd!' \
-p 1433:1433 \
--name movie-posters-db \
-d microsoft/mssql-server-linux:2017-latest
```

### Installation

___*Note: DB ConnectionString is hardcoded in this project. For deployment, consider encrypting in a config file or environment variable.___
1. Clone the repo
```bash
https://github.com/chaua0927/movie-posters.git
```
2. Install EF Core 2.2.0
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 2.2.0
```
3. Install NPM packages.
```bash
npm install
```

<!-- USAGE EXAMPLES -->
## Usage :rice_scene:
```bash
#To run db container, syntax is for Docker Toolbox
docker container start movie-posters-db

#To run webserver at localhost:5000 and :5001
dotnet run

#To stop db container when finished
docker container stop movie-posters-db

```

<!-- ROADMAP -->
## Roadmap :tent:

### User Features
- [x] View List of Movie Posters
- [ ] Base UI Design + Icon
- [ ] Add Animations/Transitions
- [ ] CRUD Movie Posters 
- [ ] CRUD Comments
- [ ] Movie Poster Search
- [ ] Account Management

### Backend Features
- [x] Fundamental stack set-up (React with Webpack and Babel, ASP.NET CORE, EF Core, MS SQL Server on Docker)
- [x] Add [React] Bootstrap
- [x] Add React Router + React-Router-Bootstrap
- [x] Migrate to Redux + Redux-Saga
- [ ] Implement reverse proxy server (Nginx)
- [x] Implement Swagger API spec
- [x] Migrate poster image to Cloudinary CDN

### Technical Fixes
- [x] SPA: History API fallback
- [ ] API: Complete API search capabilities
- [ ] API: Lagging DB nav prop refs?
- [ ] TS: Fix react-redux connect() typing (potential solution [here](https://gist.github.com/JaSpr/502084fd5989b53760d93148cf67d864))
- [ ] a11y: Carousel (indicators and auto-scroll control)
- [ ] a11y: Star Ratings

### Optimizations
- [ ] Implement lazy-loading
- [ ] Individually import Bootstrap plugins *Needs exports-loader
- [ ] Implement pagination of DB access
- [ ] Implement UUIDs for DB entries
- [ ] SPA: Gradually integrate SSR
- [ ] Optimize Redux state slice allocation, via combineReducers?
- [ ] SPA: More graceful error-handling from server errors?
- [ ] SCSS: Organize animations as mixins

### Dev Environment
- [x] Set up source maps + HMR
- [ ] Set up BDD/TDD: Cucumber + Selenium + Jest
- [x] Set up SCSS env (minifying, autoprefixer)
- [x] Migrate to Typescript

## License

Distributed under the MIT License.

All images are intended for non-commercial entertainment and education use only - reviews, fan art, blogs, forums, etc. MoviePosterDB is not endorsed, sponsored or affiliated with any movie studio. All copyrights, trademarks, and logos are owned by their respective owners. This site is for non-profit/educational use only. Using images from this project to make and/or sell reprinted movie posters is strictly forbidden.

[SQL Server URL]: https://www.microsoft.com/en-us/sql-server/default.aspx
[SQL Server Image URL]: https://hub.docker.com/_/microsoft-mssql-server
[EF Core URL]: https://docs.microsoft.com/en-us/ef/core/
[ASP.NET Core MVC URL]: https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-2.2
[React URL]: https://reactjs.org
[Redux URL]: https://redux.js.org
[Redux-Saga URL]: https://redux-saga.js.org
[Webpack URL]: https://webpack.js.org
[Babel URL]: https://babeljs.io
[Docker URL]: https://www.docker.com
[Data Studio URL]: https://docs.microsoft.com/en-us/sql/azure-data-studio/what-is?view=sql-server-2017
[VS Code URL]: https://code.visualstudio.com
[TypeScript URL]: https://www.typescriptlang.org
[SCSS URL]: https://sass-lang.com/
[Bootstrap URL]: https://getbootstrap.com
[Swagger URL]: https://swagger.io
[Cloudinary URL]: https://cloudinary.com

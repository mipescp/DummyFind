<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://ibb.co/r0zgpdT"
>
    <img src="https://ibb.co/r0zgpdT" width="80" height="80">
  </a>

<h3 align="center">DummyFind</h3>

  <p align="center">
    An api to find stuff on dummyjson api :)
    <br />
    ·
    <a href="https://github.com/mipescp/DummyFind/issues">Report Bug</a>
    ·
    <a href="https://github.com/github_username/repo_name/issues">Request Feature</a>
  </p>
</div>

<!-- ABOUT THE PROJECT -->
## About The Project

In this application, you'll interact with the dummy API, store user data in a PostgreSQL database using Entity Framework, and perform queries on the data.

We have the initial goal to create two console application with the following features:

1.Application (Console Application)

a. Create a PostgreSQL table to store some user data (UserId, number of user posts,
number of user todos).
	i This data comes from filtering the API for Posts with at least one reaction
	and have history tag.
	Expect to use Entity framework for this.

b. Perform some queries:
	i Find the Users with more than 2 posts and show their todo's.
	ii Finds Users that uses “mastercard” as their cardtype and retrieve their
	posts.
	


2nd Application (Console Application)

a. Create a PostgreSQL to store Posts (PostId, UserName, hasFrenchTag,
hasFictionTag, hasMorethanTwoReactions). Please use an Entity framework for
this.

## Approach to solution

After reading the exercise test, we found the requirements to be loosely attachted to each other, which raised some initial confusion on what's the real reason
behing the two applications and how do they relate.

1st Understanding:
Migrate all the three entities (posts, users and todo's) to our PostgreSQL database, adding some additional tables (being one of them the requested user data table).
After that, we would run queries against the database to leverage the requested data.

2nd Understanding:
Create tables per entity, as well as the additional table requested on the exercise. As we perform queries to the api, we would keep storing that information to the
database. Use some sort of memoization in order to prevent unecessary calls to the api, storing the queries results as we go. 
So when the application receives a query, it would first search on the database (or even memory, setting up a IDistributedCache from .NET), and only if it didn't find any result, query the api.

3rd Understanding:
Keep-it-simple. We create the PostgreSQL databases as requested, and keep more focus on projects definition, on how they relate to each other and code reusability (DRY).
Also keep in mind the responsability segregation, leverage some unit tests. The application would first query the api's as requested, and save the results on those databases.
We can then leverage of the information initially gathered to save some calls to the api, making our application more performant.

So for our project, we went with the <b>3rd understanding</b>.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


### Built With

* ASPNetCore
* Entity Framework
* PostgresSql

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Arquitecture

For this project we tried to use a simplified version of Clean Arquitecture.

<div align="center">
  <a href="https://ibb.co/gdZr5sm">
    <img src="https://ibb.co/gdZr5sm" width="80" height="80">
  </a>

<b> Persistance (Enterprise Business Rules) </b>
Is where the Database entities and context live. 
If we need additional databases sources, they should be created on this project.

<b>  Clients/Repositores (Middleman) </b>
This is the interface layer, used to create an abstraction of the Persistance, or access external dependencies

<b>  Services/Handlers (Application Business Rules) </b>
This is where all the business logic should be.

<b> Application (Interface adaptors) </b>
This is where the interface to the outer world should be. We are using console apps to simulate client requests but we could easily replace
by a rest api and start serving websites for example.

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/github_username/repo_name.git
   ```
2. Setup start-up project (either DummyFind.FirstConsoleApp or DummyFind.SecondConsoleApp)
3. Run the console application

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- ROADMAP -->
## Roadmap

- [ ] Add Unit tests for code coverage
- [ ] Add Memoization (caching) to prevent unecessary calls.
- [ ] Add ErrorHandling Middleware and custom exceptions
    - [ ] Create Business Exceptions to all required business exception rules.
- [ ] Deploy do AWS using AWS CDK https://docs.aws.amazon.com/cdk/v2/guide/work-with-cdk-csharp.html


See the [open issues](https://github.com/mipescp/DummyFind/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[ASPNetCore]: https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg
[ASPNetCore-url]: https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0
[PostgreSQL]: https://miro.medium.com/v2/resize:fit:828/0*epnKnkKuLx2RAajt
[PostgreSQL-url]: https://www.postgresql.org/

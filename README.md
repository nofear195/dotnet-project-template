# Dotnet project template

## Tools used

- Swagger/OpenAPI:
    - Swagger is a tool that allows you to describe your API in a human-readable format. This can be helpful for documentation and testing. OpenAPI is a standard that Swagger uses to describe APIs.
- Dapper:
    - Dapper is a micro-ORM that allows you to easily work with data in your project by mapping objects to tables in a database.
- PostgreSQL:
    - PostgreSQL is an open-source relational database management system.

## Features
- Combined classic dotnet MVC project with dotnet API project:
    - This allows you to create a single project that can be used for both a web application and a web API.
- Encapsulated Dapper for easier use:
    - This makes it easier to use Dapper in your project by providing a simplified API.

## To-do items
- Add Login/Logout function:
    - This will allow users to log in and out of your application.
- Add verification functions, like JWT, OAuth2.0 and OpenID Connect:
    - This will allow you to verify the identity of users before they are allowed to access your application.
- Add classification of how logs are running and record logs to database:
    - This will allow you to track errors and performance issues in your application.
- Use Redis to improve application performance:
    - Redis is a in-memory data store that can be used to improve the performance of your application.
- Try NoSQL database like MongoDB:
    - NoSQL databases are a good choice for applications that need to store large amounts of data or data that does not fit well into a traditional relational database.
- Try ELK (Elasticsearch, Logstash, and Kibana):
    - ELK is a popular logging stack that can be used to collect, store, and analyze logs from your application.
- Try OData:
    - OData is an open protocol that allows you to expose data from your application in a standardized way.


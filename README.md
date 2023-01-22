# OnlineShop
The main purpose of this project showing communication between microservices. As in the basic approach of microservice architecture,
all microservices work independently and not affect each other. With this approach all of them can deploy independently. 
The project is built with onion infrastructure.

## Used Technologies
* .Net 6
* Entity Framework Core
* PostgreSQL
* Mongo
* RabbitMq
* Elasticsearch
* Kibana
* Redis
* Docker - Docker Compose

## Prerequities

You will need the following tools:

* [Visual Studio 2022](https://www.visualstudio.com/downloads/) 
* [.Net 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
* [Docker Compose](https://docs.docker.com/compose/)

# How to Use
 After opening Command Prompt, go to the directory where docker-compose file is located and run the code below.
```
 CMD>docker-compose up -d

 ```

# Project Infrastructure

First of all, the infrastructures to be used in the core part of the project are located in the relevant main classes.
Application and persistence layers are coded separately for each service.
Eventbus infrastructure was created in the project. In this structure, masstransit and rabbitmq are used. 
Separate repositories has been created for reading and command structures in the webapi layer. In this way, read and write operations can be separated when necessary.
Redis lock is used for synchronization error that may occur in APIs.
Elasticsearch is used for reflection data to be presented to external systems, also used for log management with elasticsearch kibana.


<img width="600" alt="project" src="https://user-images.githubusercontent.com/1053221/213923042-b72dc5bd-f7a2-4b72-a456-fe836a8f0fb2.PNG">

The project consists of main three entities. _Product, Customer and Order._ OrderApi and CustomerApi work with _Postgresql_. 
ProductApi works with _MongoDb._ Databases of all APIs can work separately and independently from each other.
All APIs are coded with CQRS pattern. 

<img width="600" alt="project" src="https://user-images.githubusercontent.com/1053221/213924390-6034dd3c-c65a-46f6-b10b-a46628512dbf.png">

The relationship between all entities is shown in the picture above. 
After the Product and Customer registration processes are completed, order registration can be done.
If the order registration is successful, a separate event is created and the order data is sent to the reflection service.
Reflection service allows us to both process the data and present it securely in a separate place from the main data.
External api can serve data to external clients quickly and securely.

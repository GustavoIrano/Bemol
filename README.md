# Bemol app

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Run Bemol App

- Open project in visual studio 2019
- Set docker-compose as a startup project
- Click on run Docker Compose
- ✨Magic ✨

Access applications

- After running the application, the web application will open in your browser at localhost: 49751
- To see the new customer map application, access your localhost browser: 5101
- To view the data from the ConsumerMessage console application, open the visual studio exit window

Application step by step

- In the web application register a new user
- After registering the user, the ConsumerMessage application will show in the output window the name of the registered user
- After registering the user, the WebMapNewCustomer application will mark the location of the user's address on the map

## Installation

Bemol App requires [Docker](https://www.docker.com) and [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/) to run.

## About Solution

- ### bemol.App (MVC Application)
    +  AutoMapper
    +  EF Core Tools
    +  RabbitMQ

- ### bemol.Business
   + FluentValidation

- ### bemol.Data
   + EF Core
  
- ### bemol.CostumerMessage (Console Application)
  + RabbitMQ
   
- ### bemol.WebMapNewCustomers (MVC Application)
  + Newtonsoft.json
  + RabbitMQ
   
   
  



# Calculator-demo

Calculator demo is a project in Angular and Azure using the best practice of development and architecture.

## Functional Requirements

Create a simple calculator as a web application where having two numbers you can calculate basic math operations (Addition, Subtraction, Multiplication and Division).

## Non-Functional Requirements

Compliance with the following requirements:

- Reactive web application
- Securing the web application request
- Persist the results
- Real-time communication

## Restrictions

Use Azure as a cloud provider and web application in Angular.
Send a message to a queue on Azure Service Bus and compute the math operation in an Azure Functional Application with Dotnet stack and C# language, then save the result to an Azure SQL Database Server and callback the result to the web application using SingalR.
Create 4+1 Views to document the Architecture.
Also, create a Data flow diagram and Sequence Diagram.

## Resoruces (folders)

- architecture: [Architecture documentation](https://github.com/graigluque/calculator-demo/tree/master/architecture).
- angular-app: Angular Single Page Application code.
- function-app: Azure Functions App code in Dotnet Core 6.0 and C# language.
- azure-resource-template: Azure template for cloud resources.
- database-scripts: Scripts to create table and stored procedure.

## Public resources

- GitHub project: https://github.com/graigluque/calculator-demo
- Web application on live: https://glc-calculator-demo-webapp.azurewebsites.net/

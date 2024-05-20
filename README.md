# Creating Rest API using Azure functions (Isolated Process)
This project demonstrates a solution that creats REST API to perform CRUD operation on SQL Database.

## Business Objective
This project is for learning purpose. It helps with kick start the Rest API creation using Azure serverless integration services.

## Solution
Create a new solution(Azure fuction app) in visual studio.
Add required functions to the solution and write your backend logics for the same.
![Solution.jpg](Images/Solution.jpg)
## Connection
To test it locally define the sql conenction url in the local.settings.json file.
To test it on Azure, set this connection in Environment variables>App setting
![SqlConnectionString-LocalSettings.jpg](Images/SqlConnectionString-LocalSettings.jpg)

## Test APIs locally
Test it locally before publishing it to the cloud.
![test-api-at-local.jpg](Images/test-api-at-local.jpg)

## Configuration required for deployment and access:
1. Create function app from Azure portal and allow basic authentication, so that Visual studio can deploy to your function app in Azure cloud
2. Enable system assigned managed identity for the function app created.
3. Create a secerete in azure key vault for Azure SQL connection URL
	a. Assign contributer role to the function app
	b. Assign get,list secrete access policy to the function app

## Security aspects
Make sure to protect your functions with function key.
Allow only selected Vnet and IP address. It can be configured in function App>settings>Networking

## Pulish to Azure Cloud
Once tested locally, code can be puashed to the cloud.
Select you azure account, subscription and function app to create publish profile.
Push the code after creating publish profile.
![PublishChangesToAzure.jpg](Images/PublishChangesToAzure.jpg)
![PublishPush.jpg](Images/PublishPush.jpg)

## Sql Connection setting
Define Sql Connection string in App setting (Get connection url from Key Vault)

![SqlConnAppSetting.jpg](Images/SqlConnAppSetting.jpg)

## Test APIs at Portal
Test GetOrderItem
![TestGetOrderFromAzurePortal.jpg](Images/TestGetOrderFromAzurePortal.jpg)
Test AddOrderItem
![TestAPIAddOrderItem.jpg](Images/TestAPIAddOrderItem.jpg)
Order Added to SQL DB
![OrderAddedToSqlDb.jpg](Images/OrderAddedToSqlDb.jpg)

## Conclusion and Limitation
This project is having basic details. we can add validation and business logics as per the requirenment.
We can create APIM end points pointing to azure function for better security and scalibility.
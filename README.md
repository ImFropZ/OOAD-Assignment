# Year 4 - Assignment for OOAD

## Requirement for assignment

- Web API
- Console
- WinForm
- Database : Relational Database
  - MySQL
  - PostgreSQL
  - Etc

## Introduction

- Topic : **SMALL INVENTORY SYSTEM**

- Description : An Inventory System is a set of processes, tools, and technologies used by businesses and organizations to manage and track their inventory or stock items. Inventory refers to the goods and materials a business holds for the purpose of resale, production, or other business operations.

- Requirement

  - Functional Requirements:

    - CRUD Operations:
      Create, read, update, and delete operations for inventory items.
    - Item Information:
      Store item details such as ID, name, description, quantity, price, and category.
    - Supplier Information:
      Maintain supplier details including name, contact information, etc.
    - API Endpoints:
      Implement API endpoints for each CRUD operation.
    - CLI Commands:
      Implement commands for listing items, adding items, updating item details, and deleting items.
    - Validation:
      Validate input data to ensure it meets the required criteria (e.g., non-negative quantity, valid price).
    - Error Handling:
      Handle errors gracefully, providing meaningful error messages to users.

  - Non-Functional Requirements:

    - Data Integrity:
      Ensure data integrity by handling concurrent requests and avoiding data inconsistencies.
    - Scalability:
      Design the system in a way that allows it to scale if the inventory grows significantly.
    - Documentation:
      Provide clear and comprehensive documentation for your API and CLI commands.
    - User Interface:
      If time permits, create a simple web interface to interact with the inventory system visually.

  -  Additional Features (Optional, for Advanced Projects):

    - Search and Filters:
      Allow users to search for items and filter items based on various criteria.
    - Transaction History:
      Maintain a record of item transactions (sales, restocking) for auditing purposes.
    - Notifications:
      Implement notifications for low stock items or other relevant events.
    - Reports:
      Generate reports, such as sales reports or inventory valuation reports.
    - User Roles and Permissions:
      Implement user roles (admin, regular user) and permissions to restrict certain actions.
    - Analytics:
      Integrate analytics to gain insights into inventory trends and patterns.

## Model

In this models:
- Each products can have only one supplier
- Each supplier can have 0 or more products
So we can say that our relation of this 2 models are one-to-many relation ship

### Product

| Field      | Type   | KEY | Required?          |
| ---------- | ------ | --- | ------------------ |
| ID         | INT    | PK  | :heavy_check_mark: |
| SupplierID | INT    | FK  | :heavy_check_mark: |
| Name       | STRING |     | :heavy_check_mark: |
| Quantity   | INT    |     | :heavy_check_mark: |
| Price      | MONEY  |     | :heavy_check_mark: |
| Categories | STRING |     | :heavy_check_mark: |

:warning: **NOTE** : 

- You can make the categories have multiple value by seperate it by comma(,)
- SupplierID is the foreign key(FK) from Supplier model 

### Suppiler

| Field               | Type   | KEY | Required?          |
| ------------------- | ------ | --- | ------------------ |
| ID                  | INT    | PK  | :heavy_check_mark: |
| Name                | STRING |     | :heavy_check_mark: |
| Contact Information | STRING |     | :heavy_check_mark: |

## API - ENDPOINT

### PRODUCT

| METHOD | ENDPOINT           | Params     | Body          | Response                |
| ------ | ------------------ | ---------- | ------------- | ----------------------- |
| GET    | /api/products      |            |               | Result<List<Product>>   |
| GET    | /api/products/{id} | id: String |               | Result<Product?>        |
| POST   | /api/products      |            | Product       | Result\<Product?>       |
| PUT    | /api/products      |            | List\<Product> | Result\<List\<Product>> |
| PATCH  | /api/products/{id} | id: String | Product       | Result\<Product?>       |
| DELETE | /api/products/{id} | id: String |               | Result\<Bool>           |

### SUPPILER

| METHOD | ENDPOINT            | Params     | Body           | Response                 |
| ------ | ------------------- | ---------- | -------------- | ------------------------ |
| GET    | /api/suppilers      |            |                | Result<List<Supplier>>   |
| GET    | /api/suppilers/{id} | id: String |                | Result<Supplier?>        |
| POST   | /api/suppilers      |            | Supplier       | Result\<Supplier?>       |
| PUT    | /api/suppilers      |            | List\<Supplier> | Result\<List\<Supplier>> |
| PATCH  | /api/suppilers/{id} | id: String | Supplier       | Result\<Supplier?>       |
| DELETE | /api/suppilers/{id} | id: String |                | Result\<Bool>            |

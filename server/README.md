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

### Result

| Field   | Type          |
| ------- | ------------- |
| Success | bool          |
| Message | String        |
| Data    | (GenericType) |

## API - ENDPOINT

### PRODUCT

| METHOD | ENDPOINT           | Params     | Body           | Response                |
| ------ | ------------------ | ---------- | -------------- | ----------------------- |
| GET    | /api/products      |            |                | Result\<List\<Product>> |
| GET    | /api/products/{id} | id: String |                | Result<Product?>        |
| POST   | /api/products      |            | Product        | Result\<Product?>       |
| PUT    | /api/products      |            | List\<Product> | Result\<List\<Product>> |
| PATCH  | /api/products/{id} | id: String | Product        | Result\<Product?>       |
| DELETE | /api/products/{id} | id: String |                | Result\<bool>           |

### SUPPILER

| METHOD | ENDPOINT            | Params     | Body            | Response                 |
| ------ | ------------------- | ---------- | --------------- | ------------------------ |
| GET    | /api/suppilers      |            |                 | Result\<List\<Supplier>> |
| GET    | /api/suppilers/{id} | id: String |                 | Result<Supplier?>        |
| POST   | /api/suppilers      |            | Supplier        | Result\<Supplier?>       |
| PUT    | /api/suppilers      |            | List\<Supplier> | Result\<List\<Supplier>> |
| PATCH  | /api/suppilers/{id} | id: String | Supplier        | Result\<Supplier?>       |
| DELETE | /api/suppilers/{id} | id: String |                 | Result\<bool>            |

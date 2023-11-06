## Model

### ERD

![ERD](./Assets/SmallInventorySystem.jpg)

As you can see from above the system has 2 tables Suppliers and Products.  
In this model:
- Each product can have only one supplier
- Each supplier can have 0 or more products

So we can say our relation between these 2 tables are one-to-many relationship

### Product

| Field      | Type    | Required?          |
| ---------- | ------- | ------------------ |
| ID         | STRING  | :heavy_check_mark: |
| SupplierID | STRING  | :heavy_check_mark: |
| Name       | STRING  | :heavy_check_mark: |
| Quantity   | INT     | :heavy_check_mark: |
| Price      | DECIMAL | :heavy_check_mark: |
| Categories | STRING  | :heavy_check_mark: |

:warning: **NOTE** :

- You can make the categories have multiple values by separating them by commas (,)

### ProductCreated

| Field      | Type    | Required?          |
| ---------- | ------- | ------------------ |
| SupplierID | STRING  | :heavy_check_mark: |
| Name       | STRING  | :heavy_check_mark: |
| Quantity   | INT     | :heavy_check_mark: |
| Price      | DECIMAL | :heavy_check_mark: |
| Categories | STRING  | :heavy_check_mark: |

This model is used to create the product data.
As you can see from the table, we have SupplierID then we will check if the supplier exists.

### ProductUpdated

| Field      | Type    | Required? |
| ---------- | ------- | --------- |
| ID         | STRING  |           |
| SupplierID | STRING  |           |
| Name       | STRING  |           |
| Quantity   | INT     |           |
| Price      | DECIMAL |           |
| Categories | STRING  |           |

This model is used to update the product data.
ID can be required or not depending on the method you using in the endpoint below.
If we want to update the list of products we will need an ID for each product but if we update a specific product we can use a patch to update it without an ID for ProductCreated.

### Supplier

| Field              | Type   | Required?          |
| ------------------ | ------ | ------------------ |
| ID                 | INT    | :heavy_check_mark: |
| Name               | STRING | :heavy_check_mark: |
| ContactInformation | STRING | :heavy_check_mark: |

### SuppilerCreated

| Field              | Type   | Required?          |
| ------------------ | ------ | ------------------ |
| Name               | STRING | :heavy_check_mark: |
| ContactInformation | STRING | :heavy_check_mark: |

This model is used to create the supplier data.

### SuppilerUpdated

| Field              | Type   | Required? |
| ------------------ | ------ | --------- |
| ID                 | STRING |           |
| Name               | STRING |           |
| ContactInformation | STRING |           |

This model is used to update the supplier data.
ID can be required or not depending on the method you using in the endpoint below.
If we want to update the list of suppliers we will need an ID for each supplier but if we update a specific supplier we can use a patch to update it without an ID for SupplierCreated.

### Result

| Field   | Type          |
| ------- | ------------- |
| Success | BOOLEAN       |
| Message | STRING        |
| Data    | (GenericType) |

The resulting model is the response type from API with generic data depending on the response from the endpoint.

## API - ENDPOINT

### PRODUCT

| METHOD | ENDPOINT           | Params     | Body                  | Response                | Description          |
| ------ | ------------------ | ---------- | --------------------- | ----------------------- | -------------------- |
| GET    | /api/products      |            |                       | Result\<List\<Product>> | Get all products     |
| GET    | /api/products/{id} | id: String |                       | Result<Product?>        | Get product by id    |
| POST   | /api/products      |            | ProductCreated        | Result\<Product?>       | Create new product   |
| PUT    | /api/products      |            | List\<ProductUpdated> | Result\<List\<Product>> | Edit products        |
| PATCH  | /api/products/{id} | id: String | ProductUpdated        | Result\<Product?>       | Edit product by id   |
| DELETE | /api/products/{id} | id: String |                       | Result\<bool>           | Delete product by id |

### SUPPLIER

| METHOD | ENDPOINT            | Params     | Body                   | Response                 | Description           |
| ------ | ------------------- | ---------- | ---------------------- | ------------------------ | --------------------- |
| GET    | /api/suppliers      |            |                        | Result\<List\<Supplier>> | Get all suppliers     |
| GET    | /api/suppliers/{id} | id: String |                        | Result<Supplier?>        | Get supplier by id    |
| POST   | /api/suppliers      |            | SupplierCreated        | Result\<Supplier?>       | Create new supplier   |
| PUT    | /api/suppliers      |            | List\<SupplierUpdated> | Result\<List\<Supplier>> | Edit suppliers        |
| PATCH  | /api/suppliers/{id} | id: String | SupplierUpdated        | Result\<Supplier?>       | Edit supplier by id   |
| DELETE | /api/suppliers/{id} | id: String |                        | Result\<bool>            | Delete supplier by id |

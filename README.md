# StockCareV2

## Entities

### Product

| Property Name | Data Type   | Description                                           |
| ------------- | ----------- | ----------------------------------------------------- |
| Id            | Guid        | Product id                                            |
| Name          | string      | Name of the product                                   |
| Price         | double      | Price of the product                                  |
| Unit          | Enum        | Unit of the product                                   |
| PackageSize   | int         | Package size of the product                           |
| Quantity      | int         | Quantity of the product for handling at Health Center |
| MinStockLevel | int         | Min. stock level before alert to order more           |
| IsActive      | bool        | Status of the product, is active or discontinued      |
| LastUpdated   | DateTime    | Date when item was last updated                       |
| Suppliers     | ICollection | List of all the suppliers that supply the product     |
| ProductOrders | ICollection | List of all Orders for the product                    |

### Order

| Property Name | Data Type   | Description                                        |
| ------------- | ----------- | -------------------------------------------------- |
| Id            | Guid        | Order id                                           |
| StockId       | Guid        | Id of the stock that supply products for the order |
| User          | User        | User that places the order                         |
| double        | OrderSum    | Total for the order                                |
| OrderProducts | ICollection | List of products for the order                     |

### Supplier

| Property Name   | Data Type   | Description                |
| --------------- | ----------- | -------------------------- |
| Id              | Guid        | Supplier id                |
| Name            | string      | Name of the supplier       |
| QuantityOnStock | int         | Quantity at supplier stock |
| Orders          | ICollection | List of orders             |
| Products        | ICollection | List of products at stock  |

### User

| Property Name | Data Type   | Description                    |
| ------------- | ----------- | ------------------------------ |
| Id            | Guid        | Id of the user                 |
| FirstName     | string      | First name of user             |
| LastName      | string      | Lastname of user               |
| UserName      | string      | Username                       |
| Email         | string      | Email                          |
| Orders        | ICollection | List of orders user has placed |

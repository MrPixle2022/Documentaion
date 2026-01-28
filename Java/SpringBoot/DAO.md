# DAOs

`Data access objects` -aka DAOs- are a layer added between the services and the database, they expose certain functionalities while hiding the implementation.

to create a `DAO` do as follows:

1. define a class representing your model
1. define an interface with methods to access the table
1. define an implantation class of the interface that functions using `jdbc template`

that is it.

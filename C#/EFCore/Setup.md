# Setup

```csharp

```

---

## Connection string

the `connection string` is usually held in the `appsettings.json` file or any configurations file which must be embedded with the assembly.

the connection string differs by the database but it's syntax is the same:

```text
"key1: value; key2: value2;"
```

here are some examples:

```json
connectionStrings:{
  postgres: "Host=<host>;Username=<username>;Password=<password>;Database=<db_name>",
  sqlite3: "Data Source=database.db;Version=3;",
  mssql: "Server=<server name>; Database=<db_name>; Integrated Security = SSPI;"
}
```
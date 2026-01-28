# DB connection

- Db driver > allows you to use java code to interact with a specific database
- JDBC and Spring JDBC > java-data-base-connectivity allows you to use SQL, but it too low-level
- JPA and Spring Data JPA > JPA allows you to use java objects to interact with database, high-level
- Hibernate > ORM

in the resources file we can create `2 sql` files:

1. schema.sql: defines the schema of your database
1. data.sql: populates your database with data

bur for these 2 to work set the `spring.sql.init.mode` to `always` in the configuration file.

---

## H2 in-memory database

to connect to an `H2-IMDB` include the driver dependency and `JDBC APi`.

now add the connection configuration:

```properties
spring.datasource.url=jdbc:h2:mem:testdb
spring.datasource.driverClassName=org.h2.Driver
spring.datasource.username=sa
spring.datasource.password=password
```

---

## Postgresql

install the `PostgreSQL` driver and the `JDBC API`, if it was included at the project generation a `.docker` file will be included which will run a postgres image.

setup the configuration as:

```properties
spring.datasource.url=jdbc:postgresql:url-to-db
spring.datasource.username=postgres
spring.datasource.password=postgres
```

---

## Connection example

```properties
spring.datasource.url=jdbc:postgresql://localhost:5432/TestDb
spring.datasource.username=postgres
spring.datasource.password=postgres
spring.datasource.driver-class-name=org.postgresql.Driver
spring.sql.init.mode=always
```

```java
@SpringBootApplication
public class DemoApplication implements CommandLineRunner {

	private final DataSource ds;

  //DataSource object will be injected
	public DemoApplication(DataSource ds) {
		this.ds = ds;
	}

	public static void main(String[] args) {
		SpringApplication.run(DemoApplication.class, args);
	}

	@Override
	public void run(@NotNull final String... args) throws Exception {
		JdbcTemplate template = new JdbcTemplate(ds);
		//Void method, executes the given sql query
    template.execute("INSERT INTO users (username, email, pwd) VALUES ('amr', 'amr@test.com', 'hello');");
		System.out.println("SELECTING ALL USERS");
	}
}
```

# Configuration

in a spring boot maven project configuration is done through a `src/main/resource/application.properties/yaml` file.

---

## Spring config

in the config file we can change many things like:

- server.port: the port at which the server listens
- spring.datasource.url: the url to the database
- spring.datasource.driverClassName: the class name of the db driver
- spring.datasource.username: the username of the database
- spring.datasource.password: the password of the database

---

## Custom properties

we can load our own custom properties using the a configuration properties.

this can be done using `@ConfigurationProperties` annotation.

for example let's assume this is our config in the `application.yaml` file:

```yaml
course:
  mechanics:
    room-suffix: "B"
    max-students: 30
    enabled: true
```

we can access these values as follows:

```java
@Configuration
//read all course.mechanic keys
@ConfigurationProperties(prefix = "course.mechanics")
public class MechanicsProperties {
  private String roomSuffix;
  private int maxStudents;
  private boolean enabled;
}
```

however if we need a single value we can instead use the `@Value` annotation before a field:

```java
@Value("${course.mechanics.room-suffix}")
private String roomSuffix;
```

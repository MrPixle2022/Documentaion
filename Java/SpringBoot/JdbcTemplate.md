# JDBC template

---

## execute

`execute` is a void-returning method that runs the given sql command

---

## update

`update` is an int-returning method that updates a database, being creating, deleting, etc...

it returns the number of rows affected by the query

```java
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.AllArgsConstructor;

@Data //get/setName(), get/setEmail, ...
@AllArgsConstructor //public User(String name, String email, String password){}
@NoArgsConstructor //public User(){}
@Builder //objects are made through User.builder().name(val).email(val).password(val).build()
public class User {
  private String name;
  private String email;
  private String password;
}
```

```java
public int create(User user) {
  this.template.update(
    "INSERT INTO users(username, email, password) VALUES (?, ?, ?)",
    user.getName(),
    user.getEmail(),
    user.getPassword()
  );
  return 0;
}
```

---

## query

the `query` is a method that runs the given query and extract data from it using a `RowMapper<T>` method:

```java
//static inner class
public static class UserRowMapper implements RowMapper<User> {
  //rs => result set, rowNum => the row number
  public User mapRow(ResultSet rs, int rowNum) throws SQLException {
    User user = new User();
    user.setName(rs.getString("username"));
    user.setEmail(rs.getString("email"));
    user.setPassword(rs.getString("password"));
    return user;
  }
  }
```

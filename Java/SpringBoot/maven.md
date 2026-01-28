# Maven

maven is build tool that allows to use external dependencies in a project as will as compiling the code.

each maven project include a `./mvnw` which is a wrapper around maven which can be used if maven is not installed.

---

## Maven commands

- clean: removes the temps files -like the target-
- default: the default state
- site: where docs are generated

for clean the lifecycle goes as:

- pre-clean (hook): before-cleaning
- clean: the actual cleaning process
- post-clean (hook): after-cleaning

and for the default state it goes as follows:

- compile: compiles the project into bytecode file all inside the `target/` directory
- test: runs the unit test
- package: creates the `.jar/war` file
- verify: runs the integration tests

they run in order, starting from compile till it reaches the specified state:

```bash
# clean the target, then run unit-tests
mvn clean test
```

---

## Maven project structure

maven requires a predefined structure to be followed:

- src/main/java : app source
- src/main/resources: app resources(static files, etc...) and config
- src/test/java: test resources
- src/test/resources: test-only resources
- target/: where the compiled results are found
- pom.xml: the project object model XML file

---

## Run the app

we can run a spring boot app using:

```bash
mvn spring-boot:run
# or
mvn clean package
java -jar <path-to-jar>
```

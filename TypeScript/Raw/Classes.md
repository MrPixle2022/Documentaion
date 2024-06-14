# Classes:

typescript allows the usage of classes and extends their functionality significantly, to start create a class using the `class` keyword & create a new object by using the `new` keyword

```typescript
class Person {
  constructor(
    public readonly name: string, //readonly means that it is immutable
    public age: number,
    public nickname: string,
    protected lang: string = "js"
  ) {
    //public is the default visibility modifier, private(only accessible in the class) & protected(only accessible in the class & subclasses) are also available
    this.name = name;
    this.age = age;
  }
}

const amr = new Person("Amr", 17, "mr-pixel");
```

---

also classes can inherit each other, the class that inherits other classes is called a `subclass`.

you can inherit a class using the `extends` keyword.

```typescript
class Coder extends Person {
  constructor(
    public computer: string,
    name: string,
    age: number,
    nickname: string
  ) {
    super(name, age, nickname); //must call the super function to make a new instance of the parent class
    this.computer = computer;
  }

  public getLang() {
    return this.lang;
  }
}

const me = new Coder("hp-laptop", amr.name, amr.age, amr.nickname);
```

---

also classes can implement an `interface` using the `implements` keyword:

```typescript
interface Programmer {
  name: string;
  language: string;
  run(action: string): string;
}

class MyProgrammer implements Programmer {
  run(action: string): string {
    return `${this.name} is ${action}ing`;
  }

  constructor(public name: string, public language: string) {
    this.name = name;
    this.language = language;
  }
}
```

---

also classes can have `static` fields, they can only be called or read from the original class, you can set one by using the `static` keyword before the declaration & after the visibility modifier

```typescript
class ClassWithStaticFields {
  static count: number = 0;

  constructor() {
    ++MyProgrammer.count;
  }

  public static sayHi() {
    console.log(`hello from static function`);
  }

  public static getCount() {
    console.log(MyProgrammer.count);
  }
}

const o1 = new ClassWithStaticFields();
console.log(ClassWithStaticFields.count); //1
const o2 = new ClassWithStaticFields();
console.log(ClassWithStaticFields.count); //2
const o3 = new ClassWithStaticFields();
console.log(ClassWithStaticFields.count); //3

ClassWithStaticFields.sayHi();
```

---

a `private` field can have a getter & a setter function. use the `get` & `set` keywords for that.

```typescript
class Bands {
  private dataState: string[];

  constructor() {
    this.dataState = [];
  }

  public get data(): string[] {
    return this.dataState;
  }
  public set data(data: string[]) {
    this.dataState = data;
  }
}

const band = new Bands();
band.data = ["amr", "ali", "mohammed"]; //setter

console.log(`data: ${band.data}`); //getter
```

<!-- @format -->

# Setup:

install the required packages:

```bash
pnpm i @nestjs/mongoose mongoose
```

once complete import the `MongooseModule` from `@nestjs/mongoose` and add it to the imports of the app module and use the `MongooseModule.forRoot` method and pass it your mongodb uri

```typescript
import { Module } from "@nestjs/common";
import { AppController } from "./app.controller";
import { AppService } from "./app.service";
import { MongooseModule } from "@nestjs/mongoose";

@Module({
	imports: [MongooseModule.forRoot("mongodb-uri")],
	controllers: [AppController],
	providers: [AppService],
})
export class AppModule {}
```

---

## Creating schemas:

to create a schema create a new file, in that file create a class and decorate it with the `@Schema` decorator from `@nestjs/mongoose` and import `Prop` and `SchemaFactory`.

the `@Schema` tells nest that this class will be used to define a model, and the `@Prop` is used to define a filed and it's option like `required` & `default` like using mongoose, whilst the `SchemaFactory` will be used to generate the model from the class, note that you are required to provide the type:

```typescript
import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";

// options for the schema
@Schema()
export class User {
	@Prop({ type: String, required: true, unique: true })
	username: string;

	@Prop({ type: String, required: false })
	displayName: string | undefined;

	@Prop({ required: false, type: String })
	avatarUrl: string | undefined;
}

// here we create a schema and export the model
export const UserSchema = SchemaFactory.createForClass(User);
```

now in the users module import the class & the schema, and use the `MongooseModule.forFeature` to use in the not-root module, to this method we provide an array of object for each collection and model with two properties, the `name` of the collection & the `schema`, for the name we provide the base class -the one with @Schema-'s name and provide the exported model as the schema

```typescript
import { Module } from "@nestjs/common";
import { MongooseModule } from "@nestjs/mongoose";
import { User, UserSchema } from "src/Schemas/user.schema";

@Module({
	imports: [
		MongooseModule.forFeature([{ name: User.name, schema: UserSchema }]),
	],
})
export class UsersModule {}
```

---

## Creating a new document:

in the service file create a function to handle the creation, the document creation is a rather simple operation even simpler than the normal mongoose operation.

it's recommended first to create a create user dto file to describe and validate the fields required fot the user.

```typescript
import { IsString, IsNotEmpty } from "class-validator";

export class CreateUserDto {
	@IsString()
	@IsNotEmpty()
	username: string;

	displayname: string | undefined;
	avatarUrl: string | undefined;
}
```

then in the service file's class:

```typescript
async createUser(createUserDto: CreateUserDto) {
  // creates a new User document
  const newUser = new this.userModel(createUserDto);
  // saves the user into the collection
  return await newUser.save();
}
```

now last step is to create an endpoint in the controller and use the injected user service:

```typescript
@Post('new')
@UsePipes(new ValidationPipe())
createUser(@Body() newUser: CreateUserDto) {
  return this.userService.createUser(newUser);
}
```

---

## Reading documents:

we can read a document/s from the database easily using a similar approach with the user model:

for all users use:

```typescript
async getUsers() {
    const users = await this.userModel.find();
    return users;
  }
```

and to get one only:

```typescript
  async getUserById(id: string) {
    try {
      // checks if the given id is a valid object id, if not used will throw 500 server error
      if (!mongoose.Types.ObjectId.isValid(id))
        throw new HttpException('User not found', 404);

      const user = await this.userModel.findById(id);
      if (!user) throw new HttpException('User not found', 404);

      return user;
    } catch {
      console.log('something went wrong');
    }
    return null;
  }
```

note that we added a check for the id if it's valid, as if an invalid id was given it will crash the sever and send a **500** code.

now to the controller:

```typescript
@Get()
getUsers() {
  return this.userService.getUsers();
}

@Get(':id')
getById(@Param('id') id: string) {
  return this.userService.getUserById(id);
}
```

---

## Updating documents:

to update a user we can use the user model, by providing the id and the new data -and option `new: true` to return the new doc- in the service file

```typescript
async updateUser(id: string, user: UpdateUserDto) {
  if (!mongoose.Types.ObjectId.isValid(id))
    throw new HttpException('User not found', 404);

  return await this.userModel.findByIdAndUpdate(id, user, {new: true});
}
```

as we want to partially update the user document we can a **patch** request:

```typescript
// partially update
@Patch('update/:id')
@UsePipes(new ValidationPipe())
updateUser(@Body() newUser: UpdateUserDto, @Param('id') id: string) {
  return this.userService.updateUser(id, newUser);
}
```

---

## Deleting a document:

we can use the `findByIdAndDelete` method on the user model to remove the document with the given id:

```typescript
async deleteUser(id: string) {
  if (!mongoose.Types.ObjectId.isValid(id))
    throw new HttpException('User not found', 404);
  return await this.userModel.findByIdAndDelete(id);
}
```

and create a **delete** endpoint

```typescript
@Delete('remove/:id')
deleteUser(@Param('id') id: string) {
  return this.userService.deleteUser(id);
}
```

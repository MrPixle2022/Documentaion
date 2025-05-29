<!-- @format -->

# Passport authentication:

---

## JWT:

first install the required dependencies:

```bash
pnpm add -D @nestjs/passport passport
# then use
pnpm add -D @nestjs/jwt passport-jwt @types/passport-jwt
```

installing this gives us access to the `JwtModule` from `@nestjs/jwt` and register it in the auth module -if you have it- and call the `.register`:

```typescript
import { JwtModule } from "@nestjs/jwt";

@Module({
	imports: [JwtModule.register({})],
	providers: [AuthService],
	controllers: [AuthController],
})
export class AuthModule {}
```

now we can use the `JwtService` imported from `@nestjs/jwt` in the corresponding service:

```typescript
class AuthService {
	constructor(
		// if you have prisma set up
		private prisma: PrismaService,
		private jwt: JwtService,
	) {}
}
```

after registering and creating the service it's time for us to create the toke, for that we will create a new async function named `signToken` -name is optional- in our service:

```typescript
async signToken(userId: number, email: string) {
  const payload = { sub: userId, email };
  return {
    access_token: await this.jwt.signAsync(payload, {
      expiresIn: '15m',//expires after 15 minutes
      secret: this.config.get('SECRET'), //import the `SECRET` from the .env
    }),
  };
}
```

after this, we can move on to the `jwt` strategy configuration.

create a new file for the jwt strategy and insert the following:

```typescript
import { Injectable } from "@nestjs/common";
import { ConfigService } from "@nestjs/config";
import { PassportStrategy } from "@nestjs/passport";
import type { Request } from "express";
import { ExtractJwt, Strategy } from "passport-jwt";

@Injectable()
// PassportStrategy(strategy, name)
export class JwtStrategy extends PassportStrategy(Strategy, "jwt") {
	constructor(private config: ConfigService) {
		super({
			//jwt token will be extracted from the Authorization header `Bearer -token-
			jwtFromRequest: ExtractJwt.fromAuthHeaderAsBearerToken(),
			// the secret src -> env.SECRET
			secretOrKey: config.get("SECRET")!,
		});
	}

	// validate the token, called by guards
	async validate(payload: any) {
		return payload;
	}
}
```

notice the `'jwt'` provided to the `PassportStrategy` this is just a name we chose, to differentiate this strategy from others which will be helpful when using guards.

after all this is done we can import the strategy as a provider in the auth module -if you have it-

```typescript
@Module({
	imports: [JwtModule.register({})],
	providers: [AuthService, JwtStrategy],
	controllers: [AuthController],
})
export class AuthModule {}
```

the final step is using this with a guard. now nestjs already has a guard for passport that we can extend the functionality of or use directly:

```typescript
@Controller("users")
export class UserController {
	//guard for the strategy of name `jwt`
	@UseGuards(AuthGuard("jwt")) //we can also move it above the class to protect the entire controller
	@Get("me")
	getMe(@Req() request: Request) {
		console.log(request.user);
		return "hello, YOU";
	}
}
```

now with this users with no token will get a `401` **unauthorized** error, whilst those with it will get `hello, YOU`.

notice that we can access the `request.user`, but know that it's type is properly undefined.

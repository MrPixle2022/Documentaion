# Images

next js provides the `image` component as an optimized way to render images from the `public folder` or from the cloud.

by importing it from `next/image`

```typescript
import Image from "next/image";
```

you can use them to render optimized images, start by providing the `src` and `alt` props then chose to use `width, height` or fill.

with `width` & `height` you use hardcoded values while `fill` will scale the image dynamically to automatically fill the container.
> [!IMPORTANT]
> using the `fill` option requires a container with `position: relative`

also you can use:

- `quality`: give a integer between `[1(lowest), 100(best)]` to set the quality, def => 75

- `onLoad` : takes a function that accepts an `event` as a params, the function is executed once the image is loaded (only in client components)

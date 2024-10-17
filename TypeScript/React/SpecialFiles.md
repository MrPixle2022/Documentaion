# Special files

in next js there are the custom files that you can use to customize the behavior or the ui of the app in special cases.

---

## layout.tsx

the `layout.tsx` file is the file used to define the shared ui between the pages in one directory & their sub pages.

you are not limited to one, you can have as many as you need, however you are limited to **1 for each level**

layout example:

```typescript
import type { ReactNode } from 'react';

type LayoutProps = {
  children: ReactNode;
};

export default function Layout({ children }: LayoutProps) {

  return (
    <section className='w-screen h-screen bg-gray-300 text-black'>
      {children}
    </section>
  );
}
```

---

# Images:

## local images:

to use an image that is in the `public` folder you can use the `Image` components, it's next's alternative to the normal img tag, it automatically optimizes your image's size and boosts the performance.

the `Image` requires you to specify the `width` & `height` of the picture or replace them with the `fill` attribute, if used it will make the image fill it's container but the container must have a position of **relative**

```javascript
import Image from 'next/image'

function UserLog() {
  return (
    <div> 
      <Image src='/MyProfilePic.png' width={100} height={100}/>
      <div className='img-container'>
        <Image src='/MyProfilePic.png' fill/>
      </div>
    </div>
  )
}

export default UserLog
```

---

## remote images:

to download or use images from remote domains you have to specify these domains in the `next.config.mjs` file in the `images` obj.

the remote patterns takes an array of the domains you work with or else you will get an error

```javascript
/** @type {import('next').NextConfig} */
const nextConfig = {
  images: {
    remotePatterns: ['images.unsplash.com']
  }
};

export default nextConfig;

```

---

# Fonts:

next can work with almost every google font, to use one in your project import it from `next/font/google`.

in this example i'll be importing the roboto font.

when importing the font you make an instance of it, you pass it an object with the values of `subset` & `weight`, but the declaration must be out side the component.

then use the font instance's class name and assign it whatever element you want.

```javascript
import { Roboto } from 'next/font/google';

const roboto = Roboto({subsets:['latin'], weight: '500'});

function DataPage() {
  
  return (
    <div>
      <ul>
          <li className={roboto.className}>Robot Font</li>
          <li>Not robot Font</li>
      </ul>
    </div>
  )
}

export default DataPage
```

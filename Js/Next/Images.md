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
# Meta data:

next allows you to increase `SEO` using metadata, using the metadata you can set the title & description of each page.

you can use them simply like:

```javascript
export const metadata = {
  title: "blogs",
  description: "This is the description page."
}
```

or you can use a template, for example you can set your `layout.js`'s metadata to:

```javascript
export const metadata = {
  title: {
    default: "next-amr", 
    template: "%s | next-amr" // %s will be replaced by the page's metadata.title, for example "about | next-amr"
  },
  description: "the page of za pxl"
}
```
- `default`:  the value if the page doesn't export a metadata

another way is using the `generateMetadata` method:

```javascript
export async function generateMetadata({ params }) {
  const { slug } = params;
  const post = await getSinglePost(slug);
  console.log("🚀 ~ generateMetadata ~ post:", post)

  return { title: post?.title, description: post?.desc }
}
```

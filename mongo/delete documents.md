# delete docs:

to delete a document form your collection use:
- .deleteOne()
- .deleteMany()

`deleteOne({query})` is used to delete a single document from the collection whereas `deleteMany({query})` is used to remove multiple documents.

> [!CAUTION]
> passing `{}` to `deleteMany` will clear the collection
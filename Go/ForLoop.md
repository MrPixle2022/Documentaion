# For loop

the `for` is go's one and only loop structure, it's used to cover most uses of other loops.

```go
func main(){
    //infinite loop
    for{
        //code
    }

	//for range
	for i := range 100{
		fmt.Println(i); // 0 <= i < 100
	}

    //form4 (repeat 5 times)
    for range 5{
        //code
    }

	for i := 0; i < 5; i++{}

	//for (slices)
	for index, val := range slice{
		fmt.Printf("Index: %d, Value: %d\n", index, val);
	}

	//for maps
	for key, value := range myMap2 {
		fmt.Printf("Key: %s, Value: %d\n", key, value);
	}


	//for as while
	for len(slice) < 10{
		slice = append(slice, len(slice)+1);
	}
}
```

of course go also has `break` and `continue`

---

## Loop labels

in go we can give a label for a loop, this can be used with break and continue to target a specific part:

```go
outer:
	for i := 0; i < 10; i++ {
		for j := 0; j < 10; j++ {
			if j > 2*i {
				continue outer
			}
		}
	}
```

what this snippets does is whenever `j` -inner loop- is greater then 2 \* `i` -outer loop- we skip this iteration -continue affects the outer loop-

# Common data structures

---

## Dynamic arrays

regular arrays are fixed-in-size, though in languages like js and python an array is dynamic in size

what these languages actually do is they destroy and create a new array each time a new element is added, this is because the dynamic array or as it often called a `vector` has a header, including `size` or length which basically is the count or number of element **currently** in the array, and also we have `capacity` which is the max number of elements the array can hold before it overflows, when nearing the max capacity, the array will be reallocated to fit more element

```c
#include <stdlib.h>
#include <string.h>
#include <stdint.h>
#include "vector.h"

/// @brief A struct resembling a dynamic array
///@addtogroup Vector
struct Vector
{
  /// @brief the current length of the vector
  size_t size;
  /// @brief the max number of elements before reallocating the vector
  size_t capacity;
  /// @brief a pointer to the data of the vector
  void *data;
};

//* Functions

/// @brief initializes a new vector with the given initial capcity and element size
/// @param capacity the initial capacity of the vector
/// @param element_size the size of each element in the vector
/// @addtogroup Vector
/// @return a pointer to the newly created vector or `NULL`
struct Vector *vector_init(size_t capacity, size_t element_size)
{
  //allocating space for the vector, and checking if the vector has successfully been allocated
  struct Vector *vector = malloc(sizeof(struct Vector));
  if (vector == NULL)
    return NULL;

    //setting the size to 0, and setting the capacity
  vector->size = 0;
  vector->capacity = capacity;

  //attempting to allocate space for the internal array
  void *temp = malloc(capacity * element_size);
  if (temp == NULL)
  {
    //since we consider this a failure we free the vector to avoid memory leaks
    free(vector);
    return NULL;
  }

  vector->data = temp;
  temp = NULL;

  return vector;
}

/// @brief frees the allocated memory for the given vector
/// @param vector the vector to free
/// @returns void
/// @addtogroup Vector
void vector_free(struct Vector *vector)
{
  free(vector->data);
  free(vector);
}

/// @brief resizes the given vector to the new capacity
/// @param vector the vector to resize
/// @param new_capacity the new capacity of the vector, can be bigger or smaller but not <= 0
/// @param element_size the size of each element in the vector
/// @return status code, 0 if successful or 1 if not
/// @addtogroup Vector
int vector_resize(struct Vector *vector, size_t new_capacity, size_t element_size)
{
  //if the capacity has been modified by the user
  if (new_capacity <= 0)
  {
    return 1;
  }
  //attempting to reallocate
  void *ptr = realloc(vector->data, new_capacity * element_size);
  if (ptr == NULL)
  {
    return 1;
  }
  vector->data = ptr;
  vector->capacity = new_capacity;
  return 0;
}

/// @brief pops the last element from  a vector
/// @param vector the vector to be modified
/// @param element_size the size of the popped element
/// @param dist optional holder for the popped element if required, use `NULL` if not needed
/// @addtogroup Vector
/// @return 1 for failure or 0 for success
int vector_pop(struct Vector *vector, size_t element_size, void *dist)
{
  // basic validation
  if (vector == NULL || vector->size <= 0)
  {
    return 1;
  }
  // decreasing the size of element
  vector->size--;

  // moving to the last element (before wiping)
  void *elem = (char *)vector->data + (vector->size * element_size);
  // copping the value over to dist
  if (dist != NULL)
  {
    // copy
    memcpy(dist, elem, element_size);
  }
  memset(elem, 0, element_size);
  return 0;
}

/// @brief pushes a new element to the end of the vector
/// @param vector the vector to push to
/// @param val void pointer to the value
/// @param element_size the size of the element
/// @addtogroup Vector
/// @return status of 0 for success or 1 for failure
int vector_push(struct Vector *vector, void *val, size_t element_size)
{
  if (vector == NULL)
    return 1;
  // checking if the vector requires re-sizing
  if (vector->size >= vector->capacity)
  {
    size_t new_cap = (vector->capacity == 0) ? 4 : vector->capacity * 2;
    int stat = vector_resize(vector, new_cap, element_size);
    if (stat == 1)
      return 1;
  }

  // pushing the new element
  void *elem = (char *)vector->data + (vector->size * element_size);

  if (elem == NULL)
    return 1;
  // copying the value
  memcpy(elem, val, element_size);
  elem = NULL;
  vector->size++;

  return 0;
}

/// @brief used to see the value at the given index in a vector
/// @param vector the vector to search in
/// @param index the index of the target
/// @param element_size the size of the target
/// @return `NULL` on failure or `void*` on success
void *vector_at(struct Vector *vector, size_t index, size_t element_size)
{
  if (vector == NULL || vector->size <= index || index < 0)
    return NULL;

  return (char *)vector->data + (index * element_size);
}
```

---

## Simple linked list

a linked list is a non-contagious list of element composed of **nodes**, each node has 2 things:

- value: the value it stores
- next: a pointer to the next node

the start of the list is often called `head` while the very end is the `tail`

```c
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>

typedef struct Node
{
  int32_t data;
  struct Node *next;
} Node;

typedef struct LinkedList
{
  Node *head;
} LinkedList;

/// @brief create a new linked list, if data is used as value for the head node
/// @param data the initial value of the head node
/// @return a pointer to the linked list
LinkedList *linkedlist_init(int data)
{
  LinkedList *ls = malloc(sizeof(LinkedList));
  if (ls == NULL)
    return NULL;

  Node *head = malloc(sizeof(Node));
  if (head == NULL)
  {
    free(ls);
    return NULL;
  }

  head->next = NULL;
  head->data = data;

  ls->head = head;
  return ls;
}

/// @brief adds a new node after the given node, if the node already points to another node the new node will be inserted in between
/// @param node
/// @param val
/// @return a pointer to the new node
Node *linkedlist_new_node(Node *node, int val)
{
  // if given invalid node
  if (node == NULL)
    return NULL;

  // attempting to allocate a new node
  Node *newNode = malloc(sizeof(Node));
  if (newNode == NULL)
    return NULL;

  newNode->next = node->next;
  newNode->data = val;
  node->next = newNode;
  return newNode;
}

/// @brief traverses the node tree and free each node
/// @param head
int linkedlist_free(LinkedList *ls)
{
  if (ls == NULL)
    return 1;

  if (ls->head == NULL)
  {
    free(ls);
    return 0;
  }

  Node *curr = ls->head;
  while (curr != NULL)
  {
    Node *next = curr->next;
    free(curr);
    curr = next;
  }
  free(ls);
  return 0;
}

/// @brief adds a new node as the head
/// @param ls
/// @param data
/// @return a pointer to the new node
Node *linkedlist_insert_head(LinkedList *ls, int data)
{
  Node *node = malloc(sizeof(Node));
  if (node == NULL)
    return NULL;

  if (ls->head == NULL)
  {
    node->next = NULL;
    ls->head = node;
  }
  else
  {
    Node *prevHead = ls->head;
    node->next = prevHead;
    ls->head = node;
  }

  node->data = data;
  return node;
}

/// @brief adds a new node as a tail
/// @param ls
/// @param data
/// @return a pointer to the node
Node *linkedlist_insert_tail(LinkedList *ls, int data)
{
  Node *node = malloc(sizeof(Node));
  if (node == NULL)
    return NULL;

  if (ls->head == NULL)
  {
    node->next = NULL;
    ls->head = node;
  }
  else
  {
    Node *tail = ls->head;
    while (tail->next != NULL)
    {
      tail = tail->next;
    }
    tail->next = node;
  }

  node->data = data;
  node->next = NULL;
  return node;
}

/// @brief searches for the first occurrence of the given value in the node tree
/// @param head
/// @param value
/// @return a pointer to the node with that value
Node *linkedlist_search_value(Node *head, int value)
{
  if (head == NULL)
    return NULL;

  Node *node = head;
  while (node != NULL)
  {
    if (node->data == value)
      return node;
    node = node->next;
  }
  return NULL;
}

/// @brief deletes the first occurrence of the value in the node tree
/// @param head
/// @param value
/// @return a status as int, 0 for success and 1 for failure
int linkedlist_delete_value(LinkedList *ls, int value)
{
  if (ls == NULL || ls->head == NULL)
    return 1;

  Node *node = ls->head;
  Node *prev = NULL;

  while (node != NULL)
  {
    // if the value is found
    if (node->data == value)
    {
      // this means the head is the target
      if (prev == NULL)
      {
        ls->head = node->next;
      }
      else
      {
        prev->next = node->next;
      }
      free(node);
      return 0;
    }
    prev = node;
    node = node->next;
  }

  return 1;
}

/// @brief prints the entire tree in the stdout
/// @param ls
void linkedlist_print_tree(LinkedList *ls)
{
  if (ls == NULL)
    return;

  if (ls->head == NULL)
  {
    printf("NULL\n");
    return;
  };

  Node *node = ls->head;
  while (node != NULL)
  {
    printf("%d -> ", node->data);
    node = node->next;
  }
  printf("Null\n");
}
```

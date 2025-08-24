<!-- @format -->

# Data types:

sql has a lot of data types that can be used for fields.

---

## Numeric types:

numeric type include:

- `INT` or `INTEGER`: a normal integer `-2,147,483,648` to `2,147,483,647`
- `BIGINT`: a bigger integer `-9,223,372,036,854,775,808` to `9,223,372,036,854,775,807`
- `SMALLINT`: a smaller integer `-32,768` to `32,767`
- `TINYINT`: a very small integer `0` to `255`
- `DECIMAL`: a decimal fixed-point number `-10^38 + 1` to `10^38 - 1`
- `NUMERIC`: a decimal fixed-point used for precision data number `-10^38 + 1` to `10^38 - 1`
- `FLOAT`: a floating-point number, for approximated values
- `REAL`: a floating-point number, for approximated values with less precision than `FLOAT`
- `MONEY`: for storing monetary values `-922,337,203,685,477.5808` to `922,337,203,685,477.5807`
- `SMALLMONEY`: for storing monetary values `-214,748.3648` to `214,748.3647`

---

## Char and string:

- `CHAR`: The maximum length of 8000 characters. (Fixed-Length non-Unicode Characters)
- `VARCHAR(N)`: The maximum length of 8000 characters. (Variable-Length non-Unicode Characters)
- `TEXT`: The maximum length of 2,147,483,647 characters
- `NCHAR`: The maximum length of 4000 characters. (Fixed-Length Unicode Characters)
- `NVARCHAR(N)`: The maximum length of 4000 characters. (Variable-Length Unicode Characters)

---

## Dates and times:

- `DATE`: stores time as YYYY/MM/DD (3-bytes)
- `TIME`: stores time as HH:MM:SS (3-bytes)
- `DATETIME`: stores time as YYYY/MM/DD HH:MM:SS (8-bytes)

---

## Binary types:

- `BINARY`: fixed-length (max 8000 bytes) binary type
- `VARBINARY`: variable-length (max 2,147,483,647 bytes) binary type
- `IMAGE`: variable-length (max 2,147,483,647 bytes) binary type that stores images

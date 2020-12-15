# Contact API

Current version only allows Create and Get operation. Update and Delete operation will be implemented soon.

The API is locally tested with Oracle Database 19c installed in Windows 10.

## How to run server

Install dotnet 5.0 and run the following at the root directory of this project.

```
dotnet build
dotnet run
```

## Database Schema
```
CREATE TABLE contact(
id NUMBER NOT NULL Primary key,
firstname VARCHAR2(20),
lastname VARCHAR2(20),
birth DATE,
email VARCHAR2(40),
address VARCHAR2(80),
phone VARCHAR2(15)
);
```

### Example data format
```
INSERT into contact values(10, 'daniel','kang',TO_DATE('1991/02/22','yyyy/mm/dd'),'qwerty@gmail.com','1234 qwer st Vancouver','7781118888');
```

### Valid example for POST body
Body must be JSON format, and birth field is required to be ISO-8601 format for this version.
```
{
    "id": 51,
    "firstName": "daniel",
    "lastName": "kaneg",
    "address": "1234 qwer steeeeeeee Vancouver",
    "phoneNumber": "7333333888",
    "birth": "2019-01-06T17:16:40",
    "email": "qwerty@gmail.com"
}
```

# SQL Terms

Define following terms in your own words, using any resources.

- Relational database
- SQL: Structured Query Language is a domain specific language used in programming designed to manage data held in a database system or for stream processing in a data stream management system
  - DDL: Data Definition language; SQL commands that can be used to define the database schema. Used to create, drop, alter, and truncate database objects
  - DML: Data Manipulation Language; SQL commands that deal with the manipulation of data present in the database. Used to insert, update, delete, lock.
  - DQL: Used for performing queries on the data within schema objects. We use select to retrieve data from the database.
  - DCL:
  - TCL
- Primary Key
- Foreign Key
- Candidate Key: A column or a set of column that can qualify as a primary key in the database.
- Composite Key
- tell me about normalization
  - 1nf: must have an unique identifier and each column can only have one value per each row.
  - 2nf: all non-key attributes cannot be dependent on a subset of the primary key. Easiest way to achieve is to be in 1NF and not have a composite key.
  - 3nf: no transitive dependency. you shouldn't be able to infer the value of a column by looking at another non-key column.
- Referential Integrity: Making sure that the foreign key value you're referencing is a valid value.
- Which keyword do I use to...
  - Create new table
  - create a new record in a table
  - modify table structure
  - delete table
  - modify existing row in a table
  - delete a row
  - drop all rows in a table w/o deleting the table
- What are some SQL dialects/vendors we have?
  - which one do we use?
- What are constraints?
  - Give me some examples and what they do
- Tell me about some common SQL data types
- What is ADO.NET?
- How do I connect to DB on ado.net?
- how do I execute a command on ado.net?
- how do I write a query to avoid sql injection?
- what's the difference between executereader, executenonquery, executescalar?
- what is connectionstring
- tell me about multiplicity and some examples
- tell me about identity keyword

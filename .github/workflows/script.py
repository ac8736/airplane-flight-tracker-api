import pymysql.cursors


def create_connection():
    return pymysql.connect(
        host="localhost",
        user="root",
        password="root",
        charset="utf8mb4",
        cursorclass=pymysql.cursors.DictCursor,
    )


conn = create_connection()
cursor = conn.cursor()
query = "CREATE DATABASE airline_ticket_reservation;"
cursor.execute(query)
query = "use airline_ticket_reservation;"
cursor.execute(query)

query = "CREATE TABLE airline(name varchar(255) not null, primary key (name));"
cursor.execute(query)
query = "INSERT INTO airline VALUES('Delta');"
cursor.execute(query)

query = "CREATE TABLE airport(name varchar(255) not null, code varchar(255) not null, city varchar(255) not null, country varchar(255) not null, dateCreated Datetime not null);"
cursor.execute(query)
query = "INSERT INTO airport VALUES('LaGuardia Airport', 'LGA', 'NYC', 'United States', '2024-04-06 01:00:26');"
cursor.execute(query)

query = "CREATE TABLE airline_staff(username varchar(255) not null, email varchar(255) not null, acc_password varchar(255) not null, firstName varchar(255) not null, lastName varchar(255) not null, airline varchar(255) not null, dateCreated Datetime not null, lastModified Datetime not null);"
cursor.execute(query)

conn.commit()
cursor.close()
conn.close()

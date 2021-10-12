# Viridian.Demo.Informix

Demo project to interact with a informix database

## Setup:

- Configure database credentials in appsettings.json
- Database must accept connections from DRDA clients using port 9089. Netcore uses this port to connect to informix database
- Execute create.sql to create users table
- Execute seed.sql to seed table
- Run project
- Import postman collection **postman.json** to start testing endpoints
- Swagger docs available at: https://localhost:5001/swagger/index.html

# SCADA
## Database setup
CMD
```shell
docker run -d --name=mysql_container \
  -e MYSQL_DATABASE=mydatabase \
  -e MYSQL_USER=root \
  -e MYSQL_PASSWORD=root \
  -e MYSQL_ROOT_PASSWORD=root \
  -p 3306:3306 \
  mysql:latest
```
Docker 
```shell
mysql -uroot -p
root

CREATE DATABASE scada;

CREATE USER 'admin'@'172.17.0.1' IDENTIFIED BY 'admin';
GRANT ALL PRIVILEGES ON scada.* TO 'admin'@'172.17.0.1';
FLUSH PRIVILEGES;

# For mysql from local machine
# CREATE USER 'admin'@'localhost' IDENTIFIED BY 'admin';
# GRANT ALL PRIVILEGES ON scada.* TO 'admin'@'localhost';
# FLUSH PRIVILEGES;

SHOW DATABASES; # Lists all databases
USE SCADA; 
SELECT user FROM mysql.User;
EXIT; 
```
VS Nuget package manager CLI 
```shell
Enable-Migrations -ContextTypeName Core.Repository.DatabaseContext
Add-Migration InitialCreate -ConfigurationTypeName Configuration
Update-Database -ConfigurationTypeName Configuration
```
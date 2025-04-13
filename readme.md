Configure a conexão com seu db seu db criando um .env

DB_SERVER=
DB_DATABASE=
DB_USER=
DB_PASSWORD=

copie e cole no terminal
dotnet ef migrations add init
dotnet ef database update 
dotnet watch run
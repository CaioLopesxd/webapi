# Etapa 1: Usar a imagem base do .NET SDK para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

# Copiar o arquivo de projeto e restaurar dependências
COPY ./*.csproj ./
RUN dotnet restore

# Copiar todos os arquivos e publicar a aplicação
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Usar a imagem base do .NET Runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

# Copiar a aplicação publicada para o contêiner
COPY --from=build /app/publish .

# Definir o comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "webapi.dll"]

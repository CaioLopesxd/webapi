# 🚀 Configuração do Projeto

Siga os passos abaixo para configurar e executar este projeto localmente.

---

## ✅ Pré-requisitos

- **.NET 9** ou superior  
- **Entity Framework Core CLI**  
> Instale com: `dotnet tool install dotnet-ef`  
- **Banco de dados SQL Server**

---

## ⚙️ Passo a Passo

### 1️⃣ Clone o repositório

```bash
git clone https://github.com/CaioLopesxd/webapi
cd webapi
```

### 2️⃣ Crie um arquivo `.env` na raiz do projeto

Esse arquivo será usado para configurar a conexão com o banco de dados. Copie e cole o conteúdo abaixo e preencha com seus dados:

```env
DB_SERVER=UrlDeConexão
DB_DATABASE=NomeDoBanco
DB_USER=SeuUsuario
DB_PASSWORD=SuaSenha
```

### 3️⃣ Compile o projeto

```bash
dotnet build
```

### 4️⃣ Crie a migration

```bash
dotnet ef migrations add init
```

### 5️⃣ Atualize o banco de dados

```bash
dotnet ef database update
```

### 6️⃣ Abra seu banco de dados e execute esta query 

```bash
-- Populando Industries
INSERT INTO Industries (Description) VALUES ('Technology');         -- 1
INSERT INTO Industries (Description) VALUES ('Automotive');         -- 2
INSERT INTO Industries (Description) VALUES ('Healthcare');         -- 3
INSERT INTO Industries (Description) VALUES ('Finance');            -- 4
INSERT INTO Industries (Description) VALUES ('Retail');             -- 5
INSERT INTO Industries (Description) VALUES ('Energy');             -- 6
INSERT INTO Industries (Description) VALUES ('Telecommunications'); -- 7
INSERT INTO Industries (Description) VALUES ('Consumer Goods');     -- 8
INSERT INTO Industries (Description) VALUES ('Transportation');     -- 9
INSERT INTO Industries (Description) VALUES ('Entertainment');      -- 10
```

### 6️⃣ Rode o projeto

```bash
dotnet watch run
```

---

## ✅ Pronto!

Seu projeto estará rodando em:  
**https://localhost:5160** (ou na porta definida no seu `launchSettings.json`).

---

## 📘 Acesso às rotas via Swagger

Após rodar o projeto, você pode acessar as rotas da API através do Swagger:

**URL:**  
**`https://localhost:5160/swagger`** *(ajuste a porta conforme definido no seu `launchSettings.json`)*

Com o Swagger, você pode:

- Visualizar todas as rotas disponíveis  
- Enviar requisições (**GET**, **POST**, **PUT**, **DELETE**) diretamente pelo navegador  
- Testar os endpoints com os parâmetros esperados  

> O Swagger é habilitado automaticamente em ambiente de desenvolvimento.  
> Se não abrir, verifique se o `launchSettings.json` está configurado corretamente.

---

## 🌐 Testando a API Publicada

Essa API já está publicada, caso queira testala siga os passos abaixo:

### 1️⃣ Acesse o Swagger

A API está disponível publicamente no Swagger através do link:  
**[https://finshark-1emi.onrender.com/swagger](https://finshark-1emi.onrender.com/swagger)**

### 2️⃣ Explore as Rotas

No Swagger, você pode:

- Visualizar todas as rotas disponíveis  
- Enviar requisições (**GET**, **POST**, **PUT**, **DELETE**) diretamente pelo navegador  
- Testar os endpoints com os parâmetros esperados 
> Verificar se está logado pois algumas ações esperam que você esteja autenticado como post para comentarios 

## 🗂️ Relacionamentos entre Entidades

- **Industry (Indústria)** possui um relacionamento **um-para-muitos** com **Stock (Ações)**.
  - Uma única indústria pode estar associada a várias ações.
  - Cada ação pertence a uma única indústria.

- **Stock (Ação)** possui um relacionamento **um-para-muitos** com **Comment (Comentários)**.
  - Uma única ação pode ter vários comentários de usuários.
  - Cada comentário está associado a uma única ação.

  

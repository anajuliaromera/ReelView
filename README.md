# 🎬 ReelView API

ReelView é uma API RESTful desenvolvida em **ASP.NET Core 8**, estruturada com **Clean Architecture** e integrada à API externa **TMDB** para buscar filmes e séries populares.

---

## 🛠️ Tecnologias Utilizadas

| Categoria            | Tecnologia                  | Versão |
|----------------------|------------------------------|--------|
| Backend Principal    | ASP.NET Core                 | 8.0    |
| Banco de Dados       | Entity Framework Core        | 8.0    |
| Provedor DB          | SQLite                       | 8.0    |
| Documentação         | Swagger / OpenAPI            | 6.5.0  |
| Segurança            | JWT + BCrypt.Net-Next        | 4.0.3  |
| Cliente HTTP         | HttpClientFactory + TMDB API | —      |

---

## 🏗️ Arquitetura — Clean Architecture

### 📂 **ReelView.Core**
- Models  
- DTOs  
- Interfaces de Serviços  
- Interfaces de Repositórios  
- **Sem dependências externas**

### 📂 **ReelView.Infrastructure**
- `AppDbContext` (EF Core / SQLite)  
- Repositórios  
- TMDB Client  
- Depende apenas do Core + EF Core  

### 📂 **ReelView.Api**
- Controllers  
- Services (implementações concretas)  
- Endpoints HTTP  
- Autenticação JWT  
- É o projeto usado como **Startup Project**

---

# 🚀 Como Rodar o Projeto

## 📌 Pré-requisitos
- **.NET 8 SDK** instalado  
- Opcional: Visual Studio 2022 ou VS Code  
- Conta no **TMDB** para gerar uma API Key  

---

## 1️⃣ Configurar a API da TMDB

Edite o arquivo:

```
ReelView.Api/appsettings.json
```

Configure sua chave:

```json
"TMDB": {
  "ApiKey": "SUA_CHAVE_AQUI",
  "BaseUrl": "https://api.themoviedb.org/3/"
}
```

---

## 2️⃣ Configurar o Banco de Dados SQLite

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=reelview.db"
}
```

---

## 3️⃣ Restaurar Dependências

```bash
dotnet restore
```

---

## 4️⃣ Aplicar Migrações do Entity Framework

Instale a CLI do EF (caso não tenha):

```bash
dotnet tool install --global dotnet-ef
```

Aplique as migrações:

```bash
dotnet ef database update --project ReelView.Infrastructure --startup-project ReelView.Api
```

Ou simplesmente:

```bash
dotnet ef database update
```

---

## 5️⃣ Rodar o Projeto

Execute:

```bash
dotnet run --project ReelView.Api
```

Ou:

```bash
cd ReelView.Api
dotnet run
```

---

## 6️⃣ Acessar a Documentação Swagger

Acesse no navegador:

```
https://localhost:7050/swagger
```

ou

```
http://localhost:5087/swagger
```

---

# 🔐 Autenticação JWT

1. Faça login no endpoint `/auth/login`
2. Receba o token
3. No Swagger, clique em **Authorize**
4. Insira:

```
Bearer SEU_TOKEN_AQUI
```

---

# 📡 Endpoints Principais

### 🔑 Autenticação
- `POST /auth/register`
- `POST /auth/login`

### 🎬 TMDB
- `GET /tmdb/popular`
- `GET /tmdb/movie/{id}`

### 👤 Usuários
- `GET /usuarios/{id}`
- `PUT /usuarios/{id}`
- `DELETE /usuarios/{id}`

---

# 🧱 Estrutura de Pastas

```
ReelView/
 ├── ReelView.Core/
 │     ├── Models/
 │     ├── DTOs/
 │     ├── Interfaces/
 │
 ├── ReelView.Infrastructure/
 │     ├── Data/
 │     ├── Repositories/
 │     ├── TMDB/
 │
 ├── ReelView.Api/
       ├── Controllers/
       ├── Services/
       ├── Config/
       ├── Program.cs
```

---

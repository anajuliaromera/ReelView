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
- Sem dependências externas  

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
- Usada como *startup project*

---

## 🚀 Como Rodar o Projeto

### 📌 Pré-requisitos
- **.NET 8.0 SDK**

---

## 1️⃣ Configurar a API da TMDB

Edite o arquivo `ReelView.Api/appsettings.json`:

```json
"TMDB": {
  "ApiKey": "SUA_CHAVE_AQUI_...",
  "BaseUrl": "https://api.themoviedb.org/3/"
}

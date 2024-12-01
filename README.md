# Montech API Documentation

## 📚 Sobre o Projeto
O **Montech API** é uma solução desenvolvida para monitorar bens materiais e serviços de empresas. Reestruturado em formato de API, o projeto utiliza princípios de **Domain-Driven Design (DDD)**, garantindo uma arquitetura robusta, modular e fácil de manter. Ele evolui constantemente para atender às melhores práticas e novas demandas.

---

## 🛠️ Tecnologias Utilizadas

### Back-End:
- **Linguagem:** C#
- **Framework:** ASP.NET Core
- **Banco de Dados:** SQL Server (Code First com Entity Framework)
- **Arquitetura:** DDD (Domain-Driven Design)
- **Outras Tecnologias:**
  - AutoMapper
  - MediatR
  - Swagger (OpenAPI)
  - FluentValidation
  
### Ferramentas e Bibliotecas:
- **Controle de Versionamento:** Git
- **Documentação:** Swagger e Markdown
- **Testes:** NUnit e Moq

---

## 🧱 Estrutura do Projeto

### 🎯 Camadas do DDD:

1. **Domain:**
   - Entidades
   - Objetos de Valor
   - Regras de Negócio

2. **Application:**
   - DTOs (Data Transfer Objects)
   - Interfaces de Serviços
   - Handlers com MediatR

3. **Infrastructure:**
   - Repositórios (implementação das interfaces)
   - Configuração do banco de dados (EF Core)
   - Integrações externas

4. **API:**
   - Controllers
   - Configuração do Swagger
   - Middlewares

---

## 🚀 Funcionalidades

### 🏢 Gestão de Empresas:
- Cadastro de empresas com validação completa.
- Atualização e exclusão de empresas.
- Listagem com filtros personalizados (paginação e ordenação).

### 📦 Gestão de Bens e Serviços:
- Cadastro de bens com integração ao sistema de empresas.
- Atualização de status (ativo/inativo).
- Consulta detalhada e por categoria.

### 🔐 Sistema de Autenticação:
- Login e registro de usuários.
- Tokens JWT para autenticação segura.
- Controle de acesso baseado em permissões.

---

## 🗂️ Como Executar o Projeto

### Pré-requisitos:
- .NET SDK 8.0 ou superior
- SQL Server
- Visual Studio 2022 ou VS Code
- Postman (para testes manuais) ou Swagger

### Passos:
1. Clone o repositório:
   ```bash
   git clone https://github.com/SEU_USUARIO/montech-api.git
   ```
2. Navegue até o diretório do projeto:
   ```bash
   cd montech-api
   ```
3. Configure a string de conexão no arquivo `appsettings.json`.

4. Atualize o banco de dados:
   ```bash
   dotnet ef database update
   ```
5. Execute a aplicação:
   ```bash
   dotnet run
   ```
6. Acesse o Swagger:
   - URL padrão: `http://localhost:5000/swagger`

---

## 📖 Exemplos de Endpoints

### Usuário

#### Registro de Usuário
- **[POST] /api/usuario**
  - Descrição: Registra um novo usuário no sistema.
  - Corpo da Requisição:
    ```json
    {
      "nome": "João Silva",
      "email": "joao.silva@example.com",
      "senha": "SenhaSegura123"
    }
    ```
  - Resposta:
    ```json
    {
      "id": 1,
      "nome": "João Silva",
      "email": "joao.silva@example.com"
    }
    ```

#### Busca de Usuário por ID
- **[GET] /api/usuario/{id}**
  - Descrição: Retorna os detalhes de um usuário específico.
  - Exemplo de Resposta:
    ```json
    {
      "id": 1,
      "nome": "João Silva",
      "email": "joao.silva@example.com",
      "ativo": true
    }
    ```

#### Listar Usuários Ativos
- **[GET] /api/usuario/ativos**
  - Descrição: Retorna todos os usuários ativos no sistema.
  - Exemplo de Resposta:
    ```json
    [
      {
        "id": 1,
        "nome": "João Silva",
        "email": "joao.silva@example.com"
      },
      {
        "id": 2,
        "nome": "Maria Oliveira",
        "email": "maria.oliveira@example.com"
      }
    ]
    ```

#### Deletar Usuário por ID
- **[DELETE] /api/usuario/{id}**
  - Descrição: Remove um usuário específico do sistema.
  - Exemplo de Resposta:
    ```json
    {
      "mensagem": "Usuário removido com sucesso."
    }
    ```

#### Login de Usuário
- **[POST] /api/login**
  - Descrição: Autentica um usuário e retorna um token JWT.
  - Corpo da Requisição:
    ```json
    {
      "email": "joao.silva@example.com",
      "senha": "SenhaSegura123"
    }
    ```
  - Exemplo de Resposta:
    ```json
    {
      "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
      "usuario": {
        "id": 1,
        "nome": "João Silva",
        "email": "joao.silva@example.com"
      }
    }
    ```
---

## 💬 Contato

- **Nome:** João Victor Portela
- **E-mail:** jvictorportela30@outlook.com
- **LinkedIn:** https://www.linkedin.com/in/jo%C3%A3o-victor-portela-146a71248/

---

## 📌 Atualizações Futuras
- [ ] Integração com APIs OpenAI para controle de depreciação em tempo real.
- [ ] Dashboard para visualização de métricas.
- [ ] Suporte a banco de dados NoSQL.

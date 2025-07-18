# 🍺 Developer Evaluation 🍺

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![xUnit](https://img.shields.io/badge/Tests-xUnit-green.svg)](https://xunit.net/)
[![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-orange.svg)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
[![CQRS](https://img.shields.io/badge/Pattern-CQRS-purple.svg)](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

Um sistema de gerenciamento de vendas desenvolvido como parte do processo de avaliação técnica, implementando Clean Architecture e boas práticas de desenvolvimento.

## 🎯 Sobre o Projeto

O **Developer Evaluation** é um sistema de gestão de vendas que permite:

- **Gerenciamento de Usuários**: Cadastro, autenticação e autorização
- **Gestão de Produtos**: Catálogo de produtos com categorias e preços
- **Carrinho de Compras**: Sistema de vendas com aplicação de descontos

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture**, garantindo:

- ✅ **Separação de Responsabilidades**
- ✅ **Independência de Frameworks**
- ✅ **Testabilidade**
- ✅ **Flexibilidade e Manutenibilidade**

### Camadas da Aplicação

```
📁 src/
├── 🎯 Ambev.DeveloperEvaluation.Domain/          # Entidades e Regras de Negócio
├── 🔧 Ambev.DeveloperEvaluation.Application/     # Casos de Uso e CQRS
├── 🗄️ Ambev.DeveloperEvaluation.Infrastructure/  # Persistência e Serviços Externos
├── 🌐 Ambev.DeveloperEvaluation.WebApi/          # Controllers e Endpoints
└── 🧪 Ambev.DeveloperEvaluation.Tests/           # Testes Unitários e Integração
```

## 🚀 Tecnologias

### Backend
- **[.NET 8](https://dotnet.microsoft.com/)** - Framework principal
- **[ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)** - Web API
- **[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)** - ORM
- **[MediatR](https://github.com/jbogard/MediatR)** - Implementação do padrão CQRS
- **[AutoMapper](https://automapper.org/)** - Mapeamento de objetos
- **[FluentValidation](https://fluentvalidation.net/)** - Validação de dados

### Banco de Dados
- **[PostgreSQL](https://www.postgresql.org/)** - Auth Usuários
- **[MongoDB](https://www.mongodb.com/docs/drivers/csharp/current/)** - Persistencia de Vendas (SalesCart)

### Testes
- **[xUnit](https://xunit.net/)** - Framework de testes
- **[NSubstitute](https://nsubstitute.github.io/)** - Mocking
- **[FluentAssertions](https://fluentassertions.com/)** - Assertions expressivas
- **[Bogus](https://github.com/bchavez/Bogus)** - Geração de dados fake

### Documentação
- **[Swagger/OpenAPI](https://swagger.io/)** - Documentação da API
- **[Serilog](https://serilog.net/)** - Logging estruturado

## 📂 Estrutura do Projeto

```
*.DeveloperEvaluation/
├── 📁 src/
│   ├── 🎯 Domain/
│   │   ├── Entities/          # User, Product, SalesCart, Branch
│   │   ├── ValueObjects/      # CustomerInfo, BranchInfo, SalesCartItem
│   │   ├── Enums/            # UserStatus, UserRole, ProductCategory
│   │   ├── Repositories/     # Interfaces dos repositórios
│   │   └── Services/         # Interfaces dos serviços de domínio
│   │
│   ├── 🔧 Application/
│   │   ├── Users/            # CreateUser, GetUser, UpdateUser, DeleteUser
│   │   ├── SalesCart/        # CreateSalesCart, GetSalesCart
│   │   ├── Products/         # Gerenciamento de produtos
│   │   └── Common/           # DTOs, Validators, Behaviors
│   │
│   ├── 🗄️ Infrastructure/
│   │   ├── Data/             # DbContext, Configurations, Migrations
│   │   ├── Repositories/     # Implementações dos repositórios
│   │   ├── Services/         # Implementações dos serviços
│   │   └── Security/         # Validações de Segurança
│   │
│   └── 🌐 WebApi/
│       ├── Features/         # UsersController, SalesCartController
│       ├── Middleware/       # Error handling, Logging
│       └── Configuration/    # DI, Swagger, Database
│
└── 📁 tests/
    ├── 🧪 Unit/
    │   ├── Application/      # Testes dos handlers
    │   ├── Domain/          # Testes das entidades
    │   └── TestData/        # Geradores de dados fake
    ├──
```

## ⚡ Funcionalidades

### 👥 Gestão de Usuários
- [x] Criar usuário com validação
- [x] Autenticação e autorização
- [x] Atualização de dados
- [x] Desativação de conta
- [x] Hash seguro de senhas

### 🛒 Sistema de Vendas
- [x] Criar carrinho de compras
- [x] Modificar carrinho de compras
- [x] Cancelar carrinho de compras
- [x] Listar carrinho de compras
- [x] Aplicação automática de descontos
- [x] Geração de número único de venda
- [x] Validação de Quantidade Max de Produtos

### 📦 Gestão de Produtos
- [x] Catálogo de produtos
- [x] Categorização

## 🔧 Configuração do Ambiente

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/) 
- [MongoDB](https://www.mongodb.com/)
- [Git](https://git-scm.com/)
- IDE de sua preferência ([Visual Studio](https://visualstudio.microsoft.com/), [VS Code](https://code.visualstudio.com/), [Rider](https://www.jetbrains.com/rider/))

### Variáveis de Ambiente

Crie um arquivo `appsettings.Development.json` na pasta `WebApi`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5431;Database=postgres;Username=seu_username;Password=mysecretpassword;Trust Server Certificate=true"
  },
  "MongoDB": {
    "ConnectionString": "localhost:1010",
    "DatabaseName": "DevTest"
  },
  "Jwt": {
    "SecretKey": "YourSuperSecretKeyForJwtTokenGenerationThatShouldBeAtLeast32BytesLong"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Error",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

## 🚀 Como Executar

### 1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/ambev-developer-evaluation.git
cd ambev-developer-evaluation
```

### 2. Restaure as dependências
```bash
dotnet restore
```

### 3. Configure o banco de dados
```bash
# Execute as migrations
dotnet ef database update --project src/Ambev.DeveloperEvaluation.Infrastructure --startup-project src/Ambev.DeveloperEvaluation.WebApi
```

### 4. Execute a aplicação
```bash
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
```

### 5. Acesse a documentação
- **Swagger UI**: `https://localhost:7297/swagger`
- **API Base**: `https://localhost:7297/api`

## 🧪 Testes

### Executar Todos os Testes
```bash
dotnet test
```

### Executar Testes com Cobertura
```bash
dotnet test
```

### Estrutura de Testes

- **📁 Unit Tests**: Testam componentes isolados usando mocks
- **📁 Integration Tests**: Testam fluxos completos da API
- **📁 Test Data**: Geradores de dados fake usando Bogus

```csharp
// Exemplo de teste unitário
[Fact(DisplayName = "Given valid sales cart data When creating sales cart Then returns success response")]
public async Task Handle_ValidRequest_ReturnsSuccessResponse()
{
    // Given
    var command = CreateSalesCartHandlerTestData.GenerateValidCommand();
    
    // When
    var result = await _handler.Handle(command, CancellationToken.None);
    
    // Then
    result.Should().NotBeNull();
    result.Id.Should().NotBeEmpty();
}
```

## 📝 Padrões e Convenções

### Commit Messages
Seguimos o padrão [Conventional Commits](https://www.conventionalcommits.org/):

```
feat: add new sales cart creation endpoint
fix: resolve user authentication issue
docs: update API documentation
test: add unit tests for user service
refactor: improve error handling middleware
```

### Nomenclatura
- **Classes**: PascalCase (`CreateUserHandler`)
- **Métodos**: PascalCase (`GenerateValidCommand`)
- **Propriedades**: PascalCase (`CustomerName`)
- **Variáveis**: camelCase (`userName`)
- **Constantes**: UPPER_CASE (`MAX_RETRY_ATTEMPTS`)

### Estrutura de Handlers (CQRS)
```csharp
public class CreateSalesCartHandler : IRequestHandler<CreateSalesCartCommand, CreateSalesCartResult>
{
    // Dependencies injection
    // Handle method implementation
    // Logging and validation
}
```

## 📖 Documentação da API


```
### Exemplo de Request

## 🛒 1. Criar Carrinho de Vendas

### Request

```http
POST /api/SalesCart
Content-Type: application/json

{
  "customer": "91d6e609-d883-43ea-bfd0-658664749d73",
  "branch": "91d6e609-d883-43ea-bfd0-658664749d73",
  "items": [
    {
      "productId": "5ffb27c7-f128-4d0f-958c-98c03d8dba5d",
      "quantity": 10
    },
    {
      "productId": "5ffb27c7-f128-4d0f-958c-98c03d8dba5d",
      "quantity": 10
    }
  ]
}
```

### Response (201 Created)

```json
{
    "data": {
        "id": "94c69ae0-5a42-4e54-a7b4-ede1f4df096d",
        "saleNumber": "AMB-20250718-121246-9308",
        "saleDate": "2025-07-18T12:12:46.6724217Z",
        "customer": "91d6e609-d883-43ea-bfd0-658664749d73",
        "branch": "11111111-1111-1111-1111-111111111111",
        "items": [
            {
                "productId": "5ffb27c7-f128-4d0f-958c-98c03d8dba5d",
                "productTitle": "Teste Product",
                "productCategory": "Electronics",
                "quantity": 10,
                "unitPrice": 10,
                "discount": 20.00,
                "totalAmount": 80.00
            },
            {
                "productId": "5ffb27c7-f128-4d0f-958c-98c03d8dba5d",
                "productTitle": "Teste Product",
                "productCategory": "Electronics",
                "quantity": 10,
                "unitPrice": 10,
                "discount": 20.00,
                "totalAmount": 80.00
            }
        ],
        "totalAmount": 160.00,
        "isCancelled": false,
        "cancelledAt": null,
        "createdAt": "2025-07-18T12:12:46.6728102Z",
        "updatedAt": null
    },
    "success": true,
    "message": "Sales cart created successfully.",
    "errors": []
}
```

## 📄 2. Buscar Carrinho por ID

### Request

```http
GET /api/SalesCart/4b9022f6-6a58-4b59-9dda-d85c85074e33
```

### Response (200 OK)

```json
{
    "data": {
        "id": "4b9022f6-6a58-4b59-9dda-d85c85074e33",
        "saleNumber": "AMB-20250717-165030-8902",
        "saleDate": "2025-07-17T16:50:30.635Z",
        "customer": "91d6e609-d883-43ea-bfd0-658664749d73",
        "customerEmail": "teste@teste.com",
        "branch": "11111111-1111-1111-1111-111111111111",
        "branchName": "Filial São Paulo",
        "branchLocation": "São Paulo - SP",
        "items": [
            {
                "productId": "5ffb27c7-f128-4d0f-958c-98c03d8dba5d",
                "productTitle": "Teste Product",
                "productCategory": "Electronics",
                "quantity": 10,
                "unitPrice": 10,
                "discount": 20.00,
                "totalAmount": 80.00
            },
            {
                "productId": "5ffb27c7-f128-4d0f-958c-98c03d8dba5d",
                "productTitle": "Teste Product",
                "productCategory": "Electronics",
                "quantity": 5,
                "unitPrice": 10,
                "discount": 10.00,
                "totalAmount": 40.00
            }
        ],
        "totalAmount": 90.00,
        "isCancelled": true,
        "cancelledAt": "2025-07-17T20:25:08.646Z",
        "createdAt": "2025-07-17T16:50:30.636Z",
        "updatedAt": "2025-07-17T20:25:08.646Z"
    },
    "success": true,
    "message": "SalesCart retrieved successfully",
    "errors": []
}
```

## ✏️ 3. Atualizar Carrinho

### Request

```http
PUT /api/SalesCart
Content-Type: application/json

{
  "salesCartId": "4b9022f6-6a58-4b59-9dda-d85c85074e33",
  "customer": "91d6e609-d883-43ea-bfd0-658664749d73",
  "branch": "11111111-1111-1111-1111-111111111111",
  "items": [
    {
      "productId": "5ffb27c7-f128-4d0f-958c-98c03d8dba5d",
      "quantity": 15
    }
  ]
}
```

### Response (200 OK)

```json
{
    "data": {
        "id": "4b9022f6-6a58-4b59-9dda-d85c85074e33",
        "saleNumber": "AMB-20250717-165030-8902",
        "saleDate": "2025-07-17T16:50:30.635Z",
        "customer": "91d6e609-d883-43ea-bfd0-658664749d73",
        "branch": "11111111-1111-1111-1111-111111111111",
        "items": [
            {
                "productId": "5ffb27c7-f128-4d0f-958c-98c03d8dba5d",
                "productTitle": "Teste Product",
                "productCategory": "Electronics",
                "quantity": 10,
                "unitPrice": 10,
                "discount": 20.00,
                "totalAmount": 80.00
            },
            {
                "productId": "5ffb27c7-f128-4d0f-958c-98c03d8dba5d",
                "productTitle": "Teste Product",
                "productCategory": "Electronics",
                "quantity": 10,
                "unitPrice": 10,
                "discount": 20.00,
                "totalAmount": 80.00
            }
        ],
        "totalAmount": 160.00,
        "isCancelled": false,
        "cancelledAt": "2025-07-17T20:25:08.646Z",
        "createdAt": "2025-07-17T16:50:30.636Z",
        "updatedAt": "2025-07-18T09:17:44.5879588-03:00"
    },
    "success": true,
    "message": "Sales cart modified successfully.",
    "errors": []
}
```

## 🗑️ 4. Deletar Carrinho

### Request

```http
DELETE /api/SalesCart/4b9022f6-6a58-4b59-9dda-d85c85074e34
```

### Response (200 OK)

```json
{
    "data": {
        "message": "Sales Cart with Id 4b9022f6-6a58-4b59-9dda-d85c85074e33 was canceled!"
    },
    "success": true,
    "message": "SalesCart canceled!",
    "errors": []
}
```

```

### 📞 Contato

Para dúvidas sobre o projeto:

- **Desenvolvedor**: Lucas Cordeiro
- **LinkedIn**: [Clique Aqui](https://www.linkedin.com/in/lucas-cordeiro97/)

---


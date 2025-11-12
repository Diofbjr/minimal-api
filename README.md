# 🚀 Minimal API de Veículos (CRUD e Auth)

## 📋 Sobre o Projeto

Este projeto é uma **API RESTful** desenvolvida com **Minimal APIs do .NET**, focada na **gestão de veículos e administradores**.  
Foi criado como parte de um **Bootcamp da Digital Innovation One (DIO)**, aplicando conceitos modernos e boas práticas de desenvolvimento.

### 🧩 Principais Funcionalidades

- ✅ **Autenticação JWT (JSON Web Token):** Garante que apenas usuários autenticados acessem as rotas protegidas.  
- ⚡ **Minimal APIs:** Estrutura leve e performática para criação de endpoints.  
- 🧱 **Padrão de Camadas/Serviços:** Separação clara entre lógica de negócio, acesso a dados e endpoints.  
- 🧪 **Testes de Unidade e Integração:** Utilização de `WebApplicationFactory` e `Mocks` para garantir a qualidade do código.

---

## 🧠 Conceitos e Ferramentas Aplicadas

| Conceito / Ferramenta | Descrição |
|------------------------|-----------|
| **Minimal APIs** | Criação de endpoints diretos no `Program.cs` |
| **Autenticação JWT** | Geração e validação de tokens para rotas protegidas |
| **Entity Framework Core** | ORM para mapeamento e persistência de dados |
| **MySQL (Pomelo)** | Banco de dados relacional utilizado |
| **Injeção de Dependência (DI)** | Gerenciamento de serviços e interfaces (`IAdministradorServico`, `IVeiculoServico`) |
| **DTOs e ModelViews** | Transferência de dados entre API e cliente |
| **Testes Automatizados** | Testes unitários e de integração com Mocks |

---

## ⚙️ Estrutura da Aplicação

A aplicação segue um **padrão em camadas**, organizando de forma limpa e escalável:

```bash
📦 minimal-api
├── 📁 Dominio
│   ├── Entidades
│   ├── DTOs
│   ├── Interfaces
│   ├── Enums
│   └── ModelViews
├── 📁 Infraestrutura
│   └── DbContexto
├── 📁 Servicos
│   └── (Lógica de Negócio)
├── Program.cs  (Configuração e Endpoints)
└── appsettings.json
```


---

## 🔐 Autenticação e Rotas

### 🔑 Autenticação
A rota de **login** gera o **token JWT**, necessário para acessar as demais rotas protegidas.

| Método | Rota | Descrição |
|---------|------|-----------|
| `POST` | `/administradores/login` | Realiza o login e retorna um `AdministradorLogado` com Token JWT |

### 🚗 Rotas de Veículos (Protegidas por JWT)

> ⚠️ Todas as rotas exigem o cabeçalho `Authorization: Bearer <token>`.

| Método | Rota | Descrição |
|---------|------|-----------|
| `GET` | `/veiculos` | Lista todos os veículos (com paginação e filtros por nome/marca) |
| `GET` | `/veiculos/{id}` | Busca um veículo específico pelo ID |
| `POST` | `/veiculos` | Cadastra um novo veículo |
| `PUT` | `/veiculos/{id}` | Atualiza um veículo existente |
| `DELETE` | `/veiculos/{id}` | Remove um veículo pelo ID |

---

## 💻 Como Executar o Projeto

### 🧰 Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- Servidor **MySQL** (local ou remoto)

### ⚙️ Passos

1. **Clonar o Repositório**

   ```bash
   git clone <https://github.com/Diofbjr/minimal-api>
   cd minimal-api

2. Configurar o Banco de Dados

Crie o banco no seu servidor MySQL e atualize o appsettings.json:

"ConnectionStrings": {
  "mysql": "Server=localhost;Port=3306;Database=<SEU_DB>;Uid=<SEU_USER>;Pwd=<SUA_SENHA>;"
},
"jwt": "SUA_CHAVE_SECRETA_MUITO_LONGA_AQUI"

Em seguida, aplique as migrações:

dotnet ef database update

Administrador padrão (seed):

Email: administrador@teste.com
Senha: 123456

3. Executar a API

dotnet run

A API estará disponível em:

http://localhost:<PORTA>


4. Acessar a Documentação (Swagger)
http://localhost:<PORTA>/swagger


🧪 Testes Automatizados

O projeto inclui testes de unidade e integração, utilizando:

MSTest

WebApplicationFactory

Mocks para simular dependências

Os testes garantem a integridade e o comportamento correto dos serviços e endpoints.

👨‍💻 Autor

Desenvolvido por [https://github.com/Diofbjr]
📫 Entre em contato: [diogofbjr@gmail.com]
🌐 GitHub: https://github.com/Diofbjr

🏅 Licença

Este projeto está sob a licença MIT — sinta-se livre para usar e modificar.

⭐ Se este projeto te ajudou, deixe uma estrela no repositório!

Ajuda muito o desenvolvedor 😊

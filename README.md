
# User Management API

Esta aplicação é uma API para gerenciamento de usuários, construída com .NET Core e utilizando o Amazon DynamoDB como banco de dados para armazenar as informações dos usuários.

## Tecnologias Utilizadas

- **.NET Core 6+**: Framework principal para o desenvolvimento da API.
- **Amazon DynamoDB**: Banco de dados NoSQL utilizado para armazenar os dados dos usuários.
- **AWS SDK para .NET**: Para interação com o DynamoDB.
- **Swagger**: Para documentação da API e testes interativos via interface.

## Funcionalidades

- **Adicionar um usuário**: Endpoint para cadastrar um novo usuário.
- **Listar todos os usuários**: Endpoint para listar todos os usuários cadastrados.
- **Buscar usuário por ID**: Endpoint para buscar um usuário específico pelo seu ID.
- **Atualizar usuário**: Endpoint para atualizar informações de um usuário existente.
- **Excluir usuário**: Endpoint para deletar um usuário.

## Endpoints

### 1. `POST /users`

**Descrição**: Cria um novo usuário na base de dados.

**Exemplo de corpo da requisição**:
```json
{
  "id": "123",
  "name": "João Silva",
  "email": "joao.silva@email.com"
}
```

### 2. `GET /users`

**Descrição**: Retorna todos os usuários cadastrados.

**Resposta de exemplo**:
```json
[
  {
    "id": "123",
    "name": "João Silva",
    "email": "joao.silva@email.com"
  },
  {
    "id": "124",
    "name": "Maria Oliveira",
    "email": "maria.oliveira@email.com"
  }
]
```

### 3. `GET /users/{id}`

**Descrição**: Retorna um usuário específico pelo ID.

**Exemplo de resposta**:
```json
{
  "id": "123",
  "name": "João Silva",
  "email": "joao.silva@email.com"
}
```

### 4. `PUT /users/{id}`

**Descrição**: Atualiza as informações de um usuário existente.

**Exemplo de corpo da requisição**:
```json
{
  "id": "123",
  "name": "João Silva Atualizado",
  "email": "joao.silva.updated@email.com"
}
```

### 5. `DELETE /users/{id}`

**Descrição**: Deleta um usuário da base de dados.

**Resposta de exemplo**: Status 200 OK

---

## Configuração e Execução

### 1. Configurar AWS

Antes de executar a aplicação, você precisa ter uma conta AWS configurada e o **AWS SDK** configurado com credenciais de acesso.

- Crie uma tabela no DynamoDB com o nome **"Users"**.
- Se você ainda não tem, instale e configure o [AWS CLI](https://aws.amazon.com/cli/) e configure as credenciais com o comando:

```bash
aws configure
```

Isso definirá suas credenciais de acesso para a aplicação.

### 2. Configurar a Aplicação

A aplicação requer o AWS SDK para interagir com o DynamoDB. Para configurar, siga os passos abaixo:

1. **Instalar dependências**:
   A aplicação utiliza pacotes do AWS SDK para .NET. Você pode instalar esses pacotes via NuGet:

   ```bash
   dotnet add package AWSSDK.DynamoDBv2
   ```

2. **Alterar o nome da tabela**:
   Certifique-se de que a tabela do DynamoDB seja chamada `Users`. Caso contrário, altere a constante `TableName` na classe `UserRepository` para o nome correto da tabela.

3. **Configuração do DynamoDB**:
   No arquivo `UserRepository.cs`, o cliente do DynamoDB será instanciado e configurado. Caso deseje mudar a região, adicione a seguinte configuração no código:

   ```csharp
   var config = new AmazonDynamoDBConfig
   {
       RegionEndpoint = RegionEndpoint.USEast1 // Defina a região correta
   };
   _dynamoDbClient = new AmazonDynamoDBClient(config);
   ```

### 3. Executando a Aplicação

Após configurar as credenciais da AWS e a tabela do DynamoDB, você pode executar a API localmente com o comando:

```bash
dotnet run
```

A aplicação será executada na URL `http://localhost:5000`.

---

## Testando a API

### Usando o Swagger UI

A API expõe uma interface Swagger, permitindo que você faça testes diretamente no navegador. Acesse a seguinte URL:

```
http://localhost:5000/swagger
```

Na interface do Swagger, você pode testar todos os endpoints da API de maneira interativa.

---

## Estrutura do Projeto

O projeto é organizado da seguinte maneira:

```
/src
  /Api
    /Controllers
      - UserController.cs   # Controlador da API com os endpoints
    /Models
      - User.cs             # Modelo de dados do usuário
    /Repositories
      - UserRepository.cs   # Repositório responsável pela interação com o DynamoDB
    /Services
      - UserService.cs      # Lógica de negócios e manipulação dos usuários
  /UserManagementApi.sln     # Solução do Visual Studio
```

---

## Contribuindo

Se você deseja contribuir para este projeto, por favor, siga as etapas abaixo:

1. Faça um fork deste repositório.
2. Crie uma branch para sua feature ou correção (`git checkout -b feature/nome-da-feature`).
3. Realize as alterações e faça commit (`git commit -m 'Adicionando nova funcionalidade'`).
4. Envie as alterações para o seu fork (`git push origin feature/nome-da-feature`).
5. Abra um pull request para a branch `main` deste repositório.

---

## Licença

Este projeto está licenciado sob a Licença MIT - consulte o arquivo [LICENSE](LICENSE) para mais detalhes.

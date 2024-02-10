# AdaFood Delivery Driver API 🚚
Bem-vindo à API AdaFood Delivery Driver, uma plataforma para gerenciar o cadastro de entregadores!

## Visão Geral
A API AdaFood Delivery Driver é um serviço construído com C# e ASP.NET Core. 
Ela fornece funcionalidades para cadastrar e gerenciar entregadores. 
A API incorpora dois filtros principais: 
- Um filtro de exceção que atua globalmente para tratar erros de maneira consistente;
- Um filtro de autorização aplicado apenas ao adicionar novos entregadores, que demanda um query param `admin` = `true`.
Obs.: a utilização do `admin` como query param é tão somente ilustrativa, já que não é a medida segura a ser adotada.  

## Funcionalidades
- **Cadastrar Entregador**: Adicionar um novo entregador ao sistema.
- **Obter Todos os Entregadores**: Obter uma lista de todos os entregadores cadastrados.

## Filtros
- **Filtro de Exceção Global**: o filtro de exceção global garante uma resposta consistente em caso de erros, fornecendo uma mensagem amigável ao usuário.

[!Utilização do Filtro de Excelção](https://github.com/armentanoc/AdaFood/assets/88147887/9a4e8214-69d7-4f4f-8d65-15f6f2f23df2)
  
- **Filtro de Autorização para Adicionar Entregador**: o filtro de autorização específico para a adição de entregadores garante que apenas usuários autorizados (com parâmetro `admin` = `true`) possam realizar essa operação.

[!Utilização do Filtro de Autorização](https://github.com/armentanoc/AdaFood/assets/88147887/0adc0f04-c350-43af-af45-b9948cd2de25)

## Endpoints da API
`GET /api/deliverydriver/all`: Obter todos os entregadores cadastrados.
`GET /api/deliverydriver/cpf/{cpf}`: Obter o entregador por CPF.
`GET /api/deliverydriver/id/{id}`: Obter o entregador por Id. 
`POST /api/deliverydriver/`: Adicionar um novo entregador.

## Exemplo de Uso

- **Adicionar Entregador**:

```http
POST /api/deliverydriver/add?admin=true
Content-Type: application/json

{
    "name": "Fernando",
    "cpf": "43276498701"
}
```

- **Obter Todos os Entregadores**:
  
```http
GET /api/deliverydriver/all
```

## Como Começar

1. Clone o repositório:

  ```bash
  git clone https://github.com/armentanoc/AdaFood.git
  ```

2. Instale as dependências:

  ```bash
  dotnet restore
  ```

3. Execute a aplicação:

  ```bash
  dotnet run
  ```

Acesse a API em `http://localhost:5000/api` por padrão.

## Contribuições
Aceitamos contribuições! Se encontrar um bug ou tiver uma solicitação de recurso, por favor, abra uma issue. 🛠️

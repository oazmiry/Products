# Products
Me learning GraphQL, inspired by a [great tutorial](https://dev.to/dotnet/how-you-can-build-a-web-api-using-graphql-net-core-and-entity-framework-1ago)

## Prerequisites
You have two options:
1) Preferably, Docker.
2) A running Sql Server on "localhost", with a permissioned user for the credentials in your environment.


## Running using docker
From the project's root (at the same level of the .sln file)
```bash
docker-compose build
docker-compose up
```

## Running from command line
You may change the appsettings file or create a new one, then run:
```bash
cd Products.SI
dotnet run --environment <YourEnv>
```

## Examples
GraphQL query for sellers with their items:
```graphql
query {
  sellers {
    name,
    items {
     description 
    }
  }
}
```
GraphQL mutation for new seller which retrieves only his id:
```graphql
mutation {
  addSeller(name: "New boy") {
    id
  }
}

```

## Future plans
* Write unit tests
* Write integration tests

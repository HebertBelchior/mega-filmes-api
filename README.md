
# Mega Filmes

API construída para gerenciar uma página de filmes, onde é possível criar um filme, adicionar seu elenco, avaliar com nota e fazer comentários.

## Screenshot

![App Screenshot](https://github.com/saulomagalhaes/mega-filmes/blob/main/images/swagger1.jpg)


## Autor

- [@saulomagalhaes](https://www.linkedin.com/in/sauloam/)


## Stack utilizada

**Back-end:** C#, ASP.NET Core, Entity Framework e SQL Server.




## Funcionalidades

- Criar, atualizar, deletar e buscar filmes
- Adicionar elenco a um filme
- Adicionar uma avaliação contendo nota e comentário



## Rodando aplicação
- Essa aplicação roda o banco de dados sql server através do docker, que pode ser instalado através do link: https://www.docker.com/products/docker-desktop

Faça o clone do projeto:
```bash
  git clone git@github.com:saulomagalhaes/mega-filmes.git
```
Entre na pasta do projeto e execute o comando:
```bash
  docker-compose up -d
```
Suba as tabelas para o banco de dados:
```bash
  Update-Database ou dotnet ef database update
```
Rode a aplicação
```bash
  dotnet ef run
```
## Documentação
Esta é a rota para a documentação da API:

https://localhost:7030/swagger/index.html


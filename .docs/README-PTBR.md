
# LAB Clothing Collection
[ [English](../README.md) ]

Bem-vindo à LAB Clothing Collection – um estudo na criação de uma API REST dinâmica. Nosso objetivo é harmonizar a satisfação dos desenvolvedores, desempenho, melhores práticas de codificação e lógica de negócios. Ao abraçar DDD, SOLID e padrões modernos, estamos criando uma API que se destaca pelo equilíbrio. Mitigamos as trocas de desempenho usando código gerado a partir de fonte, estruturas avançadas de DTO, classes seladas, procedimentos SQL e cache.

Este empreendimento resulta em um sistema potencialmente escalável e de alto desempenho, oferecendo flexibilidade e facilidade de manutenção. Inspirada por cenários reais de moda, a LAB Clothing Collection permite que os usuários gerenciem coleções e modelos de moda. Uma evolução do DEVinHouse Audaces v2, explore o original [aqui](https://github.com/gmessiasc/LABCC-Back-End-Csharp).

Cada decisão tomada para o design deste sistema é meticulosamente documentada e justificada. Agradecemos qualquer sugestão de melhoria que você possa ter.

## Indice
1. [Tecnologias](#1-tecnologias)
2. [How To Build And Run](#2-como-construir-e-executar)
3. [Features and Documentation](#3-funcionalidades-e-documentação)
4. [Software Design](#4-design-de-software)
5. [TODO](#5-próximos-passos-)
6. [Reference](#6-referências)

## 1. Tecnologias

- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/) e [.NET Core 8.0](https://dotnet.microsoft.com/pt-br/) - Expansão para incluir outras versões de linguagens no futuro (por exemplo, Java com Quarkus e Go).
- [Fast Endpoints](https://fast-endpoints.com/) - Este framework oferece endpoints de alto desempenho semelhantes ao Minimal API, com organização de código aprimorada e uma arquitetura limpa. Ele se integra perfeitamente a outras bibliotecas.
- [Dapper](https://github.com/DapperLib/Dapper) - Um MicroORM focado em desempenho que evita complexidade excessiva. Optamos pelo Dapper devido ao seu desempenho e flexibilidade no uso de consultas personalizadas complexas quando necessário.
- [ValueOf](https://github.com/mcintyre321/ValueOf) - Permite a criação de ValueObjects com facilidade. Isso nos permite encapsular a lógica de objetos de valor dentro deles mesmos, promovendo uma linguagem mais flexível, abrangente e um contexto delimitado. Lógica complexa pode ser escrita em Value Objects para reutilização universal.
- [BCrypt](https://github.com/BcryptNet/bcrypt.net) ou [Argon2](https://github.com/mheyman/Isopoh.Cryptography.Argon2) - Após cuidadosa consideração, tendemos a usar BCrypt devido ao equilíbrio entre segurança e desempenho. O Argon2 é mais seguro, mas mais lento, o que pode afetar o desempenho da API.
- [SQL Server 2022](https://www.microsoft.com/pt-br/sql-server/sql-server-2022) - Escolhido principalmente devido ao ambiente .NET Core do projeto. Adotamos uma abordagem de banco de dados primeiro para melhor desempenho e flexibilidade. O script SQL incluído nos recursos automatiza a geração de dados de inicialização do banco de dados e fornece procedimentos armazenados.
- [Docker](https://www.docker.com/) - Facilita a execução e implantação fácil do projeto.

## 2. Como construir e executar

Para construir o projeto LAB Clothing Collection, siga estas etapas:

1. Comece criando um arquivo `.env`. Um exemplo chamado `.env.example` contém todas as variáveis de ambiente necessárias. Você pode atualizar essas variáveis com seus próprios valores ou usar as variáveis de exemplo conforme estão. Basta copiar o conteúdo do arquivo para um novo arquivo `.env` localizado no diretório raiz. Exemplo de .env:
```.env
# SQLSERVER
DB_HOST=labcc-db
DB_PORT=1433
DB_NAME=labclothingcollectionbd
DB_USER=sa
DB_PASSWORD=1456789!AbcDeFg

# JWT
JWT_SECRET=MysteriousSecretForJwt
```
-  `DB_HOST`  é o nome do container Docker para o banco de dados. Se você não estiver usando o Docker, ele deve ser algo como "localhost,1433".

2. Como mencionado acima, é necessário configurar uma instância do SQL Server que contenha um banco de dados com um nome equivalente à variável **DB_NAME** no arquivo `.env`. Isso pode ser feito de várias maneiras, mas por padrão, siga estas etapas:
   - Inicie a instância do Docker do banco de dados com o comando:
      ```bash
       docker-compose up labcc-db -d
      ```
   
   - Aguarde até que o SQL Server seja inicializado corretamente e, em seguida, crie o banco de dados. Você pode usar qualquer ferramenta de gerenciamento de banco de dados ou até mesmo o comando `docker exec` para isso. Por exemplo:
    ```bash
   docker exec -it labcc-mssql /opt/mssql-tools/bin/sqlcmd -S labcc-db -U SA -P 1456789!AbcDeFg -Q 'CREATE DATABASE labclothingcollectionbd;'
   ```
3. Uma vez que o banco de dados estiver em funcionamento, você pode iniciar a aplicação usando o Docker com o comando:
```bash
docker-compose up labcc-app
```
- Essa opção executará a aplicação no localhost exposto na configuração do Docker Compose, normalmente na porta 8080. Você pode acessar a documentação da API Swagger em http://localhost:8080/swagger.
<br><br>
- Durante a execução, a aplicação lerá o arquivo .env e executará scripts SQL para configurar o banco de dados, incluindo a etapa inicial de migração (caso seja a primeira vez que está sendo executada).
<br><br>
- Alternativamente, você pode executar a aplicação localmente navegando até o diretório LABCC.Application e usando os comandos dotnet watch ou dotnet run.
<br><br>
- Você também pode construir a aplicação usando os seguintes comandos: dotnet restore, dotnet build e dotnet publish. Isso gerará o DLL executável que você pode usar para executar a aplicação localmente.

### Explicação da Abordagem

- O arquivo .env simplifica a configuração tanto para a API quanto para o banco de dados. Ele permite ajustes fáceis e um reinício sem problemas, restaurando os containers Docker conforme necessário.
- Os scripts SQL são executados sob demanda para migrações manuais do banco de dados. Como o Dapper não possui opções automatizadas de migração, essa abordagem garante atualizações precisas do banco de dados em sincronia com as mudanças na aplicação.

## 3. Funcionalidades e Documentação

- Para informações organizadas e abrangentes, cada funcionalidade é acompanhada por documentação dedicada na pasta .docs:
<br><br>
    - **Autenticação: [Documentação de Autenticação](.docs/Auth.md)**
    - **Gerenciamento de Usuários: [Documentação de Usuários](.docs/Users.md)**
    - **Coleções de Roupas:** _(Em Breve)_
    - **Modelos de Roupas:** _(Em Breve)_
      <br><br>
- Essa estrutura fornece insights claros sobre a criação de funcionalidades, implementação e lógica de negócios subjacente.

## 4. Design de Software

- O projeto é dividido em três módulos: Application, Domain e Infra.

### Application
- O módulo Application gerencia as entradas e atua como a interface de usuário final. Ele utiliza o FastEndpoints para lidar com as solicitações, adota uma abordagem simples de Autenticação Jwt Bearer Token e Autorização de Funções para segurança, e utiliza cache em memória para aprimorar o desempenho. Este módulo também utiliza registros em solicitações e respostas, mapeadores simples e o FluentValidator do FastEndpoint para processos simplificados.

- Para aprimorar a responsabilidade única dentro das classes, nós dividimos as funcionalidades em casos de uso distintos. Essa estratégia promove um código mais organizado e focado.

### Domain
- O núcleo do projeto está no módulo Domain, que abriga a lógica de negócios usando interfaces para IoC, Enums, Exceções, ferramentas utilitárias, Aggregate Roots e ValueObjects. As entidades neste módulo são autocontidas, equipadas com Params e Dto (incluindo registros) para gerenciar os dados. Aggregate Roots representam grupos de objetos de valor, sendo que cada propriedade do Aggregate Root tem a capacidade de se gerenciar por si mesma – como senhas que podem se auto-hascar e verificar. Este módulo simplifica validação, conversão e código, aprimorando a clareza.

### Infrastructure 
- O módulo Infrastructure lida com configurações mais amplas, como acesso externo e inicialização. Ele garante um ambiente operacional suave para a execução do projeto.

### Test 
- _Em Breve_

## 5. Próximos Passos 
- Iniciar com testes unitários para garantir a qualidade do código.
- Aperfeiçoar a documentação, focando tanto em guias para os usuários quanto em detalhes de autenticação.
- Implementar recursos avançados para usuários, como Atualização e Exclusão com permissões personalizáveis.
- Integrar ações do Github para integração contínua.
- Introduzir um provedor de cache externo usando Redis para otimizar o desempenho.
- Adicionar recursos abrangentes para Coleções de Roupas.
- Desenvolver recursos abrangentes para Modelos de Roupas.
- Continuar expandindo e aprimorando o projeto com mais a caminho.

## 6. Referências
- Alguns projetos que serviram de inspiração:
    - [Elfocrash/clean-minimal-api](https://github.com/Elfocrash/clean-minimal-api)
    - [dj-nitehawk/MiniDevTo](https://github.com/dj-nitehawk/MiniDevTo)

# API Encurtador :star:
Este é um projeto de API para encurtamento de URLs, baseado no repositório [backend-br/desafios](https://github.com/backend-br/desafios). A ideia básica foi aprimorada com a aplicação de práticas avançadas e padrões de desenvolvimento para tornar a API mais robusta e profissional.

#### :warning: Regras :warning:
O usuário deve informar uma URL válida, que não pode ser nula e deve conter os prefixos "https://" ou "http://".  
As URLs encurtadas têm um prazo de validade de 4 horas. Após esse período, não podem mais ser utilizadas.  
Uma vez ao dia, o job do Quartz inativa as URLs, impedindo o seu uso.  
Após uma semana, o job do Quartz exclui fisicamente as URLs do banco de dados.  

#### Tecnologias Utilizadas
C# .NET 7  
Docker  
Banco de Dados Relacional: PostgreSQL  
Banco de Dados NoSQL: Redis  
Quartz (para gerenciamento de jobs)  
FluentValidation (para validações de entrada)  

#### Estrutura do Projeto
O projeto utiliza a arquitetura em camadas, seguindo os seguintes padrões:

**API**: Camada de interface de usuário, responsável por receber as requisições HTTP e fornecer as respostas.  
**Application**: Camada de aplicação, contendo a lógica de negócio da aplicação.  
**Domain**: Camada de domínio, contendo as entidades e regras de negócio.  
**Repository**: Camada de acesso a dados, responsável por interagir com o banco de dados.  
**IoC**: Camada de configuração de injeção de dependência.  
**Shared**: Camada contendo componentes compartilhados, como classes utilitárias, helpers e extensões.  

#### Instalação do Redis com .NET
Para utilizar o Redis com .NET, siga os passos abaixo:

Inicie uma instância do Redis localmente. Você pode usar o Docker para isso, executando o seguinte comando:

```docker run -d -p 6379:6379 --name redis redis```

Após iniciar o Redis, instale um cliente Redis para acessar o serviço e verificar os pares chave-valor salvos. Recomendamos o uso do "Another Redis Desktop Manager".

#### Configuração
Clone o repositório para a sua máquina local.  
Certifique-se de ter o PostgreSQL e o Redis instalados e configurados corretamente.  
Abra o arquivo **appsettings.json** e configure a conexão com o banco de dados PostgreSQL.  
Execute as migrações para criar as tabelas necessárias no banco de dados PostgreSQL.  
Execute o projeto para iniciar a API.  

#### Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues relatando problemas, sugerir melhorias ou enviar pull requests com suas contribuições.

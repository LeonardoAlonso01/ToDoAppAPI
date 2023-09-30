ToDoApp API
Esta é uma API em .NET para um aplicativo de lista de tarefas (ToDoApp) que demonstra o uso de várias tecnologias e padrões, incluindo Arquitetura Limpa, Entity Framework com Migrations, Padrão CQRS, Padrão Repository, Validações de Dados de Entrada com Fluent Validation, Autenticação com JWT e Testes Unitários com a biblioteca xUnit.

Tecnologias e Padrões Utilizados
.NET Core: Esta API é desenvolvida em .NET Core.

Entity Framework: Utilizado o Entity Framework para interagir com o banco de dados. As migrações são usadas para gerenciar o esquema do banco de dados.

CQRS (Command Query Responsibility Segregation):Utilizado o padrão CQRS para separar as operações de leitura (queries) das operações de escrita (comandos), o que ajuda a melhorar a escalabilidade e a manutenção da aplicação.

Padrão Repository: Foi implementado o padrão Repository para isolar a lógica de acesso aos dados do restante da aplicação, tornando-o mais testável e flexível.

Fluent Validation: Para garantir a validação dos dados de entrada, foi utilizado a biblioteca Fluent Validation, que permite definir regras de validação de forma concisa e expressiva.

Autenticação com JWT (JSON Web Tokens): Aautenticação de usuários é feita utilizando JWT, o que permite que os usuários façam login e recebam tokens JWT para autenticação subsequente.

Testes Unitários com xUnit: Os testes unitários foram desenvolvidos usando a biblioteca xUnit, que ajuda a garantir que as funcionalidades estejam funcionando conforme o esperado e que a aplicação permaneça robusta durante o desenvolvimento contínuo.

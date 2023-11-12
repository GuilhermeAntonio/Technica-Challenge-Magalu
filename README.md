




# Technical-Challenge-Magalu 💻

<br/>

Este é um projeto de aplicação web desenvolvido como parte de um desafio técnico que abrange três fases distintas, com foco no desenvolvimento de um módulo de login.

No front-end, foi utilizado HTML, JavaScript, CSS e Bootstrap. O back-end foi desenvolvido com ASP.NET MVC 6, e o banco de dados utilizado é o SQL Server.

A seguir, uma descrição da organização do projeto, com uma explicação de cada fase e algumas orientações para a execução da aplicação em ambiente local.
<br/>

## Estrutura 

<br/>

> 📂 Cada fase está organizada em uma pasta separada neste repositório, seguindo a seguinte nomenclatura: 
> +  Fase 1 - Front End;
> +  Fase 2 - Back End;
> +  Fase 3 - Banco de dados.

<br/>

## Fase 1 - Front End

<br/>

Nesta fase, foi implementado  um formulário de login responsivo usando HTML, CSS, Bootstrap e validação dos campos com JavaScript.

![282300081-5625ef90-8f53-4c7c-b14e-1ef16d63686a](https://github.com/GuilhermeAntonio/Technica-Challenge-Magalu/assets/32369563/65f2c35b-256d-4160-b34a-10ba7a6ba18b)



<br/>

## Fase 2 - Back End

<br/>

No back-end da página de login, foi utilizado credenciais fixas para validação. Se as credenciais estiverem corretas, o usuário é redirecionado para uma página de boas-vindas.

<br/>

> 🔑 Credenciais Fixas 
<table>
  <tr>
    <td>Usuário</td>
    <td>Senha</td>
  </tr>
  <tr>
    <td>magalu</td>
    <td>m@galu123</td>
  </tr>
</table>

<br/>

Após o login, as credenciais são armazenadas em um cookie que mantém o usuário logado no sistema até que ele faça logout ou até que o cookie expire após 1 hora.

<br/>

> ℹ️ Embora fosse possível realizar toda a validação e controle em uma única classe, todas as funções relacionadas à autenticação do usuário foram feitas usando Injeção de Dependência para evitar redundâncias e manter a responsabilidade única, assim como é passado no padrão SOLID.



![282300317-d9a5d190-8f3a-44cb-9b4a-9bea05897524](https://github.com/GuilhermeAntonio/Technica-Challenge-Magalu/assets/32369563/b1b8553b-2ba2-46ad-9906-9b19cab923c7)



<br/>


## Fase 3 - Banco de dados

<br/>


Para a implementação do banco de dados, foi utilizado o Entity Framework. Como esta é a última etapa do desafio, foi adotado a abordagem Code First, que usa um modelo de entidade como base para a criação do banco e geração do scripts SQL.

<br/>





### Conectando Banco

<br/>


Para conectar o banco criado com a aplicação, é necessário fazer uma alteração no código. Isso é feito no arquivo "appsettings.json", onde é registrada uma string de conexão com os dados de acesso do banco de dados. Observação, o formato da string de conexão pode variar dependendo do tipo de autenticação, seja "Windows Authentication" ou "SQL Server Authentication". Mais adiante, será informado o padrão para cada caso.

<br/>

#### Arquivo da alteração

<br/>

Localização do arquivo "appsettings.json":
~~~
├── Fase 3 - Banco de dados
│   ├── Fase3
│   │   └── appsettings.json
│   └── 
└── 
~~~

<br/>

#### String de conexão (Windows Authentication)

<br/>

O JSON a baixo é um exemplo de como a conexão deve ser alterada para casos que usam Windows Authentication, com as seguintes credenciais de banco:

> + Server=MeuServidor 

<br/>

~~~JSON
  "ConnectionStrings": 
  {
    "DefaultConnection": "server=MeuServidor; Database=DbUsersMagalu; Integrated Security=SSPI; TrustServerCertificate=True"
  },
~~~

<br/>

#### String de conexão (SQL Server authentication)

<br/>

  O JSON a baixo é um exemplo de como a conexão deve ser alterada para casos que usam autenticação SQL Server, com as seguintes credenciais: 

> + Server=MeuServidor 
> + User Id=MeuUsuario
> + Password=MinhaSenha

<br/>

~~~JSON

  "ConnectionStrings": {
    "DefaultConnection": "Server=MeuServidor; Database=DbUsersMagalu; User Id=MeuUsuario; Password=MinhaSenha; TrustServerCertificate=True"
  },

~~~


<br/>

### Criando Banco 

Com a string de conexão configurada, já podemos criar o banco de dados:

<br/>

#### Usando Migrations


Após configurar as conexões, para criar o banco de dados, basta acessar o terminal NuGet no Visual Studio (Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes) e executar o comando a baixo:"

~~~JS
update-database
~~~

Esse comando executará o arquivo de migração do Entity Framework e criará o banco de dados, a tabela e o registro de 3 usuários.

<br/>

#### Criando manualmente 


Além do uso do Migrations, o banco de dados e as tabelas também podem ser criados manualmente executando o seguinte script no SQL Server:

<br/>



> ⚠️ Alterações nas nomenclaturas do banco pode prejudicar o funcionamento da aplicação. 

```SQL

CREATE DATABASE DbUsersMagalu;
GO

CREATE TABLE DbUsersMagalu.dbo.Tb_Usuarios (
    [Id] INT NOT NULL IDENTITY,
    [UserName] VARCHAR(30) NOT NULL,
    [Password] VARCHAR(30) NOT NULL,
    CONSTRAINT [PK_Tb_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_UserName] UNIQUE ([UserName]) 
);
GO

INSERT INTO DbUsersMagalu.dbo.Tb_Usuarios ([UserName], [Password]) VALUES
        ('magalu', 'm@galu123'),
        ('guilherme', 'gui@magalu'),
        ('Lu', 'lu@2023');

```
<br>

#### Usuarios cadastraos

<br/>


> 🔑 Tanto a criação do banco por Migrations quanto a criação manual através do script cadastra os seguintes usuários:

<br/>


<table>
  <tr>
    <td>Usuário</td>
    <td>Senha</td>
  </tr>
  <tr>
    <td>magalu</td>
    <td>m@galu123</td>
  </tr>
    <tr>
    <td>guilherme</td>
    <td>gui@magalu</td>
  </tr>
    <tr>
    <td>Lu</td>
    <td>lu@2023</td>
  </tr>
</table>

<br/>

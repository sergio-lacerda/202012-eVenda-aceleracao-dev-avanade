NomeProjeto

Repositório para projeto referente ao programa Aceleração Global Dev #3 Avanade, através da plataforma Digital Innovation One. O projeto foca a integração entre sistemas (Estoque e Vendas) através de recurso do Azure Service Bus.

Começando

Este projeto foi desenvolvido no Visual Studio 2019, segundo o modelo de aplicação web MVC, utilizando Entity Framework e Migrations, com uma abordagem Code First.

Configuração

Para que o projeto funcione corretamente, é importante configurar previamente os Tópicos e Subscrições utilizadas no Azure Service Bus, obtendo uma string de conexão com esse ambiente. Essa string de conexão deve ser inserida em ambos os módulos (Estoque e Vendas), nos arquivos das classes Util.cs, linha 29, completando a instrução public static readonly string AzureConnStr = "Insira sua string de conexão aqui";

Licença

Não se aplica
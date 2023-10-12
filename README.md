![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white) ![RabbitMQ](https://img.shields.io/badge/Rabbitmq-FF6600?style=for-the-badge&logo=rabbitmq&logoColor=white) ![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)

# Projeto Envio e Rececimento - RabbitMQ
Em um ambiente de arquitetura orientada a serviços, foi implementado um sistema distribuído que utiliza a infraestrutura de mensageria RabbitMQ e banco de dados SQL Server para orquestrar a transmissão e persistência de objetos de dados. Ambos os serviços de back-end, RabbitMQ e SQL Server, estão hospedados em um servidor Linux, otimizado para alta disponibilidade e desempenho.

O sistema é composto por dois componentes principais:

API Produtora: Esta aplicação é responsável por enviar objetos serializados para uma fila específica no RabbitMQ. Ela atua como um produtor na arquitetura de mensageria, utilizando a biblioteca cliente do RabbitMQ para enfileirar mensagens.

Serviço Consumidor: Este é um serviço de back-end dedicado que atua como consumidor das mensagens enfileiradas no RabbitMQ. Ao receber uma mensagem, ele a deserializa e executa operações de Create no SQL Server para persistir o objeto de dados.

Ambos os componentes utilizam autenticação e criptografia para garantir a segurança dos dados em trânsito e em repouso. Além disso, são implementadas estratégias de tolerância a falhas, como re-tentativas e enfileiramento de mensagens em uma fila de erros para tratamento posterior.

O RabbitMQ atua como um intermediário confiável e resiliente, garantindo que as mensagens sejam entregues de forma confiável ao serviço consumidor, mesmo em face de falhas de rede ou de sistema.

Esta arquitetura proporciona uma separação de responsabilidades, permitindo que cada componente seja escalado, mantido e atualizado de forma independente, enquanto oferece um mecanismo robusto para a integração de sistemas e a persistência de dados.


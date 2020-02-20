# Sobre
Um simples roteirizador com frontend em React e backend em .Net Core

## Tela
Abaixo a interface do roteirizador no navegador:
![Image of the desktop view](https://github.com/fsbflavio/RoterizadorWebApi/raw/master/roterizador-view-desktop.jpg)

## Tecnologias utilizadas
### Frontend:
Utilizado React com a biblioteca [https://github.com/fullstackreact/google-maps-react] e fazendo o uso das seguintes apis do Google  
[Directions API](https://developers.google.com/maps/documentation/directions/start?hl=pt_BR)  
[Geocoding API](https://developers.google.com/maps/documentation/geocoding/start?hl=pt_BR)  
[Maps JavaScript API](https://developers.google.com/maps/documentation/javascript/tutorial?hl=pt_BR)  
[Places API](https://developers.google.com/places/web-service/intro?hl=pt_BR)

### Backend:
API REST utilizando .Net Core 3.1 conectado com banco de dados PostgreSQL via EntityFrameworkCore.

## Instruções para execução
### Frontend:
Apos baixar o projeto acessar a pasta roterizador-ui-react e executar na ordem:  
`npm install`  
`npm start`

*O frontend pode ser executado sem o backend, o roteamento funcionara normalmente, apenas não serão salvas as rotas.

### Backend:
-Instalar o banco de Dados PostgreSQL
-Apos baixar o projeto abrir a solução Roteirizador.WebApi.sln no VisualStudio.  
-Compilar a solução  
-alterar a string de conexao com o banco de dados no arquivo 
-Executar no Package Manager Console o comando abaixo para criar o banco de dados.  
`Update-Database`

*É necessário ter o SGBD PostgreSQL instalado na maquina. o PostgreSQL pode ser obtido gratuitamente [aqui](https://www.postgresql.org/download/).

*Se o banco ja estiver criado é possível executar diretamente via linha de comando:  
`dotnet restore`  
`dotnet build`  
`dotnet run`  

## Demo
Demonstração da aplicação em execução sem o backend está disponível [aqui](https://roteirizador-react.azurewebsites.net/)

# Sobre
Um simples roterizador com frontend em React e backend em .Net Core

## Telas
Abaixo a interface do roterizador no navegador:
![Image of the desktop view](https://github.com/fsbflavio/RoterizadorWebApi/raw/master/roterizador-view-desktop.jpg)

## Instruções para execução
### Frontend:
Apos baixar o projeto acessar a pasta roterizador-ui-react e executar na ordem:  
`npm install`  
`npm start`

*O frontend pode ser executado sem o backend, o roteamento funcionara normalmente, apenas não serão salvas as rotas.

### Backend:
-Instalar o banco de Dados Postgres
-Apos baixar o projeto abrir a solução Roteirizador.WebApi.sln no VisualStudio.  
-Compilar a solução  
-Executar no Package Manager Console o comando abaixo para criar o banco de dados.  
`Update-Database`

*É necessario ter o SGBD PostgreSQL instalado na maquina. o PostgreSQL pode ser obtido gratuitamente [aqui](https://www.postgresql.org/download/).

*Se o banco ja estiver criado é possivel executar diretamente via linha de comando:  
`dotnet restore`  
`dotnet build`  
`dotnet run`  

## Demo
Demonstração da aplicação em execução sem o backend[Demo]()

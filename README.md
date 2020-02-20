# Sobre
Um simples roterizador com frontend em React e backend em .Net Core

## Telas
Abaixo a interface do roterizador no navegador:
![Image of the desktop view](https://github.com/fsbflavio/RoterizadorWebApi/raw/master/roterizador-view-desktop.jpg)

## Demo
Para a construção do roteirizador, poderão ser utilizadas quaisquer ferramentas e bibliotecas de mapa que o usuário desejar. Embora, sugerimos: [Google](https://developers.google.com/maps/documentation/javascript/tutorial), [MapBox](https://docs.mapbox.com/) ou [Leaflet](https://leafletjs.com/reference-1.5.0.html).

## Instruções para execução
### Frontend:
Apos baixar o projeto acessar a pasta roterizador-ui-react e executar na ordem:  
`npm install` 
`npm start`

*O frontend pode ser executado sem o backend, o roteamento funcionara normalmente, apenas não serão salvas as rotas.

### Backend:
-Apos baixar o projeto abrir a solução Roteirizador.WebApi.sln no VisualStudio.  
-Compilar a solução  
-Executar no Package Manager Console o comando abaixo para criar o banco de dados.  
`Update-Database`  

*Se o banco ja estiver criado é possivel executar diretamente via linha de comando:  
`dotnet restore`  
`dotnet build`  
`dotnet run`  

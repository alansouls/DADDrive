# DADDrive

## Configurar ambiente no linux para rodar o projeto (Ubuntu 18.04)
 * Faça download do pacote com os seguintes comandos:   
 <code>wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb</code>    
 <code>sudo dpkg -i packages-microsoft-prod.deb</code>
 * Instale o SDK com os seguintes comandos:  
  <code>sudo apt-get update </code>  
  <code> sudo apt-get install -y apt-transport-https </code>  
  <code> sudo apt-get update </code>  
  <code> sudo apt-get install -y dotnet-sdk-3.1</code>  
 * Para rodar, dentro da pasta do projeto execute:
 <code> sudo dotnet run </code>
 
## Configurar o apache para redirecionar para aplicação:
 * Copie o arquivo daddrive.conf na pasta apache_files do projeto para a pasta /etc/apache2/sites-available
 * Desative qualquer site que esteja ativo no apache com o comando a2dissite ex:  
  <code> sudo a2dissite 000-default.conf </code>  
  Obs: Você pode ver os arquivos de configuração ativados listando os arquivos em /etc/apache2/sites-enabled
 * Ative o site do nosso app com o comando a2ensite:
  <code> sudo a2ensite daddrive.conf </code>
 * Rode a aplicação com o comando: 
  <code> sudo dotnet run --urls "http://*:5000" </code>
 
       

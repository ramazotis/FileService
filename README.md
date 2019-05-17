# FileService

This service enables user to download files from file system in host machine.
Local folder for downloading and supported file extensions can be setted in cervice appsettings.json file.

## Build

1) Enter in project folder
2) run command: `dotnet restore`
3) run command: `dotnet build Metasite.File.Service.sln`

## Running Server

1) Enter in folder `.\Metasite.File.Service\bin\Debug\netcoreapp2.2`
2) run command: `dotnet Metasite.File.Service.dll`

## Call sample


1) Create dir wwwroot in C drive
2) Create text file test.txt in wwwroot folder
3) Call in web browser `http://localhost:443/test.txt`

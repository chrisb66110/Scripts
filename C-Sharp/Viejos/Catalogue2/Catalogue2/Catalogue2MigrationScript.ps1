#Migrations Catalogue2 Project

cd .\Source\Catalogue2.Dal

dotnet ef migrations add InitialMigration --context Catalogue2Context --output-dir Migrations/Catalogue2 -v -s ..\Catalogue2.Api\Catalogue2.Api.csproj

cd ..\..

#Migrations Catalogue Project

cd .\Source\Catalogue.Dal

dotnet ef migrations add InitialMigration --context CatalogueContext --output-dir Migrations/Catalogue -v -s ..\Catalogue.Api\Catalogue.Api.csproj

cd ..\..

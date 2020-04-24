#Migrations NameProjectVar Project

cd .\Source\NameDALVar

dotnet ef migrations add NameNewMigrationVar --context NameContextVar --output-dir Migrations/NameProjectVar -v -s ..\NameAPIVar\NameAPIVar.csproj

cd ..\..
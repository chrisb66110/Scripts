#Migrations DeployBothSystem Project

cd .\Source\DeployBothSystem.Dal

dotnet ef migrations add InitialMigration --context DeployBothSystemContext --output-dir Migrations/DeployBothSystem -v -s ..\DeployBothSystem.Api\DeployBothSystem.Api.csproj

cd ..\..

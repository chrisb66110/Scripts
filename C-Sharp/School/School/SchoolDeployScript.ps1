$DbServer = "host.docker.internal" #$args[0] #DB Sever

cd .\Source\School.Api

	dotnet build -c release

	dotnet publish -c Release -o publishFolder

	cd .\publishFolder

		$appSettingsContent = Get-Content ".\appsettings.Development.json" -Raw
		$appSettingsContent = $appSettingsContent -replace "localhost", $DbServer

		Out-File -InputObject $appSettingsContent -Encoding ascii -FilePath ".\appsettings.json"

		rm ".\appsettings.Development.json"

		cd ..
	
	docker build -t schoolimage .

	docker run -d -p 58412:80 --name schoolcontainer schoolimage

	rm .\publishFolder
	rm .\bin
	rm .\obj

	cd ..
	cd ..
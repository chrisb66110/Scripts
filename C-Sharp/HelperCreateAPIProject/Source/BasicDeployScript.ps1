$DbServer = "host.docker.internal" #$args[0] #DB Sever

cd ApiFolderVar

	dotnet build -c release

	dotnet publish -c Release -o publishFolder

	cd .\publishFolder

		$appSettingsContent = Get-Content ".\appsettings.Development.json" -Raw
		$appSettingsContent = $appSettingsContent -replace "localhost", $DbServer

		Out-File -InputObject $appSettingsContent -Encoding ascii -FilePath ".\appsettings.json"

		rm ".\appsettings.Development.json"

		cd ..
	
	docker build -t ProjectNameLowerVarimage .

	docker run -d -p PortVar:80 --name ProjectNameLowerVarcontainer ProjectNameLowerVarimage

	rm .\publishFolder
	rm .\bin
	rm .\obj

	cd ..
	cd ..
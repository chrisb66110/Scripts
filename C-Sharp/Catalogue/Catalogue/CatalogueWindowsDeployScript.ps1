#Use this script to deploy the MS
#
#To Use this script:
#       ./CatalogueWindowsDeployScript.ps1 IpServerDataBase UserDb PasswordDb AuthAuthority AuthAudience FrontEndOrigin
#Use host.docker.internal in appsettings to conect a localhost

cd .\Source\Catalogue.Api

	dotnet publish -c Release -o publishFolder

	$tempKeyContent = Get-Content ".\tempkey.rsa" -Raw

	cd .\publishFolder

		Out-File -InputObject $tempKeyContent -Encoding ascii -FilePath ".\tempkey.rsa"

		$appSettingsContent = Get-Content ".\appsettings.json" -Raw

		Out-File -InputObject $appSettingsContent -Encoding ascii -FilePath ".\appsettings.json"

		rm ".\appsettings.Development.json"

		cd ..
	
	#Remove old image and container in docker

    docker stop catalogue

    docker container rm catalogue

    docker image rm catalogue

    #Create image and start container in docker

    docker build -t catalogue .

	docker run -d -p 20759:80 --name catalogue catalogue

	rm -r .\publishFolder
	rm -r .\bin
	rm -r .\obj

	cd ..
	cd ..

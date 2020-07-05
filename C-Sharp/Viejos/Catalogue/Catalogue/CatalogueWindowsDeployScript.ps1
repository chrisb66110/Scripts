#Use this script to deploy the MS
#
#To Use this script:
#       ./CatalogueWindowsDeployScript.ps1 IpServerDataBase UserDb PasswordDb
#Use host.docker.internal lo conect a localhost

$DbServer=$args[0]
$DbUser=$args[1]
$DbPassword=$args[2]

cd .\Source\Catalogue.Api

	dotnet publish -c Release -o publishFolder

	$tempKeyContent = Get-Content ".\tempkey.rsa" -Raw

	cd .\publishFolder

		Out-File -InputObject $tempKeyContent -Encoding ascii -FilePath ".\tempkey.rsa"

		$appSettingsContent = Get-Content ".\appsettings.Development.json" -Raw

		$appSettingsContent = $appSettingsContent -replace "localhost1", $DbServer
		$appSettingsContent = $appSettingsContent -replace "1234", $DbPassword
		$appSettingsContent = $appSettingsContent -replace "postgres", $DbUser

		Out-File -InputObject $appSettingsContent -Encoding ascii -FilePath ".\appsettings.json"

		rm ".\appsettings.Development.json"

		cd ..
	
	#Remove old image and container in docker

    docker stop catalogue

    docker container rm catalogue

    docker image rm catalogue

    #Create image and start container in docker

    docker build -t catalogue .

	docker run -d -p 8214:80 --name catalogue catalogue

	rm -r .\publishFolder
	rm -r .\bin
	rm -r .\obj

	cd ..
	cd ..

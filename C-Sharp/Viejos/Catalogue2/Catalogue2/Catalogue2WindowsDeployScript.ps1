#Use this script to deploy the MS
#
#To Use this script:
#       ./Catalogue2WindowsDeployScript.ps1 IpServerDataBase UserDb PasswordDb AuthAuthority AuthAudience FrontEndOrigin
#Use host.docker.internal in appsettings lo conect a localhost

cd .\Source\Catalogue2.Api

	dotnet publish -c Release -o publishFolder

	$tempKeyContent = Get-Content ".\tempkey.rsa" -Raw

	cd .\publishFolder

		Out-File -InputObject $tempKeyContent -Encoding ascii -FilePath ".\tempkey.rsa"

		$appSettingsContent = Get-Content ".\appsettings.json" -Raw

		Out-File -InputObject $appSettingsContent -Encoding ascii -FilePath ".\appsettings.json"

		rm ".\appsettings.Development.json"

		cd ..
	
	#Remove old image and container in docker

    docker stop catalogue2

    docker container rm catalogue2

    docker image rm catalogue2

    #Create image and start container in docker

    docker build -t catalogue2 .

	docker run -d -p 29473:80 --name catalogue2 catalogue2

	rm -r .\publishFolder
	rm -r .\bin
	rm -r .\obj

	cd ..
	cd ..

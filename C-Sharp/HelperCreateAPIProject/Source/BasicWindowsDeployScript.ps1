#Use this script to deploy the MS
#
#To Use this script:
#       ./FileNameDeployWindowsVar IpServerDataBase UserDb PasswordDb AuthAuthority AuthAudience FrontEndOrigin
#Use host.docker.internal in appsettings to conect a localhost

cd ApiFolderVar

	dotnet publish -c Release -o publishFolder

	$tempKeyContent = Get-Content ".\tempkey.rsa" -Raw

	cd .\publishFolder

		Out-File -InputObject $tempKeyContent -Encoding ascii -FilePath ".\tempkey.rsa"

		$appSettingsContent = Get-Content ".\appsettings.json" -Raw

		Out-File -InputObject $appSettingsContent -Encoding ascii -FilePath ".\appsettings.json"

		rm ".\appsettings.Development.json"

		cd ..
	
	#Remove old image and container in docker

    docker stop ProjectNameLowerVar

    docker container rm ProjectNameLowerVar

    docker image rm ProjectNameLowerVar

    #Create image and start container in docker

    docker build -t ProjectNameLowerVar .

	docker run -d -p PortVar:80 --name ProjectNameLowerVar ProjectNameLowerVar

	rm -r .\publishFolder
	rm -r .\bin
	rm -r .\obj

	cd ..
	cd ..
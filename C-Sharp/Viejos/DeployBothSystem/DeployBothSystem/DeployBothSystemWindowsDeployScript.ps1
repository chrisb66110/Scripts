#Use this script to deploy the MS
#
#To Use this script:
#       ./DeployBothSystemWindowsDeployScript.ps1 IpServerDataBase UserDb PasswordDb
#Use host.docker.internal lo conect a localhost

$DbServer=$args[0]
$DbUser=$args[1]
$DbPassword=$args[2]

cd .\Source\DeployBothSystem.Api

	dotnet publish -c Release -o publishFolder

	cd .\publishFolder

		$appSettingsContent = Get-Content ".\appsettings.Development.json" -Raw

		$appSettingsContent = $appSettingsContent -replace "localhost", $DbServer
		$appSettingsContent = $appSettingsContent -replace "1234", $DbPassword
		$appSettingsContent = $appSettingsContent -replace "postgres", $DbUser

		Out-File -InputObject $appSettingsContent -Encoding ascii -FilePath ".\appsettings.json"

		rm ".\appsettings.Development.json"

		cd ..
	
	#Remove old image and container in docker

    docker stop deploybothsystem

    docker container rm deploybothsystem

    docker image rm deploybothsystem

    #Create image and start container in docker

    docker build -t deploybothsystem .

	docker run -d -p 49355:80 --name deploybothsystem deploybothsystem

	rm -r .\publishFolder
	rm -r .\bin
	rm -r .\obj

	cd ..
	cd ..

#Use this script to deploy the MS
#
#To Use this script:
#       chmod +x ./DeployBothSystemLinuxDeployScript.sh
#       ./DeployBothSystemLinuxDeployScript.sh IpServerDataBase UserDb PasswordDb

DbServer=$1
DbUser=$2
DbPassword=$3

cd Source/DeployBothSystem.Api//

    dotnet publish -c release -o publishFolder

    cd publishFolder

        value=$(cat ../appsettings.Development.json)

        value=${value/localhost/$DbServer}
        value=${value/1234/$DbPassword}
        value=${value/postgres/$DbUser}

        echo "$value" > appsettings.json

        rm appsettings.Development.json

        cd ..

    #Remove old image and container in docker

    sudo docker stop deploybothsystem

    sudo docker container rm deploybothsystem

    sudo docker image rm deploybothsystem

    #Create image and start container in docker

    sudo docker build -t deploybothsystem .

    sudo docker run -d -p 49355:80 --name deploybothsystem deploybothsystem

    rm -r publishFolder/
    rm -r bin/
    rm -r obj/

    cd ..
    cd ..

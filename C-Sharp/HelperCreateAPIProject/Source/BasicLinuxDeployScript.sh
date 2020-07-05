#Use this script to deploy the MS
#
#To Use this script:
#       chmod +x ./FileNameDeployLinuxVar
#       ./FileNameDeployLinuxVar

cd ProgramFolderVar/

    dotnet publish -c release -o publishFolder

    cd publishFolder

        tempkey=$(cat ../tempkey.rsa)
        echo "$tempkey" > tempkey.rsa

        value=$(cat ../appsettings.json)

        echo "$value" > appsettings.json

        rm appsettings.Development.json

        cd ..

    #Remove old image and container in docker

    sudo docker stop ProjectNameLowerVar

    sudo docker container rm ProjectNameLowerVar

    sudo docker image rm ProjectNameLowerVar

    #Create image and start container in docker

    sudo docker build -t ProjectNameLowerVar .

    sudo docker run -d -p PortDeployVar:80 --name ProjectNameLowerVar ProjectNameLowerVar

    rm -r publishFolder/
    rm -r bin/
    rm -r obj/

    cd ..
    cd ..
#Use this script to deploy the MS
#
#To Use this script:
#       chmod +x ./Catalogue2LinuxDeployScript.sh
#       ./Catalogue2LinuxDeployScript.sh

cd Source/Catalogue2.Api//

    dotnet publish -c release -o publishFolder

    cd publishFolder

        tempkey=$(cat ../tempkey.rsa)
        echo "$tempkey" > tempkey.rsa

        value=$(cat ../appsettings.json)

        echo "$value" > appsettings.json

        rm appsettings.Development.json

        cd ..

    #Remove old image and container in docker

    sudo docker stop catalogue2

    sudo docker container rm catalogue2

    sudo docker image rm catalogue2

    #Create image and start container in docker

    sudo docker build -t catalogue2 .

    sudo docker run -d -p 29473:80 --name catalogue2 catalogue2

    rm -r publishFolder/
    rm -r bin/
    rm -r obj/

    cd ..
    cd ..

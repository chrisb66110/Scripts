#Use this script to deploy the MS
#
#To Use this script:
#       chmod +x ./CatalogueLinuxDeployScript.sh
#       ./CatalogueLinuxDeployScript.sh

cd Source/Catalogue.Api//

    dotnet publish -c release -o publishFolder

    cd publishFolder

        tempkey=$(cat ../tempkey.rsa)
        echo "$tempkey" > tempkey.rsa

        value=$(cat ../appsettings.json)

        echo "$value" > appsettings.json

        rm appsettings.Development.json

        cd ..

    #Remove old image and container in docker

    sudo docker stop catalogue

    sudo docker container rm catalogue

    sudo docker image rm catalogue

    #Create image and start container in docker

    sudo docker build -t catalogue .

    sudo docker run -d -p 20759:80 --name catalogue catalogue

    rm -r publishFolder/
    rm -r bin/
    rm -r obj/

    cd ..
    cd ..

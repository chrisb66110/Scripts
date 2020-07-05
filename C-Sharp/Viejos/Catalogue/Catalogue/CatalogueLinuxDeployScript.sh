#Use this script to deploy the MS
#
#To Use this script:
#       chmod +x ./CatalogueLinuxDeployScript.sh
#       ./CatalogueLinuxDeployScript.sh IpServerDataBase UserDb PasswordDb

DbServer=$1
DbUser=$2
DbPassword=$3

cd Source/Catalogue.Api//

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

    sudo docker stop catalogue

    sudo docker container rm catalogue

    sudo docker image rm catalogue

    #Create image and start container in docker

    sudo docker build -t catalogue .

    sudo docker run -d -p 8214:80 --name catalogue catalogue

    rm -r publishFolder/
    rm -r bin/
    rm -r obj/

    cd ..
    cd ..

##########################################################ProjectNames##########################################################

$projectName=$args[0]

$controllers = $args[1]

echo $controllers

$test="TEST"

$common=$projectName + ".COMMON"
$commonTest=$projectName + ".COMMON." + $test

$dal=$projectName + ".DAL"
$dalTest=$projectName + ".DAL." + $test

$bll=$projectName + ".BLL"
$bllTest=$projectName + ".BLL." + $test

$api=$projectName + ".API"
$apiTest=$projectName + ".API." + $test

$datatesthelper = $projectName + ".DATATESTHELPER"

$dotnetVersion = "netcoreapp3.1"

$pathScript = Convert-Path .\

$pathHelperCreateAPIProject = $pathScript+"\HelperCreateAPIProject"

##########################################################Functions##########################################################
function ConstantsContent([string] $nameSpace, [string] $nameClass) {
	$result = Get-Content $pathHelperCreateAPIProject"\COMMON\BasicConstants.cs"
	$result = $result -replace "NameSpaceVar", $nameSpace
	$result = $result -replace "NameClassVar", $nameClass
	return $result
}

function SettingsContent([string] $nameSpace, [string] $nameClass, [string] $dataBaseVar) {
	$result = Get-Content $pathHelperCreateAPIProject"\COMMON\BasicSettings.cs"
	$result = $result -replace "NameSpaceVar", $nameSpace
	$result = $result -replace "NameClassVar", $nameClass
	$result = $result -replace "DataBaseVar", $dataBaseVar
	return $result
}

function ModelDtoContent([string] $nameSpace, [string] $nameClass) {
	$result = Get-Content $pathHelperCreateAPIProject"\COMMON\BasicModelDto.cs"
	$result = $result -replace "NameSpaceVar", $nameSpace
	$result = $result -replace "NameClassVar", $nameClass
	return $result
}

function ModelContent([string] $nameSpace, [string] $nameClass) {
	$result = Get-Content $pathHelperCreateAPIProject"\DAL\BasicModel.cs"
	$result = $result -replace "NameSpaceVar", $nameSpace
	$result = $result -replace "NameClassVar", $nameClass
	return $result
}

function ContextContent([string] $nameSpace, [string] $nameClass) {
	$result = Get-Content $pathHelperCreateAPIProject"\DAL\BasicContext.cs"
	$result = $result -replace "NameSpaceVar", $nameSpace
	$result = $result -replace "NameClassVar", $nameClass
	return $result
}

function RepositoryContent([string] $modelsDtosNSpaceVar, [string] $contextsNSpaceVar, [string] $nameSpace, [string] $nameClass, [string] $nameInterfaceVar, [string] $nameContextVar, [string] $nameModelDtoVar) {
	$result = Get-Content $pathHelperCreateAPIProject"\DAL\BasicRepository.cs"
	$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
	$result = $result -replace "ContextsNSpaceVar", $contextsNSpaceVar
	$result = $result -replace "NameSpaceVar", $nameSpace
	$result = $result -replace "NameClassVar", $nameClass
	$result = $result -replace "NameInterfaceVar", $nameInterfaceVar
	$result = $result -replace "NameContextVar", $nameContextVar
	$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
	return $result
}

function IRepositoryContent([string] $modelsDtosNSpaceVar, [string] $nameSpace, [string] $nameInterfaceVar, [string] $nameModelDtoVar) {
	$result = Get-Content $pathHelperCreateAPIProject"\DAL\IBasicRepository.cs"
	$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
	$result = $result -replace "NameSpaceVar", $nameSpace
	$result = $result -replace "NameInterfaceVar", $nameInterfaceVar
	$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
	return $result
}

function BLLContent([string] $modelsDtosNSpaceVar, [string] $repositoriesNSpaceVar, [string] $nameSpace, [string] $nameClass, [string] $nameInterfaceVar, [string] $interfaceRepository, [string] $namePropertyRepo, [string] $nameModelDtoVar) {
	$result = Get-Content $pathHelperCreateAPIProject"\BLL\BasicBLL.cs"
	$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
	$result = $result -replace "RepositoriesNSpaceVar", $repositoriesNSpaceVar
	$result = $result -replace "NameSpaceVar", $nameSpace
	$result = $result -replace "NameClassVar", $nameClass
	$result = $result -replace "NameInterfaceVar", $nameInterfaceVar
	$result = $result -replace "InterfaceRepository", $interfaceRepository
	$result = $result -replace "nameRepostory", $namePropertyRepo
	$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
	return $result
}

function IBLLContent([string] $modelsDtosNSpaceVar, [string] $nameSpaceVar, [string] $nameClassVar, [string] $nameModelDtoVar) {
	$result = Get-Content $pathHelperCreateAPIProject"\BLL\IBasicBLL.cs"
	$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
	$result = $result -replace "NameSpaceVar", $nameSpaceVar
	$result = $result -replace "NameClassVar", $nameClassVar
	$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
	return $result
}

function LaunchSettingsContent([string] $projectNameLaunch, [string] $applicationUrl){
	$result = Get-Content $pathHelperCreateAPIProject"\API\BasicLauchSettings.json"
	$result = $result -replace "ProjectNameLaunchVar", $projectNameLaunch
	$result = $result -replace "ApplicationUrlLineVar", $applicationUrl
	return $result
}

function AppSettingsDevelopmentContent([string] $database){
	$result = Get-Content $pathHelperCreateAPIProject"\API\BasicAppSettings.development.json"
	$result = $result -replace "DataBaseVar", $database
	return $result
}

function ControllerContent([string] $BLLsNSpaceVar, [string] $ModelsDtosNSpaceVar, [string] $NameSpaceVar, [string] $NameClassVar, [string] $InterfaceBLLVar, [string] $NameModelDtoVar){
	$result = Get-Content $pathHelperCreateAPIProject"\API\BasicController.cs"
	$result = $result -replace "BLLsNSpaceVar", $BLLsNSpaceVar
	$result = $result -replace "ModelsDtosNSpaceVar", $ModelsDtosNSpaceVar
	$result = $result -replace "NameSpaceVar", $NameSpaceVar
	$result = $result -replace "NameClassVar", $NameClassVar
	$result = $result -replace "InterfaceBLLVar", $InterfaceBLLVar
	$result = $result -replace "NameModelDtoVar", $NameModelDtoVar
	return $result
}

function StartupContent([string] $NSpaceBLLsVar, [string] $NSpaceSettingsVar, [string] $NSpaceContextsVar, [string] $NSpaceRepositoriesVar, [string] $NameSpaceVar, [string] $NameClassSettingsVar,[string] $NameClassBLLVar,[string] $DataBaseVar,[string] $NameClassContextVar,[string] $NameClassRepositoryVar){
	$result = Get-Content $pathHelperCreateAPIProject"\API\BasicStartup.cs"
	$result = $result -replace "NSpaceBLLsVar", $NSpaceBLLsVar
	$result = $result -replace "NSpaceSettingsVar", $NSpaceSettingsVar
	$result = $result -replace "NSpaceContextsVar", $NSpaceContextsVar
	$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
	$result = $result -replace "NameSpaceVar", $NameSpaceVar
	$result = $result -replace "NameClassSettingsVar", $NameClassSettingsVar
	$result = $result -replace "NameClassBLLVar", $NameClassBLLVar
	$result = $result -replace "DataBaseVar", $DataBaseVar
	$result = $result -replace "NameClassContextVar", $NameClassContextVar
	$result = $result -replace "NameClassRepositoryVar", $NameClassRepositoryVar
	return $result
}

function ProgramContent([string] $NameSpaceVar){
	$result = Get-Content $pathHelperCreateAPIProject"\API\BasicProgram.cs"
	$result = $result -replace "NameSpaceVar", $NameSpaceVar
	return $result
}










mkdir .\$projectName
cd .\$projectName
	dotnet new gitignore
	
	mkdir .\$projectName
	cd .\$projectName
		mkdir .\Source
		cd .\Source
			mkdir .\$common
			cd .\$common
				dotnet new classlib -f $dotnetVersion
				rm Class1.cs
				$folderConstants = "Constants"
				mkdir .\$folderConstants
				cd .\$folderConstants
					$namespaceConstants = $common+"."+$folderConstants
					$nameclassConstants = $folderConstants
					$contentConstants = ConstantsContent $namespaceConstants $nameclassConstants
					$nameFileConstants = $nameclassConstants+".cs"
					echo $contentConstants > $nameFileConstants
				cd..
				$folderSettings = "Settings"
				mkdir .\$folderSettings
				cd .\$folderSettings
					$namespaceSettings = $common+"."+$folderSettings
					$nameclassSettings = $projectName+$folderSettings
					$settingsContent = SettingsContent $namespaceSettings $nameclassSettings $ProjectName
					$nameFileSettings = $nameclassSettings+".cs"
					echo $settingsContent > $nameFileSettings
				cd ..
				$folderDtos = "Dtos"
				mkdir .\$folderDtos
				cd .\$folderDtos
					$folderModelsDtos = "ModelsDtos"
					mkdir .\$folderModelsDtos
					cd .\$folderModelsDtos
						$namespaceModelsDto = $common+"."+$folderDtos+"."+$folderModelsDtos
						$nameclassModelsDto = $projectName+"Dto"
						$contentModelsDto = ModelDtoContent $namespaceModelsDto $nameclassModelsDto
						$nameFileModelsDto = $nameclassModelsDto+".cs"
						echo $contentModelsDto > $nameFileModelsDto
					cd ..
				cd..
			cd ..
			mkdir .\$dal
			cd .\$dal
				dotnet new classlib -f $dotnetVersion
				dotnet add package Microsoft.EntityFrameworkCore
				dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
				rm Class1.cs
				dotnet add reference ..\$common\$common.csproj
				$folderModels = "Models"
				mkdir .\$folderModels
				cd .\$folderModels
					$namespaceModels = $dal+"."+$folderModels
					$nameclassModels = $projectName
					$contentModels = ModelContent $namespaceModels $nameclassModels
					$nameFileModels = $nameclassModels+".cs"
					echo $contentModels > $nameFileModels
				cd..
				$folderContext = "Contexts"
				mkdir .\$folderContext
				cd .\$folderContext
					$namespaceContexts = $dal+"."+$folderContext
					$nameclassContexts = $projectName+"Context"
					$contentContexts = ContextContent $namespaceContexts $nameclassContexts
					$nameFileContexts = $nameclassContexts+".cs"
					echo $contentContexts > $nameFileContexts
				cd..
				$folderRepositories = "Repositories"
				mkdir .\$folderRepositories
				cd .\$folderRepositories
					$namespaceRepositories = $dal+"."+$folderRepositories
					$nameclassRepositories = $projectName+"Repository"
					
					$nameinterfaceRepositories = "I"+$nameclassRepositories
					$contentRepository = RepositoryContent $namespaceModelsDto $namespaceContexts $namespaceRepositories $nameclassRepositories $nameinterfaceRepositories $nameclassContexts $nameclassModelsDto
					$nameFileClassRepositories = $nameclassRepositories+".cs"
					echo $contentRepository > $nameFileClassRepositories
					$contentIRepository = IRepositoryContent $namespaceModelsDto $namespaceRepositories $nameinterfaceRepositories $nameclassModelsDto
					$nameFileInterfaceRepositories = $nameinterfaceRepositories+".cs"
					echo $contentIRepository > $nameFileInterfaceRepositories
				cd..
			cd ..
			mkdir .\$bll
			cd .\$bll
				dotnet new classlib -f $dotnetVersion
				rm Class1.cs
				dotnet add reference ..\$dal\$dal.csproj
				dotnet add reference ..\$common\$common.csproj
				$folderBLLs = "BLLs"
				mkdir .\$folderBLLs
				cd .\$folderBLLs
					$namespaceBLL = $bll+"."+$folderBLLs
					$nameclassBLL = $projectName+"BLL"
					$nameinterfaceBLL = "I"+$projectName+"BLL"
					$nameRepositoryProperty = $nameclassRepositories.subString(0,1)+$nameclassRepositories.subString(1,1).ToLower()+$nameclassRepositories.subString(2,$nameclassRepositories.Length-2)
					$contentBLL = BLLContent $namespaceModelsDto $namespaceRepositories $namespaceBLL $nameclassBLL $nameinterfaceBLL $nameinterfaceRepositories $nameRepositoryProperty $nameclassModelsDto
					$nameFileClassBLL = $nameclassBLL+".cs"
					echo $contentBLL > $nameFileClassBLL
					$contentIBLL = IBLLContent $namespaceModelsDto $namespaceBLL $nameinterfaceBLL $nameclassModelsDto
					$nameFileInterfaceBLL = $nameinterfaceBLL+".cs"
					echo $contentIBLL > $nameFileInterfaceBLL
				cd..
			cd ..
			mkdir .\$api
			cd .\$api
				dotnet new webapi -f $dotnetVersion
				rm WeatherForecast.cs
				$folderController = "Controllers"
				cd .\$folderController
					rm .\WeatherForecastController.cs
					$namespaceController = $api+"."+$folderController
					$nameclassController = $projectName+"Controller"
					$contentController = ControllerContent $namespaceBLL $namespaceModelsDto $namespaceController $nameclassController $nameinterfaceBLL $nameclassModelsDto
					$nameFileClassController = $nameclassController+".cs"
					echo $contentController > $nameFileClassController
				cd ..
				dotnet add reference ..\$bll\$bll.csproj
				dotnet add reference ..\$common\$common.csproj
				dotnet add package Autofac
				dotnet add package Autofac.Extensions.DependencyInjection
				cd .\Properties
					$portProject = Get-Content .\launchSettings.json | Select-String -Pattern "`"applicationUrl`": `"http://localhost:[0-9]+`""
					$launchsettingscontent = LaunchSettingsContent $api $portProject
					rm launchSettings.json
					echo $launchsettingscontent > launchSettings.json
				cd ..
				$appsettingsdevelopmentcontent =  AppSettingsDevelopmentContent $ProjectName
				rm appsettings.Development.json
				echo $appsettingsdevelopmentcontent > appsettings.Development.json
				$startUpContent = StartupContent $namespaceBLL $namespaceSettings $nameSpaceContexts $namespaceRepositories $api $nameclassSettings $nameClassBLL $projectName $nameclassContexts $nameclassRepositories
				rm Startup.cs
				echo $startUpContent > Startup.cs
				$programContent = ProgramContent $api
				rm Program.cs
				echo $programContent > Program.cs
			cd ..
		cd ..

		mkdir .\Test
		cd  .\Test
			mkdir .\$datatesthelper
			cd .\$datatesthelper
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
			cd ..
			mkdir .\$apiTest
			cd .\$apiTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$api\$api.csproj
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			mkdir .\$bllTest
			cd .\$bllTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$bll\$bll.csproj
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			mkdir .\$commonTest
			cd .\$commonTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			mkdir .\$dalTest
			cd .\$dalTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$dal\$dal.csproj
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
		cd ..

	dotnet new sln --name $projectName
	dotnet sln add ".\Source\$api\$api.csproj"
	dotnet sln add ".\Source\$bll\$bll.csproj"
	dotnet sln add ".\Source\$common\$common.csproj"
	dotnet sln add ".\Source\$dal\$dal.csproj"

	dotnet sln add ".\Test\$apiTest\$apiTest.csproj"
	dotnet sln add ".\Test\$bllTest\$bllTest.csproj"
	dotnet sln add ".\Test\$commonTest\$commonTest.csproj"
	dotnet sln add ".\Test\$dalTest\$dalTest.csproj"
	dotnet sln add ".\Test\$datatesthelper\$datatesthelper.csproj"

	##Add migrations file

	cd ..

	mkdir .\$projectName.postman

cd ..
##########################################################ProjectNames##########################################################

$projectName=$args[0]

$controllers = $args[1]

echo $controllers

$test="TEST"

$dotnetVersion = "netcoreapp3.1"

##########################################################Paths And NameSpaces##########################################################
$pathScript = Convert-Path .\
$pathHelperCreateAPIProject = $pathScript+"\HelperCreateAPIProject"

$pathCommonFiles = $pathScript+"\CommonFiles"

$common=$projectName + ".COMMON"
	$folderConstants = "Constants"
		$namespaceConstants = $common+"."+$folderConstants
	$folderSettings = "Settings"
		$namespaceSettings = $common+"."+$folderSettings
	$folderDtos = "Dtos"
		$folderModelsDtos = "ModelsDtos"
			$namespaceModelsDto = $common+"."+$folderDtos+"."+$folderModelsDtos

$commonTest=$projectName + ".COMMON." + $test

$dal=$projectName + ".DAL"
	$folderModels = "Models"
		$namespaceModels = $dal+"."+$folderModels
	$folderContext = "Contexts"
		$namespaceContexts = $dal+"."+$folderContext
	$folderRepositories = "Repositories"
		$namespaceRepositories = $dal+"."+$folderRepositories
	$folderMappingsDal = "Mappings"
		$namespaceMappingsDal = $dal+"."+$folderMappingsDal

$dalTest=$projectName + ".DAL." + $test

$bll=$projectName + ".BLL"
	$folderBLLs = "BLLs"
		$namespaceBLL = $bll+"."+$folderBLLs

$bllTest=$projectName + ".BLL." + $test

$api=$projectName + ".API"
	$folderController = "Controllers"
		$namespaceController = $api+"."+$folderController
	$folderMappingsApi = "Mappings"
		$namespaceMappingsApi = $api+"."+$folderMappingsApi
	$folderRequestsApi = "Requests"
		$namespaceRequestsApi = $api+"."+$folderRequestsApi
	$folderResponseApi = "Responses"
		$namespaceResponseApi = $api+"."+$folderResponseApi

$apiTest=$projectName + ".API." + $test

$datatesthelper = $projectName + ".DATATESTHELPER"

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

	function RepositoryContent([string] $NSpaceModelsDtosVar,
							   [string] $NSpaceContextsVar,
							   [string] $NSpaceModelsVar,
							   [string] $NameSpaceVar,
							   [string] $NameClassVar,
							   [string] $NameInterfaceVar,
							   [string] $NameContextVar,
							   [string] $NameModelDtoVar,
							   [string] $NameModelVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\DAL\BasicRepository.cs"
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceContextsVar", $NSpaceContextsVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		$result = $result -replace "NameInterfaceVar", $NameInterfaceVar
		$result = $result -replace "NameContextVar", $NameContextVar
		$result = $result -replace "NameModelDtoVar", $NameModelDtoVar
		$result = $result -replace "NameModelVar", $NameModelVar
		$nModelVarVar = $NameModelVar.subString(0,1).ToLower()+$NameModelVar.subString(1,$NameModelVar.Length-1)
		Write-Host "VAR nModelVarVar: "$nModelVarVar -ForegroundColor Red
		$result = $result -replace "nModelVarVar", $nModelVarVar
		return $result
	}

	function IRepositoryContent([string] $modelsDtosNSpaceVar, [string] $nameSpace, [string] $nameInterfaceVar, [string] $nameModelDtoVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\DAL\IBasicRepository.cs"
		$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameInterfaceVar", $nameInterfaceVar
		$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
		$param = $nameModelDtoVar.subString(0,1).ToLower()+$nameModelDtoVar.subString(1,$nameModelDtoVar.Length-1)
		Write-Host "VAR param: "$param -ForegroundColor Red
		$result = $result -replace "nameModelDtoParamVar", $param
		return $result
	}

	function BLLContent([string] $modelsDtosNSpaceVar, [string] $repositoriesNSpaceVar, [string] $nameSpace, [string] $nameClass, [string] $nameInterfaceVar, [string] $interfaceRepository, [string] $nameModelDtoVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\BLL\BasicBLL.cs"
		$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
		$result = $result -replace "RepositoriesNSpaceVar", $repositoriesNSpaceVar
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		$result = $result -replace "NameInterfaceVar", $nameInterfaceVar
		$result = $result -replace "InterfaceRepository", $interfaceRepository
		$namePropertyRepo = $interfaceRepository.subString(1,1).ToLower()+$interfaceRepository.subString(2,$interfaceRepository.Length-2)
		Write-Host "VAR namePropertyRepo: "$namePropertyRepo -ForegroundColor Red
		$result = $result -replace "nameRepostory", $namePropertyRepo
		$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
		$param = $nameModelDtoVar.subString(0,1).ToLower()+$nameModelDtoVar.subString(1,$nameModelDtoVar.Length-1)
		Write-Host "VAR param: "$param -ForegroundColor Red
		$result = $result -replace "nameModelDtoParamVar", $param
		return $result
	}

	function IBLLContent([string] $modelsDtosNSpaceVar, [string] $nameSpaceVar, [string] $nameClassVar, [string] $nameModelDtoVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\BLL\IBasicBLL.cs"
		$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
		$result = $result -replace "NameSpaceVar", $nameSpaceVar
		$result = $result -replace "NameClassVar", $nameClassVar
		$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
		$param = $nameModelDtoVar.subString(0,1).ToLower()+$nameModelDtoVar.subString(1,$nameModelDtoVar.Length-1)
		$result = $result -replace "nameModelDtoParamVar", $param
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

	function ControllerContent([string] $NSpaceRequestsVar, 
							   [string] $NSpaceResponsesVar, 
							   [string] $NSpaceBLLsVar, 
							   [string] $NSpaceConstantsVar, 
							   [string] $NSpaceModelsDtosVar, 
							   [string] $NameSpaceVar, 
							   [string] $NameClassVar, 
							   [string] $InterfaceBLLVar,
							   [string] $NameModelDtoVar,
							   [string] $NameResponseVar,
							   [string] $NameRequestVar){
		$result = Get-Content $pathHelperCreateAPIProject"\API\BasicController.cs"
		$result = $result -replace "NSpaceRequestsVar", $NSpaceRequestsVar
		$result = $result -replace "NSpaceResponsesVar", $NSpaceResponsesVar
		$result = $result -replace "NSpaceBLLsVar", $NSpaceBLLsVar
		$result = $result -replace "NSpaceConstantsVar", $NSpaceConstantsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		$result = $result -replace "InterfaceBLLVar", $InterfaceBLLVar
		$result = $result -replace "NameModelDtoVar", $NameModelDtoVar
		$result = $result -replace "NameResponseVar", $NameResponseVar
		$result = $result -replace "NameRequestVar", $NameRequestVar
		$ModelDtoPropertyVar = $NameModelDtoVar.subString(0,1).ToLower()+$nameModelDtoVar.subString(1,$nameModelDtoVar.Length-1)
		$result = $result -replace "ModelDtoPropertyVar", $ModelDtoPropertyVar
		$NameBllProperty = $InterfaceBLLVar.subString(1,1).ToLower()+$InterfaceBLLVar.subString(2,$InterfaceBLLVar.Length-2)
		$result = $result -replace "NameBllProperty", $NameBllProperty
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

	function ProfileDalContent([string] $NSpaceModelsDtosVar, [string] $NSpaceModelsVar, [string] $NameSpaceVar, [string] $NameClassVar, [string] $NameModelVar, [string] $NameModelDtoVar){
		$result = Get-Content $pathHelperCreateAPIProject"\DAL\BasicProfile.cs"
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		$result = $result -replace "NameModelVar", $NameModelVar
		$result = $result -replace "NameModelDtoVar", $NameModelDtoVar
		return $result
	}

	function ProfileApiContent([string] $NSpaceRequestsVar, [string] $NSpaceResponsesVar, [string] $NSpaceModelsDtosVar, [string] $NameSpaceVar, [string] $NameClassVar, [string] $NameRequestVar, [string] $NameModelDtoVar, [string] $NameResponseVar){
		$result = Get-Content $pathHelperCreateAPIProject"\API\BasicProfile.cs"
		$result = $result -replace "NSpaceRequestsVar", $NSpaceRequestsVar
		$result = $result -replace "NSpaceResponsesVar", $NSpaceResponsesVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		$result = $result -replace "NameRequestVar", $NameRequestVar
		$result = $result -replace "NameModelDtoVar", $NameModelDtoVar
		$result = $result -replace "NameResponseVar", $NameResponseVar
		return $result
	}

	function RequestContent ([string] $NameSpaceVar, [string] $NameClassVar){
		$result = Get-Content $pathHelperCreateAPIProject"\API\BasicRequest.cs"
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		return $result
	}

	function ResponseContent ([string] $NameSpaceVar, [string] $NameClassVar){
		$result = Get-Content $pathHelperCreateAPIProject"\API\BasicResponse.cs"
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		return $result
	}

	#This function is expected to run in the same folder where .sln is
	function ControllerBllDalCreatePath([string] $ModelName){
		Write-Host "`n`n"
		#DTO
			$nameclassModelsDto = $ModelName+"ModelDto"
			Write-Host "Creating "$nameclassModelsDto -ForegroundColor Magenta
			$contentModelsDto = ModelDtoContent $namespaceModelsDto $nameclassModelsDto
			$nameFileModelsDto = $nameclassModelsDto+".cs"
			echo $contentModelsDto > .\Source\$common\$folderDtos\$folderModelsDtos\$nameFileModelsDto
		#Model
			$nameclassModels = $ModelName+"Model"
			Write-Host "Creating "$nameclassModels -ForegroundColor Magenta
			$contentModels = ModelContent $namespaceModels $nameclassModels
			$nameFileModels = $nameclassModels+".cs"
			echo $contentModels > .\Source\$dal\$folderModels\$nameFileModels
		#ProfileDal
			$nameclassProfileDal = $ModelName+"Profile"
			Write-Host "Creating "$nameclassProfileDal -ForegroundColor Magenta
			$contentProfileDal = ProfileDalContent $namespaceModelsDto $namespaceModels $namespaceMappingsDal $nameclassProfileDal $nameclassModels $nameclassModelsDto
			$nameFileProfileDal = $nameclassProfileDal+".cs"
			echo $contentProfileDal > .\Source\$dal\$folderMappingsDal\$nameFileProfileDal
		#Repository
			$nameclassRepositories = $ModelName+"Repository"
			Write-Host "Creating "$nameclassRepositories -ForegroundColor Magenta
			$nameinterfaceRepositories = "I"+$nameclassRepositories
			$contentRepository = RepositoryContent $namespaceModelsDto $namespaceContexts $namespaceModels $namespaceRepositories $nameclassRepositories $nameinterfaceRepositories $nameclassContexts $nameclassModelsDto $nameclassModels
			$nameFileClassRepositories = $nameclassRepositories+".cs"
			echo $contentRepository > .\Source\$dal\$folderRepositories\$nameFileClassRepositories
			$contentIRepository = IRepositoryContent $namespaceModelsDto $namespaceRepositories $nameinterfaceRepositories $nameclassModelsDto
			$nameFileInterfaceRepositories = $nameinterfaceRepositories+".cs"
			echo $contentIRepository > .\Source\$dal\$folderRepositories\$nameFileInterfaceRepositories
		#BLL
			$nameclassBLL = $ModelName+"BLL"
			Write-Host "Creating "$nameclassBLL -ForegroundColor Magenta
			$nameinterfaceBLL = "I"+$ModelName+"BLL"
			$nameRepositoryProperty = $nameclassRepositories.subString(0,1)+$nameclassRepositories.subString(1,1).ToLower()+$nameclassRepositories.subString(2,$nameclassRepositories.Length-2)
			$contentBLL = BLLContent $namespaceModelsDto $namespaceRepositories $namespaceBLL $nameclassBLL $nameinterfaceBLL $nameinterfaceRepositories $nameclassModelsDto
			$nameFileClassBLL = $nameclassBLL+".cs"
			echo $contentBLL > .\Source\$bll\$folderBLLs\$nameFileClassBLL
			$contentIBLL = IBLLContent $namespaceModelsDto $namespaceBLL $nameinterfaceBLL $nameclassModelsDto
			$nameFileInterfaceBLL = $nameinterfaceBLL+".cs"
			echo $contentIBLL > .\Source\$bll\$folderBLLs\$nameFileInterfaceBLL
		#Request
			$nameclassRequest = $ModelName+"Request"
			Write-Host "Creating "$nameclassRequest -ForegroundColor Magenta
			$contentRequest = RequestContent $namespaceRequestsApi $nameclassRequest
			$nameFileRequest = $nameclassRequest+".cs"
			echo $contentRequest > .\Source\$api\$folderRequestsApi\$nameFileRequest
		#Response
			$nameclassResponse = $ModelName+"Response"
			Write-Host "Creating "$nameclassResponse -ForegroundColor Magenta
			$contentResponse = ResponseContent $namespaceResponseApi $nameclassResponse
			$nameFileResponse = $nameclassResponse+".cs"
			echo $contentResponse > .\Source\$api\$folderResponseApi\$nameFileResponse
		#Controller
			$nameclassController = $ModelName+"Controller"
			$contentController = ControllerContent $namespaceRequestsApi $namespaceResponseApi $namespaceBLL $namespaceConstants $namespaceModelsDto $namespaceController $nameclassController $nameinterfaceBLL $nameclassModelsDto $nameclassResponse $nameclassRequest
			$nameFileClassController = $nameclassController+".cs"
			echo $contentController > .\Source\$api\$folderController\$nameFileClassController
		#ProfileApi
			$nameclassProfileApi = $ModelName+"Profile"
			Write-Host "Creating "$nameclassProfileApi -ForegroundColor Magenta
			$contentProfileApi = ProfileApiContent $namespaceRequestsApi $namespaceResponseApi $namespaceModelsDto $namespaceMappingsApi $nameclassProfileApi $nameclassRequest $nameclassModelsDto $nameclassResponse
			$nameFileProfileApi = $nameclassProfileApi+".cs"
			echo $contentProfileApi > .\Source\$api\$folderMappingsApi\$nameFileProfileApi
	}

	#This function is expected to run in the same folder where .sln is
	function AddBaseFiles([string] $NameSpaceConstants, [string] $NameSpaceController){
		Write-Host "`n`n"
		#BaseConstants
			$nameclassBaseConstants = "BaseConstants"
			$fileBaseConstants = $nameclassBaseConstants+".cs"
			Write-Host "Creating "$nameclassBaseConstants -ForegroundColor Magenta
			$baseConstantsContent = Get-Content $pathCommonFiles\$fileBaseConstants
			$baseConstantsContent = $baseConstantsContent -replace "NameSpaceVar", $NameSpaceConstants
			echo $baseConstantsContent > .\Source\$common\$folderConstants\$fileBaseConstants
		#BaseController
			$nameclassBaseController = "BaseController"
			$fileBaseController = $nameclassBaseController+".cs"
			Write-Host "Creating "$nameclassBaseController -ForegroundColor Magenta
			$baseControllerContent = Get-Content $pathCommonFiles\$fileBaseController
			$baseControllerContent = $baseControllerContent -replace "NameSpaceVar", $NameSpaceController
			$baseControllerContent = $baseControllerContent -replace "NSpaceConstants", $NameSpaceConstants
			echo $baseControllerContent > .\Source\$api\$folderController\$fileBaseController
	}





#Generate project
mkdir .\$projectName
cd .\$projectName
	dotnet new gitignore
	
	mkdir .\$projectName
	cd .\$projectName
		mkdir .\Source
		cd .\Source
			Write-Host "`n`n`n`n`n`nCreating "$common -ForegroundColor Green
			mkdir .\$common
			cd .\$common
				dotnet new classlib -f $dotnetVersion
				dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
				rm Class1.cs
				mkdir .\$folderConstants
				cd .\$folderConstants
					$nameclassConstants = $folderConstants
					Write-Host "Creating "$nameclassConstants -ForegroundColor Magenta
					$contentConstants = ConstantsContent $namespaceConstants $nameclassConstants
					$nameFileConstants = $nameclassConstants+".cs"
					echo $contentConstants > $nameFileConstants
				cd..
				mkdir .\$folderSettings
				cd .\$folderSettings
					$nameclassSettings = $projectName+$folderSettings
					Write-Host "Creating "$nameclassSettings -ForegroundColor Magenta
					$settingsContent = SettingsContent $namespaceSettings $nameclassSettings $ProjectName
					$nameFileSettings = $nameclassSettings+".cs"
					echo $settingsContent > $nameFileSettings
				cd ..
				mkdir .\$folderDtos
				cd .\$folderDtos
					mkdir .\$folderModelsDtos
				cd..
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$dal -ForegroundColor Green
			mkdir .\$dal
			cd .\$dal
				dotnet new classlib -f $dotnetVersion
				dotnet add package Microsoft.EntityFrameworkCore
				dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
				rm Class1.cs
				dotnet add reference ..\$common\$common.csproj
				mkdir .\$folderModels
				mkdir .\$folderContext
				cd .\$folderContext
					$nameclassContexts = $projectName+"Context"
					Write-Host "Creating "$nameclassContexts -ForegroundColor Magenta
					$contentContexts = ContextContent $namespaceContexts $nameclassContexts
					$nameFileContexts = $nameclassContexts+".cs"
					echo $contentContexts > $nameFileContexts
				cd..
				mkdir .\$folderRepositories
				mkdir .\$folderMappingsDal
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$bll -ForegroundColor Green
			mkdir .\$bll
			cd .\$bll
				dotnet new classlib -f $dotnetVersion
				rm Class1.cs
				dotnet add reference ..\$dal\$dal.csproj
				dotnet add reference ..\$common\$common.csproj
				mkdir .\$folderBLLs
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$api -ForegroundColor Green
			mkdir .\$api
			cd .\$api
				dotnet new webapi -f $dotnetVersion
				rm WeatherForecast.cs
				cd .\$folderController
					rm .\WeatherForecastController.cs
				cd ..
				dotnet add reference ..\$bll\$bll.csproj
				dotnet add reference ..\$common\$common.csproj
				dotnet add package Autofac
				dotnet add package Autofac.Extensions.DependencyInjection
				cd .\Properties
					Write-Host "Creating launchSettings" -ForegroundColor Magenta
					$portProject = Get-Content .\launchSettings.json | Select-String -Pattern "`"applicationUrl`": `"http://localhost:[0-9]+`""
					$launchsettingscontent = LaunchSettingsContent $api $portProject
					rm launchSettings.json
					echo $launchsettingscontent > launchSettings.json
				cd ..
				Write-Host "Creating appsettings.Development" -ForegroundColor Magenta
				$appsettingsdevelopmentcontent =  AppSettingsDevelopmentContent $ProjectName
				rm appsettings.Development.json
				echo $appsettingsdevelopmentcontent > appsettings.Development.json
				Write-Host "Creating Startup" -ForegroundColor Magenta
				$nameClassBLL = $projectName+"BLL"
				$nameclassRepositories = $projectName+"Repository"
				$startUpContent = StartupContent $namespaceBLL $namespaceSettings $nameSpaceContexts $namespaceRepositories $api $nameclassSettings $nameClassBLL $projectName $nameclassContexts $nameclassRepositories
				rm Startup.cs
				echo $startUpContent > Startup.cs
				Write-Host "Creating Program" -ForegroundColor Magenta
				$programContent = ProgramContent $api
				rm Program.cs
				echo $programContent > Program.cs
				mkdir .\$folderMappingsApi
				mkdir .\$folderRequestsApi
				mkdir .\$folderResponseApi
			cd ..
		cd ..

		#Create a ControllerBllDalCreatePath
		ControllerBllDalCreatePath($projectName)
		
		#Create a others ControllerBllDalCreatePath
		For ($i=0; $i -lt $controllers.Length; $i++) {
			ControllerBllDalCreatePath($controllers[$i])
		}

		#Create a BaseFiles
		AddBaseFiles $namespaceConstants $namespaceController

		#Unit Test
		mkdir .\Test
		cd  .\Test
			Write-Host "`n`n`n`n`n`nCreating "$datatesthelper -ForegroundColor Green
			mkdir .\$datatesthelper
			cd .\$datatesthelper
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$apiTest -ForegroundColor Green
			mkdir .\$apiTest
			cd .\$apiTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$api\$api.csproj
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$bllTest -ForegroundColor Green
			mkdir .\$bllTest
			cd .\$bllTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$bll\$bll.csproj
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$commonTest -ForegroundColor Green
			mkdir .\$commonTest
			cd .\$commonTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$dalTest -ForegroundColor Green
			mkdir .\$dalTest
			cd .\$dalTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$dal\$dal.csproj
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
		cd ..
	
	Write-Host "`n`n`n`n`n`nCreating "$projectName -ForegroundColor Cyan
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
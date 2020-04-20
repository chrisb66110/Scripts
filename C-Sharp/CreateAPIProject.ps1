##########################################################ProjectNames##########################################################

$projectName=$args[0]

$controllers = $args[1]

$nameSource = "Source"
	$nameCommon = "Common"
		$nameDto = "Dto"
		$nameConstant = "Constants"
		$nameSettings = "Settings"
	$nameDal = "Dal"
		$nameRepository = "Repository"
		$nameRepositories = "Repositories"
		$nameContext = "Context"
		$nameModel = "Model"
	$nameBll = "Bll"
		$nameMapping = "Mapping"
		$nameProfile = "Profile"
	$nameApi = "Api"
		$nameRequest = "Request"
		$nameResponse = "Response"
		$nameController = "Controller"
$nameTest = "Test"
	$nameTestHelper = "TestHelper"

$nameBaseConstants = "BaseConstants"
$nameBaseController = "BaseController"
$nameBaseRepository = "BaseRepository"

$namePostman = "postman"

$dotnetVersion = "netcoreapp3.1"

$nameAPIBase = "APIBase"
$versionAPIBase = "0.0.1"

$nameAPIBaseTest = "APIBaseTest"
$versionAPIBaseTest = "0.0.1"

##########################################################Paths And NameSpaces##########################################################
$pathScript = Convert-Path .\
$pathHelperCreateAPIProject = $pathScript+"\HelperCreateAPIProject"

$pathCommonFiles = $pathScript+"\CommonFiles"

$common=$projectName + "." + $nameCommon
	$folderConstants = $nameConstant
		$namespaceConstants = $common+"."+$folderConstants
	$folderSettings = $nameSettings
		$namespaceSettings = $common+"."+$folderSettings
	$folderDtos = $nameDto + "s"
		$folderModelsDtos = $nameModel + "s" + $nameDto + "s"
			$namespaceModelsDto = $common+"."+$folderDtos+"."+$folderModelsDtos

$commonTest=$projectName + "." + $nameCommon + "." + $nameTest

$dal=$projectName + "." + $nameDal
	$folderModels = $nameModel + "s"
		$namespaceModels = $dal+"."+$folderModels
	$folderContext = $nameContext + "s"
		$namespaceContexts = $dal+"."+$folderContext
	$folderRepositories = $nameRepositories
		$namespaceRepositories = $dal+"."+$folderRepositories
	$folderMappingsDal = $nameMapping + "s"
		$namespaceMappingsDal = $dal+"."+$folderMappingsDal

$dalTest=$projectName + "." + $nameDal + "." + $nameTest

$bll=$projectName + "." + $nameBll
	$folderBLLs = $nameBll + "s"
		$namespaceBLL = $bll+"."+$folderBLLs

$bllTest=$projectName + "." + $nameBll + "." + $nameTest

$api=$projectName + "." + $nameApi
	$folderController = $nameController + "s"
		$namespaceController = $api+"."+$folderController
	$folderMappingsApi = $nameMapping + "s"
		$namespaceMappingsApi = $api+"."+$folderMappingsApi
	$folderRequestsApi = $nameRequest + "s"
		$namespaceRequestsApi = $api+"."+$folderRequestsApi
	$folderResponseApi = $nameResponse + "s"
		$namespaceResponseApi = $api+"."+$folderResponseApi

$apiTest=$projectName + "." + $nameApi + "." + $nameTest

$datatesthelper = $projectName + "." + $nameTestHelper

$folderPostmanFiles = $projectName + "." + $namePostman

##########################################################Functions##########################################################
	function ConstantsContent([string] $nameSpace, 
							  [string] $nameClass) {
		$result = Get-Content $pathHelperCreateAPIProject"\COMMON\BasicConstants.cs"
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		return $result
	}

	function SettingsContent([string] $nameSpace, 
							 [string] $nameClass, 
							 [string] $dataBaseVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\COMMON\BasicSettings.cs"
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		$result = $result -replace "DataBaseVar", $dataBaseVar
		return $result
	}

	function ModelDtoContent([string] $nameSpace, 
							 [string] $nameClass) {
		$result = Get-Content $pathHelperCreateAPIProject"\COMMON\BasicModelDto.cs"
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		return $result
	}

	function ModelContent([string] $nameSpace, 
						  [string] $nameClass) {
		$result = Get-Content $pathHelperCreateAPIProject"\DAL\BasicModel.cs"
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		return $result
	}

	function TablesContext([string[]] $OtherTables){
		$BaseTable = "        public DbSet<NameModelVar> NameTableVar { get; set; }"
		$result = ""
		For ($i=0; $i -lt $OtherTables.Length; $i++) {
			$result = $result+$BaseTable
			$result = $result -replace "NameModelVar", $OtherTables[$i]
			$nameTable = $OtherTables[$i]+"s"
			$result = $result -replace "NameTableVar", $nameTable
			$result = $result+"`n"
		}
		return $result
	}

	function ContextContent([string] $NSpaceModelsVar, 
							[string] $nameSpace,
							[string] $nameClass,
							[string] $TablesPropertyVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\DAL\BasicContext.cs"
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		$result = $result -replace "TablesPropertyVar", $TablesPropertyVar
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
		$result = $result -replace "nModelVarVar", $nModelVarVar
		$nameModelDtoParamVar = $NameModelDtoVar.subString(0,1).ToLower()+$NameModelDtoVar.subString(1,$NameModelDtoVar.Length-1)
		$result = $result -replace "nameModelDtoParamVar", $nameModelDtoParamVar
		return $result
	}

	function IRepositoryContent([string] $modelsDtosNSpaceVar, 
								[string] $nameSpace, 
								[string] $nameInterfaceVar, 
								[string] $nameModelDtoVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\DAL\IBasicRepository.cs"
		$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameInterfaceVar", $nameInterfaceVar
		$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
		$param = $nameModelDtoVar.subString(0,1).ToLower()+$nameModelDtoVar.subString(1,$nameModelDtoVar.Length-1)
		$result = $result -replace "nameModelDtoParamVar", $param
		return $result
	}

	function BLLContent([string] $modelsDtosNSpaceVar, 
						[string] $repositoriesNSpaceVar, 
						[string] $nameSpace, 
						[string] $nameClass, 
						[string] $nameInterfaceVar, 
						[string] $interfaceRepository, 
						[string] $nameModelDtoVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\BLL\BasicBLL.cs"
		$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
		$result = $result -replace "RepositoriesNSpaceVar", $repositoriesNSpaceVar
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		$result = $result -replace "NameInterfaceVar", $nameInterfaceVar
		$result = $result -replace "InterfaceRepository", $interfaceRepository
		$namePropertyRepo = $interfaceRepository.subString(1,1).ToLower()+$interfaceRepository.subString(2,$interfaceRepository.Length-2)
		$result = $result -replace "nameRepostory", $namePropertyRepo
		$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
		$param = $nameModelDtoVar.subString(0,1).ToLower()+$nameModelDtoVar.subString(1,$nameModelDtoVar.Length-1)
		$result = $result -replace "nameModelDtoParamVar", $param
		return $result
	}

	function IBLLContent([string] $modelsDtosNSpaceVar, 
						 [string] $nameSpaceVar, 
						 [string] $nameClassVar, 
						 [string] $nameModelDtoVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\BLL\IBasicBLL.cs"
		$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
		$result = $result -replace "NameSpaceVar", $nameSpaceVar
		$result = $result -replace "NameClassVar", $nameClassVar
		$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
		$param = $nameModelDtoVar.subString(0,1).ToLower()+$nameModelDtoVar.subString(1,$nameModelDtoVar.Length-1)
		$result = $result -replace "nameModelDtoParamVar", $param
		return $result
	}

	function LaunchSettingsContent([string] $projectNameLaunch, 
								   [string] $applicationUrl){
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
		#$result = $result -replace "NSpaceConstantsVar", $NSpaceConstantsVar
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

	function StartupContent([string] $NSpaceBLLsVar, 
							[string] $NSpaceSettingsVar, 
							[string] $NSpaceContextsVar, 
							[string] $NSpaceRepositoriesVar, 
							[string] $NameSpaceVar, 
							[string] $NameClassSettingsVar,
							[string] $NameClassBLLVar,
							[string] $DataBaseVar,
							[string] $NameClassContextVar,
							[string] $NameClassRepositoryVar){
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

	function ProgramContent([string] $NSpaceContextsVar,
							[string] $NameSpaceVar,
							[string] $NameClassContextVar){
		$result = Get-Content $pathHelperCreateAPIProject"\API\BasicProgram.cs"
		$result = $result -replace "NSpaceContextsVar", $NSpaceContextsVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassContextVar", $NameClassContextVar
		return $result
	}

	function ProfileDalContent([string] $NSpaceModelsDtosVar, 
							   [string] $NSpaceModelsVar, 
							   [string] $NameSpaceVar, 
							   [string] $NameClassVar, 
							   [string] $NameModelVar, 
							   [string] $NameModelDtoVar){
		$result = Get-Content $pathHelperCreateAPIProject"\DAL\BasicProfile.cs"
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		$result = $result -replace "NameModelVar", $NameModelVar
		$result = $result -replace "NameModelDtoVar", $NameModelDtoVar
		return $result
	}

	function ProfileApiContent([string] $NSpaceRequestsVar, 
							   [string] $NSpaceResponsesVar, 
							   [string] $NSpaceModelsDtosVar, 
							   [string] $NameSpaceVar, 
							   [string] $NameClassVar, 
							   [string] $NameRequestVar, 
							   [string] $NameModelDtoVar, 
							   [string] $NameResponseVar){
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

	function RequestContent ([string] $NameSpaceVar, 
							 [string] $NameClassVar){
		$result = Get-Content $pathHelperCreateAPIProject"\API\BasicRequest.cs"
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		return $result
	}

	function ResponseContent ([string] $NameSpaceVar, 
							  [string] $NameClassVar){
		$result = Get-Content $pathHelperCreateAPIProject"\API\BasicResponse.cs"
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		return $result
	}

	#This function is expected to run in the same folder where .sln is
	function ControllerBllDalCreatePath([string] $ModelName){
		Write-Host "`n`n"
		#DTO
			$nameclassModelsDto = $ModelName+$nameDto
			Write-Host "Creating "$nameclassModelsDto -ForegroundColor Magenta
			$contentModelsDto = ModelDtoContent $namespaceModelsDto $nameclassModelsDto
			$nameFileModelsDto = $nameclassModelsDto+".cs"
			echo $contentModelsDto > .\$nameSource\$common\$folderDtos\$folderModelsDtos\$nameFileModelsDto
		#Model
			$nameclassModels = $ModelName
			Write-Host "Creating "$nameclassModels -ForegroundColor Magenta
			$contentModels = ModelContent $namespaceModels $nameclassModels
			$nameFileModels = $nameclassModels+".cs"
			echo $contentModels > .\$nameSource\$dal\$folderModels\$nameFileModels
		#ProfileDal
			$nameclassProfileDal = $ModelName+$nameProfile
			Write-Host "Creating "$nameclassProfileDal -ForegroundColor Magenta
			$contentProfileDal = ProfileDalContent $namespaceModelsDto $namespaceModels $namespaceMappingsDal $nameclassProfileDal $nameclassModels $nameclassModelsDto
			$nameFileProfileDal = $nameclassProfileDal+".cs"
			echo $contentProfileDal > .\$nameSource\$dal\$folderMappingsDal\$nameFileProfileDal
		#Repository
			$nameclassRepositories = $ModelName+$nameRepository
			Write-Host "Creating "$nameclassRepositories -ForegroundColor Magenta
			$nameinterfaceRepositories = "I"+$nameclassRepositories
			$contentRepository = RepositoryContent $namespaceModelsDto $namespaceContexts $namespaceModels $namespaceRepositories $nameclassRepositories $nameinterfaceRepositories $nameclassContexts $nameclassModelsDto $nameclassModels
			$nameFileClassRepositories = $nameclassRepositories+".cs"
			echo $contentRepository > .\$nameSource\$dal\$folderRepositories\$nameFileClassRepositories
			$contentIRepository = IRepositoryContent $namespaceModelsDto $namespaceRepositories $nameinterfaceRepositories $nameclassModelsDto
			$nameFileInterfaceRepositories = $nameinterfaceRepositories+".cs"
			echo $contentIRepository > .\$nameSource\$dal\$folderRepositories\$nameFileInterfaceRepositories
		#BLL
			$nameclassBLL = $ModelName+$nameBll
			Write-Host "Creating "$nameclassBLL -ForegroundColor Magenta
			$nameinterfaceBLL = "I"+$ModelName+$nameBll
			$nameRepositoryProperty = $nameclassRepositories.subString(0,1)+$nameclassRepositories.subString(1,1).ToLower()+$nameclassRepositories.subString(2,$nameclassRepositories.Length-2)
			$contentBLL = BLLContent $namespaceModelsDto $namespaceRepositories $namespaceBLL $nameclassBLL $nameinterfaceBLL $nameinterfaceRepositories $nameclassModelsDto
			$nameFileClassBLL = $nameclassBLL+".cs"
			echo $contentBLL > .\$nameSource\$bll\$folderBLLs\$nameFileClassBLL
			$contentIBLL = IBLLContent $namespaceModelsDto $namespaceBLL $nameinterfaceBLL $nameclassModelsDto
			$nameFileInterfaceBLL = $nameinterfaceBLL+".cs"
			echo $contentIBLL > .\$nameSource\$bll\$folderBLLs\$nameFileInterfaceBLL
		#Request
			$nameclassRequest = $ModelName+$nameRequest
			Write-Host "Creating "$nameclassRequest -ForegroundColor Magenta
			$contentRequest = RequestContent $namespaceRequestsApi $nameclassRequest
			$nameFileRequest = $nameclassRequest+".cs"
			echo $contentRequest > .\$nameSource\$api\$folderRequestsApi\$nameFileRequest
		#Response
			$nameclassResponse = $ModelName+$nameResponse
			Write-Host "Creating "$nameclassResponse -ForegroundColor Magenta
			$contentResponse = ResponseContent $namespaceResponseApi $nameclassResponse
			$nameFileResponse = $nameclassResponse+".cs"
			echo $contentResponse > .\$nameSource\$api\$folderResponseApi\$nameFileResponse
		#Controller
			$nameclassController = $ModelName+$nameController
			$contentController = ControllerContent $namespaceRequestsApi $namespaceResponseApi $namespaceBLL $namespaceConstants $namespaceModelsDto $namespaceController $nameclassController $nameinterfaceBLL $nameclassModelsDto $nameclassResponse $nameclassRequest
			$nameFileClassController = $nameclassController+".cs"
			echo $contentController > .\$nameSource\$api\$folderController\$nameFileClassController
		#ProfileApi
			$nameclassProfileApi = $ModelName+$nameProfile
			Write-Host "Creating "$nameclassProfileApi -ForegroundColor Magenta
			$contentProfileApi = ProfileApiContent $namespaceRequestsApi $namespaceResponseApi $namespaceModelsDto $namespaceMappingsApi $nameclassProfileApi $nameclassRequest $nameclassModelsDto $nameclassResponse
			$nameFileProfileApi = $nameclassProfileApi+".cs"
			echo $contentProfileApi > .\$nameSource\$api\$folderMappingsApi\$nameFileProfileApi
	}

	#This function is expected to run in the same folder where .sln is
	function AddBaseFiles([string] $NameSpaceConstants, 
						  [string] $NameSpaceController,
						  [string] $NameSpaceRepository){
		Write-Host "`n`n"
		#BaseConstants
			$nameclassBaseConstants = $nameBaseConstants
			$fileBaseConstants = $nameclassBaseConstants+".cs"
			Write-Host "Creating "$nameclassBaseConstants -ForegroundColor Magenta
			$baseConstantsContent = Get-Content $pathCommonFiles\$fileBaseConstants
			$baseConstantsContent = $baseConstantsContent -replace "NameSpaceVar", $NameSpaceConstants
			echo $baseConstantsContent > .\$nameSource\$common\$folderConstants\$fileBaseConstants
		#BaseController
			$nameclassBaseController = $nameBaseController
			$fileBaseController = $nameclassBaseController+".cs"
			Write-Host "Creating "$nameclassBaseController -ForegroundColor Magenta
			$baseControllerContent = Get-Content $pathCommonFiles\$fileBaseController
			$baseControllerContent = $baseControllerContent -replace "NameSpaceVar", $NameSpaceController
			$baseControllerContent = $baseControllerContent -replace "NSpaceConstants", $NameSpaceConstants
			echo $baseControllerContent > .\$nameSource\$api\$folderController\$fileBaseController
		#BaseRepository
			$nameclassBaseRepository = $nameBaseRepository
			$fileBaseRepository = $nameclassBaseRepository+".cs"
			Write-Host "Creating "$nameclassBaseRepository -ForegroundColor Magenta
			$baseRepositoryContent = Get-Content $pathCommonFiles"\BaseRepository.cs"
			$baseRepositoryContent = $baseRepositoryContent -replace "NameSpaceVar", $NameSpaceRepository
			echo $baseRepositoryContent > .\$nameSource\$dal\$folderRepositories\$fileBaseRepository
	}

	function PostmanEnvironmentContent([string] $ProjectNameVar,
									  [string] $ProjectUrlValueVar){
		$result = Get-Content $pathHelperCreateAPIProject"\POSTMAN\BasicPostmanEnviroment.postman_environment.json"
		$result = $result -replace "ProjectNameVar", $ProjectNameVar
		$result = $result -replace "ProjectUrlValueVar", $ProjectUrlValueVar
		$DateTimeVar = [DateTime]::UtcNow.ToString('u').Replace(' ','T')
		$result = $result -replace "DateTimeVar", $DateTimeVar
		$GuidVar = New-Guid  | Select-String -Pattern "[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}"
		$result = $result -replace "GuidVar", $GuidVar
		return $result
	}

	function PostmanControllerContent([string] $NameControllerParam,
									  [string] $NameProjectVar){
		$NameFolderControllerVar = $NameControllerParam+$nameController
		$NameControllerPathVar = $NameControllerParam
		$result = Get-Content $pathHelperCreateAPIProject"\POSTMAN\BasicControllerConfigPostman.json"
		$result = $result -replace "NameFolderControllerVar", $NameFolderControllerVar
		$result = $result -replace "NameControllerPathVar", $NameControllerPathVar
		$result = $result -replace "NameProjectVar", $NameProjectVar
		return $result
	}

	function PostmanCollectionContent([string] $ProjectNameVar,
									  [string[]] $ControllersVar){
		$result = Get-Content $pathHelperCreateAPIProject"\POSTMAN\BasicPostmanCollection.postman_collection.json"
		$result = $result -replace "ProjectNameVar", $ProjectNameVar
		$GuidVar = New-Guid  | Select-String -Pattern "[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}"
		$result = $result -replace "GuidVar", $GuidVar

		#Controllers Postman
		$ItemsControllerVar = ""#PostmanControllerContent $projectName $projectName
		#$ItemsControllerVar = $ItemsControllerVar + ",`n"
		For ($i=0; $i -lt $ControllersVar.Length; $i++) {
			$itemController = PostmanControllerContent $ControllersVar[$i] $projectName
			$ItemsControllerVar = $ItemsControllerVar + $itemController
			if($i+1 -ne $ControllersVar.Length){
				$ItemsControllerVar = $ItemsControllerVar + ",`n"
			}
		}

		$result = $result -replace "ItemsControllerVar", $ItemsControllerVar
		return $result
	}

	function MigrationsScriptContent([string] $NameProjectVar,
									 [string] $NameDALVar,
								 	 [string] $NameContextVar,
									 [string] $NameAPIVar){
		$result = Get-Content $pathHelperCreateAPIProject"\DAL\BaseMigrationScript.ps1"
		$result = $result -replace "NameProjectVar", $NameProjectVar
		$result = $result -replace "NameDALVar", $NameDALVar
		$result = $result -replace "NameNewMigrationVar", "InitialMigration"
		$result = $result -replace "NameContextVar", $NameContextVar
		$result = $result -replace "NameAPIVar", $NameAPIVar
		return $result
	}



#Generate project
mkdir .\$projectName
cd .\$projectName
	dotnet new gitignore
	
	mkdir .\$projectName
	cd .\$projectName
		mkdir .\$nameSource
		cd .\$nameSource
			Write-Host "`n`n`n`n`n`nCreating "$common -ForegroundColor Green
			mkdir .\$common
			cd .\$common
				dotnet new classlib -f $dotnetVersion
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
				rm Class1.cs
				dotnet add reference ..\$common\$common.csproj
				mkdir .\$folderModels
				mkdir .\$folderContext
				cd .\$folderContext
					$nameclassContexts = $projectName+$nameContext
					Write-Host "Creating "$nameclassContexts -ForegroundColor Magenta
					$tables = TablesContext $controllers
					$contentContexts = ContextContent $namespaceModels $namespaceContexts $nameclassContexts $tables
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
				cd .\Properties
					Write-Host "Creating launchSettings" -ForegroundColor Magenta
					$portProject = Get-Content .\launchSettings.json | Select-String -Pattern "`"applicationUrl`": `"http://localhost:[0-9]+`""
					$ProjectUrl = $portProject | Select-String -Pattern "http`:`/`/localhost`:`[0`-9`]`+" -AllMatches | foreach {$_.matches.value}
					#I dont have idea, why i need this line twice? If I dont have second, the result is incorrect
					$ProjectUrl = $ProjectUrl | Select-String -Pattern "http`:`/`/localhost`:`[0`-9`]`+" -AllMatches | foreach {$_.matches.value}
					$launchsettingscontent = LaunchSettingsContent $api $portProject
					rm launchSettings.json
					echo $launchsettingscontent > launchSettings.json
				cd ..
				Write-Host "Creating appsettings.Development" -ForegroundColor Magenta
				$appsettingsdevelopmentcontent =  AppSettingsDevelopmentContent $ProjectName
				rm appsettings.Development.json
				echo $appsettingsdevelopmentcontent > appsettings.Development.json
				Write-Host "Creating Startup" -ForegroundColor Magenta
				$nameClassBLL = $controllers[0]+$nameBll
				$nameclassRepositories = $controllers[0]+$nameRepository
				$startUpContent = StartupContent $namespaceBLL $namespaceSettings $nameSpaceContexts $namespaceRepositories $api $nameclassSettings $nameClassBLL $projectName $nameclassContexts $nameclassRepositories
				rm Startup.cs
				echo $startUpContent > Startup.cs
				Write-Host "Creating Program" -ForegroundColor Magenta
				$programContent = ProgramContent $nameSpaceContexts $api $nameclassContexts
				rm Program.cs
				echo $programContent > Program.cs
				mkdir .\$folderMappingsApi
				mkdir .\$folderRequestsApi
				mkdir .\$folderResponseApi
			cd ..
		cd ..

		#Create a ControllerBllDalCreatePath
		#ControllerBllDalCreatePath($projectName)
		
		#Create a others ControllerBllDalCreatePath
		For ($i=0; $i -lt $controllers.Length; $i++) {
			ControllerBllDalCreatePath($controllers[$i])
		}

		#Create a BaseFiles
		#AddBaseFiles $namespaceConstants $namespaceController $namespaceRepositories

		#Unit Test
		mkdir .\Test
		cd  .\Test
			Write-Host "`n`n`n`n`n`nCreating "$datatesthelper -ForegroundColor Green
			mkdir .\$datatesthelper
			cd .\$datatesthelper
				dotnet new mstest -f $dotnetVersion
				dotnet add reference ..\..\$nameSource\$api\$api.csproj
				dotnet add reference ..\..\$nameSource\$bll\$bll.csproj
				dotnet add reference ..\..\$nameSource\$common\$common.csproj
				dotnet add reference ..\..\$nameSource\$dal\$dal.csproj
				rm UnitTest1.cs
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$apiTest -ForegroundColor Green
			mkdir .\$apiTest
			cd .\$apiTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\$nameSource\$api\$api.csproj
				dotnet add reference ..\..\$nameSource\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$bllTest -ForegroundColor Green
			mkdir .\$bllTest
			cd .\$bllTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\$nameSource\$bll\$bll.csproj
				dotnet add reference ..\..\$nameSource\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$commonTest -ForegroundColor Green
			mkdir .\$commonTest
			cd .\$commonTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\$nameSource\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$dalTest -ForegroundColor Green
			mkdir .\$dalTest
			cd .\$dalTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\$nameSource\$dal\$dal.csproj
				dotnet add reference ..\..\$nameSource\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
		cd ..
	
	Write-Host "`n`n`n`n`n`nCreating "$projectName -ForegroundColor Cyan
	dotnet new sln --name $projectName
	dotnet sln add ".\$nameSource\$api\$api.csproj"
	dotnet sln add ".\$nameSource\$bll\$bll.csproj"
	dotnet sln add ".\$nameSource\$common\$common.csproj"
	dotnet sln add ".\$nameSource\$dal\$dal.csproj"

	dotnet sln add ".\$nameTest\$apiTest\$apiTest.csproj"
	dotnet sln add ".\$nameTest\$bllTest\$bllTest.csproj"
	dotnet sln add ".\$nameTest\$commonTest\$commonTest.csproj"
	dotnet sln add ".\$nameTest\$dalTest\$dalTest.csproj"
	dotnet sln add ".\$nameTest\$datatesthelper\$datatesthelper.csproj"

	Copy-Item "..\..\HelperCreateAPIProject\NuGet.Config" -Destination ".\"

	#Instalation nugets
	Write-Host "Instalation nugets in "$api -ForegroundColor Green
	dotnet add .\$nameSource\$api package Autofac
	dotnet add .\$nameSource\$api package Autofac.Extensions.DependencyInjection
	dotnet add .\$nameSource\$api package Microsoft.EntityFrameworkCore.Design

	Write-Host "Instalation nugets in "$bll -ForegroundColor Green
	
	Write-Host "Instalation nugets in "$common -ForegroundColor Green
	dotnet add .\$nameSource\$common package $nameAPIBase --version $versionAPIBase
	dotnet add .\$nameSource\$common package AutoMapper.Extensions.Microsoft.DependencyInjection
	
	Write-Host "Instalation nugets in "$dal -ForegroundColor Green
	dotnet add .\$nameSource\$dal package Microsoft.EntityFrameworkCore
	dotnet add .\$nameSource\$dal package Npgsql.EntityFrameworkCore.PostgreSQL
	dotnet add .\$nameSource\$dal package Microsoft.EntityFrameworkCore.Design

	Write-Host "Instalation nugets in "$apiTest -ForegroundColor Green
	
	Write-Host "Instalation nugets in "$bllTest -ForegroundColor Green
	
	Write-Host "Instalation nugets in "$commonTest -ForegroundColor Green
	
	Write-Host "Instalation nugets in "$dalTest -ForegroundColor Green

	Write-Host "Instalation nugets in "$datatesthelper -ForegroundColor Green
	dotnet add .\$nameTest\$datatesthelper package $nameAPIBaseTest --version $versionAPIBaseTest


	##Add migrations file
	$nameFileMigration = $projectName+"MigrationScript.ps1"
	Write-Host "`n`n`n`n`n`nCreating "$nameFileMigration -ForegroundColor Green
	$migrationsContent = MigrationsScriptContent $projectName $dal $nameclassContexts $api
	echo $migrationsContent > .\$nameFileMigration


	cd ..

	Write-Host "`n`n`n`n`n`nCreating "$folderPostmanFiles -ForegroundColor Green
	mkdir .\$folderPostmanFiles
	cd .\$folderPostmanFiles
		$nameFilePostmanCollection = $projectName+".postman_collection.json"
		Write-Host "Creating "$nameFilePostmanCollection -ForegroundColor Magenta
		$postmanCollectionContent = PostmanCollectionContent $projectName $controllers
		echo $postmanCollectionContent > .\$nameFilePostmanCollection
		$nameFilePostmanEnvironment = $projectName+".postman_environment.json"
		Write-Host "Creating "$nameFilePostmanEnvironment -ForegroundColor Magenta
		$postmanEnvironmentContent = PostmanEnvironmentContent $projectName $ProjectUrl
		echo $postmanEnvironmentContent > .\$nameFilePostmanEnvironment
	cd..

cd ..
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
	$nameTestHelper = "Helpers." + $nameTest

$nameBaseConstants = "BaseConstants"
$nameBaseController = "BaseController"
$nameBaseRepository = "BaseRepository"

$namePostman = "postman"

$dotnetVersion = "netcoreapp3.1"

$nameAPIBase = "APIBase"
$versionAPIBase = "0.0.1"

$nameAPIBaseTest = "APIBaseTest"
$versionAPIBaseTest = "0.0.6"

##########################################################Paths And NameSpaces##########################################################
$pathScript = Convert-Path .\
$pathHelperCreateAPIProject = $pathScript+"\HelperCreateAPIProject"

$pathCommonFiles = $pathScript+"\CommonFiles"

$common=$projectName + "." + $nameCommon
	$folderConstants = $nameConstant
		$namespaceConstants = $common+"."+$folderConstants
		$nameclassConstants = $folderConstants
	$folderSettings = $nameSettings
		$namespaceSettings = $common+"."+$folderSettings
		$nameclassSettings = $projectName+$folderSettings
	$folderDtos = $nameDto + "s"
		$folderModelsDtos = $nameModel + "s" + $nameDto + "s"
			$namespaceModelsDto = $common+"."+$folderDtos+"."+$folderModelsDtos

$dal=$projectName + "." + $nameDal
	$folderModels = $nameModel + "s"
		$namespaceModels = $dal+"."+$folderModels
	$folderContext = $nameContext + "s"
		$namespaceContexts = $dal+"."+$folderContext
		$nameclassContexts = $projectName+$nameContext
	$folderRepositories = $nameRepositories
		$namespaceRepositories = $dal+"."+$folderRepositories
	$folderMappingsDal = $nameMapping + "s"
		$namespaceMappingsDal = $dal+"."+$folderMappingsDal

$bll=$projectName + "." + $nameBll
	$folderBLLs = $nameBll + "s"
		$namespaceBLL = $bll+"."+$folderBLLs

$api=$projectName + "." + $nameApi
	$folderController = $nameController + "s"
		$namespaceController = $api+"."+$folderController
	$folderMappingsApi = $nameMapping + "s"
		$namespaceMappingsApi = $api+"."+$folderMappingsApi
	$folderRequestsApi = $nameRequest + "s"
		$namespaceRequestsApi = $api+"."+$folderRequestsApi
	$folderResponseApi = $nameResponse + "s"
		$namespaceResponseApi = $api+"."+$folderResponseApi

$datatesthelper = $projectName + "." + $nameTestHelper
	$namespaceTestHelper = $datatesthelper
	$nameclassHelpersTest = "DataTestHelper"

$commonTest=$projectName + "." + $nameCommon + "." + $nameTest

$dalTest=$projectName + "." + $nameDal + "." + $nameTest
	$folderMappingsTestDal = $nameMapping + "s" + $nameTest
		$namespaceMappingsTestDal = $dalTest + "." + $folderMappingsTestDal
	$folderRepositoriesTest = $nameRepositories + $nameTest
		$namespaceRepositoriesTest = $dalTest + "." + $folderRepositoriesTest

$bllTest=$projectName + "." + $nameBll + "." + $nameTest
	$folderBllsTest = $nameBll + "s" + $nameTest
		$namespaceBLLTest = $bllTest + "." + $folderBllsTest

$apiTest=$projectName + "." + $nameApi + "." + $nameTest
	$folderMappingsTestApi = $nameMapping + "s" + $nameTest
		$namespaceMappingsTestApi = $apiTest + "." + $folderMappingsTestApi
	$folderControllersTest = $nameController + "s" + $nameTest
		$namespaceControllerTest = $apiTest + "." + $folderControllersTest

$folderPostmanFiles = $projectName + "." + $namePostman

##########################################################Functions##########################################################
	function ConstantsContent([string] $nameSpace, 
							  [string] $nameClass) {
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Common\BasicConstants.cs" -Raw
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		return $result
	}

	function SettingsContent([string] $nameSpace, 
							 [string] $nameClass, 
							 [string] $dataBaseVar) {
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Common\BasicSettings.cs" -Raw
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		$result = $result -replace "DataBaseVar", $dataBaseVar
		return $result
	}

	function ModelDtoContent([string] $nameSpace, 
							 [string] $nameClass) {
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Common\BasicModelDto.cs" -Raw
		$result = $result -replace "NameSpaceVar", $nameSpace
		$result = $result -replace "NameClassVar", $nameClass
		return $result
	}

	function ModelContent([string] $nameSpace, 
						  [string] $nameClass) {
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Dal\BasicModel.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Dal\BasicContext.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Dal\BasicRepository.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Dal\IBasicRepository.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Bll\BasicBLL.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Bll\IBasicBLL.cs" -Raw
		$result = $result -replace "ModelsDtosNSpaceVar", $modelsDtosNSpaceVar
		$result = $result -replace "NameSpaceVar", $nameSpaceVar
		$result = $result -replace "NameClassVar", $nameClassVar
		$result = $result -replace "NameModelDtoVar", $nameModelDtoVar
		$param = $nameModelDtoVar.subString(0,1).ToLower()+$nameModelDtoVar.subString(1,$nameModelDtoVar.Length-1)
		$result = $result -replace "nameModelDtoParamVar", $param
		return $result
	}

	function LaunchSettingsContent([string] $projectNameLaunch, 
								   [string] $portVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Api\BasicLauchSettings.json" -Raw
		$result = $result -replace "ProjectNameLaunchVar", $projectNameLaunch
		$result = $result -replace "PortVar", $portVar
		return $result
	}

	function AppSettingsDevelopmentContent([string] $database){
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Api\BasicAppSettings.development.json" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Api\BasicController.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Api\BasicStartup.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Api\BasicProgram.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Dal\BasicProfile.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Api\BasicProfile.cs" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Api\BasicRequest.cs" -Raw
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		return $result
	}

	function ResponseContent ([string] $NameSpaceVar, 
							  [string] $NameClassVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Api\BasicResponse.cs" -Raw
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "NameClassVar", $NameClassVar
		return $result
	}

	function ControllerAddAsyncTestContent ([string] $NSpaceControllersVar, 
											[string] $NSpaceResponsesVar, 
											[string] $NSpaceBllsVar, 
											[string] $NSpaceModelsDtosVar, 
											[string] $NSpaceTestHelperVar, 
											[string] $NameSpaceVar, 
											[string] $ClassToTestVar, 
											[string] $MoRequestVar, 
											[string] $MoDtoVar, 
											[string] $IBLLVar, 
							  				[string] $MoResponse){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\ApiTest\ControllersTest\BasicAddAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceControllersVar", $NSpaceControllersVar
		$result = $result -replace "NSpaceResponsesVar", $NSpaceResponsesVar
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoRequestVar", $MoRequestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IBLLVar", $IBLLVar
		$result = $result -replace "MoResponse", $MoResponse
		return $result
	}

	function ControllerDeleteAsyncTestContent ([string] $NSpaceControllersVar, 
											[string] $NSpaceResponsesVar, 
											[string] $NSpaceBllsVar, 
											[string] $NSpaceModelsDtosVar, 
											[string] $NSpaceTestHelperVar, 
											[string] $NameSpaceVar, 
											[string] $ClassToTestVar, 
											[string] $MoRequestVar, 
											[string] $MoDtoVar, 
											[string] $IBLLVar, 
							  				[string] $MoResponse){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\ApiTest\ControllersTest\BasicDeleteAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceControllersVar", $NSpaceControllersVar
		$result = $result -replace "NSpaceResponsesVar", $NSpaceResponsesVar
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoRequestVar", $MoRequestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IBLLVar", $IBLLVar
		$result = $result -replace "MoResponse", $MoResponse
		return $result
	}

	function ControllerGetAllAsyncTestContent ([string] $NSpaceControllersVar, 
											   [string] $NSpaceResponsesVar, 
											   [string] $NSpaceBllsVar, 
											   [string] $NSpaceModelsDtosVar, 
											   [string] $NSpaceTestHelperVar, 
											   [string] $NameSpaceVar, 
											   [string] $ClassToTestVar,
											   [string] $MoDtoVar, 
											   [string] $IBLLVar, 
											   [string] $MoResponse){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\ApiTest\ControllersTest\BasicGetAllAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceControllersVar", $NSpaceControllersVar
		$result = $result -replace "NSpaceResponsesVar", $NSpaceResponsesVar
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IBLLVar", $IBLLVar
		$result = $result -replace "MoResponse", $MoResponse
		return $result
	}

	function ControllerGetByIdAsyncTestContent ([string] $NSpaceControllersVar, 
											   [string] $NSpaceResponsesVar, 
											   [string] $NSpaceBllsVar, 
											   [string] $NSpaceModelsDtosVar, 
											   [string] $NSpaceTestHelperVar, 
											   [string] $NameSpaceVar, 
											   [string] $ClassToTestVar,
											   [string] $MoDtoVar, 
											   [string] $IBLLVar, 
											   [string] $MoResponse){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\ApiTest\ControllersTest\BasicGetByIdAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceControllersVar", $NSpaceControllersVar
		$result = $result -replace "NSpaceResponsesVar", $NSpaceResponsesVar
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IBLLVar", $IBLLVar
		$result = $result -replace "MoResponse", $MoResponse
		return $result
	}

	function ControllerUpdateAsyncTestContent ([string] $NSpaceControllersVar, 
											   [string] $NSpaceResponsesVar, 
											   [string] $NSpaceBllsVar, 
											   [string] $NSpaceModelsDtosVar, 
											   [string] $NSpaceTestHelperVar, 
											   [string] $NameSpaceVar, 
											   [string] $ClassToTestVar, 
											   [string] $MoRequestVar, 
											   [string] $MoDtoVar, 
											   [string] $IBLLVar, 
											   [string] $MoResponse){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\ApiTest\ControllersTest\BasicUpdateAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceControllersVar", $NSpaceControllersVar
		$result = $result -replace "NSpaceResponsesVar", $NSpaceResponsesVar
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoRequestVar", $MoRequestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IBLLVar", $IBLLVar
		$result = $result -replace "MoResponse", $MoResponse
		return $result
	}

	function MappingProfileApiTestContent ([string] $NSpaceMappingsVar, 
					  				       [string] $NSpaceRequestsVar, 
					  				       [string] $NSpaceResponsesVar, 
					  				       [string] $NSpaceModelsDtosVar, 
					  				       [string] $NSpaceTestHelperVar, 
					  				       [string] $NameSpaceVar, 
					  				       [string] $ClassToTestVar, 
					  				       [string] $MoRequestVar, 
					  				       [string] $MoDtoVar, 
					  				       [string] $MoResponse){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\ApiTest\MappingsTest\BasicProfileTest.cs" -Raw
		$result = $result -replace "NSpaceMappingsVar", $NSpaceMappingsVar
		$result = $result -replace "NSpaceRequestsVar", $NSpaceRequestsVar
		$result = $result -replace "NSpaceResponsesVar", $NSpaceResponsesVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoRequestVar", $MoRequestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "MoResponse", $MoResponse
		return $result
	}

	function HelpersPerPathContent ([string] $MoDtoVar, 
					  			    [string] $MoResponseVar, 
					  			    [string] $MoRequestVar,
								    [string] $MoModelVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\TestHelpers\BasicFunctionsTestHelpers.cs" -Raw
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "MoResponseVar", $MoResponseVar
		$result = $result -replace "MoRequestVar", $MoRequestVar
		$result = $result -replace "MoModelVar", $MoModelVar
		#$result = $result -replace "`n", "`r`n"
		return $result
	}

	function HelpersTestContent ([string] $NSpaceRequestsVar, 
					  			 [string] $NSpaceResponsesVar, 
					  			 [string] $NSpaceModelsDtosVar, 
					  			 [string] $NSpaceModelsVar, 
					  			 [string] $NameSpaceVar,
								 [string[]] $PathName){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\TestHelpers\BasicDataTestHelper.cs" -Raw
		$result = $result -replace "NSpaceRequestsVar", $NSpaceRequestsVar
		$result = $result -replace "NSpaceResponsesVar", $NSpaceResponsesVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar

		$FunctionsContent = ""
		For ($i=0; $i -lt $PathName.Length; $i++) {
			$MoDtoVar = $PathName[$i] + $nameDto
			$MoResponseVar = $PathName[$i] + $nameResponse
			$MoRequestVar = $PathName[$i] + $nameRequest
			$MoModelVar = $PathName[$i]
			$functionsOnePath = HelpersPerPathContent $MoDtoVar $MoResponseVar $MoRequestVar $MoModelVar
			$FunctionsContent = $FunctionsContent + $functionsOnePath
			if($i+1 -ne $PathName.Length){
				$FunctionsContent = $FunctionsContent + "`n"
			}
		}

		$result = $result -replace "FunctionsVar", $FunctionsContent
		return $result
	}

	function BllAddAsyncTestContent ([string] $NSpaceBllsVar, 
									 [string] $NSpaceModelsDtosVar, 
									 [string] $NSpaceRepositoriesVar,
									 [string] $NSpaceTestHelperVar, 
									 [string] $NameSpaceVar, 
									 [string] $ClassToTestVar,
									 [string] $MoDtoVar, 
									 [string] $IRepositoryVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\BllTest\BllsTest\BasicAddAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IRepositoryVar", $IRepositoryVar
		return $result
	}

	function BllDeleteAsyncTestContent ([string] $NSpaceBllsVar, 
									 	[string] $NSpaceModelsDtosVar, 
									 	[string] $NSpaceRepositoriesVar,
									 	[string] $NSpaceTestHelperVar, 
									 	[string] $NameSpaceVar, 
									 	[string] $ClassToTestVar,
									 	[string] $MoDtoVar, 
									 	[string] $IRepositoryVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\BllTest\BllsTest\BasicDeleteAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IRepositoryVar", $IRepositoryVar
		return $result
	}

	function BllGetAllTestContent ([string] $NSpaceBllsVar, 
								   [string] $NSpaceModelsDtosVar, 
								   [string] $NSpaceRepositoriesVar,
								   [string] $NSpaceTestHelperVar, 
								   [string] $NameSpaceVar, 
								   [string] $ClassToTestVar,
								   [string] $MoDtoVar, 
								   [string] $IRepositoryVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\BllTest\BllsTest\BasicGetAllAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IRepositoryVar", $IRepositoryVar
		return $result
	}

	function BllGetByIdAsyncTestContent ([string] $NSpaceBllsVar, 
									 	 [string] $NSpaceModelsDtosVar, 
									 	 [string] $NSpaceRepositoriesVar,
									 	 [string] $NSpaceTestHelperVar, 
									 	 [string] $NameSpaceVar, 
									 	 [string] $ClassToTestVar,
									 	 [string] $MoDtoVar, 
									 	 [string] $IRepositoryVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\BllTest\BllsTest\BasicGetByIdAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IRepositoryVar", $IRepositoryVar
		return $result
	}

	function BllUpdateAsyncTestContent ([string] $NSpaceBllsVar, 
									 	[string] $NSpaceModelsDtosVar, 
									 	[string] $NSpaceRepositoriesVar,
									 	[string] $NSpaceTestHelperVar, 
									 	[string] $NameSpaceVar, 
									 	[string] $ClassToTestVar,
									 	[string] $MoDtoVar, 
									 	[string] $IRepositoryVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\BllTest\BllsTest\BasicUpdateAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceBllsVar", $NSpaceBllsVar
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "IRepositoryVar", $IRepositoryVar
		return $result
	}

	function RepositoryAddAsyncTestContent ([string] $NSpaceContextsVar, 
									 		[string] $NSpaceModelsVar, 
									 		[string] $NSpaceRepositoriesVar,
									 		[string] $NSpaceTestHelperVar, 
									 		[string] $NameSpaceVar, 
									 		[string] $ClassToTestVar,
									 		[string] $ContextToUse,
									 		[string] $MoModelVar, 
									 		[string] $MoDtoVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\DalTest\RepositoriesTest\BasicAddAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceContextsVar", $NSpaceContextsVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "ContextToUse", $ContextToUse
		$result = $result -replace "MoModelVar", $MoModelVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		return $result
	}

	function RepositoryDeleteAsyncTestContent ([string] $NSpaceContextsVar, 
									 		   [string] $NSpaceModelsVar, 
									 		   [string] $NSpaceRepositoriesVar,
									 		   [string] $NSpaceTestHelperVar, 
									 		   [string] $NameSpaceVar, 
									 		   [string] $ClassToTestVar,
									 		   [string] $ContextToUse,
									 		   [string] $MoModelVar, 
									 		   [string] $MoDtoVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\DalTest\RepositoriesTest\BasicDeleteAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceContextsVar", $NSpaceContextsVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "ContextToUse", $ContextToUse
		$result = $result -replace "MoModelVar", $MoModelVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		return $result
	}

	function RepositoryGetAllAsyncTestContent ([string] $NSpaceContextsVar, 
									 		   [string] $NSpaceModelsVar, 
									 		   [string] $NSpaceRepositoriesVar,
									 		   [string] $NSpaceTestHelperVar, 
									 		   [string] $NameSpaceVar, 
									 		   [string] $ClassToTestVar,
									 		   [string] $ContextToUse,
									 		   [string] $MoModelVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\DalTest\RepositoriesTest\BasicGetAllAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceContextsVar", $NSpaceContextsVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "ContextToUse", $ContextToUse
		$result = $result -replace "MoModelVar", $MoModelVar
		return $result
	}

	function RepositoryGetByIdAsyncTestContent ([string] $NSpaceContextsVar, 
									 			[string] $NSpaceModelsVar, 
									 			[string] $NSpaceRepositoriesVar,
									 			[string] $NSpaceTestHelperVar, 
									 			[string] $NameSpaceVar, 
									 			[string] $ClassToTestVar,
									 			[string] $ContextToUse,
									 			[string] $MoModelVar, 
									 			[string] $MoDtoVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\DalTest\RepositoriesTest\BasicGetByIdAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceContextsVar", $NSpaceContextsVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "ContextToUse", $ContextToUse
		$result = $result -replace "MoModelVar", $MoModelVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		return $result
	}

	function RepositoryUpdateAsyncTestContent ([string] $NSpaceContextsVar, 
									 		   [string] $NSpaceModelsVar, 
									 		   [string] $NSpaceRepositoriesVar,
									 		   [string] $NSpaceTestHelperVar, 
									 		   [string] $NameSpaceVar, 
									 		   [string] $ClassToTestVar,
									 		   [string] $ContextToUse,
									 		   [string] $MoModelVar, 
									 		   [string] $MoDtoVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\DalTest\RepositoriesTest\BasicUpdateAsyncTest.cs" -Raw
		$result = $result -replace "NSpaceContextsVar", $NSpaceContextsVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NSpaceRepositoriesVar", $NSpaceRepositoriesVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "ContextToUse", $ContextToUse
		$result = $result -replace "MoModelVar", $MoModelVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		return $result
	}

	function MappingProfileDalTestContent ([string] $NSpaceModelsDtosVar, 
					  				       [string] $NSpaceMappingsVar, 
					  				       [string] $NSpaceModelsVar, 
					  				       [string] $NSpaceTestHelperVar,
					  				       [string] $NameSpaceVar, 
					  				       [string] $ClassToTestVar, 
					  				       [string] $MoDtoVar, 
					  				       [string] $MoModelVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Test\DalTest\MappingsTest\BasicProfileTest.cs" -Raw
		$result = $result -replace "NSpaceModelsDtosVar", $NSpaceModelsDtosVar
		$result = $result -replace "NSpaceMappingsVar", $NSpaceMappingsVar
		$result = $result -replace "NSpaceModelsVar", $NSpaceModelsVar
		$result = $result -replace "NSpaceTestHelperVar", $NSpaceTestHelperVar
		$result = $result -replace "NameSpaceVar", $NameSpaceVar
		$result = $result -replace "ClassToTestVar", $ClassToTestVar
		$result = $result -replace "MoDtoVar", $MoDtoVar
		$result = $result -replace "MoModelVar", $MoModelVar
		return $result
	}

	#This function is expected to run in the same folder where .sln is
	function ControllerBllDalAndTestCreatePath([string] $ModelName){
		Write-Host "`n`n"
		#DTO
			mkdir .\$nameSource\$common\$folderDtos\$ModelName
			$nameclassModelsDto = $ModelName+$nameDto
			Write-Host "Creating "$nameclassModelsDto -ForegroundColor Magenta
			$contentModelsDto = ModelDtoContent $namespaceModelsDto $nameclassModelsDto
			$nameFileModelsDto = $nameclassModelsDto+".cs"
			Out-File -InputObject $contentModelsDto -Encoding ascii -FilePath .\$nameSource\$common\$folderDtos\$ModelName\$nameFileModelsDto
		#Model
			$nameclassModels = $ModelName
			Write-Host "Creating "$nameclassModels -ForegroundColor Magenta
			$contentModels = ModelContent $namespaceModels $nameclassModels
			$nameFileModels = $nameclassModels+".cs"
			Out-File -InputObject $contentModels -Encoding ascii -FilePath .\$nameSource\$dal\$folderModels\$nameFileModels
		#ProfileDal
			mkdir .\$nameSource\$dal\$folderMappingsDal\$ModelName
			$nameclassProfileDal = $ModelName+$nameProfile
			Write-Host "Creating "$nameclassProfileDal -ForegroundColor Magenta
			$contentProfileDal = ProfileDalContent $namespaceModelsDto $namespaceModels $namespaceMappingsDal $nameclassProfileDal $nameclassModels $nameclassModelsDto
			$nameFileProfileDal = $nameclassProfileDal+".cs"
			Out-File -InputObject $contentProfileDal -Encoding ascii -FilePath .\$nameSource\$dal\$folderMappingsDal\$ModelName\$nameFileProfileDal
		#Repository
			mkdir .\$nameSource\$dal\$folderRepositories\$ModelName
			$nameclassRepository = $ModelName+$nameRepository
			Write-Host "Creating "$nameclassRepository -ForegroundColor Magenta
			$nameinterfaceRepositories = "I"+$nameclassRepository
			$contentRepository = RepositoryContent $namespaceModelsDto $namespaceContexts $namespaceModels $namespaceRepositories $nameclassRepository $nameinterfaceRepositories $nameclassContexts $nameclassModelsDto $nameclassModels
			$nameFileClassRepositories = $nameclassRepository+".cs"
			Out-File -InputObject $contentRepository -Encoding ascii -FilePath .\$nameSource\$dal\$folderRepositories\$ModelName\$nameFileClassRepositories
			$contentIRepository = IRepositoryContent $namespaceModelsDto $namespaceRepositories $nameinterfaceRepositories $nameclassModelsDto
			$nameFileInterfaceRepositories = $nameinterfaceRepositories+".cs"
			Out-File -InputObject $contentIRepository -Encoding ascii -FilePath .\$nameSource\$dal\$folderRepositories\$ModelName\$nameFileInterfaceRepositories
		#BLL
			mkdir .\$nameSource\$bll\$folderBLLs\$ModelName
			$nameclassBLL = $ModelName+$nameBll
			Write-Host "Creating "$nameclassBLL -ForegroundColor Magenta
			$nameinterfaceBLL = "I"+$ModelName+$nameBll
			$nameRepositoryProperty = $nameclassRepository.subString(0,1)+$nameclassRepository.subString(1,1).ToLower()+$nameclassRepository.subString(2,$nameclassRepository.Length-2)
			$contentBLL = BLLContent $namespaceModelsDto $namespaceRepositories $namespaceBLL $nameclassBLL $nameinterfaceBLL $nameinterfaceRepositories $nameclassModelsDto
			$nameFileClassBLL = $nameclassBLL+".cs"
			Out-File -InputObject $contentBLL -Encoding ascii -FilePath .\$nameSource\$bll\$folderBLLs\$ModelName\$nameFileClassBLL
			$contentIBLL = IBLLContent $namespaceModelsDto $namespaceBLL $nameinterfaceBLL $nameclassModelsDto
			$nameFileInterfaceBLL = $nameinterfaceBLL+".cs"
			Out-File -InputObject $contentIBLL -Encoding ascii -FilePath .\$nameSource\$bll\$folderBLLs\$ModelName\$nameFileInterfaceBLL
		#Request
			mkdir .\$nameSource\$api\$folderRequestsApi\$ModelName
			$nameclassRequest = $ModelName+$nameRequest
			Write-Host "Creating "$nameclassRequest -ForegroundColor Magenta
			$contentRequest = RequestContent $namespaceRequestsApi $nameclassRequest
			$nameFileRequest = $nameclassRequest+".cs"
			Out-File -InputObject $contentRequest -Encoding ascii -FilePath .\$nameSource\$api\$folderRequestsApi\$ModelName\$nameFileRequest
		#Response
			mkdir .\$nameSource\$api\$folderResponseApi\$ModelName
			$nameclassResponse = $ModelName+$nameResponse
			Write-Host "Creating "$nameclassResponse -ForegroundColor Magenta
			$contentResponse = ResponseContent $namespaceResponseApi $nameclassResponse
			$nameFileResponse = $nameclassResponse+".cs"
			Out-File -InputObject $contentResponse -Encoding ascii -FilePath .\$nameSource\$api\$folderResponseApi\$ModelName\$nameFileResponse
		#Controller
			$nameclassController = $ModelName+$nameController
			$contentController = ControllerContent $namespaceRequestsApi $namespaceResponseApi $namespaceBLL $namespaceConstants $namespaceModelsDto $namespaceController $nameclassController $nameinterfaceBLL $nameclassModelsDto $nameclassResponse $nameclassRequest
			$nameFileClassController = $nameclassController+".cs"
			Out-File -InputObject $contentController -Encoding ascii -FilePath .\$nameSource\$api\$folderController\$nameFileClassController
		#ProfileApi
			mkdir .\$nameSource\$api\$folderMappingsApi\$ModelName
			$nameclassProfileApi = $ModelName+$nameProfile
			Write-Host "Creating "$nameclassProfileApi -ForegroundColor Magenta
			$contentProfileApi = ProfileApiContent $namespaceRequestsApi $namespaceResponseApi $namespaceModelsDto $namespaceMappingsApi $nameclassProfileApi $nameclassRequest $nameclassModelsDto $nameclassResponse
			$nameFileProfileApi = $nameclassProfileApi+".cs"
			Out-File -InputObject $contentProfileApi -Encoding ascii -FilePath .\$nameSource\$api\$folderMappingsApi\$ModelName\$nameFileProfileApi
		
		#ControllerTest
			$folderOneControllerTest = $nameclassController + $nameTest

			$nameclassAddAsyncTest = "AddAsyncTest"
			Write-Host "Creating "$nameclassAddAsyncTest -ForegroundColor Magenta
			$namespaceControllerTestAddAsync = $namespaceControllerTest + "." + $folderOneControllerTest
			$contentAddAsyncTest = ControllerAddAsyncTestContent $namespaceController $namespaceResponseApi $namespaceBLL $namespaceModelsDto $namespaceTestHelper $namespaceControllerTestAddAsync $nameclassController $nameclassRequest $nameclassModelsDto $nameinterfaceBLL $nameclassResponse
			$nameFileAddAsyncTest = $nameclassAddAsyncTest+".cs"
			Out-File -InputObject $contentAddAsyncTest -Encoding ascii -FilePath .\$nameTest\$apiTest\$folderControllersTest\$folderOneControllerTest\$nameFileAddAsyncTest
			
			$nameclassDeleteAsync = "DeleteAsync"
			Write-Host "Creating "$nameclassDeleteAsync -ForegroundColor Magenta
			$namespaceControllerTestDeleteAsync = $namespaceControllerTest + "." + $folderOneControllerTest
			$contentDeleteAsync = ControllerDeleteAsyncTestContent $namespaceController $namespaceResponseApi $namespaceBLL $namespaceModelsDto $namespaceTestHelper $namespaceControllerTestDeleteAsync $nameclassController $nameclassRequest $nameclassModelsDto $nameinterfaceBLL $nameclassResponse
			$nameFileDeleteAsync = $nameclassDeleteAsync+".cs"
			Out-File -InputObject $contentDeleteAsync -Encoding ascii -FilePath .\$nameTest\$apiTest\$folderControllersTest\$folderOneControllerTest\$nameFileDeleteAsync
			
			$nameclassGetAllAsyncTest = "GetAllAsyncTest"
			Write-Host "Creating "$nameclassGetAllAsyncTest -ForegroundColor Magenta
			$namespaceControllerTestGetAllAsync = $namespaceControllerTest + "." + $folderOneControllerTest
			$contentGetAllAsyncTest = ControllerGetAllAsyncTestContent $namespaceController $namespaceResponseApi $namespaceBLL $namespaceModelsDto $namespaceTestHelper $namespaceControllerTestGetAllAsync $nameclassController $nameclassModelsDto $nameinterfaceBLL $nameclassResponse
			$nameFileGetAllAsyncTest = $nameclassGetAllAsyncTest+".cs"
			Out-File -InputObject $contentGetAllAsyncTest -Encoding ascii -FilePath .\$nameTest\$apiTest\$folderControllersTest\$folderOneControllerTest\$nameFileGetAllAsyncTest
			
			$nameclassGetByIdAsyncTest = "GetByIdAsyncTest"
			Write-Host "Creating "$nameclassGetByIdAsyncTest -ForegroundColor Magenta
			$namespaceControllerTestGetByIdAsync = $namespaceControllerTest + "." + $folderOneControllerTest
			$contentGetByIdAsyncTest = ControllerGetByIdAsyncTestContent $namespaceController $namespaceResponseApi $namespaceBLL $namespaceModelsDto $namespaceTestHelper $namespaceControllerTestGetByIdAsync $nameclassController $nameclassModelsDto $nameinterfaceBLL $nameclassResponse
			$nameFileGetByIdAsyncTest = $nameclassGetByIdAsyncTest+".cs"
			Out-File -InputObject $contentGetByIdAsyncTest -Encoding ascii -FilePath .\$nameTest\$apiTest\$folderControllersTest\$folderOneControllerTest\$nameFileGetByIdAsyncTest
			
			$nameclassUpdateAsyncTest = "UpdateAsyncTest"
			Write-Host "Creating "$nameclassUpdateAsyncTest -ForegroundColor Magenta
			$namespaceControllerTestUpdateAsync = $namespaceControllerTest + "." + $folderOneControllerTest
			$contentUpdateAsyncTest = ControllerUpdateAsyncTestContent $namespaceController $namespaceResponseApi $namespaceBLL $namespaceModelsDto $namespaceTestHelper $namespaceControllerTestUpdateAsync $nameclassController $nameclassRequest $nameclassModelsDto $nameinterfaceBLL $nameclassResponse
			$nameFileUpdateAsyncTest = $nameclassUpdateAsyncTest+".cs"
			Out-File -InputObject $contentUpdateAsyncTest -Encoding ascii -FilePath .\$nameTest\$apiTest\$folderControllersTest\$folderOneControllerTest\$nameFileUpdateAsyncTest

		#ProfileApiTest
			$nameclassProfileApiTest = $nameclassProfileApi + $Test
			Write-Host "Creating "$nameclassProfileApiTest -ForegroundColor Magenta
			$contentProfileApiTest = MappingProfileApiTestContent $namespaceMappingsApi $namespaceRequestsApi $namespaceResponseApi $namespaceModelsDto $namespaceTestHelper $namespaceMappingsTestApi $nameclassProfileApi $nameclassRequest $nameclassModelsDto $nameclassResponse
			$nameFileProfileApiTest = $nameclassProfileApiTest+".cs"
			Out-File -InputObject $contentProfileApiTest -Encoding ascii -FilePath .\$nameTest\$apiTest\$folderMappingsTestApi\$nameFileProfileApiTest

		#BllTest
			$folderOneBllTest = $nameclassBLL + $nameTest

			$nameclassAddAsyncTest = "AddAsyncTest"
			Write-Host "Creating "$nameclassAddAsyncTest -ForegroundColor Magenta
			$namespaceBllTestAddAsync = $namespaceBLLTest + "." + $folderOneBllTest
			$contentAddAsyncTest = BllAddAsyncTestContent $namespaceBLL $namespaceModelsDto $namespaceRepositories $namespaceTestHelper $namespaceBllTestAddAsync $nameclassBLL $nameclassModelsDto $nameinterfaceRepositories
			$nameFileAddAsyncTest = $nameclassAddAsyncTest+".cs"
			Out-File -InputObject $contentAddAsyncTest -Encoding ascii -FilePath .\$nameTest\$bllTest\$folderBllsTest\$folderOneBllTest\$nameFileAddAsyncTest
			
			$nameclassDeleteAsync = "DeleteAsync"
			Write-Host "Creating "$nameclassDeleteAsync -ForegroundColor Magenta
			$namespaceBllTestDeleteAsync = $namespaceBLLTest + "." + $folderOneBllTest
			$contentDeleteAsync = BllDeleteAsyncTestContent $namespaceBLL $namespaceModelsDto $namespaceRepositories $namespaceTestHelper $namespaceBllTestDeleteAsync $nameclassBLL $nameclassModelsDto $nameinterfaceRepositories
			$nameFileDeleteAsync = $nameclassDeleteAsync+".cs"
			Out-File -InputObject $contentDeleteAsync -Encoding ascii -FilePath .\$nameTest\$bllTest\$folderBllsTest\$folderOneBllTest\$nameFileDeleteAsync
			
			$nameclassGetAllAsyncTest = "GetAllAsyncTest"
			Write-Host "Creating "$nameclassGetAllAsyncTest -ForegroundColor Magenta
			$namespaceBllTestGetAllAsync = $namespaceBLLTest + "." + $folderOneBllTest
			$contentGetAllAsyncTest = BllGetAllTestContent $namespaceBLL $namespaceModelsDto $namespaceRepositories $namespaceTestHelper $namespaceBllTestGetAllAsync $nameclassBLL $nameclassModelsDto $nameinterfaceRepositories
			$nameFileGetAllAsyncTest = $nameclassGetAllAsyncTest+".cs"
			Out-File -InputObject $contentGetAllAsyncTest -Encoding ascii -FilePath .\$nameTest\$bllTest\$folderBllsTest\$folderOneBllTest\$nameFileGetAllAsyncTest
			
			$nameclassGetByIdAsyncTest = "GetByIdAsyncTest"
			Write-Host "Creating "$nameclassGetByIdAsyncTest -ForegroundColor Magenta
			$namespaceBllTestGetByIdAsync = $namespaceBLLTest + "." + $folderOneBllTest
			$contentGetByIdAsyncTest = BllGetByIdAsyncTestContent $namespaceBLL $namespaceModelsDto $namespaceRepositories $namespaceTestHelper $namespaceBllTestGetByIdAsync $nameclassBLL $nameclassModelsDto $nameinterfaceRepositories
			$nameFileGetByIdAsyncTest = $nameclassGetByIdAsyncTest+".cs"
			Out-File -InputObject $contentGetByIdAsyncTest -Encoding ascii -FilePath .\$nameTest\$bllTest\$folderBllsTest\$folderOneBllTest\$nameFileGetByIdAsyncTest
			
			$nameclassUpdateAsyncTest = "UpdateAsyncTest"
			Write-Host "Creating "$nameclassUpdateAsyncTest -ForegroundColor Magenta
			$namespaceBllTestUpdateAsync = $namespaceBLLTest + "." + $folderOneBllTest
			$contentUpdateAsyncTest = BllUpdateAsyncTestContent $namespaceBLL $namespaceModelsDto $namespaceRepositories $namespaceTestHelper $namespaceBllTestUpdateAsync $nameclassBLL $nameclassModelsDto $nameinterfaceRepositories
			$nameFileUpdateAsyncTest = $nameclassUpdateAsyncTest+".cs"
			Out-File -InputObject $contentUpdateAsyncTest -Encoding ascii -FilePath .\$nameTest\$bllTest\$folderBllsTest\$folderOneBllTest\$nameFileUpdateAsyncTest
		
		#RepositoryTest
			$folderOneRepositoryTest = $nameclassRepository + $nameTest

			$nameclassAddAsyncTest = "AddAsyncTest"
			Write-Host "Creating "$nameclassAddAsyncTest -ForegroundColor Magenta
			$namespaceRepositoryTestAddAsync = $namespaceRepositoriesTest + "." + $folderOneRepositoryTest
			$contentAddAsyncTest = RepositoryAddAsyncTestContent $namespaceContexts $namespaceModels $namespaceRepositories $namespaceTestHelper $namespaceRepositoryTestAddAsync $nameclassRepository $nameclassContexts $nameclassModels $nameclassModelsDto
			$nameFileAddAsyncTest = $nameclassAddAsyncTest+".cs"
			Out-File -InputObject $contentAddAsyncTest -Encoding ascii -FilePath .\$nameTest\$dalTest\$folderRepositoriesTest\$folderOneRepositoryTest\$nameFileAddAsyncTest

			$nameclassDeleteAsyncTest = "DeleteAsyncTest"
			Write-Host "Creating "$nameclassDeleteAsyncTest -ForegroundColor Magenta
			$namespaceRepositoryTestDeleteAsync = $namespaceRepositoriesTest + "." + $folderOneRepositoryTest
			$contentDeleteAsyncTest = RepositoryDeleteAsyncTestContent $namespaceContexts $namespaceModels $namespaceRepositories $namespaceTestHelper $namespaceRepositoryTestDeleteAsync $nameclassRepository $nameclassContexts $nameclassModels $nameclassModelsDto
			$nameFileDeleteAsyncTest = $nameclassDeleteAsyncTest+".cs"
			Out-File -InputObject $contentDeleteAsyncTest -Encoding ascii -FilePath .\$nameTest\$dalTest\$folderRepositoriesTest\$folderOneRepositoryTest\$nameFileDeleteAsyncTest

			$nameclassGetAllAsyncTest = "GetAllAsyncTest"
			Write-Host "Creating "$nameclassGetAllAsyncTest -ForegroundColor Magenta
			$namespaceRepositoryTestGetAllAsync = $namespaceRepositoriesTest + "." + $folderOneRepositoryTest
			$contentGetAllAsyncTest = RepositoryGetAllAsyncTestContent $namespaceContexts $namespaceModels $namespaceRepositories $namespaceTestHelper $namespaceRepositoryTestGetAllAsync $nameclassRepository $nameclassContexts $nameclassModels
			$nameFileGetAllAsyncTest = $nameclassGetAllAsyncTest+".cs"
			Out-File -InputObject $contentGetAllAsyncTest -Encoding ascii -FilePath .\$nameTest\$dalTest\$folderRepositoriesTest\$folderOneRepositoryTest\$nameFileGetAllAsyncTest

			$nameclassGetByIdAsyncTest = "GetByIdAsyncTest"
			Write-Host "Creating "$nameclassGetByIdAsyncTest -ForegroundColor Magenta
			$namespaceRepositoryTestGetByIdAsync = $namespaceRepositoriesTest + "." + $folderOneRepositoryTest
			$contentGetByIdAsyncTest = RepositoryGetByIdAsyncTestContent $namespaceContexts $namespaceModels $namespaceRepositories $namespaceTestHelper $namespaceRepositoryTestGetByIdAsync $nameclassRepository $nameclassContexts $nameclassModels
			$nameFileGetByIdAsyncTest = $nameclassGetByIdAsyncTest+".cs"
			Out-File -InputObject $contentGetByIdAsyncTest -Encoding ascii -FilePath .\$nameTest\$dalTest\$folderRepositoriesTest\$folderOneRepositoryTest\$nameFileGetByIdAsyncTest

			$nameclassUpdateAsyncTest = "UpdateAsyncTest"
			Write-Host "Creating "$nameclassUpdateAsyncTest -ForegroundColor Magenta
			$namespaceRepositoryTestUpdateAsync = $namespaceRepositoriesTest + "." + $folderOneRepositoryTest
			$contentUpdateAsyncTest = RepositoryUpdateAsyncTestContent $namespaceContexts $namespaceModels $namespaceRepositories $namespaceTestHelper $namespaceRepositoryTestUpdateAsync $nameclassRepository $nameclassContexts $nameclassModels $nameclassModelsDto
			$nameFileUpdateAsyncTest = $nameclassUpdateAsyncTest+".cs"
			Out-File -InputObject $contentUpdateAsyncTest -Encoding ascii -FilePath .\$nameTest\$dalTest\$folderRepositoriesTest\$folderOneRepositoryTest\$nameFileUpdateAsyncTest
		
		#ProfileDalTest
			$nameclassProfileDalTest = $nameclassProfileDal + $Test
			Write-Host "Creating "$nameclassProfileDalTest -ForegroundColor Magenta
			$contentProfileDalTest = MappingProfileDalTestContent $namespaceModelsDto $namespaceMappingsDal $namespaceModels $namespaceTestHelper $namespaceMappingsTestDal $nameclassProfileDal $nameclassModelsDto $nameclassModels
			$nameFileProfileDalTest = $nameclassProfileDalTest+".cs"
			Out-File -InputObject $contentProfileDalTest -Encoding ascii -FilePath .\$nameTest\$dalTest\$folderMappingsTestDal\$nameFileProfileDalTest
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
			$baseConstantsContent = Get-Content $pathCommonFiles\$fileBaseConstants -Raw
			$baseConstantsContent = $baseConstantsContent -replace "NameSpaceVar", $NameSpaceConstants
			Out-File -InputObject $baseConstantsContent -Encoding ascii -FilePath .\$nameSource\$common\$folderConstants\$fileBaseConstants
		#BaseController
			$nameclassBaseController = $nameBaseController
			$fileBaseController = $nameclassBaseController+".cs"
			Write-Host "Creating "$nameclassBaseController -ForegroundColor Magenta
			$baseControllerContent = Get-Content $pathCommonFiles\$fileBaseController -Raw
			$baseControllerContent = $baseControllerContent -replace "NameSpaceVar", $NameSpaceController
			$baseControllerContent = $baseControllerContent -replace "NSpaceConstants", $NameSpaceConstants
			Out-File -InputObject $baseControllerContent -Encoding ascii -FilePath .\$nameSource\$api\$folderController\$fileBaseController
		#BaseRepository
			$nameclassBaseRepository = $nameBaseRepository
			$fileBaseRepository = $nameclassBaseRepository+".cs"
			Write-Host "Creating "$nameclassBaseRepository -ForegroundColor Magenta
			$baseRepositoryContent = Get-Content $pathCommonFiles"\BaseRepository.cs" -Raw
			$baseRepositoryContent = $baseRepositoryContent -replace "NameSpaceVar", $NameSpaceRepository
			Out-File -InputObject $baseRepositoryContent -Encoding ascii -FilePath .\$nameSource\$dal\$folderRepositories\$fileBaseRepository
	}

	function PostmanEnvironmentContent([string] $ProjectNameVar,
									  [string] $ProjectUrlValueVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Postman\BasicPostmanEnviroment.postman_environment.json" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Postman\BasicControllerConfigPostman.json" -Raw
		$result = $result -replace "NameFolderControllerVar", $NameFolderControllerVar
		$result = $result -replace "NameControllerPathVar", $NameControllerPathVar
		$result = $result -replace "NameProjectVar", $NameProjectVar
		return $result
	}

	function PostmanCollectionContent([string] $ProjectNameVar,
									  [string[]] $ControllersVar){
		$result = Get-Content $pathHelperCreateAPIProject"\Postman\BasicPostmanCollection.postman_collection.json" -Raw
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
		$result = Get-Content $pathHelperCreateAPIProject"\Source\Dal\BaseMigrationScript.ps1" -Raw
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
					Write-Host "Creating "$nameclassConstants -ForegroundColor Magenta
					$contentConstants = ConstantsContent $namespaceConstants $nameclassConstants
					$nameFileConstants = $nameclassConstants+".cs"
					Out-File -InputObject $contentConstants -Encoding ascii -FilePath $nameFileConstants
				cd..
				mkdir .\$folderSettings
				cd .\$folderSettings
					Write-Host "Creating "$nameclassSettings -ForegroundColor Magenta
					$settingsContent = SettingsContent $namespaceSettings $nameclassSettings $ProjectName
					$nameFileSettings = $nameclassSettings+".cs"
					Out-File -InputObject $settingsContent -Encoding ascii -FilePath $nameFileSettings
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
					Write-Host "Creating "$nameclassContexts -ForegroundColor Magenta
					$tables = TablesContext $controllers
					$contentContexts = ContextContent $namespaceModels $namespaceContexts $nameclassContexts $tables
					$nameFileContexts = $nameclassContexts+".cs"
					Out-File -InputObject $contentContexts -Encoding ascii -FilePath $nameFileContexts
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
					$portProject = (Get-Content .\launchSettings.json  -Raw | Select-String -Pattern "[0-9]+" -AllMatches)
					$portValue = $portProject.Matches[0]
					$launchsettingscontent = LaunchSettingsContent $api $portValue
					rm launchSettings.json
					Out-File -InputObject $launchsettingscontent -Encoding ascii -FilePath launchSettings.json
				cd ..
				Write-Host "Creating appsettings.Development" -ForegroundColor Magenta
				$appsettingsdevelopmentcontent =  AppSettingsDevelopmentContent $ProjectName
				rm appsettings.Development.json
				Out-File -InputObject $appsettingsdevelopmentcontent -Encoding ascii -FilePath appsettings.Development.json
				Write-Host "Creating Startup" -ForegroundColor Magenta
				$nameClassBLL = $controllers[0]+$nameBll
				$nameclassRepositories = $controllers[0]+$nameRepository
				$startUpContent = StartupContent $namespaceBLL $namespaceSettings $nameSpaceContexts $namespaceRepositories $api $nameclassSettings $nameClassBLL $projectName $nameclassContexts $nameclassRepositories
				rm Startup.cs
				Out-File -InputObject $startUpContent -Encoding ascii -FilePath Startup.cs
				Write-Host "Creating Program" -ForegroundColor Magenta
				$programContent = ProgramContent $nameSpaceContexts $api $nameclassContexts
				rm Program.cs
				Out-File -InputObject $programContent -Encoding ascii -FilePath Program.cs
				mkdir .\$folderMappingsApi
				mkdir .\$folderRequestsApi
				mkdir .\$folderResponseApi
			cd ..
		cd ..

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
				mkdir .\$folderControllersTest
				cd .\$folderControllersTest
					For ($i=0; $i -lt $controllers.Length; $i++) {
						$nameControllerTest = $controllers[$i] + $nameController + $nameTest
						mkdir .\$nameControllerTest
					}
				cd..
				mkdir .\$folderMappingsTestApi
			cd ..
			Write-Host "`n`n`n`n`n`nCreating "$bllTest -ForegroundColor Green
			mkdir .\$bllTest
			cd .\$bllTest
				dotnet new mstest -f $dotnetVersion
				rm UnitTest1.cs
				dotnet add reference ..\..\$nameSource\$bll\$bll.csproj
				dotnet add reference ..\..\$nameSource\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
				mkdir .\$folderBllsTest
				cd .\$folderBllsTest
					For ($i=0; $i -lt $controllers.Length; $i++) {
						$nameBllTest = $controllers[$i] + $nameBll + $nameTest
						mkdir .\$nameBllTest
					}
				cd..
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
				mkdir .\$folderRepositoriesTest
				cd .\$folderRepositoriesTest
					For ($i=0; $i -lt $controllers.Length; $i++) {
						$nameRepositoryTest = $controllers[$i] + $nameRepository + $nameTest
						mkdir .\$nameRepositoryTest
					}
				cd..
				mkdir .\$folderMappingsTestDal
			cd ..
		cd ..

		#Create a ControllerBllDalAndTestCreatePath
		#ControllerBllDalAndTestCreatePath($projectName)
		
		#Create a others ControllerBllDalAndTestCreatePath
		For ($i=0; $i -lt $controllers.Length; $i++) {
			ControllerBllDalAndTestCreatePath($controllers[$i])
		}

		#HelpersTest
		Write-Host "Creating "$nameclassHelpersTest -ForegroundColor Magenta
		$contentHelpersTest = HelpersTestContent $namespaceRequestsApi $namespaceResponseApi $namespaceModelsDto $namespaceModels $namespaceTestHelper $controllers
		$nameFileHelpersTest = $nameclassHelpersTest+".cs"
		#Out-File -InputObject $contentHelpersTest -Encoding ascii -FilePath .\$nameTest\$datatesthelper\$nameFileHelpersTest
		Out-File -filepath .\$nameTest\$datatesthelper\$nameFileHelpersTest -inputobject $contentHelpersTest

		#Create a BaseFiles
		#AddBaseFiles $namespaceConstants $namespaceController $namespaceRepositories
	
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
	Out-File -InputObject $migrationsContent -Encoding ascii -FilePath .\$nameFileMigration


	cd ..

	Write-Host "`n`n`n`n`n`nCreating "$folderPostmanFiles -ForegroundColor Green
	mkdir .\$folderPostmanFiles
	cd .\$folderPostmanFiles
		$nameFilePostmanCollection = $projectName+".postman_collection.json"
		Write-Host "Creating "$nameFilePostmanCollection -ForegroundColor Magenta
		$postmanCollectionContent = PostmanCollectionContent $projectName $controllers
		Out-File -InputObject $postmanCollectionContent -Encoding ascii -FilePath .\$nameFilePostmanCollection
		$nameFilePostmanEnvironment = $projectName+".postman_environment.json"
		Write-Host "Creating "$nameFilePostmanEnvironment -ForegroundColor Magenta
		$ProjectUrl = "http`:`/`/localhost`:" + $portValue
		$postmanEnvironmentContent = PostmanEnvironmentContent $projectName $ProjectUrl
		Out-File -InputObject $postmanEnvironmentContent -Encoding ascii -FilePath .\$nameFilePostmanEnvironment
	cd..

cd ..
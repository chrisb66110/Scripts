##########################################################ProjectNames##########################################################

$projectName=$args[0]

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


##########################################################Functions##########################################################
function ClassContent([string] $nameSpace, [string] $nameClass) {
	$result = "using System.Diagnostics.CodeAnalysis;`n`nnamespace " + $nameSpace + "`n{`n    [ExcludeFromCodeCoverage]`n    public class " + $nameClass + "`n    {`n    }`n}"
	return $result
}

function ClassContentWithInterface([string] $nameSpace, [string] $nameClass, [string] $nameInterface) {
	$result = "namespace " + $nameSpace + "`n{`n    public class " + $nameClass + " : " + $nameInterface + "`n    {`n    }`n}"
	return $result
}

function InterfaceContent([string] $nameSpace, [string] $nameClass) {
	$result = "namespace " + $nameSpace + "`n{`n    public interface " + $nameClass + "`n    {`n    }`n}"
	return $result
}

function LaunchSettingsContent([string] $applicationUrl){
	$result = "{`n  `"profiles`": {`n    `""+$api+"`": {`n      `"commandName`": `"Project`",`n      `"launchBrowser`": false,`n"+$applicationUrl+"`n      `"environmentVariables`": {`n        `"ASPNETCORE_ENVIRONMENT`": `"Development`"`n      }`n    }`n  }`n}"
	return $result
}

function AppSettingsDevelopmentContent([string] $database){
	$result = "{`n  `"Logging`": {`n    `"LogLevel`": {`n      `"Default`": `"Information`",`n      `"Microsoft`": `"Warning`",`n      `"Microsoft.Hosting.Lifetime`": `"Information`"`n    }`n  },`n  `"ConnectionStrings`": {`n    `""+$database+"ConnectionString`": `"Server=localhost;UserId=userid;Password=password;Database="+$database+"`"`n  }`n}"
	return $result
}

function SettingsContent([string] $nameSpace, [string] $nameClass){
	$result = "using System.Diagnostics.CodeAnalysis;`n`nnamespace  "+$nameSpace+"`n{`n    [ExcludeFromCodeCoverage]`n    public class "+$nameClass+"`n    {`n        public ConnectionStrings ConnectionStrings { get; set; }`n    }`n`n    [ExcludeFromCodeCoverage]`n    public class ConnectionStrings`n    {`n        public string ProjectMicroserviceConnectionString { get; set; }`n    }`n}"
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
				dotnet new classlib -f netcoreapp3.1
				rm Class1.cs
				$folderConstants = "Constants"
				mkdir .\$folderConstants
				cd .\$folderConstants
					$namespaceConstants = $common+"."+$folderConstants
					$nameclassConstants = $folderConstants
					$contentConstants = ClassContent $namespaceConstants $nameclassConstants
					$nameFileConstants = $nameclassConstants+".cs"
					echo $contentConstants > $nameFileConstants
				cd..
				$folderSettings = "Settings"
				mkdir .\$folderSettings
				cd .\$folderSettings
					$namespaceSettings = $common+"."+$folderSettings
					$nameclassSettings = $projectName+$folderSettings
					$settingsContent = SettingsContent $namespaceSettings $nameclassSettings
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
						$nameclassModelsDto = "BaseModelDto"
						$contentModelsDto = ClassContent $namespaceModelsDto $nameclassModelsDto
						$nameFileModelsDto = $nameclassModelsDto+".cs"
						echo $contentModelsDto > $nameFileModelsDto
					cd ..
				cd..
			cd ..
			mkdir .\$dal
			cd .\$dal
				dotnet new classlib -f netcoreapp3.1
				rm Class1.cs
				dotnet add reference ..\$common\$common.csproj
				$folderModels = "Models"
				mkdir .\$folderModels
				cd .\$folderModels
					$namespaceModels = $dal+"."+$folderModels
					$nameclassModels = "BaseModel"
					$contentModels = ClassContent $namespaceModels $nameclassModels
					$nameFileModels = $nameclassModels+".cs"
					echo $contentModels > $nameFileModels
				cd..
				$folderContext = "Contexts"
				mkdir .\$folderContext
				cd .\$folderContext
					$namespaceContexts = $dal+"."+$folderContext
					$nameclassContexts = $projectName+"Context"
					$contentContexts = ClassContent $namespaceContexts $nameclassContexts
					$nameFileContexts = $nameclassContexts+".cs"
					echo $contentContexts > $nameFileContexts
				cd..
				$folderRepositories = "Repositories"
				mkdir .\$folderRepositories
				cd .\$folderRepositories
					$namespaceRepositories = $dal+"."+$folderRepositories
					$nameclassRepositories = "BaseRepository"
					$nameinterfaceRepositories = "I"+$nameclassRepositories
					$contentRepository = ClassContentWithInterface $namespaceRepositories $nameclassRepositories $nameinterfaceRepositories
					$nameFileClassRepositories = $nameclassRepositories+".cs"
					echo $contentRepository > $nameFileClassRepositories
					$contentIRepository = InterfaceContent $namespaceRepositories $nameinterfaceRepositories
					$nameFileInterfaceRepositories = $nameinterfaceRepositories+".cs"
					echo $contentIRepository > $nameFileInterfaceRepositories
				cd..
			cd ..
			mkdir .\$bll
			cd .\$bll
				dotnet new classlib -f netcoreapp3.1
				rm Class1.cs
				dotnet add reference ..\$dal\$dal.csproj
				dotnet add reference ..\$common\$common.csproj
				$folderBLLs = "BLLs"
				mkdir .\$folderBLLs
				cd .\$folderBLLs
					$namespaceBLL = $bll+"."+$folderBLLs
					$nameclassBLL = $projectName+"BLL"
					$nameinterfaceBLL = "I"+$projectName+"BLL"
					$contentBLL = ClassContentWithInterface $namespaceBLL $nameclassBLL $nameinterfaceBLL
					$nameFileClassBLL = $nameclassBLL+".cs"
					echo $contentBLL > $nameFileClassBLL
					$contentIBLL = InterfaceContent $namespaceBLL $nameinterfaceBLL
					$nameFileInterfaceBLL = $nameinterfaceBLL+".cs"
					echo $contentIBLL > $nameFileInterfaceBLL
				cd..
			cd ..
			mkdir .\$api
			cd .\$api
				dotnet new webapi -f netcoreapp3.1
				#rm WeatherForecast.cs
				#rm .\Controllers\WeatherForecastController.cs
				dotnet add reference ..\$bll\$bll.csproj
				dotnet add reference ..\$common\$common.csproj
				dotnet add package Autofac
				dotnet add package Autofac.Extensions.DependencyInjection
				cd .\Properties
					$portProject = Get-Content .\launchSettings.json | Select-String -Pattern "`"applicationUrl`": `"http://localhost:[0-9]+`""
					$launchsettingscontent = LaunchSettingsContent $portProject
					rm launchSettings.json
					echo $launchsettingscontent > launchSettings.json
				cd ..
				$appsettingsdevelopmentcontent =  AppSettingsDevelopmentContent $ProjectName
				rm appsettings.Development.json
				echo $appsettingsdevelopmentcontent > appsettings.Development.json
			cd ..
		cd ..

		mkdir .\Test
		cd  .\Test
			mkdir .\$datatesthelper
			cd .\$datatesthelper
				dotnet new mstest -f netcoreapp3.1
				rm UnitTest1.cs
			cd ..
			mkdir .\$apiTest
			cd .\$apiTest
				dotnet new mstest -f netcoreapp3.1
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$api\$api.csproj
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			mkdir .\$bllTest
			cd .\$bllTest
				dotnet new mstest -f netcoreapp3.1
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$bll\$bll.csproj
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			mkdir .\$commonTest
			cd .\$commonTest
				dotnet new mstest -f netcoreapp3.1
				rm UnitTest1.cs
				dotnet add reference ..\..\Source\$common\$common.csproj
				dotnet add reference ..\$datatesthelper\$datatesthelper.csproj
			cd ..
			mkdir .\$dalTest
			cd .\$dalTest
				dotnet new mstest -f netcoreapp3.1
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
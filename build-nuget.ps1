$scriptDir = split-path -parent $MyInvocation.MyCommand.Definition
$srcDir = (Join-Path -path $scriptDir src)
$original = (Join-Path -path $srcDir "DisCatSharpTemplates.nuspec")
$versioned = (Join-Path -path $srcDir "DisCatSharpTemplates-versioned.nuspec")

$tag=(git describe --tags --abbrev=0)

# nuget.exe needs to be on the path or aliased
function Reset-Templates{
    [cmdletbinding()]
    param(
        [string]$templateEngineUserDir = (join-path -Path $env:USERPROFILE -ChildPath .templateengine)
    )
    process{
        'resetting dotnet new templates. folder: "{0}"' -f $templateEngineUserDir | Write-host
        get-childitem -path $templateEngineUserDir -directory | Select-Object -ExpandProperty FullName | remove-item -recurse
        &dotnet new --debug:reinit
    }
}
function Clean(){
    [cmdletbinding()]
    param(
        [string]$rootFolder = $scriptDir
    )
    process{
        'clean started, rootFolder "{0}"' -f $rootFolder | write-host
        # delete folders that should not be included in the nuget package
        Get-ChildItem -path $rootFolder -include bin,obj,nupkg -Recurse -Directory | Select-Object -ExpandProperty FullName | Remove-item -recurse
    }
}

function SetupNuspec(){
    if (Test-Path -LiteralPath $versioned)
	{
		Write-Host "Removing Old $versioned..."
		Remove-Item -Recurse -Force $versioned
	}

    Copy-Item -Path $original -Destination $versioned
    (Get-Content $versioned).replace('%VERSION%', $tag) | Set-Content $versioned
}

function ResetSpec(){
    if (Test-Path -LiteralPath $versioned)
	{
		Write-Host "Removing Old $versioned..."
		Remove-Item -Recurse -Force $versioned
	}
}

# we need to ensure our solution template is generated / updated prior to final package
Start-Process powershell "$scriptDir\update-solution-template.ps1"

# start script
Clean
SetupNuspec

# create nuget package
$outputpath = Join-Path $scriptDir nupkg
if(Test-Path $versioned){
    nuget pack $versioned -OutputDirectory $outputpath
}
else{
    'ERROR: nuspec file not found at {0}' -f $versioned | Write-Error
    return
}

$pathtonupkg = join-path $scriptDir "nupkg/DisCatSharp.ProjectTemplates.$tag.nupkg"
# install nuget package using dotnet new --install
if(test-path $pathtonupkg){   
    Reset-Templates
    'installing template with command "dotnet new --install {0}"' -f $pathtonupkg | write-host
    &dotnet new --install $pathtonupkg
}
else{
    'Not installing template because it was not found at "{0}"' -f $pathtonupkg | Write-Error
}

ResetSpec
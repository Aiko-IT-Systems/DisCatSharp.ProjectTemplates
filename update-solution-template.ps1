# directory the script belongs to
$scriptDir = split-path -parent $MyInvocation.MyCommand.Definition

# this is the solution directory - where we will copy/update our template
$solutionDir = Join-Path $scriptDir "src/Content/DisCatSharpSolution"
$contentDir = Join-Path $scriptDir "src/Content"

# projects we need to cleanup
foreach ($projectName in "DisCatSharpProjectBot", "DisCatSharpProjectWeb")
{
	$destinationDir = Join-Path $solutionDir $projectName
	$copyDir = Join-Path $contentDir $projectName
	$templateFolder = Join-Path $destinationDir ".template.config"

	if (Test-Path -LiteralPath $destinationDir)
	{
		Write-Host "Removing Old $projectName from Solution Output..."
		Remove-Item -Recurse -Force $destinationDir
	}
	
	Write-Host "Copying $projectName into Solution Output..."
	New-Item -Path $destinationDir -ItemType Directory
	Copy-Item -Path $copyDir -Destination $solutionDir -Recurse -Force

	foreach($folder in ".template.config", "bin", "obj")
	{
		$check = Join-Path $destinationDir $folder
		if (Test-Path -LiteralPath $check)
		{
			Remove-Item -Recurse -Force "$check"
		}
	}
}
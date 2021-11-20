# directory the script belongs to
$scriptDir = split-path -parent $MyInvocation.MyCommand.Definition

# this is the solution directory - where we will copy/update our template
$solutionDir = Join-Path $scriptDir "src\Content\DisCatSharpSolution"
$contentDir = Join-Path $scriptDir "src\Content"

# projects we need to cleanup
foreach ($projectName in "DisCatSharProjectBot", "DisCatSharProjectWeb")
{
	$removeDir = Join-Path $solutionDir $projectName
	$copyDir = Join-Path $contentDir $projectName


}
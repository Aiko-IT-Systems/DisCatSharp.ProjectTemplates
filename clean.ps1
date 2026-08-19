$scriptDir = split-path -parent $MyInvocation.MyCommand.Definition

function Clean(){
    [cmdletbinding()]
    param(
        [string]$rootFolder = $scriptDir
    )
    process{
        'clean started, rootFolder "{0}"' -f $rootFolder | write-host
        # delete folders that should not be included in the nuget package
        Get-ChildItem -Path $rootFolder -Recurse -Directory |
            Where-Object { $_.Name -in @("bin", "obj", "nupkg") } |
            Remove-Item -Recurse -Force
    }
}

Clean

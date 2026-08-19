function Reset-Templates{
    [cmdletbinding()]
    param(
        [string]$templateEngineUserDir = (join-path -Path $env:USERPROFILE -ChildPath .templateengine)
    )
    process{
        'resetting dotnet new templates. folder: "{0}"' -f $templateEngineUserDir | Write-host
        if (Test-Path -LiteralPath $templateEngineUserDir)
        {
            Get-ChildItem -Path $templateEngineUserDir -Directory |
                Select-Object -ExpandProperty FullName |
                Remove-Item -Recurse -Force
        }
        &dotnet new --debug:reinit
    }
}

Reset-Templates
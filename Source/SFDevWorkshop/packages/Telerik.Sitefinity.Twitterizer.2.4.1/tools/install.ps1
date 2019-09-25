param($installPath, $toolsPath, $package, $project)

$twitterizerName = "twitterizer"
$twitterizerVersion = "2.4.1"
$twitterizerDllRelativePath = "\lib\net40\Twitterizer2.dll"

$TwitterPackages = Get-Package $twitterizerName -ProjectName $project.Name

foreach($p in $TwitterPackages)
{
	if ($p.Id -eq $twitterizerName -and $p.Version -eq $twitterizerVersion)
	{
		Uninstall-Package -Id $twitterizerName -ProjectName $project.Name -Force
		$twitterizerDllPath = Join-Path $installPath $twitterizerDllRelativePath
		$project.Object.References.Add($twitterizerDllPath)

		$project.Save()
		break
	}
}





param($installPath, $toolsPath, $package, $project)

  # Need to load MSBuild assembly if it's not loaded yet.
  Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

  # Grab the loaded MSBuild project for the project
  $msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
  $msbuild.Xml.Imports | 
  Where-Object { $_.Project -eq 'Build\RazorGenerator.MsBuild\build\RazorGenerator.MsBuild.targets' -or $_.Project -eq 'Build\FeatherPrecompilation.targets'} | 
  ForEach-Object { $msbuild.Xml.RemoveChild($_) }

  # Add project references
  Write-Host "Adding project references..."
  $references = "System.Web.Extensions", "System.Web.ApplicationServices"
  try
  {
    foreach ($reference in $references)
    {
      # Check if reference doesn't already exist
      $existingReference = $msbuild.Items | Where-Object { $_.ItemType -eq "Reference" -and $_.EvaluatedInclude.Split(",")[0] -eq $reference } | Select-Object -First 1
      if (!$existingReference)
      {
        Write-Host ("Adding '{0}' to {1}" -f $reference, $project.Name)

        $msbuild.AddItem("Reference", $reference)

        Write-Host ("Successfully added '{0}' to {1}" -f $reference, $project.Name)
      }
      else 
      {
        Write-Host ("{0} already has a reference to '{1}'" -f $project.Name, $reference)
      }
    }
  }
  catch
  {
    Write-Host ("Could not add references {0} to {1}. Please add these references manually or contact Sitefinity support." -f [system.String]::Join(", ", $references), $project.Name)
    Write-Error $_.Exception.Message
  }

  # Remove Recaptha views from Bootstrap package
  ForEach-Object { try { $project.ProjectItems.Item('ResourcePackages').ProjectItems.Item('Bootstrap').ProjectItems.Item('MVC').ProjectItems.Item('Views').ProjectItems.Item('Recaptcha') } catch { $null } } |
  Where-Object {$_ -ne $null} | 
  ForEach-Object { $_.Remove() }
  
  # Save changes to project
  $project.Save()

  $fileInfo = new-object -typename System.IO.FileInfo -ArgumentList $project.FullName
  $projectDirectory = $fileInfo.DirectoryName

  # Make sure all Resource Packages have RazorGenerator directives
  $generatorDirectivesPath = "$projectDirectory\ResourcePackages\Bootstrap\razorgenerator.directives"
  if (Test-Path $generatorDirectivesPath) 
  {
    Get-ChildItem "$projectDirectory\ResourcePackages" -Directory -Exclude "Bootstrap" |
    Where-Object { $_.GetFiles("razorgenerator.directives").Count -eq 0 } |
    ForEach-Object { Copy-Item $generatorDirectivesPath $_.FullName }
  }

  # Prompt to remove Recaptcha template if exists since it isn't distributed with Feather anymore
  $recaptchaTemplatesPath = "$projectDirectory\ResourcePackages\Bootstrap\MVC\Views\Recaptcha"
  if (Test-Path $recaptchaTemplatesPath) 
  {
    Remove-Item $recaptchaTemplatesPath -Recurse -Confirm
  }

  # Append attributes to the AssemblyInfo 
  Write-Host "Appending ControllerContainerAttribute and ResourcePackageAttribute to the AssemblyInfo..."
  $assemblyInfoPath = Join-Path $projectDirectory "Properties\AssemblyInfo.cs"
  if (Test-Path $assemblyInfoPath)
  {
    # Append ControllerContainerAttribute to the AssemblyInfo
	  $attributeRegex = "\[\s*assembly\s*\:\s*(?:(?:(?:(?:(?:(?:(?:Telerik\.)?Sitefinity\.)?Frontend\.)?Mvc\.)?Infrastructure\.)?Controllers\.)?Attributes\.)?ControllerContainer(?:Attribute)?\s*\]"
    $controllerContainerAttributeExists = (Get-Content $assemblyInfoPath | Where-Object { $_ -match $attributeRegex } | Group-Object).Count -eq 1
    if (!$controllerContainerAttributeExists)
    {
      Add-Content $assemblyInfoPath "`r`n[assembly: Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes.ControllerContainer]"
      Write-Host "Finished appending ControllerContainerAttribute to the AssemblyInfo."
    }
    else
    {
      Write-Host "ControllerContainerAttribute is already in the AssemblyInfo. Nothing is appended."
    }

    # Append ResourcePackageAttribute to the AssemblyInfo
    $attributeRegex = "\[\s*assembly\s*\:\s*(?:(?:(?:(?:(?:(?:(?:Telerik\.)?Sitefinity\.)?Frontend\.)?Mvc\.)?Infrastructure\.)?Controllers\.)?Attributes\.)?ResourcePackage(?:Attribute)?\s*\]"
    $resourcePackageAttributeExists = (Get-Content $assemblyInfoPath | Where-Object { $_ -match $attributeRegex } | Group-Object).Count -eq 1
    if (!$resourcePackageAttributeExists)
    {
      Add-Content $assemblyInfoPath "`r`n[assembly: Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes.ResourcePackage]"
      Write-Host "Finished appending ResourcePackageAttribute to the AssemblyInfo."
    }
    else
    {
      Write-Host "ResourcePackageAttribute is already in the AssemblyInfo. Nothing is appended."
    }
  }
  else
  {
    Write-Host "AssemblyInfo not found."
  }
# SIG # Begin signature block
# MIIXxAYJKoZIhvcNAQcCoIIXtTCCF7ECAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUikBxE8mjAkQ5j5LI5lRcQaIj
# UaSgghLqMIID7jCCA1egAwIBAgIQfpPr+3zGTlnqS5p31Ab8OzANBgkqhkiG9w0B
# AQUFADCBizELMAkGA1UEBhMCWkExFTATBgNVBAgTDFdlc3Rlcm4gQ2FwZTEUMBIG
# A1UEBxMLRHVyYmFudmlsbGUxDzANBgNVBAoTBlRoYXd0ZTEdMBsGA1UECxMUVGhh
# d3RlIENlcnRpZmljYXRpb24xHzAdBgNVBAMTFlRoYXd0ZSBUaW1lc3RhbXBpbmcg
# Q0EwHhcNMTIxMjIxMDAwMDAwWhcNMjAxMjMwMjM1OTU5WjBeMQswCQYDVQQGEwJV
# UzEdMBsGA1UEChMUU3ltYW50ZWMgQ29ycG9yYXRpb24xMDAuBgNVBAMTJ1N5bWFu
# dGVjIFRpbWUgU3RhbXBpbmcgU2VydmljZXMgQ0EgLSBHMjCCASIwDQYJKoZIhvcN
# AQEBBQADggEPADCCAQoCggEBALGss0lUS5ccEgrYJXmRIlcqb9y4JsRDc2vCvy5Q
# WvsUwnaOQwElQ7Sh4kX06Ld7w3TMIte0lAAC903tv7S3RCRrzV9FO9FEzkMScxeC
# i2m0K8uZHqxyGyZNcR+xMd37UWECU6aq9UksBXhFpS+JzueZ5/6M4lc/PcaS3Er4
# ezPkeQr78HWIQZz/xQNRmarXbJ+TaYdlKYOFwmAUxMjJOxTawIHwHw103pIiq8r3
# +3R8J+b3Sht/p8OeLa6K6qbmqicWfWH3mHERvOJQoUvlXfrlDqcsn6plINPYlujI
# fKVOSET/GeJEB5IL12iEgF1qeGRFzWBGflTBE3zFefHJwXECAwEAAaOB+jCB9zAd
# BgNVHQ4EFgQUX5r1blzMzHSa1N197z/b7EyALt0wMgYIKwYBBQUHAQEEJjAkMCIG
# CCsGAQUFBzABhhZodHRwOi8vb2NzcC50aGF3dGUuY29tMBIGA1UdEwEB/wQIMAYB
# Af8CAQAwPwYDVR0fBDgwNjA0oDKgMIYuaHR0cDovL2NybC50aGF3dGUuY29tL1Ro
# YXd0ZVRpbWVzdGFtcGluZ0NBLmNybDATBgNVHSUEDDAKBggrBgEFBQcDCDAOBgNV
# HQ8BAf8EBAMCAQYwKAYDVR0RBCEwH6QdMBsxGTAXBgNVBAMTEFRpbWVTdGFtcC0y
# MDQ4LTEwDQYJKoZIhvcNAQEFBQADgYEAAwmbj3nvf1kwqu9otfrjCR27T4IGXTdf
# plKfFo3qHJIJRG71betYfDDo+WmNI3MLEm9Hqa45EfgqsZuwGsOO61mWAK3ODE2y
# 0DGmCFwqevzieh1XTKhlGOl5QGIllm7HxzdqgyEIjkHq3dlXPx13SYcqFgZepjhq
# IhKjURmDfrYwggSjMIIDi6ADAgECAhAOz/Q4yP6/NW4E2GqYGxpQMA0GCSqGSIb3
# DQEBBQUAMF4xCzAJBgNVBAYTAlVTMR0wGwYDVQQKExRTeW1hbnRlYyBDb3Jwb3Jh
# dGlvbjEwMC4GA1UEAxMnU3ltYW50ZWMgVGltZSBTdGFtcGluZyBTZXJ2aWNlcyBD
# QSAtIEcyMB4XDTEyMTAxODAwMDAwMFoXDTIwMTIyOTIzNTk1OVowYjELMAkGA1UE
# BhMCVVMxHTAbBgNVBAoTFFN5bWFudGVjIENvcnBvcmF0aW9uMTQwMgYDVQQDEytT
# eW1hbnRlYyBUaW1lIFN0YW1waW5nIFNlcnZpY2VzIFNpZ25lciAtIEc0MIIBIjAN
# BgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAomMLOUS4uyOnREm7Dv+h8GEKU5Ow
# mNutLA9KxW7/hjxTVQ8VzgQ/K/2plpbZvmF5C1vJTIZ25eBDSyKV7sIrQ8Gf2Gi0
# jkBP7oU4uRHFI/JkWPAVMm9OV6GuiKQC1yoezUvh3WPVF4kyW7BemVqonShQDhfu
# ltthO0VRHc8SVguSR/yrrvZmPUescHLnkudfzRC5xINklBm9JYDh6NIipdC6Anqh
# d5NbZcPuF3S8QYYq3AhMjJKMkS2ed0QfaNaodHfbDlsyi1aLM73ZY8hJnTrFxeoz
# C9Lxoxv0i77Zs1eLO94Ep3oisiSuLsdwxb5OgyYI+wu9qU+ZCOEQKHKqzQIDAQAB
# o4IBVzCCAVMwDAYDVR0TAQH/BAIwADAWBgNVHSUBAf8EDDAKBggrBgEFBQcDCDAO
# BgNVHQ8BAf8EBAMCB4AwcwYIKwYBBQUHAQEEZzBlMCoGCCsGAQUFBzABhh5odHRw
# Oi8vdHMtb2NzcC53cy5zeW1hbnRlYy5jb20wNwYIKwYBBQUHMAKGK2h0dHA6Ly90
# cy1haWEud3Muc3ltYW50ZWMuY29tL3Rzcy1jYS1nMi5jZXIwPAYDVR0fBDUwMzAx
# oC+gLYYraHR0cDovL3RzLWNybC53cy5zeW1hbnRlYy5jb20vdHNzLWNhLWcyLmNy
# bDAoBgNVHREEITAfpB0wGzEZMBcGA1UEAxMQVGltZVN0YW1wLTIwNDgtMjAdBgNV
# HQ4EFgQURsZpow5KFB7VTNpSYxc/Xja8DeYwHwYDVR0jBBgwFoAUX5r1blzMzHSa
# 1N197z/b7EyALt0wDQYJKoZIhvcNAQEFBQADggEBAHg7tJEqAEzwj2IwN3ijhCcH
# bxiy3iXcoNSUA6qGTiWfmkADHN3O43nLIWgG2rYytG2/9CwmYzPkSWRtDebDZw73
# BaQ1bHyJFsbpst+y6d0gxnEPzZV03LZc3r03H0N45ni1zSgEIKOq8UvEiCmRDoDR
# EfzdXHZuT14ORUZBbg2w6jiasTraCXEQ/Bx5tIB7rGn0/Zy2DBYr8X9bCT2bW+IW
# yhOBbQAuOA2oKY8s4bL0WqkBrxWcLC9JG9siu8P+eJRRw4axgohd8D20UaF5Mysu
# e7ncIAkTcetqGVvP6KUwVyyJST+5z3/Jvz4iaGNTmr1pdKzFHTx/kuDDvBzYBHUw
# ggTwMIID2KADAgECAhBrJCMKH0FYqKi57MelSWPYMA0GCSqGSIb3DQEBCwUAMH8x
# CzAJBgNVBAYTAlVTMR0wGwYDVQQKExRTeW1hbnRlYyBDb3Jwb3JhdGlvbjEfMB0G
# A1UECxMWU3ltYW50ZWMgVHJ1c3QgTmV0d29yazEwMC4GA1UEAxMnU3ltYW50ZWMg
# Q2xhc3MgMyBTSEEyNTYgQ29kZSBTaWduaW5nIENBMB4XDTE5MDEwMzAwMDAwMFoX
# DTIwMDExNjIzNTk1OVowgYcxCzAJBgNVBAYTAlVTMRYwFAYDVQQIDA1NYXNzYWNo
# dXNldHRzMRAwDgYDVQQHDAdCZWRmb3JkMSYwJAYDVQQKDB1Qcm9ncmVzcyBTb2Z0
# d2FyZSBDb3Jwb3JhdGlvbjEmMCQGA1UEAwwdUHJvZ3Jlc3MgU29mdHdhcmUgQ29y
# cG9yYXRpb24wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDH8eM87I+F
# QZjqVwDOibCNAHo/w3yb6N0fy2ILZO7WUzhMwQx7r6avXL5+WXRaR1d3Ho3VffcH
# nOU1nEStIJSikOOyBjiWAZUDEL1EleJhJ/u6maS5bGZBj+9hpLDeJVqCaccuOdFw
# hianzjkjY4tZtkdCD06qc06E0b28WZmgSNEhCL59mjoBT6k3q5Enps8y0lgDqD4e
# G0dSy5dZe6Ebt3tuWdbad8ZlXHqZha1N44M8/K1W7mv8n6WTkuq1rxq1Evo+DgIg
# FhlooCay6g4kTREHHEoxsT2EcUfk5K23n3mKF8CqeYONbynALUGwUtVtWPIMQM1c
# scLsbTGzzRDFAgMBAAGjggFdMIIBWTAJBgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIH
# gDArBgNVHR8EJDAiMCCgHqAchhpodHRwOi8vc3Yuc3ltY2IuY29tL3N2LmNybDBh
# BgNVHSAEWjBYMFYGBmeBDAEEATBMMCMGCCsGAQUFBwIBFhdodHRwczovL2Quc3lt
# Y2IuY29tL2NwczAlBggrBgEFBQcCAjAZDBdodHRwczovL2Quc3ltY2IuY29tL3Jw
# YTATBgNVHSUEDDAKBggrBgEFBQcDAzBXBggrBgEFBQcBAQRLMEkwHwYIKwYBBQUH
# MAGGE2h0dHA6Ly9zdi5zeW1jZC5jb20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9zdi5z
# eW1jYi5jb20vc3YuY3J0MB8GA1UdIwQYMBaAFJY7U/B5M5evfYPvLivMyreGHnJm
# MB0GA1UdDgQWBBRzSBlxzXKA5a/a8KMj17M/AlhNTDANBgkqhkiG9w0BAQsFAAOC
# AQEAd93vaHApRkX7IAux7UDqU5Sy9J2mOawB4d/Ea7Tn9zc9WQhi5sslfw9peNx5
# nilC+Age2vK+FT/eja5vH/GqzF4flOkZS+02B+/eGF8IIdmBt0Npza02eyZ+JzaR
# kjnLI5/CWZ7Br7j+OK677vcaWY1unqs83prMgoYMPABvczBUeaMlCOZuaXmwdSVR
# nTG4ERuXPoDG0LMq2SmQNGJe/nES5KoWVK2r9KAG0QVkFMVVfQJvnXWXTfsoPZ6r
# gmXaJJNV0gocQ1XN/m9BCqzMcB2ielFkNVdKNuKaYEuzISTEE5nsfXjHdoKV9Og/
# xl19F67BMuK5aKgm0iD2IjXxZTCCBVkwggRBoAMCAQICED141/l2SWCyYX308B7K
# hiowDQYJKoZIhvcNAQELBQAwgcoxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5WZXJp
# U2lnbiwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE6MDgG
# A1UECxMxKGMpIDIwMDYgVmVyaVNpZ24sIEluYy4gLSBGb3IgYXV0aG9yaXplZCB1
# c2Ugb25seTFFMEMGA1UEAxM8VmVyaVNpZ24gQ2xhc3MgMyBQdWJsaWMgUHJpbWFy
# eSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eSAtIEc1MB4XDTEzMTIxMDAwMDAwMFoX
# DTIzMTIwOTIzNTk1OVowfzELMAkGA1UEBhMCVVMxHTAbBgNVBAoTFFN5bWFudGVj
# IENvcnBvcmF0aW9uMR8wHQYDVQQLExZTeW1hbnRlYyBUcnVzdCBOZXR3b3JrMTAw
# LgYDVQQDEydTeW1hbnRlYyBDbGFzcyAzIFNIQTI1NiBDb2RlIFNpZ25pbmcgQ0Ew
# ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCXgx4AFq8ssdIIxNdok1Fg
# HnH24ke021hNI2JqtL9aG1H3ow0Yd2i72DarLyFQ2p7z518nTgvCl8gJcJOp2lwN
# TqQNkaC07BTOkXJULs6j20TpUhs/QTzKSuSqwOg5q1PMIdDMz3+b5sLMWGqCFe49
# Ns8cxZcHJI7xe74xLT1u3LWZQp9LYZVfHHDuF33bi+VhiXjHaBuvEXgamK7EVUdT
# 2bMy1qEORkDFl5KK0VOnmVuFNVfT6pNiYSAKxzB3JBFNYoO2untogjHuZcrf+dWN
# sjXcjCtvanJcYISc8gyUXsBWUgBIzNP4pX3eL9cT5DiohNVGuBOGwhud6lo43Zvb
# AgMBAAGjggGDMIIBfzAvBggrBgEFBQcBAQQjMCEwHwYIKwYBBQUHMAGGE2h0dHA6
# Ly9zMi5zeW1jYi5jb20wEgYDVR0TAQH/BAgwBgEB/wIBADBsBgNVHSAEZTBjMGEG
# C2CGSAGG+EUBBxcDMFIwJgYIKwYBBQUHAgEWGmh0dHA6Ly93d3cuc3ltYXV0aC5j
# b20vY3BzMCgGCCsGAQUFBwICMBwaGmh0dHA6Ly93d3cuc3ltYXV0aC5jb20vcnBh
# MDAGA1UdHwQpMCcwJaAjoCGGH2h0dHA6Ly9zMS5zeW1jYi5jb20vcGNhMy1nNS5j
# cmwwHQYDVR0lBBYwFAYIKwYBBQUHAwIGCCsGAQUFBwMDMA4GA1UdDwEB/wQEAwIB
# BjApBgNVHREEIjAgpB4wHDEaMBgGA1UEAxMRU3ltYW50ZWNQS0ktMS01NjcwHQYD
# VR0OBBYEFJY7U/B5M5evfYPvLivMyreGHnJmMB8GA1UdIwQYMBaAFH/TZafC3ey7
# 8DAJ80M5+gKvMzEzMA0GCSqGSIb3DQEBCwUAA4IBAQAThRoeaak396C9pK9+HWFT
# /p2MXgymdR54FyPd/ewaA1U5+3GVx2Vap44w0kRaYdtwb9ohBcIuc7pJ8dGT/l3J
# zV4D4ImeP3Qe1/c4i6nWz7s1LzNYqJJW0chNO4LmeYQW/CiwsUfzHaI+7ofZpn+k
# VqU/rYQuKd58vKiqoz0EAeq6k6IOUCIpF0yH5DoRX9akJYmbBWsvtMkBTCd7C6wZ
# BSKgYBU/2sn7TUyP+3Jnd/0nlMe6NQ6ISf6N/SivShK9DbOXBd5EDBX6NisD3MFQ
# AfGhEV0U5eK9J0tUviuEXg+mw3QFCu+Xw4kisR93873NQ9TxTKk/tYuEr2Ty0BQh
# MYIERDCCBEACAQEwgZMwfzELMAkGA1UEBhMCVVMxHTAbBgNVBAoTFFN5bWFudGVj
# IENvcnBvcmF0aW9uMR8wHQYDVQQLExZTeW1hbnRlYyBUcnVzdCBOZXR3b3JrMTAw
# LgYDVQQDEydTeW1hbnRlYyBDbGFzcyAzIFNIQTI1NiBDb2RlIFNpZ25pbmcgQ0EC
# EGskIwofQVioqLnsx6VJY9gwCQYFKw4DAhoFAKB4MBgGCisGAQQBgjcCAQwxCjAI
# oAKAAKECgAAwGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcCAQQwHAYKKwYBBAGCNwIB
# CzEOMAwGCisGAQQBgjcCARUwIwYJKoZIhvcNAQkEMRYEFLFsBVn0OHjNVWDuUNt8
# QkH6NALTMA0GCSqGSIb3DQEBAQUABIIBAGZSZ77Uq+aTN+k+54FI1bbKsov7GS6e
# 7qa9YJ2kNObhZGfKOl7ncm6s8xVbQh1rE0msOadjc1ukllhzwA6modF+XDw0FXRv
# b/tOiJPiYbfCsE31ECB75v1R7VFgZeP6o6To7UTjCcbM2ukkSsZp4J22IR0HbwGe
# E0ULfwfIweubao/qrxCt2KbhyzTCQ7KCAUrST40Kfsm86qkG9jykqozmJyU787mr
# 611jjalGdGdQA6B/ohEXYrpJ/Bu9OgGMljirJsezAEvJTqEz/r6ijBxNe0DVywBk
# m9BbDfId215GZNHBIBRoIKBJMPI/N6+oscNpArUciVBvLQHTSGxLJayhggILMIIC
# BwYJKoZIhvcNAQkGMYIB+DCCAfQCAQEwcjBeMQswCQYDVQQGEwJVUzEdMBsGA1UE
# ChMUU3ltYW50ZWMgQ29ycG9yYXRpb24xMDAuBgNVBAMTJ1N5bWFudGVjIFRpbWUg
# U3RhbXBpbmcgU2VydmljZXMgQ0EgLSBHMgIQDs/0OMj+vzVuBNhqmBsaUDAJBgUr
# DgMCGgUAoF0wGAYJKoZIhvcNAQkDMQsGCSqGSIb3DQEHATAcBgkqhkiG9w0BCQUx
# DxcNMTkwNzMxMjEyMTE3WjAjBgkqhkiG9w0BCQQxFgQU9eMluf4MORwgTO8sK2If
# tGQgO6kwDQYJKoZIhvcNAQEBBQAEggEAQoSHY9I7lBJ6fS/Wl6/3mpBf5OAeOdzA
# Yx8TfIY8rB484ECVt4TrgF/GvXOw478IM7/sMcb60FVRfsLJp3JYJXOCQx5lKhts
# z1FUxMQEhh6jRP9sKsMfJ1plUoxj5yW93tYJLYXQJMSPpmaPob+tvQVYFSG9G5lJ
# vWd4kBzAbshLMg41bDmiPy7h7PVMPanfLGwnpGi5MxY1LTsh3bra2kBgfwlbc1tj
# w854xDRhodUCjnHaD6RKQSpPzaFfj8iLuotuSmFdCzrtoGTvGt2wXpLsU3e1NUTc
# f2lGfyyL+H8l4kWf0E/SMU7JrXSYohISQ8KT5jseGMHmVE7xv941tw==
# SIG # End signature block

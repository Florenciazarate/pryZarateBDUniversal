# Script para descargar e insertar System.Data.SQLite en el proyecto (Windows PowerShell)
# Uso: Ejecutar desde la carpeta del proyecto (donde está el .csproj):
#   .\add_sqlite_nuget.ps1

param()

$csprojPath = "pryZarateBDUniversal.csproj"
$packageId = "System.Data.SQLite.Core"
$packageVersion = "1.0.115"  # Puedes cambiar la versión si lo deseas
$packagesDir = "packages"

Write-Host "Buscando archivo de proyecto: $csprojPath"
if (-not (Test-Path $csprojPath)) {
    Write-Error "No se encontró '$csprojPath' en el directorio actual. Abre PowerShell en la carpeta del proyecto que contiene el .csproj y vuelve a ejecutar.";
    exit 1
}

# Descargar nuget.exe si no existe
$nugetExe = "$PWD\nuget.exe"
if (-not (Test-Path $nugetExe)) {
    Write-Host "Descargando nuget.exe..."
    $nugetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
    Invoke-WebRequest -Uri $nugetUrl -OutFile $nugetExe
}

# Instalar el paquete en la carpeta packages
$packageFolder = "$packagesDir\$packageId.$packageVersion"
if (-not (Test-Path $packageFolder)) {
    Write-Host "Instalando paquete $packageId $packageVersion en $packagesDir..."
    & $nugetExe install $packageId -Version $packageVersion -OutputDirectory $packagesDir -NonInteractive | Out-Null
} else {
    Write-Host "Paquete ya instalado en $packageFolder"
}

# Buscar DLL en la carpeta del paquete (puede variar la ruta según la versión)
# Intentamos varias rutas comunes
$possiblePaths = @(
    "$packageFolder\lib\net46\System.Data.SQLite.dll",
    "$packageFolder\lib\net45\System.Data.SQLite.dll",
    "$packageFolder\lib\net40\System.Data.SQLite.dll",
    "$packageFolder\lib\netstandard2.0\System.Data.SQLite.dll"
)

$dllPath = $possiblePaths | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $dllPath) {
    Write-Error "No se encontró System.Data.SQLite.dll en las rutas buscadas dentro del paquete. Revisa la estructura en $packageFolder.";
    exit 1
}

# Ruta relativa desde el .csproj al DLL
$relativeHintPath = Split-Path -Parent $dllPath -Resolve | ForEach-Object { (Resolve-Path $_).Path }
$relativeHintPath = [IO.Path]::Combine("$packagesDir", "$packageId.$packageVersion", "lib", (Split-Path $dllPath -Leaf) -replace 'System.Data.SQLite.dll','')
# Mejor construir hint path relativo simple
$hintPath = "..\\$dllPath" -replace '/', '\\'
$hintPath = (Get-Item $dllPath).FullName
$hintPath = (Resolve-Path $dllPath).Path

# Leer csproj
[xml]$xml = Get-Content $csprojPath

$ns = $xml.Project.GetNamespaceOfPrefix("")

# Comprobar si ya existe referencia
$exists = $xml.Project.ItemGroup.Reference | Where-Object { $_.Include -like "System.Data.SQLite*" }
if ($exists) {
    Write-Host "El proyecto ya contiene una referencia a System.Data.SQLite. No se harán cambios.";
    exit 0
}

# Crear nuevo nodo Reference
$projNode = $xml.Project
$itemGroup = $xml.CreateElement("ItemGroup", $ns)
$reference = $xml.CreateElement("Reference", $ns)
$reference.SetAttribute("Include", "System.Data.SQLite")

$hint = $xml.CreateElement("HintPath", $ns)
$hint.InnerText = $hintPath

$private = $xml.CreateElement("Private", $ns)
$private.InnerText = "True"

$reference.AppendChild($hint) | Out-Null
$reference.AppendChild($private) | Out-Null
$itemGroup.AppendChild($reference) | Out-Null
$projNode.AppendChild($itemGroup) | Out-Null

# Guardar csproj de respaldo y luego sobrescribir
Copy-Item $csprojPath "$csprojPath.bak" -Force
$xml.Save($csprojPath)

Write-Host "Referencia agregada al proyecto. Restaurar paquetes en Visual Studio o compilar el proyecto para que se actualicen las referencias nativas."
Write-Host "Si usas plataforma x86/x64, asegúrate de compilar con la plataforma correcta y que 'SQLite.Interop.dll' esté presente en la salida."
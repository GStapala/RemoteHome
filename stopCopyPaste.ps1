$SourceFile = Dir 'D:\Visual Studio Projects\RemoteHomeAndroid\RemoteHomeServer\bin\Debug\netcoreapp1.0\RemoteHomeServer.dll'
$DestinationFile = 'D:\Visual Studio Projects\RemoteHomeAndroid\RemoteHomeServer\bin\Release\PublishOutput\RemoteHomeServer.dll'

Import-Module WebAdministration

Stop-WebSite 'Default Web Site'
copy-Item $sourcefile $DestinationFile
Start-WebSite 'Default Web Site'

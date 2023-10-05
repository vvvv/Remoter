#define MyAppName "Remoter"
#define MyAppVersion "2.0"
#define MyAppPublisher "vvvv"
#define MyAppURL "https://github.com/vvvv/Remoter"


[Setup]
;signtool.exe sign /f CERTFILE /tr http://timestamp.sectigo.com /td SHA256 /p PASS $p
SignTool=mssign $f
AppId={{5FD1B82F-5BF0-4C1B-B9D3-F6F48C50D515}
AppName={#MyAppName} {#MyAppVersion}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
OutputBaseFilename=Remoter {#MyAppVersion} installer
DefaultDirName={commonpf64}\Remoter
DefaultGroupName=Remoter
Uninstallable=yes
Compression=lzma2
OutputDir=.
ArchitecturesAllowed=x64
WizardStyle=classic
PrivilegesRequired=admin

[Run]
Filename: {app}\{cm:AppName}.exe; Description: {cm:LaunchProgram,{cm:AppName}}; Flags: nowait postinstall skipifsilent

[CustomMessages]
AppName=Remoter
LaunchProgram=Start Remoter after finishing installation 


[Files]
Source: "Export\Remoter\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
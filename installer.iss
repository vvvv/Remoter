#define MyAppName "Remoter"
#define MyAppPublisher "vvvv"
#define MyExportPath "Export\Remoter"
#define MyAppURL "https://github.com/vvvv/Remoter"

#ifndef Version
#define Version "2.0"
#endif


[Setup]
;signtool.exe sign /f CERTFILE /tr http://timestamp.sectigo.com /td SHA256 /p PASS $p
SignTool=mssign $f
AppId={{5FD1B82F-5BF0-4C1B-B9D3-F6F48C50D515}
AppVersion={#Version}
AppName={#MyAppName} {#Version}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
OutputBaseFilename=Remoter_{#Version}-installer
DefaultDirName={commonpf64}\Remoter
DefaultGroupName=Remoter
Uninstallable=yes
UninstallDisplayIcon={app}\Remoter.exe
Compression=lzma2
OutputDir=.
ArchitecturesAllowed=x64
WizardStyle=classic
PrivilegesRequired=admin
SetupIconFile={#MyExportPath}\Assets\remoter.ico

[Run]
Filename: {app}\{cm:AppName}.exe; Description: {cm:LaunchProgram,{cm:AppName}}; Flags: nowait postinstall skipifsilent

[CustomMessages]
AppName=Remoter
LaunchProgram=Start Remoter after finishing installation 


[Files]
Source: {#MyExportPath}\*; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\Remoter"; Filename: "{app}\Remoter.exe"
;------------------------------------------------------------------------------
;   ���������� ��������� ���������
;------------------------------------------------------------------------------
; ��� ����������
#define   Name       "Library cards"
; ������ ����������
#define   Version    "0.9.5"
; �����-�����������
#define   Publisher  "Dmitriy Mekh"
; ���� ����� ������������
#define   URL        "https://vk.com/evilcruel@"
; ��� ������������ ������
#define   ExeName    "LibraryCards.exe"
;------------------------------------------------------------------------------
;   ��������� ���������
;------------------------------------------------------------------------------
[Setup]
; ���������� ������������� ����������, 
;��������������� ����� Tools -> Generate GUID
AppId={{DF71B0A6-DD1A-4601-A360-2FCB2BA4E5AF}

; ������ ����������, ������������ ��� ���������
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; ���� ��������� ��-���������
DefaultDirName={pf}\{#Name}
; ��� ������ � ���� "����"
DefaultGroupName={#Name}

; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir=..\Library cards Setup
OutputBaseFileName=LibraryCards-setup

; ���� ������
SetupIconFile=ico.ico

; ��������� ������
Compression=lzma
SolidCompression=yes

;�������� ����������
ChangesAssociations = yes
;------------------------------------------------------------------------------
;   ������������� ����� ��� �������� ���������
;------------------------------------------------------------------------------
[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl";
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl";
;------------------------------------------------------------------------------
;   ����������� - ��������� ������, ������� ���� ��������� ��� ���������
;------------------------------------------------------------------------------
[Tasks]
; �������� ������ �� ������� �����
Name: "LibraryCards"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: associate; Description: "&Associate files"; GroupDescription: "Other tasks:"; Flags: unchecked
;------------------------------------------------------------------------------
;   �����, ������� ���� �������� � ����� �����������
;------------------------------------------------------------------------------
[Files]

; ����������� ����
Source: "..\Library Cards\WindowsFormsApp1\bin\Release\LibraryCardsTable.exe"; DestDir: "{app}"; Flags: ignoreversion

; ������������� �������
Source: "..\Library Cards\WindowsFormsApp1\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; .NET Framework 4.0
Source: "dotNetFx40_Full_x86_x64.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected
;------------------------------------------------------------------------------
;   ��������� �����������, ��� �� ������ ����� ������
;------------------------------------------------------------------------------ 
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; IconFilename: "{app}\ico.ico"
;------------------------------------------------------------------------------
;   ������ ���� ���������� �� ���������� �����
;------------------------------------------------------------------------------
[Code]
#include "dotnet.pas"

[Run]
;------------------------------------------------------------------------------
;   ������ ������� ����� �����������
;------------------------------------------------------------------------------
Filename: {tmp}\dotNetFx40_Full_x86_x64.exe; Parameters: "/q:a /c:""install /l /q"""; Check: not IsRequiredDotNetDetected; StatusMsg: Microsoft Framework 4.0 is installed. Please wait...

[Registry]

Root: HKCR; Subkey: ".cardDB";                             ValueData: "{#Name}";          Flags: uninsdeletevalue; ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#Name}";                     ValueData: "Program {#Name}";  Flags: uninsdeletekey;   ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#Name}\DefaultIcon";             ValueData: "{app}\{#Name},0";               ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#Name}\shell\open\command";  ValueData: """{app}\{#Name}"" ""%1""";  ValueType: string;  ValueName: ""
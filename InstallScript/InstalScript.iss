;------------------------------------------------------------------------------
;   Определяем некоторые константы
;------------------------------------------------------------------------------
; Имя приложения
#define   Name       "Library cards"
; Версия приложения
#define   Version    "0.9.5"
; Фирма-разработчик
#define   Publisher  "Dmitriy Mekh"
; Сафт фирмы разработчика
#define   URL        "https://vk.com/evilcruel@"
; Имя исполняемого модуля
#define   ExeName    "LibraryCards.exe"
;------------------------------------------------------------------------------
;   Параметры установки
;------------------------------------------------------------------------------
[Setup]
; Уникальный идентификатор приложения, 
;сгенерированный через Tools -> Generate GUID
AppId={{DF71B0A6-DD1A-4601-A360-2FCB2BA4E5AF}

; Прочая информация, отображаемая при установке
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; Путь установки по-умолчанию
DefaultDirName={pf}\{#Name}
; Имя группы в меню "Пуск"
DefaultGroupName={#Name}

; Каталог, куда будет записан собранный setup и имя исполняемого файла
OutputDir=..\Library cards Setup
OutputBaseFileName=LibraryCards-setup

; Файл иконки
SetupIconFile=ico.ico

; Параметры сжатия
Compression=lzma
SolidCompression=yes

;Изменить ассоциации
ChangesAssociations = yes
;------------------------------------------------------------------------------
;   Устанавливаем языки для процесса установки
;------------------------------------------------------------------------------
[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl";
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl";
;------------------------------------------------------------------------------
;   Опционально - некоторые задачи, которые надо выполнить при установке
;------------------------------------------------------------------------------
[Tasks]
; Создание иконки на рабочем столе
Name: "LibraryCards"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: associate; Description: "&Associate files"; GroupDescription: "Other tasks:"; Flags: unchecked
;------------------------------------------------------------------------------
;   Файлы, которые надо включить в пакет установщика
;------------------------------------------------------------------------------
[Files]

; Исполняемый файл
Source: "..\Library Cards\WindowsFormsApp1\bin\Release\LibraryCardsTable.exe"; DestDir: "{app}"; Flags: ignoreversion

; Прилагающиеся ресурсы
Source: "..\Library Cards\WindowsFormsApp1\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; .NET Framework 4.0
Source: "dotNetFx40_Full_x86_x64.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected
;------------------------------------------------------------------------------
;   Указываем установщику, где он должен взять иконки
;------------------------------------------------------------------------------ 
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; IconFilename: "{app}\ico.ico"
;------------------------------------------------------------------------------
;   Секция кода включенная из отдельного файла
;------------------------------------------------------------------------------
[Code]
#include "dotnet.pas"

[Run]
;------------------------------------------------------------------------------
;   Секция запуска после инсталляции
;------------------------------------------------------------------------------
Filename: {tmp}\dotNetFx40_Full_x86_x64.exe; Parameters: "/q:a /c:""install /l /q"""; Check: not IsRequiredDotNetDetected; StatusMsg: Microsoft Framework 4.0 is installed. Please wait...

[Registry]

Root: HKCR; Subkey: ".cardDB";                             ValueData: "{#Name}";          Flags: uninsdeletevalue; ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#Name}";                     ValueData: "Program {#Name}";  Flags: uninsdeletekey;   ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#Name}\DefaultIcon";             ValueData: "{app}\{#Name},0";               ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#Name}\shell\open\command";  ValueData: """{app}\{#Name}"" ""%1""";  ValueType: string;  ValueName: ""
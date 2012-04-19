ECHO OFF
SET ProgFiles=%ProgramFiles%
SET ProgFilesx86=%ProgramFiles(x86)%
IF "%PROCESSOR_ARCHITECTURE%"=="x86" Set ProgFilesx86=%ProgramFiles%
@Echo Progfiles location is %ProgFiles% 
@Echo Progfiles_x86 location is %ProgFilesx86% 
@Echo Copying required VSTO Files 
@Echo VSTO/VSTA 
xcopy "%ProgFiles%\Reference Assemblies\Microsoft\VSTA30" "Payload\Program Files\Reference Assemblies\Microsoft\VSTA30" /i /S 
xcopy "%ProgFiles%\Reference Assemblies\Microsoft\VSTO40" "Payload\Program Files\Reference Assemblies\Microsoft\VSTO40" /i /S 
@Echo BootStrapper Packages 
xcopy "%ProgFilesx86%\Microsoft SDKs\Windows\v7.0A\Bootstrapper\Packages\Office2007PIARedist" "Payload\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bootstrapper\Packages\Office2007PIARedist" /i /S 
xcopy "%ProgFilesx86%\Microsoft SDKs\Windows\v7.0A\Bootstrapper\Packages\VSTOR40" "Payload\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bootstrapper\Packages\VSTOR40" /i /S 
@Echo PIA References 
xcopy "%ProgFilesx86%\Microsoft Visual Studio 10.0\Visual Studio Tools for Office" "Payload\Program Files (x86)\Microsoft Visual Studio 10.0\Visual Studio Tools for Office" /i /S 
@Echo MSBuild Targets 
xcopy "%ProgFilesx86%\MSBuild\Microsoft\VisualStudio\v10.0\OfficeTools" "Payload\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v10.0\OfficeTools" /i /S 
@Echo Copy individual Targets 
copy "%ProgFiles%\MSBuild\Microsoft.VisualStudio.OfficeTools.targets" "Payload\Program Files (x86)\MSBuild\Microsoft.VisualStudio.OfficeTools.targets" 
@Echo GACUtil 
xcopy "%ProgFilesx86%\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\GACUtil.*" "Payload\GAC\" /i 
xcopy "%ProgFilesx86%\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\1033\gacutlrc.dll" "Payload\GAC\1033\" /i 
@Echo Build Tasks 
xcopy "%windir%\Microsoft.NET\assembly\GAC_MSIL\Microsoft.VisualStudio.Tools.Applications.BuildTasks\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualStudio.Tools.Applications.BuildTasks.dll" "Payload\GAC\" 
xcopy "%windir%\Microsoft.NET\assembly\GAC_MSIL\Microsoft.VisualStudio.Tools.Office.BuildTasks\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualStudio.Tools.Office.BuildTasks.dll" "Payload\GAC\" 
@Echo VSTO Install PayLoad Created 
ECHO ON
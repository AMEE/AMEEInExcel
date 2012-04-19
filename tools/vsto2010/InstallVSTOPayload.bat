ECHO OFF 
SET ProgFiles=%ProgramFiles%
SET ProgFilesx86=%ProgramFiles(x86)%
IF "%PROCESSOR_ARCHITECTURE%"=="x86" Set ProgFilesx86=%ProgramFiles% 
@Echo Progfiles location is %ProgFiles% 
@Echo Progfiles_x86 location is %ProgFilesx86% 
@Echo Copying required VSTO files 
xcopy "Payload\Program Files (x86)" "%ProgFilesx86%" /E 
xcopy "Payload\Program Files" "%ProgFiles%" /E 
@Echo Finished copying required VSTO Files 
@Echo Creating required VSTO registry Keys 
regedit /s "v4.0_keys.reg" 
regedit /s "v2.0_keys.reg" 
@Echo Finished creating registry Keys 
@Echo Installing Build Tasks to CLR 4.0 GAC 
PayLoad\GAC\GacUtil /i "PayLoad\GAC\Microsoft.VisualStudio.Tools.Applications.BuildTasks.dll" 
PayLoad\GAC\GacUtil /i "PayLoad\GAC\Microsoft.VisualStudio.Tools.Office.BuildTasks.dll" 
@Echo Finished installing Build Tasks to CLR 4.0 GAC 
@Echo VSTO Install Complete 
ECHO ON
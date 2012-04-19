# AMEE in Excel
tightly integrates AMEE data into Microsoft Excel

## Getting started as a user

Requirements:
* Excel 2010
* Windows 7 (might work in Windows XP)

1.  Install the *AMEE in Excel* adding - http://code.labs.cityindex.com/AMEEInExcel/_setup/setup.exe
1.  Use the AMEE_* functions to pull data & calculations from AMEE
1.  Watch [this video overview](https://cityindex.viewscreencasts.com/7313b30ed11a47ffbe2fc3426a5114ab)

## Getting started as a developer

Requirements:
* Excel 2010
* Windows 7
* Visual Studio 2010

1.  Clone this repo ```git clone --recursive https://github.com/mrdavidlaing/AMEEInExcel.git ```
1.  Open src/AMEEInExcel.sln in VS2010
1.  Run the command line build - ```msbuild src/build.xml```

## Related

1.  [AMEE.CS](https://github.com/cityindex/CIAPI.CS/blob/master/src/AMEE/AMEEClient.CS.Tests/DefraFixture.cs#L72) - .NET client library for AMEEConnect
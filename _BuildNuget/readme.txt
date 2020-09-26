Etagair nuget publication readme.txt:

need to install the package: Nuget.CommandLine into the solution. 
(Nuget.Build?)


================================================================================
Folders and files descriptions:

_BuildNuget\
To build the nuget package of the application.

Model\
The model of files and folders.

Built\  
	-> Ne sert plus.


================================================================================
Generate a new nuget package, Process:


-2/ Update the nuget text file descriptor:
(in Visual Studio)
_BuildNuget\Model\
	Pierlam.ExpressionEval.nuspec

-3/ Set the new version number to the library: 
	Pierlam.ExpressionEval
   
-4/ Build them in VS, in RELEASE Mode!!
  regenerer!
  
-5/ Copy the dll libraries 
	from: ExpressionEvalSol\Pierlam.ExpressionEval\bin\Release\
		netstandard2.0\ and also net45\

	into the path:
		Model\lib\
			netstandard2.0\ and also net45\

-6/ Check the version of the library.

-7/ Generate the package:
(inside Visual Studio, in the package manager console)
	>cd _BuildNuget\Model
	>nuget pack

the result:
	inside: Model\
		Pierlam.ExpressionEval.x.x.x.x.nupkg


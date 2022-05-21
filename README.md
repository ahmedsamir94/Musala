# Musala

You have to change the driver paths in Configuration=>Environment.config file
You have to change the Attached sheet s in Configuration=>Environment.config file
You have to change the Report folder paths in Configuration=>Environment.config file
You have to change the FileName paths in Nlogt.config file which is "C:\Users\ahmed.samir\source\repos\Musala\Logs${MusalaFrameWork}\Debug.log" to check the logs on it.

You have to uncomment line "//[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)]" in Tests=>CompanyTest.cs if you need to run tests in parallel



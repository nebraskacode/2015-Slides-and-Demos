Imports HibernatingRhinos.Profiler.Appender.EntityFramework

<assembly: WebActivatorEx.PreApplicationStartMethod(GetType(Global.MovieFanatic.Web.App_Start.EntityFrameworkProfilerBootstrapper), "PreStart")>
Namespace App_Start
	Public Class EntityFrameworkProfilerBootstrapper
		Public Shared Sub PreStart()
			' Initialize the profiler
			EntityFrameworkProfiler.Initialize()

			' You can also use the profiler in an offline manner.
			' This will generate a file with a snapshot of all the EntityFramework activity in the application,
			' which you can use for later analysis by loading the file into the profiler.
			' Dim FileName as String = @"c:\profiler-log";
			' EntityFrameworkProfiler.InitializeOfflineProfiling(FileName)

			' You can use the following for production profiling.
			' EntityFrameworkProfiler.InitializeForProduction(11234, "A strong password like: ze38r/b2ulve2HLQB8NK5AYig");
		End Sub
	End Class
End Namespace


using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;

namespace Net.Spec.Logging.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var strBuilder = new StringBuilder();
			var textWriter = new StringWriter(strBuilder);
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.Enrich.FromLogContext()				
				.WriteTo.TextWriter(textWriter, outputTemplate: "[{Level:3U}][{MyVal}]{Message}{NewLine}{Exception}")
				.CreateLogger();

			System.Specification.Logging.ILogFactory logFactory = new Net.Spec.Logging.Adapters.Serilog.LogFactory();
			System.Specification.Logging.ILogger logger = logFactory.CreateLoggerFor<UnitTest1>();


			logger.Information("Xyz");
			
			using (logFactory.CreateLogContext(new System.Specification.Logging.ContextInfo("MyVal", 123))) {
				logger.Information("Pi is 3,14");
			}

			var actual = strBuilder.ToString();
			Assert.IsTrue(actual.Contains("Xyz"));
			Assert.IsTrue(actual.Contains("[123]Pi"));
		}
	}
}

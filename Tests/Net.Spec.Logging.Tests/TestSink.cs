using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Text;

namespace Net.Spec.Logging.Tests
{
	public class TestSink : ILogEventSink
	{
		private StringBuilder _strBldr;
		public TestSink(StringBuilder strBldr)
		{
			_strBldr = strBldr;
		}

		public void Emit(LogEvent logEvent)
		{
			_strBldr.AppendLine(logEvent.RenderMessage());
		}
	}

	public static class TestSinkExtensions
	{
		public static LoggerConfiguration TestSink(
			this LoggerSinkConfiguration loggerConfiguration,
			StringBuilder strBld,
			IFormatProvider formatProvider = null)
		{
			return loggerConfiguration.Sink(new TestSink(strBld));
		}
	}
}

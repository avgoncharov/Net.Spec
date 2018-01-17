using System;
using System.Specification.Logging;

namespace Net.Spec.Logging.Adapters.Serilog
{
	internal sealed class LogAdapter : ILogger
	{
		private readonly global::Serilog.ILogger _logger;

		internal LogAdapter(global::Serilog.ILogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public void Debug(string message)
		{
			_logger.Debug(message);
		}

		public void Information(string message)
		{
			_logger.Information(message);
		}

		public void Warning(string message)
		{
			_logger.Warning(message);
		}

		public void Error(string message)
		{
			_logger.Error(message);
		}

		public void Error(Exception exception)
		{
			_logger.Error(exception.ToString());
		}

		public void Fatal(string message)
		{
			_logger.Fatal(message);
		}

		public void Fatal(Exception exception)
		{
			_logger.Fatal(exception.ToString());
		}
	}
}

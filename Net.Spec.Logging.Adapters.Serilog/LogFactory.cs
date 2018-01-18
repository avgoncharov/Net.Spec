using System;
using System.Linq;
using System.Specification.Logging;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Core.Enrichers;
using ILogger = System.Specification.Logging.ILogger;

namespace Net.Spec.Logging.Adapters.Serilog
{
	public sealed class LogFactory: ILogFactory
	{
		public ILogger CreateLoggerFor<T>()
		{
			return new LogAdapter(Log.Logger.ForContext<T>());
		}

		public ILogger CreateLoggerForContext(ContextInfo contextInfo)
		{
			return new LogAdapter(Log.Logger.ForContext(Convert(new []{contextInfo})));
		}

		public ILogger CreateLoggerForContext(params ContextInfo[] contextInfos)
		{
			return new LogAdapter(Log.Logger.ForContext(Convert(contextInfos)));
		}

		public IDisposable CreateLogContext(ContextInfo contextInfo)
		{
			return LogContext.Push(Convert(new [] {contextInfo}));
		}

		public IDisposable CreateLogContext(params ContextInfo[] contextInfos)
		{
			return LogContext.Push(Convert(contextInfos));
		}

		private static ILogEventEnricher[] Convert(ContextInfo[] contextInfo)
		{
			if (contextInfo == null || !contextInfo.Any())
			{
				return Array.Empty<ILogEventEnricher>();
			}

			return contextInfo.Select(itr => new PropertyEnricher(itr.Name, itr.Value) as ILogEventEnricher).ToArray();
		}
	}
}

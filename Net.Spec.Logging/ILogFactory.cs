namespace System.Specification.Logging
{
	/// <summary>
	/// Log factory interface.
	/// </summary>
	public interface ILogFactory
	{
		/// <summary>
		/// Create new logger for type T.
		/// </summary>
		/// <typeparam name="T">Type which logger is creating for.</typeparam>
		/// <returns></returns>
		ILogger CreateLoggerFor<T>();

		/// <summary>
		/// Create new logger for context.
		/// </summary>
		/// <param name="contextInfo">Information which characterize context.</param>
		/// <returns></returns>
		ILogger CreateLoggerForContext(ContextInfo contextInfo);

		/// <summary>
		/// Create new logger for context.
		/// </summary>
		/// <param name="contextInfos">Information which characterize context.</param>
		/// <returns></returns>
		ILogger CreateLoggerForContext(params ContextInfo[] contextInfos);

		/// <summary>
		/// Create new log context.
		/// </summary>
		/// <param name="contextInfo">Information which characterize context.</param>
		/// <returns>New log context.</returns>
		IDisposable CreateLogContext(ContextInfo contextInfo);

		/// <summary>
		/// Create new log context.
		/// </summary>
		/// <param name="contextInfos">Information which characterize context.</param>
		/// <returns>New log context.</returns>
		IDisposable CreateLogContext(params ContextInfo[] contextInfos);
	}
}

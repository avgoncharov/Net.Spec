namespace System.Specification.Logging
{
	public class ContextInfo
	{
		public ContextInfo(string name, object value)
		{
			Name = name;
			Value = value;
		}

		public string Name { get; }
		public object Value { get; }
	}
}

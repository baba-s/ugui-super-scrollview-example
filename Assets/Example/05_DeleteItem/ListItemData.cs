namespace Example_DeleteItem
{
	public sealed class ListItemData
	{
		private readonly string m_name;

		public string Name { get { return m_name; } }

		public bool IsChecked { get; set; }

		public ListItemData( string name )
		{
			m_name = name;
		}
	}
}
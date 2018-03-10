namespace Example_ChangeItemHeight
{
	public sealed class ListItemData
	{
		private readonly string m_name;

		public string Name { get { return m_name; } }

		public bool IsExpanded { get; set; }

		public ListItemData( string name )
		{
			m_name = name;
		}
	}
}
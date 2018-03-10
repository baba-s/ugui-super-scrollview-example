namespace Example_Chat
{
	public sealed class CharaData
	{
		private readonly int	m_id				;
		private readonly string	m_iconSpriteName	;

		public int		Id				{ get { return m_id				; } }
		public string	IconSpriteName	{ get { return m_iconSpriteName	; } }

		public CharaData
		(
			int		id				,
			string	iconSpriteName
		)
		{
			m_id				= id				;
			m_iconSpriteName	= iconSpriteName	;
		}
	}
}
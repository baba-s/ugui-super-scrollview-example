namespace Example_Chat
{
	public sealed class ListItemData
	{
		private readonly CharaData	m_charaData			;
		private readonly string		m_message			;
		private readonly string		m_imageSpriteName	;
		private readonly bool		m_isMessage			;

		public CharaData	CharaData		{ get { return m_charaData			; } }
		public string		Message			{ get { return m_message			; } }
		public string		ImageSpriteName	{ get { return m_imageSpriteName	; } }
		public bool			IsMessage		{ get { return m_isMessage			; } }

		public ListItemData
		(
			CharaData	charaData		,
			string		message			,
			string		imageSpriteName
		)
		{
			m_charaData			= charaData			;
			m_message			= message			;
			m_imageSpriteName	= imageSpriteName	;
			m_isMessage			= !string.IsNullOrEmpty( message );
		}
	}
}
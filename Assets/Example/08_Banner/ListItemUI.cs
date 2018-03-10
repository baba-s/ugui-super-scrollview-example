using UnityEngine;
using UnityEngine.UI;

namespace Example_Banner
{
	[DisallowMultipleComponent]
	public sealed class ListItemUI : MonoBehaviour
	{
		[SerializeField] private Button	m_buttonUI	= null;
		[SerializeField] private Text	m_textUI	= null;

		private ListItemData m_data;

		public int Index { get; private set; }

		private void Awake()
		{
			m_buttonUI.onClick.AddListener( () => print( m_data.Name ) );
		}

		public void SetDisp( int index, ListItemData data )
		{
			Index = index;

			m_data = data;

			m_textUI.text = data.Name;
		}
	}
}
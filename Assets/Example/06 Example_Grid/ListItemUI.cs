using UnityEngine;
using UnityEngine.UI;

namespace Example_Grid
{
	[DisallowMultipleComponent]
	public sealed class ListItemUI : MonoBehaviour
	{
		[SerializeField] private Button	m_buttonUI	= null;
		[SerializeField] private Text	m_textUI	= null;

		private ListItemData m_data;

		private void Awake()
		{
			m_buttonUI.onClick.AddListener( () => print( m_data.Name ) );
		}

		public void SetDisp( ListItemData data )
		{
			m_data = data;

			m_textUI.text = data.Name;
		}
	}
}
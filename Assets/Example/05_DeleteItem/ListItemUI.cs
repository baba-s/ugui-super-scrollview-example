using UnityEngine;
using UnityEngine.UI;

namespace Example_DeleteItem
{
	[DisallowMultipleComponent]
	public sealed class ListItemUI : MonoBehaviour
	{
		[SerializeField] private Button	m_buttonUI	= null;
		[SerializeField] private Text	m_textUI	= null;
		[SerializeField] private Toggle	m_toggleUI	= null;

		private ListItemData m_data;

		private void Awake()
		{
			m_buttonUI.onClick.AddListener( () => print( m_data.Name ) );
			m_toggleUI.onValueChanged.AddListener( isChecked =>
			{
				m_data.IsChecked = isChecked;
			} );
		}

		public void SetDisp( ListItemData data )
		{
			m_data = data;

			m_textUI.text = data.Name;
			m_toggleUI.isOn = data.IsChecked;
		}
	}
}
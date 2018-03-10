using UnityEngine;
using UnityEngine.UI;

namespace Example_Vertical
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

		public void SetScale( float scale )
		{
			m_buttonUI.GetComponent<CanvasGroup>().alpha = scale;
			m_buttonUI.transform.localScale = new Vector3( scale, scale, 1 );
		}
	}
}
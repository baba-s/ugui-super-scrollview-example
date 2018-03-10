using SuperScrollView;
using UnityEngine;
using UnityEngine.UI;

namespace Example_ChangeItemHeight
{
	[DisallowMultipleComponent]
	public sealed class ListItemUI : MonoBehaviour
	{
		[SerializeField] private RectTransform	m_transform	= null;
		[SerializeField] private Button			m_buttonUI	= null;
		[SerializeField] private Text			m_textUI	= null;

		private ListItemData m_data;

		private void Awake()
		{
			m_buttonUI.onClick.AddListener( () =>
			{
				SetIsExpanded( !m_data.IsExpanded );
			} );
		}

		public void SetDisp( ListItemData data )
		{
			m_data = data;

			m_textUI.text = data.Name;

			SetIsExpanded( data.IsExpanded );
		}

		private void SetIsExpanded( bool isExpanded )
		{
			m_data.IsExpanded = isExpanded;

			var size = m_transform.sizeDelta;
			size.y = isExpanded ? 340 : 170;
			m_transform.sizeDelta = size;

            var item = gameObject.GetComponent<LoopListViewItem2>();
            item.ParentListView.OnItemSizeChanged( item.ItemIndex );
		}
	}
}
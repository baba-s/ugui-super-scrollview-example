using SuperScrollView;
using System.Linq;
using UnityEngine;

namespace Example_DeleteItem
{
	[DisallowMultipleComponent]
	public sealed class Example : MonoBehaviour
	{
		[SerializeField] private LoopListView2	m_view		= null;
		[SerializeField] private ListItemUI		m_original	= null;

		private ListItemData[] m_list;

		private void Start()
		{
			m_list = Enumerable
				.Range( 0, 1000 )
				.Select( c => ( c + 1 ).ToString( "0000" ) )
				.Select( c => new ListItemData( c ) )
				.ToArray()
			;

			m_view.InitListView( m_list.Length, OnUpdate );
		}

		private LoopListViewItem2 OnUpdate( LoopListView2 view, int index )
		{
			if ( index < 0 || m_list.Length <= index ) return null;

			var data	= m_list[ index ];
			var itemObj	= view.NewListViewItem( m_original.name );
			var itemUI	= itemObj.GetComponent<ListItemUI>();

			itemUI.SetDisp( data );

			return itemObj;
		}

		private void OnGUI()
		{
			if ( GUILayout.Button( "すべて選択" ) )
			{
				foreach ( var n in m_list )
				{
					n.IsChecked = true;
				}
				m_view.RefreshAllShownItem();
			}
			if ( GUILayout.Button( "選択解除" ) )
			{
				foreach ( var n in m_list )
				{
					n.IsChecked = false;
				}
				m_view.RefreshAllShownItem();
			}
			if ( GUILayout.Button( "削除" ) )
			{
				if ( !m_list.Any( c => c.IsChecked ) )
				{
					return;
				}

				m_list = m_list
					.Where( c => !c.IsChecked )
					.ToArray()
				;

				m_view.SetListItemCount( m_list.Length, false );
				m_view.RefreshAllShownItem();
			}
		}
	}
}
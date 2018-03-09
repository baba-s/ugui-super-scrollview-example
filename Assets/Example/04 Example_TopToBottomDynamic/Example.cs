using SuperScrollView;
using System.Linq;
using UnityEngine;

namespace Example_TopToBottomDynamic
{
	[DisallowMultipleComponent]
	public sealed class Example : MonoBehaviour
	{
		[SerializeField] private LoopListView2	m_view		= null;
		[SerializeField] private ListItemUI		m_original	= null;

		private ListItemData[] m_list;

		private string m_setCount		= "0";
		private string m_addCount		= "0";
		private string m_jumpToIndex	= "0";

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
			m_setCount = GUILayout.TextField( m_setCount );
			int setCount = 0;
			int.TryParse( m_setCount, out setCount );
			if ( GUILayout.Button( "項目数設定" ) )
			{
				m_view.SetListItemCount( setCount, false );
			}

			m_addCount = GUILayout.TextField( m_addCount );
			int addCount = 0;
			int.TryParse( m_addCount, out addCount );
			if ( GUILayout.Button( "項目数追加" ) )
			{
				int count = m_view.ItemTotalCount + addCount;
				m_view.SetListItemCount( count, false );
			}

			m_jumpToIndex = GUILayout.TextField( m_jumpToIndex );
			int jumpToIndex = 0;
			int.TryParse( m_jumpToIndex, out jumpToIndex );
			if ( GUILayout.Button( "特定の項目にジャンプ" ) )
			{
				m_view.MovePanelToItemIndex( jumpToIndex, 0 );
			}

			if ( GUILayout.Button( "位置リセット" ) )
			{
				m_view.MovePanelToItemIndex( 0, 0 );
			}
		}
	}
}
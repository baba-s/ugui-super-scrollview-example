using SuperScrollView;
using System.Linq;
using UnityEngine;

namespace Example_ChangeItemHeight
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
	}
}
using SuperScrollView;
using System.Linq;
using UnityEngine;

namespace Example_PageView
{
	[DisallowMultipleComponent]
	public sealed class Example : MonoBehaviour
	{
		[SerializeField] private LoopListView2	m_view		= null;
		[SerializeField] private GameObject		m_original	= null;
		[SerializeField] private DotUI[]		m_dotUIList	= null;

		private ListItemData[] m_list;

		private void Start()
		{
			m_list = Enumerable
				.Range( 0, 5 )
				.Select( c => ( c + 1 ).ToString( "0000" ) )
				.Select( c => new ListItemData( c ) )
				.ToArray()
			;

			var initParam = new LoopListViewInitParam
			{
				mSmoothDumpRate		= 0.1f	,
				mSnapVecThreshold	= 99999	,
			};
			m_view.mOnSnapNearestChanged = OnSnapNearestChanged;
			m_view.InitListView( m_list.Length, OnUpdate, initParam );
		}

		private void OnSnapNearestChanged( LoopListView2 view, LoopListViewItem2 item )
		{
			int currentIndex = m_view.CurSnapNearestItemIndex;
			int count = m_list.Length;
			if ( currentIndex < 0 || count <= currentIndex ) return;
			for ( int i = 0; i < count; i++ )
			{
				var dotUI = m_dotUIList[ i ];
				dotUI.SetDisp( currentIndex == i );
			}
		}

		private LoopListViewItem2 OnUpdate( LoopListView2 view, int index )
		{
			if ( index < 0 || m_list.Length <= index ) return null;

			var data = m_list[ index ];
			var itemObj = view.NewListViewItem( m_original.name );
			var itemUI = itemObj.GetComponent<ListItemUI>();

			itemUI.SetDisp( data );

			return itemObj;
		}

		private void OnGUI()
		{
			var option = GUILayout.Width( 64 );
			GUILayout.BeginHorizontal();
			if ( GUILayout.Button( "←", option ) )
			{
				SetSnapIndex( -1 );
			}
			if ( GUILayout.Button( "→", option ) )
			{
				SetSnapIndex( 1 );
			}
			GUILayout.EndHorizontal();
		}

		private void SetSnapIndex( int offset )
		{
			int currentIndex = m_view.CurSnapNearestItemIndex;
			int nextIndex = currentIndex + offset;
			if ( nextIndex < 0 || m_list.Length <= nextIndex ) return;
			m_view.SetSnapTargetItemIndex( nextIndex );
		}
	}
}
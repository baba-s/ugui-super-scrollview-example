using SuperScrollView;
using System.Linq;
using UnityEngine;

namespace Example_Banner
{
	[DisallowMultipleComponent]
	public sealed class Example : MonoBehaviour
	{
		[SerializeField] private LoopListView2	m_view		= null	;
		[SerializeField] private GameObject		m_original	= null	;
		[SerializeField] private DotUI[]		m_dotUIList	= null	;
		[SerializeField] private float			m_interval	= 0		;

		private ListItemData[]	m_list	;
		private float			m_timer	;

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
			m_view.InitListView( -1, OnUpdate, initParam );
		}

		private void OnSnapNearestChanged( LoopListView2 view, LoopListViewItem2 item )
		{
			int itemIndex		= m_view.CurSnapNearestItemIndex;
			int count			= m_list.Length;
			int currentIndex	= itemIndex % count;

			for ( int i = 0; i < count; i++ )
			{
				var dotUI = m_dotUIList[ i ];
				dotUI.SetDisp( currentIndex == i );
			}
		}

		private LoopListViewItem2 OnUpdate( LoopListView2 view, int index )
		{
			var itemObj	= view.NewListViewItem( m_original.name );
			var itemUI	= itemObj.GetComponent<ListItemUI>();
			int count	= m_list.Length;

			int wrapindex = 0 <= index
				? index % count
				: count + ( ( index + 1 ) % count ) - 1;
			;

			var data = m_list[ wrapindex ];

			itemUI.SetDisp( wrapindex, data );

			return itemObj;
		}

		private void Update()
		{
			if ( m_view.IsDraging )
			{
				m_timer = 0;
				return;
			}
			m_timer += Time.deltaTime;
			if ( m_timer < m_interval ) return;
			SetSnapIndex( 1 );
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
			m_timer = 0;
			int currentIndex = m_view.CurSnapNearestItemIndex;
			int nextIndex = currentIndex + offset;
			m_view.SetSnapTargetItemIndex( nextIndex );
		}
	}
}
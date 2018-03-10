using SuperScrollView;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Example_Chat
{
	[DisallowMultipleComponent]
	public sealed class Example : MonoBehaviour
	{
		private static readonly CharaData[] m_charaList =
		{
			new CharaData( 0, "icon_1" ),
			new CharaData( 1, "icon_2" ),
			new CharaData( 2, "icon_3" ),
		};

		private static readonly string[] m_textList =
		{
			"おはようございます",
			"こんにちは\nこんにちは",
			"こんばんは\nこんばんは\nこんばんは",
			"おやすみ\nおやすみ\nおやすみ\nおやすみ",
		};

		private static readonly string[] m_imageSpriteNameList =
		{
			"emo_1",
			"emo_2",
			"emo_3",
		};

		[SerializeField] private LoopListView2	m_view		= null;
		[SerializeField] private ListItemUI		m_leftItem	= null;
		[SerializeField] private ListItemUI		m_rightItem	= null;

		private List<ListItemData> m_list;

		private void Start()
		{
			m_list = new List<ListItemData>();

			for ( int i = 0; i < 1000; i++ )
			{
				var charaIndex		= Random.Range( 0, m_charaList.Length );
				var textIndex		= Random.Range( 0, m_textList.Length );
				var imageIndex		= Random.Range( 0, m_imageSpriteNameList.Length );
				var charaData		= m_charaList[ charaIndex ];
				var text			= m_textList[ textIndex ];
				var imageSpriteName	= m_imageSpriteNameList[ imageIndex ];
				var isMessage		= Random.Range( 0, 5 ) != 0;

				var data = new ListItemData
				(
					charaData		: charaData,
					message			: isMessage ? text : null,
					imageSpriteName	: isMessage ? null : imageSpriteName
				);

				m_list.Add( data );
			}

			m_view.InitListView( m_list.Count, OnUpdate );
		}

		private LoopListViewItem2 OnUpdate( LoopListView2 view, int index )
		{
			if ( index < 0 || m_list.Count <= index ) return null;

			var data			= m_list[ index ];
			var prevData		= m_list.ElementAtOrDefault( index + 1 );
			var charaData		= data.CharaData;
			var itemOriginal	= charaData.Id == 0 ? m_rightItem : m_leftItem;
			var itemObj			= view.NewListViewItem( itemOriginal.name );
			var itemUI			= itemObj.GetComponent<ListItemUI>();

			itemUI.SetDisp( data, prevData );

			return itemObj;
		}
	}
}
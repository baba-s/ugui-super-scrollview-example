using UnityEngine;
using UnityEngine.UI;

namespace Example_Chat
{
	[DisallowMultipleComponent]
	public sealed class ListItemUI : MonoBehaviour
	{
		private static readonly CharaData m_dummyCharaData = new CharaData( -1, string.Empty );

		[SerializeField] private RectTransform		m_rootUI		= null;
		[SerializeField] private Image				m_iconUI		= null;
		[SerializeField] private Image				m_arrowUI		= null;
		[SerializeField] private Image				m_frameUI		= null;
		[SerializeField] private RectTransform		m_frameRectUI	= null;
		[SerializeField] private Text				m_textUI		= null;
		[SerializeField] private RectTransform		m_textRectUI	= null;
		[SerializeField] private ContentSizeFitter	m_textFitterUI	= null;
		[SerializeField] private Image				m_imageUI		= null;
		[SerializeField] private RectTransform		m_imageRectUI	= null;

		public void SetDisp( ListItemData data, ListItemData prevData )
		{
			var charaData = data.CharaData;
			var isMessage = data.IsMessage;
			var prevCharaData = prevData != null ? prevData.CharaData : m_dummyCharaData;
			var isSameChara = charaData.Id == prevCharaData.Id;

			m_iconUI.gameObject.SetActive( !isSameChara );
			m_iconUI.sprite = Resources.Load<Sprite>( charaData.IconSpriteName );
			m_arrowUI.gameObject.SetActive( isMessage );
			m_frameRectUI.gameObject.SetActive( isMessage );
			m_textUI.gameObject.SetActive( isMessage );
			m_textUI.text = data.Message;
			m_textFitterUI.SetLayoutVertical();
			m_imageUI.gameObject.SetActive( !isMessage );
			m_imageUI.sprite = Resources.Load<Sprite>( data.ImageSpriteName );

			var contentSize	= isMessage
				? m_textRectUI.sizeDelta
				: m_imageRectUI.sizeDelta
			;

			var frameSize = contentSize + new Vector2( 20, 20 );
			var color = charaData.Id == 0
				? new Color32( 255, 255, 255, 255 )
				: new Color32( 160, 231, 90, 255 );
			;

			m_frameRectUI.sizeDelta = frameSize;
			m_frameUI.color = color;
			m_arrowUI.color = color;

			var y = Mathf.Max( frameSize.y, 75 );

			m_rootUI.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, y );
		}

	}
}
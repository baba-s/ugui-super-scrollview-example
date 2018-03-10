using UnityEngine;

namespace Example_PageView
{
	[DisallowMultipleComponent]
	public sealed class DotUI : MonoBehaviour
	{
		[SerializeField] private GameObject	m_smallUI	= null;
		[SerializeField] private GameObject	m_largeUI	= null;

		public void SetDisp( bool isLarge )
		{
			m_smallUI.SetActive( !isLarge );
			m_largeUI.SetActive(  isLarge );
		}
	}
}
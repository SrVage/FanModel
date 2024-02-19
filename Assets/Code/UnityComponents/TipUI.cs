using Code.Abstract;
using TMPro;
using UnityEngine;

namespace Code.UnityComponents
{
	public class TipUI:MonoBehaviour, IShowTip
	{
		[SerializeField] private CanvasGroup _group;
		[SerializeField] private TextMeshProUGUI _text;

		public void ShowTip(string tip)
		{
			_group.alpha = 1;
			_text.text = tip;
		}

		public void HideTip()
		{
			_group.alpha = 0;
			_text.text = "";
		}
	}
}
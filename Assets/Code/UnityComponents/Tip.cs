using Code.Abstract;
using UnityEngine;

namespace Code.UnityComponents
{
	public class Tip:MonoBehaviour, IGetTip
	{
		[SerializeField] private string _tip;

		public string GetTip() => 
			_tip;
	}
}
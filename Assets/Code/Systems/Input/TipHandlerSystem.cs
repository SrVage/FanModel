using Code.Abstract;
using Code.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Input
{
	internal sealed class TipHandlerSystem:IEcsRunSystem
	{
		private const float DEATH_ZONE = 10;
		private readonly Camera _camera;
		private readonly int _layerMask;
		private Vector2 _previousPoint = Vector2.zero;
		private readonly IShowTip _showTip = null;

		public TipHandlerSystem()
		{
			_camera = Camera.main;
			_layerMask = LayerMask.GetMask("RaycastClick", "Tips");
		}

		public void Run()
		{
			if (((Vector2)UnityEngine.Input.mousePosition-_previousPoint).sqrMagnitude<DEATH_ZONE)
				return;
			_previousPoint = UnityEngine.Input.mousePosition;
			var ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit raycastHit, 50, _layerMask))
			{
				if (raycastHit.transform.TryGetComponent(out IGetTip tip))
				{
					_showTip.ShowTip(tip.GetTip());
				}
			}
			else
			{
				_showTip.HideTip();
			}
		}
	}
}
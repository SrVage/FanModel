using Code.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Input
{
	internal sealed class MouseClickHandlerSystem:IEcsRunSystem
	{
		private readonly Camera _camera;
		private readonly int _layerMask = LayerMask.NameToLayer("Raycast");

		public MouseClickHandlerSystem() => 
			_camera = Camera.main;

		public void Run()
		{
			if (UnityEngine.Input.GetMouseButtonDown(0))
			{
				var ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit raycastHit, 50, _layerMask))
				{
					if (raycastHit.transform.TryGetComponent<TriggerReference>(out TriggerReference reference))
					{
						reference.Trigger();
					}
				}
			}
		}
	}
}
using Client.Components.Camera;
using Client.Components.Tags;
using Code.Components.References;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Input
{
	internal sealed class MouseRightClickHandlerSystem:IEcsRunSystem
	{
		private readonly float _mouseSensitivity;
		private readonly EcsFilter<GameObjectRef, CameraTag> _camera = null;
		private readonly EcsFilter<GameObjectRef, FanTag> _fan = null;
		private Vector2 _previousPoint = Vector2.zero;

		public MouseRightClickHandlerSystem(float mouseSensitivity) => 
			_mouseSensitivity = mouseSensitivity;

		public void Run()
		{
			if (UnityEngine.Input.GetMouseButtonDown(1))
			{
				_previousPoint = UnityEngine.Input.mousePosition;
			}
			if (UnityEngine.Input.GetMouseButton(1))
			{
				foreach (var fdx in _fan)
				{
					ref var transform = ref _fan.Get1(fdx).Transform;
					foreach (var cdx in _camera)
					{
						ref var camera = ref _camera.Get1(cdx).Transform;
						transform.RotateAround(transform.position, 
							new Vector3(_previousPoint.y-UnityEngine.Input.mousePosition.y, _previousPoint.x-UnityEngine.Input.mousePosition.x, 0), 
							Vector3.Distance(UnityEngine.Input.mousePosition, _previousPoint)*Time.deltaTime*_mouseSensitivity);
						_previousPoint = UnityEngine.Input.mousePosition;
					}
				}
			}
		}
	}
}
using System;
using Client.Components.Camera;
using Client.Components.Tags;
using Code.Components.References;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Input
{
	internal sealed class CameraScaleSystem : IEcsRunSystem
	{
		private const float SCALE_FACTOR = 0.2f;
		private const float MIN_BORDER = 1;
		private const float MAX_BORDER = 10;
		private readonly float _mouseSensitivity;
		private readonly EcsFilter<GameObjectRef, CameraTag> _camera = null;
		private readonly EcsFilter<GameObjectRef, FanTag> _fan = null;


		public void Run()
		{
			if (Math.Abs(UnityEngine.Input.mouseScrollDelta.y) > 0.1)
			{
				foreach (var fdx in _fan)
				{
					ref var transform = ref _fan.Get1(fdx).Transform;
					foreach (var cdx in _camera)
					{
						ref var camera = ref _camera.Get1(cdx).Transform;
						if ((transform.position - camera.position).sqrMagnitude<MIN_BORDER && UnityEngine.Input.mouseScrollDelta.y>0 ||
						    (transform.position - camera.position).sqrMagnitude>MAX_BORDER && UnityEngine.Input.mouseScrollDelta.y<0)
							return;
						camera.position += (transform.position - camera.position).normalized * UnityEngine.Input.mouseScrollDelta.y*SCALE_FACTOR;
					}
				}
			}
		}

	}
}

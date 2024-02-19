using Client.Components;
using Client.Components.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Rotating
{
	internal sealed class FanRotatingSystem:IEcsRunSystem
	{
		private readonly EcsFilter<RotationComponent, IsRotatingTag, FanTag> _rotating = null;
		
		public void Run()
		{
			foreach (var rdx in _rotating)
			{
				ref var transform = ref _rotating.Get1(rdx).RotationTransform;
				ref var speed = ref _rotating.Get1(rdx).Speed;
				transform.Rotate(speed*Time.deltaTime);
			}
		}
	}
}
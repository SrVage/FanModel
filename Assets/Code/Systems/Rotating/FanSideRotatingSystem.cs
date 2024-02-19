using Client.Components;
using Client.Components.Buttons;
using Client.Components.Interaction;
using Client.Components.Tags;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems.Rotating
{
	public class FanSideRotatingSystem:IEcsRunSystem
	{
		private readonly EcsFilter<SideRotationComponent, FanTag, IsSideRotatingTag>.Exclude<AlreadySideRotateTag> _fan = null;
		private readonly EcsFilter<SideRotationComponent, FanTag, IsSideRotatingTag> _isRotating = null;
		private readonly EcsFilter<SideRotationButtonTag, IsTriggeredTag> _button = null;
		private TweenerCore<Quaternion, Vector3, QuaternionOptions> _rotateTween;
		

		public void Run()
		{
			if (!_button.IsEmpty() && _isRotating.IsEmpty())
			{
				_rotateTween.Kill();
			}
			foreach (var fdx in _fan)
			{
				ref var transform = ref _fan.Get1(fdx).RotationTransform;
				ref var angle = ref _fan.Get1(fdx).BorderAngle;
				var entity = _fan.GetEntity(fdx);
				entity.Get<AlreadySideRotateTag>();
				float destAngle = angle * (transform.localRotation.eulerAngles.y is > 0 and < 90 ? -1 : 1);
				_rotateTween = transform.DOLocalRotate(
					new Vector3(0,destAngle, 0), 
					10f)
					.OnComplete(() =>
				{
					entity.Del<AlreadySideRotateTag>();
				});
			}
		}
	}
}
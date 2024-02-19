using Client.Components;
using Code.Abstract;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.UnityComponents.Fan
{
	public class SideRotationConvertComponent:BaseConvertComponent
	{
		[SerializeField] private float _speed;
		[SerializeField] private float _borderAngle;
		public override EcsEntity Initial(EcsEntity entity)
		{
			entity.Get<SideRotationComponent>().RotationTransform = transform;
			entity.Get<SideRotationComponent>().Speed = _speed;
			entity.Get<SideRotationComponent>().BorderAngle = _borderAngle;
			return base.Initial(entity);
		}
	}
}
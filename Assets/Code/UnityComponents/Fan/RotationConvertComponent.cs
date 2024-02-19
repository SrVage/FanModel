using Client.Components;
using Code.Abstract;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.UnityComponents.Fan
{
	public class RotationConvertComponent:BaseConvertComponent
	{
		[SerializeField] private Vector3 _speed;
		public override EcsEntity Initial(EcsEntity entity)
		{
			entity.Get<RotationComponent>().RotationTransform = transform;
			entity.Get<RotationComponent>().Speed = _speed;
			return base.Initial(entity);
		}
	}
}
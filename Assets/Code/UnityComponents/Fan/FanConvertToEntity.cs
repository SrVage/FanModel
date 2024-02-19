using Client.Components.Tags;
using Code.Abstract;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.UnityComponents.Fan
{
	public class FanConvertToEntity:MonoBehaviourEntity
	{
		[SerializeField] private MonoBehaviourEntity[] _childrenEntity;
		
		public override EcsEntity Initial(EcsWorld world)
		{
			InitialChildrenEntities(world);
			EcsEntity entity = base.Initial(world);
			entity.Get<FanTag>();
			return entity;
		}

		private void InitialChildrenEntities(EcsWorld world)
		{
			foreach (var children in _childrenEntity)
			{
				children.Initial(world);
			}
		}
	}
}
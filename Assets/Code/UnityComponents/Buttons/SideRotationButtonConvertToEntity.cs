using Client.Components.Buttons;
using Code.Abstract;
using Leopotam.Ecs;

namespace Code.UnityComponents.Buttons
{
	public class SideRotationButtonConvertToEntity:MonoBehaviourEntity
	{
		public override EcsEntity Initial(EcsWorld world)
		{
			EcsEntity entity = base.Initial(world);
			entity.Get<SideRotationButtonTag>();
			return entity;
		}
	}
}
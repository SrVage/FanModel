using Client.Components.Camera;
using Code.Abstract;
using Leopotam.Ecs;

namespace Code.UnityComponents.Camera
{
	public class CameraConvertToEntity:MonoBehaviourEntity
	{
		public override EcsEntity Initial(EcsWorld world)
		{
			EcsEntity entity = base.Initial(world);
			entity.Get<CameraTag>();
			return entity;
		}
	}
}
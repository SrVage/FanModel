using Code.Abstract;
using Leopotam.Ecs;

namespace Client.Systems.Initial
{
	internal sealed class InitialSceneSystem:IEcsInitSystem
	{
		private readonly EcsWorld _world = null;
		private readonly MonoBehaviourEntity[] _entities = null;
		
		public InitialSceneSystem(MonoBehaviourEntity[] entities) => 
			_entities = entities;

		public void Init()
		{
			foreach (var entity in _entities)
			{
				entity.Initial(_world);
			}
		}
	}
}
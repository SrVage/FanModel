using Client.Components.Interaction;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.UnityComponents
{
	public class TriggerReference:MonoBehaviour
	{
		private EcsEntity _entity;

		public void Initial(EcsEntity entity) => 
			_entity = entity;

		public void Trigger() => 
			_entity.Get<IsTriggeredTag>();
	}
}
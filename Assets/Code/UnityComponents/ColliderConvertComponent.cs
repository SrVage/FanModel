using Code.Abstract;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.UnityComponents
{
	public class ColliderConvertComponent:BaseConvertComponent
	{
		[SerializeField] private Collider _collider;
		private void OnValidate() => 
			_collider = GetComponent<Collider>();

		public override EcsEntity Initial(EcsEntity entity)
		{
			gameObject.AddComponent<TriggerReference>().Initial(entity);
			return base.Initial(entity);
		}
	}
}
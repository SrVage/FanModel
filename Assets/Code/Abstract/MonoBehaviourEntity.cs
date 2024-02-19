using System;
using Code.Components.References;
using Code.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Abstract
{
    public abstract class MonoBehaviourEntity:MonoBehaviour
    {
        [SerializeField] protected BaseConvertComponent[] _baseComponents;

        private void OnValidate() => 
            _baseComponents = GetComponentsInChildren<BaseConvertComponent>();

        public virtual EcsEntity Initial(EcsWorld world)
        { 
            EcsEntity entity = world.NewEntity();
            entity.Get<GameObjectRef>().GameObject = gameObject;
            entity.Get<GameObjectRef>().Transform = transform;
            gameObject.AddComponent<EntityRef>().Entity = entity;
            foreach (var component in _baseComponents)
            {
                component.Initial(entity);
            }
            Destroy(this);
            return entity;
        }
    }
}
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Abstract
{
	public abstract class BaseConvertComponent:MonoBehaviour
	{
		public virtual EcsEntity Initial(EcsEntity entity)
		{ 
			Destroy(this);
			return entity;
		}
	}
}
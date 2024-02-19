using Client.Components.Buttons;
using Client.Components.Interaction;
using Client.Components.Tags;
using Client.Systems.Rotating;
using Leopotam.Ecs;

namespace Client.Systems.Interactable
{
	internal sealed class FanToggleSystem:IEcsRunSystem
	{
		private readonly EcsFilter<SwitchOnButtonTag, IsTriggeredTag> _buttonTrigger = null;
		private readonly EcsFilter<FanTag> _fan = null;
		
		public void Run()
		{
			if (_buttonTrigger.IsEmpty())
				return;
			foreach (var fdx in _fan)
			{
				var entity = _fan.GetEntity(fdx);
				if (entity.Has<IsRotatingTag>())
				{
					entity.Del<IsRotatingTag>();
				}
				else
				{
					entity.Get<IsRotatingTag>();
				}
			}
		}
	}
}
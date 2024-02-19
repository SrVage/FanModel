using Client.Components;
using Client.Components.Buttons;
using Client.Components.Interaction;
using Client.Components.Tags;
using Client.Systems.Rotating;
using Leopotam.Ecs;

namespace Client.Systems.Interactable
{
	internal sealed class SideRotateToggleSystem:IEcsRunSystem
	{
		private readonly EcsFilter<SideRotationButtonTag, IsTriggeredTag> _button = null;
		private readonly EcsFilter<SideRotationComponent, FanTag> _fanRotate = null;

		public void Run()
		{
			if (_button.IsEmpty())
				return;
			foreach (var fdx in _fanRotate)
			{
				var entity = _fanRotate.GetEntity(fdx);
				if (entity.Has<IsSideRotatingTag>())
				{
					entity.Del<IsSideRotatingTag>();
					entity.Del<AlreadySideRotateTag>();
				}
				else
				{
					entity.Get<IsSideRotatingTag>();

				}
			}
		}
	}
}
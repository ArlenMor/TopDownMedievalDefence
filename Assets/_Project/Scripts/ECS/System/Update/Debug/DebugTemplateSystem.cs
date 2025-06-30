using Leopotam.Ecs;
using Project.Component;

namespace Project.System.Update.DebugProject
{
	public sealed class DebugTemplateSystem: IEcsRunSystem
	{
		private readonly EcsFilter<PlayerComponent> _filter = null;

		public void Run()
		{
			foreach (var i in _filter)
			{
				ref var input = ref _filter.Get1(i);
			}
		}
	}
}
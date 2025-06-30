using Leopotam.Ecs;
using Project.Component;

namespace Project.System
{
    sealed class PositionSyncSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PositionComponent, TransformComponent> _syncFilter = null;

        public void Run()
        {
            foreach (var i in _syncFilter)
            {
                ref var position = ref _syncFilter.Get1(i);
                ref var view = ref _syncFilter.Get2(i);

                view.Transform.position = position.Position;
            }
        }
    }
}
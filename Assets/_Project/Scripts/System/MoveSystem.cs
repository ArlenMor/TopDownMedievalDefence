using Leopotam.Ecs;
using Project.Component;
using UnityEngine;

namespace Project.System
{
    public sealed class MoveSystem: IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent, PositionComponent, SpeedComponent> _moveFilter = null;
        
        public void Run()
        {
            foreach (var i in _moveFilter)
            {
                ref var input = ref _moveFilter.Get1(i);
                ref var position = ref _moveFilter.Get2(i);
                ref var speed = ref _moveFilter.Get3(i);
                
                position.Position += input.Direction * speed.Speed * Time.deltaTime;
            }
        }
    }
}
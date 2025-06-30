using Leopotam.Ecs;
using Project.Component;
using UnityEngine;

namespace Project.System
{
    public sealed class InputSystem: IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent> _inputFilter = null;

        public void Run()
        {
            foreach (var i in _inputFilter)
            {
                ref var input = ref _inputFilter.Get1(i);

                input.Direction = new Vector2(Input.GetAxisRaw("Horizontal"),
                                              Input.GetAxisRaw("Vertical")).normalized;
            }
        }
    }
}
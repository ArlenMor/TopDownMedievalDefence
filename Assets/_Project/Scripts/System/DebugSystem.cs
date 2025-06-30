using Leopotam.Ecs;
using Project.Component;
using UnityEngine;

namespace Project.System
{
	public class DebugSystem: IEcsRunSystem
	{
		private readonly EcsFilter<InputComponent, PositionComponent, SpeedComponent, TransformComponent> _filter = null;

		public void Run()
		{
			foreach (var i in _filter)
			{
				ref var input = ref _filter.Get1(i);
				ref var position = ref _filter.Get2(i);
				ref var speed = ref _filter.Get3(i);
				ref var transform = ref _filter.Get4(i);
				
				Debug.Log($"Entity Position: {position.Position}, Speed: {speed.Speed}, Direction: {input.Direction}, Transform: {transform.Transform.position}");
			}
		}
	}
}
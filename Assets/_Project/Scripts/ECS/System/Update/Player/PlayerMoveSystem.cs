using Leopotam.Ecs;
using Project.Component;
using UnityEngine;

namespace Project.System.Update.Player
{
	public sealed class PlayerMoveSystem: IEcsRunSystem
	{
		private readonly EcsFilter<PlayerFlag, InputComponent, TransformComponent, RunSpeedComponent, WalkSpeedComponent> _player =
				null;
		
		private readonly EcsFilter<PlayerFlag, WalkInputEvent> _playerWalkInput = null;

		public void Run()
		{
			var isWalking = !_playerWalkInput.IsEmpty();
			
			foreach (var i in _player)
			{
				ref var input = ref _player.Get2(i);
				ref var transform = ref _player.Get3(i);
				ref var moveSpeed = ref _player.Get4(i);
				ref var walkSpeed = ref _player.Get5(i);

				if (input.Direction != Vector2.zero)
				{
					var speed = isWalking ? walkSpeed.Speed : moveSpeed.Speed;
					var offset = input.Direction.normalized * speed * Time.deltaTime;
					transform.Transform.position += (Vector3)offset;
				}
			}
		}
	}
}
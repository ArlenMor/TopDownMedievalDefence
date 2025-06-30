using Leopotam.Ecs;
using Project.Component;
using UnityEngine;

namespace Project.System.Update.Player
{
	public sealed class PlayerMoveSystem: IEcsRunSystem
	{
		private readonly EcsFilter<PlayerComponent, InputComponent, TransformComponent, MoveSpeedComponent> _player =
				null;

		public void Run()
		{
			foreach (var i in _player)
			{
				ref var input = ref _player.Get2(i);
				ref var transform = ref _player.Get3(i);
				ref var moveSpeed = ref _player.Get4(i);

				if (input.Direction != Vector2.zero)
				{
					var oldPosition = (Vector2)transform.Transform.position;

					var offset = new Vector2(input.Direction.x * moveSpeed.Speed, input.Direction.y * moveSpeed.Speed) *
					             Time.deltaTime;

					transform.Transform.position = oldPosition + offset;
				}
			}
		}
	}
}
using Leopotam.Ecs;
using Project.Component;
using Project.EcsExample;
using UnityEngine;

namespace Project.System.Update.Player
{
	public class PlayerRotationSystem: IEcsRunSystem
	{
		private readonly EcsFilter<PlayerComponent, TransformComponent, RotationSpeedComponent> _player = null;
		private SceneData _sceneData;

		public void Run()
		{
			foreach (var i in _player)
			{
				ref var transform = ref _player.Get2(i);
				ref var rotationSpeed = ref _player.Get3(i);

				var mousePosition = _sceneData.MainCamera.ScreenToWorldPoint(Input.mousePosition);
				var direction = mousePosition - transform.Transform.position;

				if (direction.sqrMagnitude > 0.01f)
				{
					var targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
					var targetRotation = Quaternion.Euler(x: 0, y: 0, targetAngle);

					transform.Transform.rotation = Quaternion.RotateTowards(transform.Transform.rotation,
					                                                        targetRotation,
					                                                        rotationSpeed.Speed * Time.deltaTime);
				}
			}
		}
	}
}
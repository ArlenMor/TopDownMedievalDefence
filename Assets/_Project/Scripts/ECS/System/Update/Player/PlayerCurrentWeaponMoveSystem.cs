using Leopotam.Ecs;
using Project.Component;
using UnityEngine;

namespace Project.System.Update.Player
{
	public sealed class PlayerCurrentWeaponMoveSystem: IEcsRunSystem
	{
		private readonly EcsFilter<PlayerFlag, TransformComponent, CurrentWeaponComponent> _player = null;

		public void Run()
		{
			foreach (var player in _player)
			{
				ref var playerTransform = ref _player.Get2(player);
				ref var playerWeapon = ref _player.Get3(player);

				if (playerWeapon.WeaponEntity != EcsEntity.Null)
				{
					ref var weaponTransformComponent = ref playerWeapon.WeaponEntity.Get<TransformComponent>();
					var weaponTransform = weaponTransformComponent.Transform;
					var playerTf = playerTransform.Transform;

					// Смещение перед игроком (по правой локальной оси — для 2D)
					var offset = playerTf.up * 1f; // 0.5 — расстояние до оружия (можно вынести в константу)

					weaponTransform.position = playerTf.position + offset;
					weaponTransform.rotation = playerTf.rotation;
				}
			}
		}
	}
}
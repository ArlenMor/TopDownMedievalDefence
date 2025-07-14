using Leopotam.Ecs;
using Project.Component;
using UnityEngine;

namespace Project.System.Update.Weapon
{
	public sealed class WeaponPickUpSystem: IEcsRunSystem
	{
		private readonly EcsFilter<PlayerFlag, TransformComponent, CurrentWeaponComponent, PickupInputEvent> _playerFilter = null;
		private readonly EcsFilter<WorldItemFlag, WeaponFlag, TransformComponent> _weaponFilter = null;
		
		public void Run()
		{
			foreach (var player in _playerFilter)
			{
				ref var playerEntity = ref _playerFilter.GetEntity(player);
				ref var playerTransform = ref _playerFilter.Get2(player);
				ref var currentWeapon = ref _playerFilter.Get3(player);
				
				var closestDistance = float.MaxValue;
				EcsEntity? closestWeapon = null;
				
				foreach (var weapon in _weaponFilter)
				{
					ref var weaponEntity = ref _weaponFilter.GetEntity(weapon);
					ref var weaponTransform = ref _weaponFilter.Get3(weapon);

					float sqrDistance = (playerTransform.Transform.position - weaponTransform.Transform.position).sqrMagnitude;

					if (sqrDistance < 0.25f && sqrDistance < closestDistance) {
						closestDistance = sqrDistance;
						closestWeapon = weaponEntity;
					}
				}
				
				if (closestWeapon.HasValue) {
					// Выкидываем текущее оружие
					if (currentWeapon.WeaponEntity.IsAlive() && currentWeapon.WeaponEntity.Has<WeaponFlag>()) {
						var oldWeapon = currentWeapon.WeaponEntity;

						oldWeapon.Get<WorldItemFlag>();
						oldWeapon.Del<EquippedFlag>();
                    
						// Переместить в позицию игрока
						ref var oldTransform = ref oldWeapon.Get<TransformComponent>();
						oldTransform.Transform.position = playerTransform.Transform.position;
						oldTransform.Transform.SetParent(null);
					}

					var newWeapon = closestWeapon.Value;

					newWeapon.Del<WorldItemFlag>();
					newWeapon.Get<EquippedFlag>();
                
					ref var weaponTransform = ref newWeapon.Get<TransformComponent>();
					weaponTransform.Transform.SetParent(playerTransform.Transform);
					weaponTransform.Transform.localPosition = Vector3.zero; // Или нужная точка в руке
					weaponTransform.Transform.localRotation = Quaternion.identity;

					currentWeapon.WeaponEntity = newWeapon;
				}

				playerEntity.Del<PickupInputEvent>(); // Удаляем событие после обработки
			}
		}
	}
}
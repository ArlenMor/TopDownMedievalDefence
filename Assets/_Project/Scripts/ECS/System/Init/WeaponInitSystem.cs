using Leopotam.Ecs;
using Project.Component;
using Project.ConfigScripts;
using Project.EcsExample;
using UnityEngine;

namespace Project.System.Init
{
	public sealed class WeaponInitSystem: IEcsInitSystem
	{
		private EcsWorld _ecsWorld;
		private StaticData _staticData;
		private SceneData _sceneData;

		public void Init()
		{
			foreach (var weaponData in _staticData.WeaponDataList)
			{
				var weaponEntity = _ecsWorld.NewEntity();
				weaponEntity.Get<WeaponFlag>();
				weaponEntity.Get<WorldItemFlag>();

				var weapon = Object.Instantiate(weaponData.Prefab,
				                                _sceneData.WeaponSpawnPoints[Random.Range(0, _sceneData.WeaponSpawnPoints.Count)]
				                                          .position, Quaternion.identity, _sceneData.ItemLayer.transform);
				
				weaponEntity.Get<TransformComponent>().Transform = weapon.GetComponent<Transform>();
				weaponEntity.Get<DamageComponent>().Damage = weaponData.Damage;
				weaponEntity.Get<AttackRangeComponent>().AttackRange = weaponData.AttackRange;
				weaponEntity.Get<AttackCooldownComponent>().Cooldown = weaponData.AttackCooldown;
				
				ref var weaponType = ref weaponEntity.Get<WeaponTypeComponent>();
				weaponType.Type = weaponData.Type;
				weaponType.Kind = weaponData.Kind;
			}
		}
	}
}
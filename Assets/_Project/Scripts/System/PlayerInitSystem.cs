using Leopotam.Ecs;
using Project.Component;
using Project.EcsExample;
using UnityEngine;

namespace Project.System
{
	public class PlayerInitSystem: IEcsInitSystem
	{
		private EcsWorld _ecsWorld;
		private StaticData _staticData;
		private SceneData _sceneData;

		public void Init()
		{
			var playerEntity = _ecsWorld.NewEntity();
        
			ref var playerTransform = ref playerEntity.Get<TransformComponent>();
			playerEntity.Get<InputComponent>();
			playerEntity.Get<SpeedComponent>().Speed = 5f;
			playerEntity.Get<PositionComponent>().Position = _sceneData.PlayerSpawnPoint.position;
			
			var playerGO = Object.Instantiate(_staticData.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);
			playerTransform.Transform = playerGO.GetComponent<Transform>();
		}
	}
}
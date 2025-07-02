using Leopotam.Ecs;
using Project.Component;
using Project.ConfigScripts;
using Project.EcsExample;
using UnityEngine;

namespace Project.System.Init
{
	public sealed class PlayerInitSystem: IEcsInitSystem
	{
		private EcsWorld _ecsWorld;
		private StaticData _staticData;
		private SceneData _sceneData;

		public void Init()
		{
			var playerEntity = _ecsWorld.NewEntity();

			playerEntity.Get<PlayerFlag>();
			playerEntity.Get<InputComponent>();

			ref var playerTransform = ref playerEntity.Get<TransformComponent>();
			ref var playerMoveSpeed = ref playerEntity.Get<MoveSpeedComponent>();
			ref var playerRotationSpeed = ref playerEntity.Get<RotationSpeedComponent>();
			ref var playerAnimator = ref playerEntity.Get<AnimatorComponent>();

			var playerGO = Object.Instantiate(_staticData.PlayerData.Prefab, _sceneData.PlayerSpawnPoint.position,
			                                  Quaternion.identity);

			playerTransform.Transform = playerGO.GetComponent<Transform>();
			playerAnimator.Animator = playerGO.GetComponent<Animator>();
			playerMoveSpeed.Speed = _staticData.PlayerData.MoveSpeed;
			playerRotationSpeed.Speed = _staticData.PlayerData.RotationSpeed;
		}
	}
}
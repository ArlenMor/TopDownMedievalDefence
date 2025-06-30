using Leopotam.Ecs;
using Project.System;
using Project.System.Init;
using Project.System.Update;
using UnityEngine;

namespace Project.EcsExample
{
	public class EcsStartup: MonoBehaviour
	{
		private EcsWorld _world;
		private EcsSystems _updateSystems;

		private void Start()
		{
			_world = new EcsWorld();
			_updateSystems = new EcsSystems(_world);

			var runtimeData = new RuntimeData();

			RegisterInitSystems();
			RegisterUpdateSystems();
			InjectSystems(runtimeData);

			_updateSystems.Init();
		}

		public StaticData Configuration;
		public SceneData SceneData;

		private void RegisterInitSystems() => _updateSystems.Add(new PlayerInitSystem());

		private void RegisterUpdateSystems() => _updateSystems
		                                       .Add(new PlayerInputSystem())
		                                       .Add(new PlayerMoveSystem())
		                                       .Add(new PlayerRotationSystem());

		private void InjectSystems(RuntimeData runtimeData) => _updateSystems.Inject(Configuration)
		                                                                     .Inject(SceneData)
		                                                                     .Inject(runtimeData);

		private void Update() => _updateSystems?.Run();

		private void OnDestroy()
		{
			_updateSystems?.Destroy();
			_world?.Destroy();
		}
	}
}
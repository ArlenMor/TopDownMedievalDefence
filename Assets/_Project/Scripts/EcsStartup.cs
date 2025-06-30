using Leopotam.Ecs;
using Project.System;
using UnityEngine;

namespace Project.EcsExample
{
	public class EcsStartup: MonoBehaviour
	{
		private EcsWorld _world;
		private EcsSystems _systems;

		private void Start()
		{
			_world = new EcsWorld();
			_systems = new EcsSystems(_world);
			
			var runtimeData = new RuntimeData();

			_systems
				   .Add(new PlayerInitSystem())
				   .Add(new InputSystem())
				   .Add(new MoveSystem())
				   .Add(new PositionSyncSystem())
				   .Add(new DebugSystem())
				   .Inject(Configuration)
				   .Inject(SceneData)
				   .Inject(runtimeData)
				   .Init();
		}

		public StaticData Configuration;
		public SceneData SceneData;

		private void Update() => _systems?.Run();

		private void OnDestroy()
		{
			_systems?.Destroy();
			_world?.Destroy();
		}
	}
}
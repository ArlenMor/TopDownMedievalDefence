using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using Project.ConfigScripts;
using Project.System.Init;
using Project.System.Update.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.EcsExample
{
	public class EcsStartup: MonoBehaviour
	{
		private EcsWorld _world;
		private EcsSystems _updateSystems;

		private void Start()
		{
			_world = new EcsWorld();
			
			#if UNITY_EDITOR
			EcsWorldObserver.Create(_world);
			#endif  
			
			_updateSystems = new EcsSystems(_world);

			var runtimeData = new RuntimeData();

			RegisterInitSystems();
			RegisterUpdateSystems();
			InjectSystems(runtimeData);

			_updateSystems.Init();
			
			#if UNITY_EDITOR
			EcsSystemsObserver.Create(_updateSystems);
			#endif
		}

		public StaticData StaticData;
		public SceneData SceneData;

		private void RegisterInitSystems()
		{
			_updateSystems.Add(new PlayerInitSystem()).
			               Add(new WeaponInitSystem());
		}

		private void RegisterUpdateSystems()
		{
			_updateSystems
				   .Add(new PlayerInputSystem())
				   .Add(new PlayerMoveSystem())
				   .Add(new PlayerRotationSystem())
				   .Add(new PlayerAnimationSystem());
		}

		private void InjectSystems(RuntimeData runtimeData)
		{
			_updateSystems.Inject(StaticData)
			              .Inject(SceneData)
			              .Inject(runtimeData);
		}

		private void Update()
		{
			_updateSystems?.Run();
		}

		private void OnDestroy()
		{
			_updateSystems?.Destroy();
			_world?.Destroy();
		}
	}
}
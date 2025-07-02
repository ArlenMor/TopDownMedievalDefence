using Leopotam.Ecs;

namespace Project.Component
{
	public struct CurrentWeaponComponent : IEcsIgnoreInFilter
	{
		public EcsEntity WeaponEntity;
	}
}
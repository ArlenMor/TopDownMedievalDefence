using Leopotam.Ecs;
using Project.Component;
using UnityEngine;

namespace Project.System.Update.Player
{
	public class PlayerAnimationSystem: IEcsRunSystem
	{
		private EcsFilter<PlayerComponent, InputComponent, AnimatorComponent> _filter = null;

		public void Run()
		{
			foreach (var i in _filter)
			{
				ref var input = ref _filter.Get2(i);
				ref var animator = ref _filter.Get3(i);

				if (input.Direction == Vector2.zero)
				{
					animator.Animator.SetBool("IsMoving", false);
				}
				else
				{
					
					animator.Animator.SetBool("IsMoving", true);
				}
			}
		}
	}
}
﻿using Leopotam.Ecs;
using Project.Component;
using UnityEngine;

namespace Project.System.Update.Player
{
	public sealed class PlayerInputSystem: IEcsRunSystem
	{
		private readonly EcsFilter<PlayerFlag, InputComponent> _player = null;

		public void Run()
		{
			foreach (var i in _player)
			{
				ref var input = ref _player.Get2(i);

				input.Direction = new Vector2(Input.GetAxisRaw(axisName: "Horizontal"),
				                              Input.GetAxisRaw(axisName: "Vertical")).normalized;
				
				if (Input.GetKeyDown(KeyCode.E)) 
				{
					_player.GetEntity(i).Get<PickupInputEvent>();
				}
				
				if(Input.GetKey(KeyCode.LeftControl))
				{
					_player.GetEntity(i).Get<WalkInputEvent>();
				}
				else if (_player.GetEntity(i).Has<WalkInputEvent>())
				{
					_player.GetEntity(i).Del<WalkInputEvent>();
				}
			}
		}
	}
}
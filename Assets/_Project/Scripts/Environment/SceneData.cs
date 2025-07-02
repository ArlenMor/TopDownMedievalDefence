using System.Collections.Generic;
using UnityEngine;

namespace Project.EcsExample
{
	public class SceneData: MonoBehaviour
	{
		[Header("Utilities")]
		public Camera MainCamera;
		
		[Header("Player")]
		public Transform PlayerSpawnPoint;
		
		[Header("Items")]
		public GameObject ItemLayer;
		public List<Transform> WeaponSpawnPoints;
		
		[Header("Enemies")]
		public GameObject EnemyLayer;
	}
}
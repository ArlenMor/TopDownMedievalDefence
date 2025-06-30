using UnityEngine;

namespace Project.EcsExample
{
	[CreateAssetMenu(fileName = "PlayerData", menuName = "StaticData/PlayerData")]
	public class PlayerData: ScriptableObject
	{
		public GameObject Prefab;
		public float MoveSpeed;
		public float RotationSpeed;
	}
}
using UnityEngine;

namespace Project.ConfigScripts
{
	[CreateAssetMenu(fileName = "PlayerData", menuName = "StaticData/PlayerData")]
	public class PlayerData: ScriptableObject
	{
		public GameObject Prefab;
		public float WalkSpeed;
		public float MoveSpeed;
		public float RotationSpeed;
	}
}
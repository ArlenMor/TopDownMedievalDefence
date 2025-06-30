using UnityEngine;

namespace Project.EcsExample
{
	[CreateAssetMenu(fileName = "StaticData", menuName = "StaticData/StaticData")]
	public class StaticData: ScriptableObject
	{
		public PlayerData PlayerData;
	}
}
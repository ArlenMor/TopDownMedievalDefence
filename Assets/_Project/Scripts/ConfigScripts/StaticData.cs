using System.Collections.Generic;
using UnityEngine;

namespace Project.ConfigScripts
{
	[CreateAssetMenu(fileName = "StaticData", menuName = "StaticData/StaticData")]
	public class StaticData: ScriptableObject
	{
		public PlayerData PlayerData;
		public List<WeaponData> WeaponDataList;
	}
}
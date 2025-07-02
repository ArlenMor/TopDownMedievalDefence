using Project.Component;
using UnityEngine;

namespace Project.ConfigScripts
{
	[CreateAssetMenu(fileName = "WeaponData", menuName = "StaticData/WeaponData")]
	public class WeaponData: ScriptableObject
	{
		public GameObject Prefab;
		public float Damage;
		public float AttackRange;
		public float AttackCooldown;
		public WeaponType Type;
		public WeaponKind Kind;
	}
}
using UnityEngine;

namespace Dialogue
{
	[CreateAssetMenu(menuName = "Dialogue/CharacterInfo")]
	public class CharacterInfo : ScriptableObject
	{
		public Sprite icon;
		public string title;
	}
}

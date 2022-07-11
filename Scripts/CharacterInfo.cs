using UnityEngine;

namespace Dialogue
{
	[CreateAssetMenu(menuName = "Dialogue/CharacterInfo")]
	public partial class CharacterInfo : ScriptableObject
	{
		public Sprite icon;
		public string title;
	}
}

using RPGworld14.Content.Items.Armor;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPGworld14.Common.Players
{
	public class RPGworldCostumePlayer : ModPlayer
	{
		public bool BlockyVanityEffects; // This helper property controls if the audio and visual effects of the vanity should be applied.

        public override void ResetEffects()
        {
            BlockyVanityEffects = false;
        }
        public override void FrameEffects() {
			// TODO: Need new hook, FrameEffects doesn't run while paused.
			if (BlockyVanityEffects) {
				var denirt = ModContent.GetInstance<Denirt>();
				Player.head = EquipLoader.GetEquipSlot(Mod, denirt.Name, EquipType.Head);
				Player.body = EquipLoader.GetEquipSlot(Mod, denirt.Name, EquipType.Body);
				Player.legs = EquipLoader.GetEquipSlot(Mod, denirt.Name, EquipType.Legs);
			}
		}
	}
}
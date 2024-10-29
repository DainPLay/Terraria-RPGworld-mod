using RPGworld14.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPGworld14.Content.Items.Armor
{
	// This and several other classes show off using EquipTextures to do a Merfolk or Werewolf effect.
	// Typically Armor items are automatically paired with an EquipTexture, but we can manually use EquipTextures to achieve more unique effects.
	// There is code for this effect in many places, look in the following files for the full implementation:
	// NPCs.ExamplePerson drops this item when killed
	// Content.Items.Armor.ExampleCostume (below) is the accessory item that sets ExampleCostumePlayer values. Note that this item does not have EquipTypes set. This is a vital difference and key to our approach.
	// Content.Items.Armor.DenirtFace (below) is an EquipTexture class. It spawns dust when active.
	// ExampleCostume.Load() shows calling AddEquipTexture 3 times with appropriate parameters. This is how we register EquipTexture manually instead of the automatic pairing of ModItem and EquipTexture that other equipment uses.
	// Buffs.Blocky is the Buff that is shown while in Blocky mode. The buff is responsible for the actual stat effects of the costume. It also needs to remove itself when not near town npcs.
	// ExampleCostumePlayer has 6 bools. They manage the visibility and other things related to this effect.
	// ExampleCostumePlayer.ResetEffects resets those bool, except blockyAccessoryPrevious which is special because of the order of hooks.
	// ExampleCostumePlayer.UpdateEquips is responsible for applying the Blocky buff to the player if the conditions are met and the accessory is equipped.
	// ExampleCostumePlayer.FrameEffects is most important. It overrides the drawn equipment slots and sets them to our Blocky EquipTextures.
	// ExampleCostumePlayer.ModifyDrawInfo is for some fun effects for our costume.
	// Remember that the visuals and the effects of Costumes must be kept separate. Follow this example for best results.
	public class Denirt : ModItem
	{
		public override void Load() {
			// The code below runs only if we're not loading on a server
			if (Main.netMode == NetmodeID.Server)
				return;

			// Add equip textures
			EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, this, equipTexture: new DenirtFace());
			EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, this);
			EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
        }

		// Called in SetStaticDefaults
		private void SetupDrawing() {
			// Since the equipment textures weren't loaded on the server, we can't have this code running server-side
			if (Main.netMode == NetmodeID.Server)
				return;

			int equipSlotHead = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head);
			int equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
			int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);

            ArmorIDs.Head.Sets.DrawHead[equipSlotHead] = false;
            ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
            ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
            ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
        }

		public override void SetStaticDefaults() {
			SetupDrawing();
		}

		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 28;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 2, 50, 0);
			Item.rare = ItemRarityID.Green;
            Item.hasVanityEffects = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var p = player.GetModPlayer<RPGworldCostumePlayer>();
            p.BlockyVanityEffects = !hideVisual;
        }

        public override void UpdateVanity(Player player)
        {
            var p = player.GetModPlayer<RPGworldCostumePlayer>();
            p.BlockyVanityEffects = true;
        }

    }

	public class DenirtFace : EquipTexture
	{
		public override bool IsVanitySet(int head, int body, int legs) => true;
	}
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPGworld14.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class dain_headphones_red : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 38));
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 34;
            Item.value = 0;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 1, 50, 0);
            Item.vanity = true;
        }


        public override void EquipFrameEffects(Player player, EquipType type)
        {
            // This method handles the Hot Potato game functionality.
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.direction < 0 && player.armor[10].type == ModContent.ItemType<dain_headphones_red>()) player.armor[10].SetDefaults(Mod.Find<ModItem>("dain_headphones_green").Type);
                if (player.direction < 0 && player.armor[0].type == ModContent.ItemType<dain_headphones_red>()) player.armor[0].SetDefaults(Mod.Find<ModItem>("dain_headphones_green").Type);

            }
        }
    }
}
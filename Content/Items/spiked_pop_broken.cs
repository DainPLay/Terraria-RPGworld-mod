using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RPGworld.Utilities;
using RPGworld14.Content.Projectiles;
using Terraria.Audio;

namespace RPGworld14.Content.Items
{
    public class spiked_pop_broken : ModItem
    {

        public int countdownTimer = 900;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Broken", LangHelper.GetText("Common.spiked_pop_broken_status"))
            {
                OverrideColor = new Color(167, 105, 105)
            };
            tooltips.Add(line);

        }


        public override void SetDefaults()
        {
            Item.damage = 82;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 24;
            Item.shootSpeed = 4.3f;
            Item.knockBack = 6.5f;
            Item.width = 64;
            Item.height = 32;
            Item.scale = 0.5f;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 10);

            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<spiked_pop_broken_projectile>();
        }


        public override void UpdateInventory(Player player)
        {
            // This method handles the Hot Potato game functionality.
            if (player.whoAmI == Main.myPlayer)
            {
                countdownTimer -= 1;
                if (countdownTimer <= 0)
                {
                    // Once the timer reaches 0, a grenade projectile is spawned with 2 ticks left, this is the simplest way to simulate the explosion.
                    // The item itself is deleted from the players inventory.
                    int Popfix = Item.prefix;
                    Item.SetDefaults(Mod.Find<ModItem>("spiked_pop").Type);
                    Item.Prefix(Popfix);
                    //SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/spiked_pop_rebuilds").WithVolume(.7f).WithPitchVariance(.5f));
                }
            }
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
    }
}

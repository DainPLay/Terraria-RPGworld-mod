using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RPGworld14.Content.Projectiles;


namespace RPGworld14.Content.Items
{
    public class spiked_pop : ModItem
    {

        public static int countdownTimer = 0;

        public override void SetDefaults()
        {
            Item.damage = 246;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 24;
            Item.shootSpeed = 4.3f;
            Item.knockBack = 6.5f;
            Item.width = 32;
            Item.height = 32;
            Item.scale = 0.5f;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 10);

            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<spiked_pop_projectile>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }


    }
}

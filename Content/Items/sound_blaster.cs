using RPGworld14.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPGworld14.Content.Items
{
    public class sound_blaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("Shoot a laser beam that can eliminate anything...");
        }

        public override void SetDefaults()
        {
            Item.damage = 120;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true; //Channel so that you can hold the weapon [Important]
            Item.mana = 20;
            Item.rare = ItemRarityID.Pink;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 14f;
            Item.useAnimation = 20;
            Item.shoot = ModContent.ProjectileType<sound_beam>();
            Item.value = Item.sellPrice(silver: 3);
        }

        public override void UpdateInventory(Player player)
        {
            Item.mana = player.statManaMax2;
        }


    }
}

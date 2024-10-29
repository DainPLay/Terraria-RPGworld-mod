using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RPGworld14.Content.Items
{
    public class iron_pick : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Iron Pick");
            //DisplayName.AddTranslation(GameCulture.Russian, "Железная палка");
            //Tooltip.SetDefault("[c/CF1D2D:Still better than nothing]");
            //Tooltip.AddTranslation(GameCulture.Russian, "Всё же лучше чем ничего");
        }
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.value = 0;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.pick = 35;
            Item.axe = 7;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}

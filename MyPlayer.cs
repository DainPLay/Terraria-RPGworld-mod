using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPGworld
{
    public class MyPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public bool minionName = false;
        public bool Pet = false;
        public static bool hasProjectile;

        public override void ResetEffects()
        {
            minionName = false;
            Pet = false;
        }


    }
    class Start : ModPlayer
    {

        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> items, bool mediumCoreDeath)
        {
            //items.RemoveAt(2);         
            //items.RemoveAt(1);
            //items.RemoveAt(0);

            //Item item = new Item();
            //item.SetDefaults(Mod.Find<ModItem>("iron_pick").Type);
            //item.stack = 1;
            //items.Add(item);
            //if (Main.player[Main.myPlayer].name == "Dain_PLay")
            //{
            //    items.Add(item);
            //    Main.player[Main.myPlayer].armor[0].SetDefaults(Mod.Find<ModItem>("dain_headphones_green").Type);
            //    Main.player[Main.myPlayer].armor[1].SetDefaults(Mod.Find<ModItem>("dain_hoodie").Type);
            //}

        }


    }
}
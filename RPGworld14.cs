using System;
using System.IO;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

using Terraria;
using Terraria.ID;
using Terraria.GameContent.UI;
using Terraria.ModLoader;
using Terraria.Graphics;
using Terraria.Localization;
using Terraria.DataStructures;

namespace RPGworld
{
    class RPGworld : Mod
    {

        internal static RPGworld mod;

        public override void Load()
        {
            mod = this;
        }

        public override void Unload()
        {
            mod = null;
        }
        public RPGworld()
        {
            //Properties = new ModProperties()
            //{
            //    Autoload = true,
            //    AutoloadGores = true,
            //    AutoloadSounds = true
            //};
        }
    }





}
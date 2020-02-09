using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Unending.Tiles.Ores
{
    public class RoyalOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            drop = mod.ItemType("RoyalOreItem");
            AddMapEntry(new Color(200, 0, 200));
        }
    }
}
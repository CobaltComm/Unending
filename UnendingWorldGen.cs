using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace Unending
{
    public class UnendingWorldGen : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Unending Generation", OreGeneration));
            }
        }
        private void OreGeneration(GenerationProgress progress)
        {

            // If you want to ensure that the ore spawns you can do a count.
            int count = 0;
            // In this case, we check if there is a minimum of 1 ore spawned.
            while (count < 120)
            {
                // We can also spawn the tile in certain tiles
                for (var i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 9E-05); i++)
                {
                    int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, Main.maxTilesY);
                    Tile tile = Framing.GetTileSafely(x, y);
                    if (tile.active() && (tile.type == TileID.Dirt || tile.type == TileID.Stone))
                    {
                        WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 5), mod.TileType("RoyalOre"));
                        count++;
                    }
                }
            }
        }

    }
}
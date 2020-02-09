using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items
{
    class UnendingGlobalItem : GlobalItem
    {
        public override bool OnPickup(Item item, Player player)
        {
            if (item.type == ItemID.Heart)
            {
                if (UnendingWorld.MayhemMode)
                {
                    if (NPC.AnyNPCs(NPCID.WallofFlesh))
                    {
                        player.AddBuff(BuffID.OnFire, 600);
                    }
                    if (player.ZoneJungle && !NPC.AnyNPCs(NPCID.QueenBee))
                    {
                        player.AddBuff(BuffID.Poisoned, 600);
                    }
                }
            }
            return true;
        }
    }
}

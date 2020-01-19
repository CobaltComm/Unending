using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Unending
{
    public static class UnendingHelper
    {
        // This is all code from the Antiaris Helper. I'm...co-opting it.
        public static int GetNearestAlivePlayer(Terraria.NPC npc)
        {
            var NearestPlayerDist = 4815162342f;
            var NearestPlayer = -1;
            foreach (Player player in Main.player)
            {
                if (player.Distance(npc.Center) < NearestPlayerDist && player.active)
                {
                    NearestPlayerDist = player.Distance(npc.Center);
                    NearestPlayer = player.whoAmI;
                }
            }
            return NearestPlayer;
        }
        public static int GetNearestNPC(Vector2 Point, bool Friendly = false, bool NoBoss = false)
        {
            float NearestNPCDist = -1;
            int NearestNPC = -1;
            foreach (NPC npc in Main.npc)
            {
                if (!npc.active)
                    continue;
                if (NoBoss && npc.boss)
                    continue;
                if (!Friendly && (npc.friendly || npc.lifeMax <= 5))
                    continue;
                if (NearestNPCDist == -1 || npc.Distance(Point) < NearestNPCDist)
                {
                    NearestNPCDist = npc.Distance(Point);
                    NearestNPC = npc.whoAmI;
                }
            }
            return NearestNPC;
        }
        public static int GetNearestPlayer(Vector2 Point, bool Alive = false)
        {
            float NearestPlayerDist = -1;
            int NearestPlayer = -1;
            foreach (Player player in Main.player)
            {
                if (Alive && (!player.active || player.dead))
                    continue;
                if (NearestPlayerDist == -1 || player.Distance(Point) < NearestPlayerDist)
                {
                    NearestPlayerDist = player.Distance(Point);
                    NearestPlayer = player.whoAmI;
                }
            }
            return NearestPlayer;
        }
        public static void MoveTowards(this NPC npc, Vector2 playerTarget, float speed, float turnResistance) //This is apparently from BlushieMagic, so credit to her too! Hi Blushie! If you can see this I love your work!
        {
            var Move = playerTarget - npc.Center;
            float Length = Move.Length();
            if (Length > speed)
            {
                Move *= speed / Length;
            }
            Move = (npc.velocity * turnResistance + Move) / (turnResistance + 1f);
            Length = Move.Length();
            if (Length > speed)
            {
                Move *= speed / Length;
            }
            npc.velocity = Move;
        }

    }
}
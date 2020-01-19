using Terraria;
using Terraria.ModLoader;
using Unending.NPCs;
using Unending;
using Microsoft.Xna.Framework;

namespace Unending.Buffs.Debuffs.Mayhem
{
    public class Junglebite : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Jungle's Fang");
            Description.SetDefault("Thorns split open your defenses");
            Main.debuff[Type] = true;
            longerExpertDebuff = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            //Enjoy that big fat DEFENSE DROP FOOL
            player.GetModPlayer<UnendingPlayer>().Junglebite = true;
        }
    }
    public class PlantBiteEffect : GlobalNPC
    {
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            //To change the target to a greener color;
            if (npc.HasBuff(mod.BuffType("Junglebite")))
            {
                drawColor.R = (byte)(drawColor.R * 1f);
                drawColor.G = (byte)(drawColor.G * 2.7f);
                drawColor.B = (byte)(drawColor.B * 1f);
            }

        }
        public override void AI(NPC npc)
        {
            if (npc.HasBuff(mod.BuffType("Snakebite")))
            {
                if (npc.defense >= 0 && npc.defense < 35)
                {
                    npc.defense = 0;
                }
                else
                {
                    npc.defense -= 35;
                }
            }
        }
    }
}
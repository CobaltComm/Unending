using Terraria;
using Terraria.ModLoader;
using Unending.NPCs;
using Unending;
using Microsoft.Xna.Framework;

namespace Unending.Buffs.Debuffs
{
    public class Snakebite : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Serpent Bite");
            Description.SetDefault("Dissolving from caustic venom");
            Main.debuff[Type] = true;


            longerExpertDebuff = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {


        }




    }
    public class DecayEffect : GlobalNPC
    {
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            //To change the target to a crimson-purple color;
            if (npc.HasBuff(mod.BuffType("Snakebite")))
            {
                drawColor.R = (byte)(drawColor.R * 1f);
                drawColor.G = (byte)(drawColor.G * 0f);
                drawColor.B = (byte)(drawColor.B * 0.3f);
            }

        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.HasBuff(mod.BuffType("Snakebite")))
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 20;
            }

        }
        public override void AI(NPC npc)
        {
            if (npc.HasBuff(mod.BuffType("Snakebite")))
            {
                if (npc.defense >= 0 && npc.defense < 20)
                {
                    npc.defense = 0;
                }
                else
                {
                    npc.defense -= 20;
                }
            }
        }
    }
}
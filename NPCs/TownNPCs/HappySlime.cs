/*using System;
using Unending.Projectiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.NPCs.TownNPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class HappySlime : ModNPC
	{
		public override string Texture => "ExampleMod/NPCs/TownNPCs/HappySlime";
		private bool SlimeBuffYes;

		public override bool Autoload(ref string name) {
			name = "Happy Slime";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustID.PinkSlime);
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			if (NPC.downedSlimeKing == true)
				{
				    return true;
				}		
			return false;
		}

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Taxic";
				case 1:
					return "Reginald";
				case 2:
					return "Jellemiah";
				default:
					return "Smiley";
			}
		}
		
		public override void FindFrame(int frameHeight) {
			npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}
		}

		public override string GetChat()
        {
            if (Main.bloodMoon && Main.rand.NextBool(8))
            {
                return "This reminds me of my big brother. He...wasn't very nice to me, especially when it ended up like this out.";
            }

			if (Main.eclipse && Main.rand.NextBool(8))
			{
				return "I was born under the devoured star! Mama told me it's what made me special.";
			}

            List<string> dialogue = new List<string>
            {
                "I like not dealing with the King. He kept trying to crush me for talking back. Or, y'know, talking at all.",
                $"Greetings, {Main.LocalPlayer.name}! Might I interest you in a purchase?",
                "Hey, friend! What'll it be?",
                "Do take your time before you get goo-ing...",
                $"I'm not a bad slime! Oh, it's you, {Main.LocalPlayer.name}. Thought I'd get shot again.",
                "I appreciate you letting me move in. The other slimes didn't like me.",
                "What's having organs like?",
                "Do you ever look out, into the sky, and wonder how important you are? Well, don't. You're amazing.",
                "You're back! I was bouncing in anticipation for you to come back!",
                "The surface is so bright. I'll never get used to it.",
                "Lovely day, isn't it?",
                "Sometimes, I just wait and stare out into the distance.",
                "Sitting without proper anatomy is...not easy.",
                "I'm a jolly bowl of jelly, and I represent cheer!",
                "Durran? Who's that?",
				"Did you know? Pink is proven to make people less angry! Just look into my eyes, and feel happy.",
				$"Hey {Main.LocalPlayer.name}, can you tell me ",
            };

            int angler = NPC.FindFirstNPC(NPCID.Angler);
            if (angler != -1)
            {
                dialogue.Add($"Please tell {Main.npc[angler].GivenName} that I'm not bait. Hooks DO still hurt me, you know!");
            }

			int dyetrader = NPC.FindFirstNPC(NPCID.DyeTrader);
            if (dyetrader != -1)
            {
                dialogue.Add("I am not to be used in dyes! Keep the psycho with the vat away from me!");
                dialogue.Add($"Sorry, I got in a fight with {Main.npc[dyetrader].GivenName} again. He insists I'm worth more as a dye than as a shopkeeper.");
            }

			int painter = NPC.FindFirstNPC(NPCID.Painter);
            if (painter != -1)
            {
                dialogue.Add($"I need to ask {Main.npc[painter].GivenName} to paint the sunflowers at some point for me. I like looking at them.");
                dialogue.Add($"You don't think {Main.npc[painter].GivenName} will make me into pink paint, right...?");
            }

            return Main.rand.Next(dialogue);
        }

		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Salve"; //Buffs with unique text for each!
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                SlimeBuff();
            }
        }

		public static void AddItem(bool check, int item, int price, ref Chest shop, ref int nextSlot)
        {
            if (check) //Deviantt code works to tell me where to un-screw up the code.
            {
                shop.item[nextSlot].SetDefaults(item);
                shop.item[nextSlot].shopCustomPrice = price;
                nextSlot++;
            }
        }

		public override void SetupShop(Chest shop, ref int nextSlot) {
			AddItem(true, ItemID.Gel, Item.buyPrice(0, 0, 0, 30), ref shop, ref nextSlot);
			AddItem(true, ItemID.PinkGel, Item.buyPrice(0, 0, 20, 0), ref shop, ref nextSlot);
		}

		public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ItemID.PinkGel, Main.rand.Next(20, 40));
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue) {
			return true;
		}

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
		public override void OnGoToStatue(bool toKingStatue) {
			StatueTeleport();
		}

		// Create a square of pixels around the NPC on teleport.
		public void StatueTeleport() {
			for (int i = 0; i < 30; i++) {
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y)) {
					position.X = Math.Sign(position.X) * 20;
				}
				else {
					position.Y = Math.Sign(position.Y) * 20;
				}
				Dust.NewDustPerfect(npc.Center + position, DustID.PinkSlime, Vector2.Zero).noGravity = true;
			}
		}

		private void SlimeBuff()
        {
            Player slimyplayer = Main.LocalPlayer;

            if (!SlimeBuffYes)
            {
                Main.npcChatText = "This world looks tougher than usual, so you can have these on the house just this once! Talk to me if you need any tips, yeah?";
                return;
            }
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			if (NPC.downedMoonlord)
            {
                damage = 72;
                knockback = 9f;
            }
            else if (Main.hardMode)
            {
                damage = 43;
                knockback = 5f;
            }
			else if (NPC.downedBoss3)
			{
				damage = 25;
				knockback = 4f;
			}
            else
            {
                damage = 10;
                knockback = 2f;
            }
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileType<Projectiles.Friendly.TownNPC.PinkSlimeBallNPC>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
*/
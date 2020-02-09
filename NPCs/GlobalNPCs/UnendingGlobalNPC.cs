using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Unending.Projectiles;
using Unending.Projectiles.GlobalProjectiles;
using static Terraria.ModLoader.ModContent;

namespace Unending.NPCs.GlobalNPCs
{
	public class UnendingGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		#region Enemy buffs
		public bool crierhall = false;
		#endregion
		#region Important swapping things, to ensure all enemy types are available in Mayhem Mode
		public bool FirstTick = false;
		#endregion
		#region Enemy Mayhem shenanigans
		public int timerMayhemAttack1;
		public int MayhemReverseCounter = 0;
		public int Stop = 0;
		//START: Cultist Life checks for messages
		public bool CultistBossLifeMark1;
		public bool CultistBossLifeMark2;
		public bool CultistBossLifeMark3;
		public bool CultistBossLifeMark4;
		//END: Cultist Life checks for messages
		#endregion
		public override void SetDefaults(NPC npc)
		{
			if(UnendingWorld.MayhemMode)
			{
				if(npc.boss == false)
				{
					npc.value *= 1.3f;
				}

				switch(npc.type) //Here we have various variables switched based on Mayhem Mode changes. For example, Plantera tendrils become tankier!
				{
					case NPCID.FlyingSnake:
						npc.trapImmune = true;
						MayhemReverseCounter++;
						break;

					#region Golem. Let's make him actually tough!
					case NPCID.GolemHead:
						npc.lifeMax *= 2;
						timerMayhemAttack1 = 3600;
						timerMayhemAttack1--;
						break;
					case NPCID.GolemHeadFree:
						timerMayhemAttack1 = 3600;
						timerMayhemAttack1--;
						break;
					case NPCID.Golem:
						timerMayhemAttack1 = 7200;
						timerMayhemAttack1--;
						break;
					#endregion

					#region Wall of Flesh hopefully?
					case NPCID.WallofFlesh:
						npc.defense *= 3;
						break;
					case NPCID.WallofFleshEye:
						npc.defense += 10;
						break;
					case NPCID.TheHungry:
						npc.knockBackResist = 0f;
						npc.buffImmune[BuffID.Ichor] = true;
						npc.buffImmune[BuffID.Poisoned] = true;
						npc.buffImmune[BuffID.OnFire] = true;
						npc.buffImmune[BuffID.CursedInferno] = true;
						break;
					case NPCID.TheHungryII:
						npc.noTileCollide = true;
						npc.buffImmune[BuffID.Ichor] = true;
						npc.buffImmune[BuffID.OnFire] = true;
						npc.buffImmune[BuffID.Poisoned] = true;
						npc.buffImmune[BuffID.CursedInferno] = true;
						npc.knockBackResist = 0f;
						break;
					case NPCID.LeechHead:
						npc.lifeMax *= 3;
						goto case NPCID.LeechTail;
					case NPCID.LeechBody:
					case NPCID.LeechTail:
						npc.buffImmune[BuffID.Ichor] = true;
						npc.buffImmune[BuffID.OnFire] = true;
						npc.buffImmune[BuffID.Poisoned] = true;
						npc.buffImmune[BuffID.CursedInferno] = true;
						break;
					#endregion

					#region Lunatic Cultist boss fight
					case NPCID.AncientLight:
						npc.lifeMax = 200;
						npc.defense = 20;
						npc.chaseable = true;
						break;

					case NPCID.AncientCultistSquidhead:
						MayhemReverseCounter++;
						npc.lifeMax /= 2;
						break;

					case NPCID.CultistDragonHead:
						npc.lifeMax *= 2;
						npc.damage *= (int)2.5;
						npc.defense = 0;
						break;

					case NPCID.CultistDragonBody1:
					case NPCID.CultistDragonBody2:
					case NPCID.CultistDragonBody3:
					case NPCID.CultistDragonBody4:
					case NPCID.CultistDragonTail:
						npc.defense = 999999999;
						npc.damage *= (int)1.5;
						break;


					case NPCID.AncientDoom:
						npc.lifeMax = 9;
						npc.defense = 99999;
						npc.chaseable = true;
						break;

					case NPCID.CultistBoss:
						npc.damage = 67;
						npc.defense *= 2;
						break;
					#endregion

					#region Plantera boss fight
					case NPCID.PlanterasTentacle:
						npc.lifeMax *= 2;
						npc.buffImmune[BuffID.OnFire] = true;
						npc.buffImmune[BuffID.Ichor] = true;
						npc.buffImmune[BuffID.CursedInferno] = true;
						npc.knockBackResist = 0f;
						break; 

					case NPCID.Spore:
						npc.dontTakeDamage = true;
						break;

					case NPCID.Plantera:
						if (npc.life > (int)(npc.lifeMax / 2))
						{
							npc.defense *= 2;
						}
						break;

					case NPCID.PlanterasHook:
						npc.damage *= 2;
						break;

                    #endregion
                    case NPCID.EnchantedSword:
					case NPCID.CursedHammer:
					case NPCID.CrimsonAxe:
						npc.lifeMax *= 2;
						if (npc.life >= npc.lifeMax * (int)0.4)
						{
							npc.knockBackResist = 0f;
						}
						else
						{
							npc.knockBackResist = 0.2f;
						}
						break;

					case NPCID.AngryBones:
					case NPCID.AngryBonesBig:
					case NPCID.AngryBonesBigHelmet:
					case NPCID.AngryBonesBigMuscle:
						npc.trapImmune = true;
						break;

					case NPCID.DungeonSlime:
						npc.trapImmune = true;
						npc.lifeMax *= (int)1.1;
						break;

					case NPCID.DoctorBones:
						npc.buffImmune[BuffID.Poisoned] = true;
						npc.buffImmune[BuffID.Venom] = true;
						npc.buffImmune[mod.BuffType("Snakebite")] = true;
						npc.lifeMax *= 3;
						npc.damage *= 2;
						break;

					case NPCID.Eyezor:
						npc.buffImmune[BuffID.Poisoned] = true;
						npc.buffImmune[BuffID.Venom] = true;
						npc.buffImmune[BuffID.Confused] = true;
						npc.lifeMax *= 3;
						break;

					case NPCID.ArmedZombieEskimo:
					case NPCID.ZombieEskimo:
						npc.buffImmune[BuffID.Chilled] = true;
						npc.buffImmune[BuffID.Frozen] = true;
						npc.buffImmune[BuffID.Frostburn] = true;
						break;
                }
            }
		}

		public override bool PreAI(NPC npc)
		{
			if (Stop > 0)
			{
				Stop--;
			}

			if (UnendingWorld.MayhemMode == true)
			{
				timerMayhemAttack1--;
				if (!FirstTick)
				{
					switch (npc.type) //Enemy swapping for Mayhem Mode. Altered from Fargo's Mutant Mod code.
					{
						case NPCID.BlueSlime:
							switch (npc.netID)
							{
								case NPCID.GreenSlime:
									if (Main.hardMode && Main.rand.Next(5) == 0)
									{
										npc.Transform(NPCID.HoppinJack);
									}
									break;
								case NPCID.BlueSlime:
									break;
							}
							break;

						case NPCID.Crawdad:
						case NPCID.GiantShelly:
							if (Main.rand.Next(8) == 0) //pick a random salamander
								npc.Transform(Main.rand.Next(498, 507));
							npc.buffImmune[BuffID.Confused] = true;
							npc.buffImmune[BuffID.Poisoned] = true;
							break;

						case NPCID.Salamander:
						case NPCID.Salamander2:
						case NPCID.Salamander3:
						case NPCID.Salamander4:
						case NPCID.GiantShelly2:
							if (Main.rand.Next(8) == 0) //pick a random crawdad
								npc.Transform(Main.rand.Next(494, 496));
							npc.buffImmune[BuffID.Confused] = true;
							npc.buffImmune[BuffID.Poisoned] = true;
							break;

						case NPCID.Salamander5:
						case NPCID.Salamander6:
						case NPCID.Salamander7:
						case NPCID.Salamander8:
						case NPCID.Crawdad2:
							if (Main.rand.Next(8) == 0) //pick a random shelly
								npc.Transform(Main.rand.Next(496, 498));
							npc.buffImmune[BuffID.Confused] = true;
							npc.buffImmune[BuffID.Poisoned] = true;
							break;

						case NPCID.BlackSlime:
							if (Main.hardMode == true)
							{
								if (Main.rand.Next(8) == 0)
								{
									npc.Transform(NPCID.ToxicSludge);
								}
							}
							else
							{
								if (Main.rand.Next(20) == 0)
								{
									npc.Transform(NPCID.ToxicSludge);
								}
							}
							break;

						case NPCID.EaterofSouls:
							if (Main.rand.Next(8) == 0 && Main.hardMode)
							{
								npc.Transform(NPCID.IchorSticker);
							}
							break;

						case NPCID.Crimera:
							if (Main.rand.Next(8) == 0 && Main.hardMode)
							{
								npc.Transform(NPCID.SeekerHead);
							}
							break;
					}
				}
				FirstTick = true;
				switch (npc.type)
				{
					case NPCID.FlyingSnake:
						if (++MayhemReverseCounter >= 300)
						{
							Shoot(npc, 30, 500, 10, ProjectileID.SpikyBallTrap, 40, 1, 1);
						}
						break;
					#region The correct place for Lunatic Cultist stuff
					case NPCID.AncientCultistSquidhead:
						if (NPC.AnyNPCs(NPCID.CultistDragonHead))
						{
							npc.dontTakeDamage = true;
						}
						else
						{
							npc.dontTakeDamage = false;
						}
						if (++MayhemReverseCounter >= 150)
						{
							Shoot(npc, 30, 0, 10, ProjectileID.CultistBossFireBall, 90, 1, 1);
						}
						break;


					//HOO BOY, let's get on with this!
					case NPCID.CultistBoss:
						MayhemReverseCounter++;
						if (npc.life <= npc.lifeMax * 0.75 && CultistBossLifeMark1 == false)
						{
							Main.NewText("The Cultist calls upon the fury of the sun!", 255, 94, 0);
							CultistBossLifeMark1 = true;
						}
						if(npc.life <= npc.lifeMax * 0.5 && CultistBossLifeMark2 == false)
						{
							Main.NewText("The Cultist calls upon the warping vortex of space!", 0, 205, 130);
							CultistBossLifeMark2 = true;
						}
						if (npc.life <= npc.lifeMax * 0.3 && CultistBossLifeMark3 == false)
						{
							Main.NewText("The Cultist calls upon the ever-shifting nebula!", 196, 35, 180);
							CultistBossLifeMark3 = true;
						}
						if (npc.life <= npc.lifeMax * 0.2 && CultistBossLifeMark4 == false)
						{
							Main.NewText("The Cultist calls upon the echoes of stardust!", 73, 219, 255);
							CultistBossLifeMark4 = true;
						}
						if (++MayhemReverseCounter >= 1800)
						{
							if (CultistBossLifeMark1 == true)
							{
								if (Main.netMode != 1 && npc.HasPlayerTarget)
								{
									Vector2 distance = Main.player[npc.target].Center - npc.Center;
									distance.Normalize();
									distance *= 16f;
									int type = mod.ProjectileType("SolarProphecy");
									Projectile.NewProjectile(npc.Center, distance.RotatedBy(Main.rand.NextFloat(-30, 30)), type, 112, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, distance.RotatedBy(Main.rand.NextFloat(-30, 30)), type, 112, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, distance.RotatedBy(Main.rand.NextFloat(-30, 30)), type, 112, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, distance.RotatedBy(Main.rand.NextFloat(-30, 30)), type, 112, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, distance.RotatedBy(Main.rand.NextFloat(-30, 30)), type, 112, 0f, Main.myPlayer);
								}
							}
							MayhemReverseCounter = 0;
						}
						break;


						#endregion
						#region Wall of Flesh!

						#endregion
				}
            }
			return true;
		}

		public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
		{
			if (UnendingWorld.MayhemMode)
			{
				switch (npc.type)
				{
					case NPCID.WalkingAntlion:
						target.AddBuff(BuffID.Bleeding, 900);
						break;
                    #region Plantera fight
                    case NPCID.Plantera:
						target.AddBuff(BuffID.Poisoned, 300);
						if (npc.life < (int)(npc.lifeMax / 2))
						{
							target.AddBuff(mod.BuffType("Junglebite"), 900);
						}
						break;
					case NPCID.PlanterasTentacle:
						target.AddBuff(mod.BuffType("Junglebite"), 90);
						break;
					#endregion
					case NPCID.GraniteGolem:
						target.AddBuff(BuffID.BrokenArmor, 3600);
						if (target.HasBuff(BuffID.Ironskin))
							{
							target.DelBuff(BuffID.Ironskin);
						}
						if (target.HasBuff(BuffID.Endurance))
							{
							target.DelBuff(BuffID.Endurance);
						}
						break;
                    case NPCID.Werewolf:
						if (NPC.downedMechBossAny == true)
						{
							target.AddBuff(BuffID.MoonLeech, 3600);
						}
						if (target.HasBuff(BuffID.WellFed))
						{
							target.DelBuff(BuffID.WellFed);
						}
						if (target.HasBuff(BuffID.Regeneration))
						{
							target.DelBuff(BuffID.Regeneration);
						}
						if (target.HasBuff(BuffID.RapidHealing))
						{
							target.DelBuff(BuffID.RapidHealing);
						}
						break;

					case NPCID.CultistDragonHead:
						target.AddBuff(BuffID.BrokenArmor, 1800);
						goto case NPCID.CultistDragonTail;

					case NPCID.CultistBoss:
					case NPCID.CultistBossClone:
					case NPCID.CultistDragonBody1:
					case NPCID.CultistDragonBody2:
					case NPCID.CultistDragonBody3:
					case NPCID.CultistDragonBody4:
					case NPCID.CultistDragonTail:
						target.AddBuff(BuffID.MoonLeech, 3600);
						break;

					case NPCID.AncientDoom:
						target.AddBuff(BuffID.Slow, 300);
						goto case NPCID.CultistDragonTail;

				}
			}
		}

		public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			if (UnendingWorld.MayhemMode)
			{
				switch (npc.type)
				{
                    #region Cultist minions
                    case NPCID.AncientDoom:
						damage = 1;
						crit = false;
						break;
					case NPCID.CultistDragonHead:
						damage *= 6;
						break;
					case NPCID.CultistDragonBody1:
					case NPCID.CultistDragonBody2:
					case NPCID.CultistDragonBody3:
					case NPCID.CultistDragonBody4:
					case NPCID.CultistDragonTail:
						damage /= 3;
						break;
						#endregion
				}
            }
		}
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (UnendingWorld.MayhemMode)
			{
				switch (npc.type)
				{
                    #region more cultist stuff
                    case NPCID.AncientDoom:
						damage = 1;
						crit = false;
						break;
					case NPCID.CultistDragonHead:
						damage *= 3;
						break;
					case NPCID.CultistDragonBody1:
					case NPCID.CultistDragonBody2:
					case NPCID.CultistDragonBody3:
					case NPCID.CultistDragonBody4:
					case NPCID.CultistDragonTail:
						damage /= 3;
						break;
						#endregion
				}
            }
		}

		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.DoctorBones && UnendingWorld.MayhemMode == true)
			{
				Item.NewItem(npc.getRect(), ItemID.ArchaeologistsJacket, 1);
				Item.NewItem(npc.getRect(), ItemID.ArchaeologistsPants, 1);
			}
			if (npc.type == NPCID.SantaNK1)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Materialis.Loot.Hardmode.FrostMoon.ElfMetal>(), Main.rand.Next(30, 70));
			}
			if (npc.type == NPCID.ElfCopter)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Materialis.Loot.Hardmode.FrostMoon.ElfMetal>(), Main.rand.Next(2, 6));
			}
			if (npc.type == NPCID.Everscream)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Materialis.Loot.Hardmode.FrostMoon.PineWood>(), Main.rand.Next(30, 50));
			}
			if (npc.type == NPCID.ZombieElf)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Materialis.Loot.Hardmode.FrostMoon.PineWood>(), Main.rand.Next(1, 3));
			}
			if (npc.type == NPCID.ZombieElfBeard)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Materialis.Loot.Hardmode.FrostMoon.PineWood>(), Main.rand.Next(1, 3));
			}
			if (npc.type == NPCID.ZombieElfGirl)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Materialis.Loot.Hardmode.FrostMoon.PineWood>(), Main.rand.Next(1, 3));
			}
			if (npc.type == NPCID.ElfArcher)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Materialis.Loot.Hardmode.FrostMoon.PineWood>(), Main.rand.Next(2, 5));
			}
			if (npc.type == NPCID.Tumbleweed)
			{
				if (Main.rand.Next(200) == 0)
				{
					Item.NewItem(npc.getRect(), ItemID.SandstorminaBottle, 1);
				}
			}
			if (npc.type == NPCID.FlyingAntlion)
			{
				if (Main.rand.Next(200) == 0)
				{
					Item.NewItem(npc.getRect(), ItemID.SandstorminaBottle, 1);
				}
			}
			if (npc.type == NPCID.TombCrawlerHead)
			{
				if (Main.rand.Next(200) == 0)
				{
					Item.NewItem(npc.getRect(), ItemID.SandstorminaBottle, 1);
				}
			}
		}
		private void Shoot(NPC npc, int delay, float distance, int speed, int proj, int dmg, float kb, int recoloring, bool hostile = false)
		{
			int t = npc.HasPlayerTarget ? npc.target : npc.FindClosestPlayer();
			if (t == -1)
				return;

			Player player = Main.player[t];
			//npc facing player target or if already started attack
			if (player.active && !player.dead && npc.direction == (Math.Sign(player.position.X - npc.position.X)) || Stop > 0)
			{
				//start the pause
				if (delay != 0 && Stop == 0)
				{
					Stop = delay;
				}
				//half way through start attack
				else if (delay == 0 || Stop == delay / 2)
				{
					Vector2 velocity = Vector2.Normalize(player.Center - npc.Center) * speed;
					if (npc.Distance(player.Center) < distance)
						velocity = Vector2.Normalize(player.Center - npc.Center) * speed;
					else //player too far away now, just shoot straight ahead
						velocity = new Vector2(npc.direction * speed, 0);

					int p = Projectile.NewProjectile(npc.Center, velocity, proj, dmg, kb, Main.myPlayer);
					if (p < 1000)
					{
						if (recoloring > 0)
						{
							Main.projectile[p].GetGlobalProjectile<UnendingGlobalProjectile>().Recolor = recoloring;
							Main.projectile[p].GetGlobalProjectile<UnendingGlobalProjectile>().Recolored = true;
						}
						if (hostile)
						{
							Main.projectile[p].friendly = false;
							Main.projectile[p].hostile = true;
						}
					}
					MayhemReverseCounter = 0;
				}
			}
		}
	}
}
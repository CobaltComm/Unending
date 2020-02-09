using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using Unending.Projectiles;
using Unending.Projectiles.Friendly.Armor;

namespace Unending
{
    public class UnendingPlayer : ModPlayer
    {

        #region Conduit Variables
        public float energyDamageAdd;
        public float energyDamageMult = 1f;
        public float energyKnockback;
        public int energyCrit;
        // Creating some variables to define the current value of our example resource as well as the maximum value.
        // maximumResource2 will act as our own "statMaxLife2" for temporary changes to the maximum.
        // Make sure to set these as floats if you want to have a resource bar for it.
        public float currentOverdrive;
        public float maximumOverdrive = 100;
        public float maximumOverdrive2;
        // You can make something like this to easily refer to a combination of both, instead of adding them together every time.
        public float OverallMaximumOverdrive { get => maximumOverdrive + maximumOverdrive2; }
        public float overdriveDecreaseRate;
        internal int overdriveDecreaseTimer = 0;
        public bool overdriven;
        #endregion

        #region Armor Sets
        public bool SantankSet;
        public int SantankTimer;
        public bool PineSet;
        public bool VentureSet;
        #region Sanguine Hate
        public bool IchorArmorMelee;
        public bool IchorArmorRanged;
        public bool IchorArmorMagic;
        public bool IchorArmorSummon;
        public bool IchorSummonSet;
        #endregion
        #endregion

        #region Accessory variables
        public bool mirrorShield;
        #endregion

        #region Consumables
        public bool MoonInject;
        #endregion

        #region Mayhem accessories
        public bool laserEye;
        #region Slime Vials and other slimy accessories
        public bool SlimePurple;
        public bool SlimeScroll;
        public bool SlimeLightning;
        public int SlimePurpleTimer;
        #endregion
        #endregion

        #region Debuffs
        public bool Junglebite;
        #endregion

        public override void ResetEffects()
        {
            #region Armor set effects
            SantankSet = false;
            SantankTimer -= 1;
            if (SantankTimer < 0)
            {
                SantankTimer = 0;
            }
            PineSet = false;
            VentureSet = false;
            #region Sanguine Hate set
            IchorArmorMagic = false;
            IchorArmorMelee = false;
            IchorArmorRanged = false;
            IchorArmorSummon = false;
            IchorSummonSet = false;
            #endregion
            #endregion
            #region normal accessories
            mirrorShield = false;
            #endregion
            #region Mayhem Accessories
            laserEye = false;
            SlimeScroll = false;
            SlimeLightning = false;
            SlimePurple = false;
            SlimePurpleTimer -= 1;
            if (SlimePurpleTimer < 0)
            {
                SlimePurpleTimer = 0;
            }
            #endregion
            #region Mayhem debuffs
            Junglebite = false;
            #endregion
            #region Custom class
            UpdateOverdrive();
            #endregion
        }

        public override void UpdateDead()
        {
            #region debuff reset
            Junglebite = false;
            overdriven = false;
            #endregion
            #region timer resets
            SlimePurpleTimer = 120;
            #endregion
        }
        private void UpdateOverdrive()
        {

            // Limit the currentResource from going over the limit imposed by your maximumResource's.
            if (currentOverdrive > OverallMaximumOverdrive)
            {
                overdriven = true;
            }
            else
            {
                overdriven = false;
            }
            //Simple stuff, overdriveDecreaseTimer increases rapidly.
            overdriveDecreaseTimer++; //Increase it by 60 per second, or 1 per tick.

            if ((overdriveDecreaseTimer > 180 * overdriveDecreaseRate) && currentOverdrive > OverallMaximumOverdrive)
            {
                currentOverdrive -= 1;
                overdriveDecreaseTimer = 0;
            }
            if (currentOverdrive > 0)
                currentOverdrive = 0;
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)player.whoAmI);
            packet.Write(MoonInject);
            packet.Send(toWho, fromWho);
        }

        // Note that all the SyncPlayer and other Compound stuff is based WHOLLY on ExampleMod so it's probably not usable. Let's find out!
        public override void Load(TagCompound tag)
        {
            MoonInject = (tag.GetBool("MoonInject"));
        }

        public override TagCompound Save()
        {
            // Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
            return new TagCompound {
                {"MoonInject", MoonInject},
            };
            //note that C# 6.0 supports indexer initializers
            //return new TagCompound {
            //	["score"] = score
            //};
        }

        public override void UpdateBadLifeRegen()
        {
            if (overdriven)
            {
                if (player.lifeRegen > 0)
                    player.lifeRegen = 0;
                player.lifeRegenTime = 0;
                player.lifeRegen -= 15;
            }
            if (player.HasBuff(BuffID.MoonLeech) && UnendingWorld.MayhemMode == true)
            {
                if (player.lifeRegen > 0)
                    player.lifeRegen = 0;
                player.lifeRegenTime = 0;
                player.lifeRegen -= 25;
            }
        }

        public override void PostUpdateMiscEffects()
        {
            #region Mayhem items!
            if (SlimeScroll == true)
            {
                player.meleeDamage *= 1.2f;
                player.rangedDamage *= 1.2f;
                player.magicDamage *= 1.2f;
                player.minionDamage *= 1.2f;
                player.thrownDamage *= 1.2f;
                this.energyDamageAdd *= 1.2f;
                player.moveSpeed *= 1.1f;
            }
            if (SlimePurple == true)
            {
                player.buffImmune[BuffID.Venom] = true;
            }
            if (SlimeLightning == true)
            {
                player.buffImmune[BuffID.Electrified] = true;
                if (player.ZoneSkyHeight == true)
                {
                    player.meleeDamage *= 1.2f;
                    player.rangedDamage *= 1.2f;
                    player.magicDamage *= 1.2f;
                    player.minionDamage *= 1.2f;
                    player.thrownDamage *= 1.2f;
                    this.energyDamageAdd *= 1.2f;
                }
            }
            #endregion
            if (MoonInject == true)
            {
                player.buffImmune[BuffID.MoonLeech] = true;
            }
            if (mirrorShield == true)
            {
                player.noKnockback = true;
                player.buffImmune[BuffID.Stoned] = true;
                player.buffImmune[BuffID.Frostburn] = true;
                player.buffImmune[BuffID.OnFire] = true;
                player.buffImmune[BuffID.Chilled] = true;
                player.buffImmune[BuffID.Frozen] = true;
            }
            #region debuffs
            if (Junglebite == true)
            {
                player.statDefense -= 35;
            }
            #endregion
        }

        public static UnendingPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<UnendingPlayer>();
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (item.melee == true && SlimePurple == true && SlimePurpleTimer == 0)
            {
                int slimeType = mod.ProjectileType("PurpleSlimeBall");
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, -1, slimeType, (int)(damage * 0.5), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 1, 1, slimeType, (int)(damage * 0.5), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -1, 1, slimeType, (int)(damage * 0.5), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 1, slimeType, (int)(damage * 0.5), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 1, -1, slimeType, (int)(damage * 0.5), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -1, -1, slimeType, (int)(damage * 0.5), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -1, 0, slimeType, (int)(damage * 0.5), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 1, 0, slimeType, (int)(damage * 0.5), 1f, player.whoAmI);
                SlimePurpleTimer = 60;
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (SantankSet == true)
                if (proj.ranged && SantankTimer == 0)
                {
                    SantankTimer = 60;
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, -5, ProjectileID.RocketSnowmanI, 45, 0f, player.whoAmI);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 3, 2, ProjectileID.RocketSnowmanI, 45, 0f, player.whoAmI);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -3, 2, ProjectileID.RocketSnowmanI, 45, 0f, player.whoAmI);
                }
            else
                {}
            if (VentureSet == true)
            {
                if (proj.magic)
                {
                    target.AddBuff(mod.BuffType("Snakebite"), 30 * Main.rand.Next(4, 8), false);
                }
            }
            if (proj.melee == true && SlimePurple == true && SlimePurpleTimer == 0)
            {
                int slimeType = mod.ProjectileType("PurpleSlimeBall");
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, -1, slimeType, (int)(damage * 0.25), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 1, 1, slimeType, (int)(damage * 0.25), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -1, 1, slimeType, (int)(damage * 0.25), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 1, slimeType, (int)(damage * 0.25), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 1, -1, slimeType, (int)(damage * 0.25), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -1, -1, slimeType, (int)(damage * 0.25), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -1, 0, slimeType, (int)(damage * 0.25), 1f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 1, 0, slimeType, (int)(damage * 0.25), 1f, player.whoAmI);
                SlimePurpleTimer = 60;
            }
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (PineSet == true)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 1, -3, ProjectileID.OrnamentFriendly, 60, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 4, 6, ProjectileID.OrnamentFriendly, 60, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -2, 1, ProjectileID.OrnamentFriendly, 60, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 3, -4, ProjectileID.OrnamentFriendly, 60, 3f, player.whoAmI);
            }
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {

            if (PineSet == true)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-6, 6), Main.rand.Next(-6, 6), ProjectileID.OrnamentFriendly, 60, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-6, 6), Main.rand.Next(-6, 6), ProjectileID.OrnamentFriendly, 60, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-6, 6), Main.rand.Next(-6, 6), ProjectileID.OrnamentFriendly, 60, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-6, 6), Main.rand.Next(-6, 6), ProjectileID.OrnamentFriendly, 60, 3f, player.whoAmI);
            }
            if (mirrorShield == true)
            {
                // almost entirely ripped and modified from Fargo's Soul Mod. All credit goes to Fargowiltas (see Hallowed Enchantment)
                const int focusRadius = 15;

                if (Math.Abs(player.velocity.X) < .001f && Math.Abs(player.velocity.Y) < .001f)
                {
                    for (int i = 0; i < 25; i++)
                    {
                        //This produces the blue circle around the player when hit and capable of reflecting
                        Vector2 offset = new Vector2();
                        double angle = Main.rand.NextDouble() * 2d * Math.PI;
                        offset.X += (float)(Math.Sin(angle) * focusRadius);
                        offset.Y += (float)(Math.Cos(angle) * focusRadius);
                        Dust dust = Main.dust[Dust.NewDust(
                                player.Center + offset - new Vector2(4, 4), 0, 0,
                                DustID.Ice, 0, 0, 100, Color.White, 1f
                                )];
                        dust.velocity = player.velocity;
                        dust.noGravity = true;
                    }
                }

                float distance = 3f * 16;

                Main.projectile.Where(x => x.active && x.hostile).ToList().ForEach(x =>
                {
                    if ((Math.Abs(player.velocity.X) < .001f && Math.Abs(player.velocity.Y) < .001f) && Vector2.Distance(x.Center, player.Center) <= distance)
                    {
                        // Changes the projectile to be "owned" by the player.
                        x.hostile = false;
                        x.friendly = true;
                        x.owner = player.whoAmI;

                        // Reverses the direction of the projectile
                        x.velocity *= -1f;

                        // Reverses the sprite of the projectile
                        if (x.Center.X > player.Center.X * 0.5f)
                        {
                            x.direction = 1;
                            x.spriteDirection = 1;
                        }
                        else
                        {
                            x.direction = -1;
                            x.spriteDirection = -1;
                        }
                    }
                });
            }
        }

        public void IchorSummonEffect()
        {
            IchorSummonSet = true;

            if (player.ownedProjectileCounts[mod.ProjectileType("IchorShield")] == 0)
            {
                const int max = 3;
                float rotation = 2f * (float)Math.PI / max;

                for (int i = 0; i < max; i++)
                {
                    Vector2 spawnPos = player.Center + new Vector2(60, 0f).RotatedBy(rotation * i);
                    Projectile.NewProjectile(spawnPos, Vector2.Zero, mod.ProjectileType("IchorShield"), 30, 0f, player.whoAmI, 0, rotation * i);
                }
            }
        }
    }
}

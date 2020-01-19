using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Unending.NPCs;
using Unending.NPCs.GlobalNPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unending.Projectiles.GlobalProjectiles
{
    public class UnendingGlobalProjectile : GlobalProjectile
    {
        #region "Recolor" fields
        public bool Recolored = false;
        public int Recolor;
        #endregion
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public override void SetDefaults(Projectile projectile)
        {



            if (UnendingWorld.MayhemMode)
            {
                switch (projectile.type)
                {
                    case ProjectileID.EyeLaser:
                        projectile.tileCollide = false;
                        break;

                    case ProjectileID.CultistBossFireBall:
                        projectile.tileCollide = false;
                        if (Recolor == 1)
                        {
                            projectile.Name = "Guardian's Flame";
                        }
                            break;
                    case ProjectileID.SpikyBallTrap:
                        if (Recolor == 1)
                        {
                            projectile.Name = "Snake Spikeball";
                        }
                        break;
                    case ProjectileID.CultistBossFireBallClone:
                        projectile.tileCollide = false;
                        break;
                }
            }
        }
        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if (UnendingWorld.MayhemMode)
            {
                switch (projectile.type)
                {
                    case ProjectileID.CultistBossFireBall:
                        if (Recolor == 0)
                        {
                            target.AddBuff(BuffID.BrokenArmor, 300);
                            target.AddBuff(BuffID.MoonLeech, 3600);
                        }
                        if (Recolor == 1)
                        {
                            projectile.Name = "Guardian's Flame";
                            target.AddBuff(BuffID.PotionSickness, 900);
                        }
                        break;
                    case ProjectileID.CultistBossFireBallClone:
                        target.AddBuff(BuffID.BrokenArmor, 300);
                        target.AddBuff(BuffID.MoonLeech, 3600);
                        break;
                    case ProjectileID.SpikyBallTrap:
                        if (Recolor == 1)
                        {
                            projectile.Name = "Snake Spikeball";
                            target.AddBuff(BuffID.Bleeding, 300);
                        }
                        break;
                    case ProjectileID.AncientDoomProjectile:
                        target.AddBuff(BuffID.Slow, 900);
                        target.AddBuff(BuffID.MoonLeech, 3600);
                        break;
                    case ProjectileID.CultistBossIceMist:
                        target.AddBuff(BuffID.Chilled, 900);
                        target.AddBuff(BuffID.MoonLeech, 3600);
                        break;
                }
            }
        }
        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
            if (Recolored)
            {
                if (projectile.type == ProjectileID.CultistBossFireBall)
                {
                    if (Recolor == 1)
                    {
                        projectile.Name = "Guardian's Flame";
                        return Color.Aquamarine;
                    }
                }
                if (projectile.type == ProjectileID.SpikyBallTrap)
                {
                    if (Recolor == 1)
                    {
                        projectile.Name = "Snake Spikeball";
                        return Color.Purple;
                    }
                }
            }
            return null;
        }
    }
}
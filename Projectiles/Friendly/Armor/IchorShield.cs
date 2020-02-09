using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unending.Projectiles.Friendly.Armor
{
    public class IchorShield : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ichor Shield Sphere");
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.damage = 30;
            projectile.knockBack = 0f;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            UnendingPlayer modPlayer = player.GetModPlayer<UnendingPlayer>();

            if (player.dead || !modPlayer.IchorSummonSet)
            {
                modPlayer.IchorArmorSummon = false;
                projectile.Kill();
                return;
            }

            float num395 = Main.mouseTextColor / 200f - 0.35f;
            num395 *= 0.2f;
            projectile.scale = num395 + 0.95f;

            if (projectile.owner == Main.myPlayer)
            {
                //Rotation!
                float distanceFromPlayer = 70;

                Lighting.AddLight(projectile.Center, 0.0f, 0.4f, 0.4f);

                projectile.position = player.Center + new Vector2(distanceFromPlayer, 0f).RotatedBy(projectile.ai[1]);
                projectile.position.X -= projectile.width / 2;
                projectile.position.Y -= projectile.height / 2;
                float rotation = 0.03f;
                projectile.ai[1] -= rotation;
                if (projectile.ai[1] > (float)Math.PI)
                {
                    projectile.ai[1] -= 2f * (float)Math.PI;
                    projectile.netUpdate = true;
                }
                projectile.rotation = projectile.ai[1] + (float)Math.PI / 2f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 120);
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AAMod.Projectiles
{
    public class CursedFirebolt : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_103";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Firebolt");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.CursedArrow);
            aiType = ProjectileID.CursedArrow;
            projectile.extraUpdates = 2;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 300);
        }

        public override void Kill(int timeleft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            for (int num468 = 0; num468 < 4; num468++)
            {
                num468 = Dust.NewDust(new Microsoft.Xna.Framework.Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, DustID.Fire, -projectile.velocity.X * 0.2f,
                    -projectile.velocity.Y * 0.2f, 100, Color.Lime);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Projectiles.MayhemHostile
{
    public class SolarProphecy : ModProjectile
    {
		public override string Texture => "Terraria/Projectile_" + ProjectileID.CursedFlameHostile;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Prophecy");
        }

		public override void SetDefaults()
		{
			aiType = ProjectileID.CultistBossFireBall;
			projectile.alpha = 50;
			projectile.width = 30;
			projectile.height = 30;
			projectile.timeLeft = 900;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.frameCounter = 4;
		}
		public override void AI()
		{
			projectile.tileCollide = false;
			Lighting.AddLight(projectile.Center, 255, 64, 0);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 64, 0, lightColor.A - projectile.alpha);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, Main.rand.Next(900, 1800));
			target.AddBuff(BuffID.BrokenArmor, Main.rand.Next(3200, 4000));
			target.AddBuff(BuffID.Burning, 300);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D13 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]; //ypos of lower right corner of sprite to draw
			int y3 = num156 * projectile.frame; //ypos of upper left corner of sprite to draw
			Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			Main.spriteBatch.Draw(texture2D13, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), projectile.GetAlpha(lightColor), projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}

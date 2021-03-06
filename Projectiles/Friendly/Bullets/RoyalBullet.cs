﻿using System;
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

namespace Unending.Projectiles.Friendly.Bullets
{
    class RoyalBullet : ModProjectile //Think a "Jester Arrow" for bullets
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baron's Bullet");     //The English name of the projectile
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
        }
		public override void SetDefaults()
		{
			projectile.width = 8;               
			projectile.height = 8;              
			projectile.aiStyle = 1;             
			projectile.friendly = true;         
			projectile.hostile = false;        
			projectile.ranged = true;           
			projectile.penetrate = -1;          //-1 means it has limitless pierce. 
			projectile.timeLeft = 30;          //It's the Jester Arrow of bullets. It's not lasting long.
			projectile.alpha = 255;             
			projectile.light = 0.5f;            
			projectile.ignoreWater = true;          
			projectile.tileCollide = true;          
			projectile.extraUpdates = 1;            
			aiType = ProjectileID.Bullet;           //Is a bullet. Obviously.
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			//Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			Dust.NewDust(projectile.Center, 4, 4, DustID.GoldFlame, 0, 0, 0, Color.White);
		}
	}
}

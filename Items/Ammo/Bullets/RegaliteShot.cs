﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Ammo.Bullets
{
    class RegaliteShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baron's Bullet");
            Tooltip.SetDefault("Fires a short-range bullet that pierces endlessly");
        }
		public override void SetDefaults()
		{
			item.damage = 8;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 1;
			item.shoot = ProjectileType<Projectiles.Friendly.Bullets.RoyalBullet>();   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 16f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}
	}
}

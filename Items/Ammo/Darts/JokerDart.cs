﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Ammo.Darts
{
	public class JokerDart : ModItem
{
	public override void SetStaticDefaults()
	{
			DisplayName.SetDefault("Joker's Dart");
			Tooltip.SetDefault("Confuses enemies on critical hits");
	}

	public override void SetDefaults()
	{
		item.damage = 8;
		item.ranged = true;
		item.width = 7;
		item.height = 12;
		item.maxStack = 999;
		item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
		item.knockBack = 1.5f;
		item.value = 10;
		item.rare = 1;
		item.shoot = ProjectileType<Projectiles.Friendly.Darts.JokerDartProjectile>();   //The projectile shoot when your weapon using this ammo
		item.shootSpeed = 1f;                  //The speed of the projectile
		item.ammo = AmmoID.Dart;              //The ammo class this ammo belongs to.
	}

	public override void AddRecipes()
	{
		ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(ItemID.FallenStar, 1);
		recipe.SetResult(this, 50);
		recipe.AddRecipe();
	}
}
}

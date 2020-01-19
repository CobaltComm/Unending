using System;
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
	public class FireDart : ModItem
{
	public override void SetStaticDefaults()
	{
			DisplayName.SetDefault("Inferno Dart");
			Tooltip.SetDefault("Fires a high-velocity fire dart\nMay leave an inferno around you when fired");
	}

	public override void SetDefaults()
	{
		item.damage = 11;
		item.ranged = true;
		item.width = 7;
		item.height = 12;
		item.maxStack = 999;
		item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
		item.knockBack = 1.5f;
		item.value = 10;
		item.rare = 2;
		item.shoot = ProjectileType<Projectiles.Friendly.Darts.FireDartProjectile>();   //The projectile shoot when your weapon using this ammo
		item.shootSpeed = 7f;                  //The speed of the projectile
		item.ammo = AmmoID.Dart;              //The ammo class this ammo belongs to.
	}

	// Each bullet fired has a 12.5% chance of granting 3 seconds of INFERNO.
	public override void OnConsumeAmmo(Player player)
	{
		if (Main.rand.NextBool(8))
		{
			player.AddBuff(BuffID.Inferno, 180);
		}
	}

	public override void AddRecipes()
	{
		ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(ItemID.HellstoneBar, 1);
		recipe.AddTile(TileID.Anvils);
		recipe.SetResult(this, 150);
		recipe.AddRecipe();
	}
}
}

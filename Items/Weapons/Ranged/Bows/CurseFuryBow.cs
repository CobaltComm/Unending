using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Weapons.Ranged.Bows
{
	public class CurseFuryBow : ModItem
	{
		private int FireballTimer;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vileblaze Longbow");
			Tooltip.SetDefault("Infused with an accursed fury\nTurns Cursed Arrows into disgustingly-fast Cursed Firebolts");
		}

		public override void SetDefaults()
		{
			item.damage = 37;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 45000;
			item.rare = 2;
			item.UseSound = SoundID.DD2_BetsyFireballShot;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.CursedArrow)
			{
				type = mod.ProjectileType("CursedFirebolt");
			}
			FireballTimer += 1;
			if (FireballTimer >= 3)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX * 1f, speedY * 1f, ProjectileID.CursedFlameFriendly, damage, knockBack, player.whoAmI);
				FireballTimer = 0;
			}
			return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
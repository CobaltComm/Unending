using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Weapons.Melee.Swords
{
	public class MeteorSwordMark2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteor Striker");
			Tooltip.SetDefault("Summons meteors from the heavens"); 
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);
			item.damage = 38;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 12;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.buyPrice(gold: 1, silver: 55);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 9f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = (ProjectileID.Meteor1);
			return base.Shoot(player, ref position, ref speedY, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MeteorSword");
			recipe.AddIngredient(ItemID.SoulofLight, 30);
			recipe.AddIngredient(ItemID.SoulofNight, 30);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.SnakeDedicated
{
	[AutoloadEquip(EquipType.Legs)]
	public class SnakeLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Snakeskin Trousers");
			Tooltip.SetDefault("10% increased magic damage" +
				"\n5% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
			item.rare = 8;
			item.defense = 6;
		}
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.1f;
			player.manaCost -= 0.19f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materialis.Loot.Hardmode.Temple.Snakeskin>(), 9);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 5);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
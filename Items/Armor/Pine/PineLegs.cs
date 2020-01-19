using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.Pine
{
	[AutoloadEquip(EquipType.Legs)]
	public class PineLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pine Wood Trunk Walkers");
			Tooltip.SetDefault("8% increased melee damage and movement speed" +
				"\nEnemies are more likely to target you");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 8000;
			item.rare = 8;
			item.defense = 17;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.08f;
			player.moveSpeed += 0.08f;
			player.aggro += 250;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materialis.Loot.Hardmode.FrostMoon.PineWood>(), 250);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.Pine
{
	[AutoloadEquip(EquipType.Body)]
	public class PineChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pine Wood Body Armor");
			Tooltip.SetDefault("9% increased melee damage" +
				"\n6% increased melee critical strike chance" +
				"\nEnemies are more likely to target you");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 8;
			item.defense = 26;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.08f;
			player.meleeCrit += 6;
			player.aggro += 250;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materialis.Loot.Hardmode.FrostMoon.PineWood>(), 300);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
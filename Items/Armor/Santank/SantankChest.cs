using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.Santank
{
	[AutoloadEquip(EquipType.Body)]
	public class SantankChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Santank Shirt");
			Tooltip.SetDefault("10% increased ranged damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 8; //Yellow rarity, putting it at the same rarity as Spooky Armor.
			item.defense = 28;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedCrit += 10;
			player.rangedDamage += 0.1f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materialis.Loot.Hardmode.FrostMoon.ElfMetal>(), 300);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
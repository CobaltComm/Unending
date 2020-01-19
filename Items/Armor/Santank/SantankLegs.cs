using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.Santank
{
	[AutoloadEquip(EquipType.Legs)]
	public class SantankLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Santank Pants");
			Tooltip.SetDefault("10% increased ranged damage"
				+ "\n8% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000; //All Spooky Armor is worth 1 gold. As such, Santank armor will be the same.
			item.rare = 8; //Yellow
			item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.1f;
			player.moveSpeed += 0.08f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materialis.Loot.Hardmode.FrostMoon.ElfMetal>(), 250);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
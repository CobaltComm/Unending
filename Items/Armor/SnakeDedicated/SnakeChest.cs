using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.SnakeDedicated
{
	[AutoloadEquip(EquipType.Body)]
	public class SnakeChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Snakeskin Suit");
			Tooltip.SetDefault("Reduces mana usage by 19%" +
				"\n11% increased magic damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
			item.rare = 8;
			item.defense = 8;
		}
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.11f;
			player.magicCrit += 11;
			player.manaCost -= 0.19f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materialis.Loot.Hardmode.Temple.Snakeskin>(), 12);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 6);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
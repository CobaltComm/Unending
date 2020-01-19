using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Materialis.Loot.Hardmode.Temple
{
	public class Snakeskin : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Snakeskin");
			Tooltip.SetDefault("Glistens with adventurous gleam");
		}
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.value = 1200;
			item.rare = 0;
			item.maxStack = 999;
		}
	}
}
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Materialis.Loot.Hardmode.FrostMoon
{
	public class PineWood : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pine Wood");
		}
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 14;
			item.value = 0;
			item.rare = 0;
			item.maxStack = 999;
		}
	}
}
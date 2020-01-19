using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Weapons.Melee.Swords
{
	public class Bonecleaver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bonecleaver");
			Tooltip.SetDefault("Know our pain.");
		}
		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Weapons.Melee.Swords
{
	public class Clarent : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clarent");
			Tooltip.SetDefault("No mercy given to traitors.");
		}
		public override void SetDefaults()
		{
			item.damage = 14;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 11;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Inflicts the debuff listed for the number of frames.
			// 60 frames = 1 second
			target.AddBuff(BuffID.Midas, 180);
		}
	}
}

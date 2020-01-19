
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Powerups
{
	// I'm almost certainly breaking everything.
	// ANYWAY!
	// Dedicated to Twitch streamer PerpetualMM! Go check them out: https://www.twitch.tv/perpetualmm 
	internal class MoonImmuneShot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunar Immunizer Shot");
			Tooltip.SetDefault("Grants immunity to Moon Bite.\nPermanently.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
		}

		public override bool CanUseItem(Player player)
		{
			// Any mod that changes statLifeMax to be greater than 500 is broken and needs to fix their code.
			// This check also prevents this item from being used before vanilla health upgrades are maxed out.
			return player.GetModPlayer<UnendingPlayer>().MoonInject == false;
		}

		public override bool UseItem(Player player)
		{
			// Let's test permanence.
			player.GetModPlayer<UnendingPlayer>().MoonInject = true;
			// 
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 80);
			recipe.AddIngredient(ItemID.FragmentVortex, 80);
			recipe.AddIngredient(ItemID.FragmentNebula, 80);
			recipe.AddIngredient(ItemID.FragmentStardust, 80);
			recipe.AddIngredient(ItemID.LunarBar, 120);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
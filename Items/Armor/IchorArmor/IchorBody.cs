using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.IchorArmor
{
	[AutoloadEquip(EquipType.Body)]
	public class IchorBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sanguine Hate Plate");
			Tooltip.SetDefault("2% increased critical strike chance"); //Minions get an unlisted 4% damage bonus to ensure it's not USELESS for summoners
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 4;
			item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 2;
			player.rangedCrit += 2;
			player.magicCrit += 2;
			player.thrownCrit += 2;
			player.minionDamage *= 1.04f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ichor, 30);
			recipe.AddIngredient(ItemID.SoulofNight, 20);
			recipe.AddIngredient(ItemID.CobaltBar, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ichor, 30);
			recipe.AddIngredient(ItemID.SoulofNight, 20);
			recipe.AddIngredient(ItemID.PalladiumBar, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
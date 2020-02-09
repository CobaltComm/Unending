using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.IchorArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class IchorLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sanguine Hate Chain Treads");
			Tooltip.SetDefault("1% increased damage and critical strike chance" +
				"5% increased movement speed"); //Minions get 2% damage bonus instead of 1%
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 8000;
			item.rare = 4;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 1;
			player.rangedCrit += 1;
			player.magicCrit += 1;
			player.thrownCrit += 1;
			player.meleeDamage *= 1.01f;
			player.rangedDamage *= 1.01f;
			player.magicDamage *= 1.01f;
			player.thrownDamage *= 1.01f;
			player.minionDamage *= 1.02f;
			player.moveSpeed *= 1.05f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ichor, 25);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddIngredient(ItemID.CobaltBar, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ichor, 25);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddIngredient(ItemID.PalladiumBar, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
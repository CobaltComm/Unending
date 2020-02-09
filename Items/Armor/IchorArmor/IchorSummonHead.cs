using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.IchorArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class IchorSummonHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sanguine Hate Headgear"); //New sprite by the wonderful bogisart! Discord: bogisart#8079
			Tooltip.SetDefault("Increases maximum minions by 2");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
			item.rare = 4;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 2;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<IchorBody>() && legs.type == ItemType<IchorLegs>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons a damaging ichor shield";
			UnendingPlayer modPlayer = player.GetModPlayer<UnendingPlayer>();
			modPlayer.IchorSummonEffect();
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ichor, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.CobaltBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ichor, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.PalladiumBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
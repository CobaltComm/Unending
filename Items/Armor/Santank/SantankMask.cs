using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.Santank
{
	[AutoloadEquip(EquipType.Head)]
	public class SantankMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("20% chance to not consume ammo"+
				"\n10% increased ranged damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
			item.rare = 8;
			item.defense = 13;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<SantankChest>() && legs.type == ItemType<SantankLegs>();
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.1f;
			player.ammoCost80 = true;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "huh. It shoots rockets.";
			var aPlayer = player.GetModPlayer<UnendingPlayer>();
			aPlayer.SantankSet = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materialis.Loot.Hardmode.FrostMoon.ElfMetal>(), 200);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
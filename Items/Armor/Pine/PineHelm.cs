using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.Pine
{
	[AutoloadEquip(EquipType.Head)]
	public class PineHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pine Wood Helm");
			Tooltip.SetDefault("8% increased melee damage" +
				"\nEnemies are more likely to target you");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
			item.rare = 8;
			item.defense = 20;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.08f;
			player.aggro += 250;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<PineChest>() && legs.type == ItemType<PineLegs>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Spawns ornaments when hit";
			var aPlayer = player.GetModPlayer<UnendingPlayer>();
			aPlayer.PineSet = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materialis.Loot.Hardmode.FrostMoon.PineWood>(), 200);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
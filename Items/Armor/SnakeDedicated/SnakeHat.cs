using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.SnakeDedicated
{
	[AutoloadEquip(EquipType.Head)]
	public class SnakeHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Snakeskin Hood");
			Tooltip.SetDefault("Increases maximum mana by 80" +
				"\n9% increased magic damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
			item.rare = 8;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<SnakeChest>() && legs.type == ItemType<SnakeLegs>();
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.09f;
			player.magicCrit += 9;
			player.statManaMax2 += 80;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Now we venturee forth, with the serpent's fang by our side";
			var aPlayer = player.GetModPlayer<UnendingPlayer>();
			aPlayer.VentureSet = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materialis.Loot.Hardmode.Temple.Snakeskin>(), 6);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 4);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.Royal
{
	[AutoloadEquip(EquipType.Legs)]
	public class RoyalLegs : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Royal Greaves");
			Tooltip.SetDefault("+3% increased damage"
				+ "\n5% increased movement speed");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 8000;
			item.rare = 1; //blue
			item.defense = 3;
		}

		public override void UpdateEquip(Player player) {
			player.meleeDamage += 0.03f;
			player.rangedDamage += 0.03f;
			player.magicDamage += 0.03f;
			player.minionDamage += 0.03f;
			player.thrownDamage += 0.03f;
			player.moveSpeed += 0.05f;
		}
	}
}
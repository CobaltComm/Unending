using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.Royal
{
	[AutoloadEquip(EquipType.Body)]
	public class RoyalChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Royal Plate");
			Tooltip.SetDefault("Increases damage by 3%" +
				"\n5% Increased critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1; //Blue rarity is 1. White is 0, Green is 2. I can't remember this very well, but I'm unsure as to why.
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.03f;
			player.rangedDamage += 0.03f;
			player.magicDamage += 0.03f;
			player.minionDamage += 0.03f;
			player.thrownDamage += 0.03f;
			player.thrownCrit += 5;
			player.meleeCrit += 5;
			player.magicCrit += 5;
			player.rangedCrit += 5;
		}
	}
}
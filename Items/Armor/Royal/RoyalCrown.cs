using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.Armor.Royal
{
	[AutoloadEquip(EquipType.Head)]
	public class RoyalCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases damage by 5%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
			item.rare = 1;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<RoyalChest>() && legs.type == ItemType<RoyalLegs>();
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.05f;
			player.rangedDamage += 0.05f;
			player.magicDamage += 0.05f;
			player.minionDamage += 0.05f;
			player.thrownDamage += 0.05f;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Royal blood empowers you, increasing damage by 15%";
			player.meleeDamage += 0.15f;
			player.rangedDamage += 0.15f;
			player.magicDamage += 0.15f;
			player.minionDamage += 0.15f;
			player.thrownDamage += 0.15f;
		}
	}
}
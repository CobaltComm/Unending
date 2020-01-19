using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Unending.Projectiles;
using Unending.Projectiles.Friendly.Yoyos;

namespace Unending.Items.Weapons.Melee.Yoyo
{
	public class PinkThrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Bounces your enemies about");
			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 8;
			item.useTime = 8;
			item.shootSpeed = 16f;
			item.knockBack = 16f;
			item.damage = 18;
			item.rare = 1;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 2);
			item.shoot = ProjectileType<PinkThrowProj>();
		}

		// Make sure that your item can even receive these prefixes (check the vanilla wiki on prefixes)
		// These are the ones that reduce damage of a melee weapon
		private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy };

		public override bool AllowPrefix(int pre)
		{
			// return false to make the game reroll the prefix

			// DON'T DO THIS BY ITSELF:
			// return false;
			// This will get the game stuck because it will try to reroll every time. Instead, make it have a chance to return true

			if (Array.IndexOf(unwantedPrefixes, pre) > -1)
			{
				// IndexOf returns a positive index of the element you search for. If not found, it's less than 0. Here check the opposite
				// Rolled a prefix we don't want, reroll
				return false;
			}
			// Don't reroll
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PinkGel, 20);
			recipe.AddIngredient(ItemID.Gel, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

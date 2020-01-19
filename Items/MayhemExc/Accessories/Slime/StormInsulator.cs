using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending.Items.MayhemExc.Accessories.Slime
{
    public class StormInsulator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Insulator");
            Tooltip.SetDefault(@"'Shocking, is it not?'
Grants immunity to Electrified
Grants a boost to stats while in Space");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 50, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<UnendingPlayer>().SlimeLightning = true;
        }
    }
}

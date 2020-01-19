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
    public class PurpleVial : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Jelly Vial");
            Tooltip.SetDefault(@"'A vial of purple jelly'
Grants immunity to Venom
Melee attacks cause you to erupt into bolts of venom
This effect may trigger once per second");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 10;
            item.accessory = true;
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 50, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<UnendingPlayer>().SlimePurple = true;
        }
    }
}

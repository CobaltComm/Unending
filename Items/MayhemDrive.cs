using Unending;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Unending
{
    public class MayhemDrive : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.Cog;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mayhem Gear");
            Tooltip.SetDefault("Permanently activates Mayhem Mode\nWARNING: Cannot be reversed!\nOnly usable in Expert Mode worlds\nMayhem Mode adds new debuffs, attack patterns, boss AI, monster AI, and enemies\nSpecial loot is available in Mayhem Mode that cannot be obtained elsewhere");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Cog);
            item.color = Color.DarkCyan;
            item.consumable = true;
            item.useStyle = 4;
        }
        public override bool CanUseItem(Player player)
        {
            // Checks for if Mayhem is active first, then if Expert is active second.
            return UnendingWorld.MayhemMode == false && Main.expertMode == true;
        }
        public override bool UseItem(Player player)
        {
            UnendingWorld.MayhemMode = true;
            return true;
        }
    }
}
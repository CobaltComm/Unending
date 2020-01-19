using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace Unending.Projectiles.MayhemFriendly
{
    class PurpleSlimeBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venomous Slime Ball");
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.SporeGas2);
            aiType = ProjectileID.SporeGas;
            projectile.width = 4;
            projectile.height = 4;
            projectile.tileCollide = false;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.Purple;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Venom, 180);
        }
    }
}

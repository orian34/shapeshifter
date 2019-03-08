using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class MechInferno : ModProjectile
    {
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_96";
			}
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MechInferno");
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.CursedFlameHostile);
			aiType = ProjectileID.CursedFlameHostile;
			projectile.friendly = true;
			projectile.hostile = false;
		}
    }
}
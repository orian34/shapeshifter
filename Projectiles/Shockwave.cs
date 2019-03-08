using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Shapeshifter.Projectiles
{
    public class Shockwave : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shockwave");
			Main.projFrames[projectile.type] = 2;
		}
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ignoreWater = true;    
			projectile.tileCollide = false;  
			projectile.penetrate = -1;
			projectile.timeLeft = 4;
			projectile.alpha = 227;
			projectile.width = 200;
			projectile.height = 200;
		}
		public override void AI()
		{
			if (++projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2)
				{
					projectile.frame = 0;
				}
			}
		}
	}
}
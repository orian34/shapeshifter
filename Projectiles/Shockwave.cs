using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace Shapeshifter.Projectiles
{
    public class Shockwave : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_" + ProjectileID.ShadowBeamFriendly; // I.e. an invisible sprite

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shockwave");
			//Main.projFrames[projectile.type] = 2;
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
			if (projectile.timeLeft == 4) Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<ShockwaveEffectPro>(), 0, 0, projectile.owner);
			/*if (++projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2)
				{
					projectile.frame = 0;
				}
			}*/
		}
    }
}
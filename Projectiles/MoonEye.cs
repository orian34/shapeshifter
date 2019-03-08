using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class MoonEye : ModProjectile
    {
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_452";
			}
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MoonEye");
		}
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.PhantasmalEye);
			aiType = ProjectileID.PhantasmalEye;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.timeLeft = 3600;
			projectile.ignoreWater = true;
		}
    }
}
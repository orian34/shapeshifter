using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class GolemLaser : ModProjectile
    {
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_259";
			}
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GolemLaser");
		}
        
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EyeBeam);
			aiType = ProjectileID.EyeBeam;
			projectile.friendly = true;
			projectile.hostile = false;
		}
	}
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class MechLaser : ModProjectile
    {
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_100";
			}
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MechLaser");
		}
        
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.DeathLaser);
			aiType = ProjectileID.DeathLaser;
			projectile.friendly = true;
			projectile.hostile = false;
		}
	}
}
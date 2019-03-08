using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class PrimordialEnergyBolt : ModProjectile
    {
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_440";
			}
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PrimordialEnergyBolt");
		}
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.width = 6;
			projectile.height = 10;
			projectile.penetrate = -1;
		}
		public override void AI()
		{
			projectile.rotation += 0.3f;
			int num127 = Dust.NewDust(new Vector2(projectile.position.X+1, projectile.position.Y+1), projectile.width, projectile.height, 59, 0f, 0f, 0, default(Color), 1f);
			Main.dust[num127].noGravity = true;
		}
    }
}
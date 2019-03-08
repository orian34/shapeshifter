using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class DukeBubble : ModProjectile
    {
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_405";
			}
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DukeBubble");
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bubble);
			aiType = ProjectileID.Bubble;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;   
			projectile.timeLeft = 300;
		}
    }
}
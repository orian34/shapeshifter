using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class ShockwaveEffectPro : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.ShadowBeamFriendly; // I.e. an invisible sprite

        string Shockwave { get => "ShapeshifterShockwave" + (Main.player[projectile.owner].ownedProjectileCounts[projectile.type] + (Main.player[projectile.owner].ownedProjectileCounts[projectile.type] <= 5 ? 1 : 0)); }
        string myWave = string.Empty;

		public override void SetDefaults()
		{
			projectile.tileCollide = false;
			projectile.timeLeft = 180;
            projectile.width = 1;
            projectile.height = 1;
		}

        public override void AI()
        {
            if (projectile.timeLeft == 180) myWave = Shockwave;

            if (Main.netMode != NetmodeID.Server && !Filters.Scene[myWave].IsActive() && projectile.timeLeft > 90)
            {
                Filters.Scene.Activate(myWave, projectile.Center).GetShader().UseColor(1, 2, 10).UseTargetPosition(projectile.Center);
            }

            if (Main.netMode != NetmodeID.Server && Filters.Scene[myWave].IsActive())
            {
                float progress = (180f - projectile.timeLeft) / 60f;
                Filters.Scene[myWave].GetShader().UseProgress(progress).UseOpacity(75f * (1 - progress / 3f));
            }
            
            if (projectile.timeLeft == 90)
            {
                projectile.Kill();
            }
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server && Filters.Scene[myWave].IsActive())
            {
                Filters.Scene[myWave].Deactivate();
            }
        }
    }
}

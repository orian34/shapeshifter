using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Shapeshifter.Core
{
	public class ShapeshifterPlayer : ModPlayer
	{
		// Shapeshifts I could become
		private IList<Shapeshift> _shapeshifts;

		// Shapeshift I'll turn into next update
		private Type _turnToShapeshift;

		// Set the shapeshift to activate
		public void ActivateShapeshift(Type shapeshift)
		{
			_turnToShapeshift = shapeshift;
		}

		// I'm a player, and I could be shapeshifted into this
		public Shapeshift Shapeshift;

		public override void Initialize()
		{
			// Creates a new instance for all possible shapeshift types
			_shapeshifts = new List<Shapeshift>(Shapeshifter.Shapeshifts.Select(x => (Shapeshift)Activator.CreateInstance(x)));
			foreach (var shapeshift in _shapeshifts)
            {
                shapeshift
                    .GetType()
                    .GetProperty("player")
                    ?.SetValue(shapeshift, player);

                shapeshift
                    .GetType()
                    .GetProperty("mod")
                    ?.SetValue(shapeshift, mod);
            }
		}

		// Executes after this player was checked to exist
		public override void PreUpdate()
		{
			// We should turn into a new shapeshift
			if (_turnToShapeshift != null && _turnToShapeshift != Shapeshift?.GetType())
			{
				// If we are shapeshifted, call it to deactivate
				Shapeshift?.Deactivate();
				Shapeshift = _shapeshifts.FirstOrDefault(x => x.GetType() == _turnToShapeshift);
				Shapeshift?.Activate();
			}
			// We should no longer be shapeshifted
			else if (_turnToShapeshift == null && Shapeshift != null)
			{
				Shapeshift.Deactivate();
				Shapeshift = null;
			}
			_turnToShapeshift = null;

			Shapeshift?.PreUpdate();
		}

		public override void PreUpdateBuffs()
		{
			Shapeshift?.PreUpdateBuffs();
		}

		public override void PostUpdateBuffs()
		{
			Shapeshift?.PostUpdateBuffs();
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			Shapeshift?.OnHitNPCWithProj(proj, target, damage, knockback, crit);
		}
		
		public override void OnHitNPC (Item item, NPC target, int damage, float knockback, bool crit)
		{
			Shapeshift?.OnHitNPC(item, target, damage, knockback, crit);
		}
		
		public override void OnHitAnything(float x, float y, Entity victim)
		{
			Shapeshift?.OnHitAnything(x, y, victim);
		}
		
		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
			ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			return Shapeshift?.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit,
			ref customDamage, ref playSound, ref genGore, ref damageSource)
				   ?? base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit,
			ref customDamage, ref playSound, ref genGore, ref damageSource);
		}
		
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Shapeshift?.Hurt(pvp, quiet, damage, hitDirection, crit);
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			return Shapeshift?.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource)
				   ?? base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
		}

		public override void FrameEffects()
		{
			Shapeshift?.FrameEffects();
		}
	}
}

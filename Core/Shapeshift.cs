using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Shapeshifter.Core
{
	// Defines shapeshifting behaviour
	public abstract class Shapeshift : ModPlayer
	{
		protected Shapeshift()
		{
			
		}

		// Properties that must be implemented
		public abstract string BossName { get; }
		public abstract string ShapeshiftName { get; }
		public abstract string ShapeDesc { get; }

		public override bool Autoload(ref string name)
			=> false; // not autoload, handled by Shapeplayer

		/// <summary>
		/// Do something if deactivated
		/// </summary>
		public virtual void Deactivate()
		{

		}

		/// <summary>
		/// Do something if activated
		/// </summary>
		public virtual void Activate()
		{

		}
	}
}

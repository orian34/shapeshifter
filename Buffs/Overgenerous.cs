using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Buffs
{
	public class Overgenerous : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Overflowing Generosity");
			Description.SetDefault("The energy flows out of you to heal others.");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ShapeGlobalNPC>(mod).overgenerous = true;
		}
	}
}
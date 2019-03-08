using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BrainofCthulhuShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain of Cthulhu Shapemask");
			Tooltip.SetDefault("'This mask is full of malice.' \n4% increased magic damage \n[c/99004C:1/3 Brain of Cthulhu Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 17;
			item.value = 1300*5;
			item.rare = 2;
			item.defense = 4;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BrainofCthulhuShapeplate") && legs.type == mod.ItemType("BrainofCthulhuShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.04f;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of a malicious brain";
			player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(BrainofCthulhuShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe brainofcthulhushapemask = new ModRecipe(mod);
			brainofcthulhushapemask.AddIngredient(ItemID.BrainMask);
			brainofcthulhushapemask.AddIngredient(ItemID.Vertebrae, 9);
			brainofcthulhushapemask.AddTile(TileID.DemonAltar);
			brainofcthulhushapemask.SetResult(this);
			brainofcthulhushapemask.AddRecipe();
		}
	}
}

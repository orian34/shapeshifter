using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BrainofCthulhuShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain of Cthulhu Shapelegs");
			Tooltip.SetDefault("4% increased magic damage \n[c/99004C:3/3 Brain of Cthulhu Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 1680*5;
			item.rare = 2;
			item.defense = 4;
		}
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.04f;
		}
		public override void AddRecipes()
		{
			ModRecipe brainofcthulhushapelegs = new ModRecipe(mod);
			brainofcthulhushapelegs.AddIngredient(ItemID.Vertebrae, 7);
			brainofcthulhushapelegs.AddIngredient(ItemID.TissueSample, 16);
			brainofcthulhushapelegs.AddTile(TileID.DemonAltar);
			brainofcthulhushapelegs.SetResult(this);
			brainofcthulhushapelegs.AddRecipe();
		}
	}
}

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class EaterofWorldShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater of Worlds Shapelegs");
			Tooltip.SetDefault("8% increased movement speed \n[c/003300:3/3 Eater of Worlds Set Piece]");
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
			player.moveSpeed += 0.08f;
		}
		public override void AddRecipes()
		{
			ModRecipe eaterofworldshapelegs = new ModRecipe(mod);
			eaterofworldshapelegs.AddIngredient(ItemID.RottenChunk, 9);
			eaterofworldshapelegs.AddIngredient(ItemID.ShadowScale, 16);
			eaterofworldshapelegs.AddTile(TileID.DemonAltar);
			eaterofworldshapelegs.SetResult(this);
			eaterofworldshapelegs.AddRecipe();
		}
		public override bool DrawLegs()
		{
			return false;
		}
	}
}

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class QueenBeeShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee Shapelegs");
			Tooltip.SetDefault("4% increased throwing damage \n[c/FF8000:3/3 Queen Bee Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 300*5;
			item.rare = 3;
			item.defense = 4;
		}
		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.04f;
		}
		public override void AddRecipes()
		{
			ModRecipe queenbeeshapelegs = new ModRecipe(mod);
			queenbeeshapelegs.AddIngredient(ItemID.BeeWax, 10);
			queenbeeshapelegs.AddIngredient(ItemID.HoneyBlock, 6);
			queenbeeshapelegs.AddTile(TileID.HoneyDispenser);
			queenbeeshapelegs.SetResult(this);
			queenbeeshapelegs.AddRecipe();
		}
	}
}

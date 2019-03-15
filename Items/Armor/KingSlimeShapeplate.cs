using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class KingSlimeShapeplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King Slime Shapeplate");
			Tooltip.SetDefault("Reduces damage taken by 8% \nSlimes become friendly. \n[c/0066CC:2/3 King Slime Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 18;
			item.value = 21500*5;
			item.rare = 1;
			item.defense = 4;
		}
		public override void UpdateEquip(Player player)
		{
			player.endurance += 0.08f;
			player.npcTypeNoAggro[1] = true;
			player.npcTypeNoAggro[16] = true;
			player.npcTypeNoAggro[59] = true;
			player.npcTypeNoAggro[71] = true;
			player.npcTypeNoAggro[81] = true;
			player.npcTypeNoAggro[138] = true;
			player.npcTypeNoAggro[121] = true;
			player.npcTypeNoAggro[122] = true;
			player.npcTypeNoAggro[141] = true;
			player.npcTypeNoAggro[147] = true;
			player.npcTypeNoAggro[183] = true;
			player.npcTypeNoAggro[184] = true;
			player.npcTypeNoAggro[204] = true;
			player.npcTypeNoAggro[225] = true;
			player.npcTypeNoAggro[244] = true;
			player.npcTypeNoAggro[302] = true;
			player.npcTypeNoAggro[333] = true;
			player.npcTypeNoAggro[335] = true;
			player.npcTypeNoAggro[334] = true;
			player.npcTypeNoAggro[336] = true;
			player.npcTypeNoAggro[537] = true;
		}
		public override void AddRecipes()
		{
			ModRecipe kingslimeshapeplate = new ModRecipe(mod);
			kingslimeshapeplate.AddIngredient(ItemID.RoyalGel);
			kingslimeshapeplate.AddIngredient(ItemID.NinjaShirt);
			kingslimeshapeplate.AddTile(TileID.Solidifier);
			kingslimeshapeplate.SetResult(this);
			kingslimeshapeplate.AddRecipe();
		}
	}
}

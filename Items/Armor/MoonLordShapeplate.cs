using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class MoonLordShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Lord Shapeplate");
			Tooltip.SetDefault("Increases your max number of minions by 4 \n[c/99FFCC:2/3 Moon Lord Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 800000*5;
			item.rare = 10;
			item.defense = 30;
		}
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 4;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SuspiciousLookingTentacle);
			recipe.AddIngredient(ItemID.FragmentStardust,20);
			recipe.AddIngredient(ItemID.LunarBar,16);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool DrawBody()
		{
			return false;
		}
	}
}

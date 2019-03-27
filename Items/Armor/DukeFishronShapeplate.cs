using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class DukeFishronShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duke Fishron Shapeplate");
			Tooltip.SetDefault("Grants you improved mobility in water \n[c/00FFFF:2/3 Duke Fishron Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 48000*5;
			item.rare = 9;
			item.defense = 30;
		}
		public override void UpdateEquip(Player player)
		{
			if(player.wet && !player.lavaWet && !player.honeyWet)
			{
				player.gravity = 0.2f;
				player.maxFallSpeed = 20f;
				player.releaseJump = true;
				player.wings = 0;
				player.accFlipper = true;
				player.merman = true;
				player.hideMerman = true;
				player.ignoreWater = true;
				player.maxRunSpeed = 3f;
				player.runAcceleration = 3f;
				player.pickSpeed -= 3.5f;
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShrimpyTruffle);
			recipe.AddIngredient(ItemID.SharkFin,6);
			recipe.AddIngredient(ItemID.Bacon,2);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

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
			Tooltip.SetDefault("Grants you improved mobility in water");
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
			if(player.wet && !player.honeyWet && !player.lavaWet)
			{
				player.gravity = 0.1f;
				player.maxFallSpeed = 15f;
				player.releaseJump = true;
				player.wings = 0;
				player.accFlipper = true;
				player.maxRunSpeed = 4.5f;
				player.runAcceleration = 4.5f;
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

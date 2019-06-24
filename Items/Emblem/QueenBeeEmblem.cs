using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class QueenBeeEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee Emblem");
			Tooltip.SetDefault("'This emblem shows your swarm queen mastery.' \nIncreases the strength of friendly bees. \n6% increased throwing and ranged damage. \n[c/FF8000:Queen Bee Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 36900*5;
			item.rare = 3;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.strongBees = true;
			player.thrownDamage += 0.06f;
			player.rangedDamage += 0.06f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(QueenBeeShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "QueenBeeShapemask");
			recipe.AddIngredient(null, "QueenBeeShapeplate");
			recipe.AddIngredient(null, "QueenBeeShapelegs");
			recipe.AddIngredient(ItemID.QueenBeeTrophy);
			recipe.AddTile(TileID.HoneyDispenser);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

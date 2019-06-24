using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class GolemEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem Emblem");
			Tooltip.SetDefault("'This emblem shows your ancient construct mastery.' \nGreatly increases life regen when not moving \n6% increased melee and magic damage. \n[c/F6D013:Golem Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 164000*5;
			item.rare = 8;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.shinyStone = true;
			player.meleeDamage += 0.06f;
			player.magicDamage += 0.06f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(GolemShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GolemShapemask");
			recipe.AddIngredient(null, "GolemShapeplate");
			recipe.AddIngredient(null, "GolemShapelegs");
			recipe.AddIngredient(ItemID.GolemTrophy);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

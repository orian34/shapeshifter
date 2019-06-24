using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class EaterofWorldsEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater of Worlds Emblem");
			Tooltip.SetDefault("'This emblem shows your corrupted monster mastery.' \nReduces damage taken by 10% \n6% increased melee and summoning damage \n[c/127C12:Eater of Worlds Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 35780*5;
			item.rare = 2;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.endurance += 0.1f;
			player.meleeDamage += 0.06f;
			player.minionDamage += 0.06f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(EaterofWorldShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EaterofWorldShapemask");
			recipe.AddIngredient(null, "EaterofWorldShapeplate");
			recipe.AddIngredient(null, "EaterofWorldShapelegs");
			recipe.AddIngredient(ItemID.EaterofWorldsTrophy);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

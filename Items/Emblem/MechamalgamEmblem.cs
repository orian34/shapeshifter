using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class MechamalgamEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechamalgam Emblem");
			Tooltip.SetDefault("'This emblem shows your energy-powered amalgam mastery.' \nImproved abilities if powered \n6% increased ranged and minion damage \n[c/8E8E8E:Mechamalgam Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 130000*5;
			item.rare = 5;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.06f;
			player.minionDamage += 0.06f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(MechamalgamShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MechamalgamShapemask");
			recipe.AddIngredient(null, "MechamalgamShapeplate");
			recipe.AddIngredient(null, "MechamalgamShapelegs");
			recipe.AddIngredient(ItemID.SkeletronPrimeTrophy);
			recipe.AddIngredient(ItemID.DestroyerTrophy);
			recipe.AddIngredient(ItemID.RetinazerTrophy);
			recipe.AddIngredient(ItemID.SpazmatismTrophy);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

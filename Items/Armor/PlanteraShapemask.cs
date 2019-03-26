using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PlanteraShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plantera Shapemask");
			Tooltip.SetDefault("'This mask is slowly growing.' \n7% Increased ranged damage \n[c/FF33FF:1/3 Plantera Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 17;
			item.value = 30000*5;
			item.rare = 7;
			item.defense = 13;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PlanteraShapeplate") && legs.type == mod.ItemType("PlanteraShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.07f;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of an evergrowing plant";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(PlanteraShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlanteraMask);
			recipe.AddIngredient(ItemID.ChlorophyteBar,6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class PlanteraShapemaskAwakened : EquipTexture
	{
		public override bool DrawHead()
		{
			return false;
		}
	}
}

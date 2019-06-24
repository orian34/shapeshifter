using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class EyeofCthulhuShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Cthulhu Shapemask");
			Tooltip.SetDefault("'This mask is full of rage.' \n7% increased melee speed \n[c/FF3333:1/3 Eye of Cthulhu Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.value = 27500*5;
			item.rare = 1;
			item.defense = 3;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("EyeofCthulhuShapeplate") && legs.type == mod.ItemType("EyeofCthulhuShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.07f;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of a raging eye";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(EyeofCthulhuShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe eyeofcthulhushapemask = new ModRecipe(mod);
			eyeofcthulhushapemask.AddIngredient(ItemID.EyeMask);
			eyeofcthulhushapemask.AddRecipeGroup("anyEvilOre", 25);
			eyeofcthulhushapemask.AddTile(TileID.Anvils);
			eyeofcthulhushapemask.SetResult(this);
			eyeofcthulhushapemask.AddRecipe();
		}
	}
}

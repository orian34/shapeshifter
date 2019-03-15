using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter
{

	public static class RecipeHelper
	{
		public static void AddExpertRecipes(Mod mod)
		{
			ModRecipe recipeKS = new ModRecipe(mod);
			recipeKS.AddRecipeGroup("anyCrown");
			recipeKS.AddIngredient(ItemID.PinkGel, 12);
			recipeKS.AddIngredient(ItemID.SkyBlueDye);
			recipeKS.AddTile(TileID.Solidifier);
			recipeKS.SetResult(ItemID.RoyalGel);
			recipeKS.AddRecipe();

			ModRecipe recipeEOC = new ModRecipe(mod);
			recipeEOC.AddRecipeGroup("anyEvilSeed", 4);
			recipeEOC.AddRecipeGroup("anyEvilOre", 18);
			recipeEOC.AddIngredient(ItemID.WhitePaint);
			recipeEOC.AddTile(TileID.Anvils);
			recipeEOC.SetResult(ItemID.EoCShield);
			recipeEOC.AddRecipe();

			ModRecipe recipeEOW = new ModRecipe(mod);
			recipeEOW.AddIngredient(ItemID.Diamond);
			recipeEOW.AddIngredient(ItemID.ShadowScale, 10);
			recipeEOW.AddIngredient(ItemID.Silk, 7);
			recipeEOW.AddTile(TileID.DemonAltar);
			recipeEOW.SetResult(ItemID.WormScarf);
			recipeEOW.AddRecipe();

			ModRecipe recipeBOC = new ModRecipe(mod);
			recipeBOC.AddIngredient(ItemID.Amber, 3);
			recipeBOC.AddIngredient(ItemID.Vertebrae, 6);
			recipeBOC.AddIngredient(ItemID.TissueSample, 14);
			recipeBOC.AddTile(TileID.DemonAltar);
			recipeBOC.SetResult(ItemID.BrainOfConfusion);
			recipeBOC.AddRecipe();

			ModRecipe recipeQB = new ModRecipe(mod);
			recipeQB.AddIngredient(ItemID.HerbBag);
			recipeQB.AddIngredient(ItemID.BeeWax, 13);
			recipeQB.AddIngredient(ItemID.HoneyComb);
			recipeQB.AddTile(TileID.HoneyDispenser);
			recipeQB.SetResult(ItemID.HiveBackpack);
			recipeQB.AddRecipe();

			ModRecipe recipeDG = new ModRecipe(mod);
			recipeDG.AddIngredient(ItemID.Bone, 17);
			recipeDG.AddIngredient(3821);
			recipeDG.AddTile(TileID.BoneWelder);
			recipeDG.SetResult(ItemID.BoneGlove);
			recipeDG.AddRecipe();

			ModRecipe recipeWOF = new ModRecipe(mod);
			recipeWOF.AddRecipeGroup("anyEvilLight");
			recipeWOF.AddIngredient(3783, 2);
			recipeWOF.AddIngredient(ItemID.FrostCore, 2);
			recipeWOF.AddIngredient(ItemID.SoulofNight, 20);
			recipeWOF.AddTile(TileID.Hellforge);
			recipeWOF.SetResult(ItemID.DemonHeart);
			recipeWOF.AddRecipe();

			ModRecipe recipeTW = new ModRecipe(mod);
			recipeTW.AddIngredient(ItemID.HallowedBar, 8);
			recipeTW.AddIngredient(ItemID.Wire, 6);
			recipeTW.AddIngredient(ItemID.Cog, 3);
			recipeTW.AddTile(TileID.MythrilAnvil);
			recipeTW.SetResult(ItemID.MechanicalWheelPiece);
			recipeTW.AddRecipe();

			ModRecipe recipeTD = new ModRecipe(mod);
			recipeTD.AddIngredient(ItemID.HallowedBar, 12);
			recipeTD.AddIngredient(ItemID.Wire, 18);
			recipeTD.AddIngredient(ItemID.Minecart);
			recipeTD.AddTile(TileID.MythrilAnvil);
			recipeTD.SetResult(ItemID.MechanicalWagonPiece);
			recipeTD.AddRecipe();

			ModRecipe recipeSP = new ModRecipe(mod);
			recipeSP.AddIngredient(ItemID.HallowedBar, 10);
			recipeSP.AddIngredient(ItemID.Wire, 12);
			recipeSP.AddIngredient(ItemID.Timer1Second, 2);
			recipeSP.AddTile(TileID.MythrilAnvil);
			recipeSP.SetResult(ItemID.MechanicalBatteryPiece);
			recipeSP.AddRecipe();

			ModRecipe recipePT = new ModRecipe(mod);
			recipePT.AddIngredient(ItemID.JungleSpores, 12);
			recipePT.AddIngredient(ItemID.LifeFruit, 3);
			recipePT.AddIngredient(ItemID.Seedling);
			recipePT.AddTile(TileID.LivingLoom);
			recipePT.SetResult(ItemID.SporeSac);
			recipePT.AddRecipe();

			ModRecipe recipeGO = new ModRecipe(mod);
			recipeGO.AddIngredient(ItemID.Amber, 12);
			recipeGO.AddIngredient(ItemID.HoneyBucket);
			recipeGO.AddIngredient(ItemID.PhilosophersStone);
			recipeGO.AddTile(TileID.LihzahrdFurnace);
			recipeGO.SetResult(ItemID.ShinyStone);
			recipeGO.AddRecipe();

			ModRecipe recipeDF = new ModRecipe(mod);
			recipeDF.AddIngredient(ItemID.StrangeGlowingMushroom);
			recipeDF.AddIngredient(ItemID.ScalyTruffle);
			recipeDF.AddTile(TileID.Solidifier);
			recipeDF.SetResult(ItemID.ShrimpyTruffle);
			recipeDF.AddRecipe();

			ModRecipe recipeGB = new ModRecipe(mod);
			recipeGB.AddIngredient(ItemID.GravitationPotion, 9);
			recipeGB.AddIngredient(ItemID.CrystalBall);
			recipeGB.AddTile(TileID.LunarCraftingStation);
			recipeGB.SetResult(ItemID.GravityGlobe);
			recipeGB.AddRecipe();
			
			ModRecipe recipeML = new ModRecipe(mod);
			recipeML.AddIngredient(ItemID.MagicLantern);
			recipeML.AddIngredient(ItemID.WispinaBottle);
			recipeML.AddTile(TileID.LunarCraftingStation);
			recipeML.SetResult(ItemID.SuspiciousLookingTentacle);
			recipeML.AddRecipe();
		}
	}
	
}
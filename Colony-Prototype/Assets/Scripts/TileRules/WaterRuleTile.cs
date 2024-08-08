using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "2D/Custom Water Rule Tile")]
public class WaterTileRule : RuleTile<WaterTileRule.Neighbor> {
    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int DeepWater = 2; // Define un estado adicional para agua profunda
        public const int Shore = 3; // Define un estado adicional para costa
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor)
        {
            case Neighbor.DeepWater:
                // Comprueba si el tile vecino es agua profunda
                return tile != null && tile.name == "DeepWaterDeepWater_Tile_Rule"; // Cambia el nombre según corresponda
            case Neighbor.Shore:
                // Comprueba si el tile vecino es costa
                return tile != null && tile.name == "Sand_Tile_Rule"; // Cambia el nombre según corresponda
        }
        return base.RuleMatch(neighbor, tile);
    }
}

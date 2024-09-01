using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "2D/Custom Sand Zone Rule Tile")]
public class SandZoneTileRule : RuleTile<SandZoneTileRule.Neighbor> {
    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Wet = 3; // Define un estado adicional para Zona mojada
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor)
        {
            case Neighbor.Wet:
                return tile != null && tile.name == "WetZoneTileRule"; // Cambia el nombre según corresponda
        }
        return base.RuleMatch(neighbor, tile);
    }
}

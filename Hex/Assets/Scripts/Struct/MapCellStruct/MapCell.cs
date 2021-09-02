using SceneViews.Map;

namespace Struct.MapCellStruct
{
    public class MapCell
    {
        public MapCellView mapCellPrefab;
        public bool playerSpawnMarker = false;
        public bool waterBorder;
        public int HexagonalXCoordinate;
        public int HexagonalYCoordinate;
        public bool isWalkable = true;
        public bool isTaken = false;
        public bool enemySpawnMarker;
        public bool chestSpawnMarker;
        public bool obstacleSpawnMarker;
    }
}

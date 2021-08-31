using Controllers.Map.MapGenerator;
using SceneViews.Map;
using UnityEngine;

namespace GameController
{
    public class GameController : MonoBehaviour
    {
        public MapCellView demoPrefab;

        private MapCellSpawnController _mapCellSpawnController;

        public void Start()
        {
            _mapCellSpawnController = new MapCellSpawnController(5,10, demoPrefab);
            _mapCellSpawnController.SpawnMapCells();
        }
    }
}

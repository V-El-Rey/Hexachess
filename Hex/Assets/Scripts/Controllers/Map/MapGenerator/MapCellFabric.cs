using System.Collections.Generic;
using System.Linq;
using SceneViews.Map;
using Struct.MapCellStruct;
using UnityEngine;

namespace Controllers.Map.MapGenerator
{
    public class MapCellFabric
    {
        private int _width;
        private int _height;
        

        private MapCell[] _mapCellsArray;
        private MapCellView[] _mapCellViewsArray;
        private Sprite _water_hex = Resources.Load<Sprite>("hex_1");
        private Sprite _rock_hex = Resources.Load<Sprite>("hex_rock");
        private Sprite _defaultSprite = Resources.Load<Sprite>("_defaultCell");
        public MapCellFabric(int width)
        {
            _width = width;
        }

        public void GetMapCells()
        {
            _mapCellViewsArray = Object.FindObjectsOfType<MapCellView>();
        }

        public MapCell[] CreateMapCells()
        {
            _mapCellsArray = new MapCell[_mapCellViewsArray.Length];

            for (int i = 0; i < _mapCellsArray.Length; i++)
            {
                _mapCellsArray[i] = new MapCell();
            }

            for (int i = 0; i < _mapCellViewsArray.Length; i++)
            {
                _mapCellsArray[i].HexagonalYCoordinate = _mapCellViewsArray[i].HexagonalYCoordinate;
                _mapCellsArray[i].HexagonalXCoordinate = _mapCellViewsArray[i].HexagonalXCoordinate;
                _mapCellsArray[i].mapCellPrefab = _mapCellViewsArray[i];
            }

            foreach (var mapCell in _mapCellsArray)
            {
                if (Random.Range(0, 100) > 85)
                {
                    mapCell.mapCellPrefab.spriteRenderer.sprite = _water_hex;
                    mapCell.isWalkable = false;
                    mapCell.isTaken = true;
                }
            }

            foreach (var mapCell in _mapCellsArray)
            {
                if (Random.Range(0, 100) > 95 && !mapCell.isTaken)
                {
                    mapCell.mapCellPrefab.Obstacle.sprite = _rock_hex;
                    mapCell.isWalkable = false;
                    mapCell.isTaken = true;
                }
            }

            var playerSpawnGoodCells = _mapCellsArray.Where(mapCell => mapCell.isWalkable).ToList();

            var playerSpawnIndex = Random.Range(0, playerSpawnGoodCells.Capacity);
            playerSpawnGoodCells[playerSpawnIndex].playerSpawnMarker = true;
            playerSpawnGoodCells[playerSpawnIndex].isTaken = true;

            return _mapCellsArray;
        }

        

        public void ResetAllCells()
        {
            foreach (var variableMapCell in _mapCellsArray)
            {
                variableMapCell.mapCellPrefab.spriteRenderer.sprite = _defaultSprite;
                variableMapCell.mapCellPrefab.Obstacle.sprite = null;
                variableMapCell.isWalkable = true;
                variableMapCell.playerSpawnMarker = false;
                variableMapCell.isTaken = false;
            }
        }
    }
}

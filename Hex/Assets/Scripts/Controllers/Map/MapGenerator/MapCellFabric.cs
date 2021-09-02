using System.Collections.Generic;
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
            var playerSpawnGoodCells = new List<MapCell>();
            
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

                if (mapCell.isWalkable)
                {
                    playerSpawnGoodCells.Add(mapCell);
                }
            }

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
                variableMapCell.isWalkable = true;
                variableMapCell.playerSpawnMarker = false;
                variableMapCell.isTaken = false;
            }
        }
    }
}

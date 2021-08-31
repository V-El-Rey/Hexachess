using System;
using SceneViews.Map;
using Struct.MapCellStruct;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Controllers.Map.MapGenerator
{
    public class MapCellSpawnController
    {
        private MapCell[,] _mapCellsArray;
        private MapCellFabric _mapCellFabric;

        private int _width;
        private int _base;

        private Vector3 _cellColumnStartPosition;
        private Vector3 _cellColumnStartPositionEven;
        private Vector3 _currentCellPosition;
        private Vector3 _widthOffset = Vector3.right * 1.85f;
        private Vector3 _heightOffset = Vector3.up * 1.05f;
        private Vector3 _heightStep = Vector3.up * 2.1f;
        private Vector3 _widthStep = Vector3.right * 3.7f;
        private int _layerLevelOdd;
        private int _layerLevelEven;
        private Sprite _waterSprite = Resources.Load<Sprite>("hex_1");
        

        public MapCellSpawnController(int octaBase, int width, MapCellView prefab)
        {
            _cellColumnStartPositionEven = new Vector3(1.85f, 1.05f, 0.0f);
            _cellColumnStartPosition = Vector3.zero;
            _width = width;
            _base = octaBase;
            _layerLevelOdd = 0;
            _layerLevelEven = -1;
     
            _mapCellFabric = new MapCellFabric(_width);
            _mapCellsArray = _mapCellFabric.CreateMapCells(prefab);
        }

        public void SpawnMapCells()
        {
            for (int i = 0; i < _width -1; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    var TempGO = Object.Instantiate(_mapCellsArray[i, j].mapCellPrefab);
                    if (_mapCellsArray[i, j].waterBorder)
                    {
                        TempGO.spriteRenderer.sprite = _waterSprite;
                    }

                    if (i % 2 == 0)
                    {
                        TempGO.transform.position = new Vector3(i * 1.925f, j * 2.22f, 0.0f);
                        TempGO.spriteRenderer.sortingOrder = _layerLevelOdd;
                        _layerLevelOdd -= 2;
                    }
                    else
                    {
                        TempGO.transform.position = new Vector3(i * 1.925f, j * 2.22f + (2.22f / 2f), 0.0f);
                        TempGO.spriteRenderer.sortingOrder = _layerLevelEven;
                        _layerLevelEven -= 2;
                        if (j == _width -1)
                        {
                            _layerLevelEven = -1;
                            _layerLevelOdd = 0;
                        }
                    }

                    
                }
            }
        }
    }
}

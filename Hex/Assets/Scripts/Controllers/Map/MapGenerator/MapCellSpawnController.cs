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
        private int _height;

        private Vector3 _cellColumnStartPosition;
        private Vector3 _cellColumnStartPositionEven;
        private Vector3 _currentCellPosition;
        private Vector3 _widthOffset = Vector3.right * 1.85f;
        private Vector3 _heightOffset = Vector3.up * 1.05f;
        private Vector3 _heightStep = Vector3.up * 2.1f;
        private Vector3 _widthStep = Vector3.right * 3.7f;

        public MapCellSpawnController(int width, int height, MapCellView prefab)
        {
            _cellColumnStartPositionEven = new Vector3(1.85f, 1.05f, 0.0f);
            _cellColumnStartPosition = Vector3.zero;
            _width = width;
            _height = height;
            _mapCellFabric = new MapCellFabric(_width, _height);
            _mapCellsArray = _mapCellFabric.CreateMapCells(prefab);
        }

        public void SpawnMapCells()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    var TempGO = Object.Instantiate(_mapCellsArray[i, j].mapCellPrefab.gameObject);

                    if(i % 2 == 0)
                    {
                        TempGO.transform.position = new Vector3(i * 1.85f, j * 2.1f, 0.0f);
                    }
                    else
                    {
                        TempGO.transform.position = new Vector3(i * 1.85f, j * 2.1f + (2.1f / 2), 0.0f);
                    }
                }
            }
        }
    }
}
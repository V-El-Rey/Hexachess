using System;
using Base;
using TMPro;
using UnityEngine;

namespace SceneViews.Map
{
    public class MapCellView : BaseObjectView
    {
        public SpriteRenderer Obstacle;
        public int HexagonalXCoordinate;
        public int HexagonalYCoordinate;
        public TMP_Text debug_text;

        public void Awake()
        {
            debug_text.text = $"{HexagonalXCoordinate} \n {HexagonalYCoordinate}";
            debug_text.gameObject.SetActive(false);
        }
    }
}

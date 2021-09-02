using System;
using Base;
using TMPro;

namespace SceneViews.Map
{
    public class MapCellView : BaseObjectView
    {
        public int HexagonalXCoordinate;
        public int HexagonalYCoordinate;
        public TMP_Text debug_text;

        public void Awake()
        {
            debug_text.text = $"{HexagonalXCoordinate} \n {HexagonalYCoordinate}";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid
{
    int width;
    int height;
    float cellSize;
    int[,] gridArray;
    TextMesh[,] debugTextArray;

    public Grid(int width, int hight, float cellSize)
    {
        this.width = width;
        this.height = hight;
        this.cellSize = cellSize;

        gridArray =  new int[width,height];
        debugTextArray = new TextMesh[width,height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x,y) + new Vector3(cellSize, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y),GetWorldPosition(x, y + 1), Color.white, 100);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, hight), GetWorldPosition(width, hight), Color.white, 100);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, hight), Color.white, 100);

        SetValue(2, 1, 56);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.x / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        gridArray[x, y] = value;
        debugTextArray[x, y].text = gridArray[x,y].ToString();
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }
}

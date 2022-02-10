using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeView : MonoBehaviour
{
    public int rowsInput;
    public int colsInput;
    public float horizontalSpacing;
    public float verticalSpacing;
    public GameObject cellPrefabs;
    public int tempCounter;
    TicTacToeGrid tttGrid;

    // Start is called before the first frame update
    void Start()
    {
        InitializedGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitializedGrid()
    {
        tttGrid = new TicTacToeGrid(rowsInput, colsInput);
        tttGrid.onCellCreated += OnCellCreated;
        tttGrid.InitializeCell();

    }

    public void OnCellCreated(Cell cell)
    {
        AllignGrid();
        Instantiate(cellPrefabs, new Vector3(horizontalSpacing,0,verticalSpacing), cellPrefabs.transform.rotation);
        tempCounter++;
    }

    public void AllignGrid()
    {
        if(tempCounter == rowsInput)
        {
            horizontalSpacing = 2;
            tempCounter = 0;
            verticalSpacing = 2;
        }
        else
        {
            horizontalSpacing += 2;
        }
    }

}

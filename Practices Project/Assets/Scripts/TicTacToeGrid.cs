using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    List<List<Cell>> cellGrid = new List<List<Cell>>();
    Cell.Status currentTurn = Cell.Status.cross;

    public delegate void OnCellCreated(Cell cell);
    public event OnCellCreated onCellCreated;

    public delegate void OnCellDone();
    public event OnCellDone onCellDone;

    public TicTacToeGrid(int row, int col) : base(row, col){ }


    public void InitializeCell()
    {
        for(int i = 0; i < numberOfRows; i++) 
        {
            cellGrid.Add(new List<Cell>());
            for(int j=0; j< numberOfCols; j++)
            {
                Cell cell = new Cell(i,j);
                cellGrid[i].Add(cell);
                onCellCreated?.Invoke(cell);
            }
        }
        onCellDone?.Invoke();
    }

    public override void OnMatrixUpdate()
    {
        for(int i=0; i< numberOfRows; i++)
        {
            for(int k=0; k< numberOfCols; k++)
            {
                cellGrid[i][k].SetStatus((Cell.Status)GetElement(i,k));
            }
        }
    }
    public void TakeTurn(int rows,int cols) 
    {
        ChangeTurn();
    }

    public void ChangeTurn()
    {
        if(currentTurn == Cell.Status.cross)
        {
            currentTurn = Cell.Status.circle;
        }
        else
        {
            currentTurn = Cell.Status.cross;
        }
    }
}

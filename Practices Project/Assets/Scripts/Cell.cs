using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    int rowNumber;
    int colNumber;
    public enum Status { none, cross, circle, win, loose }

    Status status;

    public delegate void OnStatusUpdate(Status status);
    public event OnStatusUpdate onStatusUpdate;


    
    public Cell()
    {
        CellInitialization();
    }

    public Cell(int row, int col)
    {
        this.status = Status.none;
        rowNumber = row;
        colNumber = col;
    }

    void CellInitialization()
    {
        this.status = Status.none;
        rowNumber = 0;
        colNumber = 0;
    }

    public int GettingRow()
    {
        return rowNumber;
    }

    public int GettingCol()
    {
        return colNumber;
    }

    public void SetStatus(Status tempStatus)
    {
        this.status = tempStatus;
        //Debug.Log((int)tempStatus);
        onStatusUpdate?.Invoke(status);
    }

    public Status GetStatus()
    {
        return status;
    }  

    public void Interaction()
    {
        SetStatus(Cell.Status.win);
    }
}

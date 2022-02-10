using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCell : MonoBehaviour
{
    public List<GameObject> cellStatus;
    public Cell cellScript = new Cell();

    private Cell.Status activeStatus;
    public delegate void OnCellInteraction(int rows, int cols);
    public event OnCellInteraction onCellInteraction;



    // Start is called before the first frame update
    void Start()
    {
       cellScript.onStatusUpdate += SetStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStatus(Cell.Status status) 
    {
        for(int i=0; i < cellStatus.Count; i++)
        {
            if((int)status == i)
            {
                cellStatus[i].SetActive(true);
            }
            else
            {
                cellStatus[i].SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        // onCellInteraction?.Invoke(cellScript.GettingRow(), cellScript.GettingCol());
        // cellScript.SetStatus(Cell.Status.win);

        cellScript.Interaction();
    }

    //public void SetCell(Cell cellScript) 
    //{
    //    this.cellScript = cellScript;
    //}

    private void OnDestroy()
    {
        cellScript.onStatusUpdate -= SetStatus;
    }
}

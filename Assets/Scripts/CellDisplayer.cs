using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    Basic,
    Forest,
    Mountain,
    Water
}

[ExecuteInEditMode]
public class CellDisplayer : MonoBehaviour
{
    public CellType cellType = CellType.Basic;
    
    public GameObject forestPrefab;
    public GameObject mountainPrefab;

    private GameObject cellContainer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void ChangeCellContainer()
    {
        if (cellContainer) DestroyImmediate(cellContainer);

        if (cellType == CellType.Forest)
            cellContainer = Instantiate(forestPrefab, transform.position, Quaternion.identity, transform);
        else if (cellType == CellType.Mountain)
            cellContainer = Instantiate(mountainPrefab, transform.position, Quaternion.identity, transform);
    }
}

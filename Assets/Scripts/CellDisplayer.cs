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

    private CellDisplayerAssets CDA;

    private GameObject cellContainer;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void OnEnable()
    {
        CDA = GetComponentInParent<CellDisplayerAssets>();
        print(CDA + " d");

        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        cellContainer = (transform.childCount != 0) ? transform.GetChild(0).gameObject : null;
    }

    // Update is called once per frame
    public void ChangeCellContainer()
    {
        if (cellContainer) DestroyImmediate(cellContainer);

        switch(cellType)
        {
            case CellType.Basic:
                meshFilter.mesh = CDA.basicMesh;
                meshRenderer.material = CDA.basicMaterial;
                break;
            case CellType.Forest:
                meshFilter.mesh = CDA.forestMesh;
                meshRenderer.material = CDA.forestMaterial;

                cellContainer = Instantiate(CDA.forestPrefab, transform.position, Quaternion.identity, transform);
                break;
            case CellType.Mountain:
                meshFilter.mesh = CDA.mountainMesh;
                meshRenderer.material = CDA.mountainMaterial;

                cellContainer = Instantiate(CDA.mountainPrefab, transform.position, Quaternion.identity, transform);
                break;
            case CellType.Water:
                meshFilter.mesh = CDA.waterMesh;
                meshRenderer.material = CDA.waterMaterial;
                break;
        }
            
    }
}

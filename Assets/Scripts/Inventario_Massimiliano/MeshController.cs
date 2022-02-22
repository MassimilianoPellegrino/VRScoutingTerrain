using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    public Mesh tulipMesh;
    public Mesh ibiscusMesh;

    #region Singleton

    public static MeshController instance;
    public List<Mesh> editedMeshes;

    void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;

        if (tulipMesh.subMeshCount < 4)
        {
            tulipMesh.subMeshCount = tulipMesh.subMeshCount + 1;
            tulipMesh.SetTriangles(tulipMesh.triangles, tulipMesh.subMeshCount - 1);
        }

        if (ibiscusMesh.subMeshCount < 8)
        {
            ibiscusMesh.subMeshCount = ibiscusMesh.subMeshCount + 1;
            ibiscusMesh.SetTriangles(ibiscusMesh.triangles, ibiscusMesh.subMeshCount - 1);
        }
    }

    #endregion

    public void AddMesh(Mesh mesh)
    {
        editedMeshes.Add(mesh);
    }

    public bool ContainsMesh(Mesh mesh)
    {
        if (editedMeshes.Contains(mesh))
            return true;
        else
            return false;
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    public Mesh tulipMesh;
    public Mesh ibiscusMesh;
    public Mesh lince;
    public Mesh stellaPolare;
    public Mesh orsaMaggiore;
    public Mesh cassiopea;
    public Mesh cefeo;
    public Mesh lucertola;
    public Mesh drago;
    public Mesh pegaso;
    public Mesh cigno;
    public Mesh leoneMinore;

    #region Singleton

    public static MeshController instance;
    //public List<Mesh> editedMeshes;

    void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of MeshController found!");
            return;
        }

        instance = this;

        //dopo il primo play, commentare da qui...
/*
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

        if (lince.subMeshCount < 8)
        {
            lince.subMeshCount = lince.subMeshCount + 1;
            lince.SetTriangles(lince.triangles, lince.subMeshCount - 1);
        }

        if (stellaPolare.subMeshCount < 8)
        {
            stellaPolare.subMeshCount = stellaPolare.subMeshCount + 1;
            stellaPolare.SetTriangles(stellaPolare.triangles, stellaPolare.subMeshCount - 1);
        }

        if (orsaMaggiore.subMeshCount < 20)
        {
            orsaMaggiore.subMeshCount = orsaMaggiore.subMeshCount + 1;
            orsaMaggiore.SetTriangles(orsaMaggiore.triangles, orsaMaggiore.subMeshCount - 1);
        }

        if (cassiopea.subMeshCount < 6)
        {
            cassiopea.subMeshCount = cassiopea.subMeshCount + 1;
            cassiopea.SetTriangles(cassiopea.triangles, cassiopea.subMeshCount - 1);
        }

        if (cefeo.subMeshCount < 8)
        {
            cefeo.subMeshCount = cefeo.subMeshCount + 1;
            cefeo.SetTriangles(cefeo.triangles, cefeo.subMeshCount - 1);
        }

        if (lucertola.subMeshCount < 8)
        {
            lucertola.subMeshCount = lucertola.subMeshCount + 1;
            lucertola.SetTriangles(lucertola.triangles, lucertola.subMeshCount - 1);
        }

        if (drago.subMeshCount < 15)
        {
            drago.subMeshCount = drago.subMeshCount + 1;
            drago.SetTriangles(drago.triangles, drago.subMeshCount - 1);
        }

        if (pegaso.subMeshCount < 14)
        {
            pegaso.subMeshCount = pegaso.subMeshCount + 1;
            pegaso.SetTriangles(pegaso.triangles, pegaso.subMeshCount - 1);
        }

        if (cigno.subMeshCount < 10)
        {
            cigno.subMeshCount = cigno.subMeshCount + 1;
            cigno.SetTriangles(cigno.triangles, cigno.subMeshCount - 1);
        }

        if (leoneMinore.subMeshCount < 5)
        {
            leoneMinore.subMeshCount = leoneMinore.subMeshCount + 1;
            leoneMinore.SetTriangles(leoneMinore.triangles, leoneMinore.subMeshCount - 1);
        }*/

        //...a qui
    }

    #endregion

    /*public void AddMesh(Mesh mesh)
    {
        editedMeshes.Add(mesh);
    }

    public bool ContainsMesh(Mesh mesh)
    {
        if (editedMeshes.Contains(mesh))
            return true;
        else
            return false;
    }*/

    

}

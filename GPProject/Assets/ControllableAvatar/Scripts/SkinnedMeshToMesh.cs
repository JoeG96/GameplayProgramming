using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SkinnedMeshToMesh : MonoBehaviour
{

    public SkinnedMeshRenderer skinnedMesh;
    public VisualEffect vfxGraph;
    public float refreshRate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateVFXGraph());
    }

    IEnumerator UpdateVFXGraph()
    {
        while (gameObject.activeSelf)
        {
            Mesh m = new Mesh();
            skinnedMesh.BakeMesh(m);
            vfxGraph.SetMesh("Object Mesh", m);

            yield return new WaitForSeconds (refreshRate);
        }

    }

}

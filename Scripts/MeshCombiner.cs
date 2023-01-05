using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public void CombineMeshes()
    {
        if (this.gameObject.AddComponent<MeshFilter>() == null)
        {
            this.gameObject.AddComponent<MeshFilter>();
        }

        if (this.gameObject.AddComponent<MeshRenderer>() == null)
        {
            this.gameObject.AddComponent<MeshRenderer>();
        }


        Quaternion originRot = transform.rotation;
        Vector3 originPos = transform.position;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        //Debug.Log(name + "is combining " + filters.Length + "meshes");

        Mesh finalMesh = new Mesh();

        CombineInstance[] combiners = new CombineInstance[filters.Length];

        for (int a = 0; a< filters.Length; a++)
        {
            if (filters[a].transform == transform)
                continue;

            combiners[a].subMeshIndex = 0;
            combiners[a].mesh = filters[a].sharedMesh;
            combiners[a].transform = filters[a].transform.localToWorldMatrix;

        }

        finalMesh.CombineMeshes(combiners);

        GetComponent<MeshFilter>().sharedMesh = finalMesh;

        transform.rotation = originRot;
        transform.position = originPos;

        for (int a = 0; a < transform.childCount; a++)
            transform.GetChild(a).gameObject.SetActive(false);

    }

}

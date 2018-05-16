using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralVoxelChunk : MonoBehaviour
{
    public int xVoxels = 4;
    //public int yVoxels = 4;
    public int zVoxels = 4;

    public Vector3 voxelSize = new Vector3(1f, 1f, 1f);

    public float height = 3f;
    //How sharp vertically the terrain is generated at
    public float gradient = 12f;
    public float seed = 99;

    // Use this for initialization
    void Start()
    {
        generateGrid();
    }

    void generateGrid()
    {
        GameObject[] voxels = new GameObject[xVoxels * zVoxels];

        //oPos = origin point that the voxel chunk is generated from
        Vector3 oPos = new Vector3(transform.position.x, transform.position.z);

        int i = -1;

        for (int x = 0; x < xVoxels; x++)
        {
            for (int z = 0; z < zVoxels; z++)
            {
                i++;

                voxels[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                oPos = transform.position;
                oPos.y = 0f;
                oPos.x -= xVoxels / 2 * voxelSize.x;
                oPos.z -= zVoxels / 2 * voxelSize.z;

                oPos.x += x * voxelSize.x;
                oPos.z += z * voxelSize.z;

                //Snap to grid.
                oPos.x = Mathf.Round(oPos.x);
                oPos.z = Mathf.Round(oPos.z);

                //PerlinNoise | dont believe I did my math right, still needs tremendous
                //Testing to see if it works correctly
                oPos.y += Mathf.PerlinNoise((1000000f + (transform.position.x + oPos.x)) / gradient,
                    (seed + 1000000f + (transform.position.z + oPos.z)) / gradient) * height;

                oPos.y = Mathf.Floor(oPos.y);

                voxels[i].transform.position = oPos;
                //Apply the voxel scale to every voxel
                voxels[i].transform.localScale = voxelSize;
                //combines all of the voxels into one object which is this 
                //Object to more efficiently create all of these voxels
                voxels[i].transform.parent = transform;
            }
        }

        //Combine all of the voxels meshes into one object 
        CombineMeshes();

        //Since we now have all of the voxels mesh data
        //We no longer need the separate voxels themselves
        //So destroy them 
        for (i = 0; i < voxels.Length; i++)
        {
            Destroy(voxels[i]);
        }
    }

    void CombineMeshes()
    {
        //Getting every childs meshfilter 
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        //Used to combine all of the voxels meshfilters into a singualr object
        CombineInstance[] combined = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            //all of the meshes within combined then combine meshes
            combined[i].mesh = meshFilters[i].sharedMesh;
            //Making sure the local position is relative to teh parent
            combined[i].transform = meshFilters[i].transform.localToWorldMatrix;
            //Once added to the combined mesh set them to false
            meshFilters[i].gameObject.SetActive(false);
        }

        //If the gameobject this is on does not have a meshfilter 
        //Then add one
        if (gameObject.GetComponent<MeshFilter>() == null)
        {
            //adding the mesh filter to the game object
            gameObject.AddComponent<MeshFilter>();

            //Emptying out mesh filter of all meshes
            transform.GetComponent<MeshFilter>().mesh = new Mesh();
            transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combined, true);
            //Recalculating these makes sure teh colliders are set correctly
            transform.GetComponent<MeshFilter>().mesh.RecalculateBounds();
            transform.GetComponent<MeshFilter>().mesh.RecalculateNormals();

            transform.gameObject.AddComponent<MeshCollider>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralVoxelGenerator : MonoBehaviour
{
    public GameObject block;
    public int worldSize;

    public IEnumerator GenerateTerrain()
    {
        for (int x = 0; x < worldSize; x++)
        {
            for (int y = 0; y < worldSize; y++)
            {
                for (int z = 0; z < worldSize; z++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    GameObject cube = GameObject.Instantiate(block, pos, Quaternion.identity);
                    cube.name = x + "_" + y + "_" + z;
                }
                yield return null;
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(GenerateTerrain());
	}
}

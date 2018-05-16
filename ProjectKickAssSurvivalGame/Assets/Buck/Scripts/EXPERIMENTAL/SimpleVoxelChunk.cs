using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleVoxelChunk : MonoBehaviour
{
    [SerializeField]
    float freq = 10f;

    //How hight the terrain will generate to 
    [SerializeField]
    float height = 10f;

    [SerializeField]
    GameObject currentBlockType;

    //Reference to voxel chunks position
    Vector3 myPos;

	void Start ()
    {
        GenerateTerrain();
	}

    void GenerateTerrain()
    {
        //Gotcha Bitch
        myPos = transform.position;

        int cols = 100;
        int rows = 100;

        for (int x = 0; x < cols; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                float y = Mathf.PerlinNoise((myPos.x+x) / freq, (myPos.z+z) / freq) * height;

                GameObject newBlock = Instantiate(currentBlockType);

                newBlock.transform.position = new Vector3(myPos.x + x, y, myPos.z + z); 
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    public Material cubeMaterial;
    public Block[,,] chunkData;
    public GameObject chunk;

    void BuildChunk()
    {
        //Come back to this and differentiate X,Y,Z chunksizes
        chunkData = new Block[World.chunkSize, World.chunkSize, World.chunkSize];

        //Create blocks
        for (int x = 0; x < World.chunkSize; x++)
        {
            for (int y = 0; y < World.chunkSize; y++)
            {
                for (int z = 0; z < World.chunkSize; z++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    if (Random.Range(0, 100) < 50)
                        chunkData[x, y, z] = new Block(Block.BlockType.DIRT, pos, chunk.gameObject, this);
                    else
                        chunkData[x, y, z] = new Block(Block.BlockType.AIR, pos, chunk.gameObject, this);
                }
            }
        }
    }

    public void DrawChunk()
    {
        //Draw blocks
        for (int x = 0; x < World.chunkSize; x++)
        {
            for (int y = 0; y < World.chunkSize; y++)
            {
                for (int z = 0; z < World.chunkSize; z++)
                {
                    chunkData[x, y, z].Draw();
                }
            }
        }
        CombineQuads();
    }

    public Chunk(Vector3 position, Material c)
    {
        chunk = new GameObject(World.BuildChunkName(position));
        chunk.transform.position = position;
        cubeMaterial = c;
        BuildChunk();
    }

    void CombineQuads()
    {
        //Comdine all children meshes
        MeshFilter[] meshFilters = chunk.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            i++;
        }

        //Create new mesh on parent
        MeshFilter mf = (MeshFilter)chunk.gameObject.AddComponent(typeof(MeshFilter));
        mf.mesh = new Mesh();

        //Add combined meshes on children as the parent's mesh
        mf.mesh.CombineMeshes(combine);

        //Create renderer for parent
        MeshRenderer renderer = chunk.gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material = cubeMaterial;

        //Delete uncombined children
        foreach (Transform quad in chunk.transform)
        {
            GameObject.Destroy(quad.gameObject);
        }
    }
}

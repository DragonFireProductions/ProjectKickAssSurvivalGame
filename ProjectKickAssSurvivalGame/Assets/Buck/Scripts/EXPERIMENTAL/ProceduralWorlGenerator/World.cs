using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public Material textureAtlas;
    public static int columnHeight = 1;
    public static int chunkSize = 8;
    public static int worldSize = 2;
    public static Dictionary<string, Chunk> chunks;

    public static string BuildChunkName(Vector3 v)
    {
        return (int)v.x + "_" + (int)v.y + "_" + (int)v.z;
    }

    IEnumerator BuildChunkColumn()
    {
        //Loops through and builds column then adds it to the dictionary 
        for (int i = 0; i < columnHeight; i++)
        {
            Vector3 chunkPosition = new Vector3(transform.position.x, 
                                                i * chunkSize,
                                                transform.position.z);
            Chunk c = new Chunk(chunkPosition, textureAtlas);
            c.chunk.transform.parent = transform;
            chunks.Add(c.chunk.name, c);
        }

        foreach (KeyValuePair<string, Chunk> c in chunks)
        {
            c.Value.DrawChunk();
            yield return null;
        }
    }

    IEnumerator BuildWorld()
    {
        for (int x = 0; x < worldSize; x++)
        {
            for (int y = 0; y < worldSize; y++)
            {
                for (int z = 0; z < worldSize; z++)
                {
                    Vector3 chunkPosition = new Vector3(x * chunkSize, y * chunkSize, z * chunkSize);
                    Chunk c = new Chunk(chunkPosition, textureAtlas);
                    c.chunk.transform.parent = transform;
                    chunks.Add(c.chunk.name, c);
                }
            }
        }

        foreach (KeyValuePair<string, Chunk> c in chunks)
        {
            c.Value.DrawChunk();
            yield return null;
        }
    }

    void Start()
    {
        chunks = new Dictionary<string, Chunk>();
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        StartCoroutine(BuildWorld());
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateQuads : MonoBehaviour
{
    enum Cubeside {BOTTOM, TOP, LEFT, RIGHT, FRONT, BACK};
    public enum BlockType{ GRASS, DIRT, STONE};

    public Material cubeMaterial;
    public BlockType btype;

    Vector2[,] blockUVs =
    {
    /*GRASSTOP*/    { new Vector2(0.125f, 0.375f), new Vector2(0.1875f, 0.375f),
                      new Vector2(0.125f, 0.4375f), new Vector2 (0.1875f, 0.4375f)},
    /*GRASSSIDE*/   { new Vector2(0.1875f, 0.9375f), new Vector2(0.25f, 0.9375f),
                      new Vector2(0.1875f, 1.0f), new Vector2(0.25f, 1.0f)},
    /*DIRT*/        { new Vector2(0.125f, 0.9375f), new Vector2(0.1875f, 0.9375f),
                      new Vector2(0.125f, 1.0f), new Vector2(0.1875f, 1.0f)},
    /*STONE*/       { new Vector2(0, 0.875f), new Vector2(0.0625f, 0.875f),
                      new Vector2(0, 0.9375f), new Vector2(0.0625f, 0.9375f)}

    };

    void CreateQuad(Cubeside side)
    {
        Mesh mesh = new Mesh();
        mesh.name = "ScriptedMesh" + side.ToString();

        Vector3[] vertices = new Vector3[4];
        Vector3[] normals = new Vector3[4];
        Vector2[] uvs = new Vector2[4];
        //Quad has 2 triangles | each triangle has 3 verticies
        int[] triangles = new int[6];

        //All possible UVs
        Vector2 uv00 = new Vector2(0f, 0f);
        Vector2 uv10 = new Vector2(1f, 0f);
        Vector2 uv01 = new Vector2(0f, 1f);
        Vector2 uv11 = new Vector2(1f, 1f);

        if (btype == BlockType.GRASS && side == Cubeside.TOP)
        {
            uv00 = blockUVs[0, 0];
            uv10 = blockUVs[0, 1];
            uv01 = blockUVs[0, 2];
            uv11 = blockUVs[0, 3];
        }
        else if (btype == BlockType.GRASS && side == Cubeside.BOTTOM)
        {
            uv00 = blockUVs[(int)(BlockType.DIRT + 1), 0];
            uv10 = blockUVs[(int)(BlockType.DIRT + 1), 1];
            uv01 = blockUVs[(int)(BlockType.DIRT + 1), 2];
            uv11 = blockUVs[(int)(BlockType.DIRT + 1), 3];
        }
        else
        {
            uv00 = blockUVs[(int)(btype + 1), 0];
            uv10 = blockUVs[(int)(btype + 1), 1];
            uv01 = blockUVs[(int)(btype + 1), 2];
            uv11 = blockUVs[(int)(btype + 1), 3];
        }

        //All possible verticies
        Vector3 p0 = new Vector3(-0.5f, -0.5f, 0.5f);
        Vector3 p1 = new Vector3(0.5f, -0.5f, 0.5f);
        Vector3 p2 = new Vector3(0.5f, -0.5f, -0.5f);
        Vector3 p3 = new Vector3(-0.5f, -0.5f, -0.5f);
        Vector3 p4 = new Vector3(-0.5f, 0.5f, 0.5f);
        Vector3 p5 = new Vector3(0.5f, 0.5f, 0.5f);
        Vector3 p6 = new Vector3(0.5f, 0.5f, -0.5f);
        Vector3 p7 = new Vector3(-0.5f, 0.5f, -0.5f);

        vertices = new Vector3[] { p4, p5, p1, p0 };
        normals = new Vector3[] { Vector3.forward,
                                  Vector3.forward,
                                  Vector3.forward,
                                  Vector3.forward};

        uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
        triangles = new int[] { 3, 1, 0, 3, 2, 1 };

        //Hooking up all of the verticies, normals, uvs, and triangles for a single quad
        switch (side)
        {
            case Cubeside.BOTTOM:
                vertices = new Vector3[] { p0, p1, p2, p3 };
                normals = new Vector3[] { Vector3.down, Vector3.down, Vector3.down, Vector3.down };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.TOP:
                vertices = new Vector3[] { p7, p6, p5, p4 };
                normals = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.LEFT:
                vertices = new Vector3[] { p7, p4, p0, p3 };
                normals = new Vector3[] { Vector3.left, Vector3.left, Vector3.left, Vector3.left };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.RIGHT:
                vertices = new Vector3[] { p5, p6, p2, p1 };
                normals = new Vector3[] { Vector3.right, Vector3.right, Vector3.right, Vector3.right };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.FRONT:
                vertices = new Vector3[] { p4, p5, p1, p0 };
                normals = new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
            case Cubeside.BACK:
                vertices = new Vector3[] { p6, p7, p3, p2 };
                normals = new Vector3[] { Vector3.back, Vector3.back, Vector3.back, Vector3.back };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                break;
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();

        GameObject quad = new GameObject("Quad");
        quad.transform.parent = gameObject.transform;
        MeshFilter meshFilter = (MeshFilter)quad.AddComponent(typeof(MeshFilter));
        meshFilter.mesh = mesh;
        MeshRenderer renderer = quad.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material = cubeMaterial;
    }

    void CombineQuads()
    {
        //Comdine all children meshes
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            i++;
        }

        //Create new mesh on parent
        MeshFilter mf = (MeshFilter) gameObject.AddComponent(typeof(MeshFilter));
        mf.mesh = new Mesh();

        //Add combined meshes on children as the parent's mesh
        mf.mesh.CombineMeshes(combine);

        MeshRenderer renderer = gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material = cubeMaterial;

        foreach (Transform quad in transform)
        {
            Destroy(quad.gameObject);
        }
    }

    void CreateCube()
    {
        CreateQuad(Cubeside.FRONT);
        CreateQuad(Cubeside.BACK);
        CreateQuad(Cubeside.TOP);
        CreateQuad(Cubeside.BOTTOM);
        CreateQuad(Cubeside.LEFT);
        CreateQuad(Cubeside.RIGHT);
    }

    void Start()
    {
        CreateCube();
        CombineQuads();
    }
}

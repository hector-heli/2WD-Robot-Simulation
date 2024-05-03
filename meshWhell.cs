using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    // Distorts the mesh vertically.
    void Update()
    {
        // Get instantiated mesh
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        // Randomly change vertices
        Vector3[] vertices = mesh.vertices;
        int p = 0;
        while (p < vertices.Length)
        {
            vertices[p] += new Vector3(0, Random.Range(-0.0F, 0.0F), 0);
            p++;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
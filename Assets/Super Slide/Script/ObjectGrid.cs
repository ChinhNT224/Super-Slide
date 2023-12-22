using UnityEngine;

public class ObjectMatrix : MonoBehaviour
{
    public int rows = 6;
    public int columns = 6;
    public float spacing = 0.6f;
    public GameObject prefab; 
    public Transform centerObject; 

    void Start()
    {
        GenerateMatrix();
    }

    void GenerateMatrix()
    {
        int halfRows = rows / 2;
        int halfColumns = columns / 2;

        for (int row = -halfRows; row < halfRows; row++)
        {
            for (int col = -halfColumns; col < halfColumns; col++)
            {
                float xOffset = col * spacing;
                float yOffset = row * spacing;

                Vector3 spawnPosition = centerObject.position + new Vector3(xOffset, yOffset, 0f);
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}

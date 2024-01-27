using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerate : MonoBehaviour
{
    public Vector2Int size;
    public Vector2 offSet;
    public GameObject brickPrefab;
    public Gradient gradient;

    private void Awake()
    {
        for(int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + 
                                               new Vector3((float)((size.x-1)*.5f-i) * offSet.x, j* offSet.y, 0);
                newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j / (size.y - 1));
            }
        }
    }
}

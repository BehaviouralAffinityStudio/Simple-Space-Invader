using UnityEngine;
using System.Collections.Generic;

// DEBUGGING TO BE DONE : L.44

public class InvaderManager : MonoBehaviour
{
    // Invaders Game Object Section
    [SerializeField] private GameObject[] invaderType = new GameObject[3];
                     public GameObject[,] invaders = new GameObject[5,10];
                     public List<GameObject> botRow = new List<GameObject>{ };
                     public List<int> botVerticalAxis = new List<int> { };

    // Sprite Size Section
    [SerializeField] private float spriteSize = 0.64f;
    // Spwan Position section
    [SerializeField] private Transform InvaderSpawnTransform;

    // Spawn Manager
    void Awake()
    {
        for (int row = 0; row < 5; ++row)
        {
            for (int column = 0; column < 10; ++column)
            {
                if (row == 0)
                    invaders[row, column] = Instantiate(invaderType[0], InvaderSpawnTransform.position + new Vector3(spriteSize*column, spriteSize*row, 0f), Quaternion.identity) as GameObject;
                else if (row == 1 || row == 2)
                    invaders[row, column] = Instantiate(invaderType[1], InvaderSpawnTransform.position + new Vector3(spriteSize * column, -spriteSize * row, 0f), Quaternion.identity) as GameObject;
                else if (row == 3)
                    invaders[row, column] = Instantiate(invaderType[2], InvaderSpawnTransform.position + new Vector3(spriteSize * column, -spriteSize * row, 0f), Quaternion.identity) as GameObject;
                else if (row == 4)
                {
                    invaders[row, column] = Instantiate(invaderType[2], InvaderSpawnTransform.position + new Vector3(spriteSize * column, -spriteSize * row, 0f), Quaternion.identity) as GameObject;
                    botRow.Add(invaders[row, column]);
                    botVerticalAxis.Add(row);
                }
                invaders[row, column].transform.parent = gameObject.transform;
            }
        }
    }

    // Death Manager
    // Check if any of the indexes are null (no alien left in the column)
    //      If so, remove the gameobject from list
    //
    // DEBUGGING TO BE DONE:
    //      - When death are to numerous in short period of time, fireManager bugs
    //      - Killing enemies higher than the current botRow index decrement prematurely the index of said botRow
    //      - Create list for invaders for better modularity (see forloop above)?

    private void FixedUpdate()
    {
        for (int columnIndex = 0; columnIndex < botRow.Count; ++columnIndex)
        {
            // If current index is NULL && not on row 0
            //      - Reduce row by 1 
            //      - Check if
            if (botRow[columnIndex] == null && botVerticalAxis[columnIndex] > 0)
            {
                botVerticalAxis[columnIndex] -= 1;
                botRow[columnIndex] = invaders[botVerticalAxis[columnIndex], columnIndex];
            }

            if (botRow[columnIndex] == null && botVerticalAxis[columnIndex] == 0)
            {
                botRow.RemoveAt(columnIndex);
            }
        }
    }
}
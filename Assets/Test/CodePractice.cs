using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static System.Linq.Enumerable;

public class CodePractice : MonoBehaviour
{
    private int[] arry = {0, 1, 0, 3, 12};

    void Start()
    {
        for (int i = 0; i < arry.Length; i++)
        {
            if (arry[i] == 0)
            {
                for (int j = i + 1; j < arry.Length; j++)
                {
                    if (arry[j] != 0)
                    {
                        arry[i] = arry[j];
                        arry[j] = 0;
                        break;
                    }
                }
            }
        }


        for (int i = 0; i < arry.Length; i++)
        {
            Debug.Log(i + " : " + arry[i]);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bespalov : MonoBehaviour
{
    private int globalVariable;

    private void Start()
    {
        int localVariable;

        TestMethod("Andrew", 18);
        TestMethod("John", 23);
        TestMethod("Anna", 19);
        
    }

    private void TestMethod(string name, int age)
    {
        name = name + " 1"; // Anna 1
        Debug.Log(name);
        Debug.Log(age);
    }

}
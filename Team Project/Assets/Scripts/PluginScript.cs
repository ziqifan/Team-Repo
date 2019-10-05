using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class PluginScript : MonoBehaviour
{
    float x = 0f;
    float y = 0f;
    float z = 0f; 
    const string DLL_NAME = "UnityDLLinclass1";

    [DllImport(DLL_NAME)]
    private static extern void savePos(float x, float y, float z);


    [DllImport(DLL_NAME)]
    private static extern void loadPos(float x, float y, float z);



    [DllImport(DLL_NAME)]
    private static extern int doSomething();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(doSomething());
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            savePos(transform.position.x, transform.position.y, transform.position.z);
            Debug.Log("Will save the position");
        }



    }
}

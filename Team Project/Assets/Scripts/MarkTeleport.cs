using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class MarkTeleport : MonoBehaviour, ITeleport
{
    const string DLL_NAME = "Individual A1 VS";

    [DllImport(DLL_NAME)]
    private static extern int savePosition(float x, float y, float z);

    [DllImport(DLL_NAME)]
    private static extern float loadPositionX();

    [DllImport(DLL_NAME)]
    private static extern float loadPositionY();

    [DllImport(DLL_NAME)]
    private static extern float loadPositionZ();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.position = new Vector3(loadPositionX(), loadPositionY(), loadPositionZ());
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            CommandProcessor.ExcuteCommand(this, transform.position);
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            CommandProcessor.Undo();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            CommandProcessor.Redo();
        }
    }
}

public interface ITeleport
{
    Transform transform { get; }
}

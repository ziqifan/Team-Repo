using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class MarkTeleport : MonoBehaviour, ITeleport
{
    //Find DLL by name
    const string DLL_NAME = "Individual A1 VS";

    //Import DLL's functions
    [DllImport(DLL_NAME)]
    private static extern int savePosition(float x, float y, float z);

    [DllImport(DLL_NAME)]
    private static extern float loadPositionX();

    [DllImport(DLL_NAME)]
    private static extern float loadPositionY();

    [DllImport(DLL_NAME)]
    private static extern float loadPositionZ();

    // Update is called once per frame
    void Update()
    {
        //Press T to teleport to maked position
        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.position = new Vector3(loadPositionX(), loadPositionY(), loadPositionZ());
        }
        //Press M to mark position
        if (Input.GetKeyDown(KeyCode.M))
        {
            CommandProcessor.ExcuteCommand(this, transform.position);
        }
        //Press U to undo mark to old position
        if(Input.GetKeyDown(KeyCode.U))
        {
            CommandProcessor.Undo();
        }
        //Press R ro redo the undoed position
        if (Input.GetKeyDown(KeyCode.R))
        {
            CommandProcessor.Redo();
        }
    }
}

//create a interface for this object
public interface ITeleport
{
    Transform transform { get; }
}

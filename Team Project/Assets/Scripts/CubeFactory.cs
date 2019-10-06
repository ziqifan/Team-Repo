using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class CubeFactory : MonoBehaviour
{
    public GameObject cubeOne;
    public GameObject cubeTwo;
    public GameObject cubeThree;
    public GameObject cubeFour;
    public GameObject cubeFive;

    public static GameObject CubeOne;
    public static GameObject CubeTwo;
    public static GameObject CubeThree;
    public static GameObject CubeFour;
    public static GameObject CubeFive;

    public static Dictionary<int, Type> factoryDict;

    // Start is called before the first frame update
    void Start()
    {
        CubeOne = cubeOne;
        CubeTwo = cubeTwo;
        CubeThree = cubeThree;
        CubeFour = cubeFour;
        CubeFive = cubeFive;

        var factoryTypes = Assembly.GetAssembly(typeof(CubeMaker)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(CubeMaker)));

        factoryDict = new Dictionary<int, Type>();

        foreach(var type in factoryTypes)
        {
            var tempCube = Activator.CreateInstance(type) as CubeMaker;
            factoryDict.Add(tempCube.Name, type);
        }
    }

    public static CubeMaker MakeCube(int cubeType, Vector3 possition, Quaternion rotation)
    {
        if(factoryDict.ContainsKey(cubeType))
        {
            Type type = factoryDict[cubeType];
            var cube = Activator.CreateInstance(type) as CubeMaker;
            cube.SpawnCube(possition, rotation);
            return cube;
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract class CubeMaker
    {
        public abstract int Name { get; }
        public abstract void SpawnCube(Vector3 pos, Quaternion rot);
    }

    public class MakeCubeOne:CubeMaker
    {
        public override int Name => 1;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            Instantiate(CubeOne, pos, rot);
        }
    }

    public class MakeCubeTwo : CubeMaker
    {
        public override int Name => 2;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            Instantiate(CubeTwo, pos, rot);
        }
    }

    public class MakeCubeThree : CubeMaker
    {
        public override int Name => 3;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            Instantiate(CubeThree, pos, rot);
        }
    }

    public class MakeCubeFour : CubeMaker
    {
        public override int Name => 4;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            Instantiate(CubeFour, pos, rot);
        }
    }

    public class MakeCubeFive : CubeMaker
    {
        public override int Name => 5;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            Instantiate(CubeFive, pos, rot);
        }
    }


}

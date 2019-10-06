using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CommandProcessor : MonoBehaviour
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

    private static ObjectPooler objectPooler;

    private static List<Command> _commands = new List<Command>();
    private static int _currentCommandIndex;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        _currentCommandIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ExcuteCommand(ITeleport tel, Vector3 pos)
    {
        var markPositionCommand = new MarkPositionCommand(tel, pos);

        if(_currentCommandIndex != _commands.Count - 1)
        {
            int count = _commands.Count - 1;
            for(int i = count; i > _currentCommandIndex; i--)
                _commands.RemoveAt(i);
        }
        _commands.Add(markPositionCommand);
        markPositionCommand.Execute();
        _currentCommandIndex++;
    }

    public static void Undo()
    {
        if (_currentCommandIndex < 1)
            return;

        _commands[_currentCommandIndex].Undo();
        _currentCommandIndex--;
    }

    public static void Redo()
    {
        if (_currentCommandIndex == _commands.Count - 1)
            return;

        _currentCommandIndex++;
        _commands[_currentCommandIndex].Redo();
    }

    public abstract class Command
    {
        protected ITeleport _teleport;

        public Command(ITeleport teleport)
        {
            _teleport = teleport;
        }
        public abstract void Execute();
        public abstract void Undo();

        public abstract void Redo();
    }

    public class MarkPositionCommand:Command
    {
        private Vector3 _position;
        private Vector3 _originalPosition;

        public MarkPositionCommand(ITeleport teleport, Vector3 position):base(teleport)
        {
            _position = position;
        }

        public override void Execute()
        {
            _originalPosition = new Vector3(loadPositionX(), loadPositionY(), loadPositionZ());
            objectPooler.SpawnObject("Teleport", _position, Quaternion.identity);
            Debug.Log(savePosition(_position.x, _position.y, _position.z));
        }

        public override void Undo()
        {
            objectPooler.SpawnObject("Teleport", _originalPosition, Quaternion.identity);
            Debug.Log(savePosition(_originalPosition.x, _originalPosition.y, _originalPosition.z));
        }

        public override void Redo()
        {
            objectPooler.SpawnObject("Teleport", _position, Quaternion.identity);
            Debug.Log(savePosition(_position.x, _position.y, _position.z));
        }
    }
}

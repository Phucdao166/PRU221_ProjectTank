using Assets.Scripts;
using DefaultNamespace;
using Entity;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TankController : MonoBehaviour
{
    // Start is called before the first frame update
    private Tank _tank;

    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;
    private TankMover _tankMover;
    private CameraController _cameraController;
    private SpriteRenderer _renderer;
    private TankBuilder _tankBuilder;
    public new GameObject camera;
    public List<MaterialEnum> materialEnums;
    private int currentIndex;

    private void Start()
    {
        _tank = new Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
			Position = new Vector3(-6, -5, 0),
			Guid = GUID.Generate()
        };
        gameObject.transform.position = _tank.Position;
        _tankMover = gameObject.GetComponent<TankMover>();
        _cameraController = camera.GetComponent<CameraController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _tankBuilder = gameObject.GetComponent<TankBuilder>();
        currentIndex = 0;
        Move(Direction.Down);
        materialEnums.Add(MaterialEnum.Trees);
        materialEnums.Add(MaterialEnum.Water);
        materialEnums.Add(MaterialEnum.WallBrick);
        materialEnums.Add(MaterialEnum.WallSteel);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Move(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move(Direction.Right);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Move(Direction.Up);
        }
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            currentIndex = 0;
        }
        else if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))
        {
            currentIndex = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3))
        {
            currentIndex = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Keypad4))
        {
            currentIndex = 3;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Build(materialEnums[currentIndex]);
        }
    }

    private void Move(Direction direction)
    {
        _tank.Position = _tank.Position + _tankMover.Move(direction);
        _tank.Direction = direction;
        _renderer.sprite = direction switch
        {
            Direction.Down => tankDown,
            Direction.Up => tankUp,
            Direction.Left => tankLeft,
            Direction.Right => tankRight,
            _ => _renderer.sprite
        };
    }

    private void Fire()
    {
        var b = new Bullet
        {
            Direction = _tank.Direction,
            Tank = _tank,
            InitialPosition = _tank.Position
        };
        GetComponent<TankFirer>().Fire(b);
    }
    private void Build(MaterialEnum materialEnum)
    {
        BuildingMaterial buildingMaterial = new(materialEnum);

        _tankBuilder.Build(buildingMaterial);
    }

}
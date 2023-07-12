using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Water;
    public GameObject Trees;
    public GameObject WallBrick;
    public GameObject WallSteel;
    public BuildingMaterial _material;
    private float lastBuild = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Build(BuildingMaterial material)
    {
        var currentPos = gameObject.transform.position;
        GameObject spawnObject = null;
        switch (material.Name)
        {
            case MaterialEnum.Water:
                spawnObject = Instantiate(Water, new Vector3(currentPos.x, currentPos.y, 0), Quaternion.identity);
                break;
            case MaterialEnum.Trees:
                spawnObject = Instantiate(Trees, new Vector3(currentPos.x, currentPos.y, 0), Quaternion.identity);
                break;
            case MaterialEnum.WallBrick:
                spawnObject = Instantiate(WallBrick, new Vector3(currentPos.x, currentPos.y, 0), Quaternion.identity);
                break;
            case MaterialEnum.WallSteel:
                spawnObject = Instantiate(WallSteel, new Vector3(currentPos.x, currentPos.y, 0), Quaternion.identity);
                break;
        }
        lastBuild = Time.time;
        spawnObject.AddComponent<BuidingMaterialController>().buildingMaterial = new BuildingMaterial(material.Name);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class BuidingMaterialController : MonoBehaviour
    {
        public BuildingMaterial buildingMaterial;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Spawn(MaterialEnum materialEnum)
        {
            buildingMaterial = new BuildingMaterial(materialEnum);
        }
    }
}

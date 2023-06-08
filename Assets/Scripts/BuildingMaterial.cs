using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class BuildingMaterial
    {
        public MaterialEnum Name { get; set; }
        public bool CanShootThrough { get; set; }
        public bool CanGoThrough { get; set; }
        public bool CanDestroy { get; set; }
        public Vector3 Position { get; set; }

        public BuildingMaterial(MaterialEnum name)
        {
            Name = name;
            switch (Name)
            {
                case MaterialEnum.Water:
                    break;
                case MaterialEnum.Trees:
                    break;
                case MaterialEnum.WallBrick:
                    break;
                case MaterialEnum.WallSteel:
                    break;
            }
        }
    }
}

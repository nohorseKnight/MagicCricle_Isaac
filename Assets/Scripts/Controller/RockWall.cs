using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class RockWall : BaseController
    {
        void Start()
        {
            Destroy(gameObject, 5f);
        }
    }
}
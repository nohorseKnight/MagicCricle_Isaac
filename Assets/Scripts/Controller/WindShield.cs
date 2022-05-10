using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class WindShield : BaseController
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null)
            {
                other.GetComponent<Player>().DecreaseHp(25f);
                Destroy(gameObject);
            }
        }
    }
}
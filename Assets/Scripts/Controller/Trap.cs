using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class Trap : BaseController
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null)
            {
                other.GetComponent<Player>().DecreaseHp(25f);
                Destroy(gameObject);
            }
            if (other.GetComponent<Slime>() != null)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
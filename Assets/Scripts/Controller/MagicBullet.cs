using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCricle_Isaac
{
    public class MagicBullet : BaseController
    {
        public Vector3 ShootDir;
        public float MovingSpeed;
        void Start()
        {
            // transform.position = transform.position + ShootDir * 1;
        }

        void Update()
        {
            transform.position = transform.position + ShootDir * MovingSpeed * Time.deltaTime;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null) return;
            if (other.GetComponent<MagicBullet>() != null) return;
            if (other.GetComponent<RockWall>() != null) return;
            Destroy(gameObject);
        }
    }
}
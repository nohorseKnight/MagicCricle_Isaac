using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class ShootMagicBulletCommand : AbstractCommand
    {
        private Transform _bullet;
        private Vector3 _shootDir;
        public ShootMagicBulletCommand(Transform bullet, Vector3 shootDir)
        {
            _bullet = bullet;
            _shootDir = shootDir;
        }
        protected override void OnExecute()
        {
            float moveSpeed = 10f;
            _bullet.GetComponent<Rigidbody2D>().AddForce(_shootDir * moveSpeed, ForceMode2D.Impulse);
        }
    }
}
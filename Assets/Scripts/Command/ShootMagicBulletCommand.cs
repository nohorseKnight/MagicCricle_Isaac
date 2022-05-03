using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class ShootMagicBulletCommand : AbstractCommand
    {
        private GameObject _bullet;
        private Vector3 _shootDir;
        private Vector3 _startPos;
        public ShootMagicBulletCommand(Vector3 pos, float h, float v)
        {
            _startPos = pos;
            if (Mathf.Abs(h) > Mathf.Abs(v))
            {
                _shootDir = new Vector3(h > 0 ? 1 : -1, 0, 0);
            }
            else
            {
                _shootDir = new Vector3(0, v > 0 ? 1 : -1, 0);
            }
        }
        protected override void OnExecute()
        {
            float moveSpeed = 10f;
            _bullet = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/MagicBullet"), _startPos, Quaternion.identity);
            _bullet.transform.eulerAngles = new Vector3(0, 0, -90f + Util.GetAngleFromVectorFloat(_shootDir));
            _bullet.GetComponent<Rigidbody2D>().AddForce(_shootDir * moveSpeed, ForceMode2D.Impulse);
            GameObject.Destroy(_bullet, 5f);
        }
    }
}
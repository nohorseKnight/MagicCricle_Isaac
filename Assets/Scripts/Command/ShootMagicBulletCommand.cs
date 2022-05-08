using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class ShootMagicBulletCommand : AbstractCommand
    {
        GameObject _bullet;
        Transform _shootByTrans;
        Vector3 _shootDir;
        Vector3 _startPos;
        int _bulletNumber;
        float _degree;
        float _speed;
        public ShootMagicBulletCommand(Transform shootByTrans, float h, float v, int bulletNumber, float speed)
        {
            _shootByTrans = shootByTrans;
            _startPos = _shootByTrans.position;
            _degree = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
            if ((_degree >= 0 && _degree <= 45f) || (_degree > -45f && _degree < 0))
            {
                _shootDir = new Vector3(1, 0, 0);
                _degree = 0;
            }
            else if (_degree > 45f && _degree <= 135f)
            {
                _shootDir = new Vector3(0, 1, 0);
                _degree = 90f;
            }
            else if ((_degree > 135f && _degree <= 180f) || (_degree >= -180f && _degree < -135f))
            {
                _shootDir = new Vector3(-1, 0, 0);
                _degree = 180f;
            }
            else if (_degree >= -135f && _degree <= -45f)
            {
                _shootDir = new Vector3(0, -1, 0);
                _degree = -90f;
            }
            if (Mathf.Abs(h - 0) < 0.01f && Mathf.Abs(v - 0) < 0.01f)
            {
                _shootDir = new Vector3(0, -1, 0);
                _degree = -90f;
            }
            _bulletNumber = bulletNumber;
            _speed = speed;
        }
        protected override void OnExecute()
        {
            if (_bulletNumber == 1)
            {
                InstantiateBullet(0);
            }
            else if (_bulletNumber == 2)
            {
                InstantiateBullet(30f);
                InstantiateBullet(-30f);
            }
            else if (_bulletNumber == 3)
            {
                InstantiateBullet(0);
                InstantiateBullet(30f);
                InstantiateBullet(-30f);
            }

            GameObject.Destroy(_bullet, 5f);
        }

        void InstantiateBullet(float offsetDegree)
        {
            _bullet = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/MagicBullet"), _startPos, Quaternion.identity);
            _bullet.transform.eulerAngles = new Vector3(0, 0, -90f + Util.GetAngleFromVectorFloat(_shootDir) + offsetDegree);
            _bullet.GetComponent<MagicBullet>().ShootDir = new Vector3((float)Math.Cos((_degree + offsetDegree) / Mathf.Rad2Deg), (float)Math.Sin((_degree + offsetDegree) / Mathf.Rad2Deg), 0);
            _bullet.GetComponent<MagicBullet>().MovingSpeed = _speed;
        }
    }
}
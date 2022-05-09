using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class PlayerSetRockWallCommand : AbstractCommand
    {
        Transform _playerTrans;
        Vector3 _offset;
        float _degree;
        public PlayerSetRockWallCommand(Transform playerTrams, float h, float v)
        {
            _playerTrans = playerTrams;
            _degree = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
            if ((_degree >= 0 && _degree <= 45f) || (_degree > -45f && _degree < 0))
            {
                _offset = new Vector3(1, 0, 0);
                _degree = 0;
            }
            else if (_degree > 45f && _degree <= 135f)
            {
                _offset = new Vector3(0, 1, 0);
                _degree = 90f;
            }
            else if ((_degree > 135f && _degree <= 180f) || (_degree >= -180f && _degree < -135f))
            {
                _offset = new Vector3(-1, 0, 0);
                _degree = 180f;
            }
            else if (_degree >= -135f && _degree <= -45f)
            {
                _offset = new Vector3(0, -1, 0);
                _degree = -90f;
            }
            if (Mathf.Abs(h - 0) < 0.01f && Mathf.Abs(v - 0) < 0.01f)
            {
                _offset = new Vector3(0, -1, 0);
                _degree = -90f;
            }
        }
        protected override void OnExecute()
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/RockWall"));
            obj.transform.position = _playerTrans.position + _offset * 1.0f;
            obj.transform.eulerAngles = new Vector3(0, 0, Util.GetAngleFromVectorFloat(_offset));
        }
    }
}
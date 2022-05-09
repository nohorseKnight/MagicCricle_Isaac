using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class PlayerSetTrapCommand : AbstractCommand
    {
        Transform _playerTrans;
        Vector3 _offset;
        public PlayerSetTrapCommand(Transform playerTrans, float h, float v)
        {
            _playerTrans = playerTrans;
            _offset = new Vector3(-h, -v, 0);
            if (Mathf.Abs(h - 0) < 0.01f && Mathf.Abs(v - 0) < 0.01f)
            {
                _offset = new Vector3(0, 1, 0);
            }
            Debug.Log($"{_offset}");
        }
        protected override void OnExecute()
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Trap"));
            obj.transform.position = _playerTrans.position + _offset * 0.8f;
        }
    }
}
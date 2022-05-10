using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class PlayerSetWindShieldCommand : AbstractCommand
    {
        Transform _playerTrans;
        public PlayerSetWindShieldCommand(Transform playerTrans)
        {
            _playerTrans = playerTrans;
        }
        protected override void OnExecute()
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/WindShield"), _playerTrans);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class PlayerUsePortalCommand : AbstractCommand
    {
        Transform _playerTrans;
        public PlayerUsePortalCommand(Transform player)
        {
            _playerTrans = player;
        }
        protected override void OnExecute()
        {
            if (_playerTrans.GetComponent<Player>().Portal == null)
            {
                GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/PortalEffect"));
                obj.transform.position = _playerTrans.transform.position;
                _playerTrans.GetComponent<Player>().Portal = obj.transform;
            }
            else
            {
                _playerTrans.position = _playerTrans.GetComponent<Player>().Portal.position;
                GameObject.Destroy(_playerTrans.GetComponent<Player>().Portal.gameObject);
                _playerTrans.GetComponent<Player>().Portal = null;
            }

        }
    }
}
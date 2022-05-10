using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class GameStart : BaseController
    {
        float time;
        Vector3[] posArr;
        void Start()
        {
            // Screen.SetResolution(720, 1480, false);

            posArr = new Vector3[3] { new Vector3(-4.5f, 0, 0), new Vector3(1.5f, 3f, 0), new Vector3(7.5f, 0, 0) };
        }
        void Update()
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();

            time += Time.deltaTime;
            if (time >= 1f && gameRuntimeModel.SlimeCount < 7 && gameRuntimeModel.CurrentGameModel == GameModel.SINGLE_MODEL)
            {
                time = 0;
                GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Slime"));
                gameRuntimeModel.SlimeCount++;
                obj.transform.position = posArr[Random.Range(0, 3)];
            }
        }
    }
}
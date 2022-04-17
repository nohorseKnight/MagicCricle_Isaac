using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class GameStart : BaseController
    {
        void Start()
        {
            // Screen.SetResolution(720, 1480, false);
            // this.GetSystem<UISystem>().OpenUI("UIMainMenuPanel");

            // GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            // EnemyModel enemyModel = this.GetModel<EnemyModel>();

            // gameRuntimeModel.GameState.Value = GameRuntimeModel.State.Fighting;
            // this.GetSystem<UISystem>().OpenUI("UIBagPanel", "Layout_Bottom");
            // enemyModel.EnemyObject.Value = this.GetSystem<UISystem>().OpenUI("Enemy");

            // MagicCricleModel mode = this.GetModel<MagicCricleModel>();
            // gameRuntimeModel.GameState.Value = GameRuntimeModel.State.Drawing;
            // mode.MagicCricleObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/MagicCricle"));
            // this.GetSystem<UISystem>().OpenUI("UIMainSelectPanel");
        }
    }
}
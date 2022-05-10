using System.Collections;
using QFramework;
using UnityEngine;

namespace MagicCricle_Isaac
{
    public enum GameModel
    {
        NONE,
        SINGLE_MODEL,
        AUTO_MODEL
    }
    public class GameRuntimeModel : AbstractModel
    {
        public int SlimeCount;
        public BindableProperty<GameModel> CurrentGameModel = new BindableProperty<GameModel>();
        protected override void OnInit()
        {
            SlimeCount = 0;
            CurrentGameModel.Register(e =>
            {
                if (CurrentGameModel.Value == GameModel.SINGLE_MODEL)
                {
                    this.SendEvent<EnterSingleModelEvent>();
                }
                else if (CurrentGameModel.Value == GameModel.AUTO_MODEL)
                {
                    this.SendEvent<EnterAutoModelEvent>();
                    this.SendEvent<SlimeDestoryEvent>();
                    SlimeCount = 0;
                }
            });
        }
    }
}
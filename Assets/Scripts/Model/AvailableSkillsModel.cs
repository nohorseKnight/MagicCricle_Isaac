using System.Collections;
using QFramework;
using UnityEngine;

namespace MagicCricle_Isaac
{
    public class AvailableSkillsModel : AbstractModel
    {
        public BindableProperty<int> Count = new BindableProperty<int>();
        public MagicCricleData[] SkillsList;
        int preCount;
        protected override void OnInit()
        {
            SkillsList = new MagicCricleData[4] { default(MagicCricleData), default(MagicCricleData), default(MagicCricleData), default(MagicCricleData) };
            MagicCricleData data = new MagicCricleData();
            data.ElementArr = new UnitStyle[3] { UnitStyle.WIND, UnitStyle.WATER, UnitStyle.FIRE };
            data.StarArr_1 = new UnitStyle[3] { UnitStyle.IncreaseEffect, UnitStyle.DecreaseSpellingTime, UnitStyle.Separatist };
            data.StarArr_2 = new UnitStyle[7] { UnitStyle.IncreaseEffect, UnitStyle.IncreaseHPByAttack, UnitStyle.DecreaseEnemySpeed, UnitStyle.DecreaseCD, UnitStyle.NONE, UnitStyle.Separatist, UnitStyle.NONE };
            SkillsList[0] = data;

            Count.Value = 1;
            preCount = 1;

            Count.Register(e =>
            {
                if (preCount < Count.Value)
                {
                    Debug.Log("preCount < Count.Value");
                    this.SendEvent<AddSkillViewEvent>();
                }
                else
                {
                    Debug.Log("preCount >= Count.Value");
                    this.SendEvent<DeleteSkillViewEvent>();
                }
                preCount = Count.Value;
            });
        }
    }
}
using System.Collections;
using QFramework;
using UnityEngine;

namespace MagicCricle_Isaac
{
    public class AvailableSkillsModel : AbstractModel
    {
        public BindableProperty<int> Count = new BindableProperty<int>();
        public MagicCricleData[] SkillsList;
        protected override void OnInit()
        {
            Count.Value = 1;
            SkillsList = new MagicCricleData[4];
            MagicCricleData data = new MagicCricleData();
            data.ElementArr = new UnitStyle[3] { UnitStyle.FIRE, UnitStyle.FIRE, UnitStyle.FIRE };
            data.StarArr_1 = new UnitStyle[3] { UnitStyle.IncreaseEffect, UnitStyle.DecreaseSpellingTime, UnitStyle.Separatist };
            data.StarArr_2 = new UnitStyle[7] { UnitStyle.IncreaseEffect, UnitStyle.IncreaseHPByAttack, UnitStyle.DecreaseEnemySpeed, UnitStyle.DecreaseCD, UnitStyle.NONE, UnitStyle.Separatist, UnitStyle.NONE };
            SkillsList[0] = data;

            Count.Register(e =>
            {
                this.SendEvent<SkillsUIPanelViewUpdateEvent>();
            });
        }
    }
}
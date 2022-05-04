using System.Collections;
using System.Net.Mime;
using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace MagicCricle_Isaac
{
    public struct MagicCricleData
    {
        public UnitStyle[] ElementArr;
        public UnitStyle[] StarArr_1;
        public UnitStyle[] StarArr_2;
    }
    public class MagicCricleModel : AbstractModel
    {
        public GameObject MagicCricleObject;
        public BindableProperty<UnitStyle> FirstCricleElement = new BindableProperty<UnitStyle>();
        public BindableProperty<UnitStyle> SecondCricleElement = new BindableProperty<UnitStyle>();
        public BindableProperty<UnitStyle> ThirdCricleElement = new BindableProperty<UnitStyle>();
        public BindableProperty<UnitStyle> SecondCricleStar = new BindableProperty<UnitStyle>();
        public BindableProperty<UnitStyle> ThirdCricleStar = new BindableProperty<UnitStyle>();
        public UnitStyle[] SecondCricleStarArr;
        public UnitStyle[] ThirdCricleStarArr;
        protected override void OnInit()
        {
            FirstCricleElement.Value = UnitStyle.NONE;
            SecondCricleElement.Value = UnitStyle.NONE;
            ThirdCricleElement.Value = UnitStyle.NONE;
            SecondCricleStarArr = null;
            ThirdCricleStarArr = null;

            FirstCricleElement.Register(FirstCricleElement =>
            {

            });

            SecondCricleElement.Register(SecondCricleElement =>
            {

            });

            ThirdCricleElement.Register(ThirdCricleElement =>
            {

            });

            SecondCricleStar.Register(SecondCricleStar =>
            {
                if (SecondCricleStar == UnitStyle.NONE)
                {
                    SecondCricleStarArr = null;
                }
                else
                {
                    SecondCricleStarArr = new UnitStyle[(int)(SecondCricleStar - UnitStyle.STAR_3) + 3];
                }
            });

            ThirdCricleStar.Register(ThirdCricleStar =>
            {
                if (ThirdCricleStar == UnitStyle.NONE)
                {
                    ThirdCricleStarArr = null;
                }
                else
                {
                    ThirdCricleStarArr = new UnitStyle[(int)(ThirdCricleStar - UnitStyle.STAR_3) + 3];
                }
            });
        }
    }
}
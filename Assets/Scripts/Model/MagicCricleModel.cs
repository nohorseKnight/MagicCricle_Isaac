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

        public bool Equals(MagicCricleData data)
        {
            if (this.Equals(default(MagicCricleData)) && data.Equals(default(MagicCricleData))) return true;
            if (data.Equals(default(MagicCricleData))) return false;
            if (this.Equals(default(MagicCricleData))) return false;

            for (int i = 0; i < ElementArr.Length; i++) if (ElementArr[i] != data.ElementArr[i]) return false;
            for (int i = 0; i < StarArr_1.Length; i++) if (StarArr_1[i] != data.StarArr_1[i]) return false;
            for (int i = 0; i < StarArr_2.Length; i++) if (StarArr_2[i] != data.StarArr_2[i]) return false;

            return true;
        }
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

        public bool IsComplete()
        {
            if (FirstCricleElement.Value == UnitStyle.NONE) return false;
            if (SecondCricleElement.Value == UnitStyle.NONE) return false;
            if (ThirdCricleElement.Value == UnitStyle.NONE) return false;
            if (SecondCricleStar.Value == UnitStyle.NONE) return false;
            if (ThirdCricleStar.Value == UnitStyle.NONE) return false;
            return true;
        }
    }
}
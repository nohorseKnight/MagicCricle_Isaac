using System.Collections;
using System.Net.Mime;
using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace MagicCricle_Isaac
{
    public class MagicCricleModel : AbstractModel
    {
        public GameObject MagicCricleObject;
        public BindableProperty<UnitStyle> FirstCricleElement = new BindableProperty<UnitStyle>();
        public BindableProperty<UnitStyle> SecondCricleElement = new BindableProperty<UnitStyle>();
        public BindableProperty<UnitStyle> ThirdCricleElement = new BindableProperty<UnitStyle>();
        public BindableProperty<UnitStyle> SecondCricleStar = new BindableProperty<UnitStyle>();
        public BindableProperty<UnitStyle> ThirdCricleStar = new BindableProperty<UnitStyle>();
        public ArrayList SecondCricleStarList;
        public ArrayList ThirdCricleStarList;
        protected override void OnInit()
        {
            FirstCricleElement.Value = UnitStyle.NONE;
            SecondCricleElement.Value = UnitStyle.NONE;
            ThirdCricleElement.Value = UnitStyle.NONE;

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

            });

            ThirdCricleStar.Register(ThirdCricleStar =>
            {

            });
        }
    }
}
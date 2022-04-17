using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class MagicBook : BaseController
    {
        public Button ExitButton;
        public Button ClearButton;
        public Button InfoButton;
        public Button DoneButton;

        void Start()
        {
            ExitButton.onClick.AddListener(() =>
            {
                this.GetSystem<UISystem>().CloseUI("MagicBook");
            });

            MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();

            magicCricleModel.MagicCricleObject = transform.Find("MagicCriclePanel").Find("MagicCricle").gameObject;

            ClearButton.onClick.AddListener(() =>
            {
                magicCricleModel.FirstCricleElement.Value = Element.NONE;
                magicCricleModel.SecondCricleElement.Value = Element.NONE;
                magicCricleModel.ThirdCricleElement.Value = Element.NONE;
            });

            InfoButton.onClick.AddListener(() =>
            {

            });

            DoneButton.onClick.AddListener(() =>
            {

            });

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class MainUI : BaseController
    {
        public Button BookButton;

        void Start()
        {
            BookButton.onClick.AddListener(() =>
            {
                if (!this.GetSystem<UISystem>().OpenUI("MagicBook"))
                {
                    this.GetSystem<UISystem>().CloseUI("MagicBook");
                }
            });

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class InfoPopup : BaseController
    {
        void Start()
        {
            transform.Find("BG").Find("ExitButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.GetSystem<UISystem>().CloseUI("InfoPopupView");
            });
        }
    }
}
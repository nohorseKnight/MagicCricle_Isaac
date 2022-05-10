using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public struct EnterSingleModelEvent
    {

    }
    public struct EnterAutoModelEvent
    {

    }
    public class MainUI : BaseController
    {
        public Button BookButton;
        public Button SingleModelButton;
        public Button AutoModelButton;
        public Button SingleModelStartButton;
        public Button AutoModelStartButton;

        void Start()
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();

            BookButton.onClick.AddListener(() =>
            {
                if (!this.GetSystem<UISystem>().OpenUI("MagicBook"))
                {
                    this.GetSystem<UISystem>().CloseUI("MagicBook");
                }
            });

            SingleModelButton.onClick.AddListener(() =>
            {
                gameRuntimeModel.CurrentGameModel.Value = GameModel.SINGLE_MODEL;
            });

            AutoModelButton.onClick.AddListener(() =>
            {
                gameRuntimeModel.CurrentGameModel.Value = GameModel.AUTO_MODEL;
            });

            SingleModelStartButton.onClick.AddListener(() =>
            {

            });

            AutoModelStartButton.onClick.AddListener(() =>
            {

            });

            this.RegisterEvent<EnterSingleModelEvent>(e =>
            {
                BookButton.gameObject.SetActive(true);
                transform.Find("SkillsUIPanel").gameObject.SetActive(true);
                SingleModelStartButton.gameObject.SetActive(true);
                AutoModelStartButton.gameObject.SetActive(false);

            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            this.RegisterEvent<EnterAutoModelEvent>(e =>
            {
                BookButton.gameObject.SetActive(false);
                transform.Find("SkillsUIPanel").gameObject.SetActive(false);
                SingleModelStartButton.gameObject.SetActive(false);
                AutoModelStartButton.gameObject.SetActive(true);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
    }
}
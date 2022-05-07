using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public struct UpdateRingStarViewEvent
    {
        public UnitStyle star;
        public CircleNumer cricle;
    }
    public struct UpdateSingleRingViewEvent
    {
        public UnitStyle element;
        public CircleNumer cricle;
    }
    public class MagicBook : BaseController
    {
        public Button ExitButton;
        public Button ClearButton;
        public Button InfoButton;
        public Button DoneButton;
        public Transform PowerElementsTrans;

        void Start()
        {
            ExitButton.onClick.AddListener(() =>
            {
                this.GetSystem<UISystem>().CloseUI("MagicBook");
            });

            MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();
            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();

            magicCricleModel.MagicCricleObject = transform.Find("MagicCriclePanel").Find("MagicCricleView").gameObject;

            ClearButton.onClick.AddListener(() =>
            {
                ClearMagicCricle();
            });

            InfoButton.onClick.AddListener(() =>
            {

            });

            DoneButton.onClick.AddListener(() =>
            {
                if (!magicCricleModel.IsComplete())
                {
                    this.GetSystem<UISystem>().OpenInfoPoup("Error", "Magic Cricle is not completed.");
                    return;
                }
                if (availableSkillsModel.Count.Value == 4)
                {
                    this.GetSystem<UISystem>().OpenInfoPoup("Error", "Skill List is full(Max capacity is 4).");
                    return;
                }
                MagicCricleData data = new MagicCricleData();
                data.ElementArr = new UnitStyle[3] { magicCricleModel.FirstCricleElement.Value, magicCricleModel.SecondCricleElement.Value, magicCricleModel.ThirdCricleElement.Value };
                data.StarArr_1 = magicCricleModel.SecondCricleStarArr;
                data.StarArr_2 = magicCricleModel.ThirdCricleStarArr;
                availableSkillsModel.SkillsList[availableSkillsModel.Count.Value] = data;
                availableSkillsModel.Count.Value++;
            });

            InitPowerElements();

            this.RegisterEvent<UpdateRingStarViewEvent>(updateEvent =>
            {
                UpdateRingStarView(updateEvent.star, updateEvent.cricle);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            this.RegisterEvent<UpdateSingleRingViewEvent>(updateEvent =>
            {
                UpdateSingleRingView(updateEvent.element, updateEvent.cricle);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        void ClearMagicCricle()
        {
            MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();

            magicCricleModel.FirstCricleElement.Value = UnitStyle.NONE;
            magicCricleModel.SecondCricleElement.Value = UnitStyle.NONE;
            magicCricleModel.ThirdCricleElement.Value = UnitStyle.NONE;
            magicCricleModel.SecondCricleStar.Value = UnitStyle.NONE;
            magicCricleModel.ThirdCricleStar.Value = UnitStyle.NONE;

            this.SendCommand(new SingleCricleElementUpdateCommand(UnitStyle.NONE, CircleNumer.Cricle_0));
            this.SendCommand(new SingleCricleElementUpdateCommand(UnitStyle.NONE, CircleNumer.Cricle_1));
            this.SendCommand(new SingleCricleElementUpdateCommand(UnitStyle.NONE, CircleNumer.Cricle_2));
            this.SendCommand(new SingleCricleRingStarUpdateCommand(UnitStyle.NONE, CircleNumer.Cricle_1));
            this.SendCommand(new SingleCricleRingStarUpdateCommand(UnitStyle.NONE, CircleNumer.Cricle_2));
        }

        void InitPowerElements()
        {
            GameObject obj;
            for (UnitStyle i = UnitStyle.PowerElement_Start + 1; i < UnitStyle.PowerElement_End; i++)
            {
                obj = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/DragUnitBase"), PowerElementsTrans);
                Debug.Log($"Image/Powers/{i.ToString()})");
                obj.transform.Find("Unit").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Powers/{i.ToString()}");
                obj.transform.Find("Unit").GetComponent<DragUnit>().Style = i;
            }
        }

        void UpdateRingStarView(UnitStyle star, CircleNumer cricle)
        {
            if (cricle == CircleNumer.NONE || cricle == CircleNumer.Cricle_0) return;
            Transform trans = transform.Find($"MagicCriclePanel/MagicCricleView/{cricle.ToString()}");
            // Debug.Log($"MagicCriclePanel/MagicCricleView/{cricle.ToString()}");
            if (trans.GetComponentsInChildren<Transform>(true).Length > 1) Destroy(trans.GetChild(0).gameObject);
            if (star != UnitStyle.NONE)
            {
                if (trans.GetComponentsInChildren<Transform>(true).Length > 1) Destroy(trans.GetChild(0).gameObject);
                // clear cricle model
                GameObject.Instantiate(Resources.Load<GameObject>($"UIPrefabs/RingStars/{star.ToString()}"), trans);
            }
        }

        void UpdateSingleRingView(UnitStyle element, CircleNumer cricle)
        {
            if (cricle == CircleNumer.NONE) return;
            Transform trans = cricle == CircleNumer.Cricle_0 ?
                transform.Find($"MagicCriclePanel/MagicCricleView/{cricle.ToString()}/CoreImage") :
                transform.Find($"MagicCriclePanel/MagicCricleView/{cricle.ToString()}");
            Debug.Log(trans == null ? "trans null" : "trans not null");
            if (element == UnitStyle.NONE)
            {
                switch (cricle)
                {
                    case CircleNumer.Cricle_0:
                        trans.GetComponent<Image>().sprite = null;
                        break;
                    case CircleNumer.Cricle_1:
                        trans.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Rings/Cricle_BASE_1");
                        break;
                    case CircleNumer.Cricle_2:
                        trans.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Rings/Cricle_BASE_2");
                        break;
                    default:
                        Debug.Log("default");
                        break;
                }
            }
            else
            {
                switch (cricle)
                {
                    case CircleNumer.Cricle_0:
                        trans.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Elements/{element}");
                        break;
                    case CircleNumer.Cricle_1:
                        trans.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Rings/Cricle_{element}_1");
                        break;
                    case CircleNumer.Cricle_2:
                        trans.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Rings/Cricle_{element}_2");
                        break;
                    default:
                        Debug.Log("default");
                        break;
                }
            }
        }
    }
}
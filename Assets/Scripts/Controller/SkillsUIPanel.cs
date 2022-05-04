using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public struct SkillsUIPanelViewUpdateEvent
    {

    }
    public class SkillsUIPanel : BaseController
    {
        Transform skillTrans_0;
        Transform skillTrans_1;
        Transform skillTrans_2;
        Transform skillTrans_3;
        void Start()
        {
            skillTrans_0 = transform.GetChild(0);
            skillTrans_1 = transform.GetChild(1);
            skillTrans_2 = transform.GetChild(2);
            skillTrans_3 = transform.GetChild(3);

            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();

            UpdateSkillView(skillTrans_0, (MagicCricleData)availableSkillsModel.SkillsList[0]);
        }
        void UpdateSkillView(Transform skillView, MagicCricleData data)
        {
            Debug.Log("UpdateSkillView");
            GameObject cricleObj = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/MagicCricleView"), skillView.GetChild(0).Find("LeftPanel"));

            var trans_0 = cricleObj.transform.Find("Cricle_0");
            var trans_1 = cricleObj.transform.Find("Cricle_1");
            var trans_2 = cricleObj.transform.Find("Cricle_2");

            trans_0.Find("CoreImage").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Elements/{data.ElementArr[0]}");
            trans_1.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Rings/Cricle_{data.ElementArr[1]}_1");
            trans_2.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Rings/Cricle_{data.ElementArr[2]}_2");

            var starObj_1 = GameObject.Instantiate(Resources.Load<GameObject>($"UIPrefabs/RingStars/Star_{data.StarArr_1.Length}"), trans_1);
            var starObj_2 = GameObject.Instantiate(Resources.Load<GameObject>($"UIPrefabs/RingStars/Star_{data.StarArr_2.Length}"), trans_2);

            for (int i = 0; i < data.StarArr_1.Length; i++)
            {
                starObj_1.transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Powers/{data.StarArr_1[i]}"); ;
            }

            for (int i = 0; i < data.StarArr_2.Length; i++)
            {
                starObj_2.transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Powers/{data.StarArr_2[i]}"); ;
            }
        }
    }
}
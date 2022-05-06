using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class UpdateSkillListCommand : AbstractCommand
    {
        Transform _trans;
        MagicCricleData _data;
        public UpdateSkillListCommand(Transform trans, MagicCricleData data)
        {
            _trans = trans;
            _data = data;
        }
        protected override void OnExecute()
        {
            Debug.Log("UpdateSkillView");
            Debug.Log($"_data.ElementArr:{_data.ElementArr[0]}, {_data.ElementArr[1]}, {_data.ElementArr[2]}");
            GameObject skillView = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/SkillView"), _trans);
            GameObject cricleObj = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/MagicCricleView"), skillView.transform.Find("LeftPanel"));

            var trans_0 = cricleObj.transform.Find("Cricle_0");
            var trans_1 = cricleObj.transform.Find("Cricle_1");
            var trans_2 = cricleObj.transform.Find("Cricle_2");

            trans_0.Find("CoreImage").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Elements/{_data.ElementArr[0]}");
            trans_1.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Rings/Cricle_{_data.ElementArr[1]}_1");
            trans_2.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Rings/Cricle_{_data.ElementArr[2]}_2");

            var starObj_1 = GameObject.Instantiate(Resources.Load<GameObject>($"UIPrefabs/RingStars/Star_{_data.StarArr_1.Length}"), trans_1);
            var starObj_2 = GameObject.Instantiate(Resources.Load<GameObject>($"UIPrefabs/RingStars/Star_{_data.StarArr_2.Length}"), trans_2);

            for (int i = 0; i < _data.StarArr_1.Length; i++)
            {
                starObj_1.transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Powers/{_data.StarArr_1[i]}"); ;
            }

            for (int i = 0; i < _data.StarArr_2.Length; i++)
            {
                starObj_2.transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Powers/{_data.StarArr_2[i]}"); ;
            }
        }
    }
}
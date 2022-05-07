using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class SkillView : BaseController
    {
        public MagicCricleData magicCricleData;
        Image imageCD;
        float CDTime;
        void Start()
        {
            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();

            imageCD = transform.Find("CDImage").GetComponent<Image>();
            imageCD.fillAmount = 0;
            CDTime = 1f;

            transform.Find("RightPanel").Find("ClearButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("ClearButton");
                availableSkillsModel.SkillsList[transform.parent.GetSiblingIndex()] = default(MagicCricleData);
                Destroy(gameObject);
                availableSkillsModel.Count.Value--;
            });
        }

        public void StartCDView()
        {
            imageCD.fillAmount = 1;
            StartCoroutine("ShowingCDView");
        }

        IEnumerator ShowingCDView()
        {
            float value = CDTime;
            while (imageCD.fillAmount > 0)
            {
                // Debug.Log($"value : {value}");
                value -= Time.deltaTime;
                imageCD.fillAmount = value / CDTime;
                yield return 0;
            }
        }
    }
}
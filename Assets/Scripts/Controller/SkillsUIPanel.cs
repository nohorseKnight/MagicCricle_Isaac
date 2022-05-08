using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public struct AddSkillViewEvent { }
    public struct DeleteSkillViewEvent { }
    public class SkillsUIPanel : BaseController
    {
        Transform[] skillTransArr;
        void Start()
        {
            skillTransArr = new Transform[4] { transform.GetChild(0), transform.GetChild(1), transform.GetChild(2), transform.GetChild(3) }; ;

            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();

            this.SendCommand(new UpdateSkillListCommand(skillTransArr[0], (MagicCricleData)availableSkillsModel.SkillsList[0]));

            this.RegisterEvent<AddSkillViewEvent>(e =>
            {
                int index = availableSkillsModel.Count.Value;
                this.SendCommand(new UpdateSkillListCommand(skillTransArr[index - 1], (MagicCricleData)availableSkillsModel.SkillsList[index - 1]));
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            this.RegisterEvent<DeleteSkillViewEvent>(e =>
            {
                RefreshSkillView();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            transform.GetChild(0).GetChild(0).GetComponent<SkillView>().SetFocus(true);
        }

        void RefreshSkillView()
        {
            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();

            for (int i = 0; i < availableSkillsModel.SkillsList.Length - 1; i++)
            {
                // Debug.Log($"i={i}");
                if (availableSkillsModel.SkillsList[i].Equals(default(MagicCricleData)))
                {
                    // Debug.Log($"if (sk...i={i}, no child");
                    if (skillTransArr[i + 1].GetComponentsInChildren<Transform>(true).Length <= 1)
                    {
                        // Debug.Log($"if (sk...i+1={i + 1}, no child");
                        availableSkillsModel.SkillsList[i] = default(MagicCricleData);
                        return;
                    }
                    Transform trans = skillTransArr[i + 1].GetChild(0);
                    trans.SetParent(skillTransArr[i]);
                    // Debug.Log($"trans.GetComponent<RectTransform>().anchoredPosition={trans.GetComponent<RectTransform>().anchoredPosition}");
                    trans.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    availableSkillsModel.SkillsList[i] = availableSkillsModel.SkillsList[i + 1];
                }
            }
            availableSkillsModel.SkillsList[availableSkillsModel.SkillsList.Length - 1] = default(MagicCricleData);
        }
    }
}
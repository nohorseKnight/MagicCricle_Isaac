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
        Transform[] skillTransArr;
        void Start()
        {
            skillTransArr = new Transform[4] { transform.GetChild(0), transform.GetChild(1), transform.GetChild(2), transform.GetChild(3) }; ;

            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();

            this.SendCommand(new UpdateSkillListCommand(skillTransArr[0], (MagicCricleData)availableSkillsModel.SkillsList[0]));

            this.RegisterEvent<SkillsUIPanelViewUpdateEvent>(e =>
            {
                int index = availableSkillsModel.Count.Value;
                this.SendCommand(new UpdateSkillListCommand(skillTransArr[index - 1], (MagicCricleData)availableSkillsModel.SkillsList[index - 1]));
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
    }
}
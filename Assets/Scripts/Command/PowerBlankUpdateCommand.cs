using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class PowerBlankUpdateCommand : AbstractCommand
    {
        private Collider2D _powerBlankObj;
        private UnitStyle _style;
        public PowerBlankUpdateCommand(Collider2D obj, UnitStyle style)
        {
            _powerBlankObj = obj;
            _style = style;
        }
        protected override void OnExecute()
        {
            if (_powerBlankObj == null) return;

            _powerBlankObj.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Powers/{_style.ToString()}");

            MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();

            Debug.Log($"_powerBlankObj.gameObject.transform.parent.parent.parent.name = {_powerBlankObj.gameObject.transform.parent.parent.parent.name}");
            Transform powerBlankTrans = _powerBlankObj.gameObject.transform.parent;
            Transform starTrans = powerBlankTrans.parent;
            Transform cricleTrans = starTrans.parent;
            if (cricleTrans.name == "Cricle_1")
            {
                magicCricleModel.SecondCricleStarArr[powerBlankTrans.GetSiblingIndex()] = _style;
                foreach (var i in magicCricleModel.SecondCricleStarArr)
                {
                    Debug.Log($"{i}");
                }
                UpdateGrainBySequence(powerBlankTrans.GetSiblingIndex(), starTrans, magicCricleModel.SecondCricleStarArr);
            }
            else if (cricleTrans.name == "Cricle_2")
            {
                Debug.Log($"powerBlankTrans.GetSiblingIndex(): {powerBlankTrans.GetSiblingIndex()}");
                Debug.Log($"magicCricleModel.ThirdCricleStarList.Len: {magicCricleModel.ThirdCricleStarArr.Length}");
                magicCricleModel.ThirdCricleStarArr[powerBlankTrans.GetSiblingIndex()] = _style;
                foreach (var i in magicCricleModel.ThirdCricleStarArr)
                {
                    Debug.Log($"{i}");
                }
                UpdateGrainByInterval(powerBlankTrans.GetSiblingIndex(), starTrans, magicCricleModel.ThirdCricleStarArr);
            }
        }

        void UpdateGrainBySequence(int index, Transform starTrans, UnitStyle[] arr)
        {
            int starLen = arr.Length;
            int preIndex = index == 0 ? starLen - 1 : index - 1;
            int afterIndex = index == starLen - 1 ? 0 : index + 1;

            starTrans.GetChild(preIndex + starLen).GetComponent<Image>().sprite = IsPowerIncreased(arr[preIndex], arr[index]) ?
                Resources.LoadAll<Sprite>("Image/Other/IconOnRingStar")[1] :
                Resources.Load<Sprite>("Image/Other/Empty");

            starTrans.GetChild(index + starLen).GetComponent<Image>().sprite = IsPowerIncreased(arr[index], arr[afterIndex]) ?
                Resources.LoadAll<Sprite>("Image/Other/IconOnRingStar")[1] :
                Resources.Load<Sprite>("Image/Other/Empty");
        }

        void UpdateGrainByInterval(int index, Transform starTrans, UnitStyle[] arr)
        {
            int starLen = arr.Length;
            int preIndex = index - 2 < 0 ? starLen + index - 2 : index - 2;
            int afterIndex = index + 2 >= starLen ? index + 2 - starLen : index + 2;

            starTrans.GetChild(preIndex + starLen).GetComponent<Image>().sprite = IsPowerIncreased(arr[preIndex], arr[index]) ?
                Resources.LoadAll<Sprite>("Image/Other/IconOnRingStar")[1] :
                Resources.Load<Sprite>("Image/Other/Empty");

            starTrans.GetChild(index + starLen).GetComponent<Image>().sprite = IsPowerIncreased(arr[index], arr[afterIndex]) ?
                Resources.LoadAll<Sprite>("Image/Other/IconOnRingStar")[1] :
                Resources.Load<Sprite>("Image/Other/Empty");
        }

        bool IsPowerIncreased(UnitStyle s1, UnitStyle s2)
        {
            if ((s1 == UnitStyle.IncreaseEffect && s2 == UnitStyle.DecreaseCD) || (s2 == UnitStyle.IncreaseEffect && s1 == UnitStyle.DecreaseCD)) return true;
            if ((s1 == UnitStyle.IncreaseEffect && s2 == UnitStyle.DecreaseSpellingTime) || (s2 == UnitStyle.IncreaseEffect && s1 == UnitStyle.DecreaseSpellingTime)) return true;
            if ((s1 == UnitStyle.IncreaseEffect && s2 == UnitStyle.IncreaseEffectTime) || (s2 == UnitStyle.IncreaseEffect && s1 == UnitStyle.IncreaseEffectTime)) return true;
            if ((s1 == UnitStyle.IncreaseEffect && s2 == UnitStyle.IncreaseObjectSpeed) || (s2 == UnitStyle.IncreaseEffect && s1 == UnitStyle.IncreaseObjectSpeed)) return true;

            if ((s1 == UnitStyle.Separatist && s2 == UnitStyle.Surround) || (s2 == UnitStyle.Separatist && s1 == UnitStyle.Surround)) return true;

            return false;
        }
    }
}
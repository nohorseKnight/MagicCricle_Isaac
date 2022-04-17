using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class SingleCricleUpdateCommand : AbstractCommand
    {
        private UnitStyle _inputUnitStyle;
        private CircleNumer _actOnCricle;
        public SingleCricleUpdateCommand(UnitStyle inputUnitStyle, CircleNumer actOnCricle)
        {
            _inputUnitStyle = inputUnitStyle;
            _actOnCricle = actOnCricle;
        }
        protected override void OnExecute()
        {
            Debug.Log("SingleCricleUpdateCommand: " + _inputUnitStyle.ToString() + ", " + _actOnCricle.ToString());
            MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();
            if (_actOnCricle == CircleNumer.Cricle_0)
            {
                magicCricleModel.FirstCricleElement.Value = Element.NONE + (_inputUnitStyle - UnitStyle.NONE);
            }
            else if (_actOnCricle == CircleNumer.Cricle_1)
            {
                magicCricleModel.SecondCricleElement.Value = Element.NONE + (_inputUnitStyle - UnitStyle.NONE);
            }
            else if (_actOnCricle == CircleNumer.Cricle_2)
            {
                magicCricleModel.ThirdCricleElement.Value = Element.NONE + (_inputUnitStyle - UnitStyle.NONE);
            }
        }
    }

}
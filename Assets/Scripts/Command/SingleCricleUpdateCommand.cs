using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class SingleCricleElementUpdateCommand : AbstractCommand
    {
        private UnitStyle _inputUnitStyle;
        private CircleNumer _actOnCricle;
        public SingleCricleElementUpdateCommand(UnitStyle inputUnitStyle, CircleNumer actOnCricle)
        {
            _inputUnitStyle = inputUnitStyle;
            _actOnCricle = actOnCricle;
        }
        protected override void OnExecute()
        {
            Debug.Log("SingleCricleElementUpdateCommand: " + _inputUnitStyle.ToString() + ", " + _actOnCricle.ToString());
            UpdateSingleRingViewEvent updateEvent = new UpdateSingleRingViewEvent();
            updateEvent.cricle = _actOnCricle;
            updateEvent.element = _inputUnitStyle;
            this.SendEvent(updateEvent);

            MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();
            if (_actOnCricle == CircleNumer.Cricle_0)
            {
                magicCricleModel.FirstCricleElement.Value = _inputUnitStyle;
            }
            else if (_actOnCricle == CircleNumer.Cricle_1)
            {
                magicCricleModel.SecondCricleElement.Value = _inputUnitStyle;
            }
            else if (_actOnCricle == CircleNumer.Cricle_2)
            {
                magicCricleModel.ThirdCricleElement.Value = _inputUnitStyle;
            }
        }
    }

    public class SingleCricleRingStarUpdateCommand : AbstractCommand
    {
        private UnitStyle _inputUnitStyle;
        private CircleNumer _actOnCricle;
        public SingleCricleRingStarUpdateCommand(UnitStyle inputUnitStyle, CircleNumer actOnCricle)
        {
            _inputUnitStyle = inputUnitStyle;
            _actOnCricle = actOnCricle;
        }
        protected override void OnExecute()
        {
            Debug.Log("SingleCricleRingStarUpdateCommand: " + _inputUnitStyle.ToString() + ", " + _actOnCricle.ToString());
            UpdateRingStarViewEvent updateEvent = new UpdateRingStarViewEvent();
            updateEvent.star = _inputUnitStyle;
            updateEvent.cricle = _actOnCricle;
            this.SendEvent(updateEvent);

            MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();

            if (_actOnCricle == CircleNumer.Cricle_1 && _inputUnitStyle >= UnitStyle.STAR_3 && _inputUnitStyle <= UnitStyle.STAR_5)
            {
                magicCricleModel.SecondCricleStar.Value = _inputUnitStyle;
            }
            else if (_actOnCricle == CircleNumer.Cricle_2 && _inputUnitStyle >= UnitStyle.STAR_6 && _inputUnitStyle <= UnitStyle.STAR_9)
            {
                magicCricleModel.ThirdCricleStar.Value = _inputUnitStyle;
            }
        }
    }

}
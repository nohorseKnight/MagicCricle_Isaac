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
        }
    }
}
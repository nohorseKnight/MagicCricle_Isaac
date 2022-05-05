using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class ShowMagicCricleEffectCommand : AbstractCommand
    {
        Transform _trans;
        MagicCricleData _data;
        public ShowMagicCricleEffectCommand(Transform trans, MagicCricleData data)
        {
            _trans = trans;
            _data = data;
        }
        protected override void OnExecute()
        {
            GameObject magicCricleEffectObj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/MagicCricleEffect"), _trans);
            magicCricleEffectObj.transform.Find("Cricle_2").GetComponent<Renderer>().material = Resources.Load<Material>($"Material/Cricle_{_data.ElementArr[2]}_2");
            magicCricleEffectObj.transform.Find("Cricle_2").Find("RingStar_2").GetComponent<Renderer>().material = Resources.Load<Material>($"Material/Star_{_data.StarArr_2.Length}");
            magicCricleEffectObj.transform.Find("Cricle_1").GetComponent<Renderer>().material = Resources.Load<Material>($"Material/Cricle_{_data.ElementArr[1]}_1");
            magicCricleEffectObj.transform.Find("Cricle_1").Find("RingStar_1").GetComponent<Renderer>().material = Resources.Load<Material>($"Material/Star_{_data.StarArr_1.Length}");
            magicCricleEffectObj.transform.Find("Cricle_0").Find("Core").GetComponent<Renderer>().material = Resources.Load<Material>($"Material/{_data.ElementArr[1]}");
        }
    }
}
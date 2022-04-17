using System.Net.Mime;
using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace MagicCricle_Isaac
{
    public enum Element
    {
        NONE, GROUND, THUNDER, WATER, PLANT, MOUNTAIN, FIRE, WIND, LIGHT
    }
    public class MagicCricleModel : AbstractModel
    {
        public GameObject MagicCricleObject;
        public BindableProperty<Element> FirstCricleElement = new BindableProperty<Element>();
        public BindableProperty<Element> SecondCricleElement = new BindableProperty<Element>();
        public BindableProperty<Element> ThirdCricleElement = new BindableProperty<Element>();
        protected override void OnInit()
        {
            FirstCricleElement.Value = Element.NONE;
            SecondCricleElement.Value = Element.NONE;
            ThirdCricleElement.Value = Element.NONE;

            FirstCricleElement.Register(FirstCricleElement =>
            {
                Sprite spr;
                if (FirstCricleElement == Element.NONE)
                {
                    Debug.Log("Clear FirstCricleElement");
                    // spr = Resources.Load<Sprite>("Image/Ring/Cricle_0_base");
                    // MagicCricleObject.transform.Find("Cricle_0").GetComponent<SpriteRenderer>().sprite = spr;
                    MagicCricleObject.transform.Find("Core").Find("CoreImage").GetComponent<Image>().sprite = null;
                    return;
                }
                Debug.Log($"Image/Elements/{(FirstCricleElement)}");
                // spr = Resources.Load<Sprite>($"Image/Ring/Cricle_0_00{(FirstCricleElement - Element.GROUND)}");
                // MagicCricleObject.transform.Find("Cricle_0").GetComponent<SpriteRenderer>().sprite = spr;
                spr = Resources.Load<Sprite>($"Image/Elements/{(FirstCricleElement)}");
                MagicCricleObject.transform.Find("Core").Find("CoreImage").GetComponent<Image>().sprite = spr;
            });

            SecondCricleElement.Register(SecondCricleElement =>
            {
                Sprite spr;
                if (SecondCricleElement == Element.NONE)
                {
                    Debug.Log("Clear SecondCricleElement");
                    spr = Resources.Load<Sprite>("Image/Rings/Cricle_BASE_1");
                    MagicCricleObject.transform.Find("MiddleCricle").GetComponent<Image>().sprite = spr;
                    return;
                }
                Debug.Log($"Image/Rings/Cricle_{SecondCricleElement.ToString()}_1");
                spr = Resources.Load<Sprite>($"Image/Rings/Cricle_{SecondCricleElement.ToString()}_1");
                MagicCricleObject.transform.Find("MiddleCricle").GetComponent<Image>().sprite = spr;
            });

            ThirdCricleElement.Register(ThirdCricleElement =>
            {
                Sprite spr;
                if (ThirdCricleElement == Element.NONE)
                {
                    Debug.Log("Clear ThirdCricleElement");
                    spr = Resources.Load<Sprite>("Image/Rings/Cricle_BASE_2");
                    MagicCricleObject.transform.Find("OutCricle").GetComponent<Image>().sprite = spr;
                    return;
                }
                Debug.Log($"Image/Rings/Cricle_{ThirdCricleElement.ToString()}_2");
                spr = Resources.Load<Sprite>($"Image/Rings/Cricle_{ThirdCricleElement.ToString()}_2");
                MagicCricleObject.transform.Find("OutCricle").GetComponent<Image>().sprite = spr;
            });
        }
    }
}
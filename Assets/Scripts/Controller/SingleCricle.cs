using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCricle_Isaac
{
    public enum CircleNumer
    {
        NONE,
        Cricle_0,
        Cricle_1,
        Cricle_2
    }
    public class SingleCricle : BaseController
    {
        [SerializeField] public CircleNumer CurrentCircleNumer;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            // Debug.Log("Cricle OnTriggerEnter2D");

            if (other.tag == "DragUnit" && IsUnitActOnCricle(other))
            {
                other.gameObject.GetComponent<DragUnit>().ActOnCricleNumber = CurrentCircleNumer;
                // this.SendCommand(new SpriteHighLightCommand(this.gameObject, 1.0f));
            }
        }

        bool IsUnitActOnCricle(Collider2D other)
        {
            UnitStyle style = other.gameObject.GetComponent<DragUnit>().Style;

            bool result = style >= UnitStyle.GROUND && style <= UnitStyle.LIGHT;
            result = result || (style >= UnitStyle.STAR_3 && style <= UnitStyle.STAR_9);

            return result;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            // Debug.Log("Cricle OnTriggerExit2D");

            // if (other.tag == "DragUnit")
            // {
            //     this.SendCommand(new SpriteHighLightCommand(this.gameObject, 0.6f));
            // }
        }

        // bool IsNeededTriggerIgnore(Collider2D other)
        // {
        //     if (other.tag != "DragUnit")
        //     {
        //         return true;
        //     }
        //     if (other.tag == "DragUnit" && other.gameObject.GetComponent<DragUnit>().Style >= UnitStyle.NUMBER_0 && other.gameObject.GetComponent<DragUnit>().Style <= UnitStyle.NUMBER_9)
        //     {
        //         return true;
        //     }
        //     return false;
        // }
    }

}

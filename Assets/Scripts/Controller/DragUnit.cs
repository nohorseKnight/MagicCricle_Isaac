using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using QFramework;

namespace MagicCricle_Isaac
{
    public enum UnitStyle
    {
        NONE,
        GROUND, THUNDER, WATER, PLANT, MOUNTAIN, FIRE, WIND, LIGHT,
        NUMBER_0, NUMBER_1, NUMBER_2, NUMBER_3, NUMBER_4, NUMBER_5, NUMBER_6, NUMBER_7, NUMBER_8, NUMBER_9,
        STAR_3, STAR_4, STAR_5, STAR_6, STAR_7, STAR_8, STAR_9
    }

    public class DragUnit : BaseController, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform canvasRec;
        private Transform orignalParent;
        // Start is called before the first frame update
        void Start()
        {
            canvasRec = this.GetComponentInParent<Canvas>().transform as RectTransform;
            orignalParent = transform.parent;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            this.transform.SetParent(canvasRec.transform);
            // orignalPos = this.transform.position;
            this.GetComponent<BoxCollider2D>().enabled = true;

            // ActOnCricleNumber = CircleNumer.NONE;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var rt = gameObject.GetComponent<RectTransform>();
            // transform the screen point to world point int rectangle
            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
            {
                rt.position = globalMousePos;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.SetParent(orignalParent);
            this.transform.localPosition = new Vector3(0, 0, 0);

            this.GetComponent<BoxCollider2D>().enabled = false;

            // if (Style >= UnitStyle.NUMBER_1 && Style <= UnitStyle.NUMBER_1000)
            // {
            //     this.SendCommand(new InputMagicNumberCommand(Style, Other));
            // }
            // else
            // {
            //     this.SendCommand(new MagicCricleViewUpdateCommand(Style, ActOnCricleNumber));
            // }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            // Debug.Log("DragUnit OnTriggerEnter2D");
        }

        void OnTriggerExit2D(Collider2D other)
        {
            // Debug.Log("DragUnit OnTriggerExit2D");

            // this.GetComponent<DragUnit>().HintImage.color = new Color(1, 1, 1, 0);
        }
    }
}


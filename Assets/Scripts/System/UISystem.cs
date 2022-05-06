using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UITextMeshPro = TMPro.TMP_Text;

namespace MagicCricle_Isaac
{
    public class UISystem : AbstractSystem
    {
        private Transform canvasTrans;
        private Dictionary<string, GameObject> openedWindow = new Dictionary<string, GameObject>();
        protected override void OnInit()
        {
            canvasTrans = Object.FindObjectOfType<Canvas>().transform;
        }

        public GameObject OpenUI(string name, string layoutName = "MiddleLayout")
        {
            if (openedWindow.ContainsKey(name)) return null;
            var go = Object.Instantiate(Resources.Load<GameObject>($"UIPrefabs/{name}"), canvasTrans.Find(layoutName));
            openedWindow[name] = go;

            return (GameObject)go;
        }

        public GameObject OpenInfoPoup(string title, string content)
        {
            if (openedWindow.ContainsKey("InfoPopupView")) return null;
            var go = Object.Instantiate(Resources.Load<GameObject>("UIPrefabs/InfoPopupView"), canvasTrans.Find("TopLayout"));
            go.transform.Find("BG").Find("Title").GetComponent<UITextMeshPro>().text = title;
            go.transform.Find("BG").Find("Content").GetComponent<UITextMeshPro>().text = content;
            openedWindow["InfoPopupView"] = go;

            return (GameObject)go;
        }


        public void CloseUI(string name)
        {
            if (!openedWindow.TryGetValue(name, out var window)) return;
            Object.Destroy(window);
            openedWindow.Remove(name);
        }

    }
}
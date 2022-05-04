using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class Player : BaseController
    {
        public GameObject SpellingBarImage;
        public Animator animator;
        float spellingTime = 3f;
        // Start is called before the first frame update
        void Start()
        {
            SpellingBarImage.GetComponent<Image>().fillAmount = 0;
        }

        // Update is called once per frame
        void Update()
        {
            Run();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine("Spelling");
            }
        }

        void Run()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            transform.position = transform.position + movement * Time.deltaTime;

        }

        IEnumerator Spelling()
        {
            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();
            MagicCricleData data = (MagicCricleData)availableSkillsModel.SkillsList[0];

            float value = 0;
            GameObject magicCricleEffectObj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/MagicCricleEffect"), transform);
            magicCricleEffectObj.transform.Find("Cricle_2").GetComponent<Renderer>().material = Resources.Load<Material>($"Material/Cricle_{data.ElementArr[2]}_2");
            magicCricleEffectObj.transform.Find("Cricle_1").GetComponent<Renderer>().material = Resources.Load<Material>($"Material/Cricle_{data.ElementArr[1]}_1");
            magicCricleEffectObj.transform.Find("Cricle_0").Find("Core").GetComponent<Renderer>().material = Resources.Load<Material>($"Material/{data.ElementArr[1]}");
            while (SpellingBarImage.GetComponent<Image>().fillAmount < 1)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    SpellingBarImage.GetComponent<Image>().fillAmount = 0;
                    Destroy(magicCricleEffectObj);
                    StopCoroutine("Spelling");
                    yield return 0;
                }
                // Debug.Log($"value : {value}");
                value += Time.deltaTime;
                SpellingBarImage.GetComponent<Image>().fillAmount = value / spellingTime;
                yield return 0;
            }
            SpellingBarImage.GetComponent<Image>().fillAmount = 0;
            Destroy(magicCricleEffectObj);
            ShootMagicBullet();
        }

        void ShootMagicBullet()
        {
            float h = animator.GetFloat("Horizontal");
            float v = animator.GetFloat("Vertical");
            this.SendCommand(new ShootMagicBulletCommand(transform.position, h, v));
        }
    }
}

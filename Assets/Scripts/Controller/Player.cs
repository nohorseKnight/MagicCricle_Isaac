using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class Player : BaseController
    {
        Image imageSpellingBar;
        public Animator animator;
        public int SkillIndex;
        float hp;
        float hpMax;
        Image imageHp;
        float mp;
        float mpMax;
        Image imageMp;
        float movingSpeed;
        float spellingTime = 3f;
        // Start is called before the first frame update
        void Start()
        {

            hp = hpMax = 100f;
            mp = mpMax = 100f;
            SkillIndex = 0;
            movingSpeed = 1;
            imageHp = transform.Find("PlayerCanvas").Find("Hp").GetComponent<Image>();
            imageMp = transform.Find("PlayerCanvas").Find("Mp").GetComponent<Image>();
            imageSpellingBar = transform.Find("PlayerCanvas").Find("SpellingBar").GetComponent<Image>();
            imageSpellingBar.fillAmount = 0;
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

            transform.position = transform.position + movement * movingSpeed * Time.deltaTime;
        }

        IEnumerator Spelling()
        {
            movingSpeed = 0.5f;

            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();
            MagicCricleData data = (MagicCricleData)availableSkillsModel.SkillsList[0];

            this.SendCommand(new ShowMagicCricleEffectCommand(transform.Find("MagicCricleEffect"), data));

            float value = 0;

            while (imageSpellingBar.fillAmount < 1)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    imageSpellingBar.fillAmount = 0;
                    Destroy(transform.Find("MagicCricleEffect").GetChild(0).gameObject);
                    movingSpeed = 1;
                    StopCoroutine("Spelling");
                    yield return 0;
                }
                // Debug.Log($"value : {value}");
                value += Time.deltaTime;
                imageSpellingBar.fillAmount = value / spellingTime;
                yield return 0;
            }
            imageSpellingBar.fillAmount = 0;
            movingSpeed = 1;
            Destroy(transform.Find("MagicCricleEffect").GetChild(0).gameObject);
            ShootMagicBullet();
        }

        void ShootMagicBullet()
        {
            float h = animator.GetFloat("Horizontal");
            float v = animator.GetFloat("Vertical");
            this.SendCommand(new ShootMagicBulletCommand(transform.position, h, v));
        }

        public void DecreaseHp(float value)
        {
            hp = hp - value < 0 ? 0 : hp - value;
            imageHp.fillAmount = hp / hpMax;
        }

        public void IncreaseHp(float value)
        {
            hp = hp + value > hpMax ? hpMax : hp + value;
            imageHp.fillAmount = hp / hpMax;
        }

        public void DecreaseMp(float value)
        {
            mp = mp - value < 0 ? 0 : mp - value;
            imageMp.fillAmount = mp / mpMax;
        }

        public void IncreaseMp(float value)
        {
            mp = mp + value > mpMax ? mpMax : mp + value;
            imageMp.fillAmount = mp / mpMax;
        }
    }
}

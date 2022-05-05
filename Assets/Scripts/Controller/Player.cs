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
        float movingSpeed;
        float spellingTime = 3f;
        // Start is called before the first frame update
        void Start()
        {
            movingSpeed = 1;
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

            transform.position = transform.position + movement * movingSpeed * Time.deltaTime;

        }

        IEnumerator Spelling()
        {
            movingSpeed = 0.5f;

            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();
            MagicCricleData data = (MagicCricleData)availableSkillsModel.SkillsList[0];

            this.SendCommand(new ShowMagicCricleEffectCommand(transform.Find("MagicCricleEffect"), data));

            float value = 0;

            while (SpellingBarImage.GetComponent<Image>().fillAmount < 1)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    SpellingBarImage.GetComponent<Image>().fillAmount = 0;
                    Destroy(transform.Find("MagicCricleEffect").GetChild(0).gameObject);
                    movingSpeed = 1;
                    StopCoroutine("Spelling");
                    yield return 0;
                }
                // Debug.Log($"value : {value}");
                value += Time.deltaTime;
                SpellingBarImage.GetComponent<Image>().fillAmount = value / spellingTime;
                yield return 0;
            }
            SpellingBarImage.GetComponent<Image>().fillAmount = 0;
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
    }
}

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
            float value = 0;
            while (SpellingBarImage.GetComponent<Image>().fillAmount < 1)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    SpellingBarImage.GetComponent<Image>().fillAmount = 0;
                    StopCoroutine("Spelling");
                    yield return 0;
                }
                // Debug.Log($"value : {value}");
                value += Time.deltaTime;
                SpellingBarImage.GetComponent<Image>().fillAmount = value / 1f;
                yield return 0;
            }
            SpellingBarImage.GetComponent<Image>().fillAmount = 0;
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

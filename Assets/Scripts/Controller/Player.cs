using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public class Player : BaseController
    {
        public Animator animator;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            Run();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 shootDir;
                float x = animator.GetFloat("Horizontal");
                float y = animator.GetFloat("Vertical");
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    shootDir = new Vector3(x > 0 ? 1 : -1, 0, 0);
                }
                else
                {
                    shootDir = new Vector3(0, y > 0 ? 1 : -1, 0);
                }
                this.SendCommand(new ShootMagicBulletCommand(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/MagicBullet"), transform.position, Quaternion.identity).transform, shootDir));
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
    }
}

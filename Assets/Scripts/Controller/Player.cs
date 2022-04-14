using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

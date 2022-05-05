using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCricle_Isaac
{
    public class Slime : BaseController
    {
        public Animator animator;
        public Vector3 TargetPos;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            TargetPos = GameObject.Find("Player").transform.position;
            MoveToTargetPos();
        }

        void MoveToTargetPos()
        {
            if (transform.position != TargetPos)
            {
                Vector3 offset = TargetPos - transform.position;
                float speed = 0.5f;
                Vector3 movement = offset.normalized * speed;
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Magnitude", movement.magnitude);
                transform.position = transform.position + movement * Time.deltaTime;
                if (Math.Abs(transform.position.x - TargetPos.x) < 0.5f && Math.Abs(transform.position.y - TargetPos.y) < 0.5f)
                {
                    TargetPos = transform.position;
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<MagicBullet>() != null)
            {
                Destroy(gameObject);
            }
        }
    }
}


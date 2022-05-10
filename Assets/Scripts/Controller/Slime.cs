using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MagicCricle_Isaac
{
    public struct SlimeDestoryEvent
    {

    }
    public class Slime : BaseController
    {
        public Animator animator;
        public Vector3 TargetPos;
        // Start is called before the first frame update
        void Start()
        {
            this.RegisterEvent<SlimeDestoryEvent>(e =>
            {
                Destroy(gameObject);
            });
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
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            if (other.GetComponent<MagicBullet>() != null || other.GetComponent<Trap>() != null || other.GetComponent<WindShield>() != null)
            {
                Destroy(other.gameObject);
                gameRuntimeModel.SlimeCount--;
                Destroy(gameObject);
            }

            // if (other.GetComponent<Player>() != null)
            // {
            //     other.GetComponent<Player>().DecreaseHp(25f);
            //     Destroy(gameObject);
            // }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            if (other.gameObject.GetComponent<Player>() != null)
            {
                other.gameObject.GetComponent<Player>().DecreaseHp(25f);
                gameRuntimeModel.SlimeCount--;
                Destroy(gameObject);
            }
        }
    }
}


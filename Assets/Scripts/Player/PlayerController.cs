using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _dir;
        private Rigidbody2D _rb;
        public float velocity = 3;
        private List<Animator> _animators = new List<Animator>();
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            var animators = GetComponentsInChildren<Animator>();
            _animators = animators.ToList();
        }

        public void SetDirection(Vector2 dir)
        {
            _dir = dir;
            if (_dir.x!=0|| _dir.y!=0)
            {
                foreach (var anim in _animators)
                {
                    anim.SetFloat("X", dir.x);
                    anim.SetFloat("Y", dir.y);
                    anim.SetBool("IsWalking", true);
                }
                
            }
            else
            {
                foreach (var anim in _animators)
                {
                    anim.SetBool("IsWalking", false);
                }
            }
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _dir * Time.fixedDeltaTime* velocity);
        }
    }
}

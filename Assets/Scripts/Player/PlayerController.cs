using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _dir;
        private Rigidbody2D _rb;
        public float velocity = 3;
        private Animator _anim;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponentInChildren<Animator>();
        }

        public void SetDirection(Vector2 dir)
        {
            _dir = dir;
            if (_dir.x!=0|| _dir.y!=0)
            {
                _anim.SetFloat("X", dir.x);
                _anim.SetFloat("Y", dir.y);
                _anim.SetBool("IsWalking", true);
            }
            else
            {
                _anim.SetBool("IsWalking", false);
            }
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _dir * Time.fixedDeltaTime* velocity);
        }
    }
}

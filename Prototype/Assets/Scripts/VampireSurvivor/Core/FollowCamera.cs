using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Core
{
    public class FollowCamera : MonoBehaviour
    {
        // Start is called before the first frame update
        public float Speed = 10;
        private GameObject _player;
        private Vector3 _offset;
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _offset = transform.position - _player.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + _offset, Speed);
        }
    }
}

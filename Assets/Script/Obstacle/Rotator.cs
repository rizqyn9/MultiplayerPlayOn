using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Peplayon;

namespace Obstacle
{
    public class Rotator : MonoBehaviour
    {
        [Header("Preferences")]
        public bool isStarted = false;
        public float speed = 3f;
        public float speedMove = 100f;

        public Rigidbody rb;

        private void OnValidate()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody>();
            }
        }

        private void Update()
        {
            if (!isStarted) return;
            transform.Rotate( speed * Time.deltaTime / 0.01f,0f, 0f, Space.Self);
        }
    }
}

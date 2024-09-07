using UnityEngine;

namespace IMPossible.Movement
{
    public class EnemyMover : MonoBehaviour
    {
        private void Update()
        {
            isGrounded();
            UpdateAnimator();
        }
        public void Move(GameObject player, float speed)
        {
            if (!isGrounded()) return;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.LookAt(player.transform.position);
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.magnitude;

            GetComponent<Animator>().SetFloat("Speed", speed);
        }
        private bool isGrounded()
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), -Vector3.up, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), -Vector3.up, out hit, 0.8f))
            {
                if (hit.collider.tag == "Floor")
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;

            }
        }
    }
}

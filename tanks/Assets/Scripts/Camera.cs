namespace Tanks
{
    using UnityEngine;

    public class Camera : MonoBehaviour
    {
        [SerializeField]
        private float constYPos;
        [SerializeField]
        private float minXPos;
        [SerializeField]
        private float interpVelocity;
        [SerializeField]
        private float minDistance;
        [SerializeField]
        private float followDistance;
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private Vector3 offset;        
        Vector3 targetPos;

        private void Start()
        {
            targetPos = transform.position;
        }

        private void Update()
        {
            if (target)
            {
                Vector3 posNoZ = transform.position;
                posNoZ.z = target.transform.position.z;

                Vector3 targetDirection = (target.transform.position - posNoZ);

                interpVelocity = targetDirection.magnitude * 5f;

                targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

                targetPos.y = constYPos;

                if (targetPos.x < minXPos)
                    targetPos.x = minXPos;
                transform.position = Vector3.Lerp(transform.position, targetPos + offset, 5f);
            }
        }
    }
}

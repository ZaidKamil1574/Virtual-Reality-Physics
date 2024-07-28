using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace UnityEngine.XR.Content.Interaction
{
    public class PushableBall : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody m_BallRigidbody;

        [SerializeField]
        private float m_MaxPushForce = 10f;

        [SerializeField]
        private UnityEvent m_OnPush = new UnityEvent();

        private bool m_IsPushing = false;

        private XRBaseInteractor m_Interactor;
        private Transform m_InteractorAttachTransform;

        private Vector3 m_LastPosition;
        private Vector3 m_CurrentVelocity;

        /// <summary>
        /// Event to fire when the ball is pushed.
        /// </summary>
        public UnityEvent onPush => m_OnPush;

        private void Update()
        {
            if (m_IsPushing && m_Interactor != null && m_InteractorAttachTransform != null)
            {
                // Calculate the velocity of the interactor
                Vector3 currentPosition = m_InteractorAttachTransform.position;
                m_CurrentVelocity = (currentPosition - m_LastPosition) / Time.deltaTime;
                m_LastPosition = currentPosition;

                // Calculate the push force based on the interactor's velocity
                float pushForceMagnitude = m_CurrentVelocity.magnitude * m_MaxPushForce;
                Vector3 pushForce = m_InteractorAttachTransform.forward * pushForceMagnitude;

                // Apply force to the ball
                m_BallRigidbody.AddForce(pushForce, ForceMode.Impulse);

                // Invoke the push event
                m_OnPush.Invoke();
            }
        }

        public void BeginPushing(SelectEnterEventArgs args)
        {
            m_Interactor = args.interactorObject as XRBaseInteractor;
            m_InteractorAttachTransform = args.interactorObject.GetAttachTransform(args.interactableObject);
            m_IsPushing = true;
            m_LastPosition = m_InteractorAttachTransform.position;
        }

        public void EndPushing()
        {
            m_IsPushing = false;
            m_Interactor = null;
            m_InteractorAttachTransform = null;
        }
    }
}

using UnityEngine;

namespace Controller
{
    [RequireComponent(typeof(CreatureMover))]
    public class MovePlayerInput : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField]
        private string m_HorizontalAxis = "Horizontal";
        [SerializeField]
        private string m_VerticalAxis = "Vertical";
        [SerializeField]
        private string m_JumpButton = "Jump";
        [SerializeField]
        private KeyCode m_RunKey = KeyCode.LeftShift;

        [Header("Camera")]
        [SerializeField]
        private PlayerCamera m_Camera;
        [SerializeField]
        private string m_MouseX = "Mouse X";
        [SerializeField]
        private string m_MouseY = "Mouse Y";
        [SerializeField]
        private string m_MouseScroll = "Mouse ScrollWheel";

        private CreatureMover m_Mover;

        private Vector2 m_Axis;
        private bool m_IsRun;
        private bool m_IsJump;

        private Vector3 m_Target;
        private Vector2 m_MouseDelta;
        private float m_Scroll;
        private Quaternion fixedRotation;

        private void Awake()
        {
            m_Mover = GetComponent<CreatureMover>();
            fixedRotation = transform.rotation; // 시작 시 회전값 저장
        }

        private void Update()
        {
            GatherInput();
            SetInput();
        }

        public void GatherInput()
        {
            m_Axis = new Vector2(Input.GetAxis(m_HorizontalAxis), Input.GetAxis(m_VerticalAxis));
            m_IsRun = Input.GetKey(m_RunKey);
            m_IsJump = Input.GetButton(m_JumpButton);

            // 임시로 카메라 없이 앞으로 이동하도록
            m_Target = transform.position + transform.forward * 10f;

            m_MouseDelta = new Vector2(Input.GetAxis(m_MouseX), Input.GetAxis(m_MouseY));
            m_Scroll = Input.GetAxis(m_MouseScroll);
        }

        public void BindMover(CreatureMover mover)
        {
            m_Mover = mover;
        }

        public void SetInput()
        {
            if (m_Mover != null)
            {
                m_Mover.SetInput(in m_Axis, in m_Target, in m_IsRun, m_IsJump);
            }

            if (m_Camera != null)
            {
                m_Camera.SetInput(in m_MouseDelta, m_Scroll);
            }
        }

        private void LateUpdate()
        {
            if (m_Mover != null)
            {
                transform.position = m_Mover.transform.position;

                // 좌우 입력이 있을 때만 회전 동기화, 아니면 고정
                bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
                bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

                if (left || right)
                {
                    transform.rotation = m_Mover.transform.rotation;
                    fixedRotation = transform.rotation; // 최신 회전값 저장
                }
                else
                {
                    transform.rotation = fixedRotation; // 고정된 회전값 유지
                }
            }
        }
    }
}
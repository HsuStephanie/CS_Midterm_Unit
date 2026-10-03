using UnityEngine;
using UnityEngine.Events;

namespace MidtermTuringTest
{
    public class PushButton : MonoBehaviour, ISelectable
    {
        [SerializeField] Material _default;
        [SerializeField] Material _hoverColor;
        [SerializeField] MeshRenderer _renderer;

        public UnityEvent onPush;

        void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            _renderer.material = default;
        }

        public void OnHoverEnter()
        {
            _renderer.material = _hoverColor;
        }

        public void OnSelect()
        {
            onPush?.Invoke();
        }

        public void OnHoverExit()
        {
            _renderer.material = _default;
        }


    }
}

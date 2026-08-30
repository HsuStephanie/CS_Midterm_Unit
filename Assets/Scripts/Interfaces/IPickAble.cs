using UnityEngine;

namespace MidtermTuringTest
{
    public interface IPickAble
    {
        public void OnPicked(Transform attachTransform);
        public void OnDropped();
    }
}

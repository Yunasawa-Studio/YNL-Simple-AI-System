#if YNL_UTILITIES
using System.Collections;
using UnityEngine;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem
{
    public class AIDecisionTimeInState : AIDecision
    {
        public AIDecisionTimeInState() : base() { }
        public AIDecisionTimeInState(AIController controller) : base(controller) { }

        private Animator _animator;
        private Coroutine _coroutine;

        private float _currentTime = 0f;
        [Tooltip("Time of currently playing animations")] public bool UsingAnimationTime = false; // Animation playing type must be immediate
        [Tooltip("Limit time in current state")] public float LimitTime;

        public override void Convert(SerializableDictionary<string, string> properties)
        {
            UsingAnimationTime = bool.Parse(properties["UsingAnimationTime"]);
            LimitTime = float.Parse(properties["LimitTime"]);
        }

        public override void Initialize(AIController controller)
        {
            base.Initialize(controller);

            _currentTime = 0f;
            if (_animator.IsNull()) _animator = controller?.transform.parent.GetComponent<Animator>();
            if (!_animator.IsNull() && UsingAnimationTime)
            {
                if (_coroutine != null) controller?.StopCoroutine(_coroutine);
                _coroutine = controller?.StartCoroutine(GetAnimationLengthAfterOneFrame());
            }
        }

        public override bool DoDecision()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= LimitTime) return true;
            return false;
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
        }

        private IEnumerator GetAnimationLengthAfterOneFrame()
        {
            yield return new WaitForEndOfFrame();
            LimitTime = _animator.GetCurrentAnimatorStateInfo(0).length;
        }
    }
}
#endif
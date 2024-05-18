#if YNL_UTILITIES
using System.Linq;
using Unity.Collections;
using UnityEngine;
using YNL.Attributes;
using YNL.Extensions.Addons;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem
{
    public class AIController : MonoBehaviour
    {
        #region ▶ Extension Properties
        [HideInInspector] public Animator Animator;
        [HideInInspector] public AIRoot Root;
        #endregion

        #region ▶ AI Properties
        public AIBehaviour Behaviour;

        [Label] public string _currentState = "None";
        [HideInInspector] public AIState CurrentState;
        [HideInInspector] public AIState[] States = new AIState[0];

        [ReadOnly] public float TimeInState = 0f;
        public bool EnableController = true;
        public bool ResetControllerOnStart = true;
        public bool ResetControllerOnEnable = false;

        public Transform Target;
        [HideInInspector] public Vector3 LastKnownTargetPosition = Vector3.zero;

        protected float _lastActionsUpdate = 0f;
        protected float _lastDecisionsUpdate = 0f;

        public float ActionFrequency = 0f;
        public float DecisionFrequency = 0f;
        public bool RandomizeFrequancies = false;
        [ShowIfBool("RandomizeFrequancies", true)] public MRange RandomActionFrequency = new(0.5f, 1f);
        [ShowIfBool("RandomizeFrequancies", true)] public MRange RandomDecisionFrequency = new(0.5f, 1f);
        #endregion

        #region ▶ Handler Methods
        protected virtual void OnEnable()
        {
            if (ResetControllerOnEnable) ResetController();
        }

        protected virtual void Awake()
        {
            States = Behaviour.GetStates(this);
            if (RandomizeFrequancies)
            {
                ActionFrequency = Random.Range(RandomActionFrequency.Min, RandomActionFrequency.Max);
                DecisionFrequency = Random.Range(RandomDecisionFrequency.Min, RandomDecisionFrequency.Max);
            }

            if (Animator.IsNull()) Animator = this.transform.parent.GetComponent<Animator>();
            if (Root.IsNull()) Root = this.transform.parent.GetComponent<AIRoot>();
        }

        protected virtual void Start()
        {
            if (ResetControllerOnStart) ResetController();
        }

        protected virtual void Update()
        {
            if (!EnableController || (CurrentState == null) || Time.timeScale == 0) return;
            if (Time.time - _lastActionsUpdate > ActionFrequency)
            {
                CurrentState.ExecuteActions();
                _lastActionsUpdate = Time.time;
            }
            if (!EnableController) return;
            if (Time.time - _lastDecisionsUpdate > DecisionFrequency)
            {
                CurrentState.ExecuteTransitions();
                _lastDecisionsUpdate = Time.time;
            }

            TimeInState += Time.deltaTime;

            StoreLastKnownPosition();

            _currentState = CurrentState.Name;
        }

        public virtual void TransitionToState(string stateName)
        {
            if (CurrentState.IsNull())
            {
                CurrentState = FindState(stateName);
                if (!CurrentState.IsNull()) CurrentState.Enter();
                return;
            }
            //if (CurrentState.Name != stateName) // Enable this to avoid reset the same state
            else
            {
                CurrentState.Exit();
                OnExitState();

                CurrentState = FindState(stateName);
                if (!CurrentState.IsNull()) CurrentState.Enter();
                return;
            }
        }
        protected virtual void OnExitState() => TimeInState = 0f;
        protected AIState FindState(string stateName)
        {
            AIState state = States.FirstOrDefault(i => i.Name == stateName);
            if (!state.IsNull()) return state;
            else if (state.IsNull() && !stateName.IsNullOrEmpty())
            {
                MDebug.Error($"{stateName} does not exist in AI Controller. Make sure states named correctly");
            }
            return null;
        }
        protected virtual void StoreLastKnownPosition()
        {
            if (!Target.IsNull()) LastKnownTargetPosition = Target.transform.position;
        }
        protected virtual void ResetController()
        {
            if (!CurrentState.IsNull())
            {
                CurrentState.Exit();
                OnExitState();
            }
            if (!States.IsEmpty())
            {
                CurrentState = States[0];
                CurrentState?.Enter();
            }
        }
        #endregion
    }
}
#endif
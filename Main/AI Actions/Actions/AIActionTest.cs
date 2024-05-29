using UnityEngine;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

#if true

namespace YNL.SimpleAISystem
{
    public class AIActionTest: AIAction
    {
        public AIActionTest() : base(null) { }
        public AIActionTest(AIController controller) : base(controller) { }

        private Rigidbody _rigidbody;
        public int Distance;
        public KeyCode KeyCode;

        public override void Initialize(AIController controller)
        {
            base.Initialize(controller);

            //_rigidbody = controller.Root.GetComponent<Rigidbody>();

            //MDebug.Log("ASDASDASD");
        }

        public override void Convert(SerializableDictionary<string, string> properties)
        {
            Distance = int.Parse(properties["Distance"]);
            KeyCode = MEnum.Parse<KeyCode>(properties["KeyCode"]);
        }

        public override void DoAction()
        {
            // Perform the actions
        }

        public override void OnEnterState()
        {
            // Do something when entering the state
        }

        public override void OnExitState()
        {
            // Do something when exiting the state
        }
    }
}
#endif
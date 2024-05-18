<adetails>
<summary><h2><div id="part1"> ★ How to create new Action or Decision </div></h2></summary>

<ul>
  <li> First of all, you have to pay attention on some important things: </li>
  <ul>
    <li> Whenever you create a new Action or Decision, make sure to put it inside namespace <code>YNL.SimpleAISystem</code>. </li>
    <li> Every created Action should have <code>AIAction</code> as a prefix, and every created Decision should have <code>AIDecision</code> as a prefix too. </li>
  </ul>
  <br>
  <li> Now come to the main part; after you follow the notes above and created a new Action or Decision, you need to create 2 constructors, one have no parameter and one have <code>AIController</code> as the only parameter. </li>
  <br>
  <li> Now is your part, inside AIAction, there are 5 methods that you can override. </li>
  <ul>
    <li> <code>void Initialize(AIController controller)</code>: Here you can initialize everything you need, such as getting the components, ect. </li>
    <li> <code>void Convert(SerializableDictionary<string, string> properties)</code>: Here you can convert the keys and values into the types you want. Keys are the name of properties and values are the values of the properties. You can see the sample below to make it easier to imagine.</li>
    <li> <code>void DoAction()</code>: Here you perform the actions as you want. </li>
    <li> <code>void OnEnterState()</code>: This will be called when entering the state. </li>
    <li> <code>void OnExitState()</code>: This will be called when exiting the state. </li>
  </ul>
  <br>
  <li> Come to AIDecision, there are also 5 methods that you can override. </li>
  <ul>
    <li> <code>void Initialize(AIController controller)</code>: Here you can initialize everything you need, such as getting the components, ect. </li>
    <li> <code>void Convert(SerializableDictionary<string, string> properties)</code>: Here you can convert the keys and values into the types you want. Keys are the name of properties and values are the values of the properties. You can see the sample below to make it easier to imagine.</li>
    <li> <code>bool DoDecision()</code>: Here you decide when to move to next state by returning this method a boolean. </li>
    <li> <code>void OnEnterState()</code>: This will be called when entering the state. </li>
    <li> <code>void OnExitState()</code>: This will be called when exiting the state. </li>
  </ul>
</ul>

<details>
<summary> AIActionSample.cs (Sample for custom AIAction script) </summary>

```csharp
using UnityEngine;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem
{
    public class AIActionSample : AIAction
    {
        public AIActionSample() : base(null) { }
        public AIActionSample(AIController controller) : base(controller) { }

        // Make the properties you want to hide as private; the Editor is currently not support
        // Reference properties so you can only get it from Initialize() method
        private Rigidbody _rigidbody;

        // Make the properties you want to edit inside Editor as public 
        public int Distance;
        public KeyCode KeyCode;

        public override void Initialize(AIController controller)
        {
            base.Initialize(controller);

            _rigidbody = controller.Root.GetComponent<Rigidbody>();
        }

        public override void Convert(SerializableDictionary<string, string> properties)
        {
            // Use converting method to convert string into the types you want.
            Distance = int.Parse(properties["Distance"]);

            // For enum you can use MEnum.Parse<T>(string) as below
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
```

</details>

<details>
<summary> AIDecisionSample.cs (Sample for custom AIAction script) </summary>

```csharp
using UnityEngine;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem
{
    public class AIDecisionSample : AIDecision
    {
        public AIDecisionSample() : base(null) { }
        public AIDecisionSample(AIController controller) : base(controller) { }

        // Make the properties you want to hide as private; the Editor is currently not support
        // Reference properties so you can only get it from Initialize() method
        private Rigidbody _rigidbody;

        // Make the properties you want to edit inside Editor as public
        public int Distance;
        public KeyCode KeyCode;

        public override void Initialize(AIController controller)
        {
            base.Initialize(controller);

            _rigidbody = controller.Root.GetComponent<Rigidbody>();
        }

        public override void Convert(SerializableDictionary<string, string> properties)
        {
            // Use converting method to convert string into the types you want.
            Distance = int.Parse(properties["Distance"]);

            // For enum you can use MEnum.Parse<T>(string) as below
            KeyCode = MEnum.Parse<KeyCode>(properties["KeyCode"]);
        }

        public override bool DoDecision()
        {
            // Decise the transition
            return true;
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
```

</details>

</adetails>


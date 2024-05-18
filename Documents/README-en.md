<div align="center"><h1><i> YのL - Simple AI System (Instuction - EN) </i></h1></div>

<details>
<summary><h2><div id="part1"> ★ How to use AI Behaviour Editor </div></h2></summary>
<ul>
  <li> Create <b> AI Behaviour </b> in your Project window like this and name it as you want. </li>
  <br>
  <div align="center"><img width="100%" src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/f1aad95a-29bf-4245-b428-b3f99e232bff"></div>
  <br>
  <img align="right" src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/b46b3b5c-2952-41e5-90a0-068c3f0f4815">
  Once you created the <b> AI Behaviour </b>, double-click on it to open the Editor Window. Or you can manually open it from Toolbar buttons.
  <br>
  <br>
  <br>
  <br>
  <li> After you open the Editor Window, everything will seem blank. </li>
  <img width="100%" src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/0b915e90-7724-4fd3-954b-a2f7ba35831a">
  <br>
  <img align="right" width=300px src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/7e6f1485-7647-439a-a1a4-9af76e0965af">
  <li> Click on <code>Add State</code> and a new state box will appear. You can Rename the state by pressing the "Pen" icon or Remove it by pressing the X button </li>
  <li> Please make sure that all the States will have distinct names. </li>
  <br>
  <img align="right" width=300px src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/622c862f-4b97-435a-bfba-ede0ff086880">
  <li> After creating all the states you want, choose one and one the main side, press on <code>Add</code> button on ACTION window and TRANSITION window. </li>
  <li> You can click on the box to open a selecting window, with Action box, you can choose the actions that you want, and with Decision box, you can choose the decisions for the next states. </li>
  <li> The window looks like this: </li>
  <br>
  <br>
  <br>
  <br>
  <table>
  <tr>
    <th width="50%"><img src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/86ec9c3a-f5ea-449b-85c9-d1690d8da2eb"></th>
    <th width="50%"><img src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/dc0ca4eb-a4fa-439c-a9a9-cc31216f4743"></th>
  </tr>
  </table>
  <img align="right" width=300px src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/41e4cc63-249a-472a-a449-6b63edad1e6c">
  <li> After you finish editing everything, select the AI Behaviour asset, choose <code>Save Data</code> to save all your changes, otherwise, you will regret not did that. </li>
</ul>

</details>

<details>
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

</details>

<details>
<summary><h2><div id="part1"> ★ How to set up your AI objects </div></h2></summary>

<ul>
  <li> You can open the Sample Scene to have a better imagination of what you need. Go inside <code>Packages/YのL - Simple AI System/Sample/Sample Scene</code>; for now you can not open the scene because you have no right to open a read-only scene from a package. But don't worry, all you need to do is just copying the scene and paste it somewhere you want; then now you can open it </li>
  <li> Take a look to <code>AI Root</code> object, it contains an <code>AI Root (Script)</code> component, then that will be the component you need to add to an AI object. If it have animations, add <code>Animator</code> too. </li>
  <li> Look at it child <code>AI Controller</code>, this is the Controller of the AI system. Add the component and drop the <code>AI Behaviour</code> you want to use inside. (<code>AIController</code> should be inside a child object of <code>AIRoot</code>) </li>
  <li> Everything is done, if you have not done an Action to get a target; make sure to put an object inside the <code>Target</code> field or it will throw an error. </li>
</ul>

</details>


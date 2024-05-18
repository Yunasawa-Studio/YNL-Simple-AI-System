<adetails>
<summary><h2><div id="part1"> ★ How to create new Action or Decision </div></h2></summary>

<ul>
  <li> First of all, you have to pay attention on some important things: </li>
  <ul>
    <li> Whenever you create a new Action or Decision, make sure to put it inside namespace <code>YNL.SimpleAISystem</code>. </li>
    <li> Every created Action should have <code>AIAction</code> as a prefix, and every created Decision should have <code>AIDecision</code> as a prefix too. </li>
  </ul>
  <li> Now come to the main part; after you follow the notes above and created a new Action or Decision, you need to create 2 constructors, one have no parameter and one have <code>AIController</code> as the only parameter. </li>
  <li> Now is your part, inside AIAction, there are 5 methods that you can override. </li>
  <ul>
    <li> <code>void Initialize(AIController controller)</code>: Here you can initialize everything you need, such as getting the components, ect. </li>
    <li> <code>void Convert(SerializableDictionary<string, string> properties)</code>: Here you can convert the keys and values into the types you want. Keys are the name of properties and values are the values of the properties. You can see the sample below to make it easier to imagine.</li>
    <li> <code>void DoAction()</code>: Here you perform the actions as you want. </li>
    <li> <code>void OnEnterState()</code>: This will be called when entering the state. </li>
    <li> <code>void OnExitState()</code>: This will be called when exiting the state. </li>
  </ul>
</ul>

</adetails>


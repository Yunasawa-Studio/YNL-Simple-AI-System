<adetails>
<summary><h2><div id="part1"> ★ How to set up your AI objects </div></h2></summary>

<ul>
  <li> You can open the Sample Scene to have a better imagination of what you need. Go inside <code>Packages/YのL - Simple AI System/Sample/Sample Scene</code>; for now you can not open the scene because you have no right to open a read-only scene from a package. But don't worry, all you need to do is just copying the scene and paste it somewhere you want; then now you can open it </li>
  <li> Take a look to <code>AI Root</code> object, it contains an <code>AI Root (Script)</code> component, then that will be the component you need to add to an AI object. If it have animations, add <code>Animator</code> too. </li>
  <li> Look at it child <code>AI Controller</code>, this is the Controller of the AI system. Add the component and drop the <code>AI Behaviour</code> you want to use inside. </li>
  <li> Everything is done, if you have not done an Action to get a target; make sure to put an object inside the <code>Target</code> field or it will throw an error. </li>
</ul>

</adetails>


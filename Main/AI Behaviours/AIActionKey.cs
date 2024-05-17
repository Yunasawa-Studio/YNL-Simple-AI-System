using System.Reflection;
using System;
using YNL.Utilities.Addons;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem
{
    [System.Serializable]
    public class AIActionKey
    {
        public string Label = "";
        public SerializableDictionary<string, string> Properties = new();

        public AIActionKey(string label)
        {
            Label = label;
        }

        public void Update(string label)
        {
            Label = label;
            Properties.Clear();

            Type type = Type.GetType($"YNL.RPG.AI.AIAction{label}");
            if (type.IsNull()) return;

            object instance = Activator.CreateInstance(type);

            FieldInfo[] fields = type.GetFieldsInSubclass();

            foreach (var field in fields)
            {
                object defaultValue = field.GetValue(instance);
                Properties.Add(field.Name, defaultValue.ToString());
            }
        }
    }
}
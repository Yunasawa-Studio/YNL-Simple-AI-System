using System.Reflection;
using System;
using YNL.Utilities.Addons;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem
{
    [System.Serializable]
    public class AITransitionKey
    {
        public string Label = "";
        public string True = "";
        public string False = "";
        public SerializableDictionary<string, string> Properties = new();

        public AITransitionKey(string label)
        {
            Label = label;
        }

        public void Update(string label)
        {
            Label = label;
            True = "";
            False = "";
            Properties.Clear();

            Type type = Type.GetType($"YNL.SimpleAISystem.AIDecision{label}");
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
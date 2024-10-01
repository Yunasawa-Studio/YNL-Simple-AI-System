#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using System.Reflection;
using System;
using UnityEngine.UIElements;
using YNL.Extensions.Methods;
using YNL.Editors.Extensions;

namespace YNL.SimpleAISystem.Editors
{
    public static class EAIUtilities
    {
        public static VisualElement CustomField<T>(string label, string value, Action<T> valueChanged, params string[] style)
        {
            VisualElement element = null;

            if (typeof(T) == typeof(string))
            {
                element = new TextField(label).AddClass(style);
                (element as TextField).value = value;
                (element as TextField).RegisterValueChangedCallback(evt => valueChanged?.Invoke((T)Convert.ChangeType(evt.newValue, typeof(T))));
            }
            else if (typeof(T) == typeof(int))
            {
                element = new IntegerField(label).AddClass(style);
                (element as IntegerField).value = int.Parse(value);
                (element as IntegerField).RegisterValueChangedCallback(evt => valueChanged?.Invoke((T)Convert.ChangeType(evt.newValue, typeof(T))));
            }
            else if (typeof(T) == typeof(float))
            {
                element = new FloatField(label).AddClass(style);
                (element as FloatField).value = float.Parse(value);
                (element as FloatField).RegisterValueChangedCallback(evt => valueChanged?.Invoke((T)Convert.ChangeType(evt.newValue, typeof(T))));
            }
            else if (typeof(T) == typeof(bool))
            {
                element = new Toggle(label).AddClass(style);
                (element as Toggle).value = bool.Parse(value);
                (element as Toggle).RegisterValueChangedCallback(evt => valueChanged?.Invoke((T)Convert.ChangeType(evt.newValue, typeof(T))));
            }
            else if (typeof(T).IsEnum)
            {
                element = new EnumField(label, (Enum)Activator.CreateInstance(typeof(T))).AddClass(style);
                (element as EnumField).value = (Enum)Convert.ChangeType(MEnum.Parse<T>(value), typeof(Enum));
                (element as EnumField).RegisterValueChangedCallback(evt => valueChanged?.Invoke((T)Convert.ChangeType(evt.newValue, typeof(T))));
            }
            else element = new Image();

            return element;
        }

        public static VisualElement CustomField(FieldInfo fieldInfo, string label, string value, Action<object> valueChanged, params string[] style)
        {
            label = label.AddSpaces();

            VisualElement element = null;

            Type fieldType = fieldInfo.FieldType;

            if (fieldType == typeof(string))
            {
                element = new TextField(label).AddClass(style);
                if (!value.IsNull()) (element as TextField).value = value;
                (element as TextField).RegisterValueChangedCallback(evt => valueChanged?.Invoke(evt.newValue));
            }
            else if (fieldType == typeof(int))
            {
                element = new IntegerField(label).AddClass(style);
                if (!value.IsNull()) (element as IntegerField).value = int.Parse(value);
                (element as IntegerField).RegisterValueChangedCallback(evt => valueChanged?.Invoke(evt.newValue));
            }
            else if (fieldType == typeof(float))
            {
                element = new FloatField(label).AddClass(style);
                if (!value.IsNull()) (element as FloatField).value = float.Parse(value);
                (element as FloatField).RegisterValueChangedCallback(evt => valueChanged?.Invoke(evt.newValue));
            }
            else if (fieldType == typeof(bool))
            {
                element = new Toggle(label).AddClass(style);
                if (!value.IsNull()) (element as Toggle).value = bool.Parse(value);
                (element as Toggle).RegisterValueChangedCallback(evt => valueChanged?.Invoke(evt.newValue));
            }
            else if (fieldType.IsEnum)
            {
                element = new EnumField(label, (Enum)Activator.CreateInstance(fieldType)).AddClass(style);
                if (!value.IsNull()) (element as EnumField).value = (Enum)Enum.Parse(fieldType, value);
                (element as EnumField).RegisterValueChangedCallback(evt => valueChanged?.Invoke(evt.newValue));
            }
            else
            {
                Extensions.Methods.MDebug.Caution($"Unsupported field type: {fieldType}");
            }

            return element;
        }
    }
}
#endif
#endif
#endif
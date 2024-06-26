using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace eBMasterData
{
    public class Settings : ScriptableObject
    {
        [Header("Output path for Scripts")]
        public string OutputPath = "Assets/MasterData/Scripts/";

        [Header("Base file name")]
        public string BaseFileName = "MD";

        [Header("Namespace name")]
        public string NamespaceName = "MasterData";

        [Header("Classes file name")]
        public string ClassesFileName = "MDClasses";

        [Header("Enums file name")]
        public string EnumsFilePath = "MDEnums";

        [Header("Data file name")]
        public string DataFileName = "MDData";

        [Header("Data line split string")]
        public string LineSplitString = "\\r\\n";

        [Header("Data field split string")]
        public string FieldSplitString = ",";

        [Header("Class prefix name")]
        public string ClassNamePrefix = "MDClass";

        [Header("Class base name")]
        public string ClassNameBase = "Base";

        [Header("Class primary key")]
        public string ClassPrimaryKey = "Id";

        [Header("Data header line count")]
        public int HeaderLines = 3;

        [Header("Data sources")]
        public SettingsDataSource[] Sources;

        [Header("Enum list")]
        public string[] Enums;

        [Header("Config list")]
        public string[] Configs;
    }

    [System.Serializable]
    public class SettingsDataSource
    {
        [Header("Data type")]
        public DsDataType DataType;

        [Header("Data path")]
        public string Path;

        [Header("Label for Addressables")]
        public string AddressablesLabel;
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SettingsDataSource))]
    public class SettingsDataSourceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var k1 = "DataType";
            var k2 = "Path";
            var k3 = "AddressablesLabel";
            var p1 = property.FindPropertyRelative(k1);
            var v1 = (DsDataType)p1.intValue;
            var p2 = property.FindPropertyRelative(k2);
            var p3 = property.FindPropertyRelative(k3);

            p2.stringValue = EditorGUILayout.TextField(k2, p2.stringValue);
            p1.intValue = (int)(DsDataType)EditorGUILayout.EnumPopup(k1, v1);
            if (v1 == DsDataType.Addressables)
            {
                p3.stringValue = EditorGUILayout.TextField(k3, p3.stringValue);
            }
        }
    }
#endif
}

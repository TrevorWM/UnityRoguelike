using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Xml.Serialization;


#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewRelic",menuName = "Items/Relic")]
[Serializable]
public class RelicSO : ScriptableObject
{
    

    [SerializeField] public enum RelicEffectType
    {
        Passive,
        OnAttack,
        OnSelfHit,
        OnTargetHit,
        OnTargetDeath,
    }
    [SerializeField] public enum RelicScalingType
    {
        Additive,
        Multiplicative,
        Logarithmic,
        Exponential,
    }

    [SerializeField] public enum RelicRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Dark,
    }

    [SerializeField] public enum StatToChange
    {
        MaxHealth,
        MoveSpeed,
        DodgeForce,
        DodgeTime,
        AttacksPerSecond,
        AttackDamage,
        AttackRange,
        ProjectileSpeed,
    }

    [SerializeField] private RelicEffectType effectType;
    [SerializeField] private string relicName;
    [SerializeField] private string description;
    [SerializeField] private RelicRarity rarity;
    [SerializeField] private RelicScalingType scalingType;
    [SerializeField] private float buffValue;
    [SerializeField] private StatToChange stat;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Ability ability;
    [SerializeField] private Material shaderMaterial;

    public string RelicName { get => relicName; set => relicName = value; }
    public RelicEffectType EffectType { get => effectType; set => effectType = value; }
    public float BuffValue { get => buffValue; set => buffValue = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
    public Material ShaderMaterial { get => shaderMaterial; set => shaderMaterial = value; }
    public string Description { get => description; set => description = value; }
    public RelicRarity Rarity { get => rarity; set => rarity = value; }
    public Ability AbilityScript { get => ability; set => ability = value; }
    public StatToChange Stat { get => stat; set => stat = value; }


    public virtual void ApplyRelicEffect(Stats target, int stacks)
    {
        CheckRelicScalingType(target, stacks);
    }

    private void CheckRelicScalingType(Stats target, int stacks)
    {
        switch (scalingType)
        {
            case RelicScalingType.Additive:
                Debug.Log("Additive");
                PassiveRelicAdditiveBuff(target, stacks);
                break;
            case RelicScalingType.Multiplicative:
                Debug.Log("Multiplicative");
                PassiveRelicMultiplicativeBuff(target, stacks);
                break;
            case RelicScalingType.Logarithmic:
                Debug.Log("Log");
                PassiveRelicLogarithmicBuff(target, stacks);
                break;
            case RelicScalingType.Exponential:
                Debug.Log("Expo");
                PassiveRelicExponentialBuff(target, stacks);
                break;
            default:
                Debug.Log("Did not find Scaling Type");
                break;

        }
    }

    private void PassiveRelicAdditiveBuff(Stats target, int stacks)
    {
        if (target != null)
        {
            switch (stat)
            {
                case StatToChange.MaxHealth:
                    target.MaxHealth = target.BaseStats.MaxHealth + (buffValue * stacks);
                    break;

                case StatToChange.MoveSpeed:
                    target.MoveSpeed = target.BaseStats.MoveSpeed + (buffValue * stacks);
                    break;

                case StatToChange.DodgeForce:
                    target.DodgeForce = target.BaseStats.DodgeForce + (buffValue * stacks);
                    break;

                case StatToChange.DodgeTime:
                    target.DodgeTime = target.BaseStats.DodgeTime + (buffValue * stacks);
                    break;

                case StatToChange.AttackDamage:
                    target.AttackDamage = target.BaseStats.AttackDamage + (buffValue * stacks);
                    break;
                case StatToChange.AttackRange:
                    target.AttackRange = target.BaseStats.AttackRange + (buffValue * stacks);
                    break;

                case StatToChange.AttacksPerSecond:
                    target.AttacksPerSecond = target.BaseStats.AttacksPerSecond + (buffValue * stacks);
                    break;

                case StatToChange.ProjectileSpeed:
                    target.ProjectileSpeed = target.BaseStats.ProjectileSpeed + (buffValue * stacks);
                    break;
            }
        }
    }

    private void PassiveRelicMultiplicativeBuff(Stats target, int stacks)
    {
        if (target != null)
        {
            switch (stat)
            {
                case StatToChange.MaxHealth:
                    target.MaxHealth = target.BaseStats.MaxHealth * (buffValue * stacks);
                    break;

                case StatToChange.MoveSpeed:
                    target.MoveSpeed = target.BaseStats.MoveSpeed * (buffValue * stacks);
                    break;

                case StatToChange.DodgeForce:
                    target.DodgeForce = target.BaseStats.DodgeForce * (buffValue * stacks);
                    break;

                case StatToChange.DodgeTime:
                    target.DodgeTime = target.BaseStats.DodgeTime * (buffValue * stacks);
                    break;

                case StatToChange.AttackDamage:
                    target.AttackDamage = target.BaseStats.AttackDamage * (buffValue * stacks);
                    break;
                case StatToChange.AttackRange:
                    target.AttackRange = target.BaseStats.AttackRange * (buffValue * stacks);
                    break;

                case StatToChange.AttacksPerSecond:
                    target.AttacksPerSecond = target.BaseStats.AttacksPerSecond * (buffValue * stacks);
                    break;

                case StatToChange.ProjectileSpeed:
                    target.ProjectileSpeed = target.BaseStats.ProjectileSpeed * (buffValue * stacks);
                    break;
            }
        }
    }

    private void PassiveRelicLogarithmicBuff(Stats target, int stacks)
    {
        if (target != null)
        {
            switch (stat)
            {
                case StatToChange.MaxHealth:
                    target.MaxHealth = target.BaseStats.MaxHealth + Mathf.Log(buffValue * stacks);
                    break;

                case StatToChange.MoveSpeed:
                    target.MoveSpeed = target.BaseStats.MoveSpeed + Mathf.Log(buffValue * stacks);
                    break;

                case StatToChange.DodgeForce:
                    target.DodgeForce = target.BaseStats.DodgeForce + Mathf.Log(buffValue * stacks);
                    break;

                case StatToChange.DodgeTime:
                    target.DodgeTime = target.BaseStats.DodgeTime + Mathf.Log(buffValue * stacks);
                    break;

                case StatToChange.AttackDamage:
                    target.AttackDamage = target.BaseStats.AttackDamage + Mathf.Log(buffValue * stacks);
                    break;
                case StatToChange.AttackRange:
                    target.AttackRange = target.BaseStats.AttackRange + Mathf.Log(buffValue * stacks);
                    break;

                case StatToChange.AttacksPerSecond:
                    target.AttacksPerSecond = target.BaseStats.AttacksPerSecond + Mathf.Log(buffValue * stacks);
                    break;

                case StatToChange.ProjectileSpeed:
                    target.ProjectileSpeed = target.BaseStats.ProjectileSpeed + Mathf.Log(buffValue * stacks);
                    break;  
            }
        }

    }

    private void PassiveRelicExponentialBuff(Stats target, int stacks)
    {
        if (target != null)
        {
            switch (stat)
            {
                case StatToChange.MaxHealth:
                    target.MaxHealth = target.BaseStats.MaxHealth + Mathf.Pow(buffValue, stacks);
                    break;

                case StatToChange.MoveSpeed:
                    target.MoveSpeed = target.BaseStats.MoveSpeed + Mathf.Pow(buffValue, stacks);
                    break;

                case StatToChange.DodgeForce:
                    target.DodgeForce = target.BaseStats.DodgeForce + Mathf.Pow(buffValue, stacks);
                    break;

                case StatToChange.DodgeTime:
                    target.DodgeTime = target.BaseStats.DodgeTime + Mathf.Pow(buffValue, stacks);
                    break;

                case StatToChange.AttackDamage:
                    target.AttackDamage = target.BaseStats.AttackDamage + Mathf.Pow(buffValue, stacks);
                    break;
                case StatToChange.AttackRange:
                    target.AttackRange = target.BaseStats.AttackRange + Mathf.Pow(buffValue, stacks);
                    break;

                case StatToChange.AttacksPerSecond:
                    target.AttacksPerSecond = target.BaseStats.AttacksPerSecond + Mathf.Pow(buffValue, stacks);
                    break;

                case StatToChange.ProjectileSpeed:
                    target.ProjectileSpeed = target.BaseStats.ProjectileSpeed + Mathf.Pow(buffValue, stacks);
                    break;
            }
        }

    }
    
    #region Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(RelicSO))]
    [CanEditMultipleObjects]
    public class RelicSOEditor : Editor
    {
        SerializedProperty relicNameSP;
        SerializedProperty relicDescriptionSP;
        SerializedProperty relicRaritySP;
        SerializedProperty relicEffectTypeSP;
        SerializedProperty relicBuffValueSP;
        SerializedProperty relicScalingTypeSP;        
        SerializedProperty relicStatSP;
        SerializedProperty relicAbilitySP;
        SerializedProperty relicSpriteSP;
        SerializedProperty relicShaderSP;

        private const int LABEL_WIDTH = 100;

        private void OnEnable()
        {
            relicNameSP = serializedObject.FindProperty("relicName");
            relicDescriptionSP = serializedObject.FindProperty("description");
            relicRaritySP = serializedObject.FindProperty("rarity");
            relicEffectTypeSP = serializedObject.FindProperty("effectType");
            relicBuffValueSP = serializedObject.FindProperty("buffValue");
            relicScalingTypeSP = serializedObject.FindProperty("scalingType");
            relicStatSP = serializedObject.FindProperty("stat");
            relicAbilitySP = serializedObject.FindProperty("ability");
            relicSpriteSP = serializedObject.FindProperty("sprite");
            relicShaderSP = serializedObject.FindProperty("shaderMaterial");
        }
        public override void OnInspectorGUI()
        {
            RelicSO relic = (RelicSO)target;

            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            DrawHeader("Relic Details");
            
            EditorGUI.indentLevel = 1;
            DrawRelicNameField();
            DrawRelicDescriptionField();
            DrawRelicRarityField();
            DrawRelicTypeField();
            DrawRelicTypeInfo(relic);

            EditorGUILayout.Space();
            DrawHeader("Visual Information");
            DrawSpriteField();
            DrawShaderField();

            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();

        }
        private void DrawHeader(string text)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(text, EditorStyles.boldLabel);
            GUILayout.EndHorizontal();
        }
        private void DrawRelicNameField()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicNameSP, new GUIContent("Name:"));
            EditorGUILayout.EndHorizontal();
        }

        private void DrawRelicDescriptionField()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicDescriptionSP, new GUIContent("Description:"));
            EditorGUILayout.EndHorizontal();
        }

        private void DrawRelicRarityField()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicRaritySP, new GUIContent("Rarity:"));
            EditorGUILayout.EndHorizontal();
        }

        private void DrawRelicTypeField()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicEffectTypeSP, new GUIContent("Type:"));
            EditorGUILayout.EndHorizontal();
        }
        private void DrawRelicTypeInfo(RelicSO relic)
        {
            EditorGUI.indentLevel++;
            if (relic.EffectType == RelicEffectType.Passive)
            {
                DrawPassiveFields();
            } else
            {
                DrawActiveFields();
            }
            EditorGUI.indentLevel--;
        }

        private void DrawPassiveFields()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicStatSP, new GUIContent("Modify Stat:"));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicBuffValueSP, new GUIContent("Buff Amount:"));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicScalingTypeSP, new GUIContent("Scale Type:"));
            EditorGUILayout.EndHorizontal();
        }

        private void DrawActiveFields()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicAbilitySP, new GUIContent("Ability Script:"));
            EditorGUILayout.EndHorizontal();
        }

        private void DrawSpriteField()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicSpriteSP, new GUIContent("Sprite:"));
            EditorGUILayout.EndHorizontal();
        }

        private void DrawShaderField()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(relicShaderSP, new GUIContent("Shader:"));
            EditorGUILayout.EndHorizontal();
        }
    }
#endif
    #endregion
    
}


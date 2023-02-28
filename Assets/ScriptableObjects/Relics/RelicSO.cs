using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Xml.Serialization;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewRelic",menuName = "Items/Relic")]
[System.Serializable]
public class RelicSO : ScriptableObject, ICollectible
{
    public static event Action<RelicSO> OnRelicSOCollected;

    public enum RelicEffectType
    {
        Passive,
        OnAttack,
        OnSelfHit,
        OnTargetHit,
        OnTargetDeath,
    }
    public enum RelicScalingType
    {
        Additive,
        Multiplicative,
        Logarithmic,
        Exponential,
    }

    public enum RelicRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Dark,
    }

    public enum StatToChange
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
    
    private RelicEffectType effectType;
    private string relicName;
    private string description;
    private RelicRarity rarity;
    private RelicScalingType scalingType;
    private float buffValue;
    private StatToChange stat;
    private Sprite sprite;
    private Ability uniqueEffectScript;
    private Material shaderMaterial;

    public string RelicName { get => relicName; set => relicName = value; }
    public RelicEffectType EffectType { get => effectType; set => effectType = value; }
    public float BuffValue { get => buffValue; set => buffValue = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
    public Material ShaderMaterial { get => shaderMaterial; set => shaderMaterial = value; }
    public string Description { get => description; set => description = value; }
    public RelicRarity Rarity { get => rarity; set => rarity = value; }
    public Ability UniqueEffectScript { get => uniqueEffectScript; set => uniqueEffectScript = value; }
    public StatToChange Stat { get => stat; set => stat = value; }


    public virtual void ApplyRelicEffect(Stats target, int stacks)
    {
        CheckRelicScalingType(target, stacks);
    }

    public virtual void Collect()
    {
        Debug.LogFormat("You collected a {0}", RelicName);
        OnRelicSOCollected?.Invoke(this);
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
    public class RelicSOEditor : Editor
    {
        private const int LABEL_WIDTH = 100;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            RelicSO relic = (RelicSO)target;
            

            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical();
            DrawHeader("Relic Details");
            
            EditorGUI.indentLevel = 1;
            DrawRelicNameField(relic);
            DrawRelicDescriptionField(relic);
            DrawRelicRarityField(relic);
            DrawRelicTypeField(relic);
            DrawRelicTypeInfo(relic);

            EditorGUILayout.Space();
            DrawHeader("Visual Information");
            DrawSpriteField(relic);
            DrawShaderField(relic);

            EditorGUILayout.EndVertical();

            EditorUtility.SetDirty(relic);
            PrefabUtility.RecordPrefabInstancePropertyModifications(relic);

        }
        private void DrawHeader(string text)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(text, EditorStyles.boldLabel);
            GUILayout.EndHorizontal();
        }
        private void DrawRelicNameField(RelicSO relic)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Name:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.relicName = EditorGUILayout.TextField(relic.relicName, GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();
        }

        private void DrawRelicDescriptionField(RelicSO relic)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Description:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.description = EditorGUILayout.TextArea(relic.description);
            EditorGUILayout.EndHorizontal();
        }

        private void DrawRelicRarityField(RelicSO relic)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Rarity:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.rarity = (RelicRarity)EditorGUILayout.EnumPopup(relic.rarity);
            EditorGUILayout.EndHorizontal();
        }

        private void DrawRelicTypeField(RelicSO relic)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Type:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.effectType = (RelicEffectType)EditorGUILayout.EnumPopup(relic.effectType);
            EditorGUILayout.EndHorizontal();
        }
        private void DrawRelicTypeInfo(RelicSO relic)
        {
            EditorGUI.indentLevel++;
            if (relic.effectType == RelicEffectType.Passive)
            {
                DrawPassiveFields(relic);
                relic.uniqueEffectScript = null;
            } else
            {
                DrawActiveFields(relic);
                relic.buffValue = 0;
            }
            EditorGUI.indentLevel--;
        }

        private void DrawPassiveFields(RelicSO relic)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Modify Stat:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.stat = (StatToChange)EditorGUILayout.EnumPopup(relic.stat);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Buff Value:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.buffValue = EditorGUILayout.FloatField(relic.buffValue);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Type:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.scalingType = (RelicScalingType)EditorGUILayout.EnumPopup(relic.scalingType);
            EditorGUILayout.EndHorizontal();
        }

        private void DrawActiveFields(RelicSO relic)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Abilities:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.UniqueEffectScript = (Ability)EditorGUILayout.ObjectField(relic.UniqueEffectScript, typeof(Ability), false);
            EditorGUILayout.EndHorizontal();
        }

        private void DrawSpriteField(RelicSO relic)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Sprite:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.sprite = (Sprite)EditorGUILayout.ObjectField(relic.sprite, typeof(Sprite), false);
            EditorGUILayout.EndHorizontal();
        }

        private void DrawShaderField(RelicSO relic)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Shader:", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.shaderMaterial = (Material)EditorGUILayout.ObjectField(relic.shaderMaterial, typeof(Material), false);
            EditorGUILayout.EndHorizontal();
        }
    }
#endif
    #endregion
}

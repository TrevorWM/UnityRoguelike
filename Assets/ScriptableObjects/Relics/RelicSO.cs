using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Xml.Serialization;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewRelic",menuName = "Items/Relic")]
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
    private ItemRarityOutlinesSO itemRarityOutlines;
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

    private void OnEnable()
    {
        SetOutlineShader();
    }

    public virtual void ApplyRelicEffect(Stats targetStats, int stacks)
    {
        CheckRelicScalingType();
    }

    public virtual void Collect()
    {
        Debug.LogFormat("You collected a {0}", RelicName);
        OnRelicSOCollected?.Invoke(this);
    }

    private void SetOutlineShader()
    {
        shaderMaterial = itemRarityOutlines.itemRarityOutlines[(int)rarity];
    }

    private void CheckRelicScalingType()
    {
        switch (scalingType)
        {
            case RelicScalingType.Additive:
                Debug.Log("Additive");
                break;
            case RelicScalingType.Multiplicative:
                Debug.Log("Multiplicative");
                break;
            case RelicScalingType.Logarithmic:
                Debug.Log("Log");
                break;
            case RelicScalingType.Exponential:
                Debug.Log("Expo");
                break;
            default:
                Debug.Log("Did not find Scaling Type");
                break;

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

            EditorGUILayout.EndVertical();

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
            EditorGUILayout.LabelField("Sprite", GUILayout.MaxWidth(LABEL_WIDTH));
            relic.sprite = (Sprite)EditorGUILayout.ObjectField(relic.sprite, typeof(Sprite), false);
            EditorGUILayout.EndHorizontal();
        }
    }
#endif
    #endregion
}

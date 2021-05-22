using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Another;
using static Another.Main;
using static UsefulMethod;

namespace Another
{
    public enum Element
    {
        Nothing,
        Fire,
        Ice,
        Thunder,
        Light,
        Dark
    }

    public class BattleController : MonoBehaviour
    {
        public Ally ally;
        public EnemyController enemyCtrl;
        public DropController dropCtrl;
        public TextMeshProUGUI areaText;
        [NonSerialized] public RectTransform thisRect;
        public Image backgroundImage;
        public SKILLEFFECT[] effectObjects;
        public SKILLEFFECT[] animationEffectObjects;
        [NonSerialized] public static Vector2 behindPosition = Vector2.down * Screen.height;//待機場所
                                                                                            //AttackToEnemy
        public void AttackToEnemy(Skill skill, SkillType skillType, Element element, Debuff debuff, double dmg, long hitCount, Vector2 initPosition, float effectRange)
        {
            ENEMY tempEnemy = enemyCtrl.enemies[0];
            for (int i = 0; i < enemyCtrl.enemies.Length; i++)
            {
                tempEnemy = enemyCtrl.enemies[i];
                if (tempEnemy.isSpawn)
                {
                    if (Distance(initPosition, tempEnemy.position) < effectRange)
                    {
                        for (int j = 0; j < hitCount; j++)
                        {
                            tempEnemy.Attacked(element, debuff, dmg);
                        }
                    }
                }
            }
            AttackEffect(skill, initPosition, effectRange);
        }
        public void AttackEffect(Skill skill, Vector2 position, float range)
        {
            switch (skill)
            {
                default:
                    InstantiateEffect(main.skillCtrl.skillEffectSprites[(int)skill], position, range);
                    break;
            }
        }
        public void SimpleAttackEffect(Element element, Vector2 initPosition, float range)
        {
            switch (element)
            {
                default://ここは後でSprite追加
                    InstantiateEffect(main.skillCtrl.skillEffectSprites[0], initPosition, range);
                    break;
            }
        }
        //AttackToAlly
        public void AttackToAlly(Element element, Debuff debuff, double dmg, long hitCount = 1)
        {
            for (int j = 0; j < hitCount; j++)
            {
                ally.Attacked(element, debuff, dmg);
            }
            SimpleAttackEffect(element, ally.position, 50);
        }
        public void InstantiateEffect(Sprite sprite, Vector2 position, float range, float showTime = 0.1f)
        {
            for (int i = 0; i < effectObjects.Length; i++)
            {
                if (!effectObjects[i].isShow)
                {
                    effectObjects[i].ShowEffect(sprite, position, range, showTime);
                    break;
                }
            }
        }
        //Target
        public ENEMY TargetEnemy(Vector2 startPosition)
        {
            float tempDistance = 9999f;
            ENEMY tempEnemy = enemyCtrl.enemies[0];
            ENEMY tempCalEnemy;
            float calDistance = 0;
            for (int i = 0; i < enemyCtrl.enemies.Length; i++)
            {
                tempCalEnemy = enemyCtrl.enemies[i];
                calDistance = Distance(startPosition, tempCalEnemy.position);
                if (tempCalEnemy.isSpawn && calDistance < tempDistance)
                {
                    tempDistance = calDistance;
                    tempEnemy = tempCalEnemy;
                }
            }
            return tempEnemy;
        }
        public ENEMY TargetEnemyFromAlly()
        {
            return TargetEnemy(ally.position);
        }
        public float Distance(Vector2 startPosition, Vector2 finishPosition)
        {
            return vectorAbs(finishPosition - startPosition);
        }
        public Vector2 Direction(Vector2 startPosition, Vector2 finishPosition)
        {
            return normalize(finishPosition - startPosition);
        }

        public float TargetDistanceToEnemy()
        {
            return Distance(ally.position, TargetEnemyFromAlly().position);
        }
        public Vector2 MoveDirectionToEnemy()
        {
            return Direction(ally.position, TargetEnemyFromAlly().position);
        }
        public float TargetDistanceToAlly(Vector2 startPosition)
        {
            return Distance(startPosition, ally.position);
        }
        public Vector2 MoveDirectionToAlly(Vector2 startPosition)
        {
            return Direction(startPosition, ally.position);
        }
        public void SpawnEnemy(EnemySpecies species, EnemyColor color, Vector2 position, long level, long difficulty)
        {
            ENEMY tempEnemy;
            for (int i = 0; i < enemyCtrl.enemies.Length; i++)
            {
                tempEnemy = enemyCtrl.enemies[i];
                if (!tempEnemy.isSpawn)
                {
                    tempEnemy.Spawn(species, color, position, level, difficulty);
                    break;
                }
            }
        }
        public void VanishAllEnemy()
        {
            for (int i = 0; i < enemyCtrl.enemies.Length; i++)
            {
                if (enemyCtrl.enemies[i].isSpawn)
                    enemyCtrl.enemies[i].Vanish();
            }
        }
        public bool isVanishedAll;
        void UpdateIsVanishedAll()
        {
            for (int i = 0; i < enemyCtrl.enemies.Length; i++)
            {
                if (enemyCtrl.enemies[i].isSpawn)
                {
                    isVanishedAll = false;
                    return;
                }
            }
            isVanishedAll = true;
        }
        public void Initialize(bool isFullHeal = false, Sprite backgroundSprite = null)
        {
            if (isFullHeal)
                ally.FullHeal();
            VanishAllEnemy();
            ally.SetInitPosition();
            if (backgroundSprite != null)
                backgroundImage.sprite = backgroundSprite;
        }

        private void Awake()
        {
            thisRect = gameObject.GetComponent<RectTransform>();
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            UpdateIsVanishedAll();
            areaText.text = optStr + "<size=26>" + main.areaCtrl.AreaString() + "\n<size=20>" + main.areaCtrl.WaveString();
        }
    }
}

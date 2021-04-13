using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ARTIFACT.ArtifactName;

public class SlimeSet : BASE {

    public bool SetSlime;
    public bool SetSlime4;
    public GameObject Mucus;
    public int TotalSlimeLevel()
    {
        int tempInt = 0;
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.artifactName == SlimeSword || arti.artifactName == SlimeRing || arti.artifactName == SlimeHat|| arti.artifactName==SlimeStick)
            {
                tempInt += arti.level;
            }
        }
        return tempInt;
    }

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        StartCoroutine(SlimeSetCor());
	}

    private void Update()
    {
        if (isSlimeSet3())
            SetSlime = true;
        else
            SetSlime = false;
        if (isSlimeSet4())
            SetSlime4 = true;
        else
            SetSlime4 = false;
    }

    bool isSlimeSet3()
    {
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.artifactName == SlimeSword || arti.artifactName == SlimeRing || arti.artifactName == SlimeHat)
            {
                if (!arti.isEquipped)
                    return false;
            }
        }
        return true;
    }

    bool isSlimeSet4()
    {
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.artifactName == SlimeSword || arti.artifactName == SlimeRing || arti.artifactName == SlimeHat || arti.artifactName == SlimeStick)
            {
                if (!arti.isEquipped)
                    return false;
            }
        }
        return true;
    }

    IEnumerator SlimeSetCor()
    {
        while (true)
        {
            yield return new WaitUntil(() => SetSlime);
            if (!SetSlime4)
            {
                GameObject game;
                game = Instantiate(Mucus, main.Transforms[1]);
                game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
                game.AddComponent<MucusAttack>().damage = SlimeBallDamage();
                game.GetComponent<MucusAttack>().TargetPosition = new Vector2(0, 1);
                game.GetComponent<MucusAttack>().damageKind = SKILL.DamageKind.physical;
                game.name = "SlimeBall";
                //game.GetComponent<MucusAttack>().isDestroyAfterCollide = true;
            }
            else
            {
                int partingNum = Math.Min(4 + main.NewArtifacts[(int)SlimeStick].level / 10,8);
                float noise;
                if (UnityEngine.Random.Range(0, 10000) < 5000)
                    noise = 2 * Mathf.PI / (partingNum * 2);
                else
                    noise = 0;
                GameObject[] games = new GameObject[partingNum];
                for (int i = 0; i < partingNum; i++)
                {
                    games[i] = Instantiate(Mucus, main.Transforms[1]);
                    games[i].GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
                    games[i].AddComponent<MucusAttack>().TargetPosition =
                        RadianToVector(2 * Mathf.PI / partingNum * i + noise);
                    games[i].GetComponent<MucusAttack>().damage = SlimeBallDamage();
                    games[i].GetComponent<MucusAttack>().damageKind = SKILL.DamageKind.physical;
                    games[i].name = "SlimeBall";
                }
            }
            yield return new WaitForSeconds(SlimeBallInterval());
        }
    }

    public double SlimeBallDamage()
    {
        return 1000 + main.skillSetController.DPS() * (0.01 + TotalSlimeLevel() * 0.0002 + main.NewArtifacts[(int)SlimeStick].level*0.001);
    }
    public float SlimeBallInterval()
    {
        return 3.0f / Math.Min(1 + TotalSlimeLevel() / 30, 6);
    }

    public class MucusAttack : Attack
    {
        public Vector2 TargetPosition;
        public float speed = 7;

        private void Awake()
        {
            AwakeAttack();
        }

        private void Start()
        {
            StartCoroutine(Move());
            StartCoroutine(DestroyThis());
        }

        public IEnumerator Move()
        {
            while (true)
            {
                thisRect.anchoredPosition += normalize(TargetPosition) * speed;
                yield return new WaitForSeconds(0.017f);
            }
        }

        public IEnumerator DestroyThis()
        {
            yield return new WaitForSeconds(2f);
            Destroy(this.gameObject);
        }
    }
}

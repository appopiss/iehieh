using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ARTIFACT.ArtifactName;
using static ArtiCtrl.MaterialList;

public class Q_SlimeLover : ACHIEVEMENT
{
    public long[] num;
    public override bool[] isSeen { get => main.S.isS_slimeLover; set => main.S.isS_slimeLover = value; }
    // Use this for initialization
    void Awake()
    {
        AwakeQuest(5, Type.Limited);
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        CliantName = "Slime otaku";//"Slime Hat man";
        discription[0] = "Hey! You look like you've been out there killing slimes! I collect their parts!  My momma told me that I needed to collect something, so this is what I picked. My only problem is that I'm not actually strong enough to fight them. They'll gobble me up and spit out my bones. So will you help me gather 1000 ooze stained cloth?! I'm going to make some slime clothes for myself, so maybe they'll let me hang out with them without eating me.";
        discription[1] = "It kind of worked! I was able to blend in with the normal slimes no problem! I had to steer clear of the others, though, because they seemed to know something was off. What do you mean slimes don't think?! Look they picked up on vibes or something, so I'm going to need more help from you, if you're willing. This time I need 5 Gooey Sludge and 2000 Ooze Stained Cloth. I don't care where you get them, but this will surely help me go undetected by the other slimes!";
        discription[2] = "Oh man, you won't believe it but my upgraded disguise works on all of the slimes except the really big ones that wear those cool sunglasses. It's like with those glasses on they just see right through my disguise! I had to run away to keep from getting digested by that guy, or thing, you know what I mean. This time I've raided my mom's cabinet and I'm ready to give you a good reward if you'll get me some Acidic Goo and a Slime Eye Ball. Yeah, if he looks me in that slimy eye, he'll for sure fall for my getup and accept me as a slime!";
        discription[3] = "Haha I am like one of them now. They don't even know I'm not a slime like them. I just make gurgling sounds and shuffle around and it's like I'm one of the family. I'm a little sad you keep killing so many of them, but if you hadn't, then I wouldn't be able to fulfill of dreams of living like a slime! I just have one problem, though. So I kind of lost something important to me and it was gobbled up by a red slime. It's probably completely dissolved by now, but if there's one kind of slime I don't like, then it's the red ones. I think I'd feel a lot better if you killed 3000 of them for me. Then they wouldn't be around as much and I'd get to enjoy hanging out with the rest of the slimes in peace.";
        discription[4] = "You really did it! I gurgled to the other slimes that a slayer was coming for the red slimes and now they think I'm some sort of prophet slime! Oh yeah, I'm starting to understand their language a little bit. It's pretty simple once you spend enough time living with them. My mom quit letting me come in the house because of all of the slimy goop I track in, so I've also been sleeping out there too. It's fine though, I feel more at home with the slimes than I do at home. My skin is even kind of turning tranluscent! I wonder if that's from the acidic goo from my disguise. Oh well, I have one last favor to ask of you. I need 3 Slime Core because I've heard of a potion that will make it so that I don't have to blend in... I'll actually become a slime! I've got everything else but that, so will you please get it for me? Oh and once I'm a slime, please don't kill me.";
        //これらの処理は必ずAwakeQues()の後に書く．
        //QuestName
        QuestNames[0] = "Slime lover 1";
        QuestNames[1] = "Slime lover 2";
        QuestNames[2] = "Slime lover 3";
        QuestNames[3] = "Slime lover 4";
        QuestNames[4] = "Slime lover 5";
        rewardText[0] = "- 1000 Gold\n- Gold Cap + 200";
        rewardText[1] = "- 500 Monster Fluid\n- 5 Carved Idol";
        rewardText[2] = "- 5 Nature Shards\n- Gold Cap + 1000";
        rewardText[3] = "- Equipment Slot " + LetterImage() + " 30";
        rewardText[4] = "- 5000 Monster Fluid " + LetterImage() + " 100";
        //Condition
        Condition[0] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OozeStainedCloth] >= 1000;
        Condition[1] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.GooeySludge] >= 5 && main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OozeStainedCloth] >= 2000;
         Condition[2] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.AcidicGoop] >= 1 && main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SlimeEyeBall] >= 1;
        Condition[3] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.RedSlime] >= 3000;
        Condition[4] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SlimeCore] >= 3;
        CurrentProgress[0] = () => main.TextEdit(new string[] { "Ooze Stained Cloth ", main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OozeStainedCloth].ToString(), " / 1000" });
        CurrentProgress[1] = () => main.TextEdit(new string[] { "Gooey Sludge ", main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.GooeySludge].ToString(), " / 5\n- Ooze Stained Cloth ", main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OozeStainedCloth].ToString(), " / 2000" });
        CurrentProgress[2] = () => main.TextEdit(new string[] { "Acidic Goop ", main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.AcidicGoop].ToString(), " / 1\n- Slime Eye Ball ", main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SlimeEyeBall].ToString(), " / 1" });
        CurrentProgress[3] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.RedSlime] + " / 3000";
        CurrentProgress[4] = () => "Slime core " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SlimeCore] + " / 3";
        UnlockCondition[0] = "1000 Ooze Stained Cloth";
        UnlockCondition[1] = "5 Gooey Sludge\n- 2000 Ooze Stained Cloth";
        UnlockCondition[2] = "1 Acidic Goop\n- 1 Slime Eye Ball";
        UnlockCondition[3] = "Kill 3000 Red Slimes";
        UnlockCondition[4] = "3 Slime Core";
        QuestLocal.slimelover(ref CliantName, discription, QuestNames, rewardText, UnlockCondition,this);
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        switch (clearNum)
        {
            case 0:
                main.ArtiCtrl.CurrentMaterial[OozeStainedCloth] -= 1000;
                main.SR.gold += 1000;
                break;
            case 1:
                main.ArtiCtrl.CurrentMaterial[GooeySludge] -= 5;
                main.ArtiCtrl.CurrentMaterial[OozeStainedCloth] -= 2000;
                main.ArtiCtrl.CurrentMaterial[MonsterFluid] += 500;
                main.ArtiCtrl.CurrentMaterial[CarvedIdol] += 5;
                break;
            case 2:
                main.ArtiCtrl.CurrentMaterial[AcidicGoop] -= 1;
                main.ArtiCtrl.CurrentMaterial[SlimeEyeBall] -= 1;
                main.ArtiCtrl.CurrentMaterial[NatureShard] += 5;
                break;
            case 3:
                GetEC(3);
                break;
            case 4:
                main.ArtiCtrl.CurrentMaterial[MonsterFluid] += 5000;
                main.ArtiCtrl.CurrentMaterial[SlimeCore] -= 3;
                GetEC(10);
                break;
        }

    }

    // Use this for initialization
    void Start()
    {
        StartQuest();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuest();
        if(clearNum >= 1 && clearNum < 3)
        {
            GoldCapBonus = 200;
        }
        else if(clearNum >= 3)
        {
            GoldCapBonus = 1200;
        }
        if(clearNum >= 4)
        {
            EquipmentBonus = 1;
            SEbonus = 3;
        }
        if (clearNum >= 5)
            SEbonus = 10;
        //Debug.Log(Input.mousePosition-new Vector3(575,345));
    }
}

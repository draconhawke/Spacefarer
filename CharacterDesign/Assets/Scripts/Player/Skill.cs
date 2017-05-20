using UnityEngine.UI;

[System.Serializable]
public class Skill  {
    public string SkillName;
    public Image SkillIcon;                 //visual image of related skill
    public int SkillCostSpec;               //cost to train at specializing skill, max prof at 126
    public int SkillCostAdvance;            //cost to train at advance skill, max prof at 108
    public int SkillLevel = 0;              //starting level at untrained
    public int SkillMaxLevel = 100;         //maximum train level at untrained
    public int SkillProficiency = 0;        //training prof, changed by training. is different than level/max level
    public Category SkillCategory;          //specialization level of skill

    public Skill() {
        SkillName = "";
        SkillIcon = null;
        SkillCostSpec = -1;
        SkillCostAdvance = -1;
        SkillLevel = 0;
        SkillMaxLevel = 0;
        SkillProficiency = 0;
        SkillCategory = Category.AVAILABLE;
    }
    //public Skill(string name, int adv, int spec, int level,int prof, Category cate)
    //{
    //    SkillName = name;
    //    SkillCostSpec = spec;
    //    SkillCostAdvance = adv;
    //    SkillLevel = level;
    //    SkillProficiency = prof;
    //    SkillCategory = cate;
    //}
    public Skill(string name, int adv, int spec, int level) {
        SkillName = name;
        SkillCostSpec = spec;
        SkillCostAdvance = adv;
        SkillLevel = level;
    }
    public Skill(string name, int adv, int spec, int level, Image icon, Category cate) : this(name,adv,spec,level){
        SkillIcon = icon;
        SkillCategory = cate;
    }

    public enum Category { UNAVAILABLE, AVAILABLE, LEARNED, ADVANCED, SPECIALIZED}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;

public class WordList : MonoBehaviour
{
    [SerializeField] TextAsset wordListJson;
    List<string[]> words;
    public List<string[]> Words
    {
        get
        {
            return words;
        }
    }

    // public List<string> words = new List<string>()
    // {
    //     "ABSENT","ABSORB","ACCEPT","ACCESS","ACTION","ACTIVE","ACTUAL","ADJUST","ADMIRE","ADVICE","ADVISE","AERIAL","AFFECT","AFFORD","AFRAID","AGENCY","ALMOST","AMOUNT","ANIMAL","ANNUAL","ANSWER","APPEAL","APPEAR","ARABLE","ARREST","ARRIVE","ASLEEP","ASSERT","ASSESS","ASSIST","ASSUME","ASSURE","ATTACH","ATTACK","ATTEND","BALTIC","BARREN","BASKET","BATTLE","BECOME","BEHAVE","BELIEF","BELONG","BEWARE","BIKING","BINARY","BITTER","BLOODY","BORROW","BOTHER","BOTTOM","BRANCH","BREATH","BRIDGE","BRIGHT","BUBBLE","BUDGET","BUTTER","CAMERA","CANCEL","CAREER","CARPET","CASTLE","CASUAL","CENTRE","CHANCE","CHANGE","CHARGE","CHEESE","CHOICE","CHOOSE","CHURCH","CLEVER","CLIENT","COARSE","COFFEE","COLOUR","COMBAT","COMMIT","COMMON","COMPLY","CONVEY","CORNER","COUNTY","COUPLE","COURSE","CREATE","CREDIT","CRISIS","DAMAGE","DANGER","DAZZLE","DEBATE","DECENT","DECIDE","DEFEAT","DEFEND","DEFINE","DEGREE","DEMAND","DENTAL","DEPEND","DERIVE","DESIGN","DESIRE","DETAIL","DETECT","DEVISE","DEVOTE","DIFFER","DINNER","DIRECT","DISMAL","DISTAL","DIVIDE","DIVINE","DOCTOR","DORSAL","DOUBLE","DRAGON","DRIVER","EFFECT","EFFORT","EIGHTH","EMERGE","EMPLOY","ENABLE","ENDURE","ENERGY","ENGAGE","ENGINE","ENIGMA","ENSURE","ENTIRE","EROTIC","ESCAPE","ESTATE","ETHNIC","EVOLVE","EXCEED","EXCUSE","EXEMPT","EXPAND","EXPECT","EXPORT","EXPOSE","EXTEND","EXTENT","FABLED","FACIAL","FACTOR","FAMILY","FAMOUS","FATHER","FAULTY","FAVOUR","FEEBLE","FELLOW","FEMALE","FEUDAL","FIERCE","FIGURE","FILTHY","FINISH","FINITE","FISCAL","FLIGHT","FLOPPY","FLORAL","FLOWER","FOLLOW","FOREST","FORGET","FORMAL","FORMER","FOSTER","FOURTH","FREEZE","FRIEND","FULFIL","FUTURE","GARDEN","GATHER","GENTLE","GERMAN","GLOBAL","GLOOMY","GLOSSY","GOLDEN","GOSSIP","GOTHIC","GOVERN","GROWTH","GUILTY","GUITAR","HANDLE","HAPPEN","HEALTH","HECTIC","HEROIC","HOLLOW","HONEST","HONOUR","HUDDLE","HUNGRY","IGNORE","IMPACT","IMPOSE","INCOME","INDUCE","INFORM","INJURY","INLAND","INNATE","INSECT","INSERT","INSIDE","INSIST","INTACT","INTEND","INVEST","INVITE","INWARD","IRONIC","ISLAND","JIGSAW","JUNGLE","JUNIOR","KERNEL","LABOUR","LAGOON","LATENT","LATTER","LAUNCH","LAVISH","LAWFUL","LEADER","LEAGUE","LENGTH","LESSER","LETHAL","LETTER","LIABLE","LIKELY","LINEAR","LIQUID","LISTEN","LITTLE","LIVELY","LOCATE","LONELY","LOVELY","MANAGE","MANNER","MANUAL","MARINE","MARKET","MARTIN","MASTER","MATURE","MEAGRE","MEDIAN","MEMBER","MEMORY","MENTAL","METHOD","MIDDLE","MINUTE","MOBILE","MODERN","MODEST","MODIFY","MOMENT","MOTHER","MUMBLE","MURDER","MUSEUM","MUTUAL","NARROW","NATURE","NEARBY","NEURAL","NIBBLE","NORMAL","NOTICE","OBJECT","OBTAIN","OCCUPY","OFFICE","OFFSET","OPPOSE","OPTION","ORANGE","OUTPUT","OXBOW","OXFORD","PALACE","PEPPER","PERIOD","PERMIT","PERSON","PILLOW","PLANET","PLAQUE","PLAYER","PLEASE","POLICE","POLICY","POTATO","PREFER","PRETTY","PRINCE","PRISON","PROFIT","PROPER","PUBLIC","PUNISH","PURSUE","QUENCH","RACIAL","RACIST","RANDOM","REASON","RECALL","RECENT","RECKON","RECORD","RECTAL","REDUCE","REFORM","REFUSE","REGAIN","REGARD","REGION","REGRET","REJECT","RELATE","RELIEF","REMAIN","REMIND","REMOTE","REMOVE","RENDER","REPAIR","REPEAT","REPORT","RESCUE","RESIGN","RESIST","RESULT","RESUME","RETAIL","RETAIN","RETIRE","RETURN","REVEAL","REVIEW","REVIVE","RITUAL","ROBUST","ROCKET","SACRED","SAFETY","SAILOR","SAVAGE","SCARCE","SCHEME","SCHOOL","SCREEN","SEARCH","SEASON","SECOND","SECRET","SECTOR","SECURE","SELECT","SENIOR","SERIAL","SERIES","SETTLE","SEVERE","SEXUAL","SHABBY","SHADOW","SHOULD","SHREWD","SILENT","SILVER","SIMPLE","SINGLE","SISTER","SLEEPY","SLIGHT","SMOOTH","SOCIAL","SOURCE","SOVIET","SPEECH","SPEEDY","SPINAL","SPIRIT","SPREAD","SPRING","SPRUCE","SQUARE","STABLE","STATUS","STEADY","STREET","STRESS","STRICT","STRIKE","STRONG","STUPID","SUBMIT","SUBTLE","SUDDEN","SUFFER","SUMMER","SUNSET","SUPERB","SUPPLY","SURVEY","SWITCH","SYSTEM","TACKLE","TARGET","TENDER","THEORY","THREAT","THRUST","TOMATO","TRAGIC","TRAVEL","TREATY","TRIBAL","TRICKY","TRIPLE","TRIVIA","TURTLE","UNABLE","UNEVEN","UNFAIR","UNIQUE","UNLIKE","UNPACK","UNPAID","UNSURE","UPDATE","UPWARD","URGENT","USEFUL","VALLEY","VERBAL","VICTOR","VISUAL","VOLUME","WANDER","WEEKLY","WEIGHT","WHISKY","WINDOW","WINTER","WONDER","WOODEN","WORTHY","XENIAL","YELLOW","ZENITH"
    // };

    private void Awake()
    {

    }

    public void Init()
    {
        // WordListAsset wordList = WordListAsset.CreateFromJSON(wordListJson.text);
        var wordList = JsonConvert.DeserializeObject<WordListAsset>(wordListJson.text);
        words = wordList.wordArrays.ToList<string[]>();
    }
}

[System.Serializable]
public class WordListAsset
{
    [SerializeField]
    public string[][] wordArrays;

    public static WordListAsset CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<WordListAsset>(jsonString);
    }
}

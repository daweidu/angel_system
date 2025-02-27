using System;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{

    /// <summary>
    /// Add a sync marker of 0x1ACFFC1D and a 4 byte length
    /// to the given message
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static byte[] AddMessageHeader(byte[] message)
    {
        //Debug.Log(String.Format("Adding sync and length marker. Message length = {0}", message.Length));
        byte[] sync = { 0x1A, 0xCF, 0xFC, 0x1D };
        byte[] length = {(byte)((message.Length & 0xFF000000) >> 24),
                         (byte)((message.Length & 0x00FF0000) >> 16),
                         (byte)((message.Length & 0x0000FF00) >> 8),
                         (byte)((message.Length & 0x000000FF) >> 0)};
        byte[] newMessage = new byte[message.Length + 8]; // 4 byte sync + 4 byte length

        System.Buffer.BlockCopy(sync, 0, newMessage, 0, sync.Length);
        System.Buffer.BlockCopy(length, 0, newMessage, sync.Length, length.Length);
        System.Buffer.BlockCopy(message, 0, newMessage, sync.Length + length.Length, message.Length);

        return newMessage;
    }

    public static string ConvertClassNumToStr(uint objectType)
    {
        return dict[objectType];
    }

    public static float linterpolate(float x, float source_0, float source_1, float dest_0, float dest_1)
    {
        if ((source_1 - source_0) == 0)
            return (dest_0 + dest_1) / 2;
        
        return dest_0 + (x - source_1) * (dest_1 - dest_0) / (source_1 - source_0);
    }

    private static Dictionary<uint, string> dict = new Dictionary<uint, string>()
        {
          {0,"tap"},
{1,"spoon"},
{2,"plate"},
{3,"cupboard"},
{4,"knife"},
{5,"pan"},
{6,"lid"},
{7,"bowl"},
{8,"drawer"},
{9,"sponge"},
{10,"glass"},
{11,"hand"},
{12,"fridge"},
{13,"cup"},
{14,"fork"},
{15,"bottle"},
{16,"onion"},
{17,"cloth"},
{18,"board:chopping"},
{19,"bag"},
{20,"spatula"},
{21,"container"},
{22,"liquid:washing"},
{23,"box"},
{24,"hob"},
{25,"dough"},
{26,"package"},
{27,"water"},
{28,"meat"},
{29,"pot"},
{30,"potato"},
{31,"oil"},
{32,"cheese"},
{33,"bread"},
{34,"food"},
{35,"tray"},
{36,"bin"},
{37,"pepper"},
{38,"salt"},
{39,"colander"},
{40,"jar"},
{41,"carrot"},
{42,"top"},
{43,"tomato"},
{44,"kettle"},
{45,"pasta"},
{46,"oven"},
{47,"sauce"},
{48,"skin"},
{49,"paper"},
{50,"maker:coffee"},
{51,"garlic"},
{52,"towel"},
{53,"egg"},
{54,"rubbish"},
{55,"rice"},
{56,"mushroom"},
{57,"chicken"},
{58,"cutlery"},
{59,"coffee"},
{60,"glove"},
{61,"can"},
{62,"leaf"},
{63,"sink"},
{64,"milk"},
{65,"heat"},
{66,"jug"},
{67,"aubergine"},
{68,"salad"},
{69,"chilli"},
{70,"dishwasher"},
{71,"mixture"},
{72,"cucumber"},
{73,"clothes"},
{74,"peach"},
{75,"flour"},
{76,"courgette"},
{77,"filter"},
{78,"butter"},
{79,"scissors"},
{80,"chopstick"},
{81,"tofu"},
{82,"blender"},
{83,"olive"},
{84,"mat"},
{85,"spice"},
{86,"sausage"},
{87,"peeler:potato"},
{88,"napkin"},
{89,"cover"},
{90,"microwave"},
{91,"pizza"},
{92,"button"},
{93,"towel:kitchen"},
{94,"vegetable"},
{95,"stock"},
{96,"grater"},
{97,"ladle"},
{98,"yoghurt"},
{99,"cereal"},
{100,"wrap:plastic"},
{101,"broccoli"},
{102,"sugar"},
{103,"brush"},
{104,"biscuit"},
{105,"lemon"},
{106,"juicer"},
{107,"wrap"},
{108,"scale"},
{109,"rest"},
{110,"rack:drying"},
{111,"alarm"},
{112,"salmon"},
{113,"freezer"},
{114,"light"},
{115,"spreads"},
{116,"squash"},
{117,"leek"},
{118,"cap"},
{119,"fish"},
{120,"lettuce"},
{121,"curry"},
{122,"seed"},
{123,"foil"},
{124,"machine:washing"},
{125,"corn"},
{126,"soup"},
{127,"oatmeal"},
{128,"onion:st"},
{129,"clip"},
{130,"lighter"},
{131,"ginger"},
{132,"tea"},
{133,"nut"},
{134,"vinegar"},
{135,"holder"},
{136,"pin:rolling"},
{137,"pie"},
{138,"powder"},
{139,"burger"},
{140,"book"},
{141,"shell:egg"},
{142,"tongs"},
{143,"cream"},
{144,"pork"},
{145,"oregano"},
{146,"banana"},
{147,"processor:food"},
{148,"paste"},
{149,"recipe"},
{150,"liquid"},
{151,"choi:pak"},
{152,"cooker:slow"},
{153,"plug"},
{154,"utensil"},
{155,"noodle"},
{156,"salami"},
{157,"kitchen"},
{158,"teapot"},
{159,"floor"},
{160,"tuna"},
{161,"lime"},
{162,"omelette"},
{163,"bacon"},
{164,"sandwich"},
{165,"phone"},
{166,"thermometer"},
{167,"orange"},
{168,"basket"},
{169,"parsley"},
{170,"spinner:salad"},
{171,"tablet"},
{172,"presser"},
{173,"coriander"},
{174,"opener:bottle"},
{175,"cake"},
{176,"avocado"},
{177,"lentil"},
{178,"blueberry"},
{179,"fan:extractor"},
{180,"cellar:salt"},
{181,"hummus"},
{182,"chair"},
{183,"juice"},
{184,"pancake"},
{185,"bean:green"},
{186,"toaster"},
{187,"apple"},
{188,"chocolate"},
{189,"ice"},
{190,"knob"},
{191,"handle"},
{192,"wine"},
{193,"pea"},
{194,"pith"},
{195,"yeast"},
{196,"coconut"},
{197,"fishcakes"},
{198,"spinach"},
{199,"apron"},
{200,"raisin"},
{201,"basil"},
{202,"grape"},
{203,"kale"},
{204,"wire"},
{205,"asparagus"},
{206,"paprika"},
{207,"mango"},
{208,"caper"},
{209,"drink"},
{210,"stalk"},
{211,"turmeric"},
{212,"whetstone"},
{213,"kiwi"},
{214,"bean"},
{215,"thyme"},
{216,"finger:lady"},
{217,"beef"},
{218,"whisk"},
{219,"blackberry"},
{220,"slicer"},
{221,"control:remote"},
{222,"label"},
{223,"celery"},
{224,"cabbage"},
{225,"hoover"},
{226,"breadstick"},
{227,"roll"},
{228,"cocktail"},
{229,"crisp"},
{230,"ladder"},
{231,"beer"},
{232,"pan:dust"},
{233,"battery"},
{234,"powder:washing"},
{235,"backpack"},
{236,"cumin"},
{237,"cutter:pizza"},
{238,"air"},
{239,"pear"},
{240,"quorn"},
{241,"funnel"},
{242,"wall"},
{243,"strawberry"},
{244,"almond"},
{245,"tv"},
{246,"scotch:egg"},
{247,"shelf"},
{248,"straw"},
{249,"stand"},
{250,"machine:sous:vide"},
{251,"masher"},
{252,"guard:hand"},
{253,"shrimp"},
{254,"fruit"},
{255,"artichoke"},
{256,"cork"},
{257,"cherry"},
{258,"sprout"},
{259,"mat:sushi"},
{260,"stick:crab"},
{261,"ring:onion"},
{262,"pestle"},
{263,"window"},
{264,"gin"},
{265,"bar"},
{266,"mint"},
{267,"heater"},
{268,"grass:lemon"},
{269,"rubber"},
{270,"gherkin"},
{271,"breadcrumb"},
{272,"watch"},
{273,"melon"},
{274,"cinnamon"},
{275,"popcorn"},
{276,"dumpling"},
{277,"rosemary"},
{278,"power"},
{279,"syrup"},
{280,"candle"},
{281,"pineapple"},
{282,"sheets"},
{283,"soda"},
{284,"raspberry"},
{285,"airer"},
{286,"balloon"},
{287,"turkey"},
{288,"computer"},
{289,"key"},
{290,"pillow"},
{291,"pen"},
{292,"face"},
{293,"plum"},
{294,"whiskey"},
{295,"door:kitchen"},
{296,"tape"},
{297,"camera"},
{298,"cd"},
{299,"extract:vanilla"}

        };

    public static bool InFOV(Camera cam, Vector3 obj)
    {
        Vector3 viewPos = cam.WorldToViewportPoint(obj);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            return true;

        return false;
    }

    public static float GetCameraToEnvironmentDist()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 31;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(AngelARUI.Instance.mainCamera.transform.position,
                            AngelARUI.Instance.mainCamera.transform.forward, out hit, Mathf.Infinity, layerMask))
            return Mathf.Abs(hit.distance);

        return -1;
    }
}
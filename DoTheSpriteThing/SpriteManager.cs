﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ImageMagick;

namespace DoTheSpriteThing
{
    public class SpriteManager
    {
        /// <summary>
        /// Create a sprite image from a list of images and the CSS to render each image.
        /// </summary>
        /// <param name="images">The list of images to include in the sprite.</param>        
        /// <param name="spriteSettings">The settings to use when creating the sprite.</param>
        public void CreateSprite(IReadOnlyCollection<IImage> images, SpriteSettings spriteSettings)
        {
            const string placeholderImageBytes = "0x89504E470D0A1A0A0000000D4948445200000320000002580806000001ED71B2E60000001974455874536F6674776172650041646F626520496D616765526561647971C9653C0000032469545874584D4C3A636F6D2E61646F62652E786D7000000000003C3F787061636B657420626567696E3D22EFBBBF222069643D2257354D304D7043656869487A7265537A4E54637A6B633964223F3E203C783A786D706D65746120786D6C6E733A783D2261646F62653A6E733A6D6574612F2220783A786D70746B3D2241646F626520584D5020436F726520352E332D633031312036362E3134353636312C20323031322F30322F30362D31343A35363A32372020202020202020223E203C7264663A52444620786D6C6E733A7264663D22687474703A2F2F7777772E77332E6F72672F313939392F30322F32322D7264662D73796E7461782D6E7323223E203C7264663A4465736372697074696F6E207264663A61626F75743D222220786D6C6E733A786D703D22687474703A2F2F6E732E61646F62652E636F6D2F7861702F312E302F2220786D6C6E733A786D704D4D3D22687474703A2F2F6E732E61646F62652E636F6D2F7861702F312E302F6D6D2F2220786D6C6E733A73745265663D22687474703A2F2F6E732E61646F62652E636F6D2F7861702F312E302F73547970652F5265736F75726365526566232220786D703A43726561746F72546F6F6C3D2241646F62652050686F746F73686F702043533620284D6163696E746F7368292220786D704D4D3A496E7374616E636549443D22786D702E6969643A43443041323637393236393331314534394536364435323036363045424345372220786D704D4D3A446F63756D656E7449443D22786D702E6469643A4344304132363741323639333131453439453636443532303636304542434537223E203C786D704D4D3A4465726976656446726F6D2073745265663A696E7374616E636549443D22786D702E6969643A4344304132363737323639333131453439453636443532303636304542434537222073745265663A646F63756D656E7449443D22786D702E6469643A4344304132363738323639333131453439453636443532303636304542434537222F3E203C2F7264663A4465736372697074696F6E3E203C2F7264663A5244463E203C2F783A786D706D6574613E203C3F787061636B657420656E643D2272223F3E08D52BE000001ED84944415478DAECDC3B128230144051A2CC50BA065B6B5BD76049E14C16C746E3D83B2AA8F020E72EC00F87E4050B5329A5519C762E0110010122204004048880001110010122204004048880001110010122204004048866AB8DF461524A79A9F72EA50C409EB7C485C951BEBC2DCB0C197DE766207130C26D29B62C5B9680BC3F6D8D39799DD73C7BA2AF9061C231F8B4E6D9B3B52DEB19C011481C8C471720F37758CB93F89640F28B617DFD62050159F0A1710FE47FF3A19B70D7DF80FC6F58F73F7E3D201FD4CF8C0CE44D5D53596BF9B5B79A55B2AB14232C4A1B1464682AADAD7875842CF90333334440800808100101222040044440800808100101222040044440800808100101A2D9BA0BC0DEFDEB100CC4011C27319BB07B07ABC186C92CD157B5183D83C57B885ED2C1206893EB9DEBE79B34B135FA71FD93487FFEB9688508081001012220400404888008081001012220400404888008081001012220400464B065F356D29463574346AFBEEF5C6FF704FB357A55FF07B26F7EB91320E90B10B3E6F311489E404032EA02246DAFB7A08F7ABBB55C4D615B790E8987D2E5D41646B05EAD90742D4BB8F69404B22EE186A014906F077D0A24CE410FDBBCC30A380089B702761D6F4ACCC28D783AAA3A3EC557403CBD1705520D0D72A8933ECDC26DD9B6877D9C80FCDEA2877D8C73FCE246AF02F9D86634F0BCC0CC354440800808100101222040044440800808100101222040044440800808100101A2FE7A0AC0DEDDAB340C850118265454843828E8527074D0AD83B35B571717C18B2BB809BA7470122FC20B105D1C5C141C04D14FCD201A492C4D9A34CF0307A53FD0FCBC3D3945AABF5C04EF5820101008080404020201818040402080404020201010080804040202018180404020804040202010100808040402EDB56017FC96249FFFE17EB1839BFEE29B360552C67187B77DE4F00BA4ACCB18B7DE14AC41003348A5EFB48F31CEED1E338838F2ADBA4C1108B8C4E24FA38259A2AA4F808E62F4B2DF9F639C3A1402697224B3BCAC5BC96EF371AC40AC774ADC2F146B10714CE9B198415AEDFB5AE3BF41BDC638B10B05D2B619E03EC6450D3341CFDA44204DB71363F0E3B6CD8213F720463AE5389F629C391CD6204D9B350605F71FE6DC9656F05A526B133348536CC418967CEC7276E2DEC5E8D714ED4D8C2B87C90C32AB596338C1F3FA35BEC62DB38940EAB6D4C293EEE3F56E3B742EB1EA38D1DA6A2F1B3EE9328388A3603BD61C4E33C8B4AC673FC773B44D49B65D0F0EAF4026B56F17745BE25B2C7276CAD7B79AEC7670D3AFDF9C1002018B741008080404020201818040402020104020201010080804040202018180404020804040202010100808040402028139F12E003BF7B2123714006038C17AE9A28260DD752142BB6857BA1144C15D11045DB4054BE7E1842E5AFA0E7D097D02D76EBD6D62822DCC9474CCE899CC49CEF741C4F13AC999DF73A24E5C5911CC202010100808040402020181804040208040402020101008080404020201818040402080404020201010080804040202018180400081804040202010100808040402020181804000818040402020101008080404020201810002018180404020201088CA0B8760549EE77F5F5D486CD7EFAA17455178100864AC95723B4C74DF2FCAEDB7878025D638AB09EFFB6BC36F0699C46922FB3930D46610100808049C837466CD7E536E3F1D12330859B65D7342BBE42457203C78DB70564120C9F9EA100884FF9B7308040208E4497E3804E9F16BDEE66E6718D0F02F004E0D85192456D583F3AAE6EDDF1B0414228EBADB9841A2F2ABC5EF3518F3763389192469EF9FF97E04D26B5BCF7C3F02E9AD41E08F4320C9C52112812467ADE5CF43209DF2B1E5CF4320BD5D5A596AB5C0DF41C2DB28B79DA1DB4DFE5EF139D0F7AEBE8E276F9941A2B633E14FF697D9C393AE42A8BECEA2211048D79649E39E4BF229F07DF8621804D2B57388EAB924CB2D9E37381F114854D61B7CCCD13FB70FA67C9F0E0C8B4062B13BE14FF6EA0AD9D3BEC4E9AA611148EC4BAB3AC7E5F62DD2FB8640827ACA851C5E451E3002096239EBCE851C360D9740DA76D4A1FBFAC17009C4B2C5524B20113816B640A837378393ECD0DE1846814C4B1F2E3FBA6F1805627962A9259016EDF5709F4E0CEBE33C1FA499F33F1B02A1C6A5432010ACD5710EF2A8EB84F7FDCAF08FCA8BA27014860F485EFD277AF6AEDCE613DCFD338F0781802516080404020201818040402020101088430002018180404020201010080804040202010402020181804040202010100808040402020104020201818040402020101008080404020804040202018180404020201010080804040208040402020181C0ACDD0BC0DEBDBC585987011C7F0F781973315EC01AB48DA38B02C5845C34B6514C37D9C234053B7FDCE0C24B82145904E5426C15E222DA542B11A40B9388296ABE3D3FE63D308CB7F7DCDFCBE7030F5E9833E33C73F43BBF793D673A799EDB02003EC302404000101000040400040400010140400010100004040004040001014040001010000404000404000101404000101000040400040400010140400010100004040004040001014040001010000404000404000101404000101000040400040400010140400010100004C40A00101000040400010140400040400010100004040001014040004040001010000404000101A0F1D65801AFD3E974D20F276236DA46AB2CE6796E0B38813094DDE2D14AA7AC002710C66129E6913534CA9C1520204CC2AD98DBD6D0285D2BA01FBE84058080003039BE84C5A4A5FFD2B5A5F8F93F31FF59090808BCC87CCC42C997FD3DE686958180D06EDB628E0D109B34BFC4FC6485506DAE81300E3B0788C74AEFC61CB2461010DAE7E0085EC70E6B0401014040A0943FAD009ACF4574C6E19B98CF62D60FF13A166BF87EBF1FF3CE8A5F7F1F73C7DD010181FE5C88591B73A6CFDB5D8DF9AB66EFEBCB6279B8F8F161CC2577090404CA7BB2E2249162F261F6FCC5F1148BEB31F76BF8FEBD11F3698997DB902D3FCFD41731FFBA5B2020D07F4C7E68D0FB939EEA7CA6CFDBA4D8A46730BEE8EE4013B8880EFD59579C266606BCFD4C71FB7556891308B4C7F1984D237A5DA7B3E5E702FBD25A71028166FF3DE98E301E3D9B8AD7EBEF214E20D0404763DE1CF3DB381B7337E63BEBC609049AA13B8178F4BC95F98E80388140EDA5A79F9F9F62B47E8BF9D187010181D1D81CF3F1AADFFB36E68F31FC033E6DBB8A59F46147406070AF7AB05EEF29E36FC75C1BF2EDEC8979AF62EF7B8AD9CD989FDD0DA822D740A8B25359B9477ABF3DE4C9A15BC178F4ECCF5C1B4140A0B4F5D9600FD64BB7F9A08F97DF5DA37F9CD39F73DE5D832AF1252CAAE69398D9216E5FF6FA411D3FAB5F28C6B5119C4060D57DB13B643C560762EF0B7E7F4756FF2F09A53FFF9CBB0C4E2090651F65CB8F8318B57DC5F43E63FF3CA6D3909D1D89791673CEDD0701A1ADBA0D791BD33CB57D15B3E4AE8480D016E962F72E6B1889F4F898C731E7AD82497F0603D3387588C768F59E667E8355E0044213A58BDAFBAC61AC4EC63C88B96C153881D0A45387784CC6C662DF6BAD022710EA2C3DF86DC11AA6E24CCCDF315F5B054E20D4F1D4211ED3B5B5F83874AC0201A10EE632CFDF5435E9313087AD0101A1CAD277D73B620D95B45DD81110AA6836F3FDBDEB227D9C0E5803C372119D51B99779923F101028217D87C0A7D6000202FDF2980E68395FAFA68C5FADA095AE5801AFD2C9F3DC1600700201404000101000040400040400010140400010100004040004040001014040001010000404000404000101404000101000040400040400010140400010100004040004040001014040001010000404000404000101404000101000040400040400010140400010100004C40A00101000040400010140400040400010100004040001014040004040001010000404000101A0F1FE1780BD7BF98DAA8A03387E27D882A528D5E223208A89265641454824F10125A2C53715A995FAC7B97061E2CE8D61A11B5D1982C6A56ED444371A6242A206329E636F935A643A8F7B67EEB9E7F3498E91B433437FB9F0651EF79E4EB7DB3505003C0301404000101000040400040400010140400010100004040004040001014040001010000404000404000101404000101000040400040400010140400010100004040004040001014040001010000404000404000101404000101000040400040400010140400010100004C408001010000404000101404000404000101000040400010140400040400010100004040001014040004040001010000404000101404000404000101000040400010140400040400010100004040001014040004040001010000404000101404000404000101000040400010100010140400010100004040001010001014040001010000404000101000101404000101000040400010100010140400010100004040001010001014040001010000404000101000101404000101000DAE03623603B9D4E67E37F77948B76FB3BFEA7DBED9A0402C2C87687B56C0C59F9A65C704B5EC2A21FE2919F278D000101404000680EEF8130AC5F8CA055E6C39A3206048471B86404AD72B68C08F4CD4B580008080002028080002020002020008CC2C77819B7785DAD5D61DD08EBAA718080402F07C25AECF1F5CB617D674C2020B0D96A1FC7D9D1727D14D675238334780F843A7D30E03F52626C761A1B0808795B1BF276178C0E04847C2D84D519E1F64B460802429E8E8D78FB7D460802427EAADA33FD41A30401212F872ABA9F478C120484BCECADE87EE68C120484BCDCA8E87E9C0F020242667E6DD8FD00024222AADA2BFD5BA30401213F55BCFC74CD18A1D95C0B8B3A7C528C7646F91709FECCD3612D873555FEFAF7B03E7528E019080CE6AFB0BE1FE199C78F89FDBCF19C95954DF188EE2AD6AF0576B7C3010181C17C550CFE7EC89FE5B39794CC86F5628FAFBF5A7E0F08080CE052589FF7F9BD713F908F13FC19CF55F43D2020B0C54F617D18D697C5CD6FAE77C3BA527EFD72823FDBBB357D2F24C19BE88CCB0FE56A8BA78AF5AD79FBB5ABBCCD1587029E8140BE6E0FEBC810B73B52DE16040432757E42B705018184BDDD90FB00018184C44BCCEFA9E07EF6142E578F804036E2074E4E54787F270A1F624140200BAB89DC27080834C8D944EF1B040426E84058F335DEFF7CF9182020D0229DB016C7F0388BE5638180404B5C6CE9638180408B9E15C4C73A69EC0808A42DEEE53189F7250E968F0D0202897A2DD3C706018111ACFA3D407F9C094B2A96C2DAB7E9D775EC39FE4C43FE4CC4DFC3D122CD3D52F00C041A656D4B3CA28D3DC7A72B7A8C7899F5C71BF4333F510CB6DF0808086C1177F2EBF569A8958A1EE77C437F76101018C2D37DFE2B7CADC57F51BFE33040406030F125A5C37D7EEF28E7502C14CD7EA96826ACC71C0E0808F46FD0979486398722BE7F722C81591C0F6BCA218180C0F69687BCDDA0E750AC243493F71C160808F4F66858BB47B87DBFE750BC91E06C5E77782020F0FFE2F90FCF56701FDBBD2C7528ACBD09CE672EAC071C2608080CFFEC613BF18DF1991EC7FCF309CFE8943FB70808FC57D53BF3DDEAE3AF6DB86CFAFB0E170404D6D5B5EBDFD6889C69C9BCE2C7964F3B6C10107257E7AE7F9BCFA1B827ACFB5A34B7FDC5CD97770101212B75BFA4B4710EC52B2D9CDD92C307012157278BF1ECFAD7E67328BC1F8280909D78D6F8416318D98E62F48F3E838090143BEF55279E7C396B0C080839B0E35EF5CE19010242DBC5B3C4ED84590FFB872020B456FC58ED8231D4265E96FEB0312020B491CD91EA1737E1DA690C0808E2C1302E180102425BC4B3C1678C61ACDE32020484D4C5B3C08F1BC3D8DD11D6C3C6808090323BE94DCE73FE8C2320A4CA0E7A9377D1081010521377CE9B33864678D908101052112F9078CA181AE3DEA25D97B2474068312F9B34CF1923404068BAD3C5782ED1CEE05CFA1D01A1B1E20E79FB8DA1B1E2A5DF5F3006048426B2435EF33D14D69DC68080D0242ED19E8E378D802AB8AC36551D479F194352E299EA7F180302C2A45D0FEB376380BC78090B00CF4018ABFB8DA055A68D0001615C5E3202C89B97B000101000048466F9DA08B273CD08D84EA7DBED9A02BD0F92CEBF97B69A2DD6CF62A6FDAE86F5B3BF1B1010006AE1252C0004040001014040001010001010000404000101404000101000101000040400010140400010100010100004040001014040001010001010000404000101404000101000101000040400010140400010100010100004040001014040001010001010000404000101404000404000101000040400010140400040400010100004040001014040004040001010000404000101404000404000101000040400010140400040400010100004040001014040004040001010000404000101404000404000101000040400010140408C00000101404000101000040400040400010140400010100004040004040001014040001010000404000404000101404000101000040400040400010140400010100004040004040001014040001010000404000404807AFD23407BF7E26465590770FC3943B8B8808A72596631081942B994612396458404424E81780BFE4B2F29486A534DA3D958934D35EA286A501303A2D22897D3EFE97DCFB4A4C0EE9EDB7BF97C667E330C0EECD9E75D97F3DDE7BCE7E974BB5DAB0000008C849F60010000020400001020000000020400001020000000020400001020000080000100001020000080000100001020000080000100000408000080000100000408000080000100000408000020400000000408000020400000000408000020400000000102000020400000000102000020400000000102000008100000000102000008100000000102000008100000000102000008100000408000000008100000408000000008100000408000000002040000408000000002040000408000000002040000102000000002040000102000000002040000102000008000010000102000008000010000102000008000010000040800008000010000040800008000010000040800008000010000040800002040000000040800002040000000040800002040000000010200002040000000010200002040000000010200000810000000010200000810000000010200000810000040800000000810000040800000000810000040800000000204000040800000000204000040800000000204000040800000000204000010200000000204000010200000000204000010200000800001000010200000800001000010200000800001000004080000800001000004080000800001000004080000204000000004080000506B5FB10440BF3A9D4EEF971331DF88B93366B1958146B81C7326E6CD98F7F36F74BB5DAB02CCFF79836F22C08002646FCC2AAB018D773C9E3B9CB20CC07C7909163008EBC507B4C60396001020C0B82DB004D01A5EBE0D08100000A01EFC140318A5975279132B5049FB63965B066098EC8000000002040000102000000002040000102000000002040000102000004083390704689ADB62D6C6AC8EB9237DF929EDDD988F634EA7E25C92BF97BF0700081080EBBA256647CCD41CFE4CA7FC737936CEF8FD0B31AFC5BC675901408000CC0C880762360CF8EF9D8CD959FEFA5CCC89984F2D37000810A0BD36C76C1FC1C7C92FE57A34E69F31C762AE587A00E89F9BD081BAC8F7721C1C517CCCB432E668CC2A9700000408D09EF83814B3748C8F616F2A6E6C07000408D0703F88B9B9028F6377CC84CB0100020468AE1531D315FA9EB9D5250100010234D774C51ECF1A9704000408D05C0B2BF6786E724900408000CD75BE628FE79C4B0200020468AE7752B5CEE078DB250100010234D7C598D72AF2584E0B1000E88F93D0813AF86BCC92549C823E2E1FC71C772946FAEFD3542A4EA4CFF7DD7C1A732A55EF2579000810A0A15E8F391BF3E0183EF6FB312FB90443974F9BFF7E9ADD992F1FC4FC36E6826503102000C392EF07792F1507024E8DE0E37D1EF37C72E3F928C2634F9ADBCB82F3DB211F8EB914F342CC19CB0820400086E172CCB1F2C9EA7D319B86F031F293D957623EB1DC4395AFE1BE98E57DFE3B7620E65F652C5EB1AC0002046018F213CD57CBC96785DC1373779ADF391DDD9893316FC47C646947221F30B97B807F5F8E98A33127623EB4BC0002046098F23B65FDA19C9EFCD3F55B6396C62C9AF1FB7907E57C191A9F5BBA91EBA4E2E556C37A095D8E9AFC6E65C7CBB0044080008C44DE21395B0ED5B03AE6A132428629C74DDE0D793115EF9C05800001A065F2CEC4F4083F5E6FA725BF1CEB84E507A80E071102304C2B52B11B313DA68F3F5D7EFC152E054035D80101605876C6ACADC0E3C83F6C7B38156FE1FC8ACB0230FE6FCA003048CB628E54243E665A5B3EAE652E11C0F8D80101609076C46CACF0E35B10F348CCDF5271923A000204801A5A12F3E334BF7358C62147D2BA986792032701040800B5B23D66730D1F778EA543317F8AF9BDCB08204000A8B6C954EC7A2CAAF9E7B1256643CCD331FF76590186CB4DE800CCC7D698C30D888F9EFC793C567E5E000C911D1000E662221537714F36F4F3BB3715F787E47B433E73B90106CF0E0800B3B529E68906C747CFE2F2F3FCBA4B0E3078764000B89185A9B8D76369CB3EEFFB63EE8E7936E6A22F0380C1B00302C0F5AC8F79AA85F1D1734BF9F9AFF7A5003018764000066FAA7CC27A7B2A760F2EC59C8D7937E6C3986E0D3E87FC03AA7D31CB5DCEFF7A30152FC97A21E68AE500102000E3B6B67C92BAE01AFF7D59BAFAA7E8F924EE572BFA64763A66B74BFA052B628EC4BC1873CA720008108071581DF3504C678E7F6E633967628EA56ADC63903F87BD312B5DD6EBAED19E987F94D7AD6B4900E6C63D2000F3FFFEB9BF7C32DAE9E3EFB92315F7186CA940481D151FB3B6AA5CAF294B013037764000E6F7647D3EBB1ED7F3AD54DC63308EF327F2CBADA65DD639CBD7FF47A9B8AFE784E500981D3B2000737BC299C3A3DF5D8F6B19F5F913F99E86A3E2A36F79FDF2BD21B75B0A801BB3030230FB27EBFB86141EFF6F14E74FEC4CC58DF30C467EF3817C56CABB31BFB41C000204A06E4FD67BE74FFC2AE69D01FEBDF9DDB8F6A76BBF5B17FD5917B3A68CC78F2C07800001A8DB93F5FCD6BE7937E4E7A9FFB7ECDD918A77DE62F8FFB6FE24E62FA978AB650066700F08C0B59FAC3F92AAB15390DF292BDFAB71E73CFFFC929827C5C7C86D2AD77DB1A500F81F3B20005F7CB29E5FCB7F53051FDBAE34F7F327F2BB6B6D7159C7267F1D3D1AF3C798372C07801D108099B6C71CAA687CF4CCF6FC89C998C7C547656C2BAFC7CD9602683B3B2000C593F5BCEBB1A8268FB777FEC40731BFF892FFBE35E65E97B572F2D7D76331AFC7BC693980B6B20302B45D7EB27EB846F131537EB7A599E74F4CA4E2E53EE2A3DAF24EDBC154ED9D3680A1B10302B4557EF277206669CD3F8FDEF9136753F1AE5DD443FEBACB37A8FF3AE66DCB0108108066CB278DDFDFB0CF497CD4D3776336C73C1773C972006DE02558409B2C8CF96903E3837ABB2DE667315FB314401BD80101DA627D2A0EF583AAFA5E2A0E9D7C3EF57FE8244065D90101DAF07DEE80F8A02696A7E26D96D7580AA0A9EC80004D964F0EDF6519A8A11FC69C8E399E667FE824402DD801019A289F93B1577C5073F9B0C9BC1BB2D252004D62070468E293B63D65844013627A5FCCC998972D07D00476408026D99D8A13C2C5074DF3D574F5A19300B56507046882FCA4ECE1541CCA074DD53B74F2AD98DF580E4080008C473EC8ED2ECB408B6C885917F34CCC79CB01081080D1B835156FAFEBFB186DFDF73B1FAAF9E798DF590E4080000CD7B75371601BB4DD3DA9D8017C3AE682E500EAC04DE8409D2C8E79527CC05526620EC76CB314401DD80101EAE29B9E60C10DFF1FD9988ADD90CF2C075055764080AA5B14F3B8F88059998C7922D925042ACC0E085065F9F5EDF7590698B37C9FD4A654BC53D645CB0154891D10A08A16C61C141FD097A5314F256F530D548C1D10A06AF21907DFB10C3030F9AC9CBC9BF85CCC65CB018C9B1D10A04ADF8F0E880F188A65314762A62D05306E764080AAB812F3AC65008066B30302000008100000A079BC040B18A55D960000DACD0E0800002040805AE95A02F0FF3B80000146E564CC25CB00ADF0962500FAD1E976FD2003E8F31B49A7D3FBE5B672FC70039AE75CCCCB31E73D770004080000500B7E4A09000008100000408000000008100000408000000008100000408000000002040000408000000002040000408000000002040000102000000002040000102000000002040000102000008000010000102000008000010000102000008000010000040800008000010000040800008000010000040800002040000000040800002040000000040800002040000000040800002040000000010200002040000000010200002040000000010200000810000000010200000810000000010200000810000040800000000810000040800000000810000040800000000204000040800000000204000040800000000204000010200000000204000010200000000204000010200000000204000010200000800001000010200000800001000010200000800001000004080000800001000004080000800001000004080000204000000004080000204000000004080000204000000001020000204000000001020000204000000001020000081000000001020000081000000001020000081000000001020000081000004080000000081000004080000000081000004080000000020400004080000000020400004080000000020400001020000000020400001020000000020400001020000080000100001020000040ADFD07641E67EDCC403D8B0000000049454E44AE426082";

            var placeholderImages = new List<IImage>
            {
                new ByteArrayImage("placeholder", Encoding.ASCII.GetBytes(placeholderImageBytes), "placeholder")
            };

            CreateSprite(images, placeholderImages, spriteSettings);
        }

        /// <summary>
        /// Create a sprite image from a list of images and the CSS to render each image.
        /// </summary>
        /// <param name="images">The list of images to include in the sprite.</param>
        /// <param name="placeholderImages">The list of custom placeholder images.</param>
        /// <param name="spriteSettings">The settings to use when creating the sprite.</param>
        public void CreateSprite(IReadOnlyCollection<IImage> images, IReadOnlyCollection<IImage> placeholderImages, SpriteSettings spriteSettings)
        {
            var spritePlaceholderImages = new List<SpritePlaceholderImage>();

            using (var spriteImages = new MagickImageCollection())
            {
                var css = new StringBuilder();
                var nextSpriteImageTop = 0;                
                
                foreach (IImage image in images)
                {
                    var hasImageBeenAddedToSprite = false;                    
                    var selectedImageHeight = 0;
                    var selectedImageTop = 0;
                    var selectedImageWidth = 0;                    

                    if (image is FileImage)
                    {
                        var imageFile = (FileImage)image;
                        
                        var imageForSprite = new MagickImage(imageFile.FilePath) { Quality = spriteSettings.Quality };

                        if (imageFile.Resize)
                        {
                            imageForSprite.Resize(new MagickGeometry($"{imageFile.ResizeToHeight}x{imageFile.ResizeToWidth}!"));
                        }

                        spriteImages.Add(imageForSprite);
                        hasImageBeenAddedToSprite = true;

                        selectedImageTop = nextSpriteImageTop;
                        selectedImageHeight = imageForSprite.Height;
                        selectedImageWidth = imageForSprite.Width;                        
                    }
                    else if (image is ByteArrayImage)
                    {
                        var byteArrayImage = (ByteArrayImage)image;                                                                                        

                        if (byteArrayImage.ImageData != null)
                        {
                            var imageForSprite = new MagickImage(byteArrayImage.ImageData) {Quality = spriteSettings.Quality};

                            if (image.Resize)
                            {
                                imageForSprite.Resize(new MagickGeometry($"{image.ResizeToWidth}x{image.ResizeToHeight}!"));
                            }

                            spriteImages.Add(imageForSprite);
                            hasImageBeenAddedToSprite = true;

                            selectedImageTop = nextSpriteImageTop;
                            selectedImageHeight = imageForSprite.Height;
                            selectedImageWidth = imageForSprite.Width;                            
                        }
                        else
                        {
                            string selectedPlaceholderImageKey = placeholderImages.Any(x => x.Key == byteArrayImage.PlaceholderImageKey) ? byteArrayImage.PlaceholderImageKey : placeholderImages.First().Key;
                            IImage selectedPlaceholderImage = placeholderImages.FirstOrDefault(x => x.Key == selectedPlaceholderImageKey);

                            MagickImage imageForSprite;

                            if (selectedPlaceholderImage is FileImage)
                            {                                
                                imageForSprite = new MagickImage(((FileImage)selectedPlaceholderImage).FilePath) {Quality = spriteSettings.Quality};
                            }
                            else
                            {
                                imageForSprite = new MagickImage(((ByteArrayImage)selectedPlaceholderImage).ImageData) { Quality = spriteSettings.Quality };
                            }

                            if (image.Resize)
                            {
                                imageForSprite.Resize(new MagickGeometry($"{image.ResizeToWidth}x{image.ResizeToHeight}!"));
                            }

                            SpritePlaceholderImage spritePlaceholderImage = spritePlaceholderImages.FirstOrDefault(x => x.Key == selectedPlaceholderImageKey && x.Width == imageForSprite.Width && x.Height == imageForSprite.Height);

                            if (spritePlaceholderImage == null)
                            {                                
                                spritePlaceholderImage = new SpritePlaceholderImage(selectedPlaceholderImageKey, nextSpriteImageTop, imageForSprite.Height, imageForSprite.Width);
                                spritePlaceholderImages.Add(spritePlaceholderImage);

                                spriteImages.Add(imageForSprite);
                                hasImageBeenAddedToSprite = true;                                
                            }

                            selectedImageTop = spritePlaceholderImage.Top;
                            selectedImageHeight = spritePlaceholderImage.Height;
                            selectedImageWidth = spritePlaceholderImage.Width;
                        }
                    }
                    
                    css.AppendLine($"#{image.Key} {{ height: {selectedImageHeight}px; width: {selectedImageWidth}px; background-image: url('{spriteSettings.SpriteUrl}'); background-position: 0px -{selectedImageTop}px; }}");

                    if (hasImageBeenAddedToSprite)
                    {
                        nextSpriteImageTop += selectedImageHeight;
                    }
                }                

                using (MagickImage result = spriteImages.AppendVertically())
                {
                    result.Write(spriteSettings.SpriteFilename);
                }

                File.WriteAllText(spriteSettings.CssFilename, css.ToString());
            }
        }                
    }
}

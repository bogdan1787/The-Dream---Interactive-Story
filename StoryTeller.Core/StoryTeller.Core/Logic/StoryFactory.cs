using System;
using System.Collections.Generic;
using System.Linq;
using StoryTeller.Core.Model;

namespace StoryTeller.Core.Logic
{
    public static class StoryFactory
    {
        private static readonly List<Story> _stories = new List<Story>();

        static StoryFactory()
        {
            //            var storyRo = new Model.Story
            //            {
            //                Title = "Visul",
            //                Chapters = new[]
            //             {
            //                    new StoryChapter()
            //                    {
            //                        Number = 1,
            //                        Text =  @"E întuneric. Nimic nu e vizibil. Auzi vocea unei femei care strigă Trezește-te, trezește-te, Oh, Doamne, de ce nu se trezește? Glasul ei e răgușit, ca și cum ar fi plâns mult și ai impresia vagă că îl recunoști. Cu greu, realitatea ia locul visului și te trezești. Primul lucru pe care îl vezi este tavanul. Apoi simți așternuturile patului șifonate sub corpul tău și te gândești că vocea era doar un vis, iar acum te așteaptă o nouă dimineață. Îți întinzi mâinile și picioarele și realizezi că tot corpul tău e obosit și amorțit ca după un efort foarte mare. Geamul este deschis și prin el intră ușor un vânt cald.",
            //                        Decisions = new[]
            //                        {
            //                            new StoryChapterDecision() { Decision = 'a', Text = @"te gândești din nou la vocea din vis", Color = "Red"},
            //                            new StoryChapterDecision() { Decision = 'b',Text = @"deschizi dulapul și te îmbraci rapid", Color = "Green"}
            //                        }
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 2,
            //                        Decision = 'a',
            //                        Text = @"Te gândești din nou la vocea din vis. Cu siguranță ai visat pe cineva cunoscut. Era un glas de femeie plin de durere. Cine ar fi putut să fie? Fără nici o legătură, îți aduci aminte de Mădălina/Grace. Fata cu picioare lungi și ochi albaștri pe care o iubești. Unde este ea? Ar fi trebuit să fie aici, în pat, lângă tine, dar nimic de al ei nu e unde ar fi trebuit să fie. Nici o rochie aruncată prin cameră, nici o cutie de cremă pe masa de lângă pat, nici măcar parfumul ei de lămâie și trandafiri care îți place atât de mult. Pătura cu care ești învelit se mișcă ușor acolo unde ar fi trebuit să fie corpul ei întins în pat. Sau doar ți-ai imaginat?",
            //                        Decisions = new[]
            //                        {
            //                            new StoryChapterDecision() { Decision = 'a', Text = @"întinzi mâna și atingi pătura", Color = "Red"},
            //                            new StoryChapterDecision() { Decision = 'b',Text = @"te gândești că vântul care intră pe geam a mișcat pătura", Color = "Green"}
            //                        }
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 3,
            //                        Decision = 'a',
            //                        Text = @"Exact în secunda în care degetele tale ating pătura, ceva se mișcă dedesubt. Îți retragi mâna speriat și respirația ți se intensifică. Închizi ochii pentru două secunde și tragi aer în piept, apoi îi deschizi. Pătura a luat forma unui om. Fără să te gândești prea mult, tragi de ea și o dai la o parte. Te aștepți la tot ce e mai rău. Într-o fracțiune de secundă îți trece prin cap o secvență dintr-un film horror classic. Personajul principal e în pat, se acunde sub cearșafuri de o arătare, iar în secunda în care ridică pătura vede monstruozitatea acolo. Îi vede ochii negri ascunși de păr, îi simte respirația.
            //Și totuși în patul tău nu e nimic. Probabil vântul a mișcat pătura și apoi ți-ai imaginat. Da, asta trebuie să fie. Ți-ai imaginat că simți și vezi acolo un corp. Probabil îți este foarte dor de Mădălina/Grace și atât. 
            //Deodată, îți dorești foarte mult să o ții în brațe și să o strângi la piept. Ai nevoie de atingerea ei, ai nevoie să îi simți mirosul și să îți plimbi mâna prin părul ei. Ai nevoie să faci dragoste cu ea.
            //Faci un efort şi te îndrepţi către baie. Acolo te apleci să te speli pe față și, când te ridici, în oglindă vezi aceeași față obosită. Numai că de data asta ochii tăi sunt închiși și pleoapele tale sunt mov. Apoi imaginea își revine. E doar o oglindă și acolo ești tu. Cu siguranță doar ți-ai imaginat."
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 3,
            //                        Decision = 'b',
            //                        Text = @"Ești obosit. Știi că seara trecută ai băut cam mult și nu îți prea aduci aminte de ce. Ignori pătura și te ridici din pat. Picioarele îți trosnesc nemulțumite, dar le obligi să atingă covorul. În spatele tău, de sub pătură, se ridică o femeie cu părul negru. Nu o vezi, dar nici ea nu pare că te vede. Sunteți spate în spate. Te ridici și te duci către baie. Când te întorci către cameră să închizi ușa, femeia nu mai este acolo. Nici măcar nu ai observat-o.
            //Te apleci să te speli pe față și, când te ridici, în oglindă vezi aceeași față obosită. Numai că de data asta ochii tăi sunt închiși și pleoapele tale sunt mov. Apoi imaginea își revine. E doar o oglindă și acolo ești tu. Cu siguranță doar ți-ai imaginat."
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 2,
            //                        Decision = 'b',
            //                        Text = @"Deschizi dulapul și te îmbraci rapid. O pereche de blugi și un tricou oarecare sunt ținuta zilnică. Bagi mâna printre hainele atârnate pe umeraşe pentru că ştii că undeva trebuie să fie o curea. Degetele tale ating ceva rece şi umed.",
            //                        Decisions = new[]
            //                        {
            //                            new StoryChapterDecision() { Decision = 'a', Text = @"dai hainele la o parte şi cauţi să vezi ce ai atins", Color = "Red"},
            //                            new StoryChapterDecision() { Decision = 'b',Text = @"ignori ce ai simţit, cu siguranţă degetele tale au atins bara de metal care susţine umeraşele", Color = "Green"}
            //                        }
            //                    },
            //                      new StoryChapter()
            //                    {
            //                        Number = 3,
            //                        Decision = 'a',
            //                        Text = @"Întinzi mâna tremurând către haine. Cu ambele mâini separi tricoul negru de cămaşa cu dungi şi te uiţi. Nu e nimic acolo, e doar dulapul, aşa cum trebuie el să fie. Oftezi şi cauţi încă  odată cureaua. La un moment dat atingi iar acel ceva rece şi umed şi realizezi că e carne. Smulgi şi arunci pe jos toate tricourile, cămăşile şi pantalonii. Dulapul e gol în continuare. Te gândeşti că eşti obosit, aşa că te întorci cu spatele la dulap şi în sfârşit vezi cureaua în maldărul de pe jos. 
            //Te apleci să o iei de acolo şi chiar atunci apare în spatele tău o femeie. Ea stă aplecată şi părul îi cade pe faţă. Tu nu o vezi în timp ce ea se apropie de tine. Mâinile ei se intind către umerii tăi. Chiar înainte să te atingă, te îndrepţi căte baie. Acolo te uiți în oglindă și nu te recunoști. Pielea feței tale e mai albă și ai cearcăne adânci sub ochi. Te apleci să te speli și, când te ridici, în oglindă vezi aceeași față obosită. Numai că de data asta ochii tăi sunt închiși și pleoapele tale sunt mov. Apoi imaginea își revine. E doar o oglindă și acolo ești tu. Cu siguranță doar ți-ai imaginat."
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 3,
            //                        Decision = 'b',
            //                        Text = @"Întinzi mâna să îţi cauţi o curea, dar nu reuşeşti să o găseşti. Cauţi printre haine fără success, apoi începi să le arunci pe jos, nervos şi obosit. Cureaua nu e de găsit aşa că te întorci cu spatele la dulap şi chiar atunci o vezi între cămăşi, tricouri şi pantaloni. Te apleci să o iei şi chiar atunci apare în spatele tău o femeie. Ea stă aplecată şi părul îi cade pe faţă. Tu nu o vezi în timp ce ea se apropie de tine. Mâinile ei se intind către umerii tăi. Chiar înainte să te atingă, te îndrepţi căte baie. Acolo te uiți în oglindă și nu te recunoști. Pielea feței tale e mai albă și ai cearcăne adânci sub ochi. Te apleci să te speli și, când te ridici, în oglindă vezi aceeași față obosită. Numai că de data asta ochii tăi sunt închiși și pleoapele tale sunt mov. Apoi imaginea își revine. E doar o oglindă și acolo ești tu. Cu siguranță doar ți-ai imaginat."
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 4,
            //                        Text = @"Afară în sfârșit. Vântul adie uşor a primăvară şi soarele îți mângâie faţa. În rest, gol. Nicio fiinţă. Niciun om, niciun câine, nicio vietate care să bântuie strada prăfuită, doar vântul care se joacă de-a tornada cu gunoaiele aruncate aiurea pe jos şi soarele plictisit ţinându-i de urât. 
            //Simţi brusc o dorinţă aprigă de a-ți vedea iubita, aşa că începi să mergi către casa ei.
            //Când ajungi, privești fațada clădirii și realizezi că ai cheia de la ea. Ți-a dat-o acum câteva zile, când ți-a spus că oricând îți vei dori, vei putea să te autoinviți.
            //",
            //                        Decisions = new[]
            //                        {
            //                            new StoryChapterDecision() { Decision = 'a', Text = @"scoți cheia din buzunar și intrii", Color = "Red"},
            //                            new StoryChapterDecision() { Decision = 'b',Text = @"ar fi ciudat ca la prima oră a dimineții, din senin, să intrii în casa prietenei tale", Color = "Green"}
            //                        }
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 5,
            //                        Decision = 'a',
            //                        Text = @"Scoți cheia din buzunar și intrii. Te descalți cu grijă să nu o trezești. Te așezi pe fotoliul din vinilin de lângă pat și o privești cum doarme. E frumoasă. Are părul negru şi ochii, pe care nu poți să îi vezi acum, sunt albaștri. Îți aduci aminte de zâmbetul ei de parcă ar fi ceva îndepărtat, ca un fragment de amintire, ca o imagine a ceva ce a fost şi nu o să mai fie.
            //	Mădălina/Grace se mişcă uşor pe sub cearşaful transparent și te face să suspini de plăcere şi să te întinzi spre ea. O atingi uşor pe gât, pe sâni şi pe coapse, apoi te trânteşti la loc în fotoliu, mirându-te că nu ai trezit-o.",
            //                        Decisions = new[]
            //                        {
            //                            new StoryChapterDecision() { Decision = 'a', Text = @"te apleci și o săruți, încercând să o trezești", Color = "Red"},
            //                            new StoryChapterDecision() { Decision = 'b',Text = @"ți-e frică să nu se sperie dacă se trezește și te vede în camera ei așa că ieși din apartament la fel de ușor cum ai intrat" , Color = "Green"}
            //                        }
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 6,
            //                        Decision = 'a',
            //                        Text = @"Te apleci și o săruți, încercând să o trezești, dar ea se întoarce cu spatele la tine și continuă să doarmă. Simți cât de mult o iubești, câtă bucurie îți aduce zâmbetul ei și vrei acum mai mult ca niciodată să îl vezi așa că o mângâi ușor pe păr. Mâinile îți alunecă pe spatele ei, către fundul ferm cu care îți place atât de mult să te joci. Ești excitat. Te așezi în pat în spatele ei și o cuprinzi în brațe. Palma ta stângă îi atinge ușor un sân cu sfârc tare. Îți impingi erecția în ea și tragi adânc aer în piept cu ochii închiși. 
            //Dar în loc de parfumul ei simți miros de carne stricată. Ca atunci când mama ta a aruncat pulpele alea de pui expirate la coș, dar a uitat să ducă gunoiul. După două zile au început să putrezească și mama ta a fost nevoită să arunce coșul cu totul și să cumpere unul nou pentru că duhoarea se impregnase în plastic.	
            //Iar acum, cu ochii închiși și brațele cuprinzând-o pe iubita ta, simți același miros. Deschizi ochii exact în clipa în care o simți cum se întoarce către tine. Instinctiv, te tragi mai în spate, cu privirea fixată către capul ei. 
            //Și apoi vezi.
            //Pe fața mov a femeii sunt bube cu lichid, iar ochii îi ies grotesc de mult din orbite. Gura ei căscată are dinți negri, acolo unde ei încă nu au căzut. Și pute atât de puternic încat icnești fară să îți dai seama.
            //Te arunci din pat stângaci și cazi în fund pe fotoliul din spate.
            //Vrei să te ridici, dar cumva pielea ta se lipește de vinilinul roșu și începe să sfârâie. Simți cum te arde spatele. Încerci să îți dezlipești palmele de mânere, dar ele par lipite acolo cu cel mai puternic adeziv. Între timp, femeia cu părul negru și față mov se ridică din pat și se apropie de tine.
            //Deschizi buzele să țipi, dar nu iese niciun sunet. Tot corpul, acolo unde atinge fotoliul, ustură. E o durere ce devine din ce în ce mai puternică. În curând va deveni agonie, dar tu nu îți poți dezlipi privirea de la femeia care se apropie cumva plutind.
            //Te zbați și încerci încă odată să urli. Din  gâtul tău iese liniște, dar brațele tale se desprind de mânerele roșii. Pielea ta se întinde ca o gumă de mestecat și se rupe și ai impresia că o să leșini. Dar ăsta ar fi un noroc de care nu ai parte. 
            //Femeia e deja la câțiva centrimetri de fața ta. Duhoarea e de nesuportat. Încercările tale de a o împinge sunt sortite eșecului. Femeia scoate o limbă neagră umflată și te linge pe ochi. Pleoapele tale se închid instinctiv, dar simți toți porii limbii ei și apoi te săgetează o durere ascuțită sub ochi, acolo unde pleoapele tale ating obrajii. 
            //Nu mai simți limba, dar nu poți ști cu certitudine dacă nu mai este acolo, pentru că în momentul ăsta nu te poți concentra decât pe durere. E o durere care îți ia mințile și te întrebi în treacăt cum și de ce e posibil așa ceva. 
            //Sari de pe scaun, cu ochii pe care se pare că nu îi poți dezlipi, cu pielea atârnând și sângerând pe brațe și cu gura căscată într-un urlet pe care nu reușești să îl articulezi."
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 6,
            //                        Decision = 'b',
            //                        Text = @"Ți-e frică să nu se sperie dacă se trezește și te vede în camera ei așa că ieși din apartament la fel de ușor cum ai intrat. Te gândești că o plimbare prin parc își va face bine, te va ajuta să îți pui gândurile în ordine.
            //Când intri pe poarta din fier, un vânt ușor adie și te bucuri să îl simți. E gol, niciun om nicăieri și deoadată îți dai seama că de când ai ieșit din propriul apartament nu ai văzut pe nimeni, iar asta e cel puțin ciudat. 
            //Copacii se mișcă în bătaia vântului. Îi privești și te relaxezi așa că hotărăști să te așezi. 
            //Găsești o bancă mică, de o persoană, cu mânere din fier forjat lângă o salcie bătrână. E comod aici. Îți lași capul pe spate și privești crengile lăsate în jos cum se unduiesc. Închizi ochii și tragi aer adânc în piept, dar în loc de aerul curat al dimineții simți miros de carne stricată. Ca atunci când mama ta a aruncat pulpele alea de pui expirate la coș, dar a uitat să ducă gunoiul. După două zile au început să putrezească și mama ta a fost nevoită să arunce coșul cu totul și să cumpere unul nou pentru că duhoarea se impregnase în plastic.
            //Iar acum, stând pe bancă sub salcie, simți același miros. Deschizi ochii exact în clipa în care o vezi cum se întoarce către tine. Instinctiv, te tragi mai în spate, cu privirea fixată către capul ei. 
            //În fața ta, în picioare, e o femeie cu părul negru și lung. Pe fața mov are bube cu lichid, iar ochii îi ies grotesc de mult din orbite. Gura ei căscată are dinți negri, acolo unde ei încă nu au căzut. Și pute atât de puternic încat icnești fară să îți dai seama.
            //Vrei să te ridici, dar cumva pielea ta se lipește de lemn și începe să sfârâie. Simți cum te arde spatele. Încerci să îți dezlipești palmele de mânere, dar ele par lipite acolo cu cel mai puternic adeziv. Între timp, femeia cu părul negru și față mov începe să se apropie de tine.
            //Deschizi buzele să țipi, dar nu iese niciun sunet. Tot corpul, acolo unde atinge banca, ustură. E o durere ce devine din ce în ce mai puternică. În curând va deveni agonie, dar tu nu îți poți dezlipi privirea de la femeia care se apropie cumva plutind.
            //Te zbați și încerci încă odată să urli. Din  gâtul tău iese liniște, dar brațele tale se desprind de mânerele din fier. Pielea ta se întinde ca o gumă de mestecat și se rupe și ai impresia că o să leșini. Dar ăsta ar fi un noroc de care nu ai parte. 
            //Femeia e deja la câțiva centrimetri de fața ta. Duhoarea e de nesuportat. Încercările tale de a o împinge sunt sortite eșecului. Femeia scoate o limbă neagră umflată și te linge pe ochi. Pleoapele tale se închid instinctiv, dar simți toți porii limbii ei și apoi te săgetează o durere ascuțită sub ochi, acolo unde pleoapele tale ating obrajii. 
            //Nu mai simți limba, dar nu poți ști cu certitudine dacă nu mai este acolo, pentru că în momentul ăsta nu te poți concentra decât pe durere. E o durere care îți ia mințile și te întrebi în treacăt cum și de ce e posibil așa ceva. 
            //Sari de pe bancă, cu ochii pe care se pare că nu îi poți dezlipi, cu pielea atârnând și sângerând pe brațe și gura căscată într-un urlet pe care nu reușești să îl articulezi."
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 5,
            //                        Decision = 'b',
            //                        Text = @"Privești clădirea și vezi că are geamul deschis la dormitor. Te intorci cu spatele la ea și pornești către parc. Te gândești că o plimbare îți va face bine și te va ajuta să îți pui gândurile în ordine.
            //Când intri pe poartă, un vânt ușor adie și te bucuri să îl simți. E gol, niciun om nicăieri și deoadată îți dai seama că de când ai ieșit din propriul apartament nu ai văzut pe nimeni, iar asta e cel puțin ciudat. 
            //Copacii se mișcă în bătaia vântului. Îi privești și te relaxezi, apoi vezi o bancă de o persoană cu mânere din fier forjat, sub o salcie bătrână.
            //",
            //                        Decisions = new[]
            //                        {
            //                            new StoryChapterDecision() { Decision = 'a', Text = @"te așezi pe bancă", Color = "Red"},
            //                            new StoryChapterDecision() { Decision = 'b',Text = @"mergi mai departe", Color  = "Green" }
            //                        }
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 6,
            //                        Decision = 'a',
            //                        Text = @"E comod aici. Îți lași capul pe spate și privești crengile lăsate în jos cum se unduiesc. Închizi ochii și tragi aer adânc în piept, dar în loc de aerul curat al dimineții simți miros de carne stricată. Ca atunci când mama ta a aruncat pulpele alea de pui expirate la coș, dar a uitat să ducă gunoiul. După două zile au început să putrezească și mama ta a fost nevoită să arunce coșul cu totul și să cumpere unul nou pentru că duhoarea se impregnase în plastic.
            //Iar acum, stând pe bancă sub salcie, simți același miros. Deschizi ochii exact în clipa în care o vezi cum se întoarce către tine. Instinctiv, te tragi mai în spate, cu privirea fixată către capul ei. 
            //În fața ta, în picioare, e o femeie cu părul negru și lung. Pe fața mov are bube cu lichid, iar ochii îi ies grotesc de mult din orbite. Gura ei căscată are dinți negri, acolo unde ei încă nu au căzut. Și pute atât de puternic încat icnești fară să îți dai seama.
            //Vrei să te ridici, dar cumva pielea ta se lipește de lemn și începe să sfârâie. Simți cum te arde spatele. Încerci să îți dezlipești palmele de mânere, dar ele par lipite acolo cu cel mai puternic adeziv. Între timp, femeia cu părul negru și față mov începe să se apropie de tine.
            //Deschizi buzele să țipi, dar nu iese niciun sunet. Tot corpul, acolo unde atinge banca, ustură. E o durere ce devine din ce în ce mai puternică. În curând va deveni agonie, dar tu nu îți poți dezlipi privirea de la femeia care se apropie cumva plutind.
            //Te zbați și încerci încă odată să urli. Din  gâtul tău iese liniște, dar brațele tale se desprind de mânerele din fier. Pielea ta se întinde ca o gumă de mestecat și se rupe și ai impresia că o să leșini. Dar ăsta ar fi un noroc de care nu ai parte. 
            //Femeia e deja la câțiva centrimetri de fața ta. Duhoarea e de nesuportat. Încercările tale de a o împinge sunt sortite eșecului. Femeia scoate o limbă neagră umflată și te linge pe ochi. Pleoapele tale se închid instinctiv, dar simți toți porii limbii ei și apoi te săgetează o durere ascuțită sub ochi, acolo unde pleoapele tale ating obrajii. 
            //Nu mai simți limba, dar nu poți ști cu certitudine dacă nu mai este acolo, pentru că în momentul ăsta nu te poți concentra decât pe durere. E o durere care îți ia mințile și te întrebi în treacăt cum și de ce e posibil așa ceva. 
            //Sari de pe bancă, cu ochii pe care se pare că nu îi poți dezlipi, cu pielea atârnând și sângerând pe brațe și gura căscată într-un urlet pe care nu reușești să îl articulezi.",
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 6,
            //                        Decision = 'b',
            //                        Text = @"Ignori banca și hotărăști să mergi mai departe. E plăcut să te plimbi. Simți aer curat și miros de iarbă proaspăt tăiată. Nu  mai ai mult și ajungi la fântână.
            //În mijlocul ei e o statuie a doi copilași care toarnă apă dintr-un ulcior în altul. Te așezi pe margine și bagi o mână în fântână. E rece și plină de monede. Închizi ochii și te bucuri de senzație.
            //Dar în loc de iarbă și apă, acum simți miros de carne stricată. Ca atunci când mama ta a aruncat pulpele alea de pui expirate la coș, dar a uitat să ducă gunoiul. După două zile au început să putrezească și mama ta a fost nevoită să arunce coșul cu totul și să cumpere unul nou pentru că duhoarea se impregnase în plastic.
            //Iar acum, stând pe fântână cu una dintre mâini în apă, simți același miros. Deschizi ochii exact în clipa în care o vezi cum se întoarce către tine. Instinctiv, te tragi mai în spate, cu privirea fixată către capul ei. 
            //În fața ta, în picioare, e o femeie cu părul negru și lung. Pe fața mov are bube cu lichid, iar ochii îi ies grotesc de mult din orbite. Gura ei căscată are dinți negri, acolo unde ei încă nu au căzut. Și pute atât de puternic încat icnești fară să îți dai seama.
            //Vrei să te ridici, dar cumva pielea ta se lipește de ciment și începe să sfârâie. Simți cum te arde. Încerci să îți dezlipești palma rămasă afară sau să scoți mâna din apă, dar ele par lipite acolo cu cel mai puternic adeziv. Între timp, femeia cu părul negru și față mov începe să se apropie de tine.
            //Deschizi buzele să țipi, dar nu iese niciun sunet. Tot corpul, acolo unde atinge cimentul, ustură. E o durere ce devine din ce în ce mai puternică. În curând va deveni agonie, dar tu nu îți poți dezlipi privirea de la femeia care se apropie cumva plutind.
            //Te zbați și încerci încă odată să urli. Din  gâtul tău iese liniște, dar brațele tale se eliberează în sfârșit. Pielea ta se întinde ca o gumă de mestecat și se rupe și ai impresia că o să leșini. Dar ăsta ar fi un noroc de care nu ai parte. 
            //Femeia e deja la câțiva centrimetri de fața ta. Duhoarea e de nesuportat. Încercările tale de a o împinge sunt sortite eșecului. Femeia scoate o limbă neagră umflată și te linge pe ochi. Pleoapele tale se închid instinctiv, dar simți toți porii limbii ei și apoi te săgetează o durere ascuțită sub ochi, acolo unde pleoapele tale ating obrajii. 
            //Nu mai simți limba, dar nu poți ști cu certitudine dacă nu mai este acolo, pentru că în momentul ăsta nu te poți concentra decât pe durere. E o durere care îți ia mințile și te întrebi în treacăt cum și de ce e posibil așa ceva. 
            //Reușești să te ridici, cu ochii pe care se pare că nu îi poți dezlipi, cu pielea atârnând și sângerând pe brațe și gura căscată într-un urlet pe care nu poți să îl articulezi.",
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 7,
            //                        Text = @"Bătrânul e obișnuit cu munca lui. Coase pleoapele mortului cu pricepere, fără silă, ca și cum ar îngriji o păpușă. Îl dă cu parfum și se întreabă la cum o să arate și el pe masa din marmură veche.

            //Ai reușit să scapi și fugi. Deodată nu mai ești în apartament/parc ci undeva în aer liber. Picioarele tale se mișcă repede, adrenalina ți-a umplut corpul, dar în urma ta femeia cu părul negru șuieră. Ea vrea să te prindă în brațele ei putrezite și să te țină acolo pe vecie. Știi asta fără să ți-o spună cineva. Alergi cât poți de repede pentru că ești conștient că dacă ea te prinde, ești pierdut pentru totdeauna. Așa că fugi mâncând pământul, cu pleoapele cusute și țipând fără sunet.",
            //                        Decisions = new[]
            //                        {
            //                            new StoryChapterDecision() { Decision = 'a', Text = @"fugi în continuare", Color = "Red"},
            //                            new StoryChapterDecision() { Decision = 'b',Text = @"te întorci către ea, hotărât să o confrunți", Color = "Green"}
            //                        }
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 8,
            //                        Decision = 'a',
            //                        Text = @"Fugi în continuare până când ajungi într-un cimitir. Îți dai seama de asta când te lovești de o piatră funerară pe care o atingi ușor cu degetele și simți scrisul, numele celui trecut în neființă. Alergi în continuare, de data asta mult mai încet, cu mâinile întinse în față până când ajungi la o groapă proaspăt săpată. Nu ai cum să o vezi, dar simți cu piciorul golul.",
            //                        Decisions = new[]
            //                        {
            //                            new StoryChapterDecision() { Decision = 'a', Text = @"te ascunzi în groapă", Color = "Red"},
            //                            new StoryChapterDecision() { Decision = 'b',Text = @"fugi mai departe", Color = "Green"}
            //                        }
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 9,
            //                        Decision = 'a',
            //                        Text = @"Decizi să te ascunzi în groapă. Sari în ea, dar te lovești la coate și genunchi. Nu te așteptai să fie atât de adâncă. Te ghemuiești într-un colț și îți ții respirația. 
            //Ochii te ustură, acolo unde au fost cusuți de limba femeii cu păr negru și respiri din ce în ce mai greu. Pieptul tău se simte greu, ca și cum ceva ar sta deasupra lui și l-ar apăsa.	
            //Arătarea a ajuns deasupra gropii și începe să râdă. Nu e un râs normal, ci cumva horcăit și poți simți din nou mirosul ei. Te ridici în picioare cu gândul să ieși de acolo și să încerci să fugi iar, dar aluneci și cazi pe spate.
            //Și chiar atunci femeia cu păr negru aruncă prima lopată de pământ peste tine.
            //",
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 9,
            //                        Decision = 'b',
            //                        Text = @"Ocolești groapa și continui să fugi cu mâinile întinse în față. Exact în momentul în care începi să te miri cum de nu te-ai împiedicat până acum, cazi. O altă groapă pe care de data asta nu ai observat-o.
            //Cu ochii lipiți nu îți dai seama cât de adâncă e și te lovești la coate și genunchi. Te ghemuiești într-un colț și îți ții respirația. 
            //Ochii te ustură, acolo unde au fost cusuți de limba femeii cu păr negru și respiri din ce în ce mai greu. Pieptul tău se simte greu, ca și cum ceva ar sta deasupra lui și l-ar apăsa.	
            //Arătarea a ajuns deasupra gropii și începe să râdă. Nu e un râs normal, ci cumva horcăit și poți simți din nou mirosul ei. Te ridici în picioare cu gândul să ieși de acolo și să încerci să fugi iar, dar aluneci și cazi pe spate.
            //Și chiar atunci femeia cu păr negru aruncă prima lopată de pământ peste tine.
            //",
            //                    },
            //                                       new StoryChapter()
            //                    {
            //                        Number = 8,
            //                        Decision = 'b',
            //                        Text = @"Dar nu pentru mult timp. Hotărât să scapi odată de ea, te oprești brusc și te întorci către ea, hotărât să o confrunți. Dar în loc de carne stricată, simți parfumul ei, al Mădălinei/Grace. 
            //Pentru moment nu înțelegi ce se întâmplă și rămâi nemișcat. Apoi începi să auzi suspinele ei și în curând vocea ei blândă, înecată de plâns, îți spune „trezește-te, oh, te rog, trezește-te”.",
            //                        Decisions = new[]
            //                        {
            //                            new StoryChapterDecision() { Decision = 'a', Text = @"întinzi mâinile să o atingi", Color = "Red"},
            //                            new StoryChapterDecision() { Decision = 'b',Text = @"te întorci să fugi din nou, convins că nu e Mădălina/Grace" , Color = "Green"}
            //                        }
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 9,
            //                        Decision = 'a',
            //                        Text = @"Întinzi mâinile să o atingi, dar în loc de piele fină simți carne rece. Și moartă. E femeia cu părul negru. Și ea te prinde de palmă strâns.
            //Te smucești din strânsoare cu putere, dar cazi pe spate direct într-o groapă proaspăt săpată.
            //Cu ochii lipiți nu îți dai seama cât de adâncă e și te lovești la coate și genunchi. Te ghemuiești într-un colț și îți ții respirația. 
            //Ochii te ustură, acolo unde au fost cusuți de limba femeii cu păr negru și respiri din ce în ce mai greu. Pieptul tău se simte greu, ca și cum ceva ar sta deasupra lui și l-ar apăsa.	
            //Arătarea a ajuns deasupra gropii și începe să râdă. Nu e un râs normal, ci cumva horcăit și poți simți din nou mirosul ei. Te ridici în picioare cu gândul să ieși de acolo și să încerci să fugi iar, dar aluneci și cazi pe spate.
            //Și chiar atunci femeia cu păr negru aruncă prima lopată de pământ peste tine.",
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 9,
            //                        Decision = 'b',
            //                        Text = @"Ești convins că nu are cum să fie Mădălina/Grace așa că te întorci să fugi din nou. 
            //Nu reușești să faci decât câțiva pași și cazi într-o groapă proaspăt săpată.
            //Cu ochii lipiți nu îți dai seama cât de adâncă e și te lovești la coate și genunchi. Te ghemuiești într-un colț și îți ții respirația. 
            //Ochii te ustură, acolo unde au fost cusuți de limba femeii cu păr negru și respiri din ce în ce mai greu. Pieptul tău se simte greu, ca și cum ceva ar sta deasupra lui și l-ar apăsa.	
            //Arătarea a ajuns deasupra gropii și începe să râdă. Nu e un râs normal, ci cumva horcăit și poți simți din nou mirosul ei. Te ridici în picioare cu gândul să ieși de acolo și să încerci să fugi iar, dar aluneci și cazi pe spate.
            //Și chiar atunci femeia cu păr negru aruncă prima lopată de pământ peste tine.",
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 10,
            //                        Text = @"Simți pământul cum vine în valuri peste tine, dar nu ai cum sa îl oprești. Încerci fără succes să ieși din groapă, dar e prea adâncă și pământul e alunecos. Vrei să ţipi dar în continuare nu ai glas. Ochii îţi sunt lipiţi şi acolo unde pleoapele tale ating pielea obrazului simţi cum te arde. E agonie şi deodată tot ce îţi doreşti este să mori ca să scapi. 
            //Dar femeia cu părul negru are alte planuri pentru tine.

            //Groparii aruncă pământ peste sicriul din lemn lăcuit. Mădălina/Grace plânge și strigă „Trezește-te, oh, te rog, trezește-te! De ce nu se trezește?”

            //Mâinile ei reci te cuprind într-o îmbrățișare. Limba umflată îți linge obrazul. Pământul din jurul tău te ține imobilizat, ca și cum ai fi paralizat. Duhoarea te amețește, dar nu leșini.  
            //Femeia cu părul negru începe să își înfigă unghiile în carnea ta. Le simți cum apasă din ce în ce mai tare până când ele străpung pielea și ajung la os. Urli în gând.
            //Gura ți se umple de viermi. Îi simți zvârcolindu-se sub și pe limba ta. 
            //Simți că te apropii de nebunie și o aștepți cu nerăbdare.",
            //                        Final = true
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 10,
            //                        DecisionFunc = (decTaken) =>
            //                        {
            //                            return decTaken.Decisions.Count(d => d== 'b') > decTaken.DecisionsMade /2;
            //                        },
            //                        Text = @"Simți pământul cum vine în valuri peste tine, dar nu ai cum sa îl oprești. Încerci fără succes să ieși din groapă, dar e prea adâncă și pământul e alunecos. Vrei să ţipi dar în continuare nu ai glas. Ochii îţi sunt lipiţi şi acolo unde pleoapele tale ating pielea obrazului simţi cum te arde. E agonie şi tot ce îţi doreşti este să mori ca să scapi.
            //Apoi întinzi mâinile și atingi un material fin care pare așezat peste ceva tare. Îți tragi mâinile speriat, te lovești cu coatele de marginile sicriului și realizezi că nu mai e pământ peste tine, dar ești închis într-o cutie.

            //Groparii aruncă pământ peste sicriul din lemn lăcuit. Mădălina/Grace plânge și strigă „Trezește-te, oh, te rog, trezește-te! De ce nu se trezește?”

            //O auzi pe iubita ta și îți amintești ce s-a întâmplat și îți dai seama unde ești. 
            //Începi să bați cu pumnii in lemn și deodata glasul îți revine. Urli din toate puterile, pentru că de asta depinde viața ta. 
            //Ochii îți sunt în continuare lipiți, dar pumnii tăi lovesc în disperare capacul sicriului și țipi și țipi până când....
            //"
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 11,
            //                        Decision = 'a',
            //                        Text = @"Dar femeia cu părul negru are alte planuri pentru tine.

            //Mâinile ei reci te cuprind într-o îmbrățișare. Limba umflată îți linge obrazul. Pământul din jurul tău te ține imobilizat, ca și cum ai fi paralizat. Duhoarea te amețește, dar nu leșini.  
            //Femeia cu părul negru începe să își înfigă unghiile în carnea ta. Le simți cum apasă din ce în ce mai tare până când ele străpung pielea și ajung la os. Urli în gând.
            //Gura ți se umple de viermi. Îi simți zvârcolindu-se sub și pe limba ta. 
            //Simți că te apropii de nebunie și o aștepți cu nerăbdare."
            //                    },
            //                    new StoryChapter()
            //                    {
            //                        Number = 11,
            //                        Decision = 'b',
            //                        Text = @"Groparii se opresc din lucru. Unul dintre ei își face o cruce și se dă în spate câțiva pași.
            //Mădălina/Grace se aruncă în groapă și începe să tragă de capac. Ea strigă „E ÎN VIAȚĂ. E ÎN VIAȚĂ. CINEVA SĂ DESCHIDĂ SICRIUL ĂSTA NENOROCIT”.
            //Un bărbat găsește o rangă în roaba groparilor și sare lângă femeia care plânge. Înfige și trage cu putere de câteva ori până când reușește să smulgă capacul.

            //Deși ai ochii lipiți, lumina soarelui te face să vezi roșu. Simți căldura lui.
            //Și o auzi pe Mădălina/Grace. Îți simți mâinile fine pe față și apoi simți alte mâini puternice cum te apucă și te ridică din sicriu.

            //Părinții bărbatului din sicriu plâng și îi mulțumesc Dumnezeului lor pentru că nu au cerut îmbălsămare. Sunt fericiți și nici nu se mai întreabă cum e posibil să se întâmple așa ceva. Pentru ei e o minune cerească.

            //Ești îmbrățișat din toate părțile și știi că ai scăpat.
            //În groapă, femeia cu părul negru rânjește. Tu nu o vezi, dar ea întinde brațele către tine.
            //Și apoi, exact când crezi că ai visat totul, îi auzi vocea grotească:
            //„Te aștept. Mai ai puțin și vii înapoi la mine”"
            //                    }
            //                }
            //            };

            //            _stories.Add("RO", storyRo);

            var story = new Story
            {
                Language = "EN",
                Title = "The dream",
                Chapters = new[]
   {
                    new StoryChapter()
                    {
                        Number = 1,
                        Text =  @"It's dark. Nothing is visible. You hear the voice of a woman crying <i>""Wake up! wake up! Oh, my God, why is he not waking up?""</i> Her voice is hoarse, as if she wept a lot and you have the vague impression that you recognize it. Slowly, reality takes the place of the dream and you wake up. The first thing you see is the ceiling. Then you can feel the sheets of the bed wrinkled under your body, and you know the voice was just a dream. Now you're expecting a new morning. Stretching your hands and legs, you realize that your whole body is tired and numb as after a great effort. The window is open and a warm wind comes through it.",
                        SsmlText = @"It's dark. Nothing is visible. You hear the voice of a woman crying <voice name=""Emma"">""<prosody pitch=""x-high"" volume=""x-loud""><amazon:effect name=""whispered"">Wake up! wake up! Oh, my God, why is he not waking up?""</amazon:effect></prosody></voice> Her voice is hoarse, as if she wept a lot and you have the vague impression that you recognize it. Slowly, reality takes the place of the dream and you wake up. The first thing you see is the ceiling. Then you can feel the sheets of the bed wrinkled under your body, and you know the voice was just a dream. Now you're expecting a new morning. Stretching your hands and legs, you realize that your whole body is tired and numb as after a great effort. The window is open and a warm wind comes through it.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"you’re thinking back to the dream voice", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"you open the closet and dress up quickly", Color = "Green"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 2,
                        DecisionFunc = (decTaken) => decTaken.Get(1) == 'a',
                        Text = @"You think again of the dream voice. You surely dreamed someone you knew. There was a woman's voice full of pain. Who could have been? Without any reason, you remember Grace. The girl with long legs and blue eyes that you love. Where is she? She should have been here in bed beside you, but nothing of her is where it should have been. No dress thrown in the room, no cream box on the table next to the bed, not even her fragrance of lemon and roses that you like so much. The cloth you're wrapped in moves slightly where her body should have been in bed. Or did you just imagine?",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"you touch the blanket", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"you think that the wind coming through the window moved the blanket", Color = "Green"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 3,
                        DecisionFunc = (decTaken) => decTaken.Get(1) == 'a' && decTaken.Get(2) == 'a',
                        Text = @"When your fingers touch the blanket, something moves underneath. Scared, you withdraw your hand and your breathing intensifies. You close your eyes for two seconds and breath in, then you open them back. 
	The blanket took the shape of a human being. Without thinking too much, you pull it off and take it aside. You expect the worst. In a fraction of a second you get through a sequence of a classic horror movie. The main character is in the bed, hiding under the sheets from a creature, and when he lifts the blanket he sees the monstrosity there. He sees its dark eyes hidden from its hair, he feels its breathing.
	And yet there is nothing in your bed. Probably the wind moved the blanket and then you imagined it. Yes, that must be it. You imagined that you felt and saw a body there. You probably miss Grace so much.
Suddenly, you really want to keep her in your arms and hold her to your chest. You need her touch, you need to feel her smell and walk your hand through her hair. You need to make love with her.
With an effort, you head for the bathroom. There you lean forward to wash your face and when you get up you see the same tired face in the mirror. Only this time your eyes are shut and your eyelids are purple. Then the image returns. It's just a mirror and there you are. Surely you just imagined."
                    },
                    new StoryChapter()
                    {
                        Number = 3,
                        DecisionFunc = (decTaken) => decTaken.Get(1) == 'a' && decTaken.Get(2) == 'b',
                        Text = @"You are tired, because last night you drank a lot and don’t really remember why. You ignore the blanket and get out of bed. Your legs are uncomfortable, but you force them to touch the carpet. 
Behind you, under the blanket, a black-haired woman stands up. You do not see her and she doesn’t seem to see you either. You're back to back. You get up and go to the bathroom. When you turn around to the room to close the door, the woman is no longer there. You didn’t even noticed it.
You lean forward to wash your face and when you get up you see the same tired face in the mirror. Only this time your eyes are shut and your eyelids are purple. Then the image returns. It's just a mirror and there you are. Surely you just imagined."
                    },
                    new StoryChapter()
                    {
                        Number = 2,
                        DecisionFunc = (decTaken) => decTaken.Get(1) == 'b',
                        Text = @"You open the closet and get dressed quickly. A pair of jeans and a t-shirt are your regular outfit. You reach your hand between your clothes hanging there because you know your belt has to be somewhere in there. Your fingers touch something cold and wet.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"you put the clothes to one side and look to see what you have touched", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"you ignore what you felt, surely your fingers touched the metal bar that supports the hangers", Color = "Green"}
                        }
                    },
                      new StoryChapter()
                    {
                        Number = 3,
                        DecisionFunc = (decTaken) => decTaken.Get(1) == 'b' && decTaken.Get(2) == 'a',
                        Text = @"Trembling, you stretch your hands to the clothes and separate the black shirt from the striped shirt and you look. There's nothing there, it's just the wardrobe, as it should be. So you look for the belt again. At some point, you touch that cold and wet thing again and you realize it's flesh. You throw down all your t-shirts, shirts and trousers, but nothing is there. The wardrobe is still empty. You think you're tired, so you turn your back to the closet and finally see the belt in the pile of clothes that’s laying on the floor.
You bend to get it out of there, and then a woman appears behind you. She stays bent and her hair falls on her face. You do not see her as she approaches you. Her hands are stretched to your shoulders. Just before she touches you, you go to the bathroom. There you look in the mirror and you do not recognize yourself. The skin from your face is whiter and you have dark circles under your eyes. You lean forward to wash your face and when you get up you see the same tired face in the mirror. Only this time your eyes are shut and your eyelids are purple. Then the image returns. It's just a mirror and there you are. Surely you just imagined."
                    },
                    new StoryChapter()
                    {
                        Number = 3,
                        DecisionFunc = (decTaken) => decTaken.Get(1) == 'b' && decTaken.Get(2) == 'b',
                        Text = @"You stretch out your hand to look for a belt, but you can’t find it. You look through your clothes without success, then start to throw them down, nervous and tired. The belt is nowhere to be found so you turn your back to the closet and there it is, in the pile of clothes that lay now on the floor.
You bend to get it out of there, and then a woman appears behind you. She stays hunched and her hair falls on her face. You do not see her as she approaches you. Her hands are stretching to touch your shoulders, but just before she can do that, you head towards the bathroom. There you look in the mirror and you do not recognize yourself. The skin from your face is pale and you have dark circles under your eyes. You lean forward to wash your face and when you get up you see the same tired face in the mirror. Only this time your eyes are shut and your eyelids are purple.
Then the image returns. It's just a mirror and there you are. Surely you just imagined.
"
                    },
                    new StoryChapter()
                    {
                        Number = 4,
                        Text = @"Finally outside. The wind blows softly like in the spring and the sun is warm. It's empty. No being. No man, no animal, no life to haunt the dusty street, only the wind that plays like a small tornado with the garbage on the ground.
You suddenly feel a fierce desire to see your lover, so you start walking towards her home.
When you get there, you look at the building and realize you have the key to it. She gave it to you a few days ago when she told you that whenever you want or whatever you need, you should be able to come anytime.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"you take the key from your pocket and you enter the apartment", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"it would be odd that in the first hour of the morning, out of the blue, you would enter your friend's house", Color = "Green"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 5,
                        DecisionFunc = (decTaken) => decTaken.Get(4) == 'a',
                        Text = @"You take the key from your pocket and enter the apartment You take your shoes off carefully not to wake her up. Then you sit on the vinyl chair by the bed and watch her sleep. She is beautiful. She has black hair and, behind her closed eyelids, her eyes are blue like the ocean. You remember her smile as if it were a distant remnant, a fragment of memory, like a picture of something that was and will not be anymore.
Grace moves slightly under the transparent sheet and makes you sigh of pleasure and stretch towards her. You touch her gently on her neck, breasts and thighs, then you sink back into the armchair, wondering why didn’t she wake up.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"you bend again and kiss her, trying to wake her up", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"you’re afraid not to scare her if she wakes up and sees you in her room, so you leave the apartment as fast as you got in." , Color = "Green"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 6,
                        DecisionFunc = (decTaken) => decTaken.Get(4) == 'a' &&  decTaken.Get(5) == 'a',
                        Text = @"You lean and kiss her, trying to wake her up, but she turns back to you and continues to sleep. You feel how much you love her, how much joy she brings with her smile, and now you want more than ever to see it so you touch her hair gently. Your hands are slipping on her back, to the firm butt you like so much to play with. You're horny. You sit in bed and take her in your arms. Your left palm slightly touches a breast with a hard nipple. You push your erection against her, and you take deep breaths into your chest with your eyes closed.
But instead of her perfume, you smell rotting flesh. Like when your mother threw those chicken tights in the garbage bin but forgot to take it out. After two days, they began to rot and your mother had to throw the bin altogether and buy a new one because the stench was impregnated in the plastic.
And now, with your eyes closed and your arms holding your lover, you feel the same smell. You open your eyes exactly in the same second when you feel her turning back to you. Instinctively, you pull yourself back, with your eyes fixed on her head.
And then you see.
The woman's purple face is bubbling with liquid, and her eyes are grotesque in orbit. Her wrinkled mouth has black teeth, where they have not yet fallen. And it smells so strong that you gag without even realizing it.
You throw yourself from the bed and fall on your back into the chair.
You want to get up, but somehow your skin sticks to the red vinyl and starts to sizzle. You feel your back burning. You're trying to lift your hands, but they seem stuck there with the strongest glue. Meanwhile, the woman with black hair and purple face rises out of bed and approaches you.
You open your lips to scream, but there's no sound. The whole body, where it touches the armchair, hurts. It's a pain that is getting stronger. Soon it will become agony, but you cannot take your eyes off the approaching woman somehow.
You fight to scream again, but the sounds come out quietly and your arms rip from the red handles. Your skin looks like a chewing gum and breaks. You think you’re going to lose your consciousness, but that would be a good luck that you do not have.
The woman is already a few inches away from your face. The stink is unbearable. You attempt to push her, but you fail. The woman pulls out a swollen black tongue and licks your eyes. Your eyelids shut down instinctively, but you feel all the pores of her tongue, and then a sharp pain stings you under the eyes, where your eyelids touch the cheeks.
You do not feel her tongue anymore, but you can’t know for sure if it's not there anymore, because at this moment you can only focus on pain. It's a pain that plays with reality and you wonder how and why it's possible.
You jump from the chair, with the eyes that you do not seem to be able to untie, with your skin hanging and bleeding on your arms and your mouth in a roar that you cannot articulate."
                    },
                    new StoryChapter()
                    {
                        Number = 6,
                        DecisionFunc = (decTaken) => decTaken.Get(4) == 'a' &&  decTaken.Get(5) == 'b',
                        Text = @"You're afraid of scaring her (what would she think if she wakes up and she sees you in her room?), so you get out of the apartment as quickly as you walked in. You think a walk through the park will do you well, will help you put your thoughts in order.
When you go through the iron gate, a light wind touches your face and you enjoy feeling it. It's empty, there’s nobody there and now you realize that since you left your own apartment you haven’t seen anyone, and that's at least strange.
Trees move in the wind. You look at them and  they seem to relax you, so you decide to sit down.
You find a small one-person bench with wrought iron handles near an old willow. It's comfortable here. You let your head rest and look at the branches as they wave. Then you close your eyes and take a deep breath, but instead of the clean air of the morning, you smell rotting flesh. Like when your mother threw those chicken tights in the garbage bin but forgot to take it out. After two days, they began to rot and your mother had to throw the bin altogether and buy a new one because the stench was impregnated in the plastic
And then you see.
The woman's purple face is bubbling with liquid, and her eyes are grotesque in orbit. Her wrinkled mouth has black teeth, where they have not yet fallen. And it smells so strong that you gag without even realizing it.
You want to get up, but somehow your skin sticks to the iron and starts to sizzle. You feel your back burning. You're trying to lift your hands, but they seem stuck there with the strongest glue. Meanwhile, the woman with black hair and purple face approaches you.
You open your lips to scream, but there's no sound. The whole body, where it touches the bench, hurts. It's a pain that is getting stronger. Soon it will become agony, but you cannot take your eyes off the approaching woman somehow.
You fight to scream again, but the sounds come out quietly and your arms rip from the handles. Your skin looks like a chewing gum after it breaks. You think you’re going to lose your consciousness, but that would be a good luck that you do not have.
The woman is already a few inches away from your face. The stink is unbearable. You attempt to push her, but you fail. The woman pulls out a swollen black tongue and licks your eyes. Your eyelids shut down instinctively, but you feel all the pores of her tongue, and then a sharp pain stings you under the eyes, where your eyelids touch the cheeks.
You do not feel her tongue anymore, but you can’t know for sure if it's not there anymore, because at this moment you can only focus on pain. It's a pain that plays with reality and you wonder how and why it's possible.
You jump off the bench, with the eyes that you do not seem to be able to untie, with your skin hanging and bleeding on your arms and your mouth in a roar that you cannot articulate."
                    },
                    new StoryChapter()
                    {
                        Number = 5,
                        DecisionFunc = (decTaken) => decTaken.Get(4) == 'b',
                        Text = @"You look at the building and see that her bedroom window is open. You take a deep breath and decide that a walk through the park will do well, will help put your thoughts in order.
When you go through the iron gate, a light wind touches your face and you enjoy feeling it. The park it's empty, there’s nobody there and now you realize that since you left your own apartment you haven’t seen anyone, and that's strange.
Trees move in the wind. You look at them and they seem to relax you. Near an old willow, there is a small one-person bench with wrought iron handles.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"you sit on the bench", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"you don’t want to sit, so you continue your walk", Color  = "Green" }
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 6,
                        DecisionFunc = (decTaken) => decTaken.Get(4) == 'b' &&  decTaken.Get(5) == 'a',
                        Text = @"You sit on the bench. It's comfortable here. You let your head rest and look at the branches as they wave. Then you close your eyes and take a deep breath, but instead of the clean air of the morning, you smell rotting flesh. Like when your mother threw those chicken tights in the garbage bin but forgot to take it out. After two days, they began to rot and your mother had to throw the bin altogether and buy a new one because the stench was impregnated in the plastic
And then you see.
The woman's purple face is bubbling with liquid, and her eyes are grotesque in orbit. Her wrinkled mouth has black teeth, where they have not yet fallen. And it smells so strong that you gag without even realizing it.
You want to get up, but somehow your skin sticks to the iron and starts to sizzle. You feel your back burning. You're trying to lift your hands, but they seem stuck there with the strongest glue. Meanwhile, the woman with black hair and purple face approaches you.
You open your lips to scream, but there's no sound. The whole body, where it touches the bench, hurts. It's a pain that is getting stronger. Soon it will become agony, but you cannot take your eyes off the approaching woman somehow.
You fight to scream again, but the sounds come out quietly and your arms rip from the handles. Your skin looks like a chewing gum after it breaks. You think you’re going to lose your consciousness, but that would be a good luck that you do not have.
The woman is already a few inches away from your face. The stink is unbearable. You attempt to push her, but you fail. The woman pulls out a swollen black tongue and licks your eyes. Your eyelids shut down instinctively, but you feel all the pores of her tongue, and then a sharp pain stings you under the eyes, where your eyelids touch the cheeks.
You do not feel her tongue anymore, but you can’t know for sure if it's not there anymore, because at this moment you can only focus on pain. It's a pain that plays with reality and you wonder how and why it's possible.
You jump off the bench, with the eyes that you do not seem to be able to untie, with your skin hanging and bleeding on your arms and your mouth in a roar that you cannot articulate.",
                    },
                    new StoryChapter()
                    {
                        Number = 6,
                        DecisionFunc = (decTaken) => decTaken.Get(4) == 'b' &&  decTaken.Get(5) == 'b',
                        Text = @"You ignore the bench and decide to go further. It's nice to walk around. You like the smell of clean air and freshly cut grass. You’ve almost reached the fountain.
When you finally get there, you look at the statue of two little children who pour water from one jug to another. You sit on the edge and put a hand in the fountain. The water it's cool and you can see lots of coins on the bottom. You close your eyes and enjoy the sensation.
But instead of grass and water, now it smells like rotten flesh. Like when your mother threw those chicken tights in the garbage bin but forgot to take it out. After two days, they began to rot and your mother had to throw the bin altogether and buy a new one because the stench was impregnated in the plastic
And then you see.
The woman's purple face is bubbling with liquid, and her eyes are grotesque in orbit. Her wrinkled mouth has black teeth, where they have not yet fallen. And it stinks so strong that you gag without even realizing it.
You want to get up, but somehow your skin starts to sizzle and it's stuck to the cold fountain. You feel a burning sensation. You're trying to lift your hands, but you seem unabled to do so. Meanwhile, the woman with black hair and purple face approaches you.
You open your mouth to scream, but there's no sound. The whole body, where it touches the fountain, hurts. The sharp pain that is getting stronger. Soon it will become agony, but somehow you can't take your eyes off the approaching woman.
You try to scream again, but the sounds come out quietly and your hands rip from the stone. Your skin looks like dangling chewing gum. You think you’re going to lose your consciousness, but you are not that lucky.
The woman is already a few inches away from your face. The stench is unbearable. You attempt to push her away, but you fail. The woman stucks out a swollen black tongue and licks your eyes. Your eyes shut instinctively, but you feel all the pores of her tongue, and then a sharp pain stings you beneath the eyes, where your eyelashes touch the cheeks.
You don't feel her tongue anymore, but you can’t know for sure if it's there anymore, because at this moment you can only focus on pain. It's a pain that plays with reality and you wonder how and why it's possible.
You jump off the fountain. You can't open your eyes and your skin is hanging and bleeding on your arms. You wan't to scream but you can't",
                    },
                    new StoryChapter()
                    {
                        Number = 7,
                        Text = @"<i>The old man is accustomed to his work. He sews the dead man's eyelids with skill, without using force, as if he takes care of a very expensive doll. He then uses perfume and wonders what he would look like on the old marble table.</i>",
                    },
                   new StoryChapter()
                   {
                       Number = 8,
                       Text = @"You managed to escape and now you are running. Suddenly you are no longer where you were but somewhere else. Your legs are moving fast, your adrenaline has filled your body, but behind you the black-haired thing is whistling. She wants to get you in her rotten arms and keep you there forever. You know that, so you run as fast as you can because you're aware that if she catches you, you're lost forever. With your eyelids sewn and screaming without any sound coming out from your mouth, you run.
            ",
                       Decisions = new[]
                       {
                           new StoryChapterDecision() { Decision = 'a', Text = @"You keep on running", Color = "Red"},
                           new StoryChapterDecision() { Decision = 'b',Text = @"You turn around, determined to confront her.", Color = "Green"}
                       }
                   },
                    new StoryChapter()
                    {
                        Number = 9,
                        DecisionFunc = (decTaken) => decTaken.Get(8) == 'a',
                        Text = @"You run further until you get to a cemetery. A thought goes through your mind: how is that possible? Then you hit a funeral stone and when you touch it slightly with your fingers, you can feel the writing there, the name of the past. You continue running, this time much slower, with your hands outstretched. At some point, you stop instinctively. With one of your feet you touch the ground in front of you. One step, then one more, until you reach a newly excavated pit. You can’t see it, but you feel the gap.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"You hide in the pit.", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"You keep on running.", Color = "Green"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 10,
                        DecisionFunc = (decTaken) => decTaken.Get(8) == 'a' && decTaken.Get(9) == 'a',
                        Text = @"You decide to hide in the pit. But when you jump in it, you hit your elbows and knees. You didn’t expect to be so deep. You crumble in a corner and try to breath without making any sound.
	Your eyes hurt, where they have been sewn by the tongue of that black-haired thing and you notice that you are breathing harder. Your chest feels heavy, as if something is on top of it.
	That black-haired thing reached the pit and now is gazing upon you from up there. She starts laughing but is not a normal laugh. Somehow, it's snorting and you can feel her stench again. You get up thinking about how to get out of there and to run again, but when you try to climb up, you slip and fall on your back.
	And then the black-haired thing throws the first earth shovel over you.",
                    },
                    new StoryChapter()
                    {
                        Number = 10,
                        DecisionFunc = (decTaken) => decTaken.Get(8) == 'a' && decTaken.Get(9) == 'b',
                        Text = @"You go around the pit and continue to run with your hands still stretched. Just when you start wondering how is it that you haven’t trip, you fall into another pit, that you didn’t notice this time.
	With your eyes sewn, you do not realize how deep it is and you hit your elbows and knees. You crumble into a corner and try to breath without making any sound.
	Your eyes hurt, where they have been sewn by the tongue of that black-haired thing and you notice that you are breathing harder. Your chest feels heavy, as if something is on top of it.
	That black-haired thing reached the pit and now is gazing upon you from up there. She starts laughing but is not a normal laugh. Somehow, it's snorting and you can feel her stench again. You get up thinking about how to get out of there and how to run again, but when you try to climb up, you slip and fall on your back.
	And then the black-haired thing throws the first dirt shovel over you.",
                    },
                                       new StoryChapter()
                    {
                        Number = 9,
                        DecisionFunc = (decTaken) => decTaken.Get(8) == 'b',
                        Text = @"Determined to confront her, you suddenly stop and turn around, facing her and hopping to get rid of her one way or the other. But instead of rotten flesh, you smell Grace’s perfume.
	And for the moment you don’t understand what's going on so you don’t move. Then you start to actually hear her and soon her gentle voice, drowned in crying, tells you to <i>""wake up, oh, please, wake up""</i>.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"You stretch your arms to touch Grace", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"You start running again, convinced that is couldn’t be Grace" , Color = "Green"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 10,
                        DecisionFunc = (decTaken) => decTaken.Get(8) == 'b' && decTaken.Get(9) == 'a',
                        Text = @"Because you really want to touch her once again, you start stretching out your arms, but instead of Grace’s fine skin that you love so much, you feel cold and dead meat. The black-haired thing grabs your hands an keeps them in a strong hold, next to her putrid chest.
	You pull yourself away, but you fell directly into a dug pit that you couldn’t have known it was there.
	With your eyes sewn, you do not realize how deep it is and you hit your elbows and knees. You crumble into a corner and try to breath without making any sound.
	Your eyes hurt, where they have been sewn by the tongue of that black-haired thing and you notice that you are breathing harder. Your chest feels heavy, as if something is on top of it.
	That black-haired thing reached the pit and now is gazing upon you from up there. She starts laughing but is not a normal laugh. Somehow, it's snorting and you can feel her stench again. You get up thinking about how to get out of there and how to run again, but when you try to climb up, you slip and fall on your back.
	And then the black-haired thing throws the first dirt shovel over you.",
                    },
                    new StoryChapter()
                    {
                        Number = 10,
                        DecisionFunc = (decTaken) => decTaken.Get(8) == 'b' && decTaken.Get(9) == 'b',
                        Text = @"You’re convinced that it can’t be Grace so you turn around and start running again, but not for long.
	After just a few steps, you fell into a dug pit that you couldn’t have known it was there.
	With your eyes sewn, you do not realize how deep it is and you hit your elbows and knees. You crumble into a corner and try to breath without making any sound.
	Your eyes hurt, where they have been sewn by the tongue of that black-haired thing and you notice that you are breathing harder. Your chest feels heavy, as if something is on top of it.
	That black-haired thing reached the pit and now is gazing upon you. It starts laughing but it's not a normal laugh. Somehow, it's snorting and you can feel her stench again. You get up thinking about how to get out of there and how to run again, but when you try to climb up, you slip and fall on your back.
	And then the black-haired thing throws the first dirt shovel over you.",
                    },
                    new StoryChapter()
                    {
                        Number = 11,
                        Text = @"You can feel the dirt coming in waves over you, but you can’t stop it. You try to get out of the pit without success, it's too deep, and the earth is slippery. You want to scream, but you still don’t have a voice. Your eyes are glued and where your eyelids touch the skin of your cheek, it burns. It's agony and suddenly everything you want is to die to get rid of it.
	But the black-haired thing has other plans for you.

	<i>Gravediggers throw earth over the lacquered coffin. Grace cries and shouts ""Wake up, oh, please, wake up! Why is he not waking up? ""</i>

	Her cold hands hold you in a hug. The swollen tongue licks your cheek. The earth around you keeps you immobile, as though you were paralyzed. The stink makes you dizzy, but you don’t faint.
	The black-haired thing starts to dig your nails into your flesh. You feel them pushing harder until they break through the skin and get to the bone. You scream in your mind. 
	Your mouth is filled with worms. 
	You think you’re getting close to madness and you are looking forward to it.",
                        Final = true
                    },
                    new StoryChapter()
                    {
                        Number = 11,
                        DecisionFunc = (decTaken) =>
                        {
                            return decTaken.Decisions.Count(d => d== 'b') > decTaken.DecisionsMade /2;
                        },
                        Text = @"You feel the dirt coming in waves over you, but you can’t stop it. You try to get out of the pit without success. It’s too deep and slippery. You want to scream, but you still don’t have a voice. Your eyes are glued and where your eyelashes touch the skin of your cheek, it burns. It’s agony, and all you want is to die to get rid of it.
	Then… you stretch out your arms and touch a fine material that seems to be holding something hard. Scared, you pull back your hands and that’s when you hit your elbows on the edges of the coffin and you realize there’s no more dirt on you, but you’re locked in a box.
	<i>Gravediggers throw ground over the lacquered coffin. Grace cries and shouts ""Wake up, oh, please, wake up! Why is he not waking up?""</i>
	You can hear your girlfriend and, suddently, you remember what happened and you know where you are. So you start punching the wood and suddenly your voice returns.You scream from the top of your lungs, because your life depends on it.
	Your eyes are still stuck together, but your fists strike the lid of the coffin desperately and you scream and scream until…"
                    },
                    new StoryChapter()
                    {
                        Number = 12,
                        Text = @"<i>The gravediggers stop working. One of them makes the sign of the cross and takes a few steps back.</i>
	<i>Grace drops into the pit and tries to pull off the lid. She shouts, ""He's alive! He's alive! Someone open this fucking coffin!""</i>
	<i>A man finds a ranch and jumps in the pit, next to the weeping woman. He sticks it underneath the lid and pulls hard a few times until he manages to take it off.</i>
	Although your eyes are glued, sunlight makes you see red. And you can feel its warmth.
    You hear Grace and you can feel her hands on your face. They are soft and warm. Then some other strong hands are grabbing and lifting you out of the coffin.
	<i>The men’s parents are weeping and thank their God they didn't ask for embalming. They are happy and don’t even wonder how this could be possible. For them, this is a heavenly miracle.</i>
	You are embraced from all sides and you know you have escaped.
    ...
	In the pit, the black-haired thing is grinning. You do not see her, but she stretches her arms at you.
	And then, just when you think you’ve dreamed it all, you hear her grotesque voice, talking inside of your head:
	<i><b>""I'm waiting for you. You have a little more left and then you’ll come back to me ""</b></i>"
                    }
                }
            };

            _stories.Add(story);
        }

        public static Story GetStory(string language, string title)
        {
            return _stories.FirstOrDefault(d => string.Equals(d.Language, language, StringComparison.InvariantCultureIgnoreCase) && string.Equals(d.Title, title, StringComparison.InvariantCultureIgnoreCase));
        }

        public static string[] GetStories()
        {
            return _stories.Select(d => d.Title).ToArray();
        }


    }
}

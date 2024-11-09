using System;
using StoryTeller.Model;

namespace StoryTeller.Logic
{
    public class StoryFactory
    {
        public static Story GetStory()
        {
            var story = new Story
            {
                Title = "Visul",
                Chapters = new[]
                {
                    new StoryChapter()
                    {
                        Number = 1,
                        Text = @"E întuneric. Nimic nu e vizibil. Auzi vocea unei femei care strigă Trezește-te, trezește-te, Oh, Doamne, de ce nu se trezește? Glasul ei e răgușit, ca și cum ar fi plâns mult și ai impresia vagă că îl recunoști. Cu greu, realitatea ia locul visului și te trezești. Primul lucru pe care îl vezi este tavanul. Apoi simți așternuturile patului șifonate sub corpul tău și te gândești că vocea era doar un vis, iar acum te așteaptă o nouă dimineață. Îți întinzi mâinile și picioarele și realizezi că tot corpul tău e obosit și amorțit ca după un efort foarte mare. Geamul este deschis și prin el intră ușor un vânt cald.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"te gândești din nou la vocea din vis", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"deschizi dulapul și te îmbraci rapid", Color = "Blue"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 2,
                        Decision = 'a',
                        Text = @"Te gândești din nou la vocea din vis. Cu siguranță ai visat pe cineva cunoscut. Era un glas de femeie plin de durere. Cine ar fi putut să fie? Fără nici o legătură, îți aduci aminte de Mădălina/Grace. Fata cu picioare lungi și ochi albaștri pe care o iubești. Unde este ea? Ar fi trebuit să fie aici, în pat, lângă tine, dar nimic de al ei nu e unde ar fi trebuit să fie. Nici o rochie aruncată prin cameră, nici o cutie de cremă pe masa de lângă pat, nici măcar parfumul ei de lămâie și trandafiri care îți place atât de mult. Pătura cu care ești învelit se mișcă ușor acolo unde ar fi trebuit să fie corpul ei întins în pat. Sau doar ți-ai imaginat?",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"întinzi mâna și atingi pătura", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"te gândești că vântul care intră pe geam a mișcat pătura", Color = "Blue"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 3,
                        Decision = 'a',
                        Text = @"Exact în secunda în care degetele tale ating pătura, ceva se mișcă dedesubt. Îți retragi mâna speriat și respirația ți se intensifică. Închizi ochii pentru două secunde și tragi aer în piept, apoi îi deschizi. Pătura a luat forma unui om. Fără să te gândești prea mult, tragi de ea și o dai la o parte. Te aștepți la tot ce e mai rău. Într-o fracțiune de secundă îți trece prin cap o secvență dintr-un film horror classic. Personajul principal e în pat, se acunde sub cearșafuri de o arătare, iar în secunda în care ridică pătura vede monstruozitatea acolo. Îi vede ochii negri ascunși de păr, îi simte respirația.
Și totuși în patul tău nu e nimic. Probabil vântul a mișcat pătura și apoi ți-ai imaginat. Da, asta trebuie să fie. Ți-ai imaginat că simți și vezi acolo un corp. Probabil îți este foarte dor de Mădălina/Grace și atât. 
Deodată, îți dorești foarte mult să o ții în brațe și să o strângi la piept. Ai nevoie de atingerea ei, ai nevoie să îi simți mirosul și să îți plimbi mâna prin părul ei. Ai nevoie să faci dragoste cu ea.
Faci un efort şi te îndrepţi către baie. Acolo te apleci să te speli pe față și, când te ridici, în oglindă vezi aceeași față obosită. Numai că de data asta ochii tăi sunt închiși și pleoapele tale sunt mov. Apoi imaginea își revine. E doar o oglindă și acolo ești tu. Cu siguranță doar ți-ai imaginat."
                    },
                    new StoryChapter()
                    {
                        Number = 3,
                        Decision = 'b',
                        Text = @"Ești obosit. Știi că seara trecută ai băut cam mult și nu îți prea aduci aminte de ce. Ignori pătura și te ridici din pat. Picioarele îți trosnesc nemulțumite, dar le obligi să atingă covorul. În spatele tău, de sub pătură, se ridică o femeie cu părul negru. Nu o vezi, dar nici ea nu pare că te vede. Sunteți spate în spate. Te ridici și te duci către baie. Când te întorci către cameră să închizi ușa, femeia nu mai este acolo. Nici măcar nu ai observat-o.
Te apleci să te speli pe față și, când te ridici, în oglindă vezi aceeași față obosită. Numai că de data asta ochii tăi sunt închiși și pleoapele tale sunt mov. Apoi imaginea își revine. E doar o oglindă și acolo ești tu. Cu siguranță doar ți-ai imaginat."
                    },
                    new StoryChapter()
                    {
                        Number = 2,
                        Decision = 'b',
                        Text = @"Deschizi dulapul și te îmbraci rapid. O pereche de blugi și un tricou oarecare sunt ținuta zilnică. Bagi mâna printre hainele atârnate pe umeraşe pentru că ştii că undeva trebuie să fie o curea. Degetele tale ating ceva rece şi umed.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"dai hainele la o parte şi cauţi să vezi ce ai atins", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"ignori ce ai simţit, cu siguranţă degetele tale au atins bara de metal care susţine umeraşele", Color = "Blue"}
                        }
                    },
                      new StoryChapter()
                    {
                        Number = 3,
                        Decision = 'a',
                        Text = @"Întinzi mâna tremurând către haine. Cu ambele mâini separi tricoul negru de cămaşa cu dungi şi te uiţi. Nu e nimic acolo, e doar dulapul, aşa cum trebuie el să fie. Oftezi şi cauţi încă  odată cureaua. La un moment dat atingi iar acel ceva rece şi umed şi realizezi că e carne. Smulgi şi arunci pe jos toate tricourile, cămăşile şi pantalonii. Dulapul e gol în continuare. Te gândeşti că eşti obosit, aşa că te întorci cu spatele la dulap şi în sfârşit vezi cureaua în maldărul de pe jos. 
Te apleci să o iei de acolo şi chiar atunci apare în spatele tău o femeie. Ea stă aplecată şi părul îi cade pe faţă. Tu nu o vezi în timp ce ea se apropie de tine. Mâinile ei se intind către umerii tăi. Chiar înainte să te atingă, te îndrepţi căte baie. Acolo te uiți în oglindă și nu te recunoști. Pielea feței tale e mai albă și ai cearcăne adânci sub ochi. Te apleci să te speli și, când te ridici, în oglindă vezi aceeași față obosită. Numai că de data asta ochii tăi sunt închiși și pleoapele tale sunt mov. Apoi imaginea își revine. E doar o oglindă și acolo ești tu. Cu siguranță doar ți-ai imaginat."
                    },
                    new StoryChapter()
                    {
                        Number = 3,
                        Decision = 'b',
                        Text = @"Întinzi mâna să îţi cauţi o curea, dar nu reuşeşti să o găseşti. Cauţi printre haine fără success, apoi începi să le arunci pe jos, nervos şi obosit. Cureaua nu e de găsit aşa că te întorci cu spatele la dulap şi chiar atunci o vezi între cămăşi, tricouri şi pantaloni. Te apleci să o iei şi chiar atunci apare în spatele tău o femeie. Ea stă aplecată şi părul îi cade pe faţă. Tu nu o vezi în timp ce ea se apropie de tine. Mâinile ei se intind către umerii tăi. Chiar înainte să te atingă, te îndrepţi căte baie. Acolo te uiți în oglindă și nu te recunoști. Pielea feței tale e mai albă și ai cearcăne adânci sub ochi. Te apleci să te speli și, când te ridici, în oglindă vezi aceeași față obosită. Numai că de data asta ochii tăi sunt închiși și pleoapele tale sunt mov. Apoi imaginea își revine. E doar o oglindă și acolo ești tu. Cu siguranță doar ți-ai imaginat."
                    },
                    new StoryChapter()
                    {
                        Number = 4,
                        Text = @"Afară în sfârșit. Vântul adie uşor a primăvară şi soarele îți mângâie faţa. În rest, gol. Nicio fiinţă. Niciun om, niciun câine, nicio vietate care să bântuie strada prăfuită, doar vântul care se joacă de-a tornada cu gunoaiele aruncate aiurea pe jos şi soarele plictisit ţinându-i de urât. 
Simţi brusc o dorinţă aprigă de a-ți vedea iubita, aşa că începi să mergi către casa ei.
Când ajungi, privești fațada clădirii și realizezi că ai cheia de la ea. Ți-a dat-o acum câteva zile, când ți-a spus că oricând îți vei dori, vei putea să te autoinviți.
",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"scoți cheia din buzunar și intrii", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"ar fi ciudat ca la prima oră a dimineții, din senin, să intrii în casa prietenei tale", Color = "Blue"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 5,
                        Decision = 'a',
                        Text = @"Scoți cheia din buzunar și intrii. Te descalți cu grijă să nu o trezești. Te așezi pe fotoliul din vinilin de lângă pat și o privești cum doarme. E frumoasă. Are părul negru şi ochii, pe care nu poți să îi vezi acum, sunt albaștri. Îți aduci aminte de zâmbetul ei de parcă ar fi ceva îndepărtat, ca un fragment de amintire, ca o imagine a ceva ce a fost şi nu o să mai fie.
	Mădălina/Grace se mişcă uşor pe sub cearşaful transparent și te face să suspini de plăcere şi să te întinzi spre ea. O atingi uşor pe gât, pe sâni şi pe coapse, apoi te trânteşti la loc în fotoliu, mirându-te că nu ai trezit-o.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"te apleci și o săruți, încercând să o trezești", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"ți-e frică să nu se sperie dacă se trezește și te vede în camera ei așa că ieși din apartament la fel de ușor cum ai intrat" , Color = "Blue"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 6,
                        Decision = 'a',
                        Text = @"Te apleci și o săruți, încercând să o trezești, dar ea se întoarce cu spatele la tine și continuă să doarmă. Simți cât de mult o iubești, câtă bucurie îți aduce zâmbetul ei și vrei acum mai mult ca niciodată să îl vezi așa că o mângâi ușor pe păr. Mâinile îți alunecă pe spatele ei, către fundul ferm cu care îți place atât de mult să te joci. Ești excitat. Te așezi în pat în spatele ei și o cuprinzi în brațe. Palma ta stângă îi atinge ușor un sân cu sfârc tare. Îți impingi erecția în ea și tragi adânc aer în piept cu ochii închiși. 
Dar în loc de parfumul ei simți miros de carne stricată. Ca atunci când mama ta a aruncat pulpele alea de pui expirate la coș, dar a uitat să ducă gunoiul. După două zile au început să putrezească și mama ta a fost nevoită să arunce coșul cu totul și să cumpere unul nou pentru că duhoarea se impregnase în plastic.	
Iar acum, cu ochii închiși și brațele cuprinzând-o pe iubita ta, simți același miros. Deschizi ochii exact în clipa în care o simți cum se întoarce către tine. Instinctiv, te tragi mai în spate, cu privirea fixată către capul ei. 
Și apoi vezi.
Pe fața mov a femeii sunt bube cu lichid, iar ochii îi ies grotesc de mult din orbite. Gura ei căscată are dinți negri, acolo unde ei încă nu au căzut. Și pute atât de puternic încat icnești fară să îți dai seama.
Te arunci din pat stângaci și cazi în fund pe fotoliul din spate.
Vrei să te ridici, dar cumva pielea ta se lipește de vinilinul roșu și începe să sfârâie. Simți cum te arde spatele. Încerci să îți dezlipești palmele de mânere, dar ele par lipite acolo cu cel mai puternic adeziv. Între timp, femeia cu părul negru și față mov se ridică din pat și se apropie de tine.
Deschizi buzele să țipi, dar nu iese niciun sunet. Tot corpul, acolo unde atinge fotoliul, ustură. E o durere ce devine din ce în ce mai puternică. În curând va deveni agonie, dar tu nu îți poți dezlipi privirea de la femeia care se apropie cumva plutind.
Te zbați și încerci încă odată să urli. Din  gâtul tău iese liniște, dar brațele tale se desprind de mânerele roșii. Pielea ta se întinde ca o gumă de mestecat și se rupe și ai impresia că o să leșini. Dar ăsta ar fi un noroc de care nu ai parte. 
Femeia e deja la câțiva centrimetri de fața ta. Duhoarea e de nesuportat. Încercările tale de a o împinge sunt sortite eșecului. Femeia scoate o limbă neagră umflată și te linge pe ochi. Pleoapele tale se închid instinctiv, dar simți toți porii limbii ei și apoi te săgetează o durere ascuțită sub ochi, acolo unde pleoapele tale ating obrajii. 
Nu mai simți limba, dar nu poți ști cu certitudine dacă nu mai este acolo, pentru că în momentul ăsta nu te poți concentra decât pe durere. E o durere care îți ia mințile și te întrebi în treacăt cum și de ce e posibil așa ceva. 
Sari de pe scaun, cu ochii pe care se pare că nu îi poți dezlipi, cu pielea atârnând și sângerând pe brațe și cu gura căscată într-un urlet pe care nu reușești să îl articulezi."
                    },
                    new StoryChapter()
                    {
                        Number = 6,
                        Decision = 'b',
                        Text = @"Ți-e frică să nu se sperie dacă se trezește și te vede în camera ei așa că ieși din apartament la fel de ușor cum ai intrat. Te gândești că o plimbare prin parc își va face bine, te va ajuta să îți pui gândurile în ordine.
Când intri pe poarta din fier, un vânt ușor adie și te bucuri să îl simți. E gol, niciun om nicăieri și deoadată îți dai seama că de când ai ieșit din propriul apartament nu ai văzut pe nimeni, iar asta e cel puțin ciudat. 
Copacii se mișcă în bătaia vântului. Îi privești și te relaxezi așa că hotărăști să te așezi. 
Găsești o bancă mică, de o persoană, cu mânere din fier forjat lângă o salcie bătrână. E comod aici. Îți lași capul pe spate și privești crengile lăsate în jos cum se unduiesc. Închizi ochii și tragi aer adânc în piept, dar în loc de aerul curat al dimineții simți miros de carne stricată. Ca atunci când mama ta a aruncat pulpele alea de pui expirate la coș, dar a uitat să ducă gunoiul. După două zile au început să putrezească și mama ta a fost nevoită să arunce coșul cu totul și să cumpere unul nou pentru că duhoarea se impregnase în plastic.
Iar acum, stând pe bancă sub salcie, simți același miros. Deschizi ochii exact în clipa în care o vezi cum se întoarce către tine. Instinctiv, te tragi mai în spate, cu privirea fixată către capul ei. 
În fața ta, în picioare, e o femeie cu părul negru și lung. Pe fața mov are bube cu lichid, iar ochii îi ies grotesc de mult din orbite. Gura ei căscată are dinți negri, acolo unde ei încă nu au căzut. Și pute atât de puternic încat icnești fară să îți dai seama.
Vrei să te ridici, dar cumva pielea ta se lipește de lemn și începe să sfârâie. Simți cum te arde spatele. Încerci să îți dezlipești palmele de mânere, dar ele par lipite acolo cu cel mai puternic adeziv. Între timp, femeia cu părul negru și față mov începe să se apropie de tine.
Deschizi buzele să țipi, dar nu iese niciun sunet. Tot corpul, acolo unde atinge banca, ustură. E o durere ce devine din ce în ce mai puternică. În curând va deveni agonie, dar tu nu îți poți dezlipi privirea de la femeia care se apropie cumva plutind.
Te zbați și încerci încă odată să urli. Din  gâtul tău iese liniște, dar brațele tale se desprind de mânerele din fier. Pielea ta se întinde ca o gumă de mestecat și se rupe și ai impresia că o să leșini. Dar ăsta ar fi un noroc de care nu ai parte. 
Femeia e deja la câțiva centrimetri de fața ta. Duhoarea e de nesuportat. Încercările tale de a o împinge sunt sortite eșecului. Femeia scoate o limbă neagră umflată și te linge pe ochi. Pleoapele tale se închid instinctiv, dar simți toți porii limbii ei și apoi te săgetează o durere ascuțită sub ochi, acolo unde pleoapele tale ating obrajii. 
Nu mai simți limba, dar nu poți ști cu certitudine dacă nu mai este acolo, pentru că în momentul ăsta nu te poți concentra decât pe durere. E o durere care îți ia mințile și te întrebi în treacăt cum și de ce e posibil așa ceva. 
Sari de pe bancă, cu ochii pe care se pare că nu îi poți dezlipi, cu pielea atârnând și sângerând pe brațe și gura căscată într-un urlet pe care nu reușești să îl articulezi."
                    },
                    new StoryChapter()
                    {
                        Number = 5,
                        Decision = 'b',
                        Text = @"Privești clădirea și vezi că are geamul deschis la dormitor. Te intorci cu spatele la ea și pornești către parc. Te gândești că o plimbare îți va face bine și te va ajuta să îți pui gândurile în ordine.
Când intri pe poartă, un vânt ușor adie și te bucuri să îl simți. E gol, niciun om nicăieri și deoadată îți dai seama că de când ai ieșit din propriul apartament nu ai văzut pe nimeni, iar asta e cel puțin ciudat. 
Copacii se mișcă în bătaia vântului. Îi privești și te relaxezi, apoi vezi o bancă de o persoană cu mânere din fier forjat, sub o salcie bătrână.
",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"te așezi pe bancă", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"mergi mai departe", Color  = "Blue" }
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 6,
                        Decision = 'a',
                        Text = @"E comod aici. Îți lași capul pe spate și privești crengile lăsate în jos cum se unduiesc. Închizi ochii și tragi aer adânc în piept, dar în loc de aerul curat al dimineții simți miros de carne stricată. Ca atunci când mama ta a aruncat pulpele alea de pui expirate la coș, dar a uitat să ducă gunoiul. După două zile au început să putrezească și mama ta a fost nevoită să arunce coșul cu totul și să cumpere unul nou pentru că duhoarea se impregnase în plastic.
Iar acum, stând pe bancă sub salcie, simți același miros. Deschizi ochii exact în clipa în care o vezi cum se întoarce către tine. Instinctiv, te tragi mai în spate, cu privirea fixată către capul ei. 
În fața ta, în picioare, e o femeie cu părul negru și lung. Pe fața mov are bube cu lichid, iar ochii îi ies grotesc de mult din orbite. Gura ei căscată are dinți negri, acolo unde ei încă nu au căzut. Și pute atât de puternic încat icnești fară să îți dai seama.
Vrei să te ridici, dar cumva pielea ta se lipește de lemn și începe să sfârâie. Simți cum te arde spatele. Încerci să îți dezlipești palmele de mânere, dar ele par lipite acolo cu cel mai puternic adeziv. Între timp, femeia cu părul negru și față mov începe să se apropie de tine.
Deschizi buzele să țipi, dar nu iese niciun sunet. Tot corpul, acolo unde atinge banca, ustură. E o durere ce devine din ce în ce mai puternică. În curând va deveni agonie, dar tu nu îți poți dezlipi privirea de la femeia care se apropie cumva plutind.
Te zbați și încerci încă odată să urli. Din  gâtul tău iese liniște, dar brațele tale se desprind de mânerele din fier. Pielea ta se întinde ca o gumă de mestecat și se rupe și ai impresia că o să leșini. Dar ăsta ar fi un noroc de care nu ai parte. 
Femeia e deja la câțiva centrimetri de fața ta. Duhoarea e de nesuportat. Încercările tale de a o împinge sunt sortite eșecului. Femeia scoate o limbă neagră umflată și te linge pe ochi. Pleoapele tale se închid instinctiv, dar simți toți porii limbii ei și apoi te săgetează o durere ascuțită sub ochi, acolo unde pleoapele tale ating obrajii. 
Nu mai simți limba, dar nu poți ști cu certitudine dacă nu mai este acolo, pentru că în momentul ăsta nu te poți concentra decât pe durere. E o durere care îți ia mințile și te întrebi în treacăt cum și de ce e posibil așa ceva. 
Sari de pe bancă, cu ochii pe care se pare că nu îi poți dezlipi, cu pielea atârnând și sângerând pe brațe și gura căscată într-un urlet pe care nu reușești să îl articulezi.",
                    },
                    new StoryChapter()
                    {
                        Number = 6,
                        Decision = 'b',
                        Text = @"Ignori banca și hotărăști să mergi mai departe. E plăcut să te plimbi. Simți aer curat și miros de iarbă proaspăt tăiată. Nu  mai ai mult și ajungi la fântână.
În mijlocul ei e o statuie a doi copilași care toarnă apă dintr-un ulcior în altul. Te așezi pe margine și bagi o mână în fântână. E rece și plină de monede. Închizi ochii și te bucuri de senzație.
Dar în loc de iarbă și apă, acum simți miros de carne stricată. Ca atunci când mama ta a aruncat pulpele alea de pui expirate la coș, dar a uitat să ducă gunoiul. După două zile au început să putrezească și mama ta a fost nevoită să arunce coșul cu totul și să cumpere unul nou pentru că duhoarea se impregnase în plastic.
Iar acum, stând pe fântână cu una dintre mâini în apă, simți același miros. Deschizi ochii exact în clipa în care o vezi cum se întoarce către tine. Instinctiv, te tragi mai în spate, cu privirea fixată către capul ei. 
În fața ta, în picioare, e o femeie cu părul negru și lung. Pe fața mov are bube cu lichid, iar ochii îi ies grotesc de mult din orbite. Gura ei căscată are dinți negri, acolo unde ei încă nu au căzut. Și pute atât de puternic încat icnești fară să îți dai seama.
Vrei să te ridici, dar cumva pielea ta se lipește de ciment și începe să sfârâie. Simți cum te arde. Încerci să îți dezlipești palma rămasă afară sau să scoți mâna din apă, dar ele par lipite acolo cu cel mai puternic adeziv. Între timp, femeia cu părul negru și față mov începe să se apropie de tine.
Deschizi buzele să țipi, dar nu iese niciun sunet. Tot corpul, acolo unde atinge cimentul, ustură. E o durere ce devine din ce în ce mai puternică. În curând va deveni agonie, dar tu nu îți poți dezlipi privirea de la femeia care se apropie cumva plutind.
Te zbați și încerci încă odată să urli. Din  gâtul tău iese liniște, dar brațele tale se eliberează în sfârșit. Pielea ta se întinde ca o gumă de mestecat și se rupe și ai impresia că o să leșini. Dar ăsta ar fi un noroc de care nu ai parte. 
Femeia e deja la câțiva centrimetri de fața ta. Duhoarea e de nesuportat. Încercările tale de a o împinge sunt sortite eșecului. Femeia scoate o limbă neagră umflată și te linge pe ochi. Pleoapele tale se închid instinctiv, dar simți toți porii limbii ei și apoi te săgetează o durere ascuțită sub ochi, acolo unde pleoapele tale ating obrajii. 
Nu mai simți limba, dar nu poți ști cu certitudine dacă nu mai este acolo, pentru că în momentul ăsta nu te poți concentra decât pe durere. E o durere care îți ia mințile și te întrebi în treacăt cum și de ce e posibil așa ceva. 
Reușești să te ridici, cu ochii pe care se pare că nu îi poți dezlipi, cu pielea atârnând și sângerând pe brațe și gura căscată într-un urlet pe care nu poți să îl articulezi.",
                    },
                    new StoryChapter()
                    {
                        Number = 7,
                        Text = @"Bătrânul e obișnuit cu munca lui. Coase pleoapele mortului cu pricepere, fără silă, ca și cum ar îngriji o păpușă. Îl dă cu parfum și se întreabă la cum o să arate și el pe masa din marmură veche.

Ai reușit să scapi și fugi. Deodată nu mai ești în apartament/parc ci undeva în aer liber. Picioarele tale se mișcă repede, adrenalina ți-a umplut corpul, dar în urma ta femeia cu părul negru șuieră. Ea vrea să te prindă în brațele ei putrezite și să te țină acolo pe vecie. Știi asta fără să ți-o spună cineva. Alergi cât poți de repede pentru că ești conștient că dacă ea te prinde, ești pierdut pentru totdeauna. Așa că fugi mâncând pământul, cu pleoapele cusute și țipând fără sunet.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"fugi în continuare", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"te întorci către ea, hotărât să o confrunți", Color = "Blue"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 8,
                        Decision = 'a',
                        Text = @"Fugi în continuare până când ajungi într-un cimitir. Îți dai seama de asta când te lovești de o piatră funerară pe care o atingi ușor cu degetele și simți scrisul, numele celui trecut în neființă. Alergi în continuare, de data asta mult mai încet, cu mâinile întinse în față până când ajungi la o groapă proaspăt săpată. Nu ai cum să o vezi, dar simți cu piciorul golul.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"te ascunzi în groapă", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"fugi mai departe", Color = "Blue"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 9,
                        Decision = 'a',
                        Text = @"Decizi să te ascunzi în groapă. Sari în ea, dar te lovești la coate și genunchi. Nu te așteptai să fie atât de adâncă. Te ghemuiești într-un colț și îți ții respirația. 
Ochii te ustură, acolo unde au fost cusuți de limba femeii cu păr negru și respiri din ce în ce mai greu. Pieptul tău se simte greu, ca și cum ceva ar sta deasupra lui și l-ar apăsa.	
Arătarea a ajuns deasupra gropii și începe să râdă. Nu e un râs normal, ci cumva horcăit și poți simți din nou mirosul ei. Te ridici în picioare cu gândul să ieși de acolo și să încerci să fugi iar, dar aluneci și cazi pe spate.
Și chiar atunci femeia cu păr negru aruncă prima lopată de pământ peste tine.
",
                    },
                    new StoryChapter()
                    {
                        Number = 9,
                        Decision = 'b',
                        Text = @"Ocolești groapa și continui să fugi cu mâinile întinse în față. Exact în momentul în care începi să te miri cum de nu te-ai împiedicat până acum, cazi. O altă groapă pe care de data asta nu ai observat-o.
Cu ochii lipiți nu îți dai seama cât de adâncă e și te lovești la coate și genunchi. Te ghemuiești într-un colț și îți ții respirația. 
Ochii te ustură, acolo unde au fost cusuți de limba femeii cu păr negru și respiri din ce în ce mai greu. Pieptul tău se simte greu, ca și cum ceva ar sta deasupra lui și l-ar apăsa.	
Arătarea a ajuns deasupra gropii și începe să râdă. Nu e un râs normal, ci cumva horcăit și poți simți din nou mirosul ei. Te ridici în picioare cu gândul să ieși de acolo și să încerci să fugi iar, dar aluneci și cazi pe spate.
Și chiar atunci femeia cu păr negru aruncă prima lopată de pământ peste tine.
",
                    },
                                       new StoryChapter()
                    {
                        Number = 8,
                        Decision = 'b',
                        Text = @"Dar nu pentru mult timp. Hotărât să scapi odată de ea, te oprești brusc și te întorci către ea, hotărât să o confrunți. Dar în loc de carne stricată, simți parfumul ei, al Mădălinei/Grace. 
Pentru moment nu înțelegi ce se întâmplă și rămâi nemișcat. Apoi începi să auzi suspinele ei și în curând vocea ei blândă, înecată de plâns, îți spune „trezește-te, oh, te rog, trezește-te”.",
                        Decisions = new[]
                        {
                            new StoryChapterDecision() { Decision = 'a', Text = @"întinzi mâinile să o atingi", Color = "Red"},
                            new StoryChapterDecision() { Decision = 'b',Text = @"te întorci să fugi din nou, convins că nu e Mădălina/Grace" , Color = "Blue"}
                        }
                    },
                    new StoryChapter()
                    {
                        Number = 9,
                        Decision = 'a',
                        Text = @"Întinzi mâinile să o atingi, dar în loc de piele fină simți carne rece. Și moartă. E femeia cu părul negru. Și ea te prinde de palmă strâns.
Te smucești din strânsoare cu putere, dar cazi pe spate direct într-o groapă proaspăt săpată.
Cu ochii lipiți nu îți dai seama cât de adâncă e și te lovești la coate și genunchi. Te ghemuiești într-un colț și îți ții respirația. 
Ochii te ustură, acolo unde au fost cusuți de limba femeii cu păr negru și respiri din ce în ce mai greu. Pieptul tău se simte greu, ca și cum ceva ar sta deasupra lui și l-ar apăsa.	
Arătarea a ajuns deasupra gropii și începe să râdă. Nu e un râs normal, ci cumva horcăit și poți simți din nou mirosul ei. Te ridici în picioare cu gândul să ieși de acolo și să încerci să fugi iar, dar aluneci și cazi pe spate.
Și chiar atunci femeia cu păr negru aruncă prima lopată de pământ peste tine.",
                    },
                    new StoryChapter()
                    {
                        Number = 9,
                        Decision = 'b',
                        Text = @"Ești convins că nu are cum să fie Mădălina/Grace așa că te întorci să fugi din nou. 
Nu reușești să faci decât câțiva pași și cazi într-o groapă proaspăt săpată.
Cu ochii lipiți nu îți dai seama cât de adâncă e și te lovești la coate și genunchi. Te ghemuiești într-un colț și îți ții respirația. 
Ochii te ustură, acolo unde au fost cusuți de limba femeii cu păr negru și respiri din ce în ce mai greu. Pieptul tău se simte greu, ca și cum ceva ar sta deasupra lui și l-ar apăsa.	
Arătarea a ajuns deasupra gropii și începe să râdă. Nu e un râs normal, ci cumva horcăit și poți simți din nou mirosul ei. Te ridici în picioare cu gândul să ieși de acolo și să încerci să fugi iar, dar aluneci și cazi pe spate.
Și chiar atunci femeia cu păr negru aruncă prima lopată de pământ peste tine.",
                    },
                    new StoryEndingChapter()
                    {
                        Number = 10,
                        Text = @"Simți pământul cum vine în valuri peste tine, dar nu ai cum sa îl oprești. Încerci fără succes să ieși din groapă, dar e prea adâncă și pământul e alunecos. Vrei să ţipi dar în continuare nu ai glas. Ochii îţi sunt lipiţi şi acolo unde pleoapele tale ating pielea obrazului simţi cum te arde. E agonie şi deodată tot ce îţi doreşti este să mori ca să scapi. 
Dar femeia cu părul negru are alte planuri pentru tine.

Groparii aruncă pământ peste sicriul din lemn lăcuit. Mădălina/Grace plânge și strigă „Trezește-te, oh, te rog, trezește-te! De ce nu se trezește?”

Mâinile ei reci te cuprind într-o îmbrățișare. Limba umflată îți linge obrazul. Pământul din jurul tău te ține imobilizat, ca și cum ai fi paralizat. Duhoarea te amețește, dar nu leșini.  
Femeia cu părul negru începe să își înfigă unghiile în carnea ta. Le simți cum apasă din ce în ce mai tare până când ele străpung pielea și ajung la os. Urli în gând.
Gura ți se umple de viermi. Îi simți zvârcolindu-se sub și pe limba ta. 
Simți că te apropii de nebunie și o aștepți cu nerăbdare."
                    },
                    new StoryEndingChapter()
                    {
                        Number = 10,
                        DecisionsTaken = new DecisionsTaken(new[] { 'b','b','b','b','b','b' }),
                        Text = @"Simți pământul cum vine în valuri peste tine, dar nu ai cum sa îl oprești. Încerci fără succes să ieși din groapă, dar e prea adâncă și pământul e alunecos. Vrei să ţipi dar în continuare nu ai glas. Ochii îţi sunt lipiţi şi acolo unde pleoapele tale ating pielea obrazului simţi cum te arde. E agonie şi tot ce îţi doreşti este să mori ca să scapi.
Apoi întinzi mâinile și atingi un material fin care pare așezat peste ceva tare. Îți tragi mâinile speriat, te lovești cu coatele de marginile sicriului și realizezi că nu mai e pământ peste tine, dar ești închis într-o cutie.

Groparii aruncă pământ peste sicriul din lemn lăcuit. Mădălina/Grace plânge și strigă „Trezește-te, oh, te rog, trezește-te! De ce nu se trezește?”

O auzi pe iubita ta și îți amintești ce s-a întâmplat și îți dai seama unde ești. 
Începi să bați cu pumnii in lemn și deodata glasul îți revine. Urli din toate puterile, pentru că de asta depinde viața ta. 
Ochii îți sunt în continuare lipiți, dar pumnii tăi lovesc în disperare capacul sicriului și țipi și țipi până când....

Groparii se opresc din lucru. Unul dintre ei își face o cruce și se dă în spate câțiva pași.
Mădălina/Grace se aruncă în groapă și începe să tragă de capac. Ea strigă „E ÎN VIAȚĂ. E ÎN VIAȚĂ. CINEVA SĂ DESCHIDĂ SICRIUL ĂSTA NENOROCIT”.
Un bărbat găsește o rangă în roaba groparilor și sare lângă femeia care plânge. Înfige și trage cu putere de câteva ori până când reușește să smulgă capacul.

Deși ai ochii lipiți, lumina soarelui te face să vezi roșu. Simți căldura lui.
Și o auzi pe Mădălina/Grace. Îți simți mâinile fine pe față și apoi simți alte mâini puternice cum te apucă și te ridică din sicriu.

Părinții bărbatului din sicriu plâng și îi mulțumesc Dumnezeului lor pentru că nu au cerut îmbălsămare. Sunt fericiți și nici nu se mai întreabă cum e posibil să se întâmple așa ceva. Pentru ei e o minune cerească.

Ești îmbrățișat din toate părțile și știi că ai scăpat.
În groapă, femeia cu părul negru rânjește. Tu nu o vezi, dar ea întinde brațele către tine.
Și apoi, exact când crezi că ai visat totul, îi auzi vocea grotească:
„Te aștept. Mai ai puțin și vii înapoi la mine”"
                    }
                }
            };

            return story;
        }
    }
}

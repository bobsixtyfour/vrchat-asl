#if UNITY_EDITOR && VRC_SDK_VRCSDK2

using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using VRCSDK2;
using UnityEngine.Events;
using UnityEditor.Events;

public class Squrrel_HQ : MonoBehaviour
{
    [MenuItem("ASLWorld/SqurrelButtons")]
    static void SqurrelButtons()
    {
        string[][,] ASLlessons = { //creates an array of arrays
			new string[,]{//lesson 1
            {"Hello/Hi","안녕하세요","Bonjour/Salut","Hallo"},{"Bye","안녕(작별)","AuRevoir","Tschus"},{"How","어떻게","Comment","Wie"},{"You","너","Toi/Tu","du/dir"},{"How are you?","어떻게 지냈어?","Comment vas-tu?","Wie geht es dir?"},
            {"Nice","멋지다","Agréable","Nett"},{"Meet","만나다","Rencontrer","Treffen"},{"Nice to meet you","만나서 반가워","Ravis de te rencontrer.","Freut mich, dich kennenzulernen"},{"Good","좋아,훌륭해","Bon","Gut"},{"Bad","나빠","Mauvais","Schlecht"},
            {"Fine","괜찮아","Bien","fein"},{"Who","누구","Qui","Wer"},{"What","무엇을","Quoi","Was"},{"When","언제","Quand","Wann"},{"Where","어디","Où","Wo"},{"Why","왜","Pourquoi","Warum"},{"Which","어떤것","Lequel","Welche"},{"Understand","이해하다","Comprendre","Verstehen"},
            {"Don’t Understand","이해하지 못하다","Ne pas comprendre","Verstehe nicht"},{"Yes","네,예","Oui","Ja"},{"No","아니","Non","Nein"},{"Please","제발,부디","S’il vous plaît","Bitte"},{"Thanks","고마워","Merci","Vielen Dank"},{"Sorry","미안해","Désolé","Es tut uns leid"},
            {"Deaf","청각장애인(농아인)","Sourd","gehörlos"},{"Hard of Hearing","난청인","Malententand","schwerhörig"},{"Hearing","청력,청인","Entendant","Hören"},{"Mute","말을 못하다","Muet","Stumm"}
            },
            new string[,]{//lesson 2
			{"Person","사람","Personne","Person"},{"Learn","배우다","Apprendre","Lernen"},{"Student","학생","Étudiant","Student"},{"Teach","가르치다","Enseigner","Lehren"},{"Teacher","선생님","Enseignant","Lehrer"},
            {"Friend","친구","Ami","Freund"},{"Slow","느리다","Lent","Langsam"},{"Fast","빠르다","Rapide","Schnell"},{"Like","좋다","Aimer","mögen"},{"Don’t Like","싫다","Ne pas aimer","mag nicht"},{"Want","원하다","Vouloir","wollen"},
            {"Don’t Want","원하지 않다","Ne pas vouloir","will nicht"},{"Need","필요하다","Besoin","brauchen"},{"Change","바꾸다","Changer","Veränderung"},{"Same","같다","Même","gleich"},{"Different","다르다","Different","anders"},{"Can","할수있다","Pouvoir","können"},
            {"Can’t","못하다","Ne pas pouvoir","Kann nicht"},{"Not","그것은 아니다","Pas","Nicht"},{"Use","사용하다","Utiliser","verwenden"},{"Follow","따라가다","Suivre","Folgen"},{"Easy","쉽다","Facile","einfach"},{"Difficult","어렵다","Difficile","Schwer"},
            {"Soft","부드럽다","Doux","Sanft"},{"Hard","단단하다","Dure","Hart"},{"New","새롭다","Nouveau","Neu"},{"Old","나이,늙은","Vieux","alt"},{"Much/Alot","많다","Beaucoup","Viel"}
            },
            new string[,]{//lesson 3
			{"Time","시간","Temps","Zeit"},{"Tomorrow","내일","Demain","Morgen"},{"Yesterday","어제","Hier","Gestern"},{"Today","오늘","Aujourd'hui","heute"},{"Second","초","Seconde","Sekunde"},{"Minute","분","Minute","Minute"},
            {"Hour","시, 1시간","Heure","Stunde"},{"Day","하루","Journée","Tag"},{"Week","일주일","Semaine","Woche"},{"Month","개월,달","Mois","Monat"},{"Year","년도","Année","Jahr"},{"Past","과거","Passé","Vergangenheit"},{"Future/Will","미래","Future","Zukunft/Wille"},
            {"Before","전에","Avant","Vor"},{"Now","지금","Maintenant","Jetzt"},{"After","후에","Après","Nach"},{"Someday/Eventually","언젠가/결국","un Jour/Éventuellement","Irgendwann mal/Schließlich"},{"Everyday","매일","Tous les jours","Täglich"},
            {"Next","다음","Suivant","Nächster"},{"Done/Finished","완료","Termier","Fertig"},{"Late","나중에","Tard","Spät"},{"Near","가깝다","Près","In der Nähe von"},
            {"Far","멀다","Loin","Weit"},{"House","집","Maison","Haus"},{"Home","집","Maison","Zuhause"},{"Live","살다","Vivre","Leben"},{"True/Sure/Real","진실,정말,진짜","Vrai","Richtig/Sicher/Real"},{"Fake","거짓말,가짜","Faux","Fälschung"}
            },
            new string[,]{//lesson 4
			{"Normal","평범,보통","Normal","Normal"},{"Any","전혀,어느","N'importequel","beliebig"},{"Continue","계속","Continuer","Fortsetzen"},{"Stay","계속있다,머물러있다","Rester","Bleibe"},{"Still","여전하다","Encore","Noch"},
            {"Copy","복사","Copier","Kopieren"},{"Notice","공지,안내","Remarquer","bemerken"},{"Improve","개선","Ameliorer","Verbessern"},{"Gone","사라지다","Disparu","Weg"},{"Test","시험,테스트","Tester","Test"},{"Visit","방문하다","Visiter","Besuch"},
            {"With","와(과)함께","Avec","Mit"},{"Without","없이","Sans","Ohne"},{"Away","없이떨어져/저리가!","Auloin","Weg"},{"Weird","기괴하다,이상하다","Bizarre","Seltsam"},{"Turn","돌다,돌리다","Tourner","abbiegen"},
            {"More Than","보다 많다","Plusque",""},{"Less Than","보다 적다","Moinsque",""},{"Correct","옳다,맞다","Correct",""},{"High","높다","Haut",""},{"Low","낮다","Bas",""},{"Way","방식","Chemin",""},{"Wish","원하다,바라다","Souhait",""},
            {"Later","늦다","Tard","Später"},{"Perfect","완벽하다","Parfait","Perfekt"},{"Fun","재미,재밌어","Amusant","Spaß"},{"Every","모든,모두","Tout","Jeden"},{"Funny","우습다,웃기다","Drôle","Lustig"}
            },
            new string[,]{//lesson 5
			{"Jealous","질투","Jaloux","Eifersüchtig"},{"Idea","아이디어,발상","Idée","Idee"},{"Mountain","산","Montagne","Berg"},{"Blame","탓하다","Accuser","Schuld"},{"Babysitter","육아도우미","Gardienne d'enfants","Babysitter"},
            {"Behavior","행동","Agissement","Verhalten"},{"Butter","버터","Beurre","Butter"},{"Farm","농장","Ferme","Bauernhof"},{"Fault","잘못","Faute","Fehler"},{"Fall","떨어지다/빠지다","Tomber","Fallen"},{"Man","남자","Homme","Mann"},
            {"Woman","여자","Femme","Frauen"},{"Mom","엄마","Mère","Mama"},{"Dad","아빠","Père","Papa"},{"Uncle","삼촌","Oncle","Uncle"},{"Aunt","고모,이모","Tante","Tante"},{"Grandma","할머니","Grand-mère","Oma"},{"Grandpa","할아버지","Grand-père","Opa"},
            {"Sister","언니,누나","Sœur","Schwester"},{"Brother","오빠,형","Frère","Bruder"},{"Kid","꼬마,어린이","Enfant","Kind"},{"Sunday","일요일","Dimanche","Sonntag"},{"Monday","월요일","Lundi","Montag"},
            {"Tuesday","화요일","Mardi","Dienstag"},{"Wednesday","수요일","Mercredi","Mittwoch"},{"Thursday","목요일","Jeudi","Donnerstag"},{"Friday","금요일","Vendredi","Freitag"},{"Saturday","토요일","Samedi","Samstag"}
            },
            new string[,]{//lesson 6
			{"Account","계좌","Compte","Konto"},{"Abandon","버리다","Abandonner","Verlassen"},{"Balance","균형(상태)","Balancer","Balance"},{"Bath","목욕","Bain","Bad"},{"Excited","야구","Excité","Aufgeregt"},{"Because","때문에,왜냐면","Parce que","weil"},
            {"Become","되다","Devenir","Werden"},{"Call","부르다","Appeler","Anruf"},{"Careful","조심하다","Prudent","Vorsichtig"},{"Choose","선택하다","Choisir","Wählen"},{"Red","빨간색","Rouge","Rot"},{"Blue","파랑색","Bleu","Blau"},{"Green","초록색","Vert","Grün"},
            {"Yellow","노란색","Jaune","Gelb"},{"Orange","주황색","Orange","Orange"},{"Purple","보라색","Purple","Lila"},{"Pink","분홍색","Rose","Rosa"},{"Black","검은색","Noir","Schwarz"},{"White","하얀색","Blanc","Weiß"},{"Grey","회색","Gris","Grau"},
            {"Brown","갈색","Brun","Braun"},{"Tan","황갈색,선탠","Hâlé","Bräunen"},{"Gold","골드,황금색","Or","Gold"},{"Silver","실버,은색","Argent","Silber"},
            {"Bright-(Color)","밝다","Brillant","Hell (Frabe)"},{"Shiny-(Color)","빛나다,반짝이다","Étincelant","Glänzend- (Farbe)"},{"Light-(Color)","연하다","Clair","Licht-(Frabe)"},{"Dark-(Color)","어둡다","Foncé","Dunkle (Farbe)"}
            },
            new string[,]{//lesson 7
			{"Fly","날다","Voler","Fliege"},{"Schedule","일정,스케줄","Emploi du temps","Zeitplan"},{"Frustrated","좌절하다","Frustré","Frustriert"},{"Don’t Worry","걱정마세요","Ne t'inquiète pas","Mach dir keine Sorgen"},{"Embarrassed","당황하다","Embarassé","Verlegen"},
            {"Polite","공손하다","Poli","Höflich"},{"Rude","무례하다","Rude","Unhöflich"},{"Strong","강하다","Fort","Stark"},{"Brave","용감하다,용기 있는","Brave","Mutig"},{"Experience","경험하다,체험하다","Expérience","Erfahrung"},{"Expensive","비싸다","Coûteux","Teuer"},
            {"Curious","궁금하다,호기심이많다","Curieux","Neugierig"},{"Money","돈","Argent","Geld"},{"Lazy","게으른다","Lâche","Faul"},{"Hungry","배고프다","Faim","Hungrig"},{"Important","중요하다","Important","Wichtig"},{"Family","가족","Famille","Familie"},
            {"Worry","걱정하다","Inquiêtude","Sorge"},{"Worse","더나쁘다,심하다","Pire","Schlechter"},{"Here","여기,여기서","Ici","Hier"},{"Area","지역(구역)","Zone","Bereich"},{"E-Mail","전자메일(이메일)","Courriel","E-Mail"},{"Discord","디스코드","Discorde","Discord"},
            {"Drama","드라마","Drame","Theater"},{"Hot","뜨겁다,덥다","Chaud","Heiß"},{"Cold","차갑다,춥다","Froid","Kalt"},{"Music","음악","Musique","Musik"},{"Avatar","아바타","Avatar","Benutzerbild"}
            },
            new string[,]{//lesson 8
			{"Cochlear Implant","인공와우","Implant Cochéaire","Cochleaimplantat"},{"Hearing Aid","보청기","Aide auditoire","Höhrgerät"},{"Disorder","엉망,어수선,장애","Désordre","Störung"},{"Together","함께하다","Ensemble","Zusammen"},
            {"Nothing","아무것도 아니다","Rien","Nichts"},{"Selective Mutism","불안장애","Mustisme sélectif","Selektive Stummheit"},{"Restaurant","레스토랑,식당","Restaurant","Restaurant"},{"Order","주문,질서","Ordre","Auftrag"},{"Serve","제공,서비스","Service","Dienen"},
            {"Buy","구매,사다","Acheter","Kaufen"},{"Sell","팔다","Vendre","Verkaufen"},{"Taco","타코","Taco","Taco"},{"Burrito","브리또","Burrito","Burrito"},{"Hamburger","햄버거","Hamburger","Hamburger"},{"Spaghetti","스파게티","Spaghetti","Spaghetti"},{"Pizza","피자","Pizza","Pizza"},
            {"IceCream","아이스크림","Crème glacée","Eiscreme"},{"Cake","케이크","Gâteaux","Kuchen"},{"Cookie","과자/쿠키","Biscuit","Plätzchen"},{"Police","경찰","Police","Polizei"},{"FireMan","소방관","Pompier","Feuerwehrmann"},{"Doctor","의사","Docteur","Ärzt"},
            {"Wonder","궁금하다","Se demander",""},{"Water","물","Eau","Wasser"},{"Flower","꽃","Fleur","Blume"},{"Tree","나무","Arbre","Baum"},{"Sea","바다","Océan","Meer"},{"Rock","바위","Roche","Felsen"}
            },
            new string[,]{//lesson 9
            {"Forgive","용서","Pardonner","Verzeihen"},{"Leave","떠나다","Partir","Verlassen"},{"Ready","준비","Prêt","Bereit"},{"Skill","솜씨,기술","Abilité","Fertigkeit"},{"Joke","농담","Blague","Scherz"},{"Mistake","실수","Erreur","Fehler"},
            {"Move","행동","Bouger","Bewegung"},{"Lost","잃다","Perdu","Hat verloren"},{"Work","일하다","Travail","Arbeit"},{"Talk","말하다","Parler","Sich unterhalten"},{"Not Yet","아직","Pas encore","Sich unterhalten"},{"Equal","동등하다","Égal","Gleich"},
            {"Number","숫자,번호","Nombre","Nummer"},{"Letter","편지","Lettre","Brief"},{"Place","장소","Lieu","Platz"},{"Start","시작","Commencer","Anfang"},{"Say/Tell","말하다","Dire","Sagen/Erzählen"},{"Fill","채우다","Remplir","Füllen"},
            {"Tea","차/찻잎","Thé",""},{"Come","오다","Venir",""},{"Bring","가져오다","Apporter",""},{"Explain","설명","Expliquer",""},{"Size","크기,사이즈","Taille",""},
            {"Retreat","물러가다,후퇴","Fuir","Rückzug"},{"Return","반환,반납","Retourner","Rückkehr"},{"Taste","맛(미각)","Goût","Geschmack"},{"Enjoy","즐기다","Apprécier","Genießen"},{"Reason","이유","Raison","Grund"}
            },
            new string[,]{//lesson 10
            {"Kind/Type","종류/형태","Sorte/Type","Art/yp"},{"Limit","제한","Limite","Limit"},{"Have","가지다","Avoir","Haben"},{"Plan","계획","Plan","Planen"},{"Won","이기다","Gagné","Gewonnen"},{"Lost","지다","Perdu","Hat verloren"},
            {"Decide","결정","Décider","Entscheiden"},{"Keep","지키다","Garder","Behalten"},{"Act","행동","Agir","Handlung"},{"Guess","추측","Deviner","Vermuten"},{"Search","찾다,검색","Chercher","Suche"},{"Lock","잠그다","Verrouiller","Sperren"},
            {"Listen","듣다","Écouter","Hör mal zu"},{"Special","특별하다,특히","Spéciale","Besondere"},{"Favor","친절","Faveur","Gefallen"},{"Owe/Debt","빚지다,부채","Dette","Verdanken/Schuld"},{"Argue","다투다","Argumenter","Streiten"},{"Wonder","궁금하다","Se questionner","Wunder"},
            {"Join","가입","Joindre","Beitreten"},{"Realize","깨닫다","Réaliser","Realisieren"},{"Animal","동물","Animale","Tier"},{"Skip","넘어가다","Passer","Überspringen"},{"Calm","차분하다,침착하다","Calme","Ruhe"},
            {"Progress","진행하다","Progrès","Fortschritt"},{"Option","반대","Option","Möglichkeit"},{"Annoy","짜증","Embêter","Nerven"},{"Opposite","반대로","Opposer","Gegenteil"},{"Satisfy","만족,충족시키다","Satisfaire","Erfüllen"}
            },
            new string[,]{//lesson 11
            {"Over","지나치다,과하다","Sur","Über"},{"Holiday","휴일","Temps des fêtes","Urlaub"},{"Freeze","얼다,얼음","Geler","Einfrieren"},{"Discuss","상의","Discuter","Diskutieren"},{"Rule","규칙","Règle","Regel"},
            {"Awkward","어색하다","Gênant","Peinlich"},{"Strange","낯설다","Étrange","Seltsam"},{"Bored","심심하다","Ennuyant","Gelangweilt"},{"Hurt","아프다","Douleur","Verletzt"},{"Love","사랑","Amour","Liebe"},{"Silly","바보","Ridicule","Dumm"},
            {"Damaged","손해,피해","Endommager","Beschädigt"},{"Jail","감옥","Prison","Gefängnis"},{"Show","보여주다","Montrer","Anzeigen"},{"Dress","드레스","Robe","Kleid"},{"Pants","바지","Pantalon","Hose"},{"Shoes","신발","Chaussures","Schuhe"},
            {"Shirt","셔츠","Chandail","Hemd"},{"Bed","침대","Lit","Bett"},{"Sleep","자다","Dormir","Schlaf"},{"Drink","마시다","Boire","Getränk"},{"Sit","앉다","S'assoir","Sitzen"},{"Stand","서다","Se tenir debout","Stand"},
            {"Jump","뛰다","Sauter","Springen"},{"Picture","사진","Photo","Bild"},{"Happen","우연히","Se produire","Geschehen"},{"Communicate","의사소통","Communiquer","Kommunizieren"},{"Play","놀다","Jouer","abspielen"}
            },
            new string[,]{//lesson 12
            {"End","끝","Terminer","Ende"},{"Confused","혼란","Confus","Verwirrung"},{"Empty","비다","Vide","Leer"},{"Touch","만지다","Toucher",""},{"Car","자동차","Voiture","Auto"},{"Drive","운전하다","Conduire","Fahrt"},
            {"Above","보다위에","Au dessus","Über"},{"Stop","정지","Arrêt","Halt/Stopp!"},{"Hate","미워","Haïr","Hassen"},{"Run","달리다","Courir","Lauf"},{"Walk","걷다","Marcher","Gehen"},{"Story","이야기","Histoire","Geschichte"},{"Promise","약속","Promettre","Versprechen"},
            {"Help","돕다","Aider","Hilfe"},{"Agree","동의하다","Être en accord","Zustimmen"},{"Disagree","동의하지 않다","Être en désaccord","Nicht zustimmen"},{"Add","더하다","Ajouter","Hinzufügen"},{"Trust","신뢰","Faire Confiance","Vertrauen"},
            {"Trouble","곤란","Trouble","Schwierigkeiten/Beunruhigen"},{"Gain","얻다","Prendre","Gewinnen"},{"Challenge","도전","Défier","Herausforderung"},{"Replace","대신,교체","Remplacer","Ersetzen"},
            {"Proud","자랑스럽다","Fier","Stolz"},{"Expert","전문가","Expert","Experte"},{"Soda","탄산음료","Soda","Sprudel"},{"Eat","먹다","Manger","Essen"},{"Food","음식","Nourriture","Essen"},{"Name","이름","Nom","Name"}
            },
            new string[,]{//lesson 13
            {"Big/Huge","크다","Gros/Grand","Groß/Riesig"},{"Small","작다","Petit","Klein"},{"Beautiful","아름답다","Beau/Belle","Wunderschönen"},{"Ugly","못생기다","Laid","Hässlich"},{"Fat","뚱뚱하다","Gras","Fett"},
            {"Skinny","날씬하다","Mince","dünn"},{"Weak","약하다","Faible","Schwach"},{"Health","건강","Santé","Gesundheit"},{"Medicine","약","Médicament","Medizin"},{"Build","짓다","Construire","Bauen"},{"Break","부러지다","Briser","Pause"},
            {"Make","만들다","Faire","Machen"},{"Find","찾다","Trouver","Finden"},{"Bully","괴롭히다","Intimider","Schikanieren"},{"Insult","모욕","Insulter","Beleidigung"},{"Simple","간단하다","Simple","Einfach"},{"Complicated","복잡하다","Compliqué","Kompliziert"},
            {"Open","열다","Ouvert","Öffnen"},{"Close","닫다","Fermer","Schließen"},{"Hit","때리다","Frapper","Schlagen"},{"Meat","고기","Viande","Fleisch"},{"Bread","빵","Pain","Brot"},{"Chips","과자","Croustilles","Chips"},{"Melon","메론","Melon","Melone"},
            {"Event","행사","Évênement","Veranstaltung"},{"Socialize","사교","Socialiser","Sozialisieren"},{"Hangout/chill","쌀쌀하다","Trainer/Ensemble","Aushängen/Ausruhen"},{"Relax","편하게하다","Relaxer","Entspannen"}
            },
            new string[,]{//lesson 14
            {"Under","아래","En dessous","Unter"},{"Private/Secret","개인/비밀","Privé/Secret","Privat/Geheimnis"},{"Emergency","비상/사태","Urgence","Notfall"},{"Favorite","마음에 들다","Favori","Lieblings"},{"Class","수업","Classe","Klasse"},
            {"Proof","증명,증거","Preuve","Beweis"},{"Switch","스위치","Transférer","Schalter"},{"Angry","화나다","Faché","Wütend"},{"Store","상점,가게","Magasin","Geschäft"},{"Respect","존경","Respect","Respekt"},{"Ask","물어보다","Demander","Fragen"},
            {"Suggest","제안","Suggerer","Vorschlagen"},{"Trash","쓰레기","Déchet","Müll"},{"Clean","깨끗하다","Propre","Reinigen"},{"Age","나이","Age","Alter"},{"Try","노력","Éssayer","Versuchen"},{"Pay","지불","Payer","Zahlen"},
            {"Hide","감추다,숨다","Cacher","Ausblenden"},{"Random","무작위","Aléatoire","Zufällig"},{"Flag","깃발","Drapeau","Flagge"},{"Judge","심판","Juge","Richter"},{"Warn","경고","Avertissement","Warnen"},{"See","보다","Voir","Sehen"},
            {"Collect","수집","Collecte","Sammeln"},{"Some/Part","일부,부분","Quelque","Etwas/Teil"},{"Goal","목표","But","Tor"},{"Pet","애완동물","Animale de Compagnie","Haustier"},{"Communicate","소통하다","Communiquer","Kommunizieren"}
            },
            new string[,]{//lesson 15
            {"Yesterday I worked 6 hours.","어제 나는 6시간 일했다.","Hier, j'ai travaillé 6 heures.","Gestern habe ich 6 Stunden gearbeitet"},{"I think that you are a great friend.","나는 네가 좋은 친구라고 생각해.","Je pense que tu es un bon ami.","denke, dass du ein guter Freund bist"},
            {"Do you work or have school?","너는 일하니 아니면학교니?","Est-ce que tu travailles ou vas à l'école?","Arbeitest du oder hast du eine Schule?"},{"I went to the hospital, but don't worry.","병원에 갔지만 걱정하지마.","Je suis allé à l'hôpital,mais ne tèinquiète pas.","Ich ging ins Krankenhaus, aber mach dir keine Sorgen."},
            {"All the food at the store was gone.","가게의 모든 음식은사 라졌다.","Toute la nourriture au magasin était parti.","Das Essen im Laden war weg."},{"Please repeat, I am a new student.","반복해줘,나는 새로운 학생입니다.","Répète s'il te plait,je suis un nouvel étudiant.","Bitte wiederholen Sie, ich bin ein neuer Student."},
            {"I don't understand a lot, but I am improving.","많이 이해하지는 못하지만, 발전하고 있어.","Je ne comprend pas beaucoup mais je m'améliore.","Ich verstehe nicht viel, aber ich verbessere mich."},{"Where is the teacher?","선생님은 어디 계시니?","Où est l'enseignant?","Wo ist der Lehrer?"},
            {"I don't like drama.","나는 드라마를 좋아하지 않는다.","Je n'aime pas le drame.","Ich mag kein Drama."},{"What did you do today?","오늘 뭐했어?","Qu'as-tu fait aujourd'hui?","Was hast du heute so gemacht?"},{"What is your favorite food?","가장 좋아하는 음식이 무엇입니까?","Quelle est ta nourriture préféré?","Was ist dein Lieblingsessen?"},
            {"Where can I learn more sign?","더많은 수화를 어디서배울수 있니?","Où puis-je apprendre plus de signes?","Wo kann ich mehr Zeichen lernen?"},{"Are you alright? What happened?","괜찮아? 어떻게 된 거야?","Est-ce que çava? Que s'est-t'il passé?","Geht es dir gut? Was ist passiert?"},
            {"I like turtles.","나는 거북이를 좋아한다.","J'aime les tortues.","Ich mag Schildkröten."},{"I love Deaf culture!","나는 청각장애인 문화를 좋아해!","J'aime la cultures des sourds.","Ich liebe gehörlose Kultur!"},{"You're a great person!","넌 훌륭한 사람이야!","Tu es une bonne personne.","Du bist eine großartige Person!"},
            {"I like to eat bread.","나는 빵 먹는 것을 좋아한다.","J'aime manger du pain.","Ich esse gerne Brot."},{"I hate taking pictures.","나는 사진찍는 것을싫어한다.","Je déteste prendre des photos.","Ich hasse es, Bilder zu machen."},{"I respect my friends.","나는 내친구들을 존중합니다.","Je respect mes amis.","I respect my friends."},
            {"Do you understand, need me to repeat?","알아들었어? 반복할 필요가 있어?","Est-ce que tu comprends, besoin de répéter?","Verstehst du, muss ich wiederholen?"},{"I cannot hear,I am Deaf.","나는 들을 수 없다. 나는 청각장애인이다.","Je ne peux pas entendre,je suis sourd.","Ich kann nicht hören, ich bin Gehörlos(Taub)."},
            {"I need an interpreter, who can help me?","통역사가 필요해, 누가 날 도와줄 수 있지?","J'ai besoin d'un interprètre, qui peut m'aider?","Ich brauche einen Dolmetscher, der mir helfen kann?"},{"Are you Deaf, mute, hard of hearing, hearing?","청각장애인? 말을못해? 난청인? 청인?","Es-tu sourd, muet, malentendant ou entendant?","Sind Sie Gehörlos, stumm, schwerhörig, hörend?"},
            {"Are you streaming on youtube or twitch?","유투브 or 트위치에서 스트리밍하고 있니?","Est-ce que tu diffuses sur youtube ou twitch?","Streamen Sie auf Youtube oder Twitch?"},{"I don't like running.","나는 달리기를 좋아하지 않는다.","Je n'aime pas courir.","Ich laufe nicht gern"},{"Can you lock that door?","문을 잠글수 있니?","Peux-tu verrouiller cette porte?","Kannst du diese Tür abschließen?"},
            {"I feel sick, I need to rest.","몸이 아파서 쉬어야겠어.","Je me sens malade, j'ai besoin de me reposer.","Mir ist schlecht, ich muss mich ausruhen."},{"Please stop doing that, it's rude.","제발 그렇게하지 마, 무례한 짓이야.","S'il te plait arrête de faire ça, c'est rude.","Bitte hör auf damit, es ist unhöflich."}
            },
            new string[,]{//lesson 16
            {"Door","문","Porte",""},{"Dangerous","위험하다","Dangereux","Tür"},{"Barrow","빌리다","Brouette","Karren"},{"Army","군대","Armée","Armee"},{"Group","그룹,모임","Groupe",""},{"Team","팀","Équipe","Mannschaft"},
            {"Alright","괜찮다","Bien","In Ordung"},{"Gross","역겹다","Dégueux","Brutto"},{"Feel","느끼다","Sentir","Gefühl"},{"Depression","우울증","Depression","Depression"},{"Anxiety/anxious","불안","Anxiété","Angst/ängstlich"},{"Nervous","긴장하다","Nerveux","Nervös"},
            {"Kiss","키스,뽀뽀","Embrasser","Kuss"},{"Date","날짜","Date","Datum"},{"Sweetheart","애인,연인","Cœurtendre","Schatz"},{"Fall in love","사랑에 빠진다","Tomber en amour","Sich verlieben"},{"Just/Only","그냥/오직","Seulement","Gerade/Nur"},
            {"Sneeze","재채기","Éternuer","Niesen"},{"Cough","기침","Tousser","Husten"},{"Blessyou","축복하다","À tes souhaits","Gesundheit"},{"University","종합대학","Université","Universität"},{"Church","교회","Église","Kirche"},{"Library","도서관","Bibliothèque","Bibliothek"},
            {"Office","사무실","Bureau","Büro"},{"Fancy","공상","Qualité supérieure","Schick"},{"College","전문대학","Collège","Hochschule"},{"Gym","체육관","Gymnase","Fitnessstudio"},{"Workout","운동","Exercicer","Trainieren"}
            }/*if this is the last lesson, don't put a comma after the }

				*/
        };
        string[] lessonnames = new string[]{//array of lesson names - I guess rename to Lesson 1, Lesson 2 and so on if you don't have names
		"Lesson 1","Lesson 2","Lesson 3","Lesson 4","Lesson 5","Lesson 6","Lesson 7","Lesson 8","Lesson 9","Lesson 10","Lesson 11","Lesson 12","Lesson 13","Lesson 14","15) Sentences","Lesson 16","Lesson 17","Lesson 18","Lesson 19","Lesson 20"};

        int layer = 11;
        int rowoffset = 650;
        int columnoffset = 100;

        int projectionsizex = 3400;
        int projectionsizey = 6200;

        int teachermenusizex = 1100;
        int teachermenusizey = 750;
        DefaultControls.Resources resources = new DefaultControls.Resources();

        GameObject menuroot = new GameObject("HH Root"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
        menuroot.transform.position = new Vector3(0, 0, 0);
        menuroot.layer = layer;
        GameObject rootcanvas = createandreturncanvas("Menu Canvas", menuroot, teachermenusizex, teachermenusizey, layer);
        rootcanvas.transform.position = new Vector3(-0.544f, .426f, -15.634f);

        //rootcanvas.GetComponent<RectTransform> ().localScale=new Vector3(.0004149436f,.0007330904f,.001f);
        GameObject menupanel= createpanel(rootcanvas, teachermenusizex, teachermenusizey, layer); //Creates panel under rootcanvas.
        menupanel.name="Menu Panel";

        GameObject podiumpanel = createpanel(rootcanvas, teachermenusizex, 200, layer); //Creates panel under rootcanvas.
        podiumpanel.name="Podium Panel";
        podiumpanel.GetComponent<Image>().color = new Color32(0x21, 0x21, 0x21, 0xFF);
        podiumpanel.GetComponent<RectTransform>().localPosition=new Vector3(0,550,290);
        GameObject podiumtext = DefaultControls.CreateText(resources);
        podiumtext.transform.SetParent(podiumpanel.transform, false);
        podiumtext.name = "DisplayText";
        podiumtext.layer = layer;
        podiumtext.GetComponent<Text>().text = "Welcome to the Helping Hands Headquarters!\n돕는 손 본부에 오신 것을 환영합니다!\nBienvenue au siège social de Helping Hands!\nWillkommen im Hauptquartier von Helping Hands!";
        podiumtext.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font; //change font file here
        podiumtext.GetComponent<Text>().fontStyle = FontStyle.Bold;
        podiumtext.GetComponent<Text>().fontSize = 50;
        //displaytext.GetComponent<Text> ().color = Color.black;
        podiumtext.GetComponent<Text>().color = new Color32(0x6D, 0x9E, 0xEB, 0xFF); // RGBA
        podiumtext.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        podiumtext.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        podiumtext.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        podiumtext.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        podiumtext.GetComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
        podiumtext.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        podiumtext.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
podiumtext.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 180, 0);//x,y,z

        GameObject leftdisplaycanvas = createandreturncanvas("LeftDisplay", menuroot, projectionsizex, projectionsizey, layer);
        leftdisplaycanvas.GetComponent<RectTransform>().position = new Vector3(8.57f, 5.12f, -17.57f);
        leftdisplaycanvas.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 135, 0);//x,y,z
        leftdisplaycanvas.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        leftdisplaycanvas.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        leftdisplaycanvas.GetComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
        //displaycanvas.GetComponent<RectTransform> ().localScale=new Vector3(.0007777605f,.0008309863f,.001f);
        GameObject leftdisplaypanel = createstretchedpanel(leftdisplaycanvas, layer);
        leftdisplaypanel.GetComponent<Image>().color = new Color32(0x21, 0x21, 0x21, 0xFF);
        leftdisplaypanel.GetComponent<Image>().raycastTarget = false;
        DestroyImmediate(leftdisplaycanvas.GetComponent<GraphicRaycaster>());
        DestroyImmediate(leftdisplaycanvas.GetComponent<VRC_UiShape>());
        DestroyImmediate(leftdisplaycanvas.GetComponent<ToggleGroup>());


        GameObject leftdisplaytext = DefaultControls.CreateText(resources);
        leftdisplaytext.transform.SetParent(leftdisplaycanvas.transform, false);
        leftdisplaytext.name = "LeftDisplayText";
        leftdisplaytext.layer = layer;
        leftdisplaytext.GetComponent<Text>().text = "Welcome to the Helping Hands Headquarters!\n\n돕는 손 본부에 오신 것을 환영합니다!\n\nBienvenue au siège social de Helping Hands!\n\nWillkommen im Hauptquartier von Helping Hands!";
        leftdisplaytext.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font; //change font file here
        leftdisplaytext.GetComponent<Text>().fontStyle = FontStyle.Bold;
        leftdisplaytext.GetComponent<Text>().fontSize = 300;
        //leftdisplaytext.GetComponent<Text> ().color = Color.black;
        leftdisplaytext.GetComponent<Text>().color = new Color32(0x6D, 0x9E, 0xEB, 0xFF); // RGBA
        leftdisplaytext.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        leftdisplaytext.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        leftdisplaytext.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        leftdisplaytext.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        leftdisplaytext.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        leftdisplaytext.GetComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
        leftdisplaytext.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        GameObject rightdisplaycanvas = createandreturncanvas("RightDisplay", menuroot, projectionsizex, projectionsizey, layer);
        rightdisplaycanvas.GetComponent<RectTransform>().position = new Vector3(-8.57f, 5.12f, -17.57f);
        rightdisplaycanvas.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 225, 0);//x,y,z
        rightdisplaycanvas.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        rightdisplaycanvas.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        rightdisplaycanvas.GetComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
        //displaycanvas.GetComponent<RectTransform> ().localScale=new Vector3(.0007777605f,.0008309863f,.001f);
        GameObject rightdisplaypanel = createstretchedpanel(rightdisplaycanvas, layer);
        rightdisplaypanel.GetComponent<Image>().color = new Color32(0x21, 0x21, 0x21, 0xFF);
        rightdisplaypanel.GetComponent<Image>().raycastTarget = false;
        DestroyImmediate(rightdisplaycanvas.GetComponent<GraphicRaycaster>());
        DestroyImmediate(rightdisplaycanvas.GetComponent<VRC_UiShape>());
        DestroyImmediate(rightdisplaycanvas.GetComponent<ToggleGroup>());


        GameObject rightdisplaytext = DefaultControls.CreateText(resources);
        rightdisplaytext.transform.SetParent(rightdisplaycanvas.transform, false);
        rightdisplaytext.name = "RightDisplayText";
        rightdisplaytext.layer = layer;
        rightdisplaytext.GetComponent<Text>().text = "Welcome to the Helping Hands Headquarters!\n\n돕는 손 본부에 오신 것을 환영합니다!\n\nBienvenue au siège social de Helping Hands!\n\nWillkommen im Hauptquartier von Helping Hands!";
        rightdisplaytext.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font; //change font file here
        rightdisplaytext.GetComponent<Text>().fontStyle = FontStyle.Bold;
        rightdisplaytext.GetComponent<Text>().fontSize = 300;
        //rightdisplaytext.GetComponent<Text> ().color = Color.black;
        rightdisplaytext.GetComponent<Text>().color = new Color32(0x6D, 0x9E, 0xEB, 0xFF); // RGBA
        rightdisplaytext.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        rightdisplaytext.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        rightdisplaytext.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        rightdisplaytext.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        rightdisplaytext.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        rightdisplaytext.GetComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
        rightdisplaytext.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);



        GameObject aslroot = new GameObject("ASL Root");
        aslroot.transform.SetParent(rootcanvas.transform, false);
        GameObject asllessonmenu = new GameObject("ASL Lesson Menu");
        asllessonmenu.transform.SetParent(aslroot.transform, false);
        asllessonmenu.layer = layer;
        for (int x = 0; x < ASLlessons.Length; x++)
        {
            createlessonboard(aslroot, ASLlessons[x],lessonnames, "ASL", x, rootcanvas, rowoffset, columnoffset, 40, 450, layer);//Loops and creates lesson boards for all initialized lessons in the lessonarray.
        }
        createmenu(aslroot, "ASL", ASLlessons, lessonnames, asllessonmenu, teachermenusizex, teachermenusizey, 300, 40, (teachermenusizey - 100), 80, 40, 300, layer); //creates the lesson chooser menu

        //rootcanvas.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 90, 0);//x,y,z

    }
    static GameObject createbutton2(GameObject parent, string name, int sizedeltax, int sizedeltay, int rotatex, int rotatey, int rotatez, int anchoredPositionx, int anchoredPositiony, string text, int fontSize, int txtsizeDeltax, int txtsizeDeltay, int txtanchoredPositionx, int txtanchoredPositiony, TextAnchor alignment, int layer)
    {
        Navigation no_nav = new Navigation();
        no_nav.mode = Navigation.Mode.None;

        DefaultControls.Resources resources = new DefaultControls.Resources();
        //Set the Button Background Image someBgSprite;
        resources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/InputFieldBackground.psd");
        GameObject go = DefaultControls.CreateButton(resources);
        go.layer = layer;
        go.transform.SetParent(parent.transform, false);
        go.name = name;
        Button b = go.GetOrAddComponent<Button>();
        b.navigation = no_nav;

        go.GetComponent<RectTransform>().sizeDelta = new Vector2(sizedeltax, sizedeltay);
        go.GetComponent<RectTransform>().eulerAngles = new Vector3(rotatex, rotatey, rotatez);//x,y,z
        go.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionx, anchoredPositiony);
        go.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
        go.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        go.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        go.transform.Find("Text").GetComponent<Text>().text = text;
        go.transform.Find("Text").GetComponent<Text>().fontSize = fontSize;
        go.transform.Find("Text").GetComponent<Text>().alignment = alignment;
        go.transform.Find("Text").GetComponent<RectTransform>().sizeDelta = new Vector2(txtsizeDeltax, txtsizeDeltay);
        go.transform.Find("Text").GetComponent<RectTransform>().anchoredPosition = new Vector2(txtanchoredPositionx, txtanchoredPositiony);
        go.transform.Find("Text").GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
        go.transform.Find("Text").GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        go.transform.Find("Text").GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        return go;
    }
    static GameObject createandreturncanvas(string name, GameObject parent, int sizedeltax, int sizedeltay, int layer)
    {//creates and returns canvas gameobject
        GameObject go = new GameObject(name);
        go.transform.SetParent(parent.transform, false);
        go.layer = layer;
        go.transform.localScale = new Vector3(.001f, .001f, .001f);
        go.AddComponent<RectTransform>();
        go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        go.GetComponent<RectTransform>().sizeDelta = new Vector2(sizedeltax, sizedeltay);
        go.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
        go.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        go.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        go.AddComponent<Canvas>(); //adds canvas to root canvas gameobject
        go.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        go.AddComponent<CanvasScaler>();
        go.AddComponent<GraphicRaycaster>();
        go.AddComponent<VRC_UiShape>();
        go.AddComponent<ToggleGroup>();
        return go;
    }
    static GameObject createpanel(GameObject parent, int sizedeltax, int sizedeltay, int layer)
    {//creates and returns panel gameobject
        DefaultControls.Resources resources = new DefaultControls.Resources();
        resources.background = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
        GameObject go = DefaultControls.CreatePanel(resources);
        go.transform.SetParent(parent.transform, false);
        go.layer = layer;
        go.GetComponent<RectTransform>().sizeDelta = new Vector2(sizedeltax, sizedeltay);
        go.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
        go.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        go.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        return go;
    }
    static GameObject createstretchedpanel(GameObject parent, int layer)
    {//creates and returns panel gameobject
        DefaultControls.Resources resources = new DefaultControls.Resources();
        resources.background = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
        GameObject go = DefaultControls.CreatePanel(resources);
        go.transform.SetParent(parent.transform, false);
        go.layer = layer;
        go.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        go.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        go.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        go.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        return go;
    }
    static GameObject createheadertext(GameObject parent, string txt, int sizedeltax, int sizedeltay, int anchoredPositionx, int anchoredPositiony, int layer)
    {

        DefaultControls.Resources resources = new DefaultControls.Resources();
        GameObject go = DefaultControls.CreateText(resources);
        go.transform.SetParent(parent.transform, false);
        go.name = "Header";
        go.layer = layer;
        go.GetComponent<Text>().text = txt;
        go.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        go.GetComponent<Text>().fontStyle = FontStyle.Bold;
        go.GetComponent<Text>().fontSize = 25;
        go.GetComponent<Text>().color = Color.black;
        go.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        go.GetComponent<RectTransform>().sizeDelta = new Vector2(sizedeltax, sizedeltay);
        go.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionx, anchoredPositiony);
        go.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
        go.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        go.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        return go;
    }
    static GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    static GameObject createmenu(GameObject parent, string lang, string[][,] ASLlessons, string[] lessonnames, GameObject menu, int canvassizex, int canvassizey, int buttonsizex, int buttonsizey, int rowoffset, int columnoffset, int rowseperation, int columnseperation, int layer)
    {
        Navigation no_nav = new Navigation();
        no_nav.mode = Navigation.Mode.None;
        int headerheight = 60;
        createheadertext(menu, "Lesson Menu", canvassizex, headerheight, 80, canvassizey - headerheight, layer);//Add menu header text:
        int column = 0;
        int row = 0;
        for (int x = 0; x < ASLlessons.Length; x++) //this is the main loop that processes the array and creates + organizes the buttons in rows+columns.
        {
            if (x != 0)
            {
                if (x % 15 == 0)
                { //display 9 items per column
                    column++;
                    row = 0;
                }
            }

            GameObject go = createbutton2(menu, lang + " Lesson " + (x + 1) + " - Button", buttonsizex, buttonsizey, 0, 0, 0,
            (columnoffset + (column * columnseperation)), (rowoffset + (row * -rowseperation)), lessonnames[x], 25, buttonsizex, buttonsizey, 20, 0, TextAnchor.MiddleLeft, layer);
            Button b = go.GetOrAddComponent<Button>();
            b.onClick = new Button.ButtonClickedEvent();

            UnityAction<bool> enablelesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang + " Lesson " + (x + 1)), "SetActive") as UnityAction<bool>;
            UnityEventTools.AddBoolPersistentListener(b.onClick, enablelesson, true);

            UnityAction<bool> disablemenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), menu, "SetActive") as UnityAction<bool>;
            UnityEventTools.AddBoolPersistentListener(b.onClick, disablemenu, false);


            row++;
        }
        //menu.SetActive(false);
        return menu;
    }

    static void createlessonboard(GameObject parent, string[,] signarray,string[] lessonnames ,string lang, int lessonnum, GameObject rootcanvas, int rowoffset, int columnoffset, int rowseperation, int columnseperation, int layer) //, int arraypos, int anchoredposx, int anchoredposy, string alignment, int layernum, string text, int posx, int posy
    {
        Navigation no_nav = new Navigation();
        no_nav.mode = Navigation.Mode.None; //disables navigation so people can't operate ui by moving avatar.
        GameObject lessongo = new GameObject(lang + " Lesson " + (lessonnum + 1));
        lessongo.transform.SetParent(parent.transform, false);
        createheadertext(lessongo, lessonnames[lessonnum], 1100, 30, 80, 705, layer);
		GameObject lessontriggers = new GameObject("LessonTriggers");
		lessontriggers.transform.SetParent(lessongo.transform, false);

        GameObject tablettext = FindInActiveObjectByName("Tablet Text");
		GameObject ldisplaytext = GameObject.Find("/HH Root/LeftDisplay/LeftDisplayText");
        GameObject rdisplaytext = GameObject.Find("/HH Root/RightDisplay/RightDisplayText");
        GameObject podiumdisplaytext = GameObject.Find("/HH Root/Menu Canvas/Podium Panel/DisplayText");

        DefaultControls.Resources scrollviewresources = new DefaultControls.Resources();
        //Set the Slider Background Image someBgSprite;
        scrollviewresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
        //Set the Slider Fill Image someFillSprite;
        scrollviewresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        //Set the Slider Knob Image someKnobSprite;
        scrollviewresources.knob = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Knob.psd");
        GameObject scrollview = DefaultControls.CreateScrollView(scrollviewresources);
        scrollview.GetComponent<RectTransform>().pivot=new Vector2(0,0);
        scrollview.GetComponent<RectTransform>().sizeDelta=new Vector2(1050,500);
        scrollview.GetComponent<RectTransform>().anchoredPosition=new Vector2(50,200);
        scrollview.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
        scrollview.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        scrollview.GetComponent<ScrollRect>().verticalScrollbarVisibility=ScrollRect.ScrollbarVisibility.Permanent;
        //scrollview.transform.Find("Scrollbar Horizontal").GetComponent<Scrollbar>().navigation= no_nav;
        scrollview.transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().navigation= no_nav;
        scrollview.transform.Find("Scrollbar Vertical").GetComponent<RectTransform>().sizeDelta= new Vector2(40,0);
        //scrollview.transform.Find("Scrollbar Vertical").GetComponent<Scrollbar>().direction= Scrollbar.Direction.TopToBottom;
        scrollview.GetComponent<ScrollRect>().horizontal=false;
        scrollview.GetComponent<Image>().enabled=false;
        //DestroyImmediate(scrollview.GetComponent<ScrollRect>().horizontalScrollbar);
        DestroyImmediate(scrollview.transform.Find("Scrollbar Horizontal").gameObject);
        DestroyImmediate(scrollview.transform.Find("Viewport").Find("Content").gameObject);
        //scrollviewtransform.Find("Viewport").transform

        scrollview.transform.SetParent(lessongo.transform, false);
        //uiSlider.transform.SetParent(canvas.transform, false);

		GameObject lessontoggles = new GameObject("LessonToggles");
		lessontoggles.transform.SetParent(scrollview.transform.Find("Viewport").transform, false);
		lessontoggles.GetOrAddComponent<RectTransform>().sizeDelta= new Vector2(1000,650);
		lessontoggles.GetComponent<RectTransform>().pivot=new Vector2(0,0);
		lessontoggles.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        lessontoggles.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
		lessontoggles.GetComponent<RectTransform>().localPosition=new Vector3(0,-650,0);
		scrollview.GetComponent<ScrollRect>().content=lessontoggles.GetComponent<RectTransform>();
        scrollview.GetComponent<ScrollRect>().movementType=ScrollRect.MovementType.Clamped;
/*
		GameObject scrollrectgo = new GameObject("Scrollrect");
		scrollrectgo.transform.SetParent(lessongo.transform, false);
		scrollrectgo.GetOrAddComponent<RectTransform>().pivot=new Vector2(0,1);
		scrollrectgo.GetComponent<RectTransform>().anchoredPosition=new Vector2(50,700);
		scrollrectgo.GetComponent<RectTransform>().sizeDelta=new Vector2(1000,450);
		ScrollRect scrollrect = scrollrectgo.AddComponent<ScrollRect>();
		scrollrect.horizontal=false;
		//scrollrect
		scrollrect.content=lessontoggles.GetComponent<RectTransform>();

		GameObject scrollbargo = new GameObject("Scrollbar");
		scrollbargo.transform.SetParent(scrollrectgo.transform, false);
		Image scrollbarimage= scrollbargo.AddComponent<Image>();
		scrollbargo.GetOrAddComponent<RectTransform>().sizeDelta = new Vector2(20,450);
		scrollbargo.GetOrAddComponent<RectTransform>().anchoredPosition = new Vector2(980,0);

		GameObject slidingarea = new GameObject("Sliding Area");
		slidingarea.transform.SetParent(scrollbargo.transform, false);
		//slidingarea.GetOrAddComponent<RectTransform>().pivot=new Vector2(.5,.5);
		GameObject handle = new GameObject("Handle");
		handle.transform.SetParent(slidingarea.transform, false);
		handle.AddComponent<Image>().sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");


		scrollbarimage.sprite=AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
		Scrollbar scrollbar = scrollbargo.AddComponent<Scrollbar>();
		scrollbar.transform.SetParent(scrollrectgo.transform, false);
		scrollrect.verticalScrollbar = scrollbar;
		scrollbar.navigation= no_nav;
*/
        int column = 0;
        int row = 0;
        for (int x = 0; x < signarray.GetLength(0); x++) //this is the main loop that processes the array and creates + organizes the buttons in rows+columns.
        {
            if (x != 0)
            {
                if(x%2==0){
                column = 0;
                row++;
                }else{
                column=1;

                }
/*
                if (x % 15 == 0) //15  per column
                {
                    column++;
                    row = 0;
                }*/
            }

            //create the sign trigger helper first otherwise toggle has no target
            GameObject go = new GameObject(lang + " L" + (lessonnum + 1) + " - S" + (x + 1) + "(" + signarray[x, 0] + ") - Trigger");//helper gameobject with vrc_trigger. needed for toggle?
            go.transform.SetParent(lessontriggers.transform, false);
            go.layer = layer;
            go.AddComponent<VRC_Trigger>();

            VRC_Trigger trigComponent = go.AddComponent<VRC_Trigger>();
            VRC_Trigger.TriggerEvent customTrig = new VRC_Trigger.TriggerEvent();
            customTrig.BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne;
            customTrig.TriggerType = VRC_Trigger.TriggerType.OnEnable;
            customTrig.TriggerIndividuals = true;

            VRC_EventHandler.VrcEvent eventAction;
            eventAction = new VRC_EventHandler.VrcEvent();
            eventAction.EventType = VRC_EventHandler.VrcEventType.SetUIText;
            eventAction.ParameterString = signarray[x, 0] + "\n" + signarray[x, 1] + "\n" + signarray[x, 2];
            eventAction.ParameterObjects = new GameObject[]{ldisplaytext, rdisplaytext, podiumdisplaytext, tablettext};

            customTrig.Events.Add(eventAction); //this eventaction sets uitext on current sign text

            trigComponent.Triggers.Add(customTrig); //adds all event actions to the trigger for this helper gameobject.
            go.SetActive(false); //disables the gameobject since the UI toggle with enable them to activate the triggers.

            //declare toggle resource settings
            DefaultControls.Resources toggleresources = new DefaultControls.Resources();
            //Set the Toggle Background Image someBgSprite;
            toggleresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/InputFieldBackground.psd");
            //Set the Toggle Checkmark Image someCheckmarkSprite;
            toggleresources.checkmark = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/VRCSDK/Dependencies/VRChat/Resources/PerformanceIcons/Perf_Great_32.png");
            GameObject uiToggle = DefaultControls.CreateToggle(toggleresources);
            Toggle t = uiToggle.GetOrAddComponent<Toggle>();
            uiToggle.name = lang+" L" + (lessonnum+1) + " - S" + (x+1) +"("+signarray[x,0]+") - Toggle";
            uiToggle.transform.SetParent(lessontoggles.transform, false);
            uiToggle.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
            uiToggle.GetComponent<RectTransform>().anchoredPosition = new Vector2((50 + (column * columnseperation)), (-40 + (row * -rowseperation)));
            //Debug.Log("Position: " + column + ", " + row + ", arraynum" + x + " ArrayValue: " + lesson1signarray[x] + " pos: " + (70 +(column*1000)) + "," + (1400+(row*-150)));
            uiToggle.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
            uiToggle.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
            uiToggle.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
            uiToggle.layer = layer;
            t.navigation = no_nav;
            t.isOn = false;
            t.transition = Selectable.Transition.None;
            t.toggleTransition = Toggle.ToggleTransition.None;
            t.group = rootcanvas.GetComponent<ToggleGroup>();
            t.onValueChanged = new Toggle.ToggleEvent();

            UnityEventTools.AddPersistentListener(t.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), go, "SetActive") as UnityAction<bool>);

			uiToggle.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = new Vector2 (40, 40);
			uiToggle.transform.Find("Background").GetComponent<RectTransform>().anchoredPosition = new Vector2 (-20,-20);
			uiToggle.transform.Find("Background").GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.layer=layer;
			GameObject checkboxtextgo = new GameObject("Text");

			checkboxtextgo.transform.SetParent(uiToggle.transform.Find("Background").transform, false);
			Text checkboxtext = checkboxtextgo.AddComponent<Text>();
			checkboxtextgo.GetComponent<RectTransform>().sizeDelta= new Vector2(0,0);
			checkboxtextgo.GetComponent<RectTransform>().anchorMax = new Vector2 (1, 1);
			checkboxtextgo.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			checkboxtextgo.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);

			checkboxtext.alignment = TextAnchor.MiddleCenter;
			checkboxtext.text=(x+1)+"";
			checkboxtext.color = Color.black;
			checkboxtext.fontSize = 25;

			uiToggle.transform.Find("Label").GetComponent<Text>().text =" "+signarray[x,0];
			uiToggle.transform.Find("Label").GetComponent<Text>().fontSize = 25;
			uiToggle.transform.Find("Label").GetComponent<Text>().alignment = TextAnchor.MiddleLeft;

			uiToggle.transform.Find("Label").GetComponent<Text>().resizeTextForBestFit=true;
			uiToggle.transform.Find("Label").GetComponent<Text>().resizeTextMaxSize=25;
			uiToggle.transform.Find("Label").GetComponent<Text>().resizeTextMinSize=12;

            uiToggle.transform.Find("Label").GetComponent<RectTransform>().sizeDelta = new Vector2 (410, 40);
			uiToggle.transform.Find("Label").GetComponent<RectTransform>().anchoredPosition = new Vector2 (20,-20);
			uiToggle.transform.Find("Label").GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.layer=layer;

			uiToggle.transform.Find("Background").transform.Find("Checkmark").GetComponent<RectTransform>().sizeDelta = new Vector2 (40, 40);
			uiToggle.transform.Find("Background").transform.Find("Checkmark").GetComponent<RectTransform>().anchoredPosition = new Vector2 (0,0);
			uiToggle.transform.Find("Background").transform.Find("Checkmark").GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").transform.Find("Checkmark").GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").transform.Find("Checkmark").GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
            uiToggle.transform.Find("Background").transform.Find("Checkmark").GetComponent<Image> ().color = new Color(0,0,0,1);
			uiToggle.transform.Find("Background").gameObject.layer=layer;

            //row++;
        }
        //makes back button
        GameObject backtolessongo = createbutton2(lessongo, "Return to VR-" + lang + " Lesson Menu", 750, 50, 0, 0, 90, 50, 0, "Return to Lesson Menu", 25, 750, 50, 0, 0, TextAnchor.MiddleCenter, layer);
        Button b = backtolessongo.GetOrAddComponent<Button>();
        b.onClick = new Button.ButtonClickedEvent();

        //disable the current active lesson when clicked
        UnityAction<bool> disablecurrentlesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang + " Lesson " + (lessonnum + 1)), "SetActive") as UnityAction<bool>;
        UnityEventTools.AddBoolPersistentListener(b.onClick, disablecurrentlesson, false);

        //enable the lesson select
        UnityAction<bool> enablelessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang + " Lesson Menu"), "SetActive") as UnityAction<bool>;
        UnityEventTools.AddBoolPersistentListener(b.onClick, enablelessonmenu, true);
        lessongo.SetActive(false);
    }
}

#endif

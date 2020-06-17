using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using VRCSDK2;
using UnityEngine.Events;
using UnityEditor.Events;

public class HH_HQ : MonoBehaviour
{
    [MenuItem("ASLWorld/KoolaidButtons")]
    static void KoolaidButtons()
    {
        string[][,] ASLlessons = { //creates an array of arrays
			new string[,]{//lesson 1
            {"Hello/Hi","안녕하세요","Bonjour/Salut"},{"Bye","안녕(작별)","AuRevoir"},{"How","어떻게","Comment"},{"You","너","Toi/Tu"},{"How are you?","어떻게 지냈어?","Comment vas-tu?"},
            {"Nice","멋지다","Agréable"},{"Meet","만나다","Rencontrer"},{"Nice to meet you","만나서 반가워","Ravis de te rencontrer."},{"Good","좋아,훌륭해","Bon"},{"Bad","나빠","Mauvais"},
            {"Fine","괜찮아","Bien"},{"Who","누구","Qui"},{"What","무엇을","Quoi"},{"When","언제","Quand"},{"Where","어디","Où"},{"Why","왜","Pourquoi"},{"Which","어떤것","Lequel"},{"Understand","이해하다","Comprendre"},
            {"Don’t Understand","이해하지 못하다","Ne pas comprendre"},{"Yes","네,예","Oui"},{"No","아니","Non"},{"Please","제발,부디","S’il vous plaît"},{"Thanks","고마워","Merci"},{"Sorry","미안해","Désolé"},
            {"Deaf","청각장애인(농아인)","Sourd"},{"Hard of Hearing","난청인","Malententand"},{"Hearing","청력,청인","Entendant"},{"Mute","말을 못하다","Muet"}
            },
            new string[,]{//lesson 2
			{"Person","사람","Personne"},{"Learn","배우다","Apprendre"},{"Student","학생","Étudiant"},{"Teach","가르치다","Enseigner"},{"Teacher","선생님","Enseignant"},
            {"Friend","친구","Ami"},{"Slow","느리다","Lent"},{"Fast","빠르다","Rapide"},{"Like","좋다","Aimer"},{"Don’t Like","싫다","Ne pas aimer"},{"Want","원하다","Vouloir"},
            {"Don’t Want","원하지 않다","Ne pas vouloir"},{"Need","필요하다","Besoin"},{"Change","바꾸다","Changer"},{"Same","같다","Même"},{"Different","다르다","Different"},{"Can","할수있다","Pouvoir"},
            {"Can’t","못하다","Ne pas pouvoir"},{"Not","그것은 아니다","Pas"},{"Use","사용하다","Utiliser"},{"Follow","따라가다","Suivre"},{"Easy","쉽다","Facile"},{"Difficult","어렵다","Difficile"},
            {"Soft","부드럽다","Doux"},{"Hard","단단하다","Dure"},{"New","새롭다","Nouveau"},{"Old","나이,늙은","Vieux"},{"Much/Alot","많다","Beaucoup"}
            },
            new string[,]{//lesson 3
			{"Time","시간","Temps"},{"Tomorrow","내일","Demain"},{"Yesterday","어제","Hier"},{"Today","오늘","Aujourd'hui"},{"Second","초","Seconde"},{"Minute","분","Minute"},
            {"Hour","시, 1시간","Heure"},{"Day","하루","Journée"},{"Week","일주일","Semaine"},{"Month","개월,달","Mois"},{"Year","년도","Année"},{"Past","과거","Passé"},{"Future/Will","미래","Future"},
            {"Before","전에","Avant"},{"Now","지금","Maintenant"},{"After","후에","Après"},{"Someday/Eventually","언젠가/결국","un Jour/Éventuellement"},{"Everyday","매일","Tous les jours"},
            {"Next","다음","Suivant"},{"Done/Finished","완료","Termier"},{"Late","나중에","Tard"},{"Near","가깝다","Près"},
            {"Far","멀다","Loin"},{"House","집","Maison"},{"Home","집","Maison"},{"Live","살다","Vivre"},{"True/Sure/Real","진실,정말,진짜","Vrai"},{"Fake","거짓말,가짜","Faux"}
            },
            new string[,]{//lesson 4
			{"Normal","평범,보통","Normal"},{"Any","전혀,어느","N'importequel"},{"Continue","계속","Continuer"},{"Stay","계속있다,머물러있다","Rester"},{"Still","여전하다","Encore"},
            {"Copy","복사","Copier"},{"Notice","공지,안내","Remarquer"},{"Improve","개선","Ameliorer"},{"Gone","사라지다","Disparu"},{"Test","시험,테스트","Tester"},{"Visit","방문하다","Visiter"},
            {"With","와(과)함께","Avec"},{"Without","없이","Sans"},{"Away","없이떨어져/저리가!","Auloin"},{"Weird","기괴하다,이상하다","Bizarre"},{"Turn","돌다,돌리다","Tourner"},
            {"More Than","보다 많다","Plusque"},{"Less Than","보다 적다","Moinsque"},{"Correct","옳다,맞다","Correct"},{"High","높다","Haut"},{"Low","낮다","Bas"},{"Way","방식","Chemin"},{"Wish","원하다,바라다","Souhait"},
            {"Later","늦다","Tard"},{"Perfect","완벽하다","Parfait"},{"Fun","재미,재밌어","Amusant"},{"Every","모든,모두","Tout"},{"Funny","우습다,웃기다","Drôle"}
            },
            new string[,]{//lesson 5
			{"Jealous","질투","Jaloux"},{"Idea","아이디어,발상","Idée"},{"Mountain","산","Montagne"},{"Blame","탓하다","Accuser"},{"Babysitter","육아도우미","Gardienne d'enfants"},
            {"Behavior","행동","Agissement"},{"Butter","버터","Beurre"},{"Farm","농장","Ferme"},{"Fault","잘못","Faute"},{"Fall","떨어지다/빠지다","Tomber"},{"Man","남자","Homme"},
            {"Woman","여자","Femme"},{"Mom","엄마","Mère"},{"Dad","아빠","Père"},{"Uncle","삼촌","Oncle"},{"Aunt","고모,이모","Tante"},{"Grandma","할머니","Grand-mère"},{"Grandpa","할아버지","Grand-père"},
            {"Sister","언니,누나","Sœur"},{"Brother","오빠,형","Frère"},{"Kid","꼬마,어린이","Enfant"},{"Sunday","일요일","Dimanche"},{"Monday","월요일","Lundi"},
            {"Tuesday","화요일","Mardi"},{"Wednesday","수요일","Mercredi"},{"Thursday","목요일","Jeudi"},{"Friday","금요일","Vendredi"},{"Saturday","토요일","Samedi"}
            },
            new string[,]{//lesson 6
			{"Account","계좌","Compte"},{"Abandon","버리다","Abandonner"},{"Balance","균형(상태)","Balancer"},{"Bath","목욕","Bain"},{"Excited","야구","Excité"},{"Because","때문에,왜냐면","Parce que"},
            {"Become","되다","Devenir"},{"Call","부르다","Appeler"},{"Careful","조심하다","Prudent"},{"Choose","선택하다","Choisir"},{"Red","빨간색","Rouge"},{"Blue","파랑색","Bleu"},{"Green","초록색","Vert"},
            {"Yellow","노란색","Jaune"},{"Orange","주황색","Orange"},{"Purple","보라색","Purple"},{"Pink","분홍색","Rose"},{"Black","검은색","Noir"},{"White","하얀색","Blanc"},{"Grey","회색","Gris"},
            {"Brown","갈색","Brun"},{"Tan","황갈색,선탠","Hâlé"},{"Gold","골드,황금색","Or"},{"Silver","실버,은색","Argent"},
            {"Bright-(Color)","밝다","Brillant"},{"Shiny-(Color)","빛나다,반짝이다","Étincelant"},{"Light-(Color)","연하다","Clair"},{"Dark-(Color)","어둡다","Foncé"}
            },
            new string[,]{//lesson 7
			{"Fly","날다","Voler"},{"Schedule","일정,스케줄","Emploi du temps"},{"Frustrated","좌절하다","Frustré"},{"Don’t Worry","걱정마세요","Ne t'inquiète pas"},{"Embarrassed","당황하다","Embarassé"},
            {"Polite","공손하다","Poli"},{"Rude","무례하다","Rude"},{"Strong","강하다","Fort"},{"Brave","용감하다,용기 있는","Brave"},{"Experience","경험하다,체험하다","Expérience"},{"Expensive","비싸다","Coûteux"},
            {"Curious","궁금하다,호기심이많다","Curieux"},{"Money","돈","Argent"},{"Lazy","게으른다","Lâche"},{"Hungry","배고프다","Faim"},{"Important","중요하다","Important"},{"Family","가족","Famille"},
            {"Worry","걱정하다","Inquiêtude"},{"Worse","더나쁘다,심하다","Pire"},{"Here","여기,여기서","Ici"},{"Area","지역(구역)","Zone"},{"E-Mail","전자메일(이메일)","Courriel"},{"Discord","디스코드","Discorde"},
            {"Drama","드라마","Drame"},{"Hot","뜨겁다,덥다","Chaud"},{"Cold","차갑다,춥다","Froid"},{"Music","음악","Musique"},{"Avatar","아바타","Avatar"}
            },
            new string[,]{//lesson 8
			{"Cochlear Implant","인공와우","Implant Cochéaire"},{"Hearing Aid","보청기","Aide auditoire"},{"Disorder","엉망,어수선,장애","Désordre"},{"Together","함께하다","Ensemble"},
            {"Nothing","아무것도 아니다","Rien"},{"Selective Mutism","불안장애","Mustisme sélectif"},{"Restaurant","레스토랑,식당","Restaurant"},{"Order","주문,질서","Ordre"},{"Serve","제공,서비스","Service"},
            {"Buy","구매,사다","Acheter"},{"Sell","팔다","Vendre"},{"Taco","타코","Taco"},{"Burrito","브리또","Burrito"},{"Hamburger","햄버거","Hamburger"},{"Spaghetti","스파게티","Spaghetti"},{"Pizza","피자","Pizza"},
            {"IceCream","아이스크림","Crème glacée"},{"Cake","케이크","Gâteaux"},{"Cookie","과자/쿠키","Biscuit"},{"Police","경찰","Police"},{"FireMan","소방관","Pompier"},{"Doctor","의사","Docteur"},
            {"Wonder","궁금하다","Se demander"},{"Water","물","Eau"},{"Flower","꽃","Fleur"},{"Tree","나무","Arbre"},{"Sea","바다","Océan"},{"Rock","바위","Roche"}
            },
            new string[,]{//lesson 9
            {"Forgive","용서","Pardonner"},{"Leave","떠나다","Partir"},{"Ready","준비","Prêt"},{"Skill","솜씨,기술","Abilité"},{"Joke","농담","Blague"},{"Mistake","실수","Erreur"},
            {"Move","행동","Bouger"},{"Lost","잃다","Perdu"},{"Work","일하다","Travail"},{"Talk","말하다","Parler"},{"Not Yet","아직","Pas encore"},{"Equal","동등하다","Égal"},
            {"Number","숫자,번호","Nombre"},{"Letter","편지","Lettre"},{"Place","장소","Lieu"},{"Start","시작","Commencer"},{"Say/Tell","말하다","Dire"},{"Fill","채우다","Remplir"},
            {"Tea","차/찻잎","Thé"},{"Come","오다","Venir"},{"Bring","가져오다","Apporter"},{"Explain","설명","Expliquer"},{"Size","크기,사이즈","Taille"},
            {"Retreat","물러가다,후퇴","Fuir"},{"Return","반환,반납","Retourner"},{"Taste","맛(미각)","Goût"},{"Enjoy","즐기다","Apprécier"},{"Reason","이유","Raison"}
            },
            new string[,]{//lesson 10
            {"Kind/Type","종류/형태","Sorte/Type"},{"Limit","제한","Limite"},{"Have","가지다","Avoir"},{"Plan","계획","Plan"},{"Won","이기다","Gagné"},{"Lost","지다","Perdu"},
            {"Decide","결정","Décider"},{"Keep","지키다","Garder"},{"Act","행동","Agir"},{"Guess","추측","Deviner"},{"Search","찾다,검색","Chercher"},{"Lock","잠그다","Verrouiller"},
            {"Listen","듣다","Écouter"},{"Special","특별하다,특히","Spéciale"},{"Favor","친절","Faveur"},{"Owe/Debt","빚지다,부채","Dette"},{"Argue","다투다","Argumenter"},{"Wonder","궁금하다","Se questionner"},
            {"Join","가입","Joindre"},{"Realize","깨닫다","Réaliser"},{"Animal","동물","Animale"},{"Skip","넘어가다","Passer"},{"Calm","차분하다,침착하다","Calme"},
            {"Progress","진행하다","Progrès"},{"Option","반대","Option"},{"Annoy","짜증","Embêter"},{"Opposite","반대로","Opposer"},{"Satisfy","만족,충족시키다","Satisfaire"}
            },
            new string[,]{//lesson 11
            {"Over","지나치다,과하다","Sur"},{"Holiday","휴일","Temps des fêtes"},{"Freeze","얼다,얼음","Geler"},{"Discuss","상의","Discuter"},{"Rule","규칙","Règle"},
            {"Awkward","어색하다","Gênant"},{"Strange","낯설다","Étrange"},{"Bored","심심하다","Ennuyant"},{"Hurt","아프다","Douleur"},{"Love","사랑","Amour"},{"Silly","바보","Ridicule"},
            {"Damaged","손해,피해","Endommager"},{"Jail","감옥","Prison"},{"Show","보여주다","Montrer"},{"Dress","드레스","Robe"},{"Pants","바지","Pantalon"},{"Shoes","신발","Chaussures"},
            {"Shirt","셔츠","Chandail"},{"Bed","침대","Lit"},{"Sleep","자다","Dormir"},{"Drink","마시다","Boire"},{"Sit","앉다","S'assoir"},{"Stand","서다","Se tenir debout"},
            {"Jump","뛰다","Sauter"},{"Picture","사진","Photo"},{"Happen","우연히","Se produire"},{"Communicate","의사소통","Communiquer"},{"Play","놀다","Jouer"}
            },
            new string[,]{//lesson 12
            {"End","끝","Terminer"},{"Confused","혼란","Confus"},{"Empty","비다","Vide"},{"Touch","만지다","Toucher"},{"Car","자동차","Voiture"},{"Drive","운전하다","Conduire"},
            {"Above","보다위에","Au dessus"},{"Stop","정지","Arrêt"},{"Hate","미워","Haïr"},{"Run","달리다","Courir"},{"Walk","걷다","Marcher"},{"Story","이야기","Histoire"},{"Promise","약속","Promettre"},
            {"Help","돕다","Aider"},{"Agree","동의하다","Être en accord"},{"Disagree","동의하지 않다","Être en désaccord"},{"Add","더하다","Ajouter"},{"Trust","신뢰","Faire Confiance"},
            {"Trouble","곤란","Trouble"},{"Gain","얻다","Prendre"},{"Challenge","도전","Défier"},{"Replace","대신,교체","Remplacer"},
            {"Proud","자랑스럽다","Fier"},{"Expert","전문가","Expert"},{"Soda","탄산음료","Soda"},{"Eat","먹다","Manger"},{"Food","음식","Nourriture"},{"Name","이름","Nom"}
            },
            new string[,]{//lesson 13
            {"Big/Huge","크다","Gros/Grand"},{"Small","작다","Petit"},{"Beautiful","아름답다","Beau/Belle"},{"Ugly","못생기다","Laid"},{"Fat","뚱뚱하다","Gras"},
            {"Skinny","날씬하다","Mince"},{"Weak","약하다","Faible"},{"Health","건강","Santé"},{"Medicine","약","Médicament"},{"Build","짓다","Construire"},{"Break","부러지다","Briser"},
            {"Make","만들다","Faire"},{"Find","찾다","Trouver"},{"Bully","괴롭히다","Intimider"},{"Insult","모욕","Insulter"},{"Simple","간단하다","Simple"},{"Complicated","복잡하다","Compliqué"},
            {"Open","열다","Ouvert"},{"Close","닫다","Fermer"},{"Hit","때리다","Frapper"},{"Meat","고기","Viande"},{"Bread","빵","Pain"},{"Chips","과자","Croustilles"},{"Melon","메론","Melon"},
            {"Event","행사","Évênement"},{"Socialize","사교","Socialiser"},{"Hangout/chill","쌀쌀하다","Trainer/Ensemble"},{"Relax","편하게하다","Relaxer"}
            },
            new string[,]{//lesson 14
            {"Under","아래","En dessous"},{"Private/Secret","개인/비밀","Privé/Secret"},{"Emergency","비상/사태","Urgence"},{"Favorite","마음에 들다","Favori"},{"Class","수업","Classe"},
            {"Proof","증명,증거","Preuve"},{"Switch","스위치","Transférer"},{"Angry","화나다","Faché"},{"Store","상점,가게","Magasin"},{"Respect","존경","Respect"},{"Ask","물어보다","Demander"},
            {"Suggest","제안","Suggerer"},{"Trash","쓰레기","Déchet"},{"Clean","깨끗하다","Propre"},{"Age","나이","Age"},{"Try","노력","Éssayer"},{"Pay","지불","Payer"},
            {"Hide","감추다,숨다","Cacher"},{"Random","무작위","Aléatoire"},{"Flag","깃발","Drapeau"},{"Judge","심판","Juge"},{"Warn","경고","Avertissement"},{"See","보다","Voir"},
            {"Collect","수집","Collecte"},{"Some/Part","일부,부분","Quelque"},{"Goal","목표","But"},{"Pet","애완동물","Animale de Compagnie"},{"Communicate","소통하다","Communiquer"}
            },
            new string[,]{//lesson 15
            {"Yesterday I worked 6 hours.","어제 나는 6시간 일했다.","Hier, j'ai travaillé 6 heures."},{"I think that you are a great friend.","나는 네가 좋은 친구라고 생각해.","Je pense que tu es un bon ami."},
            {"Do you work or have school?","너는 일하니 아니면학교니?","Est-ce que tu travailles ou vas à l'école?"},{"I went to the hospital, but don't worry.","병원에 갔지만 걱정하지마.","Je suis allé à l'hôpital,mais ne tèinquiète pas."},
            {"All the food at the store was gone.","가게의 모든 음식은사 라졌다.","Toute la nourriture au magasin était parti."},{"Please repeat, I am a new student.","반복해줘,나는 새로운 학생입니다.","Répète s'il te plait,je suis un nouvel étudiant."},
            {"I don't understand a lot, but I am improving.","많이 이해하지는 못하지만, 발전하고 있어.","Je ne comprend pas beaucoup mais je m'améliore."},{"Where is the teacher?","선생님은 어디 계시니?","Où est l'enseignant?"},
            {"I don't like drama.","나는 드라마를 좋아하지 않는다.","Je n'aime pas le drame."},{"What did you do today?","오늘 뭐했어?","Qu'as-tu fait aujourd'hui?"},{"What is your favorite food?","가장 좋아하는 음식이 무엇입니까?","Quelle est ta nourriture préféré?"},
            {"Where can I learn more sign?","더많은 수화를 어디서배울수 있니?","Où puis-je apprendre plus de signes?"},{"Are you alright? What happened?","괜찮아? 어떻게 된 거야?","Est-ce que çava? Que s'est-t'il passé?"},
            {"I like turtles.","나는 거북이를 좋아한다.","J'aime les tortues."},{"I love Deaf culture!","나는 청각장애인 문화를 좋아해!","J'aime la cultures des sourds."},{"You're a great person!","넌 훌륭한 사람이야!","Tu es une bonne personne."},
            {"I like to eat bread.","나는 빵 먹는 것을 좋아한다.","J'aime manger du pain."},{"I hate taking pictures.","나는 사진찍는 것을싫어한다.","Je déteste prendre des photos."},{"I respect my friends.","나는 내친구들을 존중합니다.","Je respect mes amis."},
            {"Do you understand, need me to repeat?","알아들었어? 반복할 필요가 있어?","Est-ce que tu comprends, besoin de répéter?"},{"I cannot hear,I am Deaf.","나는 들을 수 없다. 나는 청각장애인이다.","Je ne peux pas entendre,je suis sourd."},
            {"I need an interpreter, who can help me?","통역사가 필요해, 누가 날 도와줄 수 있지?","J'ai besoin d'un interprètre, qui peut m'aider?"},{"Are you Deaf, mute, hard of hearing, hearing?","청각장애인? 말을못해? 난청인? 청인?","Es-tu sourd, muet, malentendant ou entendant?"},
            {"Are you streaming on youtube or twitch?","유투브 or 트위치에서 스트리밍하고 있니?","Est-ce que tu diffuses sur youtube ou twitch?"},{"I don't like running.","나는 달리기를 좋아하지 않는다.","Je n'aime pas courir."},{"Can you lock that door?","문을 잠글수 있니?","Peux-tu verrouiller cette porte?"},
            {"I feel sick, I need to rest.","몸이 아파서 쉬어야겠어.","Je me sens malade, j'ai besoin de me reposer."},{"Please stop doing that, it's rude.","제발 그렇게하지 마, 무례한 짓이야.","S'il te plait arrête de faire ça, c'est rude."}
            },
            new string[,]{//lesson 16
            {"Door","문","Porte"},{"Dangerous","위험하다","Dangereux"},{"Barrow","빌리다","Brouette"},{"Army","군대","Armée"},{"Group","그룹,모임","Groupe"},{"Team","팀","Équipe"},
            {"Alright","괜찮다","Bien"},{"Gross","역겹다","Dégueux"},{"Feel","느끼다","Sentir"},{"Depression","우울증","Depression"},{"Anxiety/anxious","불안","Anxiété"},{"Nervous","긴장하다","Nerveux"},
            {"Kiss","키스,뽀뽀","Embrasser"},{"Date","날짜","Date"},{"Sweetheart","애인,연인","Cœurtendre"},{"Fall in love","사랑에 빠진다","Tomber en amour"},{"Just/Only","그냥/오직","Seulement"},
            {"Sneeze","재채기","Éternuer"},{"Cough","기침","Tousser"},{"Blessyou","축복하다","À tes souhaits"},{"University","종합대학","Université"},{"Church","교회","Église"},{"Library","도서관","Bibliothèque"},
            {"Office","사무실","Bureau"},{"Fancy","공상","Qualité supérieure"},{"College","전문대학","Collège"},{"Gym","체육관","Gymnase"},{"Workout","운동","Exercicer"}
            }/*if this is the last lesson, don't put a comma after the } 

				*/
        };
        string[] lessonnames = new string[]{//array of lesson names - I guess rename to Lesson 1, Lesson 2 and so on if you don't have names
		"Lesson 1","Lesson 2","Lesson 3","Lesson 4","Lesson 5","Lesson 6","Lesson 7","Lesson 8","Lesson 9","Lesson 10","Lesson 11","Lesson 12","Lesson 13","Lesson 14","15) Sentences","Lesson 16","Lesson 17","Lesson 18","Lesson 19","Lesson 20"};

        int layer = 0;
        int rowoffset = 650;
        int columnoffset = 100;

        int projectionsizex = 5000;
        int projectionsizey = 4000;

        int teachermenusizex = 1100;
        int teachermenusizey = 750;
        DefaultControls.Resources resources = new DefaultControls.Resources();

        GameObject menuroot = new GameObject("HH Root"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
        menuroot.transform.position = new Vector3(0, 0, 0);
        menuroot.layer = layer;
        GameObject rootcanvas = createandreturncanvas("Menu Canvas", menuroot, teachermenusizex, teachermenusizey, layer);
        rootcanvas.transform.position = new Vector3(-18.653f, -2.585f, -2.178f);

        //rootcanvas.GetComponent<RectTransform> ().localScale=new Vector3(.0004149436f,.0007330904f,.001f);
        GameObject menupanel= createpanel(rootcanvas, teachermenusizex, teachermenusizey, layer); //Creates panel under rootcanvas.
        menupanel.name="Menu Panel";

        GameObject podiumpanel = createpanel(rootcanvas, teachermenusizex, 200, layer); //Creates panel under rootcanvas.
        podiumpanel.name="Podium Panel";
        podiumpanel.GetComponent<Image>().color = new Color32(0x21, 0x21, 0x21, 0xFF);
        podiumpanel.GetComponent<RectTransform>().localPosition=new Vector3(0,550,100);
        GameObject podiumtext = DefaultControls.CreateText(resources);
        podiumtext.transform.SetParent(podiumpanel.transform, false);
        podiumtext.name = "DisplayText";
        podiumtext.layer = layer;
        podiumtext.GetComponent<Text>().text = "Welcome to the Helping Hands Headquarters!\n돕는 손 본부에 오신 것을 환영합니다!\nBienvenue au siège social de Helping Hands!";
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
        

        GameObject displaycanvas = createandreturncanvas("MainDisplay", menuroot, projectionsizex, projectionsizey, layer);

        displaycanvas.transform.position = new Vector3(-19.881f, -1.307f, -1.453f);
        //displaycanvas.GetComponent<RectTransform> ().localScale=new Vector3(.0007777605f,.0008309863f,.001f);
        GameObject maindisplaypanel = createpanel(displaycanvas, projectionsizex, projectionsizey, layer);
        maindisplaypanel.GetComponent<Image>().color = new Color32(0x21, 0x21, 0x21, 0xFF);
        GameObject maindisplay = GameObject.Find("/HH Root/MainDisplay/Panel");
        maindisplay.GetComponent<Image>().raycastTarget = false;
        GraphicRaycaster deletethisgraphicraycaster = GameObject.Find("/HH Root/MainDisplay").GetComponent<GraphicRaycaster>();
        DestroyImmediate(deletethisgraphicraycaster);
        VRC_UiShape deletethisvrcuishape = GameObject.Find("/HH Root/MainDisplay").GetComponent<VRC_UiShape>();
        DestroyImmediate(deletethisvrcuishape);
        ToggleGroup deletethistogglegroup = GameObject.Find("/HH Root/MainDisplay").GetComponent<ToggleGroup>();
        DestroyImmediate(deletethistogglegroup);

        
        GameObject displaytext = DefaultControls.CreateText(resources);
        displaytext.transform.SetParent(displaycanvas.transform, false);
        displaytext.name = "DisplayText";
        displaytext.layer = layer;
        displaytext.GetComponent<Text>().text = "Welcome to Helping Hands Headquarters!";
        displaytext.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font; //change font file here
        displaytext.GetComponent<Text>().fontStyle = FontStyle.Bold;
        displaytext.GetComponent<Text>().fontSize = 300;
        //displaytext.GetComponent<Text> ().color = Color.black; 
        displaytext.GetComponent<Text>().color = new Color32(0x6D, 0x9E, 0xEB, 0xFF); // RGBA
        displaytext.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        displaytext.GetComponent<RectTransform>().sizeDelta = new Vector2(projectionsizex, projectionsizey);
        displaytext.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        displaytext.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
        displaytext.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        displaytext.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        displaytext.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);


        GameObject aslroot = new GameObject("ASL Root");
        aslroot.transform.SetParent(rootcanvas.transform, false);
        GameObject asllessonmenu = new GameObject("ASL Lesson Menu");
        asllessonmenu.transform.SetParent(rootcanvas.transform, false);
        asllessonmenu.layer = layer;
        for (int x = 0; x < ASLlessons.Length; x++)
        {
            createlessonboard(aslroot, ASLlessons[x],lessonnames, "ASL", x, rootcanvas, rowoffset, columnoffset, 40, 450, layer);//Loops and creates lesson boards for all initialized lessons in the lessonarray.
        }
        createmenu(aslroot, "ASL", ASLlessons, lessonnames, asllessonmenu, teachermenusizex, teachermenusizey, 300, 40, (teachermenusizey - 100), 80, 40, 300, layer); //creates the lesson chooser menu

        rootcanvas.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 90, 0);//x,y,z
        displaycanvas.GetComponent<RectTransform>().eulerAngles = new Vector3(0, -90, 0);//x,y,z
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

		

    DefaultControls.Resources scrollviewresources = new DefaultControls.Resources();
    //Set the Slider Background Image someBgSprite;
    scrollviewresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
    //Set the Slider Fill Image someFillSprite;
    scrollviewresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
    //Set the Slider Knob Image someKnobSprite;
    scrollviewresources.knob = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd");
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
            eventAction.ParameterObjects = new GameObject[]{GameObject.Find("/HH Root/MainDisplay/DisplayText"),GameObject.Find("/HH Root/Menu Canvas/Podium Panel/DisplayText")};
            
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
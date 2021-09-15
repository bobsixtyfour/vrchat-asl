using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using System;
using TMPro;
using VRC.SDK3.Components.Video;
using VRC.SDK3.Video.Components;
using VRC.SDK3.Video.Components.AVPro;
using VRC.SDK3.Video.Components.Base;


#if !COMPILER_UDONSHARP && UNITY_EDITOR
using System.Linq; //for sorting
using System.Collections.Generic; //for lists if I ever use em.
using UnityEditor;
using UdonSharpEditor;
#endif


public class MenuControl : UdonSharpBehaviour
{
    /*
     lessons[x]=lesson number
     lessons[x][y]=word number
     lessons[x][y][z]=translation
     */
    string[][][] Lessons = { //creates an array of arrays
      new string[][] { //lesson 1
        new string[] {
            "Hello/Hi",
            "안녕하세요",
            "Bonjour/Salut"
          },
          new string[] {
            "Bye",
            "안녕(작별)",
            "AuRevoir"
          },
          new string[] {
            "How",
            "어떻게",
            "Comment"
          },
          new string[] {
            "You",
            "너",
            "Toi/Tu"
          },
          new string[] {
            "How are you?",
            "어떻게 지냈어?",
            "Comment vas-tu?"
          },
          new string[] {
            "Nice",
            "멋지다",
            "Agréable"
          },
          new string[] {
            "Meet",
            "만나다",
            "Rencontrer"
          },
          new string[] {
            "Nice to meet you",
            "만나서 반가워",
            "Ravis de te rencontrer."
          },
          new string[] {
            "Good",
            "좋아,훌륭해",
            "Bon"
          },
          new string[] {
            "Bad",
            "나빠",
            "Mauvais"
          },
          new string[] {
            "Fine",
            "괜찮아",
            "Bien"
          },
          new string[] {
            "Who",
            "누구",
            "Qui"
          },
          new string[] {
            "What",
            "무엇을",
            "Quoi"
          },
          new string[] {
            "When",
            "언제",
            "Quand"
          },
          new string[] {
            "Where",
            "어디",
            "Où"
          },
          new string[] {
            "Why",
            "왜",
            "Pourquoi"
          },
          new string[] {
            "Which",
            "어떤것",
            "Lequel"
          },
          new string[] {
            "Understand",
            "이해하다",
            "Comprendre"
          },
          new string[] {
            "Don’t Understand",
            "이해하지 못하다",
            "Ne pas comprendre"
          },
          new string[] {
            "Yes",
            "네,예",
            "Oui"
          },
          new string[] {
            "No",
            "아니",
            "Non"
          },
          new string[] {
            "Please",
            "제발,부디",
            "S’il vous plaît"
          },
          new string[] {
            "Thanks",
            "고마워",
            "Merci"
          },
          new string[] {
            "Sorry",
            "미안해",
            "Désolé"
          },
          new string[] {
            "Deaf",
            "청각장애인(농아인)",
            "Sourd"
          },
          new string[] {
            "Hard of Hearing",
            "난청인",
            "Malententand"
          },
          new string[] {
            "Hearing",
            "청력,청인",
            "Entendant"
          },
          new string[] {
            "Mute",
            "말을 못하다",
            "Muet"
          }
      },
      new string[][] { //lesson 2
        new string[] {
            "Person",
            "사람",
            "Personne"
          },
          new string[] {
            "Learn",
            "배우다",
            "Apprendre"
          },
          new string[] {
            "Student",
            "학생",
            "Étudiant"
          },
          new string[] {
            "Teach",
            "가르치다",
            "Enseigner"
          },
          new string[] {
            "Teacher",
            "선생님",
            "Enseignant"
          },
          new string[] {
            "Friend",
            "친구",
            "Ami"
          },
          new string[] {
            "Slow",
            "느리다",
            "Lent"
          },
          new string[] {
            "Fast",
            "빠르다",
            "Rapide"
          },
          new string[] {
            "Like",
            "좋다",
            "Aimer"
          },
          new string[] {
            "Don’t Like",
            "싫다",
            "Ne pas aimer"
          },
          new string[] {
            "Want",
            "원하다",
            "Vouloir"
          },
          new string[] {
            "Don’t Want",
            "원하지 않다",
            "Ne pas vouloir"
          },
          new string[] {
            "Need",
            "필요하다",
            "Besoin"
          },
          new string[] {
            "Change",
            "바꾸다",
            "Changer"
          },
          new string[] {
            "Same",
            "같다",
            "Même"
          },
          new string[] {
            "Different",
            "다르다",
            "Different"
          },
          new string[] {
            "Can",
            "할수있다",
            "Pouvoir"
          },
          new string[] {
            "Can’t",
            "못하다",
            "Ne pas pouvoir"
          },
          new string[] {
            "Not",
            "그것은 아니다",
            "Pas"
          },
          new string[] {
            "Use",
            "사용하다",
            "Utiliser"
          },
          new string[] {
            "Follow",
            "따라가다",
            "Suivre"
          },
          new string[] {
            "Easy",
            "쉽다",
            "Facile"
          },
          new string[] {
            "Difficult",
            "어렵다",
            "Difficile"
          },
          new string[] {
            "Soft",
            "부드럽다",
            "Doux"
          },
          new string[] {
            "Hard",
            "단단하다",
            "Dure"
          },
          new string[] {
            "New",
            "새롭다",
            "Nouveau"
          },
          new string[] {
            "Old",
            "나이,늙은",
            "Vieux"
          },
          new string[] {
            "Much/Alot",
            "많다",
            "Beaucoup"
          }
      },
      new string[][] { //lesson 3
        new string[] {
          "Time",
          "시간",
          "Temps"
        },
        new string[] {
            "Tomorrow",
            "내일",
            "Demain"
          },
          new string[] {
            "Yesterday",
            "어제",
            "Hier"
          },
          new string[] {
            "Today",
            "오늘",
            "Aujourd'hui"
          },
          new string[] {
            "Second",
            "초",
            "Seconde"
          },
          new string[] {
            "Minute",
            "분",
            "Minute"
          },
          new string[] {
            "Hour",
            "시, 1시간",
            "Heure"
          },
          new string[] {
            "Day",
            "하루",
            "Journée"
          },
          new string[] {
            "Week",
            "일주일",
            "Semaine"
          },
          new string[] {
            "Month",
            "개월,달",
            "Mois"
          },
          new string[] {
            "Year",
            "년도",
            "Année"
          },
          new string[] {
            "Past",
            "과거",
            "Passé"
          },
          new string[] {
            "Future/Will",
            "미래",
            "Future"
          },
          new string[] {
            "Before",
            "전에",
            "Avant"
          },
          new string[] {
            "Now",
            "지금",
            "Maintenant"
          },
          new string[] {
            "After",
            "후에",
            "Après"
          },
          new string[] {
            "Someday/Eventually",
            "언젠가/결국",
            "un Jour/Éventuellement"
          },
          new string[] {
            "Everyday",
            "매일",
            "Tous les jours"
          },
          new string[] {
            "Next",
            "다음",
            "Suivant"
          },
          new string[] {
            "Done/Finished",
            "완료",
            "Termier"
          },
          new string[] {
            "Late",
            "나중에",
            "Tard"
          },
          new string[] {
            "Near",
            "가깝다",
            "Près"
          },
          new string[] {
            "Far",
            "멀다",
            "Loin"
          },
          new string[] {
            "House",
            "집",
            "Maison"
          },
          new string[] {
            "Home",
            "집",
            "Maison"
          },
          new string[] {
            "Live",
            "살다",
            "Vivre"
          },
          new string[] {
            "True/Sure/Real",
            "진실,정말,진짜",
            "Vrai"
          },
          new string[] {
            "Fake",
            "거짓말,가짜",
            "Faux"
          }
      },
      new string[][] { //lesson 4
        new string[] {
            "Normal",
            "평범,보통",
            "Normal"
          },
          new string[] {
            "Any",
            "전혀,어느",
            "N'importequel"
          },
          new string[] {
            "Continue",
            "계속",
            "Continuer"
          },
          new string[] {
            "Stay",
            "계속있다,머물러있다",
            "Rester"
          },
          new string[] {
            "Still",
            "여전하다",
            "Encore"
          },
          new string[] {
            "Copy",
            "복사",
            "Copier"
          },
          new string[] {
            "Notice",
            "공지,안내",
            "Remarquer"
          },
          new string[] {
            "Improve",
            "개선",
            "Ameliorer"
          },
          new string[] {
            "Gone",
            "사라지다",
            "Disparu"
          },
          new string[] {
            "Test",
            "시험,테스트",
            "Tester"
          },
          new string[] {
            "Visit",
            "방문하다",
            "Visiter"
          },
          new string[] {
            "With",
            "와(과)함께",
            "Avec"
          },
          new string[] {
            "Without",
            "없이",
            "Sans"
          },
          new string[] {
            "Away",
            "없이떨어져/저리가!",
            "Auloin"
          },
          new string[] {
            "Weird",
            "기괴하다,이상하다",
            "Bizarre"
          },
          new string[] {
            "Turn",
            "돌다,돌리다",
            "Tourner"
          },
          new string[] {
            "More Than",
            "보다 많다",
            "Plusque"
          },
          new string[] {
            "Less Than",
            "보다 적다",
            "Moinsque"
          },
          new string[] {
            "Correct",
            "옳다,맞다",
            "Correct"
          },
          new string[] {
            "High",
            "높다",
            "Haut"
          },
          new string[] {
            "Low",
            "낮다",
            "Bas"
          },
          new string[] {
            "Way",
            "방식",
            "Chemin"
          },
          new string[] {
            "Wish",
            "원하다,바라다",
            "Souhait"
          },
          new string[] {
            "Later",
            "늦다",
            "Tard"
          },
          new string[] {
            "Perfect",
            "완벽하다",
            "Parfait"
          },
          new string[] {
            "Fun",
            "재미,재밌어",
            "Amusant"
          },
          new string[] {
            "Every",
            "모든,모두",
            "Tout"
          },
          new string[] {
            "Funny",
            "우습다,웃기다",
            "Drôle"
          }
      },
      new string[][] { //lesson 5
        new string[] {
          "Jealous",
          "질투",
          "Jaloux"
        },
        new string[] {
            "Idea",
            "아이디어,발상",
            "Idée"
          },
          new string[] {
            "Mountain",
            "산",
            "Montagne"
          },
          new string[] {
            "Blame",
            "탓하다",
            "Accuser"
          },
          new string[] {
            "Babysitter",
            "육아도우미",
            "Gardienne d'enfants"
          },
          new string[] {
            "Behavior",
            "행동",
            "Agissement"
          },
          new string[] {
            "Butter",
            "버터",
            "Beurre"
          },
          new string[] {
            "Farm",
            "농장",
            "Ferme"
          },
          new string[] {
            "Fault",
            "잘못",
            "Faute"
          },
          new string[] {
            "Fall",
            "떨어지다/빠지다",
            "Tomber"
          },
          new string[] {
            "Man",
            "남자",
            "Homme"
          },
          new string[] {
            "Woman",
            "여자",
            "Femme"
          },
          new string[] {
            "Mom",
            "엄마",
            "Mère"
          },
          new string[] {
            "Dad",
            "아빠",
            "Père"
          },
          new string[] {
            "Uncle",
            "삼촌",
            "Oncle"
          },
          new string[] {
            "Aunt",
            "고모,이모",
            "Tante"
          },
          new string[] {
            "Grandma",
            "할머니",
            "Grand-mère"
          },
          new string[] {
            "Grandpa",
            "할아버지",
            "Grand-père"
          },
          new string[] {
            "Sister",
            "언니,누나",
            "Sœur"
          },
          new string[] {
            "Brother",
            "오빠,형",
            "Frère"
          },
          new string[] {
            "Kid",
            "꼬마,어린이",
            "Enfant"
          },
          new string[] {
            "Sunday",
            "일요일",
            "Dimanche"
          },
          new string[] {
            "Monday",
            "월요일",
            "Lundi"
          },
          new string[] {
            "Tuesday",
            "화요일",
            "Mardi"
          },
          new string[] {
            "Wednesday",
            "수요일",
            "Mercredi"
          },
          new string[] {
            "Thursday",
            "목요일",
            "Jeudi"
          },
          new string[] {
            "Friday",
            "금요일",
            "Vendredi"
          },
          new string[] {
            "Saturday",
            "토요일",
            "Samedi"
          }
      },
      new string[][] { //lesson 6
        new string[] {
          "Account",
          "계좌",
          "Compte"
        },
        new string[] {
            "Abandon",
            "버리다",
            "Abandonner"
          },
          new string[] {
            "Balance",
            "균형(상태)",
            "Balancer"
          },
          new string[] {
            "Bath",
            "목욕",
            "Bain"
          },
          new string[] {
            "Excited",
            "야구",
            "Excité"
          },
          new string[] {
            "Because",
            "때문에,왜냐면",
            "Parce que"
          },
          new string[] {
            "Become",
            "되다",
            "Devenir"
          },
          new string[] {
            "Call",
            "부르다",
            "Appeler"
          },
          new string[] {
            "Careful",
            "조심하다",
            "Prudent"
          },
          new string[] {
            "Choose",
            "선택하다",
            "Choisir"
          },
          new string[] {
            "Red",
            "빨간색",
            "Rouge"
          },
          new string[] {
            "Blue",
            "파랑색",
            "Bleu"
          },
          new string[] {
            "Green",
            "초록색",
            "Vert"
          },
          new string[] {
            "Yellow",
            "노란색",
            "Jaune"
          },
          new string[] {
            "Orange",
            "주황색",
            "Orange"
          },
          new string[] {
            "Purple",
            "보라색",
            "Purple"
          },
          new string[] {
            "Pink",
            "분홍색",
            "Rose"
          },
          new string[] {
            "Black",
            "검은색",
            "Noir"
          },
          new string[] {
            "White",
            "하얀색",
            "Blanc"
          },
          new string[] {
            "Grey",
            "회색",
            "Gris"
          },
          new string[] {
            "Brown",
            "갈색",
            "Brun"
          },
          new string[] {
            "Tan",
            "황갈색,선탠",
            "Hâlé"
          },
          new string[] {
            "Gold",
            "골드,황금색",
            "Or"
          },
          new string[] {
            "Silver",
            "실버,은색",
            "Argent"
          },
          new string[] {
            "Bright-(Color)",
            "밝다",
            "Brillant"
          },
          new string[] {
            "Shiny-(Color)",
            "빛나다,반짝이다",
            "Étincelant"
          },
          new string[] {
            "Light-(Color)",
            "연하다",
            "Clair"
          },
          new string[] {
            "Dark-(Color)",
            "어둡다",
            "Foncé"
          }
      },
      new string[][] { //lesson 7
        new string[] {
          "Fly",
          "날다",
          "Voler"
        },
        new string[] {
            "Schedule",
            "일정,스케줄",
            "Emploi du temps"
          },
          new string[] {
            "Frustrated",
            "좌절하다",
            "Frustré"
          },
          new string[] {
            "Don’t Worry",
            "걱정마세요",
            "Ne t'inquiète pas"
          },
          new string[] {
            "Embarrassed",
            "당황하다",
            "Embarassé"
          },
          new string[] {
            "Polite",
            "공손하다",
            "Poli"
          },
          new string[] {
            "Rude",
            "무례하다",
            "Rude"
          },
          new string[] {
            "Strong",
            "강하다",
            "Fort"
          },
          new string[] {
            "Brave",
            "용감하다,용기 있는",
            "Brave"
          },
          new string[] {
            "Experience",
            "경험하다,체험하다",
            "Expérience"
          },
          new string[] {
            "Expensive",
            "비싸다",
            "Coûteux"
          },
          new string[] {
            "Curious",
            "궁금하다,호기심이많다",
            "Curieux"
          },
          new string[] {
            "Money",
            "돈",
            "Argent"
          },
          new string[] {
            "Lazy",
            "게으른다",
            "Lâche"
          },
          new string[] {
            "Hungry",
            "배고프다",
            "Faim"
          },
          new string[] {
            "Important",
            "중요하다",
            "Important"
          },
          new string[] {
            "Family",
            "가족",
            "Famille"
          },
          new string[] {
            "Worry",
            "걱정하다",
            "Inquiêtude"
          },
          new string[] {
            "Worse",
            "더나쁘다,심하다",
            "Pire"
          },
          new string[] {
            "Here",
            "여기,여기서",
            "Ici"
          },
          new string[] {
            "Area",
            "지역(구역)",
            "Zone"
          },
          new string[] {
            "E-Mail",
            "전자메일(이메일)",
            "Courriel"
          },
          new string[] {
            "Discord",
            "디스코드",
            "Discorde"
          },
          new string[] {
            "Drama",
            "드라마",
            "Drame"
          },
          new string[] {
            "Hot",
            "뜨겁다,덥다",
            "Chaud"
          },
          new string[] {
            "Cold",
            "차갑다,춥다",
            "Froid"
          },
          new string[] {
            "Music",
            "음악",
            "Musique"
          },
          new string[] {
            "Avatar",
            "아바타",
            "Avatar"
          }
      },
      new string[][] { //lesson 8
        new string[] {
          "Cochlear Implant",
          "인공와우",
          "Implant Cochéaire"
        },
        new string[] {
            "Hearing Aid",
            "보청기",
            "Aide auditoire"
          },
          new string[] {
            "Disorder",
            "엉망,어수선,장애",
            "Désordre"
          },
          new string[] {
            "Together",
            "함께하다",
            "Ensemble"
          },
          new string[] {
            "Nothing",
            "아무것도 아니다",
            "Rien"
          },
          new string[] {
            "Selective Mutism",
            "불안장애",
            "Mustisme sélectif"
          },
          new string[] {
            "Restaurant",
            "레스토랑,식당",
            "Restaurant"
          },
          new string[] {
            "Order",
            "주문,질서",
            "Ordre"
          },
          new string[] {
            "Serve",
            "제공,서비스",
            "Service"
          },
          new string[] {
            "Buy",
            "구매,사다",
            "Acheter"
          },
          new string[] {
            "Sell",
            "팔다",
            "Vendre"
          },
          new string[] {
            "Taco",
            "타코",
            "Taco"
          },
          new string[] {
            "Burrito",
            "브리또",
            "Burrito"
          },
          new string[] {
            "Hamburger",
            "햄버거",
            "Hamburger"
          },
          new string[] {
            "Spaghetti",
            "스파게티",
            "Spaghetti"
          },
          new string[] {
            "Pizza",
            "피자",
            "Pizza"
          },
          new string[] {
            "IceCream",
            "아이스크림",
            "Crème glacée"
          },
          new string[] {
            "Cake",
            "케이크",
            "Gâteaux"
          },
          new string[] {
            "Cookie",
            "과자/쿠키",
            "Biscuit"
          },
          new string[] {
            "Police",
            "경찰",
            "Police"
          },
          new string[] {
            "FireMan",
            "소방관",
            "Pompier"
          },
          new string[] {
            "Doctor",
            "의사",
            "Docteur"
          },
          new string[] {
            "Wonder",
            "궁금하다",
            "Se demander"
          },
          new string[] {
            "Water",
            "물",
            "Eau"
          },
          new string[] {
            "Flower",
            "꽃",
            "Fleur"
          },
          new string[] {
            "Tree",
            "나무",
            "Arbre"
          },
          new string[] {
            "Sea",
            "바다",
            "Océan"
          },
          new string[] {
            "Rock",
            "바위",
            "Roche"
          }
      },
      new string[][] { //lesson 9
        new string[] {
            "Forgive",
            "용서",
            "Pardonner"
          },
          new string[] {
            "Leave",
            "떠나다",
            "Partir"
          },
          new string[] {
            "Ready",
            "준비",
            "Prêt"
          },
          new string[] {
            "Skill",
            "솜씨,기술",
            "Abilité"
          },
          new string[] {
            "Joke",
            "농담",
            "Blague"
          },
          new string[] {
            "Mistake",
            "실수",
            "Erreur"
          },
          new string[] {
            "Move",
            "행동",
            "Bouger"
          },
          new string[] {
            "Lost",
            "잃다",
            "Perdu"
          },
          new string[] {
            "Work",
            "일하다",
            "Travail"
          },
          new string[] {
            "Talk",
            "말하다",
            "Parler"
          },
          new string[] {
            "Not Yet",
            "아직",
            "Pas encore"
          },
          new string[] {
            "Equal",
            "동등하다",
            "Égal"
          },
          new string[] {
            "Number",
            "숫자,번호",
            "Nombre"
          },
          new string[] {
            "Letter",
            "편지",
            "Lettre"
          },
          new string[] {
            "Place",
            "장소",
            "Lieu"
          },
          new string[] {
            "Start",
            "시작",
            "Commencer"
          },
          new string[] {
            "Say/Tell",
            "말하다",
            "Dire"
          },
          new string[] {
            "Fill",
            "채우다",
            "Remplir"
          },
          new string[] {
            "Tea",
            "차/찻잎",
            "Thé"
          },
          new string[] {
            "Come",
            "오다",
            "Venir"
          },
          new string[] {
            "Bring",
            "가져오다",
            "Apporter"
          },
          new string[] {
            "Explain",
            "설명",
            "Expliquer"
          },
          new string[] {
            "Size",
            "크기,사이즈",
            "Taille"
          },
          new string[] {
            "Retreat",
            "물러가다,후퇴",
            "Fuir"
          },
          new string[] {
            "Return",
            "반환,반납",
            "Retourner"
          },
          new string[] {
            "Taste",
            "맛(미각)",
            "Goût"
          },
          new string[] {
            "Enjoy",
            "즐기다",
            "Apprécier"
          },
          new string[] {
            "Reason",
            "이유",
            "Raison"
          }
      },
      new string[][] { //lesson 10
        new string[] {
            "Kind/Type",
            "종류/형태",
            "Sorte/Type"
          },
          new string[] {
            "Limit",
            "제한",
            "Limite"
          },
          new string[] {
            "Have",
            "가지다",
            "Avoir"
          },
          new string[] {
            "Plan",
            "계획",
            "Plan"
          },
          new string[] {
            "Won",
            "이기다",
            "Gagné"
          },
          new string[] {
            "Lost",
            "지다",
            "Perdu"
          },
          new string[] {
            "Decide",
            "결정",
            "Décider"
          },
          new string[] {
            "Keep",
            "지키다",
            "Garder"
          },
          new string[] {
            "Act",
            "행동",
            "Agir"
          },
          new string[] {
            "Guess",
            "추측",
            "Deviner"
          },
          new string[] {
            "Search",
            "찾다,검색",
            "Chercher"
          },
          new string[] {
            "Lock",
            "잠그다",
            "Verrouiller"
          },
          new string[] {
            "Listen",
            "듣다",
            "Écouter"
          },
          new string[] {
            "Special",
            "특별하다,특히",
            "Spéciale"
          },
          new string[] {
            "Favor",
            "친절",
            "Faveur"
          },
          new string[] {
            "Owe/Debt",
            "빚지다,부채",
            "Dette"
          },
          new string[] {
            "Argue",
            "다투다",
            "Argumenter"
          },
          new string[] {
            "Wonder",
            "궁금하다",
            "Se questionner"
          },
          new string[] {
            "Join",
            "가입",
            "Joindre"
          },
          new string[] {
            "Realize",
            "깨닫다",
            "Réaliser"
          },
          new string[] {
            "Animal",
            "동물",
            "Animale"
          },
          new string[] {
            "Skip",
            "넘어가다",
            "Passer"
          },
          new string[] {
            "Calm",
            "차분하다,침착하다",
            "Calme"
          },
          new string[] {
            "Progress",
            "진행하다",
            "Progrès"
          },
          new string[] {
            "Option",
            "반대",
            "Option"
          },
          new string[] {
            "Annoy",
            "짜증",
            "Embêter"
          },
          new string[] {
            "Opposite",
            "반대로",
            "Opposer"
          },
          new string[] {
            "Satisfy",
            "만족,충족시키다",
            "Satisfaire"
          }
      },
      new string[][] { //lesson 11
        new string[] {
            "Over",
            "지나치다,과하다",
            "Sur"
          },
          new string[] {
            "Holiday",
            "휴일",
            "Temps des fêtes"
          },
          new string[] {
            "Freeze",
            "얼다,얼음",
            "Geler"
          },
          new string[] {
            "Discuss",
            "상의",
            "Discuter"
          },
          new string[] {
            "Rule",
            "규칙",
            "Règle"
          },
          new string[] {
            "Awkward",
            "어색하다",
            "Gênant"
          },
          new string[] {
            "Strange",
            "낯설다",
            "Étrange"
          },
          new string[] {
            "Bored",
            "심심하다",
            "Ennuyant"
          },
          new string[] {
            "Hurt",
            "아프다",
            "Douleur"
          },
          new string[] {
            "Love",
            "사랑",
            "Amour"
          },
          new string[] {
            "Silly",
            "바보",
            "Ridicule"
          },
          new string[] {
            "Damaged",
            "손해,피해",
            "Endommager"
          },
          new string[] {
            "Jail",
            "감옥",
            "Prison"
          },
          new string[] {
            "Show",
            "보여주다",
            "Montrer"
          },
          new string[] {
            "Dress",
            "드레스",
            "Robe"
          },
          new string[] {
            "Pants",
            "바지",
            "Pantalon"
          },
          new string[] {
            "Shoes",
            "신발",
            "Chaussures"
          },
          new string[] {
            "Shirt",
            "셔츠",
            "Chandail"
          },
          new string[] {
            "Bed",
            "침대",
            "Lit"
          },
          new string[] {
            "Sleep",
            "자다",
            "Dormir"
          },
          new string[] {
            "Drink",
            "마시다",
            "Boire"
          },
          new string[] {
            "Sit",
            "앉다",
            "S'assoir"
          },
          new string[] {
            "Stand",
            "서다",
            "Se tenir debout"
          },
          new string[] {
            "Jump",
            "뛰다",
            "Sauter"
          },
          new string[] {
            "Picture",
            "사진",
            "Photo"
          },
          new string[] {
            "Happen",
            "우연히",
            "Se produire"
          },
          new string[] {
            "Communicate",
            "의사소통",
            "Communiquer"
          },
          new string[] {
            "Play",
            "놀다",
            "Jouer"
          }
      },
      new string[][] { //lesson 12
        new string[] {
            "End",
            "끝",
            "Terminer"
          },
          new string[] {
            "Confused",
            "혼란",
            "Confus"
          },
          new string[] {
            "Empty",
            "비다",
            "Vide"
          },
          new string[] {
            "Touch",
            "만지다",
            "Toucher"
          },
          new string[] {
            "Car",
            "자동차",
            "Voiture"
          },
          new string[] {
            "Drive",
            "운전하다",
            "Conduire"
          },
          new string[] {
            "Above",
            "보다위에",
            "Au dessus"
          },
          new string[] {
            "Stop",
            "정지",
            "Arrêt"
          },
          new string[] {
            "Hate",
            "미워",
            "Haïr"
          },
          new string[] {
            "Run",
            "달리다",
            "Courir"
          },
          new string[] {
            "Walk",
            "걷다",
            "Marcher"
          },
          new string[] {
            "Story",
            "이야기",
            "Histoire"
          },
          new string[] {
            "Promise",
            "약속",
            "Promettre"
          },
          new string[] {
            "Help",
            "돕다",
            "Aider"
          },
          new string[] {
            "Agree",
            "동의하다",
            "Être en accord"
          },
          new string[] {
            "Disagree",
            "동의하지 않다",
            "Être en désaccord"
          },
          new string[] {
            "Add",
            "더하다",
            "Ajouter"
          },
          new string[] {
            "Trust",
            "신뢰",
            "Faire Confiance"
          },
          new string[] {
            "Trouble",
            "곤란",
            "Trouble"
          },
          new string[] {
            "Gain",
            "얻다",
            "Prendre"
          },
          new string[] {
            "Challenge",
            "도전",
            "Défier"
          },
          new string[] {
            "Replace",
            "대신,교체",
            "Remplacer"
          },
          new string[] {
            "Proud",
            "자랑스럽다",
            "Fier"
          },
          new string[] {
            "Expert",
            "전문가",
            "Expert"
          },
          new string[] {
            "Soda",
            "탄산음료",
            "Soda"
          },
          new string[] {
            "Eat",
            "먹다",
            "Manger"
          },
          new string[] {
            "Food",
            "음식",
            "Nourriture"
          },
          new string[] {
            "Name",
            "이름",
            "Nom"
          }
      },
      new string[][] { //lesson 13
        new string[] {
            "Big/Huge",
            "크다",
            "Gros/Grand"
          },
          new string[] {
            "Small",
            "작다",
            "Petit"
          },
          new string[] {
            "Beautiful",
            "아름답다",
            "Beau/Belle"
          },
          new string[] {
            "Ugly",
            "못생기다",
            "Laid"
          },
          new string[] {
            "Fat",
            "뚱뚱하다",
            "Gras"
          },
          new string[] {
            "Skinny",
            "날씬하다",
            "Mince"
          },
          new string[] {
            "Weak",
            "약하다",
            "Faible"
          },
          new string[] {
            "Health",
            "건강",
            "Santé"
          },
          new string[] {
            "Medicine",
            "약",
            "Médicament"
          },
          new string[] {
            "Build",
            "짓다",
            "Construire"
          },
          new string[] {
            "Break",
            "부러지다",
            "Briser"
          },
          new string[] {
            "Make",
            "만들다",
            "Faire"
          },
          new string[] {
            "Find",
            "찾다",
            "Trouver"
          },
          new string[] {
            "Bully",
            "괴롭히다",
            "Intimider"
          },
          new string[] {
            "Insult",
            "모욕",
            "Insulter"
          },
          new string[] {
            "Simple",
            "간단하다",
            "Simple"
          },
          new string[] {
            "Complicated",
            "복잡하다",
            "Compliqué"
          },
          new string[] {
            "Open",
            "열다",
            "Ouvert"
          },
          new string[] {
            "Close",
            "닫다",
            "Fermer"
          },
          new string[] {
            "Hit",
            "때리다",
            "Frapper"
          },
          new string[] {
            "Meat",
            "고기",
            "Viande"
          },
          new string[] {
            "Bread",
            "빵",
            "Pain"
          },
          new string[] {
            "Chips",
            "과자",
            "Croustilles"
          },
          new string[] {
            "Melon",
            "메론",
            "Melon"
          },
          new string[] {
            "Event",
            "행사",
            "Évênement"
          },
          new string[] {
            "Socialize",
            "사교",
            "Socialiser"
          },
          new string[] {
            "Hangout/chill",
            "쌀쌀하다",
            "Trainer/Ensemble"
          },
          new string[] {
            "Relax",
            "편하게하다",
            "Relaxer"
          }
      },
      new string[][] { //lesson 14
        new string[] {
            "Under",
            "아래",
            "En dessous"
          },
          new string[] {
            "Private/Secret",
            "개인/비밀",
            "Privé/Secret"
          },
          new string[] {
            "Emergency",
            "비상/사태",
            "Urgence"
          },
          new string[] {
            "Favorite",
            "마음에 들다",
            "Favori"
          },
          new string[] {
            "Class",
            "수업",
            "Classe"
          },
          new string[] {
            "Proof",
            "증명,증거",
            "Preuve"
          },
          new string[] {
            "Switch",
            "스위치",
            "Transférer"
          },
          new string[] {
            "Angry",
            "화나다",
            "Faché"
          },
          new string[] {
            "Store",
            "상점,가게",
            "Magasin"
          },
          new string[] {
            "Respect",
            "존경",
            "Respect"
          },
          new string[] {
            "Ask",
            "물어보다",
            "Demander"
          },
          new string[] {
            "Suggest",
            "제안",
            "Suggerer"
          },
          new string[] {
            "Trash",
            "쓰레기",
            "Déchet"
          },
          new string[] {
            "Clean",
            "깨끗하다",
            "Propre"
          },
          new string[] {
            "Age",
            "나이",
            "Age"
          },
          new string[] {
            "Try",
            "노력",
            "Éssayer"
          },
          new string[] {
            "Pay",
            "지불",
            "Payer"
          },
          new string[] {
            "Hide",
            "감추다,숨다",
            "Cacher"
          },
          new string[] {
            "Random",
            "무작위",
            "Aléatoire"
          },
          new string[] {
            "Flag",
            "깃발",
            "Drapeau"
          },
          new string[] {
            "Judge",
            "심판",
            "Juge"
          },
          new string[] {
            "Warn",
            "경고",
            "Avertissement"
          },
          new string[] {
            "See",
            "보다",
            "Voir"
          },
          new string[] {
            "Collect",
            "수집",
            "Collecte"
          },
          new string[] {
            "Some/Part",
            "일부,부분",
            "Quelque"
          },
          new string[] {
            "Goal",
            "목표",
            "But"
          },
          new string[] {
            "Pet",
            "애완동물",
            "Animale de Compagnie"
          },
          new string[] {
            "Communicate",
            "소통하다",
            "Communiquer"
          }
      },
      new string[][] { //lesson 15
        new string[] {
            "Yesterday I worked 6 hours.",
            "어제 나는 6시간 일했다.",
            "Hier, j'ai travaillé 6 heures."
          },
          new string[] {
            "I think that you are a great friend.",
            "나는 네가 좋은 친구라고 생각해.",
            "Je pense que tu es un bon ami."
          },
          new string[] {
            "Do you work or have school?",
            "너는 일하니 아니면학교니?",
            "Est-ce que tu travailles ou vas à l'école?"
          },
          new string[] {
            "I went to the hospital, but don't worry.",
            "병원에 갔지만 걱정하지마.",
            "Je suis allé à l'hôpital,mais ne tèinquiète pas."
          },
          new string[] {
            "All the food at the store was gone.",
            "가게의 모든 음식은사 라졌다.",
            "Toute la nourriture au magasin était parti."
          },
          new string[] {
            "Please repeat, I am a new student.",
            "반복해줘,나는 새로운 학생입니다.",
            "Répète s'il te plait,je suis un nouvel étudiant."
          },
          new string[] {
            "I don't understand a lot, but I am improving.",
            "많이 이해하지는 못하지만, 발전하고 있어.",
            "Je ne comprend pas beaucoup mais je m'améliore."
          },
          new string[] {
            "Where is the teacher?",
            "선생님은 어디 계시니?",
            "Où est l'enseignant?"
          },
          new string[] {
            "I don't like drama.",
            "나는 드라마를 좋아하지 않는다.",
            "Je n'aime pas le drame."
          },
          new string[] {
            "What did you do today?",
            "오늘 뭐했어?",
            "Qu'as-tu fait aujourd'hui?"
          },
          new string[] {
            "What is your favorite food?",
            "가장 좋아하는 음식이 무엇입니까?",
            "Quelle est ta nourriture préféré?"
          },
          new string[] {
            "Where can I learn more sign?",
            "더많은 수화를 어디서배울수 있니?",
            "Où puis-je apprendre plus de signes?"
          },
          new string[] {
            "Are you alright? What happened?",
            "괜찮아? 어떻게 된 거야?",
            "Est-ce que çava? Que s'est-t'il passé?"
          },
          new string[] {
            "I like turtles.",
            "나는 거북이를 좋아한다.",
            "J'aime les tortues."
          },
          new string[] {
            "I love Deaf culture!",
            "나는 청각장애인 문화를 좋아해!",
            "J'aime la cultures des sourds."
          },
          new string[] {
            "You're a great person!",
            "넌 훌륭한 사람이야!",
            "Tu es une bonne personne."
          },
          new string[] {
            "I like to eat bread.",
            "나는 빵 먹는 것을 좋아한다.",
            "J'aime manger du pain."
          },
          new string[] {
            "I hate taking pictures.",
            "나는 사진찍는 것을싫어한다.",
            "Je déteste prendre des photos."
          },
          new string[] {
            "I respect my friends.",
            "나는 내친구들을 존중합니다.",
            "Je respect mes amis."
          },
          new string[] {
            "Do you understand, need me to repeat?",
            "알아들었어? 반복할 필요가 있어?",
            "Est-ce que tu comprends, besoin de répéter?"
          },
          new string[] {
            "I cannot hear,I am Deaf.",
            "나는 들을 수 없다. 나는 청각장애인이다.",
            "Je ne peux pas entendre,je suis sourd."
          },
          new string[] {
            "I need an interpreter, who can help me?",
            "통역사가 필요해, 누가 날 도와줄 수 있지?",
            "J'ai besoin d'un interprètre, qui peut m'aider?"
          },
          new string[] {
            "Are you Deaf, mute, hard of hearing, hearing?",
            "청각장애인? 말을못해? 난청인? 청인?",
            "Es-tu sourd, muet, malentendant ou entendant?"
          },
          new string[] {
            "Are you streaming on youtube or twitch?",
            "유투브 or 트위치에서 스트리밍하고 있니?",
            "Est-ce que tu diffuses sur youtube ou twitch?"
          },
          new string[] {
            "I don't like running.",
            "나는 달리기를 좋아하지 않는다.",
            "Je n'aime pas courir."
          },
          new string[] {
            "Can you lock that door?",
            "문을 잠글수 있니?",
            "Peux-tu verrouiller cette porte?"
          },
          new string[] {
            "I feel sick, I need to rest.",
            "몸이 아파서 쉬어야겠어.",
            "Je me sens malade, j'ai besoin de me reposer."
          },
          new string[] {
            "Please stop doing that, it's rude.",
            "제발 그렇게하지 마, 무례한 짓이야.",
            "S'il te plait arrête de faire ça, c'est rude."
          }
      },
      new string[][] { //lesson 16
        new string[] {
            "Door",
            "문",
            "Porte"
          },
          new string[] {
            "Dangerous",
            "위험하다",
            "Dangereux"
          },
          new string[] {
            "Borrow",
            "빌리다",
            "Brouette"
          },
          new string[] {
            "Army",
            "군대",
            "Armée"
          },
          new string[] {
            "Group",
            "그룹,모임",
            "Groupe"
          },
          new string[] {
            "Team",
            "팀",
            "Équipe"
          },
          new string[] {
            "Alright",
            "괜찮다",
            "Bien"
          },
          new string[] {
            "Gross",
            "역겹다",
            "Dégueux"
          },
          new string[] {
            "Feel",
            "느끼다",
            "Sentir"
          },
          new string[] {
            "Depression",
            "우울증",
            "Depression"
          },
          new string[] {
            "Anxiety/anxious",
            "불안",
            "Anxiété"
          },
          new string[] {
            "Nervous",
            "긴장하다",
            "Nerveux"
          },
          new string[] {
            "Kiss",
            "키스,뽀뽀",
            "Embrasser"
          },
          new string[] {
            "Date",
            "날짜",
            "Date"
          },
          new string[] {
            "Sweetheart",
            "애인,연인",
            "Cœurtendre"
          },
          new string[] {
            "Fall in love",
            "사랑에 빠진다",
            "Tomber en amour"
          },
          new string[] {
            "Just/Only",
            "그냥/오직",
            "Seulement"
          },
          new string[] {
            "Sneeze",
            "재채기",
            "Éternuer"
          },
          new string[] {
            "Cough",
            "기침",
            "Tousser"
          },
          new string[] {
            "Blessyou",
            "축복하다",
            "À tes souhaits"
          },
          new string[] {
            "University",
            "종합대학",
            "Université"
          },
          new string[] {
            "Church",
            "교회",
            "Église"
          },
          new string[] {
            "Library",
            "도서관",
            "Bibliothèque"
          },
          new string[] {
            "Office",
            "사무실",
            "Bureau"
          },
          new string[] {
            "Fancy",
            "공상",
            "Qualité supérieure"
          },
          new string[] {
            "College",
            "전문대학",
            "Collège"
          },
          new string[] {
            "Gym",
            "체육관",
            "Gymnase"
          },
          new string[] {
            "Workout",
            "운동",
            "Exercicer"
          }
      }
      /*if this is the last lesson, don't put a comma after the } 

      				*/
    };
    string[] lessonnames = new string[] { //array of lesson names - I guess rename to Lesson 1, Lesson 2 and so on if you don't have names
      "Lesson 1",
      "Lesson 2",
      "Lesson 3",
      "Lesson 4",
      "Lesson 5",
      "Lesson 6",
      "Lesson 7",
      "Lesson 8",
      "Lesson 9",
      "Lesson 10",
      "Lesson 11",
      "Lesson 12",
      "Lesson 13",
      "Lesson 14",
      "Sentences",
      "Lesson 16",
      "Lesson 17",
      "Lesson 18",
      "Lesson 19",
      "Lesson 20"
    };



    // Main Menu Objects/Variables
    TextMeshProUGUI menuheadertext;
    //TextMeshProUGUI menusubheadertext;
    int numofbuttons;
    GameObject[] buttons;
	TextMeshProUGUI[] buttontext;


    Text podiumtext;
    Text maintext;


    GameObject backbutton;
    //GameObject nextButton;
    //GameObject prevButton;

    //int currentboard=0; // current page
    //int currentlang = 0; // currently selected Language
    [UdonSynced] int currentlesson = -1; // currently selected Lesson
    [UdonSynced] int currentword = -1; // currently selected Word/Sign

	//[UdonSynced] int globalboard;
	//[UdonSynced] int globalcurrentlang; //
	//[UdonSynced] int globalcurrentlesson = -1;
	//[UdonSynced] int globalcurrentword = -1;
	
	// Preference Menu Objects/Variables - Lookup/Quiz Mode

	//const int MODE_LOOKUP = 0;
	//const int MODE_QUIZ = 1;
	//int currentmode; // Tracks current mode (Lookup, Quiz, etc.)
	//[UdonSynced] int globalcurrentmode;


	// General Constants
	const int NOT_SELECTED = -1;
	const int MENU_LANGUAGE = 0;
	const int MENU_LESSON = 1;
	const int MENU_WORD = 2;

	//const int FORWARDS=1;
	//const int BACKWARDS=-1;
	//int direction=FORWARDS;

    ColorBlock darkmodebutton;
    ColorBlock darkmodeselectedbutton;

    // Color Constants
    Color COLOR_WHITE = new Color(1,1,1,1);
	Color COLOR_BLACK = new Color(0,0,0,1);
	Color COLOR_GREY_DARK = new Color(.25f,.25f,.25f,1);
	Color COLOR_GREY_MEDIUM = new Color(.5f,.5f,.5f,1);
	Color COLOR_GREY_LIGHT = new Color(.75f,.75f,.75f,1);
	Color COLOR_GREEN_DARK = new Color(.2f,.3f,.2f,1);
	Color COLOR_GREEN_MEDIUM = new Color(.2f,.5f,.2f,1);
	Color COLOR_GREEN_LIGHT = new Color(.75f,.75f,.75f,1);
	Color COLOR_GREEN = new Color(.5f,1,.5f,1);
	Color COLOR_RED = new Color(1,.5f,.5f,1);
	// Debug
	//Text debugtextbox;

	/***************************************************************************************************************************
	Assigns variables for use. Initializes menu by calling DisplayLocalLanguageSelectMenu();
	***************************************************************************************************************************/
	void Start() {
        // Initialize Displays
        //mainscreen = GameObject.Find("/World/Udon Menu System/Main Display Canvas/DisplayText");
        //podium = GameObject.Find("/World/Udon Menu System/Main Display Canvas/DisplayText");
        

        _InitializeDarkMode(); //assigns colors to color variables declared in class.
        _InitializeMenu();

        // Update Data - Modes
        //globalmode = GlobalToggle.GetComponent<Toggle>().isOn;
        //globalmode = true;
        //darkmode = DarkToggle.GetComponent<Toggle>().isOn;



        // Update Data - Menu Defaults
        //currentlang = NOT_SELECTED;
		currentlesson = NOT_SELECTED;
		currentword = NOT_SELECTED;


		// Update Display States

		_UpdateAllDisplays();
	}



/***************************************************************************************************************************
Initialize Variables related to Dark Mode
***************************************************************************************************************************/
    private void _InitializeDarkMode()
    {
        darkmodebutton = new ColorBlock();
        darkmodebutton.normalColor = COLOR_WHITE;
        darkmodebutton.highlightedColor = COLOR_GREY_MEDIUM;
        darkmodebutton.pressedColor = COLOR_GREY_LIGHT;
        darkmodebutton.colorMultiplier = 1;
        darkmodebutton.fadeDuration = .1f;

        darkmodeselectedbutton = new ColorBlock();
        darkmodeselectedbutton.normalColor = COLOR_GREEN_LIGHT;
        darkmodeselectedbutton.highlightedColor = COLOR_GREEN_MEDIUM;
        darkmodeselectedbutton.pressedColor = COLOR_GREY_LIGHT;
        darkmodeselectedbutton.colorMultiplier = 1;
        darkmodeselectedbutton.fadeDuration = .1f;

        //ColorBlock ver = new ColorBlock();
        //verifieddark.normalColor = new Color(.18f,.3f,.18f,1); //light green
        //verifieddark.highlightedColor = new Color(.4f,1,.4f,1); //darker light green
        //verifieddark.pressedColor = new Color(.4f,.7f,.4f,1); //darker green
    }



    /***************************************************************************************************************************
	Initialize Variables related to the main Menu
	***************************************************************************************************************************/
    private void _InitializeMenu() {
        numofbuttons = GameObject.Find("/World/Udon Menu System/Menu Canvas/Scroll View/Viewport/Content/Menu Buttons").transform.childCount;
        Debug.Log("numofbuttons:" + numofbuttons);
        buttons = new GameObject[numofbuttons];
        buttontext = new TextMeshProUGUI[numofbuttons];
        maintext = GameObject.Find("/World/Udon Menu System/Main Display Canvas/DisplayText").GetComponent<Text>();
        podiumtext = GameObject.Find("/World/Udon Menu System/Podium Display Canvas/DisplayText").GetComponent<Text>();
        
        
        menuheadertext = GameObject.Find("/World/Udon Menu System/Menu Canvas/Menu Header").GetComponent<TextMeshProUGUI>();
        //menuheader = GameObject.Find("/Udon Menu System/Root Canvas/Menu Header"); 


        for (int x = 0; x < numofbuttons; x++) {
            buttons[x] = GameObject.Find("/World/Udon Menu System/Menu Canvas/Scroll View/Viewport/Content/Menu Buttons/Button (" + x + ")");
			buttontext[x] = GameObject.Find("/World/Udon Menu System/Menu Canvas/Scroll View/Viewport/Content/Menu Buttons/Button (" + x + ")/Text (TMP)").GetComponent < TextMeshProUGUI > ();

		}
		backbutton = GameObject.Find("/World/Udon Menu System/Menu Canvas/Back Button");
		//backbuttons[1] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Right Back Button");

	}

    

	/***************************************************************************************************************************
	Update Menu Variables used to control displays.
	***************************************************************************************************************************/
    private void _UpdateMenuVariables(int buttonIndex) {
		Debug.Log("Entered _UpdateMenuVariables with buttonIndex:"+ buttonIndex);
        //_DebugMenuVariables();
        _TakeOwnership();
        //int currentmenu = _GetCurrentMenu();

				switch (_GetCurrentMenu()) {
					case MENU_LESSON:
						currentlesson = buttonIndex;
						currentword = NOT_SELECTED;
						break;
					case MENU_WORD:
							currentword = buttonIndex;
						break;
					default:
						//Debug.Log("_UpdateMenuVariables() failed; currentmenu is: "+currentmenu+" buttonIndex:"+ buttonIndex);
						//_DebugMenuVariables();
						break;
				}
        /*
        if (globalmode)
        {
            TakeOwnership();
            _GlobalModeVarSync();
        }
        */
        RequestSerialization();

    }

    /***************************************************************************************************************************
    When updates to variables are recieved, check if globalmode is enabled
    ***************************************************************************************************************************/
    public override void OnDeserialization()
    {
        if (!Networking.IsOwner(gameObject))//if i'm not the owner, i need to update my display to match what the owner sees
        { 
                //_UpdateMenuVariables(NOT_SELECTED);
                _UpdateAllDisplays();
            
        }
        //_DebugMenuVariables();
    }



	/***************************************************************************************************************************
	Update all displays, including Menu, VRC Player, Nana, etc.
	***************************************************************************************************************************/
	private void _UpdateAllDisplays() {
        Debug.Log("Entered _UpdateAllDisplays");
        int currentmenu = _GetCurrentMenu();
		switch (currentmenu) {
			case MENU_LESSON:
				_DisplayLessonSelectMenu();
				break;
			case MENU_WORD:
				_DisplayWordSelectMenu();
				_DisplaySign();

				break;
			default:
				//Debug.Log("UpdateMenuDisplay() failed; currentmenu is: "+currentmenu+")");
				//_DebugMenuVariables();
				break; 
		}
		

	}

	/***************************************************************************************************************************
	Calculate and return the current Menu state.
	***************************************************************************************************************************/
	private int _GetCurrentMenu() {
		int currentmenu = 1;
			if (currentlesson == NOT_SELECTED) {
				currentmenu = MENU_LESSON;
			} else {
				currentmenu = MENU_WORD;
			}

		return currentmenu;
	}



	/***************************************************************************************************************************
	Change Menu to display Lesson Selection.
	***************************************************************************************************************************/
	private void _DisplayLessonSelectMenu() {
		// Handle Menu Header (Breadcrumb)
		menuheadertext.text = "Lesson Menu";

		// Handle Selection Buttons
		bool isButtonSelected = false;
		for (int i = 0; i < numofbuttons; i++) { //loop through all the buttons
			if (i < Lessons.Length) {
				if (lessonnames.Length > i) {
					//isButtonSelected = currentmode == MODE_QUIZ && quizlessonselection[currentlang][i] ? true : false;
					_DisplayButton(i, (i + 1) + ") " + lessonnames[i], isButtonSelected);

				}
			} else {
				_HideButton(i);
			}
		}

		// Handle Navigation Buttons
		//nextButton.SetActive(false);
		//prevButton.SetActive(false);
		backbutton.SetActive(true);

	}

	/***************************************************************************************************************************
	Change Menu to display Word Selection.
	***************************************************************************************************************************/
	private void _DisplayWordSelectMenu() {
		// Handle Menu Header (Breadcrumb)
		menuheadertext.text = " Lesson #" + (currentlesson+1) + " - " + lessonnames[currentlesson];

		// Handle Selection Buttons
		string buttonText;
		bool isButtonSelected;
		
        //Debug.Log("numofbuttons:" + numofbuttons);
		for (int i = 0; i < numofbuttons; i++) {
            //Debug.Log("give me the data for: AllLessons[0][27][58][0]" + AllLessons[0][27][58][0]);
			if (i < Lessons[currentlesson].Length) { //prevent crashing if udon doesn't find the array data for some reason
                //Debug.Log("working on button number: " + i);
                buttonText = (i + 1) + ") " + Lessons[currentlesson][i][0];
				isButtonSelected = currentword == i;
				
				_DisplayButton(i, buttonText, isButtonSelected);
				
			} else {
				_HideButton(i);
			}
		}

		// Handle Navigation Buttons
		backbutton.SetActive(true);
		//backbuttons[1].SetActive(true);
        /*
		if (currentword > 0){
			prevButton.SetActive(true);
		} else {
			prevButton.SetActive(false);
		}
		if ((currentword+1)<AllLessons[currentlang][currentlesson].Length && currentword != NOT_SELECTED) {
			nextButton.SetActive(true);
		} else {
			nextButton.SetActive(false);
		}*/

	}





	/***************************************************************************************************************************
	Display a Menu button at a specific index, with the given parameters.
	***************************************************************************************************************************/
	private void _DisplayButton(int index, string text, bool isSelected) {


	
		// Handle Selection Highlighting
		buttons[index].GetComponent<Button>().colors = isSelected ? darkmodeselectedbutton : darkmodebutton;
		
		// Handle Text
		buttontext[index].text = text;
		
		// Toggle Display
		buttons[index].SetActive(true);
	}

	/***************************************************************************************************************************
	Hide the specified button.
	***************************************************************************************************************************/
	private void _HideButton(int index) {
		buttons[index].SetActive(false);
	}

	/***************************************************************************************************************************
	Display the sign on the display
	***************************************************************************************************************************/
	private void _DisplaySign() {
		if(currentword!=NOT_SELECTED){

            //maintext = GameObject.Find("/World/Udon Menu System/Main Display Canvas/DisplayText").GetComponent<Text>(); 
            //podiumtext = GameObject.Find("/World/Udon Menu System/Podium Display Canvas/DisplayText").GetComponent<Text>(); 
            maintext.text = Lessons[currentlesson][currentword][0]+"\n"+ Lessons[currentlesson][currentword][1]+"\n"+ Lessons[currentlesson][currentword][2];
            podiumtext.text = Lessons[currentlesson][currentword][0] + "\n" + Lessons[currentlesson][currentword][1] + "\n" + Lessons[currentlesson][currentword][2];

        }
	}


	/***************************************************************************************************************************
	Button Handler for Previous/Next navigation button clicks on Word Selection for main Menu.
	***************************************************************************************************************************/
	private void _PreviousNextWordButtonPushed(bool isIncrementingWord) {
		Debug.Log("Entered _PreviousNextWordButtonPushed");
		int nextword = isIncrementingWord ? currentword + 1 : currentword - 1;
		int lessonLength = Lessons[currentlesson].Length;
		if (nextword >= 0 && nextword < lessonLength) {
			currentword = nextword;
			_DisplayWordSelectMenu();
			_DisplaySign();

		}
	}

	/***************************************************************************************************************************
	Button Handler for Back button click on Menu.
	***************************************************************************************************************************/
	private void _BackButtonPushed() {
		Debug.Log("Entered _BackButtonPushed");



            if (currentlesson == NOT_SELECTED)
            { //on lesson menu
                //Do nothing, as it shouldn't be possible to hit a back button on the lesson select
            }
            else
            { //on word menu
                currentlesson = NOT_SELECTED; //go to lesson menu
            }
        

       _TakeOwnership();
       RequestSerialization();

        _UpdateAllDisplays();
	}



	/***************************************************************************************************************************
	Figures out what the button does, and sends to the approperate functions to update the menu.
	***************************************************************************************************************************/
	private void _buttonpushed(int buttonIndex) {
		Debug.Log("Entered _buttonpushed("+buttonIndex+")");
		
		// Update Data
		_UpdateMenuVariables(buttonIndex);
		
		// Update Display
		_UpdateAllDisplays();
	}

	/***************************************************************************************************************************
	Takes ownership of the board udonbehavior to update variables?
	***************************************************************************************************************************/
    public void _TakeOwnership() {
                if (!Networking.IsOwner(gameObject)) {
                    Networking.SetOwner(Networking.LocalPlayer, gameObject);
                }
        }



	/***************************************************************************************************************************
	Outputs debug vars to log or panel
	***************************************************************************************************************************/
	private void _DebugMenuVariables() 
	{
		//String _message = "";
		/*
		debugtextbox.text="Current Variable contents: " +
			"\nOwner: " + Networking.IsOwner(gameObject) + 
			"\ncurrentmode: " + currentmode + " globalcurrentmode: " + globalcurrentmode +
			"\ncurrentlang: " + currentlang + " globalcurrentlang: " + globalcurrentlang + 
			"\ncurrentlesson: " + currentlesson + " globalcurrentlesson: " + globalcurrentlesson + 
			"\ncurrentword: " + currentword + " globalcurrentword: " + globalcurrentword;

				*/
	}


	/***************************************************************************************************************************
	Register Button Handlers
	***************************************************************************************************************************/
	public void NextB() {
		_PreviousNextWordButtonPushed(true);
	}
	public void PrevB() {
		_PreviousNextWordButtonPushed(false);
	}
	public void BackB() {
		_BackButtonPushed();
	}
	public void B0() {
		_buttonpushed(0);
	}
	public void B1() {
		_buttonpushed(1);
	}
	public void B2() {
		_buttonpushed(2);
	}
	public void B3() {
		_buttonpushed(3);
	}
	public void B4() {
		_buttonpushed(4);
	}
	public void B5() {
		_buttonpushed(5);
	}
	public void B6() {
		_buttonpushed(6);
	}
	public void B7() {
		_buttonpushed(7);
	}
	public void B8() {
		_buttonpushed(8);
	}
	public void B9() {
		_buttonpushed(9);
	}
	public void B10() {
		_buttonpushed(10);
	}
	public void B11() {
		_buttonpushed(11);
	}
	public void B12() {
		_buttonpushed(12);
	}
	public void B13() {
		_buttonpushed(13);
	}
	public void B14() {
		_buttonpushed(14);
	}
	public void B15() {
		_buttonpushed(15);
	}
	public void B16() {
		_buttonpushed(16);
	}
	public void B17() {
		_buttonpushed(17);
	}
	public void B18() {
		_buttonpushed(18);
	}
	public void B19() {
		_buttonpushed(19);
	}
	public void B20() {
		_buttonpushed(20);
	}
	public void B21() {
		_buttonpushed(21);
	}
	public void B22() {
		_buttonpushed(22);
	}
	public void B23() {
		_buttonpushed(23);
	}
	public void B24() {
		_buttonpushed(24);
	}
	public void B25() {
		_buttonpushed(25);
	}
	public void B26() {
		_buttonpushed(26);
	}
	public void B27() {
		_buttonpushed(27);
	}
	public void B28() {
		_buttonpushed(28);
	}
	public void B29() {
		_buttonpushed(29);
	}
	public void B30() {
		_buttonpushed(30);
	}
	public void B31() {
		_buttonpushed(31);
	}
	public void B32() {
		_buttonpushed(32);
	}
	public void B33() {
		_buttonpushed(33);
	}
	public void B34() {
		_buttonpushed(34);
	}
	public void B35() {
		_buttonpushed(35);
	}
	public void B36() {
		_buttonpushed(36);
	}
	public void B37() {
		_buttonpushed(37);
	}
	public void B38() {
		_buttonpushed(38);
	}
	public void B39() {
		_buttonpushed(39);
	}
	public void B40() {
		_buttonpushed(40);
	}
	public void B41() {
		_buttonpushed(41);
	}
	public void B42() {
		_buttonpushed(42);
	}
	public void B43() {
		_buttonpushed(43);
	}
	public void B44() {
		_buttonpushed(44);
	}
	public void B45() {
		_buttonpushed(45);
	}
	public void B46() {
		_buttonpushed(46);
	}
	public void B47() {
		_buttonpushed(47);
	}
	public void B48() {
		_buttonpushed(48);
	}
	public void B49() {
		_buttonpushed(49);
	}
	public void B50() {
		_buttonpushed(50);
	}
	public void B51() {
		_buttonpushed(51);
	}
	public void B52() {
		_buttonpushed(52);
	}
	public void B53() {
		_buttonpushed(53);
	}
	public void B54() {
		_buttonpushed(54);
	}
	public void B55() {
		_buttonpushed(55);
	}
	public void B56() {
		_buttonpushed(56);
	}
	public void B57() {
		_buttonpushed(57);
	}
	public void B58() {
		_buttonpushed(58);
	}
	public void B59() {
		_buttonpushed(59);
	}
	public void B60() {
		_buttonpushed(60);
	}
	public void B61() {
		_buttonpushed(61);
	}
	public void B62() {
		_buttonpushed(62);
	}
	public void B63() {
		_buttonpushed(63);
	}
	public void B64() {
		_buttonpushed(64);
	}
	public void B65() {
		_buttonpushed(65);
	}
	public void B66() {
		_buttonpushed(66);
	}
	public void B67() {
		_buttonpushed(67);
	}
	public void B68() {
		_buttonpushed(68);
	}
	public void B69() {
		_buttonpushed(69);
	}

    

}
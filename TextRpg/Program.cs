using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace TextRpg
{
    internal class Program
    {
        static Player player = new Player();
        static IDungeon idungeon = new IDungeon();
        static AtkItem atkItem;
        static DefItem defItem;

        static void Main(string[] args)
        {
            village();
        }

        static void village ()
        {
            int result;

            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("\n");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string inputVillage = Console.ReadLine();

            switch (inputVillage)
            {
                case "1":
                    status();
                    break;
                case "2":
                    Inventory();
                    break;
                case "3":
                    Shop();
                    break;

            }
            bool resVillage = int.TryParse(inputVillage, out int selectVillage);
            if (selectVillage < 1 || selectVillage > 3)
            {
                Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                string inputVillage2 = Console.ReadLine();
                bool resVillage2 = int.TryParse(inputVillage2, out int selectVillage2);
                if (selectVillage2 == 1)
                {
                    status();
                }
                else if (selectVillage2 == 2)
                {
                    Inventory();
                }
                else if (selectVillage2 == 3)
                {
                    Shop();
                }
            }
        }

        static void status ()
        {
            Console.Clear();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("\n");
            Console.WriteLine("Lv." + player.level);
            Console.WriteLine("chad (" + player.major + ")");
            Console.WriteLine("공격력 : " + player.atk);
            Console.WriteLine("방어력 : " + player.def);
            Console.WriteLine("체 력 : " + player.hp);
            Console.WriteLine("Gold : " + player.gold + "G");
            Console.WriteLine("\n");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string inputStatus = Console.ReadLine();
            bool resStatus = int.TryParse(inputStatus, out int seletStatus);

            if (seletStatus == 0) 
            {
                village();
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                string inputStatus2 = Console.ReadLine();
                bool resStatus2 = int.TryParse(inputStatus2, out int  seletStatus2);
                if (seletStatus2 == 0)
                {
                    village();
                }

            }

        }

        static void Inventory ()
        {
            List<string> inventoryItemList = new List<string>();

            Console.Clear();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        }

        static void Shop ()
        {
            List<DefItem> shopDefItemList = new List<DefItem>();
            List<AtkItem> shopAtkItemList = new List<AtkItem>();
            shopDefItemList.Add(new DefItem("수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다.", "1000"));
            shopDefItemList.Add(new DefItem("무쇠 갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", "1000"));
            shopDefItemList.Add(new DefItem("스파르타의 갑옷", 15, "스파르타 전사들이 사용했다는 전설의 갑옷입니다.", "1000"));
            shopAtkItemList.Add(new AtkItem("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다.", "1000"));
            shopAtkItemList.Add(new AtkItem("청동 도끼", 5, "어디선가 사용했던거 같은 도끼입니다.", "1000"));
            shopAtkItemList.Add(new AtkItem("스파르타의 창", 7, "스파르타 전사들이 사용했다는 전설의 창입니다.", "1000"));

            Console.Clear();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine(player.gold + " G");
            Console.WriteLine("\n");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("1 " + shopDefItemList[0].name + "   | 방어력 +" + shopDefItemList[0].def + "   | " + shopDefItemList[0].ex + "     | " + shopDefItemList[0].price + "G");
            Console.WriteLine("2 " + shopDefItemList[1].name + "   | 방어력 +" + shopDefItemList[1].def + "   | " + shopDefItemList[1].ex + "     | " + shopDefItemList[1].price + "G");
            Console.WriteLine("3 " + shopDefItemList[2].name + "   | 방어력 +" + shopDefItemList[2].def + "   | " + shopDefItemList[2].ex + "     | " + shopDefItemList[2].price + "G");
            Console.WriteLine("4 " + shopAtkItemList[0].name + "   | 방어력 +" + shopAtkItemList[0].atk + "   | " + shopAtkItemList[0].ex + "     | " + shopAtkItemList[0].price + "G");
            Console.WriteLine("5 " + shopAtkItemList[1].name + "   | 방어력 +" + shopAtkItemList[1].atk + "   | " + shopAtkItemList[1].ex + "     | " + shopAtkItemList[1].price + "G");
            Console.WriteLine("6 " + shopAtkItemList[2].name + "   | 방어력 +" + shopAtkItemList[2].atk + "   | " + shopAtkItemList[2].ex + "     | " + shopAtkItemList[2].price + "G");
            Console.WriteLine("1~6. 아이템 구매");
            Console.WriteLine("0. 나가기");
            string inputShop = Console.ReadLine();
            bool resShop = int.TryParse(inputShop, out int selectShop);

            if (selectShop == 0)
            {
                village();
            }
            else if (selectShop > 6 || selectShop < 0)
            {
                Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                string inputShop2 = Console.ReadLine();
                bool resShop2 = int.TryParse(inputShop2, out int selectShop2);
                if (selectShop2 == 0)
                {
                    village();
                }
                else if (selectShop2 > 0 ||  selectShop2 < 7)
                {
                    //아이템 구매
                    
                }
            }
        }

        static void Dungeon ()
        {
            Console.Clear();
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("\n");
            Console.WriteLine("1. 쉬운던전     | 방어력 5 이상 권장");
            Console.WriteLine("2. 쉬운던전     | 방어력 11 이상 권장");
            Console.WriteLine("3. 쉬운던전     | 방어력 17 이상 권장");
            Console.WriteLine("0. 나가기");
            string dungeonInput = Console.ReadLine();
            
            switch (dungeonInput)
            {
                case "1":
                    idungeon.EasyDungeon();
                    break;
                case "2":
                    idungeon.NormalDungeon();
                    break;
                case "3":
                    idungeon.HardDungeon();
                    break;
            }
        }

        class Player
        {
            public int level = 01;
            public string major = "전사";
            public int atk = 10;
            public int def = 5;
            public int hp = 100;
            public int gold = 1500;
        }

        class DefItem
        {
            public string name;
            public int def;
            public string ex;
            public string price;

            public DefItem(string name, int def, string ex, string price)
            {
                this.name = name;
                this.def = def;
                this.ex = ex;
                this.price = price;
            }
        }
        
        class AtkItem
        {
            public string name;
            public int atk;
            public string ex;
            public string price;

            public AtkItem(string name, int atk, string ex, string price)
            {
                this.name = name;
                this.atk = atk;
                this.ex = ex;
                this.price = price;
            }
        }

        public interface ItemBuy
        {
            void Buy();
        }

        public class BItem : ItemBuy
        {
            public void Buy()
            {

            }
        }

        class IDungeon
        {
            public void EasyDungeon()
            {
                if (player.def < 5)
                {
                    //40% 확률
                    Console.WriteLine("던전 클리어에 실패했습니다.");
                    player.hp /= 2;
                }
                else
                {
                    Console.WriteLine("던전 클리어에 성공했습니다.");
                    player.gold += 1000;
                }
            }

            public void NormalDungeon()
            {
                if (player.def < 11)
                {
                    //40% 확률
                    Console.WriteLine("던전 클리어에 실패했습니다.");
                    player.hp /= 2;
                }
                else
                {
                    Console.WriteLine("던전 클리어에 성공했습니다.");
                    player.gold += 1700;
                }
            }

            public void HardDungeon()
            {
                if (player.def < 17)
                {
                    //40% 확률
                    Console.WriteLine("던전 클리어에 실패했습니다.");
                    player.hp /= 2;
                }
                else
                {
                    Console.WriteLine("던전 클리어에 성공했습니다.");
                    player.gold += 2500;
                }
            }
        }
    }
}

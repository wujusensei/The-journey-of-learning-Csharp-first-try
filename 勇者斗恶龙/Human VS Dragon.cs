namespace 勇者斗恶龙
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a;
            // 隐藏光标
            Console.CursorVisible = false;
            //设置舞台大小
            int stageWide = 50;
            int stageHigh = 30;
            Console.SetWindowSize(stageWide, stageHigh);
            Console.SetBufferSize(stageWide, stageHigh);

            int gameStageID = 0;//场景编号，不同编号对应不同的场景
            while (true)
            {
                switch(gameStageID)
                {
                    case 0:
                        #region 开始场景
                        //开始场景
                        Console.SetCursorPosition(stageWide / 2 - 5, stageHigh / 6);
                        Console.WriteLine("勇者斗公主");
                        int ifGameStart = 1;

                        while (true)
                        {
                            Console.ForegroundColor = ifGameStart == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(stageWide / 2 - 4, stageHigh / 4);
                            Console.WriteLine("开始游戏");

                            Console.ForegroundColor = ifGameStart == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(stageWide / 2 - 4, stageHigh / 4 + 2);
                            Console.WriteLine("退出游戏");

                            a = Console.ReadKey(true).KeyChar;
                            switch (a)
                            {
                                case 'W':
                                case 'w':
                                    ifGameStart++;
                                    break;
                                case 'S':
                                case 's':
                                    ifGameStart--;
                                    break;

                            }
                            if (a == 'z' || a == 'Z')
                            {
                                if (ifGameStart == 1)
                                    gameStageID = 1;
                                else
                                    gameStageID = 3;
                                Console.Clear();
                                break;
                            }
                            if (ifGameStart < 0) ifGameStart = -ifGameStart;
                            ifGameStart %= 2;
                        }

                        #endregion
                        break;
                    case 1:
                        #region 游戏场景
                        #region 不变的红墙
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i < stageWide - 2; i += 2)
                        {
                            Console.SetCursorPosition(i, 0);
                            Console.Write("■");
                            Console.SetCursorPosition(i, stageHigh - 1);
                            Console.Write("■");
                            Console.SetCursorPosition(i, stageHigh / 7 * 6);
                            Console.Write("■");
                        }
                        for (int j = 0; j < stageHigh; j++)
                        {
                            Console.SetCursorPosition(0, j);
                            Console.Write("■");
                            Console.SetCursorPosition(stageWide - 2, j);
                            Console.Write("■");
                        }
                        #endregion


                        Random random = new Random();
                        int BOSSDEF = 5, BOSSATKMin = 7, BOSSATKMax = 12, BOSSHP = 115;
                        int GrimmDEF=5,GrimmATKMin=8, GrimmATKMax=13, GrimmHP = 100;
                        int BOSSX = stageWide / 2 - 1, BOSSY = stageHigh / 3 * 2 - 5;
                        char Grimmmove;
                        int GrimmX = 6, GrimmY = 3;
                        int DragonX= stageWide / 2 - 1, DragonY= stageHigh / 6;
                        while (true)
                        {
                            if (GrimmHP == 0)
                            {
                                gameStageID = 4;
                                break;
                            }
                            else if (BOSSHP == 0)
                            {
                                Console.SetCursorPosition(stageWide / 2 - 23, stageHigh / 7 * 6 + 2);
                                Console.Write($"公主已被屠尽，勇者哟，速去迎娶那属于你的恶龙吧");
                                Console.SetCursorPosition(BOSSX, BOSSY);
                                Console.Write("  ");

                                if (gameStageID == 2) break;
                            }
                                
                            if (BOSSHP>0)
                            {
                                Console.SetCursorPosition(BOSSX, BOSSY);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("主");
                            }
                            if(BOSSHP==0)
                            {
                                Console.SetCursorPosition(DragonX, DragonY);
                                Console.ForegroundColor= ConsoleColor.Green;
                                Console.Write("龙");
                            }
                            Console.SetCursorPosition(GrimmX, GrimmY);
                            Console.ForegroundColor= ConsoleColor.White;
                            Console.Write("勇");
                            Grimmmove = Console.ReadKey(true).KeyChar;
                            Console.SetCursorPosition(GrimmX, GrimmY);
                            Console.Write(" ");
                            #region 移动与战斗
                            switch (Grimmmove)
                            {
                                    #region 移动相关
                                    case 'A':
                                    case 'a':
                                        GrimmX -= 2;
                                        if (GrimmX < 2) GrimmX = 2;
                                        else if (GrimmX == BOSSX && GrimmY == BOSSY && BOSSHP > 0) GrimmX += 2;
                                        else if (GrimmX == DragonX && GrimmY == DragonY && BOSSHP == 0) GrimmX += 2;
                                        break;
                                    case 'W':
                                    case 'w':
                                        GrimmY--;
                                        if (GrimmY < 1) GrimmY = 1;
                                        else if (GrimmX == BOSSX && GrimmY == BOSSY && BOSSHP > 0) GrimmY++;
                                        else if (GrimmX == DragonX && GrimmY == DragonY && BOSSHP == 0) GrimmY++;
                                        break;
                                    case 'D':
                                    case 'd':
                                        GrimmX += 2;
                                        if (GrimmX > stageWide - 4) GrimmX = stageWide - 4;
                                        else if (GrimmX == BOSSX && GrimmY == BOSSY && BOSSHP > 0) GrimmX -= 2;
                                        else if (GrimmX == DragonX && GrimmY == DragonY && BOSSHP == 0) GrimmX -= 2;
                                        break;
                                    case 'S':
                                    case 's':
                                        GrimmY++;
                                        if (GrimmY > stageHigh / 7 * 6 - 1) GrimmY = stageHigh / 7 * 6 - 1;
                                        else if (GrimmX == BOSSX && GrimmY == BOSSY && BOSSHP > 0) GrimmY--;
                                        else if (GrimmX == DragonX && GrimmY == DragonY && BOSSHP == 0) GrimmY--;
                                        break;
                                    #endregion
                                case 'z':
                                case 'Z':
                                    #region 迎娶界面
                                    Console.SetCursorPosition(GrimmX, GrimmY);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("勇");
                                    if ((GrimmX == DragonX - 2 && GrimmY == DragonY ||
                                        GrimmX == DragonX + 2 && GrimmY == DragonY ||
                                        GrimmX == DragonX && GrimmY == DragonY + 1 ||
                                        GrimmX == DragonX && GrimmY == DragonY - 1) && BOSSHP == 0 && GrimmHP > 0)
                                    {
                                        gameStageID = 2;
                                    }
                                    #endregion
                                    #region 战斗界面
                                    Console.SetCursorPosition(GrimmX, GrimmY);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("勇");
                                    if ((GrimmX == BOSSX - 2 && GrimmY == BOSSY ||
                                        GrimmX == BOSSX + 2 && GrimmY == BOSSY ||
                                        GrimmX == BOSSX && GrimmY == BOSSY + 1 ||
                                        GrimmX == BOSSX && GrimmY == BOSSY - 1) && (BOSSHP > 0 && GrimmHP > 0))
                                    {
                                        Console.SetCursorPosition(stageWide / 2 - 10, stageHigh / 7 * 6 + 2);
                                        Console.Write("战斗开始,请按Z键继续");
                                        Grimmmove = Console.ReadKey(true).KeyChar;
                                        while (Grimmmove != 'Z' && Grimmmove != 'z')
                                        {
                                            Grimmmove = Console.ReadKey(true).KeyChar;
                                        }
                                        while (BOSSHP > 0 && GrimmHP > 0)
                                        {
                                            int b = random.Next(GrimmATKMin, GrimmATKMax) - BOSSDEF;
                                            if (b < 0) b = 0;
                                            BOSSHP -= b;
                                            if (BOSSHP < 0) BOSSHP = 0;
                                            Console.SetCursorPosition(stageWide / 2 - 21, stageHigh / 7 * 6 + 2);
                                            Console.Write($"格林对公主造成了{b:00}点伤害, 公主剩余血量为{BOSSHP:00}");
                                            b = random.Next(BOSSATKMin, BOSSATKMax) - GrimmDEF;
                                            if (b < 0) b = 0;
                                            GrimmHP -= b;
                                            if (GrimmHP < 0) GrimmHP = 0;
                                            Console.SetCursorPosition(stageWide / 2 - 21, stageHigh / 7 * 6 + 3);
                                            Console.Write($"公主对格林造成了{b:00}点伤害, 格林剩余血量为{GrimmHP:00}");
                                            Grimmmove = Console.ReadKey(true).KeyChar;
                                            while (Grimmmove != 'Z' && Grimmmove != 'z')
                                            {
                                                Grimmmove = Console.ReadKey(true).KeyChar;
                                            }
                                            Console.SetCursorPosition(stageWide / 2 - 22, stageHigh / 7 * 6 + 2);
                                            Console.Write("                                            ");
                                            Console.SetCursorPosition(stageWide / 2 - 22, stageHigh / 7 * 6 + 3);
                                            Console.Write("                                            ");
                                        }
                                        
                                    }
                                    #endregion
                                    break;
                            }
                            #endregion


                        }

                        #endregion
                        break;
                    case 2:
                        int nowSelect=0;
                        Console.Clear();
                        Console.SetCursorPosition(stageWide / 2 - 24, stageHigh / 6);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("击败了公主后的格林，终于与巨龙幸福地生活在了一起");
                        while(true)
                        {
                            Console.ForegroundColor = nowSelect == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(stageWide / 2 - 11, stageHigh / 4);
                            Console.WriteLine("帮勇者再找一个巨龙老婆");
                            Console.ForegroundColor = nowSelect == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(stageWide / 2 - 4, stageHigh / 4 + 2);
                            Console.Write("结束游戏");
                            a=Console.ReadKey(true).KeyChar;
                            switch (a)
                            {
                                case 'W':
                                case 'w':
                                    nowSelect++;
                                    break;
                                case 'S':
                                case 's':
                                    nowSelect--;
                                    break;

                            }
                            if (a == 'z' || a == 'Z')
                            {
                                if (nowSelect == 1)
                                    gameStageID = 3;
                                else
                                    gameStageID = 0;
                                Console.Clear();
                                break;
                            }
                            if (nowSelect < 0) nowSelect = -nowSelect;
                            nowSelect %= 2;
                        }

                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(stageWide / 2-7, stageHigh / 3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("勇者踏上了归途");
                        Environment.Exit(0);
                        break;
                    case 4:
                        Console.Clear();
                        Console.SetCursorPosition(stageWide / 2 - 24, stageHigh / 3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("勇士已然身死，然而邪恶未除，后继者哟，继续努力吧");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}

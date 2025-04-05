using System;
using System.IO;

namespace HREngine.Bots
{
    public class AiTest : TestBase
    {
        public string MainPath { get; set; }

        public string TestFilePath { get; set; }

        public string CardDbPath { get; set; }

        //根据卡组选择合适的策略
        public Behavior Bot { get; set; }

        public void Test()
        {
            Settings.Instance.test = true;
            Settings.Instance.mainPath = MainPath;

            var testFile = Path.Combine(MainPath, TestFilePath);
            var data = File.ReadAllText(testFile);
            Settings.Instance.logpath = Path.Combine(MainPath, @"Test\Data\");

            if (!Directory.Exists(Settings.Instance.logpath))
            {
                Directory.CreateDirectory(Settings.Instance.logpath);
            }

            var logFile = Path.Combine(Settings.Instance.logpath, "Logg.txt");
            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }

            using (File.Create(logFile)) ;

            Settings.Instance.path = Path.Combine(MainPath, CardDbPath); // 用于CardDB类构造，读取CardDefs.xml

            InitSetting();

            Ai ai = Ai.Instance;
            ai.botBase = Bot;

            ai.autoTester(true, data, 0); // 0：全做 1:只斩杀 2：正常
            Console.WriteLine("测试完毕，请去Logg.txt文件末尾查看Ai操作");
        }

        public static void main(string[] args) //如果单独Run这个程序，main->Main
        {
            AiTest test = new AiTest();
            test.MainPath = @"D:\hb\r\Hearthbuddy\Routines\DefaultRoutine\Silverfish";
            test.TestFilePath = @"Test\Data\对局记录\日期2025-04-05\16-16-14-MAGE-PRIEST\3法力水晶 第6回合 第4步操作.txt";
            test.CardDbPath = "data";
            test.Bot = new Behavior丨狂野丨奥秘法();
            test.Test();
        }
    }
}
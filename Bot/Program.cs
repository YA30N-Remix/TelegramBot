using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotSharp;
using TelegramBotSharp.Types;

namespace Bot
{
    class Program
    {
        public static TelegramBot bot;
        static void Main(string[] args)
        {
            Console.WriteLine("Bot");
            bot = new TelegramBot("266568997:AAFq1tSEPSXf5qh9TST0y_-jp5-zyR-tgHA");
            Console.WriteLine("My Name Is : {0} , And My ID is : {1}",bot.Me.FirstName,bot.Me.Id);
            
            new Task(PollMessages).Start();
            Console.ReadLine();
        }
        static async void PollMessages()
        {
            while (true)
            {
                var resualt = await bot.GetMessages(); ;
                foreach (Message m in resualt)
                {
                    if (m.Chat != null)
                    {
                        Console.WriteLine("[{0}] {1} : {2}", m.Chat.Title, m.From.Username, m.Text);
                    }
                    else
                    {
                        Console.WriteLine("{0}:{1}" , m.From.Username,m.Text);
                    }
                    ControlMessages(m);
                }
            }
           
        }
        private static void ControlMessages(Message m)
        {

            if (m.Text == null) return;
            MessageTarget target = (MessageTarget)m.Chat ?? m.From;
            if (m.Text.Contains("hi"))
            {
                bot.SendMessage(target, "سلام . خوبی؟");
            }
            else if(m.Text.Contains("صلوات")){
                bot.SendMessage(target, "الهم صلی علی محمد و آل محمد");
            }
            else
            {
                
                bot.SendMessage(target, "متوجه نشدم", false, m, new ForceReplyOptions(true));
            }
        }
    }
}

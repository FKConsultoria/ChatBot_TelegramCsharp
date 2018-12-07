using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace MensagensSimplesTelegram
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("");//Token do Bot sem esse token não funciona.

        static void Main(string[] args)
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;

            Bot.StartReceiving();//Quando inicia as mensagens
            Console.ReadLine();//Quanda o readLine acionado significa que ja esta em uso o telegram dai basta mandar a mensagem ao chatbot.
            Bot.StopReceiving();//finaliza as mensagens
        }
        

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var me = Bot.GetMeAsync().Result;//Pega as informações do Bot por exemplo o nome, o id do telegram

            //Aqui a conversa e bem simples, ao digitar a mensagem ira cair nos ifs e a resposta será com o Bot.sendTextMessageAsync
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)

                if (e.Message.Text == "/start")
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Olá sou um ChatBot em Desenvolvimento em que posso te ajudar? " +
                        "                                       Lembrando que ainda só sei palavras de comprimentos:");
                else if (e.Message.Text == "Como você está?")
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Estou bem e você? ");
                else if (e.Message.Text == "Estou bem também")
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Que Ótimo 😀");//coloqui emoji so para ver se no C# tambem tem suporte ao emoji.
                else if (e.Message.Text == "Até Logo")
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Até...👋 " + e.Message.Chat.Username);
            
        }
    }
}

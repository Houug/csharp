// https://telegrambots.github.io/book/1/example-bot.html
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("6784029185:AAHGzAR91ncQQSQEGBg22xgD-paIq98P_eY");

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Теперь у нас есть 2 блока update.CallbackQuery - обработка callback
    if (update.CallbackQuery is { } callback)
    {
        // В callback.Data приходит сообщение из кнопки из поля callbackData
        if (callback.Data == "правильный")
        {
            Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: callback.Message.Chat.Id,
                    text: "Вы правильно ответили на вопрос"
            );
        }
        if (callback.Data == "неправильный")
        {
            Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: callback.Message.Chat.Id,
                    text: "Вы НЕправильно ответили на вопрос"
            );
        }
    }

    if (update.Message is { } message)
    {
        // Only process text messages
        if (message.Text is { } messageText)
        {
            // Отбор по команде /cosmos
            if (message.Text == "/cosmos")
            {
                // Создание клавиатуры
                ReplyKeyboardMarkup keyboard = new(new[]
                {
                    // каждая строчка здесь - строчка в клавиатуре
                    new KeyboardButton[] { "Меркурий", "Венера" },
                    new KeyboardButton[] { "Земля", "Марс" },
                    new KeyboardButton[] { "Юпитер" },
                    new KeyboardButton[] { "Сатурн", "Уран", "Нептун", "Плутон" }
                })
                {
                    ResizeKeyboard = true
                };
                Message sentMessage = await botClient.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "Выбери планету:",
                       // Подключение клавиатуры к сообщению (она открывается при отправке сообщения) 
                       replyMarkup: keyboard
                );
            }

            if (message.Text == "/quiz")
            {
                InlineKeyboardMarkup inlineKeyboard = new(new[]
                {
                    // Первая строка
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: "🔴", callbackData: "правильный"),
                        InlineKeyboardButton.WithCallbackData(text: "🟠", callbackData: "неправильный"),
                    },
                    // Вторая строка
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: "🟢", callbackData: "неправильный"),
                        InlineKeyboardButton.WithCallbackData(text: "💛", callbackData: "неправильный"),
                    },
                });

                Message sentMessage = await botClient.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "Выбери красный цвет:",
                       // Подключение клавиатуры к сообщению (она открывается при отправке сообщения) 
                       replyMarkup: inlineKeyboard
                );
            }
        }

        if (message.Sticker is { } messageSticker)
        {
            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageSticker.FileId}' message in chat {chatId}.");

            // Echo received message text
            Message sentMessage = await botClient.SendStickerAsync(
                chatId: chatId,
                sticker: InputFile.FromFileId(message.Sticker.FileId),
                cancellationToken: cancellationToken);
        }

        if (message.Photo is { } messagePhoto)
        {
            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messagePhoto}' message in chat {chatId}.");
            var my_photo_fileid = messagePhoto[messagePhoto.Count() - 1].FileId;
            // Echo received message text
            Message sentMessage = await botClient.SendPhotoAsync(
                chatId: chatId,
                photo: InputFile.FromFileId(my_photo_fileid),
                cancellationToken: cancellationToken);
        }
    }
    
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}
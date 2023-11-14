// Документация к библиотеке
// https://telegrambots.github.io/book/1/example-bot.html
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

// Создание бота, вставляем токен из BotFather
var botClient = new TelegramBotClient("6784029185:AAHGzAR91ncQQSQEGBg22xgD-paIq98P_eY");

// Технические строки (они нужны, но нам пока нет) начало
using CancellationTokenSource cts = new();
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>()
};
// Технические строки (они нужны, но нам пока нет) конец

// Запуск бота
botClient.StartReceiving(
    updateHandler: HandleUpdateAsync, // Обработчик обновлений
    pollingErrorHandler: HandlePollingErrorAsync, // Обработчик ошибок
    receiverOptions: receiverOptions, // Технические строки (они нужны, но нам пока нет)
    cancellationToken: cts.Token // Технические строки (они нужны, но нам пока нет)
);

// Получаем данные о боте
var me = await botClient.GetMeAsync();

// Выводим в консоль уведомление о запуске бота
Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Технические строки (они нужны, но нам пока нет)
cts.Cancel();

// Обработчк обновлений
async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Отсеиваем все обновления, которые НЕ являются сообщениями
    if (update.Message is not { } message)
        return;

    // Если сообщение является текстом, тогда выполняем код внутри
    if (message.Text is { } messageText) // <-- messageText означает сообщение с текстом
    {
        // Получаем ID чата, в которое пришло сообщение
        var chatId = message.Chat.Id;

        // Получаем вывод в консоль логов
        Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

        // Отправка сообщения типа текст
        Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Привет, ты отправил сообщение!\n{messageText}",
            cancellationToken: cancellationToken);
    }

    // Если сообщение является стикером, тогда выполняем код внутри
    if (message.Sticker is { } messageSticker)
    {
        // Получаем ID чата, в которое пришло сообщение
        var chatId = message.Chat.Id;

        // Получаем вывод в консоль логов
        Console.WriteLine($"Received a '{messageSticker}' message in chat {chatId}.");

        // Отправка сообщения типа стикер
        Message sentMessage = await botClient.SendStickerAsync(
            chatId: chatId,
            sticker: InputFile.FromFileId(message.Sticker.FileId),
            cancellationToken: cancellationToken);
    }

    
}

// Технические строки (они нужны, но нам пока нет)
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
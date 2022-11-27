string animalName = string.Empty;
string choosenAnimal;
string[] animals = new string[]
{
    "Кошка",
    "Собака",
    "Дракон",
    "Жираф",
    "Бегемот",
    "Орёл",
};
string[] commands =
{
    "кормить", // еда -к
    "кататься", // еда -кт
    "спать", // -с
    "играть", // и
    "гулять",
};

Print("Здравствуйте. Добро пожаловать в 'Тамагочи'");
Print("Для продолжения нужно выбрать зверька. Введите цифру");

for (int i = 0; i < animals.Length; i++)
{
    Console.WriteLine(i + 1 + "." + animals[i]);
}

var number = GetNumber();
choosenAnimal = animals[number - 1];
Print("Прекрасно. Вы выбрали: " + choosenAnimal);
Print("Как назовёте? Введите имя:");
animalName = GetText();

Console.Clear();
Print($"Поздравляем. На свет появился {choosenAnimal} {animalName}");
Print("Вам доступны следующие команды:");

foreach (var command in commands)
{
    Print(command + " -" + command[0]);
}

while (true)
{
    Print("Введите команду. Для завершения введите 'exit'");

    var command = GetCommand();
    if (command == "exit")
    {
        break;
    }
    switch (command)
    {
        case "кормить":
            Print($"{choosenAnimal} {animalName} покушал");
            break;
        default:
            break;
    }
}

Console.WriteLine("Всего доброго");



void Print(string message)
{
    Console.WriteLine(message);
}

int GetNumber()
{
    int n;
    while (!int.TryParse(Console.ReadLine(), out n))
    {
        n = 0;
        Console.WriteLine("Вы ввели некорректные данные");
    }

    return n;
}

string GetCommand()
{
    string result = null;
    while (result == null || result == "exit")
    {
        var command = GetText();
        if (command == "exit")
        {
            return command;
        }
        if ((command.Length < 2 || command.Length > 3) || command[0] != '-')
        {
            Print("Такой команды не существует");
        }
        else
        {
            result = command switch
            {
                "-к" => commands[0],
                "-кт" => commands[1],
                "-с" => commands[2],
                "-и" => commands[3],
                "-г" => commands[4],
                "exit" => "exit",
                _ => null
            };
        }
    }
    return result;
}

string GetText()
{
    string text;
    bool isValid;
    do
    {
        text = Console.ReadLine().Trim();
        isValid = !string.IsNullOrEmpty(text);

        if (!isValid)
        {
            Console.WriteLine("Вы ввели некорректные данные");
        }

    } while (!isValid);

    return text;
}
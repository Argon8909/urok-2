﻿namespace WebApp;

using System;
using System.Collections.Generic;

public class DataGenerator
{
    private  readonly Random Random = new Random();

    private  readonly List<string> FirstNames = new List<string>
    {
        "Александр", "Андрей", "Артем", "Владимир", "Иван", "Дмитрий", "Максим", "Никита", "Сергей", "Егор",
        "Алексей", "Александр", "Михаил", "Кирилл", "Даниил", "Артем", "Илья", "Максим", "Роман", "Владислав",
        "Денис", "Евгений", "Тимофей", "Матвей", "Антон", "Андрей", "Михаил", "Иван", "Николай", "Сергей",
        "Александр", "Егор", "Даниил", "Роман", "Кирилл", "Алексей", "Илья", "Артем", "Владислав", "Денис",
        "Владимир", "Максим", "Никита", "Тимофей", "Сергей", "Евгений", "Антон", "Матвей", "Андрей", "Дмитрий",
        "Анна", "Мария", "Ольга", "Екатерина", "Ирина", "Татьяна", "Елена", "Александра", "Виктория", "Евгения",
        "Алина", "Елизавета", "Полина", "Ксения", "Наталья", "Светлана", "Маргарита", "Юлия", "Валерия", "Кристина",
        "Ангелина", "Дарья", "Анастасия", "Вероника", "Людмила", "Надежда", "Милана", "Инна", "Лариса", "Любовь",
    };


    private  readonly List<string> LastNames = new List<string>
    {
        "Иванов", "Петров", "Смирнов", "Соколов", "Михайлов", "Федоров", "Морозов", "Волков", "Ковалев", "Зайцев",
        "Павлов", "Семенов", "Голубев", "Виноградов", "Богданов", "Воробьев", "Федотов", "Михайлов", "Беляев",
        "Тарасов",
        "Белов", "Медведев", "Андреев", "Кравцов", "Кузьмин", "Миронов", "Шестаков", "Коновалов", "Быков", "Селезнев",
        "Мельников", "Дмитриев", "Егоров", "Степанов", "Никитин", "Самсонов", "Зайцев", "Козлов", "Ситников", "Марков",
        "Новиков", "Соловьев", "Кошелев", "Шилов", "Кудряшов", "Киреев", "Щербаков", "Бычков", "Герасимов", "Рябов",
        "Акимов", "Кондратьев", "Григорьев", "Калашников", "Матвеев", "Бобров", "Ширяев", "Васильев", "Исаев",
        "Суханов",
        "Алексеев", "Ковалев", "Кудрявцев", "Трофимов", "Фомин", "Кузнецов", "Ильин", "Касаткин", "Максимов", "Кононов",
        "Буров", "Сорокин", "Ефимов", "Фролов", "Молчанов", "Лазарев", "Игнатов", "Савельев", "Тимофеев", "Соловьев",
        "Капустин", "Лапин", "Лебедев", "Шестаков", "Коновалов", "Савин", "Лазарев", "Игнатов", "Савельев", "Тимофеев",
        "Соловьев", "Капустин", "Лапин", "Лебедев", "Шестаков", "Коновалов", "Савин", "Лазарев", "Игнатов", "Савельев",
        "Тимофеев", "Соловьев", "Капустин", "Лапин", "Лебедев", "Шестаков", "Коновалов", "Савин", "Лазарев", "Игнатов",
        "Савельев", "Тимофеев", "Соловьев", "Капустин", "Лапин", "Лебедев", "Шестаков", "Коновалов", "Савин", "Лазарев"
        // Добавьте еще фамилий по вашему желанию
    };

// Добавляем женские фамилии (половина списка)
/*
        for (int i = 0; i < LastNames.Count / 2; i++)
    {
        LastNames.Add(LastNames[i] + "а");
    }
*/

    private  readonly List<string> Cities = new List<string>
    {
        "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Нижний Новгород", "Казань", "Самара", "Омск",
        "Челябинск", "Ростов-на-Дону", "Уфа", "Волгоград", "Пермь", "Красноярск", "Воронеж", "Саратов", "Краснодар",
        "Тольятти", "Ижевск", "Барнаул", "Ульяновск", "Тюмень", "Иркутск", "Владивосток", "Ярославль", "Хабаровск",
        "Махачкала", "Оренбург", "Новокузнецк", "Кемерово", "Рязань", "Томск", "Астрахань", "Пенза", "Липецк",
        "Киров", "Чебоксары", "Балашиха", "Калининград", "Тула", "Курск", "Севастополь", "Сочи", "Улан-Удэ",
        "Тверь", "Магнитогорск", "Иваново", "Брянск", "Белгород", "Сургут", "Владимир", "Архангельск", "Находка",
        "Симферополь", "Ставрополь", "Калуга", "Смоленск", "Чита", "Волжский", "Саранск", "Тамбов", "Владикавказ",
        "Мурманск", "Подольск", "Грозный", "Стерлитамак", "Нижнекамск", "Йошкар-Ола", "Керчь", "Орёл", "Череповец",
        "Балаково", "Северодвинск", "Черкесск", "Петрозаводск", "Копейск", "Коломна", "Ангарск", "Мытищи", "Люберцы",
        "Волгодонск", "Псков", "Южно-Сахалинск", "Братск", "Нижневартовск", "Комсомольск-на-Амуре", "Шахты",
        "Новочеркасск",
        "Дзержинск", "Нальчик", "Орск", "Сыктывкар", "Нижний Тагил", "Бийск", "Анапа", "Благовещенск",
        "Великий Новгород",
        "Тамбов", "Владикавказ", "Мурманск", "Подольск", "Сыктывкар", "Нижний Тагил", "Бийск", "Анапа", "Благовещенск",
        "Караганда", "Ош", "Джалал-Абад", "Туркестан", "Тараз", "Бишкек", "Ош", "Баткен", "Коканд", "Маргилан",
        "Ташкент", "Самарканд", "Навои", "Андижан", "Бухара", "Наманган", "Алматы", "Шымкент", "Талдыкорган", "Актау",
        "Атырау", "Усть-Каменогорск", "Павлодар", "Караганда", "Киев", "Актобе", "Тараз", "Астана", "Петропавловск",
        "Семей",
        "Актюбинск", "Костанай", "Темиртау", "Туркестан", "Уральск", "Атырау", "Кызылорда", "Риддер", "Талдыкорган",
        "Текели",
        "Шымкент", "Актау", "Балхаш", "Астана", "Павлодар", "Кокшетау", "Экибастуз", "Каскелен", "Темиртау", "Атырау",
        "Талгар", "Петропавловск", "Семей", "Актюбинск", "Костанай", "Жезказган", "Кокшетау", "Туркестан", "Уральск",
        "Караганда"
    };


    private  readonly List<string> Streets = new List<string>
    {
        "Ленина улица", "Пушкина улица", "Гагарина улица", "Мира улица", "Советская улица", "Школьная улица",
        "Парковая улица", "Молодежная улица",
        "Кирова улица", "Центральная улица", "Набережная улица", "Садовая улица", "Комсомольская улица",
        "Совхозная улица", "Зеленая улица",
        "Горького улица", "Светлая улица", "Заречная улица", "Строителей улица", "Маяковского улица",
        "Железнодорожная улица", "Победы улица",
        "Первомайская улица", "Коммунистическая улица", "Заводская улица", "Рабочая улица", "Солнечная улица",
        "Южная улица", "Звездная улица",
        "Песчаная улица", "Трудовая улица", "Лесная улица", "Мичурина улица", "Степная улица", "Сиреневая улица",
        "Калинина улица",
        "Полярная улица", "Молодежный переулок", "Заречный переулок", "Вокзальная улица", "Луговая улица",
        "Гагарина переулок", "Горная улица",
        "Шоссейная улица", "Славянская улица", "Красноармейская улица", "Мостовая улица", "Пионерская улица",
        "Береговая улица", "Мельничная улица",
        "Ломоносова улица", "Красная улица", "Спортивная улица", "Кировский переулок", "Маркса улица", "Сосновая улица",
        "Пушкинский переулок",
        "Весенняя улица", "Цветочная улица", "Дружбы улица", "Гагарина переулок", "Лермонтова улица", "Мирная улица",
        "Садовый переулок",
        "Колхозная улица", "Тверская улица", "Речная улица", "Светлый переулок", "Заводской переулок",
        "Песочный переулок", "Зеленый переулок",
        "Школьный переулок", "Московская улица", "Красногвардейский переулок", "Садовый переулок",
        "Пионерский переулок", "Мичуринский переулок",
        "Южный переулок", "Лесной переулок", "Горный переулок", "Заречный переулок", "Строительный переулок",
        "Коммунистический переулок",
        "Солнечный переулок", "Рабочий переулок", "Юбилейный переулок", "Вокзальный переулок", "Луговой переулок",
        "Полевой переулок",
        "Гагарина переулок", "Восточный переулок", "Северный переулок", "Звездный переулок", "Песочный переулок",
        "Трудовой переулок",
        "Заводской переулок", "Комсомольский переулок", "Молодежный переулок", "Молодежная улица", "Заречная улица",
        "Строителей улица",
        "Кирова улица", "Центральная улица", "Набережная улица", "Садовая улица", "Комсомольская улица",
        "Совхозная улица", "Зеленая улица",
        "Горького улица", "Светлая улица", "Заречная улица", "Строителей улица", "Маяковского улица",
        "Железнодорожная улица", "Победы улица",
        "Первомайская улица", "Коммунистическая улица", "Заводская улица", "Рабочая улица", "Солнечная улица",
        "Южная улица", "Звездная улица",
        "Песчаная улица", "Трудовая улица", "Лесная улица", "Мичурина улица", "Степная улица", "Сиреневая улица",
        "Калинина улица",
        "Полярная улица", "Молодежный переулок", "Заречный переулок", "Вокзальная улица", "Луговая улица",
        "Гагарина переулок", "Горная улица",
        "Шоссейная улица", "Славянская улица", "Красноармейская улица", "Мостовая улица", "Пионерская улица",
        "Береговая улица", "Мельничная улица",
        "Ломоносова улица", "Красная улица", "Спортивная улица", "Кировский переулок", "Маркса улица", "Сосновая улица",
        "Пушкинский переулок",
        "Весенняя улица", "Цветочная улица", "Дружбы улица", "Гагарина переулок", "Лермонтова улица", "Мирная улица",
        "Садовый переулок",
        "Колхозная улица", "Тверская улица", "Речная улица", "Светлый переулок", "Заводской переулок",
        "Песочный переулок", "Зеленый переулок",
        "Школьный переулок", "Московская улица", "Красногвардейский переулок", "Садовый переулок",
        "Пионерский переулок", "Мичуринский переулок",
        "Южный переулок", "Лесной переулок", "Горный переулок", "Заречный переулок", "Строительный переулок",
        "Коммунистический переулок",
        "Солнечный переулок", "Рабочий переулок", "Юбилейный переулок", "Вокзальный переулок", "Луговой переулок",
        "Полевой переулок",
        "Гагарина переулок", "Восточный переулок", "Северный переулок", "Звездный переулок", "Песочный переулок",
        "Трудовой переулок",
        "Заводской переулок", "Комсомольский переулок", "Молодежный переулок", "Парковый переулок",
        "Шоссейный переулок", "Ленинский переулок",
        "Маяковского переулок", "Комсомольский переулок", "Заводской переулок", "Песочный переулок",
        "Советский переулок", "Красный переулок",
        "Московский переулок", "Железнодорожный переулок", "Трудовой переулок", "Цветочный переулок",
        "Садовый переулок", "Лесной переулок",
        "Рабочий переулок", "Пионерский переулок", "Песочный переулок", "Гагаринский переулок", "Южный переулок",
        "Северный переулок",
        "Славянский переулок", "Комсомольский переулок", "Молодежный переулок", "Заречный переулок", "Ленина улица",
        "Гагарина улица",
        "Мира улица", "Советская улица", "Школьная улица", "Парковая улица", "Молодежная улица", "Кирова улица",
        "Центральная улица",
        "Набережная улица", "Садовая улица", "Комсомольская улица", "Совхозная улица", "Зеленая улица",
        "Горького улица", "Светлая улица",
        "Заречная улица", "Строителей улица", "Маяковского улица", "Железнодорожная улица", "Победы улица",
        "Первомайская улица",
        "Коммунистическая улица", "Заводская улица", "Рабочая улица", "Солнечная улица", "Южная улица",
        "Звездная улица", "Песчаная улица",
        "Трудовая улица", "Лесная улица", "Мичурина улица", "Степная улица", "Сиреневая улица", "Калинина улица",
        "Полярная улица",
        "Молодежный переулок", "Заречный переулок", "Вокзальная улица", "Луговая улица", "Гагарина переулок",
        "Горная улица", "Шоссейная улица",
        "Славянская улица", "Красноармейская улица", "Мостовая улица", "Пионерская улица", "Береговая улица",
        "Мельничная улица", "Ломоносова улица",
        "Красная улица", "Спортивная улица", "Кировский переулок", "Маркса улица", "Сосновая улица",
        "Пушкинский переулок", "Весенняя улица",
        "Цветочная улица", "Дружбы улица", "Гагарина переулок", "Лермонтова улица", "Мирная улица", "Садовый переулок",
        "Колхозная улица",
        "Тверская улица", "Речная улица", "Светлый переулок", "Заводской переулок", "Песочный переулок",
        "Зеленый переулок", "Школьный переулок",
        "Московская улица", "Красногвардейский переулок", "Садовый переулок", "Пионерский переулок",
        "Мичуринский переулок", "Южный переулок",
        "Лесной переулок", "Горный переулок", "Заречный переулок", "Строительный переулок", "Коммунистический переулок",
        "Солнечный переулок",
        "Рабочий переулок", "Юбилейный переулок", "Вокзальный переулок", "Луговой переулок", "Полевой переулок",
        "Гагарина переулок",
        "Восточный переулок", "Звездный переулок", "Песочный переулок", "Трудовой переулок", "Заводской переулок",
        "Комсомольский переулок",
        "Молодежный переулок", "Парковый переулок", "Шоссейный переулок", "Ленинский переулок", "Маяковского переулок",
        "Комсомольский переулок",
        "Заводской переулок", "Песочный переулок", "Советский переулок", "Красный переулок", "Московский переулок",
        "Железнодорожный переулок",
        "Трудовой переулок", "Цветочный переулок", "Садовый переулок", "Лесной переулок", "Рабочий переулок",
        "Пионерский переулок",
        "Песочный переулок", "Гагаринский переулок", "Южный переулок", "Северный переулок", "Славянский переулок",
        "Комсомольский переулок",
        "Молодежный переулок", "Заречный переулок", "Ленина улица", "Гагарина улица", "Мира улица", "Советская улица",
        "Школьная улица",
        "Парковая улица", "Молодежная улица", "Кирова улица", "Центральная улица", "Набережная улица", "Садовая улица",
        "Комсомольская улица",
        "Совхозная улица", "Зеленая улица", "Горького улица", "Светлая улица", "Заречная улица", "Строителей улица",
        "Маяковского улица",
        "Железнодорожная улица", "Победы улица", "Первомайская улица", "Коммунистическая улица", "Заводская улица",
        "Рабочая улица", "Солнечная улица",
        "Южная улица", "Звездная улица", "Песчаная улица", "Трудовая улица", "Лесная улица", "Мичурина улица",
        "Степная улица", "Сиреневая улица",
        "Калинина улица", "Полярная улица", "Молодежный переулок", "Заречный переулок", "Вокзальная улица",
        "Луговая улица", "Гагарина переулок",
        "Горная улица", "Шоссейная улица", "Славянская улица", "Красноармейская улица", "Мостовая улица",
        "Пионерская улица", "Береговая улица",
        "Мельничная улица", "Ломоносова улица", "Красная улица", "Спортивная улица", "Кировский переулок",
        "Маркса улица", "Сосновая улица",
        "Пушкинский переулок", "Весенняя улица", "Цветочная улица", "Дружбы улица", "Гагарина переулок",
        "Лермонтова улица", "Мирная улица",
        "Садовый переулок"
    };

    public  string GenerateRandomFirstName()
    {
        return FirstNames[Random.Next(FirstNames.Count)];
    }

    public  string GenerateRandomLastName()
    {
        return LastNames[Random.Next(LastNames.Count)];
    }

    public string GenerateRandomPhoneNumber()
    {
        return string.Format("+7{0:###-###-####}", Random.Next(1000000000, 2000000000));
    }


    public  string GenerateRandomCity()
    {
        return Cities[Random.Next(Cities.Count)];
    }

    public  string GenerateRandomStreet()
    {
        return Streets[Random.Next(Streets.Count)];
    }

    public  string GenerateRandomHouseNumber()
    {
        return Random.Next(1, 999).ToString();
    }
}
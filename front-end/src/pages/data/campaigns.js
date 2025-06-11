const campaignsMock = [
    {
        id: "1",
        title: "Підтримка протидронового захисту",
        description:
            "Збір коштів на обладнання для боротьби з ворожими дронами.",
        raised: 7755,
        goal: 10000,
        category: "Дрони",
        direction: "Запорізький напрям",
        status: "Активний",
        volunteer: { name: "Пацко Максим", reputation: "Верифіковано" },
    },
    {
        id: "2",
        title: "Зимове спорядження 24 батальйону",
        description: "Ізоляційний одяг для солдатів на морозі.",
        raised: 8000,
        goal: 15000,
        category: "Одяг",
        direction: "Північний фронт",
        status: "Активний",
        volunteer: { name: "Микола Петренко", reputation: "Верифіковано" },
    },
    {
        id: "3",
        title: "Медикаменти для 10 бригади",
        description:
            "Невідкладна закупівля медикаментів та перев’язувальних матеріалів.",
        raised: 15000,
        goal: 15000,
        category: "Медицина",
        direction: "Південний фронт",
        status: "Закрито",
        volunteer: { name: "Катерина Шевченко", reputation: "Верифіковано" },
    },
];

export default campaignsMock;

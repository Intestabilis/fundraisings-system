import React from "react";
import {Box, VStack, Select, Input, Flex, Heading, HStack, Badge, Text, createListCollection} from "@chakra-ui/react";
import campaignsMock from "./data/campaigns.js";
import {Link} from "react-router-dom";



export default function HomePage(){

    // const categories = ["Всі", "Обладнання", "Одяг", "Медицина"];
    // const directions = [
    //     "Всі",
    //     "Східний фронт",
    //     "Північний фронт",
    //     "Південний фронт",
    //     "Західний фронт",
    // ];

    const directions = createListCollection({
        items: [
            {label: "Всі", value: "all"},
            {label: "Схід", value: "east"}
        ],
    })
    const equipments = createListCollection({
        items: [
            {label: "Всі", value: "all"},
            {label: "Дрони", value: "drones"}
        ],
    })


    const [filterEquipment, setFilterEquipment] = React.useState("Всі");
    const [filterDirection, setFilterDirection] = React.useState("Всі");
    const [searchTerm, setSearchTerm] = React.useState("");

    const filtered = campaignsMock.filter((c) => {
        return (
            (filterEquipment === "Всі" || c.category === filterEquipment) &&
            (filterDirection === "Всі" || c.direction === filterDirection) &&
            (c.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
                c.description.toLowerCase().includes(searchTerm.toLowerCase()))
        );
    });

    return (
        <Flex gap={8} direction={{ base: "column", md: "row" }}>
        <VStack spacing={4} align="stretch">
            <Input
                placeholder="Пошук..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
            />
            <Select.Root collection={directions}>
                <Select.Label>Напрям</Select.Label>
                <Select.Control>
                    <Select.Trigger>
                        <Select.ValueText placeholder="Напрямок" />
                    </Select.Trigger>
                    <Select.IndicatorGroup>
                        <Select.Indicator />
                    </Select.IndicatorGroup>
                </Select.Control>
                <Select.Content>
                    {directions.items.map((directions) => (
                        <Select.Item item={directions} key={directions.value}>
                            {directions.label}
                            <Select.ItemIndicator></Select.ItemIndicator>
                        </Select.Item>
                    ))}
                </Select.Content>
            </Select.Root>
            <Select.Root collection={equipments}>
                <Select.Label>Обладнання</Select.Label>
                <Select.Control>
                    <Select.Trigger>
                        <Select.ValueText placeholder="Тип обладнання" />
                    </Select.Trigger>
                    <Select.IndicatorGroup>
                        <Select.Indicator />
                    </Select.IndicatorGroup>
                </Select.Control>
                <Select.Content>
                    {equipments.items.map((equipment) => (
                        <Select.Item item={equipment} key={equipment.value}>
                            {equipment.label}
                            <Select.ItemIndicator></Select.ItemIndicator>
                        </Select.Item>
                    ))}
                </Select.Content>
            </Select.Root>
        </VStack>

        <Box flex="3" bg="white" rounded="md" p={5} shadow="md">
            <Heading size="lg" mb={6} className="font-bold text-indigo-700">
                Актуальні збори
            </Heading>
            <VStack spacing={6} align="stretch">
                {filtered.length === 0 ? (
                    <Text textAlign="center" color="gray.500" py={10}>
                        Збори не знайдено
                    </Text>
                ) : (
                    filtered.map((c) => (
                        <Box
                            key={c.id}
                            borderWidth="1px"
                            borderRadius="md"
                            p={5}
                            _hover={{ shadow: "lg", cursor: "pointer", borderColor: "indigo.500" }}
                            className="transition-shadow"
                        >
                            <Link to={`/campaign/${c.id}`}>
                                <Heading size="md" className="font-semibold">
                                    {c.title}
                                </Heading>
                                <Text mt={1} noOfLines={2}>
                                    {c.description}
                                </Text>
                                <HStack mt={2} spacing={3}>
                                    <Badge colorScheme={c.status === "Активний" ? "green" : "red"}>
                                        {c.status}
                                    </Badge>
                                    <Badge colorScheme="purple">{c.category}</Badge>
                                    <Badge colorScheme="cyan">{c.direction}</Badge>
                                </HStack>
                                <Text mt={2} fontSize="sm" color="gray.500">
                                    Зібрано: {c.raised.toLocaleString()} грн / {c.goal.toLocaleString()} грн
                                </Text>
                                <Text mt={2} fontSize="sm" color="gray.600">
                                    Волонтер: {c.volunteer.name} ({c.volunteer.reputation})
                                </Text>
                            </Link>
                        </Box>
                    ))
                )}
            </VStack>
        </Box>
        </Flex>
    )
}
/*import {
    Flex,
    Box,
    Heading,
    Input,
    Select,
    VStack,
    Text,
    HStack,
    Badge,
} from "@chakra-ui/react";
import { Link } from "react-router-dom";
import campaignsMock from "../data/campaigns";

const categories = ["Всі", "Обладнання", "Одяг", "Медицина"];
const directions = [
    "Всі",
    "Східний фронт",
    "Північний фронт",
    "Південний фронт",
    "Західний фронт",
];

export default function HomePage() {
    const [filterCategory, setFilterCategory] = React.useState("Всі");
    const [filterDirection, setFilterDirection] = React.useState("Всі");
    const [searchTerm, setSearchTerm] = React.useState("");

    const filtered = campaignsMock.filter((c) => {
        return (
            (filterCategory === "Всі" || c.category === filterCategory) &&
            (filterDirection === "Всі" || c.direction === filterDirection) &&
            (c.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
                c.description.toLowerCase().includes(searchTerm.toLowerCase()))
        );
    });

    return (
        <Flex gap={8} direction={{ base: "column", md: "row" }}>
            <Box
                flex="1"
                maxW={{ base: "full", md: "280px" }}
                bg="white"
                rounded="md"
                p={5}
                shadow="md"
            >
                <Heading size="md" mb={4} className="font-semibold text-indigo-600">
                    Фільтри
                </Heading>
                <VStack spacing={4} align="stretch">
                    <Input
                        placeholder="Пошук..."
                        value={searchTerm}
                        onChange={(e) => setSearchTerm(e.target.value)}
                    />
                    <Select
                        value={filterCategory}
                        onChange={(e) => setFilterCategory(e.target.value)}
                    >
                        {categories.map((c) => (
                            <option key={c} value={c}>
                                {c}
                            </option>
                        ))}
                    </Select>
                    <Select
                        value={filterDirection}
                        onChange={(e) => setFilterDirection(e.target.value)}
                    >
                        {directions.map((d) => (
                            <option key={d} value={d}>
                                {d}
                            </option>
                        ))}
                    </Select>
                </VStack>
            </Box>
            <Box flex="3" bg="white" rounded="md" p={5} shadow="md">
                <Heading size="lg" mb={6} className="font-bold text-indigo-700">
                    Актуальні збори
                </Heading>
                <VStack spacing={6} align="stretch">
                    {filtered.length === 0 ? (
                        <Text textAlign="center" color="gray.500" py={10}>
                            Збори не знайдено
                        </Text>
                    ) : (
                        filtered.map((c) => (
                            <Box
                                key={c.id}
                                borderWidth="1px"
                                borderRadius="md"
                                p={5}
                                _hover={{ shadow: "lg", cursor: "pointer", borderColor: "indigo.500" }}
                                className="transition-shadow"
                            >
                                <Link to={`/campaign/${c.id}`}>
                                    <Heading size="md" className="font-semibold">
                                        {c.title}
                                    </Heading>
                                    <Text mt={1} noOfLines={2}>
                                        {c.description}
                                    </Text>
                                    <HStack mt={2} spacing={3}>
                                        <Badge colorScheme={c.status === "Активний" ? "green" : "red"}>
                                            {c.status}
                                        </Badge>
                                        <Badge colorScheme="purple">{c.category}</Badge>
                                        <Badge colorScheme="cyan">{c.direction}</Badge>
                                    </HStack>
                                    <Text mt={2} fontSize="sm" color="gray.500">
                                        Зібрано: {c.raised.toLocaleString()} грн / {c.goal.toLocaleString()} грн
                                    </Text>
                                    <Text mt={2} fontSize="sm" color="gray.600">
                                        Волонтер: {c.volunteer.name} ({c.volunteer.reputation})
                                    </Text>
                                </Link>
                            </Box>
                        ))
                    )}
                </VStack>
            </Box>
        </Flex>
    );*/


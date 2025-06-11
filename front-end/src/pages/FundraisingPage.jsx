import React from "react";
import {Avatar, Badge, Text, Box, Button, Heading, HStack} from "@chakra-ui/react";
import {Link, useParams} from "react-router-dom";
import {Link as ChakraLink} from "@chakra-ui/react";
import campaignsMock from "../pages/data/campaigns.js";

export default function FundraisingPage(){
    const { id } = useParams();
    const fundraising = campaignsMock.find((c) => c.id === id);
    const testurl = "https://example.com";

    if (!fundraising)
        return (
            <Box bg="white" p={6} rounded="md" shadow="md" textAlign="center" color="red.500">
                Збір не знайдено
            </Box>
        );

    return (
        <Box maxW="4xl" mx="auto" bg="white" p={6} rounded="md" shadow="md">
            <Heading mb={4} className="text-indigo-700">
                {fundraising.title}
            </Heading>
            <Text mb={4}>{fundraising.description}</Text>

            <HStack mb={4}>
                <Badge colorScheme={fundraising.status === "Активний" ? "green" : "red"}>
                    {fundraising.status}
                </Badge>
                <Badge colorScheme="purple">{fundraising.category}</Badge>
                <Badge colorScheme="cyan">{fundraising.direction}</Badge>
            </HStack>

            <Text mb={4}>
                Зібрано: {fundraising.raised.toLocaleString()} / {fundraising.goal.toLocaleString()} грн
            </Text>
            <Link to={`/volunteer/${id}`}>
            <Box p={4} bg="gray.50" rounded="md" mb={6}>
                <Heading size="md" mb={2}>
                    Волонтер
                </Heading>
                <HStack>
                    <Avatar.Root>
                        <Avatar.Fallback name={fundraising.volunteer.name}></Avatar.Fallback>
                    </Avatar.Root>
                    <Box>
                        <Text fontWeight="bold">{fundraising.volunteer.name}</Text>
                        <Text>{fundraising.volunteer.reputation}</Text>
                    </Box>
                </HStack>
            </Box>
            </Link>
            <Button
                    asChild
                    colorScheme="indigo"
                    size="lg"
                    w="full"
            >
                <ChakraLink isExternal href={testurl}>Задонатити</ChakraLink>
            </Button>
            <Button
                as={Link}
                to={`/report/${fundraising.id}`}
                colorScheme="indigo"
                size="lg"
                w="full"
            >
                Поширити
            </Button>
            <Button color="red.400" size="sg" w="full" variant="subtle" >
                Поскаржитись
            </Button>
        </Box>
    )
}
/*
import {
    Box,
    Heading,
    Text,
    HStack,
    Badge,
    Avatar,
    Button,
} from "@chakra-ui/react";
import { useParams } from "react-router-dom";
import campaignsMock from "../data/campaigns";

export default function FundraisingPage() {
    const { id } = useParams();
    const campaign = campaignsMock.find((c) => c.id === id);

    if (!campaign)
        return (
            <Box bg="white" p={6} rounded="md" shadow="md" textAlign="center" color="red.500">
                Збір не знайдено
            </Box>
        );

    return (
        <Box maxW="4xl" mx="auto" bg="white" p={6} rounded="md" shadow="md">
            <Heading mb={4} className="text-indigo-700">
                {campaign.title}
            </Heading>
            <Text mb={4}>{campaign.description}</Text>

            <HStack mb={4}>
                <Badge colorScheme={campaign.status === "Активний" ? "green" : "red"}>
                    {campaign.status}
                </Badge>
                <Badge colorScheme="purple">{campaign.category}</Badge>
                <Badge colorScheme="cyan">{campaign.direction}</Badge>
            </HStack>

            <Text mb={4}>
                Зібрано: {campaign.raised.toLocaleString()} / {campaign.goal.toLocaleString()} грн
            </Text>

            <Box p={4} bg="gray.50" rounded="md" mb={6}>
                <Heading size="md" mb={2}>
                    Волонтер
                </Heading>
                <HStack>
                    <Avatar name={campaign.volunteer.name} />
                    <Box>
                        <Text fontWeight="bold">{campaign.volunteer.name}</Text>
                        <Text>{campaign.volunteer.reputation}</Text>
                    </Box>
                </HStack>
            </Box>

            <Button colorScheme="indigo" size="lg" w="full">
                Пожертвувати
            </Button>
        </Box>
    );
}
*/

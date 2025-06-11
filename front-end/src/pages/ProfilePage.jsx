import React from "react";
import {Text, Avatar, Box, Heading, HStack, Tabs, Button, Spacer, Badge, VStack} from "@chakra-ui/react";
import {Link} from "react-router-dom";
import campaignsMock from "./data/campaigns.js";

export default function ProfilePage() {

    const fundraisings = campaignsMock;

    return (
        <Box bg="white" p={6} rounded="md" shadow="md">
            <Heading mb={4} className="text-indigo-700">
                Профіль користувача
            </Heading>
            <HStack spacing={6} mb={6}>
                <Avatar.Root>
                <Avatar.Fallback>
                </Avatar.Fallback>
                    <Avatar.Image>
                    </Avatar.Image>
                </Avatar.Root>
                <Box>
                    <Heading size="md">Пацко Максим</Heading>
                    <Text>Роль: Волонтер</Text>
                    <Text>Email: Maxym.Ptsk@gmail.com</Text>
                </Box>
                <Spacer></Spacer>
                <Box>
                    <Button as={Link} to="/create">
                        Відкрити збір
                    </Button>
                </Box>
            </HStack>
            <Tabs.Root>
                <Tabs.List>
                    <Tabs.Trigger value="fundraisings">
                        Мої збори
                    </Tabs.Trigger>
                    {/*<Tabs.Trigger value="analytics">*/}
                    {/*    Статистика*/}
                    {/*</Tabs.Trigger>*/}
                    <Tabs.Indicator />
                </Tabs.List>
                <Tabs.Content value="fundraisings">
                    <VStack spacing={6} align="stretch">
                        {fundraisings.length === 0 ? (
                            <Text textAlign="center" color="gray.500" py={10}>
                                Збори не знайдено
                            </Text>
                        ) : (
                            fundraisings.map((c) => (
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
                </Tabs.Content>
                <Tabs.Content value="analytics">
                </Tabs.Content>
            </Tabs.Root>
        </Box>
    )
}
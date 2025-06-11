import React from "react";
import { Box, Heading, Text, VStack, Button, Tabs } from "@chakra-ui/react";
import Verifications from "../components/Verifications.jsx";
import Complaints from "../components/Complaints.jsx";
import ManageEquipments from "../components/ManageEquipments.jsx";
export default function AdminDashboardPage(){
    return (
        // add lazyMount unmountOnExit after testing
        <Tabs.Root  defaultValue = "verifications">
            <Tabs.List>
                <Tabs.Trigger value="verifications">Запити</Tabs.Trigger>
                <Tabs.Trigger value="complaints">Скарги</Tabs.Trigger>
                <Tabs.Trigger value="weights">Алгоритм</Tabs.Trigger>
                <Tabs.Indicator />
            </Tabs.List>
            <Tabs.Content value="verifications">
            <Verifications></Verifications>
            </Tabs.Content>
            <Tabs.Content value="complaints">
                <Complaints></Complaints>
            </Tabs.Content>
            <Tabs.Content value="weights">
                <ManageEquipments></ManageEquipments>
            </Tabs.Content>
        </Tabs.Root>
    )
}
/*

export default function AdminDashboardPage() {
    return (
        <Box bg="white" rounded="md" shadow="md" p={6} maxW="5xl" mx="auto">
            <Heading mb={6} className="text-indigo-700">
                Адмін-панель
            </Heading>
            <Text>Тут буде функціонал верифікації волонтерів, розгляду скарг та модерації.</Text>
            <VStack spacing={4} mt={6} align="start">
                <Button colorScheme="purple">Перевірка волонтерів</Button>
                <Button colorScheme="red">Перегляд скарг</Button>
                <Button colorScheme="gray">Блокування волонтерів</Button>
            </VStack>
        </Box>
    );
}
*/

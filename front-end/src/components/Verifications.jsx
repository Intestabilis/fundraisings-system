import React from "react";
import {Badge, Box, Button, Flex, Heading, HStack, Spacer, Text, VStack} from "@chakra-ui/react";
import {Link} from "react-router-dom";

export default function Verifications() {
    return (

        <Box flex="3" bg="white" rounded="md" p={5} shadow="md">
            <Heading size="lg" mb={6} className="font-bold text-indigo-700">
                Запити на верифікацію
            </Heading>
            <VStack spacing={6} align="stretch">

                <Box
                    key={1}
                    borderWidth="1px"
                    borderRadius="md"
                    p={5}
                    _hover={{shadow: "lg", cursor: "pointer", borderColor: "indigo.500"}}
                    className="transition-shadow"
                >
                    {/*мб додати justify="center" потім*/}
                    <Flex align="center"  gap={2}>
                        <Link>лінк на збір</Link>
                        <Text textStyle="md" truncate>короткий опис скарги</Text>
                        <Spacer></Spacer>
                        <Text>статус запиту</Text>
                        <Button>Переглянути додані матеріали</Button>
                        <Text>дата створення</Text>
                    </Flex>
                </Box>

            </VStack>
        </Box>

)
}
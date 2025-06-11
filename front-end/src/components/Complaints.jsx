import React from "react";
import {Box, Button, Flex, Heading, VStack, Text, Link, Spacer} from "@chakra-ui/react";

export default function Complaints(){
    return (

        <Box flex="3" bg="white" rounded="md" p={5} shadow="md">
            <Heading size="lg" mb={6} className="font-bold text-indigo-700">
                Скарги
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
                        <Text>статус скарги</Text>
                    <Button>Переглянути скаргу</Button>
                        <Text>дата створення</Text>
                    </Flex>
                </Box>

            </VStack>
        </Box>

    )
}
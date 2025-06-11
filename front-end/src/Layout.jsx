import React from "react";
import {
    Box,
    Flex,
    Heading,
    Button,
    Spacer,
    Link as ChakraLink,
    HStack,
} from "@chakra-ui/react";
import { Link } from "react-router-dom";

export default function Layout({ children }) {


    return (
        <Box minH="100vh" bg="gray.50">
            <Flex
                as="header"
                bg="light"
                p={4}
                boxShadow="md"
                alignItems="center"
                position="sticky"
                top="0"
                zIndex={10}
            >
                <Heading
                    size="lg"
                    className="font-extrabold tracking-tight text-indigo-700"
                >
                    <ChakraLink as={Link} to="/" _hover={{ textDecoration: "none" }}>
                        Благодійна Платформа
                    </ChakraLink>
                </Heading>
                <Spacer />
                <HStack spacing={4} display={{ base: "none", md: "flex" }}>
                    <Button as={Link} to="/" variant="ghost" colorScheme="indigo">
                        Головна
                    </Button>
                    <Button as={Link} to="/profile" variant="ghost" colorScheme="indigo">
                        Профіль
                    </Button>
                    {/*<Button as={Link} to="/admin" variant="ghost" colorScheme="indigo">*/}
                    {/*    Адмін*/}
                    {/*</Button>*/}
                    {/*<Button as={Link} to="/login" colorScheme="indigo">*/}
                    {/*    Увійти*/}
                    {/*</Button>*/}
                </HStack>

            </Flex>

            <Box as="main" maxW="7xl" mx="auto" py={8} px={{ base: 4, md: 8 }}>
                {children}
            </Box>

            <Box
                as="footer"
                bg="light"
                py={6}
                mt={12}
                boxShadow="inner"
                textAlign="center"
                color="gray.500"
                fontSize="sm"
            >
                © 2025 Благодійна платформа для організації благодійних зборів на потреби війська
            </Box>
        </Box>
    );
}

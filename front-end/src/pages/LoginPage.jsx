import React from "react";
import {Box, Heading, VStack, Input, Button, Fieldset, Field} from "@chakra-ui/react";
import {Link as ChakraLink} from "@chakra-ui/react";
import {Link, useNavigate} from "react-router-dom";

export default function LoginPage() {
    const navigate = useNavigate();
    const handleSubmit = (e) => {
        e.preventDefault();
        // Placeholder: after login navigate to profile
        navigate("/profile");
    };

    return (
        <Box maxW="md" mx="auto" bg="white" p={6} rounded="md" shadow="md">
            <Heading mb={6} textAlign="center" className="text-indigo-700">
                Вхід
            </Heading>
            <Fieldset.Root>
                <Fieldset.Content>
                    <Field.Root>
                        <Field.Label>
                            Електронна пошта
                        </Field.Label>
                        <Input>
                        </Input>
                    </Field.Root>
                    <Field.Root>
                        <Field.Label>
                            Пароль
                        </Field.Label>
                        <Input type="password">
                        </Input>
                    </Field.Root>
                </Fieldset.Content>
            </Fieldset.Root>
            <VStack spacing={4} align="stretch">
                <Button colorScheme="indigo" type="submit" mt={4} w="full">
                    Увійти
                </Button>
                <ChakraLink colorPalette="gray" variant="ghost" textStyle="sm" textColor="gray.200" asChild>
                    <Link to={`/register`}> Не маєте акаунту? Натисніть, щоб зареєструватись</Link>
                </ChakraLink>
            </VStack>
        </Box>

    )
}
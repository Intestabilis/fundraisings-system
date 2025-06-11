import React, {useState} from "react";
import {Box, Heading, VStack, Input, Button, Fieldset, Field, Switch, Flex, Text, FileUpload} from "@chakra-ui/react";
import {Link, useNavigate} from "react-router-dom";
import { HiUpload } from "react-icons/hi"
import {Link as ChakraLink} from "@chakra-ui/react";
export default function RegisterPage() {
    const navigate = useNavigate();
    const handleSubmit = (e) => {
        e.preventDefault();
        // Placeholder: after login navigate to profile
        navigate("/profile");
    };
    const [checked, setChecked] = useState(false)
    return (
        <Box maxW="md" mx="auto" bg="white" p={6} rounded="md" shadow="md">
            <Heading mb={6} textAlign="center" className="text-indigo-700">
                Реєстрація
            </Heading>
            <Fieldset.Root>
                <Fieldset.Content>
                    <Field.Root>
                        <Field.Label>
                            Оберіть роль
                        </Field.Label>
                        <Flex textStyle="sm" width="100%" fontWeight="500" align="center" justify="center" gap={2}>
                            <Text>Користувач</Text>
                            <Switch.Root
                                checked={checked}
                                onCheckedChange={(e) => setChecked(e.checked)}
                            >
                                <Switch.HiddenInput/>
                                <Switch.Control>
                                    <Switch.Thumb/>
                                </Switch.Control>
                                <Switch.Label/>
                            </Switch.Root>
                            <Text>Волонтер</Text>
                        </Flex>
                    </Field.Root>
                    {checked && <Field.Root>
                        <Field.Label>
                            Додайте файли-підтвердження
                        </Field.Label>
                        <FileUpload.Root maxFiles={5}>
                            <FileUpload.HiddenInput />
                            <FileUpload.Trigger asChild>
                                <Button variant="outline" size="sm">
                                    <HiUpload /> Upload file
                                </Button>
                            </FileUpload.Trigger>
                            <FileUpload.List showSize clearable />
                        </FileUpload.Root>
                    </Field.Root>}
                    <Field.Root>
                        <Field.Label>
                            Ім'я
                        </Field.Label>
                        <Input>
                        </Input>
                    </Field.Root>
                    <Field.Root>
                        <Field.Label>
                            Прізвище
                        </Field.Label>
                        <Input>
                        </Input>
                    </Field.Root>
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
                    Зареєструватись
                </Button>
                <ChakraLink colorPalette="gray" variant="ghost" textStyle="sm" textColor="gray.200" asChild>
                    <Link to={`/login`}> Повернутись на сторінку входу</Link>
                </ChakraLink>
            </VStack>
        </Box>

)
}
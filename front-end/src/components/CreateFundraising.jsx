import React from "react";
import {
    Box,
    Heading,
    VStack,
    Fieldset,
    Field,
    Input,
    Textarea,
    Select,
    createListCollection,
    FileUpload,
    Icon,
    Text, Button, InputGroup, CloseButton
} from "@chakra-ui/react";
import {LuFileUp, LuUpload} from "react-icons/lu"
import {Form} from "react-router-dom";

export default function CreateFundraising() {

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

    return (
        <Box maxW="3xl" mx="auto" bg="white" p={6} rounded="md" shadow="md">
            <Heading mb={6} className="text-indigo-700">
                Створення збору
            </Heading>
            <VStack spacing={4} align="stretch">
                <Fieldset.Root>
                    <Fieldset.Legend></Fieldset.Legend>
                    <Fieldset.Content>
                        <Field.Root>
                            <Field.Label>
                                Назва збору
                            </Field.Label>
                            <Input>
                            </Input>
                        </Field.Root>
                        <Field.Root>
                            <Field.Label>
                                Посилання на монобанку
                            </Field.Label>
                            <Input>
                            </Input>
                        </Field.Root>
                        <Field.Root>
                            <Field.Label>Зображення збору</Field.Label>
                            <FileUpload.Root maxW="xl" alignItems="stretch" maxFiles={1} accept={["image/*"]}>
                                <FileUpload.HiddenInput />
                                <FileUpload.Dropzone>
                                    <Icon size="md" color="fg.muted">
                                        <LuUpload />
                                    </Icon>
                                    <FileUpload.DropzoneContent>
                                        <Box>Обкладинка збору</Box>
                                        <Box color="fg.muted">.png, .jpg до 2MB</Box>
                                    </FileUpload.DropzoneContent>
                                </FileUpload.Dropzone>
                                <FileUpload.List />
                            </FileUpload.Root>
                        </Field.Root>
                        <Select.Root collection={directions}>
                            <Select.Label>Напрям</Select.Label>
                            <Select.Control>
                                <Select.Trigger>
                                    <Select.ValueText placeholder="Напрямок"/>
                                </Select.Trigger>
                                <Select.IndicatorGroup>
                                    <Select.Indicator/>
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
                        <Field.Root>
                            <Field.Label>
                                Кінцева сума
                            </Field.Label>
                            <Input>
                            </Input>
                        </Field.Root>
                        <Field.Root>
                            <Field.Label>
                                Дедлайн
                            </Field.Label>
                            <Input>
                            </Input>
                        </Field.Root>
                        <Textarea placeholder="Опис збору">

                        </Textarea>
                    </Fieldset.Content>
                    <Button type="submit" alignSelf="flex-center">
                        Відкрити збір
                    </Button>
                </Fieldset.Root>
            </VStack>
        </Box>
    );
}
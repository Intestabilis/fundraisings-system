import React, { useEffect, useState } from "react";
import {
    Box,
    Image,
    SimpleGrid,
    Heading,
    Spinner,
    Text,
    Center,
} from "@chakra-ui/react";

export default function ReportPage() {
    const [images, setImages] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch("/api/gallery")
            .then((res) => {
                if (!res.ok) throw new Error("Помилка завантаження зображень");
                return res.json();
            })
            .then(setImages)
            .catch((err) => setError(err.message))
            .finally(() => setLoading(false));
    }, []);

    return (
        <Box maxW="7xl" mx="auto" p={6}>
            <Heading mb={6} color="indigo.700">
                Галерея
            </Heading>

            {loading ? (
                <Center py={10}>
                    <Spinner size="xl" />
                </Center>
            ) : error ? (
                <Center py={10}>
                    <Text color="red.500">{error}</Text>
                </Center>
            ) : (
                <SimpleGrid columns={{ base: 1, sm: 2, md: 3, lg: 4 }} spacing={6}>
                    {images.map((img, idx) => (
                        <Box key={idx} borderRadius="md" overflow="hidden" boxShadow="md">
                            <Image
                                src={img.url}
                                alt={img.alt || `Зображення ${idx + 1}`}
                                objectFit="cover"
                                w="full"
                                h="200px"
                            />
                        </Box>
                    ))}
                </SimpleGrid>
            )}
        </Box>
    );

}
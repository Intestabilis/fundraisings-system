import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Flex, Spacer } from '@chakra-ui/react';
import { useUser } from '../hooks/useUser';

const Navbar = () => {
    const { user, logout } = useUser();
    return (
        <Flex p={4} bg="gray.100" boxShadow="md">
            <Link to="/">🏠 Головна</Link>
            <Spacer />
            {user && <Link to="/profile">👤 Профіль</Link>}
            {user?.role === 'volunteer' && <Link to="/create"><Button ml={2}>Створити збір</Button></Link>}
            {user?.role === 'admin' && <Link to="/admin"><Button ml={2}>Адмін-панель</Button></Link>}
            {!user && (
                <>
                    <Link to="/login"><Button ml={4}>Увійти</Button></Link>
                    <Link to="/register"><Button ml={2}>Зареєструватись</Button></Link>
                </>
            )}
            {user && <Button ml={4} onClick={logout}>Вийти</Button>}
        </Flex>
    );
};

export default Navbar;
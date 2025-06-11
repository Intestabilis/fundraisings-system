import React, { useContext, createContext, useState, useEffect } from 'react';

// 1. Створюємо контекст
const UserContext = createContext();

// 2. Провайдер
export const UserProvider = ({ children }) => {
    const [user, setUser] = useState(null);

    // Емуляція завантаження користувача (наприклад, з localStorage або API)
    useEffect(() => {
        const storedUser = localStorage.getItem('user');
        if (storedUser) setUser(JSON.parse(storedUser));
    }, []);

    const login = (userData) => {
        setUser(userData);
        localStorage.setItem('user', JSON.stringify(userData));
    };

    const logout = () => {
        setUser(null);
        localStorage.removeItem('user');
    };

    return (
        <UserContext.Provider value={{ user, login, logout }}>
            {children}
        </UserContext.Provider>
    );
};
// 3. Хук для використання
export const useUser = () => {
    const context = useContext(UserContext);
    if (!context) {
        throw new Error('useUser must be used within a UserProvider');
    }
    return context;
};
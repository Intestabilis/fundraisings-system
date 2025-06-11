import ReactDOM from "react-dom/client";
import React from 'react';
import './index.css'
import App from './App.jsx'
import { ChakraProvider, defaultSystem } from "@chakra-ui/react"
import { UserProvider } from './hooks/useUser';
ReactDOM.createRoot(document.getElementById("root")).render(
<React.StrictMode>
    <ChakraProvider value={defaultSystem}>
        <UserProvider>
            <App></App>
        </UserProvider>
    </ChakraProvider>
</React.StrictMode>
);

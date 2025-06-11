import React from "react";

import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Layout from "./Layout";
import HomePage from "./pages/HomePage";
import ProfilePage from "./pages/ProfilePage.jsx";
import LoginPage from "./pages/LoginPage";
import CreateFundraisingPage from "./pages/CreateFundraisingPage";
import FundraisingPage from "./pages/FundraisingPage.jsx";
import AdminDashboardPage from "./pages/AdminDashboardPage";
import RegisterPage from "./pages/RegisterPage.jsx";
import ReportPage from "./pages/ReportPage.jsx";
import VolunteerPage from "./pages/VolunteerPage.jsx";

export default function App() {
    return (

            <Router>
                <Layout>
                    <Routes>
                        <Route path="/" element={<HomePage />} />
                        <Route path="/profile" element={<ProfilePage />} />
                        <Route path="/create" element={<CreateFundraisingPage />} />
                        <Route path="/campaign/:id" element={<FundraisingPage />} />
                        <Route path="/fundraising/:id" element={<FundraisingPage />} />
                        <Route path="/report/:id" element={<ReportPage />} />
                        <Route path="/login" element={<LoginPage />} />
                        <Route path="/register" element={<RegisterPage />} />
                        <Route path="/admin" element={<AdminDashboardPage />} />
                        <Route path="/volunteer/:id" element={<VolunteerPage />} />
                        <Route
                            path="*"
                            element={
                                <div className="text-center py-20 text-red-600 font-semibold text-xl">
                                    Сторінку не знайдено
                                </div>
                            }
                        />
                    </Routes>
                </Layout>
            </Router>

    );
}

import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import HomePage from '@/pages old/HomePage.jsx';
import ProfilePage from '@/pages old/ProfilePage.jsx';
import FundraiserDetailsPage from '@/pages old/FundraiserDetailsPage.jsx';
import CreateFundraiserPage from '@/pages old/CreateFundraiserPage.jsx';
import AdminPanelPage from '@/pages old/AdminPanelPage.jsx';
import LoginPage from '@/pages old/LoginPage.jsx';
import RegisterPage from '@/pages old/RegisterPage.jsx';
import ReportPage from '@/pages old/ReportPage.jsx';
import Navbar from './components/Navbar.jsx';

function App() {
  return (
      <Router>
        <Navbar />
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/profile" element={<ProfilePage />} />
          <Route path="/fundraiser/:id" element={<FundraiserDetailsPage />} />
          <Route path="/create" element={<CreateFundraiserPage />} />
          <Route path="/admin" element={<AdminPanelPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/report/:id" element={<ReportPage />} />
          <Route path="*" element={<Navigate to="/" replace />} />
        </Routes>
      </Router>
  );
}

export default App

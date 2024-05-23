// import { useState } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Login from "./pages/LoginPage/Login";
import PageTemplate from "./pages/PageTemplate/PageTemplate";
import "./assets/css/antdcustomcss.css";
import InfoPage from "./pages/PageContent/InfoPage";
import HomePage from "./pages/PageContent/HomePage";
function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/Login" element={<Login />} />
          {/* <Route path="/" element={<AuthProvider />}> */}
          <Route path="/" element={<PageTemplate />}>
            <Route path="/" element={<HomePage />} />
            <Route path="/Home" element={<HomePage />} />
            <Route path="/Info" element={<InfoPage />} />
            <Route path="/ChangePassword" element={<InfoPage />} />
          </Route>
          {/* </Route> */}
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;

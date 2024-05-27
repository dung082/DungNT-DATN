// import { useState } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import DrawerComponent from "./assets/Component/DrawerComponent";
import PopUpComponent from "./assets/Component/PopUpComponent";
import "./assets/css/antdcustomcss.css";
import Login from "./pages/LoginPage/Login";
import HomePage from "./pages/PageContent/HomePage";
import InfoPage from "./pages/PageContent/InfoPage";
import PageTemplate from "./pages/PageTemplate/PageTemplate";
function App() {
  return (
    <>
      <BrowserRouter>
        <PopUpComponent />
        <DrawerComponent />
        <Routes>
          <Route path="/Login" element={<Login />} />
          {/* <Route path="/" element={<AuthProvider />}> */}
          <Route path="/" element={<PageTemplate />}>
            <Route path="/" element={<HomePage />} />
            <Route path="/Home" element={<HomePage />} />
            <Route path="/Info" element={<InfoPage />} />
            <Route path="/ChangePassword" element={<HomePage />} />
          </Route>
          {/* </Route> */}
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;

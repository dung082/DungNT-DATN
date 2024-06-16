// import { useState } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import DrawerComponent from "./assets/Component/DrawerComponent";
import PopUpComponent from "./assets/Component/PopUpComponent";
import "./assets/css/antdcustomcss.css";
import Login from "./pages/LoginPage/Login";
import PageTemplate from "./pages/PageTemplate/PageTemplate";
import HomePage from "./pages/PageContent/HomePage/HomePage";
import InfoPage from "./pages/PageContent/InfoPage/InfoPage";
import ChuongTrinhHoc from "./pages/PageContent/ChuongTrinhHoc/ChuongTrinhHoc";
import LichHocTheoTuan from "./pages/PageContent/LichHocTheoTuan/LichHocTheoTuan";
import LichThi from "./pages/PageContent/LichThi/LichThi";
import ThongTinHocBa from "./pages/PageContent/ThongTinHocBa/ThongTinHocBa";
import DanhSachLopHoc from "./pages/PageContent/DanhSachLopHoc/DanhSachLopHoc";
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
            <Route path="/TrangChu" element={<HomePage />} />
            <Route path="/ThongTinCaNhan" element={<InfoPage />} />
            <Route path="/DoiMatKhau" element={<HomePage />} />
            <Route path="/ChuongTrinhHoc" element={<ChuongTrinhHoc />} />
            <Route path="/LichHocTheoTuan" element={<LichHocTheoTuan />} />
            <Route path="/LichThi" element={<LichThi />} />
            <Route path="/ThongTinHocBa" element={<ThongTinHocBa />} />
            <Route path="/DanhSachHocSinh" element={<DanhSachLopHoc />} />
          </Route>
          {/* </Route> */}
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;

import { configureStore } from "@reduxjs/toolkit";
import { drawerSlice } from "./drawerReducer/drawerReducer";
import { globalSlice } from "./globalReducer/globalReducer";
import { infoSlice } from "./infoReducer/infoReducer";
import { popUpSlice } from "./modalReducer/modalReducer";
import { danTocSlice } from "./danTocReducer/danTocReducer";
import { tonGiaoSlice } from "./tonGiaoReducer/tonGiaoReducer";
import { khoaHocSlice } from "./khoaHocReducer/khoaHocReducer";
import { chuongTrinhHocSlice } from "./chuongTrinhHocReducer/chuongTrinhHocReducer";
import { khoiSlice } from "./khoiReducer/khoiReducer";
import { chiTietLopSlice } from "./chiTietLopReducer/chiTietLopReducer";
import { hocBaSlice } from "./hocBaReducer/hocBaReducer";
import { diemThiSlice } from "./diemThiReducer/diemThiReducer";
import { kyThiSlice } from "./kyThiReducer/kyThiReducer";
import { thoiKhoaBieuSlice } from "./thoiKhoaBieuReducer/thoiKhoaBieuReducer";

const store = configureStore({
  reducer: {
    global: globalSlice.reducer,
    info: infoSlice.reducer,
    popup: popUpSlice.reducer,
    drawer: drawerSlice.reducer,
    dantoc: danTocSlice.reducer,
    tongiao: tonGiaoSlice.reducer,
    khoahoc: khoaHocSlice.reducer,
    chuongtrinhhoc: chuongTrinhHocSlice.reducer,
    khoi: khoiSlice.reducer,
    chitietlop: chiTietLopSlice.reducer,
    hocba: hocBaSlice.reducer,
    diemthi: diemThiSlice.reducer,
    kythi: kyThiSlice.reducer,
    thoikhoabieu : thoiKhoaBieuSlice.reducer
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});

export default store;

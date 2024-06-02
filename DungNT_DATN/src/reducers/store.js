import { configureStore } from "@reduxjs/toolkit";
import { drawerSlice } from "./drawerReducer/drawerReducer";
import { globalSlice } from "./globalReducer/globalReducer";
import { infoSlice } from "./infoReducer/infoReducer";
import { popUpSlice } from "./modalReducer/modalReducer";
import { danTocSlice } from "./danTocReducer/danTocReducer";
import { tonGiaoSlice } from "./tonGiaoReducer/tonGiaoReducer";

const store = configureStore({
  reducer: {
    global: globalSlice.reducer,
    info: infoSlice.reducer,
    popup: popUpSlice.reducer,
    drawer: drawerSlice.reducer,
    dantoc: danTocSlice.reducer,
    tongiao: tonGiaoSlice.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});

export default store;

import { createSlice } from "@reduxjs/toolkit";
import { dantocservice } from "../../services/danTocService/danTocService";
import { chuongtrinhhocservice } from "../../services/chuongTrinhHocService/chuongTrinhHocService";

export const chuongTrinhHocSlice = createSlice({
  name: "chuongtrinhhoc",
  initialState: {
    listTruongTrinhHoc: [],
  },
  reducers: {
    setListTruongChinhHoc: (state, action) => {
      state.listTruongTrinhHoc = action.payload;
    },
  },
});
export const getListChuongTrinhHocAction = (khoiId) => async (dispatch) => {
  try {
    const response = await chuongtrinhhocservice.getChuongTrinhHocTheoKhoi(khoiId);
    if (response.status === 200) {
      dispatch(setListTruongChinhHoc(response.data.value));
    //   const listDantocSelect = response.data.value.map((item) => {
    //     return {
    //       value: item.id,
    //       label: item.tenDanToc,
    //     };
    //   });

    //   dispatch(setListDanTocSelect(listDantocSelect));
    }
  } catch (err) {
    console.log(err);
  }
};

export const { setListTruongChinhHoc } = chuongTrinhHocSlice.actions;
export const chuongTrinhHocState = (state) => state.chuongtrinhhoc;
export default chuongTrinhHocSlice.reducer;

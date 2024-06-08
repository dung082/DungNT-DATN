import { createSlice } from "@reduxjs/toolkit";
import { dantocservice } from "../../services/danTocService/danTocService";
import { chuongtrinhhocservice } from "../../services/chuongTrinhHocService/chuongTrinhHocService";

export const chuongTrinhHocSlice = createSlice({
  name: "chuongtrinhhoc",
  initialState: {
    pageNumber: 1,
    pageSize: 10,
    listTruongTrinhHoc: [],
  },
  reducers: {
    setListTruongChinhHoc: (state, action) => {
      state.listTruongTrinhHoc = action.payload;
    },
    setAdvanceSearch: (state, action) => {
      state.pageNumber = action.payload.pageNumber;
      state.pageSize = action.payload.pageSize;
    },
  },
});
export const getListChuongTrinhHocAction = (khoiId) => async (dispatch) => {
  try {
    const response = await chuongtrinhhocservice.getChuongTrinhHocTheoKhoi(
      khoiId
    );
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

export const { setListTruongChinhHoc, setAdvanceSearch } =
  chuongTrinhHocSlice.actions;
export const chuongTrinhHocState = (state) => state.chuongtrinhhoc;
export default chuongTrinhHocSlice.reducer;

import { createSlice } from "@reduxjs/toolkit";
import { chuongtrinhhocservice } from "../../services/chuongTrinhHocService/chuongTrinhHocService";
import { chitietlopservice } from "../../services/chiTietLopHocService/chiTietLopHocService";

export const chiTietLopSlice = createSlice({
  name: "chitietlop",
  initialState: {
    pageNumber: 1,
    pageSize: 10,
    listHs: {},
  },
  reducers: {
    setListHocSinhAction: (state, action) => {
      state.listHs = action.payload;
    },
    setAdvanceSearchCTLopAction: (state, action) => {
      state.pageNumber = action.payload.pageNumber;
      state.pageSize = action.payload.pageSize;
    },
  },
});
export const getListHocSinhTrongLopAction = (username) => async (dispatch) => {
  try {
    const response = await chitietlopservice.getHSInClass(username);
    if (response.status === 200) {
      dispatch(setListHocSinhAction(response.data.value));
    }
  } catch (err) {
    console.log(err);
  }
};

export const { setListHocSinhAction, setAdvanceSearchCTLopAction } =
  chiTietLopSlice.actions;
export const chiTietLopState = (state) => state.chitietlop;
export default chiTietLopSlice.reducer;

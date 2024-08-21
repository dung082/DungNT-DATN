import { createSlice } from "@reduxjs/toolkit";
import { chuongtrinhhocservice } from "../../services/chuongTrinhHocService/chuongTrinhHocService";
import { chitietlopservice } from "../../services/chiTietLopHocService/chiTietLopHocService";
import { openWarning } from "../../templates/notification";

export const chiTietLopSlice = createSlice({
  name: "chitietlop",
  initialState: {
    pageNumber: 1,
    pageSize: 10,
    listHs: {},
    listHocSinh: []
  },
  reducers: {
    setListHocSinhAction: (state, action) => {
      state.listHs = action.payload;
    },
    setAdvanceSearchCTLopAction: (state, action) => {
      state.pageNumber = action.payload.pageNumber;
      state.pageSize = action.payload.pageSize;
    },
    setListHsAction: (state, action) => {
      state.listHocSinh = action.payload
    }
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

export const getListHocSinhAction = (namhoc, lopId) => async (dispatch) => {
  try {
    const res = await chitietlopservice.getHSLopNamHoc(namhoc, lopId)
    if (res.status === 200) {
      const listHocSinh = res?.data?.value?.map(i => {
        return {
          username: i.username,
          hoTen: i?.hoTen,
          ngaySinh: i?.ngaySinh,
          gioiTinh: i?.gioiTinh,
          diem: (Math.random() * 4 + 6).toFixed(2)
        }
      })
      dispatch(setListHsAction(listHocSinh))
    }
  }
  catch (err) {
    openWarning("Thất bại", err?.response?.data?.Message)
  }
}



export const { setListHocSinhAction, setAdvanceSearchCTLopAction, setListHsAction } =
  chiTietLopSlice.actions;
export const chiTietLopState = (state) => state.chitietlop;
export default chiTietLopSlice.reducer;

import { createSlice } from "@reduxjs/toolkit";
import { thoikhoabieuservice } from "../../services/thoiKhoaBieuService/thoiKhoaBieuService";
import { openWarning } from "../../templates/notification";

export const thoiKhoaBieuSlice = createSlice({
  name: "thoikhoabieu",
  initialState: {
    thoiKhoaBieu: {},
    chiTietTKB: {},
    pageNumber: 1,
    pageSize: 10,
  },
  reducers: {
    setThoiKhoaBieu: (state, action) => {
      state.thoiKhoaBieu = action.payload;
    },
    setChiTietTkb: (state, action) => {
      state.chiTietTKB = action.payload;
    },
    setPageInformationTKB: (state, action) => {
      state.pageNumber = action.payload.pageNumber;
      state.pageSize = action.payload.pageSize;
    },
  },
});

export const getThoiKhoaBieuAction =
  (ngayHoc, username) => async (dispatch) => {
    try {
      const res = await thoikhoabieuservice.getThoiKhoaBieu(ngayHoc, username);
      if (res.status === 200) {
        dispatch(setThoiKhoaBieu(res.data.value));
      }
    } catch (err) {
      openWarning("Thất bại", "Có lỗi xảy ra khi lấy thời khóa biểu");
    }
  };

export const getChiTietThoiKhoaBieuAction = (tkbId) => async (dispatch) => {
  try {
    const res = await thoikhoabieuservice.getChiTietThoiKhoaBieu(tkbId);
    if (res.status === 200) {
      console.log(res);
      dispatch(setChiTietTkb(res.data));
    }
  } catch (err) {
    openWarning("Thất bại", "Có lỗi xảy ra khi lấy thời khóa biểu");
  }
};

export const { setThoiKhoaBieu, setChiTietTkb, setPageInformationTKB } =
  thoiKhoaBieuSlice.actions;
export const thoiKhoaBieuState = (state) => state.thoikhoabieu;
export default thoiKhoaBieuSlice.reducer;

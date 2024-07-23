import { createSlice } from "@reduxjs/toolkit";
import { openWarning } from "../../templates/notification";
import { lichthiservice } from "../../services/lichThiService/lichThiService";

export const lichThiSlice = createSlice({
  name: "lichthi",
  initialState: {
    lichThi: {},
    chiTietLichThi: {},
    pageNumber: 1,
    pageSize: 10,
  },
  reducers: {
    setLichThi: (state, action) => {
      state.lichThi = action.payload;
    },
    setChiTietLichThi: (state, action) => {
      state.chiTietLichThi = action.payload;
    },
    // setPageInformationTKB: (state, action) => {
    //   state.pageNumber = action.payload.pageNumber;
    //   state.pageSize = action.payload.pageSize;
    // },
  },
});

export const getLichThiAction =
  (ngayHoc, username) => async (dispatch) => {
    try {
      const res = await lichthiservice.getLichThi(ngayHoc, username);
      if (res.status === 200) {
        dispatch(setLichThi(res.data.value));
      }
    } catch (err) {
      openWarning("Thất bại", "Có lỗi xảy ra khi lấy lịch thi");
    }
  };

export const getChiTietLichThiAction = (lichThiId, username) => async (dispatch) => {
  try {
    const res = await lichthiservice.getDetailLichThi(lichThiId, username);
    if (res.status === 200) {
      dispatch(setChiTietLichThi(res.data.value));
    }
  } catch (err) {
    openWarning("Thất bại", "Có lỗi xảy ra khi chi tiết lịch thi");
  }
};

export const { setLichThi, setChiTietLichThi } =
  lichThiSlice.actions;
export const lichThiState = (state) => state.lichthi;
export default lichThiSlice.reducer;

import { createSlice } from "@reduxjs/toolkit";
import { khoahocservice } from "../../services/khoaHocService/khoaHocService";

export const khoaHocSlice = createSlice({
  name: "khoahoc",
  initialState: {
    listKhoaHoc: [],
    listKhoaHocSelect: [],
  },
  reducers: {
    setListKhoaHoc: (state, action) => {
      state.listKhoaHoc = action.payload;
    },
    setListKhoaHocSelect: (state, action) => {
      state.listKhoaHocSelect = action.payload;
    },
  },
});
export const getListKhoaHocAction = () => async (dispatch) => {
  try {
    const response = await khoahocservice.getAllKhoaHoc();
    if (response.status === 200) {
      dispatch(setListKhoaHoc(response.data.value));
      const listKhoaHocSelect = response.data.value.map((item) => {
        return {
          value: item.id,
          label: item.tenKhoaHoc,
        };
      });

      dispatch(setListKhoaHocSelect(listKhoaHocSelect));
    }
  } catch (err) {
    console.log(err);
  }
};

export const { setListKhoaHoc, setListKhoaHocSelect } = khoaHocSlice.actions;
export const khoaHocState = (state) => state.khoahoc;
export default khoaHocSlice.reducer;

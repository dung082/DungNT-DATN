import { createSlice } from "@reduxjs/toolkit";
import { khoahocservice } from "../../services/khoaHocService/khoaHocService";
import { khoiservice } from "../../services/khoiService/khoiService";

export const khoiSlice = createSlice({
  name: "khoi",
  initialState: {
    listKhoi: [],
    listKhoiSelect: [],
  },
  reducers: {
    setListKhoi: (state, action) => {
      state.listKhoi = action.payload;
    },
    setListKhoiSelect: (state, action) => {
      state.listKhoiSelect = action.payload;
    },
  },
});
export const getListKhoiAction = () => async (dispatch) => {
  try {
    const response = await khoiservice.getAllKhoi();
    if (response.status === 200) {
      dispatch(setListKhoi(response.data.value));
      const listKhoaHocSelect = response.data.value.map((item) => {
        return {
          value: item.id,
          label: item.tenKhoi,
        };
      });

      dispatch(setListKhoiSelect(listKhoaHocSelect));
    }
  } catch (err) {
    console.log(err);
  }
};

export const { setListKhoi, setListKhoiSelect } = khoiSlice.actions;
export const khoiState = (state) => state.khoi;
export default khoiSlice.reducer;

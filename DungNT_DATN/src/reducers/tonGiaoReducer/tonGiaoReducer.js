import { createSlice } from "@reduxjs/toolkit";
import { dantocservice } from "../../services/danTocService/danTocService";
import { tongiaoservice } from "../../services/tonGiaoService/tonGiaoService";

export const tonGiaoSlice = createSlice({
  name: "tongiao",
  initialState: {
    listTonGiao: [],
    listTonGiaoSelect: [],
  },
  reducers: {
    setListTonGiao: (state, action) => {
      state.listTonGiao = action.payload;
    },
    setListTonGiaoSelect: (state, action) => {
      state.listTonGiaoSelect = action.payload;
    },
  },
});
export const getListTonGiaoAction = () => async (dispatch) => {
  try {
    const response = await tongiaoservice.getAllTonGiao();
    if (response.status === 200) {
      dispatch(setListTonGiao(response.data.value));
      const listTonGiaoSelect = response.data.value.map((item) => {
        return {
          value: item.id,
          label: item.tenTonGiao,
        };
      });

      dispatch(setListTonGiaoSelect(listTonGiaoSelect));
    }
  } catch (err) {
    console.log(err);
  }
};

export const { setListTonGiao, setListTonGiaoSelect } = tonGiaoSlice.actions;
export const tonGiaoState = (state) => state.tongiao;
export default tonGiaoSlice.reducer;

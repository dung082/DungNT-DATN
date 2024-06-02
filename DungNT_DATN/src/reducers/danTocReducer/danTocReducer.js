import { createSlice } from "@reduxjs/toolkit";
import { dantocservice } from "../../services/danTocService/danTocService";

export const danTocSlice = createSlice({
  name: "dantoc",
  initialState: {
    listDanToc: [],
    lstDanTocSelect: [],
  },
  reducers: {
    setListDanToc: (state, action) => {
      state.listDanToc = action.payload;
    },
    setListDanTocSelect: (state, action) => {
      state.lstDanTocSelect = action.payload;
    },
  },
});
export const getListDanTocAction = () => async (dispatch) => {
  try {
    const response = await dantocservice.getAllDanToc();
    if (response.status === 200) {
      dispatch(setListDanToc(response.data.value));
      const listDantocSelect = response.data.value.map((item) => {
        return {
          value: item.id,
          label: item.tenDanToc,
        };
      });

      dispatch(setListDanTocSelect(listDantocSelect));
    }
  } catch (err) {
    console.log(err);
  }
};

export const { setListDanToc, setListDanTocSelect } = danTocSlice.actions;
export const danTocState = (state) => state.dantoc;
export default createSlice.reducer;

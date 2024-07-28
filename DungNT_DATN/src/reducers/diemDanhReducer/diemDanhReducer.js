import { createSlice } from "@reduxjs/toolkit";
import { diemdanhservice } from "../../services/diemDanhService/diemDanhService";
import { openNotification } from "../../templates/notification";
import { closeModalAction } from "../modalReducer/modalReducer";

export const diemDanhSlice = createSlice({
  name: "diemdanh",
  initialState: {
    diemDanh: {},
    listCaHoc: []
  },
  reducers: {
    setDiemDanh: (state, action) => {
      state.diemDanh = action.payload;
    },
    setListCaHoc: (state, action) => {
      state.listCaHoc = action.payload;
    }
  },
});

export const getDiemDanhAction =
  (ngay, username) => async (dispatch) => {
    try {
      const res = await diemdanhservice.getDiemDanh(ngay, username);
      if (res.status === 200) {
        dispatch(setDiemDanh(res.data.value));
      }
    } catch (err) {
      dispatch(setDiemDanh({}));
      //   dispatch(setErrorMessage(err.response.data.Message));
    }
  };

export const getListCaHocAction = () => async (dispatch) => {
  try {
    const res = await diemdanhservice.getCaHoc();
    if (res.status === 200) {
      const newList = res.data.value?.map(item => {
        return {
          label: item.tenCaHoc,
          value: item.id
        }
      })
      dispatch(setListCaHoc(newList))
    }
  }
  catch (err) {
    console.log(err);
  }
}

export const xinNghiAction = (data) => async (dispatch) => {
  try {
    const res = await diemdanhservice.addDiemDanh(data);
    if (res.status === 200) {
      openNotification("Thành công", "Nộp đơn xin nghỉ thành công");
      dispatch(getDiemDanhAction("", data?.username))
      dispatch(closeModalAction())
    }
  }
  catch (err) {
    console.log(err);
  }

}


export const suaDiemDanhAction = (data) => async (dispatch) => {
  try {
    const res = await diemdanhservice.suaDiemDanh(data);
    if (res.status === 200) {
      openNotification("Thành công", "Sửa đơn xin nghỉ thành công");
      dispatch(getDiemDanhAction("", data?.username))
      dispatch(closeModalAction())
    }
  }
  catch (err) {
    console.log(err);
  }

}


export const xoaDiemDanhAction = (diemDanhId , username) => async (dispatch) => {
  try {
    const res = await diemdanhservice.xoaDiemDanh(diemDanhId);
    if (res.status === 200) {
      openNotification("Thành công", "Xóa đơn xin nghỉ thành công");
      dispatch(getDiemDanhAction("", username))
      dispatch(closeModalAction())
    }
  }
  catch (err) {
    console.log(err);
  }

}


export const {
  setDiemDanh,
  setListCaHoc
} = diemDanhSlice.actions;
export const diemDanhState = (state) => state.diemdanh;
export default diemDanhSlice.reducer;

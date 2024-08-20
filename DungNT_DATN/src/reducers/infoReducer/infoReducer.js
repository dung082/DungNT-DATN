import { createSlice } from "@reduxjs/toolkit";
import { infoservice } from "../../services/infoService/infoService";
import { openNotification, openWarning } from "../../templates/notification";
import { closeDrawerAction } from "../drawerReducer/drawerReducer";

export const infoSlice = createSlice({
  name: "info",
  initialState: {
    userInfomation: {},
    listHocSinh: [],
    pageNumber: 1,
    pageSize: 10,
    listHocKy: [],
    listKyThi: [],
    listLop: [],
    namHoc: "",
    kythi: "",
    lop: "",
    monthi: ""
  },
  reducers: {
    setUserInfomation: (state, action) => {
      state.userInfomation = action.payload;
    },
    setListHocSinh: (state, action) => {
      state.listHocSinh = action.payload;
    },
    setAdvanceSearchQLHS: (state, action) => {
      state.pageNumber = action.payload.pageNumber
      state.pageSize = action.payload.pageSize
    },
    setNamHoc: (state, action) => {
      state.namHoc = action.payload
    },
    setKyThi: (state, action) => {
      state.kythi = action.payload
    },
    setLop: (state, action) => {
      state.lop = action.payload
    },
    setMonThi: (state, action) => {
      state.monthi = action.payload
    }
  },
});

export const getUserInfomationAction = (id) => async (dispatch) => {
  try {
    const response = await infoservice.getUserInfomation(id);
    if (response.status === 200) {
      dispatch(setUserInfomation(response.data.value));
    }
  } catch (err) {
    openWarning("Thất bại", "Không thể lấy thông tin người dùng");
    console.log(err);
  }
};

export const layTatCaHocSinhAction = () => async (dispatch) => {
  try {
    const response = await infoservice.layTatCaHocSinh();
    if (response.status === 200) {
      dispatch(setListHocSinh(response.data.value))
    }
  }
  catch (err) {
    console.log(err);
  }
}

export const updateUserInfomationAction =
  (user, refresh) => async (dispatch) => {
    try {
      const response = await infoservice.updateUserInfomation(user);
      if (response.status === 200) {
        // dispatch(setUserInfomation(response.data.value));
        openNotification(
          "Thành công",
          "Cập nhật thông tin người dùng thành công"
        );

        dispatch(closeDrawerAction());
        refresh();
      }
    } catch (err) {
      openWarning("Thất bại", "Cập nhật thông tin người dùng thất bại");
      console.log(err);
    }
  };

export const themNguoiDungAction =
  (user, refresh) => async (dispatch) => {
    try {
      const response = await infoservice.themNguoiDung(user);
      if (response.status === 200) {
        // dispatch(setUserInfomation(response.data.value));
        openNotification(
          "Thành công",
          "Thêm người dùng thành công"
        );

        dispatch(closeDrawerAction());
        refresh();
      }
    } catch (err) {
      openWarning("Thất bại", err.response.data.Message);
      console.log(err);
    }
  };

export const { setUserInfomation, setListHocSinh, setAdvanceSearchQLHS, setNamHoc, setLop, setKyThi, setMonThi } = infoSlice.actions;
export const infoState = (state) => state.info;
export default infoSlice.reducer;

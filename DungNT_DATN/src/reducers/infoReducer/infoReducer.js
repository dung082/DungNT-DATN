import { createSlice } from "@reduxjs/toolkit";
import { infoservice } from "../../services/infoService/infoService";
import { openNotification, openWarning } from "../../templates/notification";
import { closeDrawerAction } from "../drawerReducer/drawerReducer";

export const infoSlice = createSlice({
  name: "info",
  initialState: {
    userInfomation: {},
  },
  reducers: {
    setUserInfomation: (state, action) => {
      state.userInfomation = action.payload;
    },
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

export const { setUserInfomation } = infoSlice.actions;
export const infoState = (state) => state.info;
export default infoSlice.reducer;

import { createSlice } from "@reduxjs/toolkit";
import { thoikhoabieuservice } from "../../services/thoiKhoaBieuService/thoiKhoaBieuService";
import { openWarning } from "../../templates/notification";

export const thoiKhoaBieuSlice = createSlice({
    name: "thoikhoabieu",
    initialState: {
        thoiKhoaBieu: {}
    },
    reducers: {
        setThoiKhoaBieu: (state, action) => {
            state.thoiKhoaBieu = action.payload;
        },
    },
});

export const getThoiKhoaBieuAction = (ngayHoc, username) => async (dispatch) => {
    try {
        const res = await thoikhoabieuservice.getThoiKhoaBieu(ngayHoc, username);
        if (res.status === 200) {
            dispatch(setThoiKhoaBieu(res.data.value))
        }
    } catch (err) {
        openWarning("Thất bại", "Có lỗi xảy ra khi lấy thời khóa biểu")
    }
}


export const { setThoiKhoaBieu } =
    thoiKhoaBieuSlice.actions;
export const thoiKhoaBieuState = (state) => state.thoikhoabieu;
export default thoiKhoaBieuSlice.reducer;

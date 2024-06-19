import { createSlice } from "@reduxjs/toolkit";
import { openWarning } from "../../templates/notification";
import { hocbaservice } from "../../services/hocBaService/hocBaService";

export const hocBaSlice = createSlice({
    name: "hocba",
    initialState: {
        hocba: {},
    },
    reducers: {
        setHocBa: (state, action) => {
            state.hocba = action.payload;
        },
    },
});

export const getHocBaAction = (username, lop) => async (dispatch) => {
    try {
        const res = await hocbaservice.getHocBa(username, lop);
        if (res.status === 200) {
            dispatch(setHocBa(res.data.value))
        }
    }
    catch (err) {
        openWarning("Có lỗi khi lấy thông tin học bạ")
    }
}

export const { setHocBa } = hocBaSlice.actions;
export const hocBaState = (state) => state.hocba;
export default hocBaSlice.reducer;

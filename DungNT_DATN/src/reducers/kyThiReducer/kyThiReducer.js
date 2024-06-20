import { createSlice } from "@reduxjs/toolkit";
import { chuongtrinhhocservice } from "../../services/chuongTrinhHocService/chuongTrinhHocService";
import { chitietlopservice } from "../../services/chiTietLopHocService/chiTietLopHocService";
import { kythiservice } from "../../services/kyThiService/kyThiService";

export const kyThiSlice = createSlice({
    name: "kythi",
    initialState: {
        listKyThi: []
    },
    reducers: {
        setListKyThi: (state, action) => {
            state.listKyThi = action.payload;
        },
    },
});
export const getListKyThiAction = (namHoc) => async (dispatch) => {
    try {
        const response = await kythiservice.getKyThiTheoNam(namHoc);
        if (response.status === 200) {
            const list = response.data?.value?.map((item) => {
                return {
                    value: item.id,
                    label: item.tenKyThi
                }
            })
            dispatch(setListKyThi(list))
        }
    } catch (err) {
        console.log(err);
    }
};

export const { setListKyThi } =
    kyThiSlice.actions;
export const kyThiState = (state) => state.kythi;
export default kyThiSlice.reducer;

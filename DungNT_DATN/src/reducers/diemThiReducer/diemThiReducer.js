import { createSlice } from "@reduxjs/toolkit";
import { dantocservice } from "../../services/danTocService/danTocService";
import { diemthiservice } from "../../services/diemThiService/DiemThiService";
import { act } from "react";

export const diemThiSlice = createSlice({
    name: "diemthi",
    initialState: {
        diemThi: {},
        typeSearch: 0,
        pageNumber: 1,
        pageSize: 10,
        kyThi: "",
        namHoc: "",
        errorMessage: ""
    },
    reducers: {
        setDiemThi: (state, action) => {
            state.diemThi = action.payload;
        },
        setAdvanceSearchDiemThi: (state, action) => {
            state.pageNumber = action.payload.pageNumber;
            state.pageSize = action.payload.pageSize
        },
        setTypeSearch: (state, action) => {
            state.typeSearch = action.payload
        },
        setKyThi: (state, action) => {
            state.kyThi = action.payload
        },
        setNamHoc: (state, action) => {
            state.namHoc = action.payload
        },
        setErrorMessage: (state, action) => {
            state.errorMessage = action.payload
        }
    },
});

export const getDiemThiAction = (type, username, kyThiId) => async (dispatch) => {
    try {
        const res = await diemthiservice.getDiemThi(type, username, kyThiId);
        if (res.status === 200) {
            dispatch(setDiemThi(res.data.value))
            dispatch(setKyThi(res.data.value?.kythi?.id))
            dispatch(setNamHoc(res.data.value?.namhoc))
        }
    }
    catch (err) {
        dispatch(setDiemThi(null))
        dispatch(setErrorMessage(err.response.data.Message))

    }
}

export const { setDiemThi, setAdvanceSearchDiemThi, setTypeSearch, setKyThi, setNamHoc, setErrorMessage } = diemThiSlice.actions;
export const diemThiState = (state) => state.diemthi;
export default diemThiSlice.reducer;
